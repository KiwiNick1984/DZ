namespace DZ_8_MenuClient
{
    public class ExitMenuItem : IMenuIten
    {
        public string Title => "Exit";

        public int IDItem => 0;

        public bool Process()
        {
            return true;
        }
    }
}
