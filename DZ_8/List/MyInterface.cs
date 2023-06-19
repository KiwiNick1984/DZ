using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    internal interface IMyList : IMyEnumerable
    {
        object this[int index] { get; set; }
        void Add(object value);
        void Clear();
        bool Contains(object value);
        int IndexOf(object value);
        void Insert(int index, object value);
        void Remove(object value);
        void RemoveAt(int index);
    }
    internal interface IMyCollection : IMyEnumerable
    {
        int Count { get; }
    }

    internal interface IMyEnumerable
    {
        IMyEnumerator GetEnumerator();
    }
    public interface IMyEnumerator
    {
        object Current { get; }
        bool MoveNext();
        void Reset();
    }
}
