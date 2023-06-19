using System;
using System.Collections;
using System.Collections.Generic;

namespace DataStructures
{
    public static class MyCoolLinq
    {
        class FilterEnum : IEnumerable
        {
            private IEnumerable list;
            private Predicate<object?> predicate;

            public FilterEnum(IEnumerable list, Predicate<object?> predicate)
            {
                this.list = list;
                this.predicate = predicate;
            }

            public IEnumerator GetEnumerator()
            {
                return new FilterIterator(list, predicate);
            }
        }

        class FilterIterator : IEnumerator
        {
            private readonly IEnumerator _iter;
            private readonly Predicate<object?> _predicate;

            public FilterIterator(IEnumerable list, Predicate<object?> predicate)
            {
                _iter = list.GetEnumerator();
                _predicate = predicate;
            }

            public object Current => _iter.Current;

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

        class SkipEnumrable : IEnumerable
        {
            private IEnumerable enumerable;
            private int count;

            public SkipEnumrable(IEnumerable enumerable, int count)
            {
                this.enumerable = enumerable;
                this.count = count;
            }

            public IEnumerator GetEnumerator() => new SkipEnumerator(enumerable.GetEnumerator(), count);
        }

        class SkipEnumerator : IEnumerator
        {
            private IEnumerator enumerator;
            private int count;

            public SkipEnumerator(IEnumerator enumerator, int count)
            {
                this.enumerator = enumerator;
                this.count = count;
            }

            public object Current => enumerator.Current;

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


        public static IEnumerable FilterAlt(this IEnumerable enumerable, Predicate<object?> predicate)
        {
            return new FilterEnum(enumerable, predicate);
        }

        public static IEnumerable Skip(this IEnumerable enumerable, int count)
        {
            return new SkipEnumrable(enumerable, count);
        }

        //public static IEnumerable Skip(this IEnumerable enumerable, int count, Predicate<object?> predicate)
        //{

        //}

        public static IEnumerable Filter(this IEnumerable list, Predicate<object?> predicate)
        {
            foreach (var item in list)
            {
                if (predicate(item))
                {
                    yield return item;
                }
            }
        }
    }

    public class List : IList/*, Interfaces.IList*/
    {

        private class Iterator : IEnumerator
        {
            private readonly List _list;
            private int _index;

            public Iterator(List list)
            {
                _list = list;
                _index = 0;
                Current = _list[0];
            }

            public object Current { get; private set; }

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

        private object[] innerArray;
        private readonly object syncRoot = new object();
        private readonly int origCapacity;

        public List() : this(10)
        {
        }

        public List(int capacity)
        {
            origCapacity = capacity;
            innerArray = new object[capacity];
        }

        public object this[int index]
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

        public int Add(object value)
        {

            GrowingArray();

            var index = Count++;
            innerArray[index] = value;
            return index;
        }

        public void Clear()
        {

            Count = 0;
            innerArray = new object[origCapacity];
        }

        public bool Contains(object value) => IndexOf(value) >= 0;

        public void CopyTo(Array array, int index)
        {

            for (int innerIndex = 0; innerIndex < Count; innerIndex++, index++)
                array.SetValue(innerArray[innerIndex], index);
        }

        public int IndexOf(object value)
        {

            for (int index = 0; index < Count; index++)
                if (innerArray[index].Equals(value))
                    return index;
            return -1;
        }

        public void Insert(int index, object value)
        {

            if (index < 0 || index > Count)
                throw new IndexOutOfRangeException();

            GrowingArray();

            object stored = null;
            for (; index < Count + 1; index++)
            {
                stored = innerArray[index];
                innerArray[index] = value;
                value = stored;
            }

            Count++;
        }

        public void Remove(object value)
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

        public void RemoveAll(object value)
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
                object store = innerArray[index];
                innerArray[index] = innerArray[lastIndex];
                innerArray[lastIndex] = store;
            }
        }

        private void GrowingArray()
        {

            if (Capacity == Count)
            {
                var newArray = new object[(Capacity / 2) + Capacity];
                for (int i = 0; i < innerArray.Length; i++)
                    newArray[i] = innerArray[i];
                innerArray = newArray;
            }
        }

        public IEnumerator GetEnumerator()
        {
            return new Iterator(this);
        }
    }
}
