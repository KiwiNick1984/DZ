using DZ_8_CommonMenu;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DZ_8_MenuClient
{
    public class Menu : MenuItem, IMenu
    {
        private List<IMenuIten> _items = new List<IMenuIten>();
        public IEnumerable<IMenuIten> Items => _items;
        //public Menu _prevNemu;
        public Menu(string menuTitle) : base(menuTitle)
        { }
        public Menu(string menuTitle, int iDItem, Action process) : base(menuTitle, iDItem, process)
        { }
        public void AddMenuItem(IMenuIten item)
        {
            _items.Add(item);
        }
        public void OrgerItems()
        {
            _items = _items.OrderBy(i => i.IDItem).ToList();
            var item = _items[0];
            _items.RemoveAt(0);
            _items.Add(item);
        }
        public override bool Process()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(Title);
                foreach (var item in _items)
                {
                    Console.WriteLine($"{item.IDItem} - {item.Title}");
                }
                if (int.TryParse(Console.ReadLine(), out int choice))
                {
                    var menuItem = _items.FirstOrDefault(i => i.IDItem == choice);
                    if (menuItem == null)
                        Console.WriteLine("ERROR! Incorrect input");
                    else
                    {
                        if (menuItem.Process())
                        {
                            return false;
                        }
                    }
                }
            }
        }
        public static Menu DetectMenu<T>() where T : new()
        {
            var menuName = typeof(T).GetCustomAttribute<MainMenuAttribute>().MenuTitle;
            return DetectMenu(new Menu(menuName), typeof(T));
        }
        public static Menu DetectMenu(Menu menu, Type menuType)
        {
            var menuBildMethods = Activator.CreateInstance(menuType);
            var menuItems = menuType.
                GetMethods().
                Where(m => m.GetCustomAttribute<MenuActionsAttribute>() != null).
                Select(m =>
                {
                    var atr = m.GetCustomAttribute<MenuActionsAttribute>();
                    return new MenuItem(atr.MenuTitle, atr.IDItem, () => m.Invoke(menuBildMethods, null));
                });
            var subMenus = menuType.
                GetProperties().
                Where(p => p.GetCustomAttribute<SubMenuAttribute>() != null).
                Select(p =>
                {
                    var atr = p.GetCustomAttribute<SubMenuAttribute>();
                    return new { Menu = new Menu(atr.MenuTitle, atr.IDItem, null), Type = p.PropertyType };
                });
            foreach (var item in subMenus)
            {
                menu.AddMenuItem(DetectMenu(item.Menu, item.Type));
            }
            foreach (var item in menuItems)
            {
                menu.AddMenuItem(item);
            }
            menu.OrgerItems();
            return menu;
        }
    }
}
