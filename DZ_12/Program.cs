using System;
using System.Diagnostics;
using System.Drawing;

internal partial class Program
{

    private static void Main(string[] args)
    {
        Random rnd = new Random();
        Stopwatch watch = new Stopwatch();

        ulong sum = 0;

        int[] randomArr = new int[10_000_000];
        double[] randomArrFunc = new double[10_000_000];
        int[] randomArrThread = new int[10_000_000];
        double[] randomArrThreadFunc = new double[10_000_000];

        #region [  DZ_11_1 ArrGenerator  ]
        ArrGeneration arrGeneration = new ArrGeneration();
        //Генерация без потока
        watch.Start();
        arrGeneration.GenerateArr(randomArr);
        watch.Stop();
        Console.WriteLine($"Tine generation without Thread: {watch.Elapsed}");

        //Генерация f(i) без потока
        watch.Start();
        arrGeneration.GenerateArrFunc(randomArrFunc);
        watch.Stop();
        Console.WriteLine($"Tine generation f(i) without Thread: {watch.Elapsed}");

        //Генерация c потоками
        watch.Restart();
        arrGeneration.GenerateArrThreads(randomArrThread, 4);
        watch.Stop();
        Console.WriteLine($"Tine generation with Thread: {watch.Elapsed}");

        //Генерация c потоками f(i)
        watch.Restart();
        arrGeneration.GenerateArrThreadsFunc(randomArrThreadFunc, 4);
        watch.Stop();
        Console.WriteLine($"Tine generation f(i) with Thread: {watch.Elapsed}");
        #endregion

        #region [  DZ_11_1 Sum/Min/Max  ] 
        ArrMath arrMath = new ArrMath(randomArr, 3);
        //Простое суммирование
        watch.Restart();
        Console.WriteLine(arrMath.ArrSum());
        watch.Stop();        
        Console.WriteLine($"Sum withput Thread: {watch.Elapsed}");
        //Суммирование с потоками
        watch.Restart();
        Console.WriteLine(arrMath.ArrSumThreads());
        watch.Stop();
        Console.WriteLine($"Sum with Thread: {watch.Elapsed}");

        //Найти Min/Max в массиве с потоками
        watch.Restart();
        arrMath.GetMinMaxTheads();
        Console.WriteLine($"Min = {arrMath.min}");
        Console.WriteLine($"Max = {arrMath.max}");
        watch.Stop();
        Console.WriteLine($"Min with Thread: {watch.Elapsed}");
        #endregion

        #region [  DZ_11_1 Копировать часть массива  ] 
        //Простое копирование
        watch.Restart();
        var subarray = arrMath.GetSubarray(10, 20_000);
        watch.Stop();
        Console.WriteLine($"GetSubarray withput Thread: {watch.Elapsed}");
        //Копирование с потоками
        watch.Restart();
        subarray = arrMath.GetSubarrayThreads(10, 20);
        watch.Stop();
        Console.WriteLine($"GetSubarray withput Thread: {watch.Elapsed}");
        #endregion

        #region [  DZ_11 DictionaryThreads  ]
        var list = new List<string>();
        using (StreamReader sr = new StreamReader("riba.txt", System.Text.Encoding.Default))
        {            
            while (!sr.EndOfStream)
            {
                list.Add(sr.ReadLine()!);
            }
        }  
        //string[] strings = new string[] { "Сайт рыбатекст поможет дизайнеру, верстальщику, вебмастеру сгенерировать несколько абзацев более менее",
        //                                  "осмысленного текста рыбы на русском языке, а начинающему оратору отточить навык публичных выступлений в",
        //                                  "домашних условиях. При создании генератора мы использовали небезизвестный универсальный код речей. Текст",
        //                                  "генерируется абзацами случайным образом от двух до десяти предложений в абзаце, что позволяет сделать текст более",
        //                                  "привлекательным и живым для визуально-слухового восприятия."};
        FrequncyDictionary FrequncyDictionary = new FrequncyDictionary(list.ToArray(), 4);

        //Простой словарь символов
        watch.Restart();
        FrequncyDictionary.GetDictionaryChar();
        watch.Stop();
        Console.WriteLine($"{watch.Elapsed} - Простой словарь символов");

        //Словарь символов с потоками
        watch.Restart();
        FrequncyDictionary.GetDictionaryCharThreads();
        watch.Stop();
        Console.WriteLine($"{watch.Elapsed} - Словарь символов с потоками");

        //Простой словарь слов
        watch.Restart();
        FrequncyDictionary.GetDictionaryWords();
        watch.Stop();
        Console.WriteLine($"{watch.Elapsed} - Простой словарь слов");
        //Словарь слов с потоками
        watch.Restart();
        FrequncyDictionary.GetDictionaryWordThreads();
        watch.Stop();
        Console.WriteLine($"{watch.Elapsed} - Словарь слов с потоками");
        #endregion


        #region[  Diod  ]
        //List<Diod> diodList = new List<Diod>();
        ////После 30 элементов закрашивает последние строки в цвет предыдущего диода
        ////Проблема в отрисовки на консоли?
        //for (int i = 0; i < 30; i++)
        //{
        //    diodList.Add(new Diod((ConsoleColor)rnd.Next(1, 16),
        //                          1, i + 1, 500, 500));
        //}

        ////Diod diod_1 = new Diod(ConsoleColor.Green, 1, 1, 500, 500);
        ////Diod diod_2 = new Diod(ConsoleColor.Red, 1, 2, 1000, 500);

        //Swicher swicher = new Swicher(diodList.ToArray());
        //swicher.Start();
        ////diod_1.TogleInfinitely();
        ////diod_2.TogleInfinitely();
        #endregion
    }


}
