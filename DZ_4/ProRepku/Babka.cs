using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class Babka : Ded
    {
        private int _babkaPower;   //Сила бабки

        public Babka()
        {
            _babkaPower = 15;
        }
        public void PullTheRepka()
        {
            Console.WriteLine("Дед и бабка тянет репку!");
            if (_seizedRepka?.ToPull(_dedPower + _babkaPower) ?? false)
            {
                _garden.DeleteRepka(_seizedRepka);
            }
            Console.WriteLine("Нажмите Enter для проболжения.");
            Console.ReadLine();
        }
    }
}
