using System;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8_MenuClient
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //Menu loginMenu = new Menu("Login menu", 1, null);
            //loginMenu.AddMenuItem(new MenuItem("Display all accounts", 1, () => Console.WriteLine("Display all accounts")));
            //loginMenu.AddMenuItem(new MenuItem("Transfer", 2, () => Console.WriteLine("Transfer")));
            //loginMenu.AddMenuItem(new ExitMenuItem());

            //Menu clientMenu = new Menu("Client menu");
            //clientMenu.AddMenuItem(loginMenu);
            //clientMenu.AddMenuItem(new ExitMenuItem());

            //clientMenu.Process();

            Menu.DetectMenu<ClientMainMenu>().Process();
        }
    }
}
