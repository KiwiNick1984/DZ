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
                    return _right.Contains(inInt);
                else
                    return false;
            }
        }

        public int[] ToArray()
        {
            int[] leftArr = new int[0];
            int[] rightArr = new int[0];
            int[] returnArr;
            if (_left != null)
            {
                leftArr = _left.ToArray();
            }
            if (_right != null)
            {
                rightArr = _right.ToArray();
            }
            if(_left == null && _right == null)
            {
                return new int[] { _data };
            }
            returnArr = new int[leftArr.Length + rightArr.Length + 1];
            for (int i = 0; i < leftArr.Length; i++)
            {
                returnArr[i] = leftArr[i];
            }
            for (int i = leftArr.Length; i < returnArr.Length-1; i++)
            {
                returnArr[i] = rightArr[i-leftArr.Length];
            }
            returnArr[returnArr.Length-1] = _data;
            return returnArr;
        }
    }

}
