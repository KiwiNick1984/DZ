using DZ_8_MenuClient;

namespace DZ_8_MenuManager
{
    class ManegerCreateMenu
    {
        [MenuActions("CreateClient", 1)]
        public void CreateClient()
        { }

        [MenuActions("CreateAccount", 2)]
        public void CreateAccount()
        { }

        [MenuActions("Exit", 0)]
        public void Exit()
        { }
    }
}
