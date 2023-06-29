using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace DZ_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            ////1. Виведіть усі числа від 10 до 50 через кому
            Console.WriteLine("Виведіть усі числа від 10 до 50 через кому");
            Console.WriteLine(string.Join(", ", Enumerable.Range(10, 40).ToList()));
            Console.WriteLine();
            //2.Виведіть лише ті числа від 10 до 50, які можна поділити на 3
            Console.WriteLine("Виведіть лише ті числа від 10 до 50, які можна поділити на 3");
            Console.WriteLine(string.Join(", ", Enumerable.Range(10, 40).ToList().Where(x => (x % 3) == 0)));
            Console.WriteLine();
            //Виведіть слово "Linq" 10 разів
            Console.WriteLine("Виведіть слово \"Linq\" 10 разів");
            Console.WriteLine(string.Concat(Enumerable.Repeat("Linq", 10)));
            Console.WriteLine();
            //Вивести всі слова з буквою «а» в рядку «aaa; abb; ccc; dap»
            Console.WriteLine("Вивести всі слова з буквою «а» в рядку «aaa; abb; ccc; dap»");
            Console.WriteLine(string.Join(" ", "aaa; abb; ccc; dap".Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(str => str.Contains('a')).Select(str => str)));
            Console.WriteLine();
            //Виведіть кількість літер «а» у словах з цією літерою в рядку «aaa; abb; ccc; dap» через кому
            Console.WriteLine("Виведіть кількість літер «а» у словах з цією літерою в рядку «aaa; abb; ccc; dap» через кому");
            Console.WriteLine(string.Join(" ", "aaa; abb; ccc; dap".Split(new char[] { ';', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(str => str.Where(ch => ch == 'a').Count())));
            Console.WriteLine();
            //Вивести true, якщо слово "abb" існує в рядку "aaa;xabbx;abb;ccc;dap", інакше false
            Console.WriteLine("Вивести true, якщо слово \"abb\" існує в рядку \"aaa;xabbx;abb;ccc;dap\", інакше false");
            Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').Any(str => str.Equals("abb")));
            Console.WriteLine();
            //Отримати найдовше слово в рядку "aaa;xabbx;abb;ccc;dap"
            Console.WriteLine("Отримати найдовше слово в рядку \"aaa;xabbx;abb;ccc;dap\"");
            Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').OrderByDescending(str => str.Length).FirstOrDefault());
            Console.WriteLine();
            //Обчислити середню довжину слова в рядку "aaa;xabbx;abb;ccc;dap"
            Console.WriteLine("Обчислити середню довжину слова в рядку \"aaa;xabbx;abb;ccc;dap\"");
            Console.WriteLine("aaa;xabbx;abb;ccc;dap".Split(';').Average(str => str.Length));
            Console.WriteLine();
            //Вивести найкоротше слово в рядку "aaa;xabbx;abb;ccc;dap;zh" у зворотному порядку.
            Console.WriteLine("Вивести найкоротше слово в рядку \"aaa;xabbx;abb;ccc;dap;zh\" у зворотному порядку.");
            Console.WriteLine(string.Join("", "aaa;xabbx;abb;ccc;dap;zh".Split(';').OrderBy(str => str.Length).FirstOrDefault().Reverse()));
            //Вивести true, якщо в першому слові, яке починається з "aa", усі літери "b"(За винятком "аа"), інакше false "baaa;aabb;aaa;xabbx;abb;ccc;dap;zh"
            Console.WriteLine("Вивести true, якщо в першому слові, яке починається з \"aa\", усі літери \"b\"(За винятком \"аа\"), інакше false \"baaa;aabb;aaa;xabbx;abb;ccc;dap;zh\"");
            Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(';').First(str => str.StartsWith("aa")).Reverse().SkipWhile(ch => ch == 'b').Count() == 2);
            Console.WriteLine();
            //Вивести останнє слово в послідовності, за винятком перших двох елементів, які закінчуються на "bb"(використовуйте послідовність із 10 завдання)
            Console.WriteLine("Вивести останнє слово в послідовності, за винятком перших двох елементів, які закінчуються на \"bb\"(використовуйте послідовність із 10 завдання)");
            Console.WriteLine("baaa;aabb;aaa;xabbx;abb;ccc;dap;zh".Split(';').Skip(2).Where(str => str.EndsWith("bb")).Last());

        }
    }
}
