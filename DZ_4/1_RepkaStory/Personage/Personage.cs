namespace RepkaStory
{
    internal class Personage
    {
		private int _personagePower;
		public int PersonagePower
        {
			get { return _personagePower; }
		}
		public Personage(int personagePower)
		{
			_personagePower = personagePower;
		}

		public virtual bool Pull(Plant plant, int personagePower)
		{
            return plant.Pull(personagePower);
        }
    }
}
