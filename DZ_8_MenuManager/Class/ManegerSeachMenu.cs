using DZ_8_MenuClient;

namespace DZ_8_MenuManager
{
    class ManegerSeachMenu
    {
        [MenuActions("Client", 1)]
        public void Client()
        { }

        [MenuActions("Account", 2)]
        public void Account()
        { }

        [MenuActions("Exit", 0)]
        public void Exit()
        { }
    }
}
