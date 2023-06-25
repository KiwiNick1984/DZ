using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataStructures
{
    public static class MyCoolLinq
    {
        class BaseEnum<T> : IEnumerable<T>
        {
            private readonly Func<IEnumerator<T>> _creator;

            public BaseEnum(Func<IEnumerator<T>> creator)
            {
                _creator = creator;
            }

            public IEnumerator<T> GetEnumerator()
            {
                return _creator();
            }

            IEnumerator IEnumerable.GetEnumerator()
            {
                return GetEnumerator();
            }
        }

        class FilterIterator<T> : IEnumerator<T>
        {
            private readonly IEnumerator<T> _iter;
            private readonly Predicate<T?> _predicate;

            public FilterIterator(IEnumerable<T> list, Predicate<T?> predicate)
            {
                _iter = list.GetEnumerator();
                _predicate = predicate;
            }

            public T Current => _iter.Current!;

            object IEnumerator.Current => _iter.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                bool res;
                do
                {
                    res = _iter.MoveNext();
                } while (!_predicate(Current) && res);
                return res;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        class SkipEnumerator<T> : IEnumerator<T>
        {
            private IEnumerator<T> enumerator;
            private int count;

            public SkipEnumerator(IEnumerable<T> enumerable, int count)
            {
                this.enumerator = enumerable.GetEnumerator();
                this.count = count;
            }

            public T Current => enumerator.Current;

            object IEnumerator.Current => enumerator.Current;

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                for (; count > 0; count--)
                {
                    enumerator.MoveNext();
                }

                return enumerator.MoveNext();
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }


        public static IEnumerable<T> Filter<T>(this IEnumerable<T> enumeration, Predicate<T?> predicate)
        {
            return new BaseEnum<T>(() => new FilterIterator<T>(enumeration, predicate));
        }

        public static IEnumerable<T> CoolSkip<T>(this IEnumerable<T> list, int count)
        {
            return new BaseEnum<T>(() => new SkipEnumerator<T>(list, count));
        }

        //public static IEnumerable Skip(this IEnumerable enumerable, int count, Predicate<object?> predicate)
        //{

        //}
    }

    public class List<T> : /*IList, Interfaces.IList,*/ IEnumerable<T>
    {
        private class Iterator<T> : IEnumerator<T>
        {
            private readonly List<T> _list;
            private int _index;

            public Iterator(List<T> list)
            {
                _list = list;
                _index = 0;
            }

            public T Current { get; private set; }

            object IEnumerator.Current => Current;

            //public object Current { get; private set; }

            public void Dispose()
            {
            }

            public bool MoveNext()
            {
                if (_index < _list.Count)
                {
                    Current = _list[_index++];
                    return true;
                }
                return false;
            }

            public void Reset()
            {
                throw new NotImplementedException();
            }
        }

        private T[] innerArray;
        private readonly object syncRoot = new object();
        private readonly int origCapacity;

        public List() : this(10)
        {
        }

        public List(int capacity)
        {
            origCapacity = capacity;
            innerArray = new T[capacity];
        }

        public T this[int index]
        {
            get
            {
                return innerArray[index];
            }
            set
            {
                innerArray[index] = value;
            }
        }

        public bool IsReadOnly => false;

        public bool IsFixedSize => false;

        public int Count { get; private set; }

        public int Capacity => innerArray.Length;

        public object SyncRoot => syncRoot;

        public bool IsSynchronized => false;

        public int Add(T value)
        {

            GrowingArray();

            var index = Count++;
            innerArray[index] = value;
            return index;
        }

        public void Clear()
        {

            Count = 0;
            innerArray = new T[origCapacity];
        }

        public bool Contains(T value) => IndexOf(value) >= 0;

        public void CopyTo(Array array, int index)
        {

            for (int innerIndex = 0; innerIndex < Count; innerIndex++, index++)
                array.SetValue(innerArray[innerIndex], index);
        }

        public int IndexOf(T value)
        {

            for (int index = 0; index < Count; index++)
                if (innerArray[index].Equals(value))
                    return index;
            return -1;
        }

        public void Insert(int index, T value)
        {

            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException();

            GrowingArray();

            T stored;
            for (; index < Count + 1; index++)
            {
                stored = innerArray[index];
                innerArray[index] = value;
                value = stored;
            }

            Count++;
        }

        public void Remove(T value)
        {

            var index = IndexOf(value);
            if (index >= 0)
                RemoveAt(index);
        }

        public void RemoveAt(int index)
        {

            if (index < 0 || index >= Count)
                throw new IndexOutOfRangeException();

            for (int nextIndex = index + 1; index < Count && nextIndex < Count; index++, nextIndex++)
                innerArray[index] = innerArray[nextIndex];

            Count--;
        }

        public void RemoveAll(T value)
        {

            int index = -1;
            while ((index = IndexOf(value)) >= 0)
                RemoveAt(index);
        }

        public object[] ToArray()
        {

            var result = new object[Count];
            for (int index = 0; index < Count; index++)
                result[index] = innerArray[index];
            return result;
        }

        public void Reverse()
        {

            for (int index = 0, lastIndex = Count - 1; index < lastIndex; index++, lastIndex--)
            {
                T store = innerArray[index];
                innerArray[index] = innerArray[lastIndex];
                innerArray[lastIndex] = store;
            }
        }

        private void GrowingArray()
        {

            if (Capacity == Count)
            {
                var newArray = new T[(Capacity / 2) + Capacity];
                for (int i = 0; i < innerArray.Length; i++)
                    newArray[i] = innerArray[i];
                innerArray = newArray;
            }
        }

        public IEnumerator<T> GetEnumerator()
        {
            return new Iterator<T>(this);
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return GetEnumerator();
        }
    }
}