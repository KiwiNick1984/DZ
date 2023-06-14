using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{ 
    internal class OneWayList
    {
        private OneWayNode _head;
        private OneWayNode _tail;
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
            OneWayNode tempNode = new OneWayNode(inObj);
            tempNode._next = _head;
            _head = tempNode;
            _count++;
        }

        public void AddLast(object inObj)
        {
            if (_head == null)
            {
                _head = new OneWayNode(inObj);
                _tail = _head;
            }
            else 
            {
                OneWayNode current = _head;
                while (current._next != null)
                {
                    current = current._next;
                }
                _tail = new OneWayNode(inObj);
                current._next = _tail;
            }
            _count++;
        }
        public void Insert(int index, object inObj)
        {
            if ((uint)index > (uint)_count)
            {
                throw new Exception("ОШИБКА! выход за пределы диапазона!");
            }

            OneWayNode current = _head;
            OneWayNode tempNode = new OneWayNode(inObj);

            if (index == _count)
            {
                _tail._next = tempNode;
                _tail = tempNode;
            }
            else if (index == 0)            
            {
                tempNode._next = _head;
                _head = tempNode;
            }
            else
            {
                for (int i = 0; i < _count; i++)
                {
                    if (i == index - 1)
                    {
                        tempNode._next = current._next;
                        current._next = tempNode;
                        break;
                    }
                    current = current._next;
                }
            }
            _count++;
        }
        public void Clear()
        { 
            OneWayNode next = _head;
            OneWayNode tempNode = _head;
            while (next != null)
            {
                tempNode = next;
                next = next._next;
                tempNode._data = null;
                tempNode._next = null;
            }
            _head = null;
            _tail = null;
            _count = 0;
        }
        public bool Contains(object inObj)
        {
            OneWayNode current = _head;
            while (current?._data != null)
            {
                if(current._data.Equals(inObj))
                    return true;
                current = current._next;
            }
            return false;
        }
        public object[] ToArray()
        {
            object[] array = new object[_count];
            OneWayNode current = _head;
            for (int i = 0; current?._data != null; i++)
            {
                array[i] = current._data;
                current = current._next;
            }
            return array;
        }
        public void Print()
        {
            OneWayNode current = _head;
            while (true)
            {
                Console.WriteLine(current?._data);
                current = current?._next;
                if(current == null)
                    break;
            }
        }
    }
    class OneWayNode 
    {
        public OneWayNode(object inObj)
        {
            _data = inObj;
        }
        public Object _data;
        public OneWayNode _next;
    }
}
