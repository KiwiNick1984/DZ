using System;

namespace DZ_4
{
    internal class Repka : Plant
    {
        public Repka(int repkaPower = 30)  : base(repkaPower)
        {
            Console.WriteLine($"Создана репка. Мощь -> {_plantPower}");
        }
        public bool Pull(int pullPower)   //Тянуть репку (true-вытащена / false-продолжает расти)
        {
            if (_plantPower <= pullPower) {
                Console.WriteLine("Репка поддалась!");
                return true;
            } else {
                Console.WriteLine("Сила репки кажется безграничной. Нужна помощь");
                return false;
            }
        }
    }
}
