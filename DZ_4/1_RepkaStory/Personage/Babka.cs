using System;

namespace RepkaStory
{
    internal class Babka : Personage
    {
        public Babka(int personagePower=5) : base(personagePower)
        { }
        public override bool Pull(Plant plant, int personagePower)
        {
            Console.WriteLine("Дед и бабка тянет!");
            return plant.Pull(personagePower);
        }
    }
}
