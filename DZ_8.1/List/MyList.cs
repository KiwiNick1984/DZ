using System;

namespace DZ_8.Generic
{
    internal class MyList<T> : IMyList<T>, IMyList, IMyCollection<T>, IMyEnumerable<T>, IMyEnumerable
    {
        private T[] _items;
        private int _size;
        private int _capacity;

        public int Count => _size;
        public int Capacity
        {
            get => _capacity;
        }

        public MyList() : this(4) { }
        public MyList(int inCapacity = 4)
        {
            _items = new T[0];
            EnsureCapacity(inCapacity);
        }

        public void Add(T inItem)
        {
            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }
            _items[_size++] = inItem;
        }
        void IMyList.Add(object inItem)
        {
            try
            {
                Add((T)inItem);
            }
            catch(Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
        public T this[int index]
        {
            get
            { return _items[index]; }
            set
            { _items[index] = value; }
        }
        object IMyList.this[int index]
        {
            get
            { return _items[index]; }
            set
            { 
                try
                {
                    _items[index] = (T)value;
                }
                catch (Exception ex)
                {
                    throw new Exception(ex.Message);
                }
            }
        }   
        public void Clear()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                _items[i] = default(T);
            }
            _size = 0;
        }
        public bool Contains(object inObj)
        {
            for (int i = 0; i < _size; i++)
            {
                if (inObj.Equals(_items[i]))
                    return true;
            }
            return false;
        }
        public void Insert(int index, T inItem)
        {
            if ((uint)index > (uint)_size)
            {
                throw new Exception("ОШИБКА! выход за пределы диапазона!");
            }
            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }
            for (int i = _size; i > index; i--)
            {
                _items[i] = _items[i - 1];
            }
            _items[index] = inItem;
            _size++;
        }
        void IMyList.Insert(int index, object inIndex)
        {
            try
            {
                Insert(index, (T)inIndex);
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }

        }
        public void Remove(object inObj)
        {
            int num = IndexOf(inObj);
            if (num >= 0)
            {
                RemoveAt(num);
            }
        }
        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)_size)
            {
                throw new Exception("ОШИБКА! Выход за пределы диапазона!");
            }
            for (int i = index; i < _size - 1; i++)
            {
                _items[i] = _items[i + 1];
            }
            _items[_size - 1] = default(object);
            _size--;
        }
        public int IndexOf(T inItem)
        {
            for (int i = 0; i < _size; i++)
            {
                if (inItem.Equals(_items[i]))
                    return i;
            }
            return -1;
        }
        int IMyList.IndexOf(object inObj)
        {
            return IndexOf((T)inObj);
        }
        public T[] ToArray()
        {
            T[] array = new T[_size];
            for (int i = 0; i < _size; i++)
            {
                array[i] = _items[i];
            }
            return array;
        }
        public void Reverse()
        {
            object tempObj;
            for (int i = 0; i < _size / 2; i++)
            {
                tempObj = _items[i];
                _items[i] = _items[_size - i - 1];
                _items[_size - i - 1] = tempObj;
            }
        }

        private void EnsureCapacity(int min)
        {
            if (_items.Length < min)
            {
                _capacity = ((_items.Length == 0) ? 4 : (_items.Length * 2));
                if ((uint)_capacity > 2146435071u)
                {
                    _capacity = 2146435071;
                }
                if (_capacity < min)
                {
                    _capacity = min;
                }

                object[] tempObjArr = new object[_capacity];
                for (int i = 0; i < _items.Length; i++)
                {
                    tempObjArr[i] = _items[i];
                }
                _items = tempObjArr;
            }
        }

        IMyEnumerator IMyEnumerable.GetEnumerator() => new Enumerator(this);

        IMyEnumerator<T> GetEnumerator() => new Enumerator(this);

        IMyEnumerator<T> IMyEnumerable<T>.GetEnumerator()
        {
            throw new NotImplementedException();
        }

        public class Enumerator : IMyEnumerator, IMyEnumerator<T>
        {
            private readonly MyList<T> _list;
            private int _index;
            private T _current;

            public Enumerator(MyList<T> list)
            {
                _list = list;
                _index = 0;
                _current = default(T);
            }

            public T Current => _current;

            object IMyEnumerator.Current => _current;

            public bool MoveNext()
            {
                if (_index < _list.Count)
                {
                    _current = _list[_index++];
                    return true;
                }
                return false;
            }
            public void Reset()
            {
                _index = 0;
                _current = default;
            }
        }
    }
}
