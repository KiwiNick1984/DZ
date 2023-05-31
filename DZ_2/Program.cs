using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Threading;
using System.Collections;
using System.Linq.Expressions;

namespace DZ_2
{
    internal class Program
    {
        //для ДЗ 2
        static void dz2_function(int inInt, int step = 1)
        {
            if (inInt == 1)
            {
                Console.WriteLine($"\nШаг -> {step}");
                Console.WriteLine($"Число = {inInt}");
                Console.WriteLine("Расчин окончен!");
            }
            else if (inInt % 2 == 0)
            {
                Console.WriteLine($"\nШаг -> {step}");
                Console.WriteLine($"Число = {inInt}");
                dz2_function(inInt/2, ++step);
            }
            else
            {
                Console.WriteLine($"\nШаг -> {step}");
                Console.WriteLine($"Число = {inInt}");
                dz2_function((inInt * 3 + 1)/2, ++step);
            }
        }
        //Для ДЗ 4
        static string dz4_ranndomChrs(int inInt)
        {
            //65..90 97..122
            Random random = new Random();
            string outStr = "";
            int rendomInt;
            for (int i = 0; i < inInt;)
            {
                rendomInt = random.Next(65, 122);
                if(rendomInt <= 90 || rendomInt >= 97)
                {
                    outStr += Convert.ToChar(rendomInt);
                    i++;
                }                
            }
            return outStr;
        }
        //Для ДЗ 6
        static void dz6_printPool(int [,] inArr)
        {
            Console.Clear();
            for (int i = 0; i < inArr.GetLength(0); i++)
            {
                for (int j = 0; j < inArr.GetLength(1); j++)
                {
                    if (inArr[i, j] == 10)
                        Console.Write(Convert.ToChar(2));
                    else
                        Console.Write("_");
                }
                Console.WriteLine();
            }
        }
        static void dz6_updateNeighbours(int[,] inPool)
        {
            for (int i = 0; i < inPool.GetLength(0); i++)
            {
                for (int j = 0; j < inPool.GetLength(1); j++)
                {
                    if (inPool[i, j] >= 10)
                    {
                        try { inPool[i - 1, j - 1] += 1; } catch (Exception) { }
                        try { inPool[i - 1, j] += 1; } catch (Exception) { }
                        try { inPool[i - 1, j + 1] += 1; } catch (Exception) { };
                        try { inPool[i, j - 1] += 1; } catch (Exception) { };
                        try { inPool[i, j + 1] += 1; } catch (Exception) { };
                        try { inPool[i + 1, j - 1] += 1; } catch (Exception) { };
                        try { inPool[i + 1, j] += 1; } catch (Exception) { };
                        try { inPool[i + 1, j + 1] += 1; } catch (Exception) { };
                    }
                }
            }
        }
        static void dz6_updateLife(int[,] inPool)
        {
            for (int i = 0; i < inPool.GetLength(0); i++)
            {
                for (int j = 0; j < inPool.GetLength(1); j++)
                {
                    if (inPool[i,j]==3 || (inPool[i, j] > 11 && inPool[i, j] < 14))
                        inPool[i, j] = 10;
                    else
                        inPool[i, j] = 0;
                }
            }
        }
        static bool dz6_compareArrays(int[,] array1, int[,] array2)
        {
            //if (array1.GetLength(0) != array2.GetLength(0) || array1.GetLength(1) != array2.GetLength(1))
            //    return false;
            for (int i = 0; i < array1.GetLength(0); i++)
            {
                for (int j = 0; j < array1.GetLength(1); j++)
                {
                    if (array1[i, j] != array2[i, j])
                        return false;
                }
            }
            return true;
        }


        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            ///////////////////////////////ДЗ 1/////////////////////////////
            //Console.WriteLine("\t\tДЗ 1");
            //Console.WriteLine("Реверс строки/масиву. Без додаткового масиву. Складність О(n).");
            ////////////////////////////////////////////////////////////////
            //int[] dz1_intMass = { 1, 2, 3, 4, 5, 6 };
            //int dz1_tempInt;
            //foreach (var item in dz1_intMass)
            //    Console.Write(item + ", ");
            //Console.WriteLine();
            //for (int j = 0; j < dz1_intMass.Length / 2; j++)
            //{
            //    dz1_tempInt = dz1_intMass[j];
            //    dz1_intMass[j] = dz1_intMass[dz1_intMass.Length - j - 1];
            //    dz1_intMass[dz1_intMass.Length - j - 1] = dz1_tempInt;
            //}
            //foreach (var item in dz1_intMass)
            //    Console.Write(item + ", ");
            ////Ожидание "Enter"
            //Console.WriteLine("\n\nДз 2 -> \"Enter\"...");
            //Console.ReadLine();
            //Console.Clear();

