using System;

namespace RepkaStory
{
    internal class Beet : Plant
    {
        public Beet(int plantPower = 10) : base(plantPower)
        {
            Console.WriteLine("Свекла посажена!");
        }
        public override bool Pull(int pullPower)
        {
            if (pullPower >= PlantPower)
            {
                Console.WriteLine("Свекла поддалась");
                return true;
            }
            Console.WriteLine("Сила свеклы кажется безграничной. Нужна помощь");
            return false;
        }
    }
}
