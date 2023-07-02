using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;

namespace DZ_5
{
    public interface IMyList : IMyCollection, IMyEnumerable
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
    public interface IMyCollection
    {
        int Count { get; }
        object [] ToArray();
    }
    public interface IMyEnumerable
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

namespace DZ_5.Generic
{    
    public interface IMyList<T> : IMyCollection<T>, IMyEnumerable<T>, IMyEnumerable
    {
        T this[int index] { get; set; }
        int IndexOf(T inItem);
        void Insert(int index, T inItem);
        void RemoveAt(int index);
    }
    public interface IMyCollection<T>
    {
        int Count { get; }
        void Add(T inItem);
        void Clear();
        bool Contains(T item);
        T[] ToArray();
    }

    public interface IMyEnumerable<out T> : IMyEnumerable
    {
        new IMyEnumerator<T> GetEnumerator();
    }
    public interface IMyEnumerator<out T> : IMyEnumerator
    {
        T Current
        {
            get;
        }
    }
}