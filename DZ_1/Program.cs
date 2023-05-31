using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;

namespace DZ_1
{
    internal class Program
    {
        //для ДЗ 2
        static string[] Splitting(string inStr)
        { 
            string[] outMasStr;
            string[] tempMasStr;
            string tempStr;
            if (inStr.IndexOf(',') > 0)
            {
                tempStr = inStr.Substring(0, inStr.IndexOf(','));
                tempStr = tempStr.Trim();
                tempMasStr = Splitting(inStr.Substring(inStr.IndexOf(',')+1));
                outMasStr = new string[tempMasStr.Length + 1];
                outMasStr[0] = string.Copy(tempStr);
                for (int i = 0; i < tempMasStr.Length; i++)
                {
                    outMasStr[i + 1] = tempMasStr[i];
                }
            }
            else 
            {
                outMasStr = new string[1];
                outMasStr[0] = string.Copy(inStr.Trim());
            }
            return outMasStr;
        }

        //для ДЗ 3
        static string IntToStr(int inInt, int i, string intStr)
        {            
            if (i == 0)
            {
                if (inInt == 0)
                    intStr = ((IntDigit)0).ToString();
                else if (inInt % 100 < 20)
                    intStr = IntToStr(inInt / 100, 100, ((IntDigit)(inInt % 100)).ToString()) + " " + intStr;
                else
                    intStr = IntToStr(inInt / 10, 10, ((IntDigit)(inInt % 10)).ToString()) + " " + intStr;
            }
            else
            {
                if ((inInt % 10) > 0)
                    intStr = IntToStr(inInt / 10, 10 * i, ((IntDigit)(inInt % 10 * i)).ToString() + " " + intStr);
            }
            return intStr;
        }
        enum IntDigit
        {
            Ноль,
            один,
            два,
            три,
            четыре,
            пять,
            шесть,
            семь,
            восемь,
            девять,
            десять,
            одиннадцать,
            двенадцать,
            тринадцать,
            четырнадцать,
            пятнадцать,
            шестнадцать,
            семнадцать,
            восемннадцать,
            девятнадцать,
            двадцать = 20,
            тридцать = 30,
            сорок = 40,
            пятьдесят = 50,
            шестьдесят = 60,
            семьдесят = 70,
            восемьдесят = 80,
            девяносто = 90,
            сто = 100,
            двести = 200,
            триста = 300,
            четыреста = 400,
            пятьсот = 500,
            шестьсот = 600,
            семьсот = 700,
            восемьсот = 800,
            девятьсот = 900,
            тысяча = 1000,
        }

        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            /////////////////////////////ДЗ 1/////////////////////////////
            Console.WriteLine("\t\tДЗ 1");
            Console.WriteLine("Знайти позицію літери в алфавіті та перевести її в інший регістр\n");
            //////////////////////////////////////////////////////////////
            //Формируем алфавит
            char[] Alfavit = new char[116];
            for (int i = 0; i < Alfavit.Length; i++)
            {
                Alfavit[i] = Convert.ToChar(i + 11);
            }
            Console.WriteLine("Исходный массив символов:");
            foreach (var item in Alfavit)
            {
                Console.Write(item);
            }
            //Выводим только буквы на консоль
            Console.WriteLine("\n\nТолько буквы:");
            foreach (var item in Alfavit)
            {
                if (char.IsLetter(item))
                    Console.Write(item);
            }
            //Находим букву и меняем регистр с выводом на консоль
            Console.WriteLine("\nПосле смены регистра:");
            for (int i = 0; i < Alfavit.Length; i++)
            {
                if (char.IsLetter(Alfavit[i]))
                {
                    if (char.IsUpper(Alfavit[i]))
                        Alfavit[i] = char.ToLower(Alfavit[i]);
                    else
                        Alfavit[i] = char.ToUpper(Alfavit[i]);
                    Console.Write(Alfavit[i]);
                }
            }
            //Ожидание "Enter"
            Console.WriteLine("\n\nДз 2 -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();

            ///////////////////////////ДЗ 2/////////////////////////////
            Console.WriteLine("\t\tДЗ 2");
            Console.WriteLine("Розділювач рядка.\r\n" +
                              "Дана строка та символ, потрібно розділити строку на кілька строк (масив строк) виходячи із заданого символу.\n" +
                              "Наприклад: строка = \"Лондон, Париж, Рим\", а символ = ','.\n" +
                              "Результат = string[] { \"Лондон\", \"Париж\", \"Рим\" }.");
            //////////////////////////////////////////////////////////////
            string inStr = "Лондон, Париж, Рим";
            Console.WriteLine("\nВходящая строка:");
            Console.WriteLine(inStr);
            string[] splitMassStr = Splitting(inStr);
            Console.WriteLine("\nВозвращаем массив городов:");
            foreach(var line in splitMassStr)
                Console.WriteLine(line);
            //Ожидание "Enter"
            Console.WriteLine("\nДз 3 -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();

            /////////////////////////////ДЗ 3/////////////////////////////
            Console.WriteLine("\t\tДЗ 3");
            Console.WriteLine("Пошук підстроки у строці.");
            //////////////////////////////////////////////////////////////
            int index;
            inStr = "один два три четыре два пять четыре";
            string subStr = "два";
            Console.WriteLine("Входящая строка: " + inStr);
            Console.WriteLine("Искомая строка:  " + subStr);
            //index = inStr.IndexOf(subStr);
            //if (index != -1)
            //    Console.WriteLine($"Строка \"{inStr.Substring(index, subStr.Length)}\" встречается на {index + 1} символе");
            for (int i = 0; i < inStr.Length - subStr.Length; i++)
            {
                index = i;
                for (int j = 0; j < subStr.Length; j++)
                {
                    if (subStr[j] != inStr[j+i])
                    {
                        index = -1;
                        break;
                    }                    
                }
                if (index >= 0)
                    Console.WriteLine($"индекс вхождения -> {index}");             
            }
            //Ожидание "Enter"
            Console.WriteLine("\nДз 4 -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();

            ///////////////////////////ДЗ 4/////////////////////////////
            Console.WriteLine("\t\tДЗ 4");
            Console.WriteLine("Написати програму, яка виводить число літерами.Приклад: 117 - сто сімнадцять.");
            //////////////////////////////////////////////////////////////
            Console.Write("Введите число -1999..1999 -> ");
            int inVal = Convert.ToInt32(Console.ReadLine());
            while (!(inVal > -2000 && inVal < 2000))
            {
                Console.Clear();
                Console.WriteLine("Ошибка ввода!");
                Console.Write("Введите число -1999..1999 -> ");
                inVal = Convert.ToInt32(Console.ReadLine());
            }
            string intStr = IntToStr(Math.Abs(inVal), 0, "");
            if (inVal < 0)
                intStr = "минус " + intStr;
            Console.WriteLine(intStr);
            //Ожидание "Enter"
            Console.WriteLine("\nДз 5 -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();

            /////////////////////////////ДЗ 5/////////////////////////////
            //Поміняти місцями значення двох змінних (типу int) (без використання 3й)
            Console.WriteLine("\t\tДЗ 5");
            Console.WriteLine("Поміняти місцями значення двох змінних (типу int) (без використання 3й)");
            int int1 = 356;
            int int2 = 587;
            Console.WriteLine($"int1 -> {int1}");
            Console.WriteLine($"int2 -> {int2}");
            int1 += int2;
            int2 = int1 - int2;
            int1 -= int2;
            Console.WriteLine("Фжух!");
            Console.WriteLine($"int1 -> {int1}");
            Console.WriteLine($"int2 -> {int2}");
        }
    }
}