            ///////////////////////////////ДЗ 2/////////////////////////////
            //Console.WriteLine("\t\tДЗ 2");
            //Console.WriteLine("Перевірка гіпотези Сиракуз: Візьмемо будь-яке натуральне число.\n" +
            //                  "Якщо воно парне - розділимо його навпіл, якщо непарне - помножимо на 3, додамо 1 і розділимо навпіл.\n" +
            //                  "Повторимо ці дії із знову отриманим числом. Гіпотеза свідчить,\n" +
            //                  "незалежно від вибору першого числа рано чи пізно ми отримаємо 1.\n" +
            //                  "На вхід – число, при кожній зміні – роздрукувати число. Зробити рекурсивно.");
            ////////////////////////////////////////////////////////////////            
            //Console.Write("Введите целое число-> ");
            //int dz2_inVal = Convert.ToInt32(Console.ReadLine());
            //dz2_function(dz2_inVal);
            ////Ожидание "Enter"
            //Console.WriteLine("\n\nДз 3 -> \"Enter\"...");
            //Console.ReadLine();
            //Console.Clear();

            ///////////////////////////////ДЗ 3/////////////////////////////
            //Console.WriteLine("\t\tДЗ 3");
            //Console.WriteLine("Фільтрування неприпустимих слів у строці. Має бути саме слова, а не частини слів.");
            ////////////////////////////////////////////////////////////////
            //string dz3_inStr = "Текст с повторяющимся словом \"текст\". В этом тексте должно исчезнуть слово текст";
            //string dz3_keyWord = "текст";
            //Console.WriteLine("Недопустимое слово: \"" + dz3_keyWord + "\"");
            //Console.WriteLine(dz3_inStr);
            //string dz3_regexStr = @"\b" + dz3_keyWord + @"\b";
            //MatchCollection dz_match = Regex.Matches(dz3_inStr, dz3_regexStr, RegexOptions.IgnoreCase);
            //foreach (Match item in dz_match)
            //{
            //    for (int j = 0; j < dz3_keyWord.Length; j++)
            //    {
            //        dz3_inStr = dz3_inStr.Remove(j + item.Index, 1).Insert(j + item.Index, "*");
            //    }
            //}
            //Console.WriteLine(dz3_inStr);
            ////Ожидание "Enter"
            //Console.WriteLine("\nДз 3 -> \"Enter\"...");
            //Console.ReadLine();
            //Console.Clear();

            ///////////////////////////////ДЗ 4/////////////////////////////
            //Console.WriteLine("\t\tДЗ 4");
            //Console.WriteLine("Генератор випадкових символів. На вхід у символів, на виході рядок з випадковими символами.");
            ////////////////////////////////////////////////////////////////
            //Console.WriteLine(dz4_ranndomChrs(100));

            ///////////////////////////////ДЗ 5/////////////////////////////
            //Console.WriteLine("\t\tДЗ 5");
            //Console.WriteLine("\"Дірка\"(пропущене число) у масиві.");
            ////////////////////////////////////////////////////////////////
            //int[] dz5_array = { 1, 2, 3, 4, 6, 7, 8, 9, 10};
            //int dz5_expectedSum = (dz5_array.Length + 1)*(dz5_array.Length + 2) / 2 ;
            //int dz5_realSum = 0;
            //for (int i = 0; i < dz5_array.Length; i++)
            //{
            //    dz5_realSum += dz5_array[i];
            //    Console.Write(dz5_array[i] + " ");
            //}
            //Console.WriteLine($"\nПропущено число {dz5_expectedSum - dz5_realSum}");

            /////////////////////////////////ДЗ 6/////////////////////////////
            //Console.WriteLine("\t\tДЗ 6");
            //Console.WriteLine("Игра \"Жизнь\":");
            //////////////////////////////////////////////////////////////////
            //int[,] dz6_pool = new int[20, 40];
            //int[,] dz6_previousPool = new int[20, 40];
            //int[,] dz6_previous2Pool = new int[20, 40];
            //int[,] dz6_nullPool = new int[20, 40];

