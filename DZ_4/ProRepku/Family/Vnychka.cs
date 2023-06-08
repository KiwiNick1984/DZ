using System;

namespace DZ_4
{
    internal class Vnychka
    {
        protected int _vnychkaPower;   //Сила внучки

        public Vnychka()
        {
            _vnychkaPower = 10;
        }
        protected void VnychkaPull(Plant plant, int power)
        {
            if (plant is Repka repka)
            {
                Console.WriteLine("Дед, бабка и внучка тянут репку!");
                if (!repka.Pull(power + _vnychkaPower)) { }
            }
            else if (plant is Beet beet)
            {
                Console.WriteLine("Дед, бабка и внучка тянут свеклу!");
                if (!beet.Pull(power + _vnychkaPower)) { }
            }
        }
    }
}
