using System;

namespace DZ_8_CommonMenu
{
    [System.AttributeUsage(AttributeTargets.Property, Inherited = false, AllowMultiple = false)]
    public sealed class SubMenuAttribute : Attribute
    {
        public SubMenuAttribute(string menuTitle, int iDItem)
        {
            MenuTitle = menuTitle;
            IDItem = iDItem;

        }
        public string MenuTitle { get; }
        public int IDItem { get; }
    }
}
