using System.Collections.Generic;

namespace DZ_8_MenuClient
{
    public interface IMenu
    {
        IEnumerable<IMenuIten> Items { get; }
    }
}
