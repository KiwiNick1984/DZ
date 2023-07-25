using System;
using System.IO;
using System.Linq;
using System.Collections.Generic;

namespace DZ_9
{
    internal class Program
    {
        //Открывает только txt файлы
        //Стрелка вверх/вниз    - Навигация
        //Enter                 - Выбор/чтение txt
        //Backspace             - Назад
        //Escape                - Выход
        static void Main(string[] args)
        {
            ConsoleKeyInfo cki = new ConsoleKeyInfo();

            DriverNav driverNav = new DriverNav();

            while (cki.Key != ConsoleKey.Escape)
            {
                cki = Console.ReadKey();
                switch (cki.Key)
                {
                    case ConsoleKey.UpArrow:
                        driverNav.Up();
                        break;
                    case ConsoleKey.DownArrow:
                        driverNav.Down();
                        break;
                    case ConsoleKey.Enter:
                        driverNav.Select();
                        break;
                    case ConsoleKey.Backspace:
                        driverNav.Back();
                        break;
                    default:
                        break;
                }
            }
        }
    }
}
