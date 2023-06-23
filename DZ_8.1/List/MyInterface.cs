namespace DZ_8
{
    public interface IMyList : IMyEnumerable
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
namespace DZ_8.Generic
{    public interface IMyList<T> : IMyEnumerable<T>
    {
        T this[int index] { get; set; }
        void Add(T inItem);
        int IndexOf(T inItem);
        void Insert(int index, T inItem);
        void RemoveAt(int index);
    }
    public interface IMyCollection<T>
    {
        int Count { get; }
        void Clear();
        T[] ToArray();
    }
    public interface IMyEnumerable<out T>
    {
        IMyEnumerator<T> GetEnumerator();
    }
    public interface IMyEnumerator<out T> : IMyEnumerator
    {
        new T Current
        {
            get;
        }
    }
}