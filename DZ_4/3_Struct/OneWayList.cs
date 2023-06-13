using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{ 
    internal class OneWayList
    {
        private Node _root;
        private Node _last;
        private int _count;

        public int Count => _count;
        public object First => _root;
        public object Last => _last;

        public void Add(object inObj)
        {
            AddLast(inObj);
        }
        public void AddFirst(object inObj)
        {
            _root._data = inObj;
        }
        public void AddLast(object inObj)
        {
            if (inObj == null)
                _root = new Node(inObj);
            Node current = _root;
            while (current._next != null)
            {
                current = current._next;
            }
            _last = new Node(inObj);
            current._next = _last;
            _count++;
        }
        //public void Insert(int index, object inObj)
        //{ }
        //public void Clear()
        //{ }
        //public bool Contains(object inObj) 
        //{
        //    return false;
        //}
        //public object[] ToArray()
        //{ 
        //    return new object[0];
        //}
        public void Print()
        {
            Node current = _root;
            while (current._next != null)
            {
                Console.WriteLine(current._data);
                current = current._next;
            }
        }
    }
    class Node 
    {
        public Node(object inObj)
        {
            _data = inObj;
        }
        public Object _data;
        public Node _next;
    }

//Add(object)
//AddFirst(object)
//Insert(int, object) (де int це индекс у який буде вставлення)
//Clear()
//bool Contains(object)
//object[] ToArray()
//Свойства Count, First, Last.
}
