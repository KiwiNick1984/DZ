using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class MyStack
    {
        ListStruct listStruct = new ListStruct();
        public int Count => listStruct.Count;

        public void Push(object inObj)
        {
            listStruct.Add(inObj);
        }
        public object Pop()
        {
            object tempObj = listStruct[Count-1];
            listStruct.RemoveAt(Count-1);
            return tempObj;
        }
        public object Peek()
        {
            return listStruct[Count - 1];
        }
        public bool Contains(object inObj)
        {
            return listStruct.Contains(inObj);
        }
        public object[] ToArray()
        { 
            return listStruct.ToArray();
        }
        public void Clear()
        {
            listStruct.Clear();
        }
    }
    //Clear()
    //bool Contains(object) ***
    //object Peek()     ***
    //ToArray()         ***
    //Push(object)      ***
    //object Pop().     ***
    //Свойство Count.   ***
}
