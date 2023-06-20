using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    internal class MyList : IMyList
    {
        private object[] _items;
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
            _items = new object[0];
            EnsureCapacity(inCapacity);
        }

        public void Add(object inObj)
        {
            if (_size == _items.Length)
            {
                EnsureCapacity(_size + 1);
            }
            _items[_size++] = inObj;
        }
        public object this[int index]
        {
            get
            { return _items[index]; }
            set
            { _items[index] = value; }
        }
        public void Clear()
        {
            for (int i = 0; i < _items.Length; i++)
            {
                _items[i] = default(object);
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
        public void Insert(int index, object inObj)
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
            _items[index] = inObj;
            _size++;
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
        public int IndexOf(object inObj)
        {
            for (int i = 0; i < _size; i++)
            {
                if (inObj.Equals(_items[i]))
                    return i;
            }
            return -1;
        }
        public object[] ToArray()
        {
            object[] array = new object[_size];
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

        public IMyEnumerator GetEnumerator() => new Enumerator(this);
        public class Enumerator : IMyEnumerator
        {
            private readonly MyList _list;
            private int _index;
            private object? _current;

            public Enumerator(MyList list)
            {
                _list = list;
                _index = 0;
                _current = default(object);
            }

            public object Current => _current!;

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
