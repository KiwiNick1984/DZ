class Swicher
{
    private List<Diod> _diods;
    private int _quante;

    public Swicher(params Diod[] diods)
    {
        _diods = new List<Diod>(diods);
        _quante = 10;
    }

    //Переключение диода по кванту времени (10мс)
    public void Start() 
    {
        while(true)
        {
            _diods.ForEach(d => d.Time += _quante);
            Thread.Sleep(_quante);            
        }
    }
}