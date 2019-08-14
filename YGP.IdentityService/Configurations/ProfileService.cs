using IdentityServer4.Models;
using IdentityServer4.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace YGP.IdentityService
{
    public class ProfileService : IProfileService
    {
        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            await Task.CompletedTask;

            //depending on the scope accessing the user data.
            var claims = context.Subject.Claims;

            //set issued claims to return
            context.IssuedClaims = claims.ToList();
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {
            await Task.CompletedTask;

            context.IsActive = true;
        }
    }
}
