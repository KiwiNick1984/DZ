using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace DZ_8
{
    internal class TowWaysList : OneWayList
    {
        public override void AddFirst(object inObj)
        {
            IOneWayNode tempNode = new TowWayNode(inObj);
            tempNode.Next = _head;
            _head = tempNode;
            _count++;
        }
        public override void AddLast(object inObj)
        {
            if (_head == null)
            {
                _head = new TowWayNode(inObj);
                _tail = _head;
            }
            else
            {
                IOneWayNode current = _head;
                while (current.Next != null)
                {
                    current = current.Next;
                }
                _tail = new TowWayNode(inObj);
                ((ITowWayNode)_tail).Prev = current;
                current.Next = _tail;
            }
            _count++;
        }
    }
    class TowWayNode : OneWayNode, ITowWayNode
    {
        private IOneWayNode _prev;
        public IOneWayNode Prev
        {
            get { return _prev; }
            set { _prev = value; }
        }

        public TowWayNode(object inObjData, IOneWayNode prev = null, IOneWayNode next = null) : base(inObjData, next)
        {
            _prev = prev;
        }
    }
}
