using DZ_8_MenuClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8_MenuManager
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Menu.DetectMenu<ManagerMainMenu>().Process();
        }
    }
}
