using Domain.AggregatesModel;
using Domain.SeedWork;
using Infrastructure.EntityTypeConfigurations;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Infrastructure.DbContexts
{
    internal class UserContext : DbContext, IUnitOfWork
    {
        public DbSet<User> Users { get; set; }

        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {

        }

        public Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            throw new NotImplementedException();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfigurationsFromAssembly(typeof(UserContext).Assembly);
            modelBuilder.ApplyConfiguration(new UserEntityTypeConfigurations());
        }
    }
}
