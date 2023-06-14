using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class MyQueue
    {
        ListStruct listStruct = new ListStruct();
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
        public void Print()
        {
            listStruct.Print();
        }

    }
}
