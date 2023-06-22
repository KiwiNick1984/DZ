namespace DZ_8
{ 
    internal class OneWayList : IMyCollection
    {
        protected OneWayNode _head;
        protected OneWayNode _tail;
        protected int _count;

        public int Count => _count;
        public object First => _head;
        public object Last => _tail;

        public OneWayList()
        {
            _head = null;
            _tail = null;
            _count = 0;
        }

        public void Add(object inObj)
        {
            AddLast(inObj);
        }
        public virtual void AddFirst(object data)
        {
            _head = CreateNode(data: data, next: _head);
            _count++;
        }
        public virtual void AddLast(object data)
        {
            if (_head == null)
            {
                _head = CreateNode(data: data);
                _tail = _head;
            }
            else 
            {
                OneWayNode current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                _tail = CreateNode(data: data, prev: current);
            }
            _count++;
        }
        public void Insert(int index, object data)
        {
            if ((uint)index > (uint)_count)
            {
                throw new Exception("ОШИБКА! Insert выход за пределы диапазона!");
            }

            if (index == _count)
            {
                AddLast(data);
            }
            else if (index == 0)
            {
                AddFirst(data);
            }
            else
            {
                OneWayNode current = _head;
                for (int i = 0; i < _count; i++)
                {
                    if (i == index-1)
                    {
                        CreateNode(data: data, next: current.Next, prev: current);
                        break;
                    }
                    current = current.Next;
                }
            }
            _count++;
        }
        public void Clear()
        {
            OneWayNode currentNode = _head;
            while (currentNode != null)
            {
                OneWayNode tempNode = currentNode;
                currentNode = currentNode.Next;
                DeleteNode(tempNode);
            }
            _head = null;
            _tail = null;
            _count = 0;
        }
        public bool Contains(object inObj)
        {
            OneWayNode current = _head;
            while (current?.Data != null)
            {
                if (current.Data.Equals(inObj))
                    return true;
                current = current.Next;
            }
            return false;
        }
        public object[] ToArray()
        {
            object[] array = new object[_count];
            OneWayNode current = _head;
            for (int i = 0; current?.Data != null; i++)
            {
                array[i] = current.Data;
                current = current.Next;
            }
            return array;
        }
        protected virtual OneWayNode CreateNode(object data, OneWayNode next = null, OneWayNode prev = null)
        {
            OneWayNode newDode = new OneWayNode(data, next);
            if (prev != null)
                prev.Next = newDode;
            return newDode;
        }
        protected virtual void DeleteNode(OneWayNode current, OneWayNode next = null, OneWayNode prev = null)
        {
            current.Next = null;
            current.Data = null;
        }

        public IMyEnumerator GetEnumerator() => new Enumerator(this);
        public class Enumerator : IMyEnumerator
        {
            private OneWayNode _currentNode;
            private object? _currentData;

            public Enumerator(OneWayList list)
            {
                _currentNode = list._head;
            }

            public object Current => _currentData;

            public bool MoveNext()
            {
                if(_currentNode?.Data != null)
                {
                    _currentData = _currentNode.Data;
                    if (_currentNode?.Next != null)
                        _currentNode = (OneWayNode)_currentNode.Next;
                    else

                        _currentNode = null;
                    return true;
                }
                return false;
            }
            public void Reset()
            {
                throw new NotImplementedException();
            }
        }
    }
    class OneWayNode
    {
        private OneWayNode _next;
        private Object _data;
        public OneWayNode Next
        {
            get { return _next; }
            set { _next = value; }
        }        
        public Object Data
        {
            get { return _data; }
            set { _data = value; }
        }
        public OneWayNode(object inObjData, OneWayNode next = null)
        {
            _data = inObjData;
            _next = next;
        }        
    }
}
