using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class TwoWaysList
    {
        private TwoWaysNode _head;
        private TwoWaysNode _tail;
        private int _count = 0;
        public int Count => _count;
        public object First => _head;
        public object Last => _tail;
        public void Add(object inObj)
        {
            AddLast(inObj);
        }
        public void AddFirst(object inObj)
        {
            TwoWaysNode tempNode = new TwoWaysNode(inObj);
            tempNode._next = _head;
            _head._prev = tempNode;
            _head = tempNode;
            _count++;
        }
        public void AddLast(object inObj)
        {
            if (_head == null)
            {
                _head = new TwoWaysNode(inObj);
                _tail = _head;
            }
            else
            {
                TwoWaysNode current = _head;
                while (current._next != null)
                {
                    current = current._next;
                }
                _tail = new TwoWaysNode(inObj, current);
                current._next = _tail;
            }
            _count++;
        }
        public void RemoveFirst()
        {
            if(_head != null)
            {
                if (_count > 1)
                {
                    _head._data = null;
                    _head = _head._next;
                    _head._prev = null;

                }
                else
                {
                    _head._data = null;
                    _head = null;
                }
                _count--;
            }
        }
        public void RemoveLast()
        {
            if(_head != null)
            {
                if (_tail._prev != null)
                {
                    _tail._data = null;
                    _tail = _tail._prev;
                }
                else
                {
                    _tail._data = null;
                    _tail = null;
                    _head = null;
                }
                _count--;
            }            
        }
        public bool Contains(object inObj)
        {
            TwoWaysNode current = _head;
            while (current?._data != null)
            {
                if (current._data.Equals(inObj))
                    return true;
                current = current._next;
            }
            return false;
        }
        public object[] ToArray()
        {
            object[] array = new object[_count];
            TwoWaysNode current = _head;
            for (int i = 0; current?._data != null; i++)
            {
                array[i] = current._data;
                current = current._next;
            }
            return array;
        }
        public void Clear()
        {
            TwoWaysNode next = _head;
            TwoWaysNode tempNode = _head;
            while (next != null)
            {
                tempNode = next;
                next = next._next;
                tempNode._data = null;
                tempNode._next = null;
                tempNode._prev = null;
            }
            _head = null;
            _tail = null;
            _count = 0;
        }
        public void Print()
        {
            TwoWaysNode current = _head;
            while (true)
            {
                Console.WriteLine(current?._data);
                current = current?._next;
                if (current == null)
                    break;
            }
        }
    }
    class TwoWaysNode
    {
        public TwoWaysNode(object inObj, TwoWaysNode prev = null)
        {
            _data = inObj;
            _prev = prev;
        }
        public Object _data;
        public TwoWaysNode _next;
        public TwoWaysNode _prev;
    }
}
