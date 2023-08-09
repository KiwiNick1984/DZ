internal partial class Program
{
    class ArrMath
    {
        private readonly Thread[] _threads;
        private readonly Memory<int> _arrMem;
        private readonly int _numOfThreads;
        private readonly int _numOfElements;
        private ulong[] _results;
        private ulong[] _results_2;
        private int[] _resultsSubArr;
        public int min;
        public int max;
        ulong _sum = 0;
        int[] _arr;
        

        public ArrMath( int[] arr, int numOfThreads)
        {
            _numOfThreads = numOfThreads;
            _threads = new Thread[_numOfThreads];
            _results = new ulong[_numOfThreads];
            _results_2 = new ulong[_numOfThreads];
            _arrMem = arr.AsMemory();
            _numOfElements = arr.Length / _numOfThreads;
            _arr = arr;
        }

        //Простое суммирование
        public ulong ArrSum()
        {
            _sum = 0;
            foreach (ulong item in _arr)
            {
                _sum += item;
            }
            return _sum;
        }
        //Многопоточное суммирование
        public ulong ArrSumThreads()
        {
            _sum = 0;
            for (int i = 0; i < _numOfThreads; i++)
            {
                Memory<int> arrSlice;
                _threads[i] = new Thread(SumThreadProc);
                if (i == _numOfThreads - 1)
                    arrSlice = _arrMem.Slice(i * _numOfElements);
                else
                    arrSlice = _arrMem.Slice(i * _numOfElements, _numOfElements);
                _threads[i].Start(new ProcecParam<int> { Memory = arrSlice, ThreadIndex = i });
            }
            Wait();
            foreach (var item in _results)
            {
                _sum += item;
            }
            return _sum;
        }
        private void SumThreadProc(object? state)
        {
            ProcecParam<int> param = (ProcecParam<int>)state;
            Span<int> span = param.Memory.Span;
            for (int i = 0; i < span.Length; i++)
            {
                _results[param.ThreadIndex] += (ulong)span[i];
            }
        }

        //Простое копирование части массива
        public int[] GetSubarray(int startIndex, int endIndex)
        {
            int[] resultArr = new int[endIndex - startIndex + 1];
            for (int i = startIndex, j = 0; i <= endIndex; i++, j++)
            {
                resultArr[j] = _arr[i];
            }
            return resultArr;
        }
        //Многопоточное копирование части массива
        public int[] GetSubarrayThreads(int startIndex, int endIndex)
        {
            //int[] resultArr = new int[endIndex - startIndex + 1];
            int numOfElem = (endIndex - startIndex + 1) / _numOfThreads;
            int currentIndex = 0;
            _resultsSubArr = new int[endIndex - startIndex + 1];
            Memory<int> arrSlice = _arrMem.Slice(startIndex, endIndex - startIndex + 1);
            for (int i = 0; i < _numOfThreads; i++)
            {
                _threads[i] = new Thread(GetSubarrayThreadsProc);
                if (i == _numOfThreads - 1)
                {
                    _threads[i].Start(new ProcecParam<int> { Memory = arrSlice.Slice(numOfElem * i), ThreadIndex = i, Param1 = currentIndex});
                }
                else
                {
                    _threads[i].Start(new ProcecParam<int> { Memory = arrSlice.Slice(numOfElem * i, numOfElem), ThreadIndex = i, Param1 = currentIndex});
                    currentIndex += numOfElem;
                }
            }
            Wait();
            return _resultsSubArr;
        }
        private void GetSubarrayThreadsProc(object? state)
        {
            ProcecParam<int> param = (ProcecParam<int>)state;
            Span<int> span = param.Memory.Span;
            for (int i = 0; i < span.Length; i++)
            {
                _resultsSubArr[param.Param1 + i] = span[i];
            }
        }

        //Многопоточное Min/Max массива
        public void GetMinMaxTheads()
        {            
            for (int i = 0; i < _numOfThreads; i++)
            {
                Memory<int> arrSlice;
                _threads[i] = new Thread(GetMinMaxTheadsProc);
                if (i == _numOfThreads - 1)
                    arrSlice = _arrMem.Slice(i * _numOfElements);
                else
                    arrSlice = _arrMem.Slice(i * _numOfElements, _numOfElements);
                _threads[i].Start(new ProcecParam<int> { Memory = arrSlice, ThreadIndex = i });
            }
            Wait();
            min = (int)_results[0];
            max = (int)_results_2[0];
            for (int i = 1; i < _results.Length; i++)
            {
                min = min > (int)_results[i] ? (int)_results[i] : min;
                max = max < (int)_results[i] ? (int)_results[i] : max;
            }
        }
        private void GetMinMaxTheadsProc(object? state)
        {
            ProcecParam<int> param = (ProcecParam<int>)state!;
            Span<int> span = param.Memory.Span;
            int minVal = span[0];
            int maxVal = span[0];
            for (int i = 1; i < span.Length; i++)
            {
                minVal = minVal > span[i] ? span[i] : minVal;
                maxVal = maxVal < span[i] ? span[i] : maxVal;
            }
            _results[param.ThreadIndex] = (ulong)minVal;
            _results_2[param.ThreadIndex] = (ulong)maxVal;
        }

        private void Wait()
        {
            foreach (var item in _threads)
            {
                item.Join();
            }
        }
    }
}
