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
        protected override OneWayNode CreateNode(object data, OneWayNode next = null, OneWayNode prev = null)
        {
            TowWayNode newDode = new TowWayNode(data, next, prev);
            if (next != null)
                ((TowWayNode)next).Prev = newDode;
            if (prev != null)
                prev.Next = newDode;                
            return newDode; 
        }
        protected override void DeleteNode(OneWayNode current, OneWayNode next = null, OneWayNode prev = null)
        {
            current.Next = null;
            current.Data = null;
            ((TowWayNode)current).Prev = null;
        }
    }
    class TowWayNode : OneWayNode
    {
        private OneWayNode _prev;
        public OneWayNode Prev
        {
            get { return _prev; }
            set { _prev = value; }
        }
        public TowWayNode(object data, OneWayNode next = null, OneWayNode prev = null) : base(data, next)
        {
            _prev = prev;
        }
    }
}
