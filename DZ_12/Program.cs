internal class Program
{
    private static void Main(string[] args)
    {
        Diod diod = new Diod(ConsoleColor.Green, 1, 1, 500, 300);
    }
}

class Diod
{
    private ConsoleColor _color;
    private int _x;
    private int _y;
    private int _onTime;
    private int _offTime;

    public Diod(ConsoleColor color, int x, int y, int onTime, int offTime)
    {
        _color = color;
        _x = x;
        _y = y;
        _offTime = onTime;
        _offTime = offTime;
    }
}