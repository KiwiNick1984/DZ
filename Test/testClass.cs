using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Test
{
    internal class testEnum : IEnumerable, IEnumerator
    {
        private int[] Arr;
        int position;        
        public testEnum(int[] inArr)
        {
            Arr = inArr;
            position = -1;
        }
        public void Reset() => position = -1;
        public bool MoveNext() => ++position < Arr.Length;
        public IEnumerator GetEnumerator() => this;
        //IEnumerator IEnumerable.GetEnumerator() => this;

        public object Current
        {
            get {
                if (position == -1 || position >= Arr.Length)
                    throw new ArgumentException(); 
                return Arr[position]; 
            }
        }
    }
}
