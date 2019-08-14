using Domain.AggregatesModel;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.SeedWork
{
    /// <summary>
    /// 表示仓储
    /// </summary>
    /// <typeparam name="TEntity"></typeparam>
    public interface IRepository<TEntity>
        where TEntity : IAggregateRoot
    {
        /// <summary>
        /// 收集该仓储更改的工作单元
        /// </summary>
        IUnitOfWork UnitOfWork { get; }
    }
}
