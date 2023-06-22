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
        bool Contains(object value);
        void Clear();
        int IndexOf(object value);
        void Insert(int index, object value);
        void Remove(object value);
        void RemoveAt(int index);
    }
    internal interface IMyList<T>
    {
        T this[int index] { get; set; }
    }
    //internal interface IMyList
    internal interface IMyCollection : IMyEnumerable
    {
        int Count { get; }
        void Clear();
        public object[] ToArray();
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
