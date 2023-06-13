using System;

namespace RepkaStory
{
    internal class Vnychka : Personage
    {
        public Vnychka(int personagePower = 3) : base(personagePower)
        { }
        public override bool Pull(Plant plant, int personagePower)
        {
            Console.WriteLine("Дед, бабка и внучка тянет!");
            return plant.Pull(personagePower);
        }
    }
}
