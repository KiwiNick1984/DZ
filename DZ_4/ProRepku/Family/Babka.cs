using System;

namespace DZ_4
{
    internal class Babka : Vnychka
    {
        protected int _babkaPower;   //Сила бабки
        public Babka()
        {
            _babkaPower = 15;
        }
        protected void BabkaPull(Plant plant, int power)
        {
            if (plant is Repka repka)
            {
                Console.WriteLine("Дед и бабка тянут репку!");
                if (!repka.Pull(power + _babkaPower))
                    VnychkaPull(repka, power + _babkaPower);
            }
            else if (plant is Beet beet)
            {
                Console.WriteLine("Дед и бабка тянут свеклу!");
                if (!beet.Pull(power + _babkaPower))
                    VnychkaPull(beet, power + _babkaPower);
            }
        }
    }
}
