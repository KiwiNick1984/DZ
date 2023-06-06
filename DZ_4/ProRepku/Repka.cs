using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class Repka
    {
        private int repkaPower;           //Мощь репки
        public int RepkaPower { get; }
        //private bool repkaIsPulledOut = false;  //Статус перки

        public Repka()
        {
            repkaPower = 30;
            Console.WriteLine($"Создана репка. Мощь -> {repkaPower}");
        }
        public Repka(int Power)
        {
            repkaPower = Power;
            Console.WriteLine($"Создана репка. Мощь -> {repkaPower}");
        }
        public bool Boost()                 //Удобрить репку
        {
            repkaPower += 5;
            Console.WriteLine($"Репка подросла. Мощь -> {repkaPower}");
            return true;
        }
        public bool ToPull(int pullPower)   //Тянуть репку
        {
            //Определяем статус репки (true-вытащена / false-ппродолжает расти)
            if (repkaPower <= pullPower)
            {
                Console.WriteLine("Репка поддалась!");
                return true;
            }
            else
            {
                Console.WriteLine("Сила репки кажется безграничной. Нужна помощь");
                return false;
            }
        }
    }
}
