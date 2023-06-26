using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_5.Generic
{
    internal class MyQueuePriority<T> : MyQueue<T>
    {
        //struct _priorityNode
        //{
        //    int priority;
        //    T data;
        //}
        //MyList<_priorityNode> _nodes = new MyList<_priorityNode>();
        MyList<int> _priority = new MyList<int>();
    }
}
