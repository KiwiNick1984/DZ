namespace RepkaStory
{
    internal class Plant
    {
        private int _plantPower;
        public int PlantPower
        {
            get { return _plantPower; }
        }
        public Plant(int plantPower)
        {
            _plantPower = plantPower;
        }
        public virtual bool Pull(int pullPower)
        {
            return (pullPower >= _plantPower);
        }
    }
}
