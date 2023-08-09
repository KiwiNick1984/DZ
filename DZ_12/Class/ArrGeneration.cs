internal partial class Program
{
    class ArrGeneration
    {
        List<Thread> _threads = new List<Thread>();

        public ArrGeneration() { }

        //простая генерация массива
        public void GenerateArr(int[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                arr[i] = rnd.Next(1, 100);
            }
        }

        //простая генерация массива f(i)
        public void GenerateArrFunc(double[] arr)
        {
            Random rnd = new Random();
            for (int i = 0; i < arr.Length; i++)
            {
                //Функция гиперболы 
                arr[i] = 1.0/((double)i+1.0);
            }
        }

        //Многопоточная генерация массива
        public void GenerateArrThreads(int[] arr, int numOfThreads)
        {
            _threads.Clear();
            for (int i = 0; i < numOfThreads; i++)
            {
                //Tuple<int[], Range> tuple = new Tuple<int[], Range>(_arr, new Range(0, _arr.Length / 2));
                _threads.Add(new Thread(ArrGeneratorThreadProc));
                _threads[i].Start((arr, new Range(arr.Length / numOfThreads * i, arr.Length / numOfThreads*(i+1))));
            }
            foreach (var item in _threads)
            {
                item.Join();
            }
        }

        //Многопоточная генерация массива f(i)
        public void GenerateArrThreadsFunc(double[] arr, int numOfThreads)
        {
            _threads.Clear();
            for (int i = 0; i < numOfThreads; i++)
            {
                //Tuple<int[], Range> tuple = new Tuple<int[], Range>(_arr, new Range(0, _arr.Length / 2));
                _threads.Add(new Thread(ArrGeneratorThreadProcFunc));
                _threads[i].Start((arr, new Range(arr.Length / numOfThreads * i, arr.Length / numOfThreads * (i + 1))));
            }
            foreach (var item in _threads)
            {
                item.Join();
            }
        }

        private void ArrGeneratorThreadProc(object? inParam)
        {
            Random rnd = new Random();

            (int[] arr, Range range) param = ((int[] arr, Range range))inParam!;
            Range range = param.range;
            for (int i = range.Start.Value; i < range.End.Value; i++)
            {
                param.arr[i] = rnd.Next(0, 100);
            }
        }
        private void ArrGeneratorThreadProcFunc(object? inParam)
        {
            Random rnd = new Random();

            (double[] arr, Range range) param = ((double[] arr, Range range))inParam!;
            Range range = param.range;
            for (int i = range.Start.Value; i < range.End.Value; i++)
            {
                //Функция гиперболы
                param.arr[i] = 1.0 / ((double)i + 1.0);
            }
        }
    }


}
