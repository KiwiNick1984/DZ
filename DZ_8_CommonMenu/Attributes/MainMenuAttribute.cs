using System;

namespace DZ_8_CommonMenu
{
    [AttributeUsage(AttributeTargets.Class, Inherited = false, AllowMultiple = false)]
    public sealed class MainMenuAttribute : Attribute
    {
        public MainMenuAttribute(string menuTitle)
        {
            MenuTitle = menuTitle;
        }
        public string MenuTitle { get; set; }
    }
}
