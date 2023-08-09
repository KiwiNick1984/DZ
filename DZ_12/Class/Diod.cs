class Diod
{
    private ConsoleColor _color;
    private int _x;
    private int _y;
    private int _onTime;
    private int _offTime;

    private bool _isOn;
    private int _time;

    public int Time 
    {
        get => _time;
        set
        {
            _time = value;
            if(_time >= (_isOn ? _offTime : _onTime))
            {
                Togle();
                _time = 0;
            }
        }
    }

    public Diod(ConsoleColor color, int x, int y, int onTime, int offTime)
    {
        _color = color;
        _x = x;
        _y = y;
        _onTime = onTime;
        _offTime = offTime;

        _isOn = true;
        _time = 0;
    }

    //бесконечное мигание
    public void TogleInfinitely()   
    {
        while (true)
        {
            Togle();
            Thread.Sleep(_isOn ? _offTime : _onTime);
        }
    }
    //переключить состояние диода
    public void Togle()
    {
        Console.BackgroundColor = ConsoleColor.Black;
        Console.SetCursorPosition(_x, _y);
        Console.BackgroundColor = _isOn ? _color : ConsoleColor.Black;
        Console.WriteLine(' ');
        _isOn = !_isOn;
    }
}
