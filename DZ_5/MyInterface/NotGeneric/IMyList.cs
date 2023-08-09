namespace DZ_5
{
    public interface IMyList : IMyCollection, IMyEnumerable
    {
        object this[int index] { get; set; }
        void Add(object value);
        int IndexOf(object value);
        void Insert(int index, object value);
        void Remove(object value);
        void RemoveAt(int index);
    }
}
