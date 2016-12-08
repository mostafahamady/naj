using System;

namespace Naj.Common
{
    public interface IEntity<TKey>
        where TKey:IComparable<TKey>
    {
        TKey Id { get; set; }
    }
}
