using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    internal class MyQueue : IMyCollection
    {
        MyList listStruct = new MyList();
        public int Count => listStruct.Count;

        public void Enqueue(object item)
        {
            listStruct.Add(item);
        }
        public object Dequeue()
        {
            object tempObj = listStruct[0];
            listStruct.RemoveAt(0);
            return tempObj;
        }
        public void Clear()
        {
            listStruct.Clear();
        }
        public bool Contains(object item)
        {
            return listStruct.Contains(item);
        }
        public object Peek()
        {
            return listStruct[0];
        }
        public object[] ToArray()
        {
            return listStruct.ToArray();
        }

        public IMyEnumerator GetEnumerator() => new Enumerator(listStruct);
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
