using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Domain.SeedWork
{
    /// <summary>
    /// 领域驱动值对象
    /// </summary>
    public abstract class ValueObject
    {
        /// <summary>
        /// 获取所有属性的值
        /// </summary>
        /// <returns></returns>
        public abstract IEnumerable<object> GetAtomicValues();
        /// <summary>
        /// 比较俩个值对象是否相等
        /// </summary>
        /// <param name="obj"></param>
        /// <returns></returns>
        public override bool Equals(object obj)
        {
            if (obj == null || obj.GetType() != GetType())
            {
                return false;
            }
            var other = (ValueObject)obj;
            IEnumerator<object> thisValues = GetAtomicValues().GetEnumerator();
            IEnumerator<object> otherValues = other.GetAtomicValues().GetEnumerator();
            while (thisValues.MoveNext() && otherValues.MoveNext())
            {
                if (ReferenceEquals(thisValues.Current, null) ^ ReferenceEquals(otherValues.Current, null))
                {
                    return false;
                }
                if (thisValues.Current != null && !thisValues.Current.Equals(otherValues.Current))
                {
                    return false;
                }
            }
            return !thisValues.MoveNext() && !otherValues.MoveNext();
        }
        /// <summary>
        /// 计算值对象的hashcode
        /// </summary>
        /// <returns></returns>
        public override int GetHashCode()
        {
            return GetAtomicValues()
             .Select(x => x != null ? x.GetHashCode() : 0)
             .Aggregate((x, y) => x ^ y);
        }
        /// <summary>
        /// 获取复制的相同对象
        /// </summary>
        /// <returns></returns>
        public ValueObject GetCopy()
        {
            return MemberwiseClone() as ValueObject;
        }
    }
}
