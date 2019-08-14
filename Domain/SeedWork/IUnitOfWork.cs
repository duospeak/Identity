using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Domain.SeedWork
{
    /// <summary>
    /// 用于数据持久化的工作单元
    /// </summary>
    public interface IUnitOfWork : IDisposable
    {

        /// <summary>
        /// 保存收集的所有实体变更
        /// </summary>
        /// <param name="cancellationToken"></param>
        /// <returns></returns>
        Task<int> SaveEntitiesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