            //dz6_pool[0, 1] = 10;
            //dz6_pool[1, 2] = 10;
            //dz6_pool[2, 0] = 10;
            //dz6_pool[2, 1] = 10;
            //dz6_pool[2, 2] = 10;
            //dz6_pool[0, 5] = 10;
            //dz6_pool[1, 5] = 10;
            //dz6_pool[2, 5] = 10;
            //while (true)
            //{
            //    dz6_previousPool = dz6_pool.Clone() as int[,];
            //    dz6_printPool(dz6_pool);
            //    dz6_updateNeighbours(dz6_pool);
            //    dz6_updateLife(dz6_pool);
            //    Thread.Sleep(30);
            //    if (dz6_compareArrays(dz6_pool, dz6_previousPool) || dz6_compareArrays(dz6_pool, dz6_previous2Pool))
            //        break;
            //    if (dz6_compareArrays(dz6_pool, dz6_nullPool))
            //    {
            //        dz6_printPool(dz6_pool);
            //        break;
            //    }
            //    dz6_previous2Pool = dz6_previousPool.Clone() as int[,];
            //}
            //Console.WriteLine("Игра окончена");
            ////Ожидание "Enter"
            //Console.WriteLine("\nДз 7 -> \"Enter\"...");
            //Console.ReadLine();
            //Console.Clear();

            /////////////////////////////////ДЗ 7/////////////////////////////
            //Console.WriteLine("\t\tДЗ 7");
            //Console.WriteLine("Найпростіше стиснення ланцюжка ДНК. Ланцюг ДНК у вигляді строки на вхід(кожен нуклеотид\n" +
            //    "представлений символом \"A\", \"C\", \"G\", \"T\").Два методи, один для компресії, інший для декомпресії.");
            //////////////////////////////////////////////////////////////////
            //string dz7_DNK = "ACTGGACCTCACGGAATCGATACAGATTACACCCATAAGCCTTG";
            ////Архивация ДНК
            //string dz7_archiveDNK = "";
            //int dz7_code = 0;
            //for (int i = 0; i < dz7_DNK.Length; i++)
            //{
            //    switch (dz7_DNK[i])
            //    {
            //        case 'A':
            //            dz7_code = dz7_code + (0 << i%8*2);
            //            break;
            //        case 'C':
            //            dz7_code = dz7_code + (1 << i%8*2);
            //            break;
            //        case 'T':
            //            dz7_code = dz7_code + (2 << i%8*2);
            //            break;
            //        case 'G':
            //            dz7_code = dz7_code + (3 << i%8*2);
            //            break;
            //    }
            //    if ((i + 1) % 8 == 0 || i+1 == dz7_DNK.Length)
            //    {
            //        dz7_archiveDNK += Convert.ToChar(dz7_code);
            //        dz7_code = 0;
            //        if (i + 1 == dz7_DNK.Length)
            //        {
            //            dz7_archiveDNK += Convert.ToChar(dz7_DNK.Length);
            //        }
            //    }
            //}
            ////Занимаемая память = длина строки * 2 байта + 2 байта на символ конца строки
            //int dz7_sizeDNK =  dz7_DNK.Length * sizeof(char) + 2;
            //int dz7_sizeArchiveDNK = dz7_archiveDNK.Length * sizeof(char) + 2;
            //Console.WriteLine();
            //Console.Write(dz7_DNK);
            //Console.WriteLine($" -> {dz7_sizeDNK} байт");
            //Console.Write(dz7_archiveDNK);
            //Console.WriteLine($" -> {dz7_sizeArchiveDNK} байт");
            //Console.WriteLine($"Процент сжатия -> {100 - dz7_sizeArchiveDNK * 100 / dz7_sizeDNK}%");
            ////Восстановление ДНК
            //dz7_DNK = "";
            //for (int i = 0; i < dz7_archiveDNK.Length - 1; i++)
            //{
            //    dz7_code = dz7_archiveDNK[i];

            //    for (int j = 0; j < 8; j++)
            //    {
            //        dz7_code = dz7_code & 3;
            //        switch (dz7_code)
            //        {
            //            case 0:
            //                dz7_DNK += 'A';
            //                break;
            //            case 1:
            //                dz7_DNK += 'C';
            //                break;
            //            case 2:
            //                dz7_DNK += 'T';
            //                break;
            //            case 3:
            //                dz7_DNK += 'G';
            //                break;
            //        }
            //        if (dz7_DNK.Length == dz7_archiveDNK[dz7_archiveDNK.Length - 1])
            //        {
            //            break;
            //        }
            //        dz7_code = dz7_archiveDNK[i] >> (j + 1) * 2;
            //    }
            //}
            //Console.WriteLine(dz7_DNK);
            ////Ожидание "Enter"
            //Console.WriteLine("\nДз 8 -> \"Enter\"...");
            //Console.ReadLine();
            //Console.Clear();
        }
    }
}
