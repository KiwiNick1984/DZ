using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class Vnychka
    {
        protected int _vnychkaPower;   //Сила внучки

        public Vnychka()
        {
            _vnychkaPower = 10;
        }
        protected bool VnychkaPull(Repka repka, int power)
        {
            Console.WriteLine("Дед, бабка и внучка тянет репку!");
            if (repka.ToPull(power + _vnychkaPower))
            {
                return true;
            } else {
                return false; 
            }
        }
    }
}
