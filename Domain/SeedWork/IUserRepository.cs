using Domain.AggregatesModel;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.SeedWork
{
    public interface IUserRepository : IRepository<User>
    {
        Task<User> GetAsync(string userName, CancellationToken cancellationToken = default);
    }
}
