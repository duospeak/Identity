using Domain.AggregatesModel;
using Domain.SeedWork;
using Infrastructure.DbContexts;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    internal class UserRepository : IUserRepository
    {
        public IUnitOfWork UnitOfWork => throw new NotImplementedException();

        private readonly UserContext _context;

        public UserRepository(UserContext context)
            => _context = context ?? throw new ArgumentNullException(nameof(context));

        public async Task<User> GetAsync(string userName, CancellationToken cancellationToken = default)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.UserName == userName && !x.IsLocked, cancellationToken);

            return user;
        }
    }
}
