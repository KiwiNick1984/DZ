using System;

namespace DZ_8_MenuClient
{
    public class MenuItem : IMenuIten
    {
        private readonly Action _process;
        public string Title { get; }

        public int IDItem { get; }

        public virtual bool Process()
        {
            _process();
            return IDItem == 0;
        }
        public MenuItem(string title)
        {
            Title = title;
            IDItem = -1;
            _process = null;
        }
        public MenuItem(string title, int iDItem, Action process)
        {
            Title = title;
            IDItem = iDItem;
            _process = process;
        }
    }
}
