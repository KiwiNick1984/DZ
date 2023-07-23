using System;

namespace DZ_8_MenuClient
{
    [AttributeUsage(AttributeTargets.Method, Inherited = false, AllowMultiple = false)]
    public sealed class MenuActionsAttribute : Attribute
    {
        public MenuActionsAttribute(string menuTitle, int iDItem)
        {
            MenuTitle = menuTitle;
            IDItem = iDItem;
        }

        public string MenuTitle { get; }
        public int IDItem { get; }
    }
}
