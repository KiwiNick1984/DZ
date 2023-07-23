using DZ_8_CommonMenu;
using DZ_8_MenuClient;

namespace DZ_8_MenuManager
{
    [MainMenu("Manager main menu")]
    class ManagerMainMenu
    {
        [MenuActions("Shou all accounts", 1)]
        public void ShouAllAccounts()
        { }

        [MenuActions("Shou all clients", 2)]
        public void ShouAllClients()
        { }

        [SubMenu("Search", 3)]
        public ManegerSeachMenu Search { get; set; }
        [SubMenu("Create", 4)]
        public ManegerCreateMenu Create { get; set; }

        [MenuActions("Exit", 0)]
        public void Exit()
        { }
    }
}
