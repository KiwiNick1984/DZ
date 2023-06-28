using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_6
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            //1. Виведіть усі числа від 10 до 50 через кому
            Console.WriteLine("Виведіть усі числа від 10 до 50 через кому");
            foreach (int index in Enumerable.Range(10, 40))
            {
                Console.Write(index + ", ");
            }
            Console.WriteLine();
            //2.Виведіть лише ті числа від 10 до 50, які можна поділити на 3
            Console.WriteLine("Виведіть лише ті числа від 10 до 50, які можна поділити на 3");
            List<int> list = Enumerable.Range(10, 40).ToList();
            var enumerable = list.Where(x => (x%3) == 0);
            foreach (int index in enumerable)
            {
                Console.Write(index + ", ");
            }


        }
    }
}
