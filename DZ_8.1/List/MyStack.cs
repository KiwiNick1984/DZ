using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    internal class MyStack : IMyCollection
    {
        MyList _items = new MyList();
        public int Count => _items.Count;

        public void Push(object inObj)
        {
            _items.Add(inObj);
        }
        public object Pop()
        {
            object tempObj = _items[Count - 1];
            _items.RemoveAt(Count - 1);
            return tempObj;
        }
        public object Peek()
        {
            return _items[Count - 1];
        }
        public object this[int index]
        {
            get
            { return _items[index]; }
            set
            { _items[index] = value; }
        }
        public bool Contains(object inObj)
        {
            return _items.Contains(inObj);
        }
        public object[] ToArray()
        {
            return _items.ToArray();
        }
        public void Clear()
        {
            _items.Clear();
        }

        public IMyEnumerator GetEnumerator() => new Enumerator(this);

        public class Enumerator : IMyEnumerator
        {
            private readonly MyStack _list;
            private int _index;
            private object? _current;

            public Enumerator(MyStack list)
            {
                _list = list;
                _index = 0;
                _current = default(object);
            }

            public object Current => _current;

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
