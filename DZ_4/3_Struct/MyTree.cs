using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class MyTree
    {
        public MyTree(int count = 0)
        {
            _count = count;
        }

        int _count;
        public int _data;
        MyTree _left;
        MyTree _right;

        public int Count => _count;
        
        public void Add(int inInt)
        {
            if(_count == 0)
            {
                _data = inInt;
                _count++;
            }
            else
            {
                if (inInt < _data)
                {
                    if (_left == null)
                    {
                        _left = new MyTree(++_count);
                        _left._data = inInt;
                    }
                    else
                    {
                        ++_count;
                        _left.Add(inInt);
                    }
                }
                else
                {
                    if (_right == null)
                    {
                        _right = new MyTree(++_count);
                        _right._data = inInt;
                    }
                    else
                    {
                        ++_count;
                        _right.Add(inInt);
                    }
                }
            }
        }

        public bool Contains(int inInt)
        {
            if (inInt == _data)
            {
                return true;
            }
            else if (inInt < _data)
            {
                if (_left != null)
                    return _left.Contains(inInt);
                else
                    return false;
            }
            else
            {
                if (_right != null)
                    return _left.Contains(inInt);
                else
                    return false;
            }
        }

        public int[] ToArray()
        {
            int[] tempArr;
            int[] leftArr = new int[0];
            int[] rightArr = new int[0];
            int[] returnArr;
            if (_left != null)
            {
                tempArr = _left.ToArray();
                leftArr = new int[tempArr.Length+1];
                leftArr[0] = _data;
                for (int i = 1; i < leftArr.Length; i++)
                {
                    leftArr[i] = tempArr[i - 1];
                }
            }
            if (_right != null)
            {
                rightArr = _right.ToArray();
            }
            if(_left == null && _right == null)
            {
                return new int[] { _data };
            }
            returnArr = new int[leftArr.Length + rightArr.Length];
            for (int i = 0; i < leftArr.Length; i++)
            {
                returnArr[i] = leftArr[i];
            }
            for (int i = leftArr.Length; i < returnArr.Length; i++)
            {
                returnArr[i] = rightArr[i-rightArr.Length];
            }
            return returnArr;
        }
    }

}
