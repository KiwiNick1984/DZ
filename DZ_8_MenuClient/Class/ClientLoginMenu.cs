namespace DZ_8_MenuClient
{
    class ClientLoginMenu
    {
        [MenuActions("Display all accounts", 1)]
        public void DisplayAccounts() 
        { }
        [MenuActions("Transfer", 2)]
        public void Transfer()
        { }
        [MenuActions("Exit", 0)]
        public void Exit()
        { }
    }
}
