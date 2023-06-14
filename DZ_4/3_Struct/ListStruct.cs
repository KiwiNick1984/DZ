using System;

namespace DZ_4
{
    internal class ListStruct
    {
        private object[] _mainObjects = new object[0];
        private int _size;
        private int _capacity;
        public int Count => _size;

        public ListStruct(int inCapacity = 4)
        {
            EnsureCapacity(inCapacity);
        }

        public void Add(object inObj)
        {
            if (_size == _mainObjects.Length)
            {
                EnsureCapacity(_size + 1);
            }
            _mainObjects[_size++] = inObj;
        }
        public void Insert(int index, object inObj)
        {
            if ((uint)index > (uint)_size)
            {
                throw new Exception("ОШИБКА! выход за пределы диапазона!");
            }
            if (_size == _mainObjects.Length)
            {
                EnsureCapacity(_size + 1);
            }
            for (int i = _size; i > index; i--)
            {
                _mainObjects[i] = _mainObjects[i - 1];
            }
            _mainObjects[index] = inObj;
            _size++;
        }
        public bool Remove(object inObj)
        {
            int num = IndexOf(inObj);
            if (num >= 0)
            {
                RemoveAt(num);
                return true;
            }
            return false;
        }
        public void RemoveAt(int index)
        {
            if ((uint)index >= (uint)_size)
            {
                throw new Exception("ОШИБКА! Выход за пределы диапазона!");
            }
            for (int i = index; i < _size-1; i++)
            {
                _mainObjects[i] = _mainObjects[i + 1];
            }
            _mainObjects[_size-1] = default(object);
            _size--;
        }
        public void Clear()
        {
            for (int i = 0; i < _mainObjects.Length; i++)
            {
                _mainObjects[i] = default(object);
            }
            _size = 0;
        }
        public bool Contains(object inObj)
        {
            for (int i = 0; i < _size; i++)
            {
                if (inObj.Equals(_mainObjects[i]))
                    return true;
            }
            return false;
        }
        public int IndexOf(object inObj)
        {
            for (int i = 0; i < _size; i++)
            {
                if (inObj.Equals(_mainObjects[i]))
                    return i;
            }
            return -1;
        }
        public object[] ToArray()
        {
            object[] array = new object[_size];
            for (int i = 0; i < _size; i++)
            {
                array[i] = _mainObjects[i];
            }
            return array;
        }
        public void Reverse()
        {
            object tempObj;
            for (int i = 0; i < _size / 2; i++)
            {
                tempObj = _mainObjects[i];
                _mainObjects[i] = _mainObjects[_size - i - 1];
                _mainObjects[_size - i - 1] = tempObj;
            }
        }
        public object this[int index]
        { 
            get 
            { return _mainObjects[index]; }
            set
            {_mainObjects[index] = value; }
        }

        private void EnsureCapacity(int min)
        {
            if (_mainObjects.Length < min)
            {
                _capacity = ((_mainObjects.Length == 0) ? 4 : (_mainObjects.Length * 2));
                if ((uint)_capacity > 2146435071u)
                {
                    _capacity = 2146435071;
                }
                if (_capacity < min)
                {
                    _capacity = min;
                }

                object[] tempObjArr = new object[_capacity];
                for (int i = 0; i < _mainObjects.Length; i++)
                {
                    tempObjArr[i] = _mainObjects[i];
                }
                _mainObjects = tempObjArr;
            }
        }
        public void Print()
        {
            for (int i = 0; i < _size; i++)
            {
                Console.WriteLine(_mainObjects[i]);
            }
        }

    }
}
