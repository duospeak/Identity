using Domain.SeedWork;
using IdentityModel;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using YGP.IdentityService.Configurations;

namespace YGP.IdentityService
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly ILogger<ResourceOwnerPasswordValidator> _logger;
        private readonly IUserRepository _userRepository;
        private readonly DefaultOptions _defaultOptions;

        public ResourceOwnerPasswordValidator(ILogger<ResourceOwnerPasswordValidator> logger,
            IUserRepository userRepository,
            IOptions<DefaultOptions> defaultOptions)
        {
            _logger = logger;
            _userRepository = userRepository;
            _defaultOptions = defaultOptions.NotNull(nameof(defaultOptions)).Value;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = await _userRepository.GetAsync(context.UserName);
            if (user == null)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest, "用户不存在");
                return;
            }

            var password = (_defaultOptions.PasswordHashSalt + context.Password).GetMD5();
            if (user.Password != password)
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest, "密码错误");
                return;
            }

            context.Result = new GrantValidationResult(user.Id.ToString(), OidcConstants.AuthenticationMethods.Password, new List<Claim>()
            {
                    new Claim(YgpClaimTypes.TenantId,user.TenantId.ToString()),
                    new Claim(YgpClaimTypes.UserId,user.Id.ToString()),
                    new Claim(YgpClaimTypes.UserName,user.UserName.ToString()),
                    new Claim(YgpClaimTypes.OrgId,user.OrgId.ToString())
            });
        }
    }
}
