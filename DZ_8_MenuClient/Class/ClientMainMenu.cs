using DZ_8_CommonMenu;

namespace DZ_8_MenuClient
{
    [MainMenu("Client main menu")]
    class ClientMainMenu
    {
        [SubMenu("Login menu", 1)]
        public ClientLoginMenu subMenu { get; set; }

        [MenuActions("Exit", 0)]
        public void Exit() 
        {
        }
    }
}
