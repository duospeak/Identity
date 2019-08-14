using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.AggregatesModel
{
    /// <summary>
    /// 表示领域实体中的聚合根
    /// <para>
    /// 聚合根具有全局的唯一标识
    /// 一个Bounded Context（界定的上下文）可能包含多个聚合，每个聚合都有一个根实体，叫做聚合根；
    /// </para>
    /// </summary>
    public interface IAggregateRoot
    {
    }
}
