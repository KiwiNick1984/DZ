namespace DZ_8_MenuClient
{
    public interface IMenuIten
    {
        string Title { get; }
        int IDItem { get; }
        bool Process();
    }
}
