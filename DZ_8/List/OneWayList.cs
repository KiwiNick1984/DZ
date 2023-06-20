using DZ_8;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DZ_8
{ 
    internal class OneWayList : IMyCollection
    {
        protected IOneWayNode _head;
        protected IOneWayNode _tail;
        protected int _count = 0;

        public int Count => _count;
        public object First => _head;
        public object Last => _tail;

        public void Add(object inObj)
        {
            AddLast(inObj);
        }
        public virtual void AddFirst(object inObj)
        {
            IOneWayNode tempNode = new OneWayNode(inObj);
            tempNode.Next = _head;
            _head = tempNode;
            _count++;
        }

        public virtual void AddLast(object inObj)
        {
            if (_head == null)
            {
                _head = new OneWayNode(inObj);
                _tail = _head;
            }
            else 
            {
                IOneWayNode current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                _tail = new OneWayNode(inObj);
                current.Next = _tail;
            }
            _count++;
        }

        //public void Insert(int index, object inObj)
        //{
        //    if ((uint)index > (uint)_count)
        //    {
        //        throw new Exception("ОШИБКА! выход за пределы диапазона!");
        //    }

        //    OneWayNode current = _head;
        //    OneWayNode tempNode = new OneWayNode(inObj);

        //    if (index == _count)
        //    {
        //        _tail._next = tempNode;
        //        _tail = tempNode;
        //    }
        //    else if (index == 0)            
        //    {
        //        tempNode._next = _head;
        //        _head = tempNode;
        //    }
        //    else
        //    {
        //        for (int i = 0; i < _count; i++)
        //        {
        //            if (i == index - 1)
        //            {
        //                tempNode._next = current._next;
        //                current._next = tempNode;
        //                break;
        //            }
        //            current = current._next;
        //        }
        //    }
        //    _count++;
        //}
        public void Clear()
        {
            OneWayNode currentNode = (OneWayNode)_head;
            OneWayNode tempNode = (OneWayNode)_head;
            while (currentNode != null)
            {
                tempNode = currentNode;
                currentNode = (OneWayNode)currentNode.Next;
                tempNode._data = null;
                tempNode.Next = null;
                if(tempNode is TowWayNode tempNodeTowWay)
                    tempNodeTowWay.Prev = null;
            }
            _head = null;
            _tail = null;
            _count = 0;
        }
        //public bool Contains(object inObj)
        //{
        //    OneWayNode current = _head;
        //    while (current?._data != null)
        //    {
        //        if(current._data.Equals(inObj))
        //            return true;
        //        current = current._next;
        //    }
        //    return false;
        //}
        //public object[] ToArray()
        //{
        //    object[] array = new object[_count];
        //    OneWayNode current = _head;
        //    for (int i = 0; current?._data != null; i++)
        //    {
        //        array[i] = current._data;
        //        current = current._next;
        //    }
        //    return array;
        //}
        //public void Print()
        //{
        //    OneWayNode current = _head;
        //    while (true)
        //    {
        //        Console.WriteLine(current?._data);
        //        current = current._next;
        //        if(current == null)
        //            break;
        //    }
        //}

        public IMyEnumerator GetEnumerator() => new Enumerator(this);
        public class Enumerator : IMyEnumerator
        {
            private OneWayNode _currentNode;
            private object? _currentData;

            public Enumerator(OneWayList list)
            {
                _currentNode = (OneWayNode)list?._head;
                _currentData = _currentNode?._data;
            }

            public object Current => _currentData!;

            public bool MoveNext()
            {
                if(_currentNode?._data != null)
                {
                    _currentData = _currentNode._data;
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
    class OneWayNode : IOneWayNode
    {
        private IOneWayNode _next;
        public IOneWayNode Next
        {
            get { return _next; }
            set { _next = value; }
        }
        public Object _data;
        public OneWayNode(object inObjData, IOneWayNode next = null)
        {
            _data = inObjData;
            _next = next;
        }        
    }
}
