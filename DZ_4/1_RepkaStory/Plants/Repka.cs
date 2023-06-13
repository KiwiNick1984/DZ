using System;

namespace RepkaStory
{
    internal class Repka : Plant
    {
        public Repka(int plantPower = 10) : base(plantPower)
        {
            Console.WriteLine("Репка посажена!");
        }
        public override bool Pull(int pullPower)
        {
            if(pullPower >= PlantPower)
            {
                Console.WriteLine("Репка поддалась");
                return true;
            }
            Console.WriteLine("Сила репки кажется безграничной. Нужна помощь");
            return false;
        }
    }
}
