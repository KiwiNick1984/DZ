using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class Babka : Vnychka
    {
        protected int _babkaPower;   //Сила бабки

        public Babka()
        {
            _babkaPower = 15;
        }
        protected bool BabkaPull(Repka repka, int power)
        {
            Console.WriteLine("Дед и бабка тянет репку!");
            if (repka.ToPull(power + _babkaPower)) {
                return true;
            } else {
                return VnychkaPull(repka, power + _babkaPower);
            }
        }
    }
}
