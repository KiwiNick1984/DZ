using System;

namespace DZ_4
{
    internal class Beet : Plant
    {
        public Beet(int deetPower = 30) : base(deetPower)
        {
            Console.WriteLine($"Создана свекла. Мощь -> {_plantPower}");
        }
        public bool Pull(int pullPower)   //Тянуть свеклу (true-вытащена / false-продолжает расти)
        {
            if (_plantPower <= pullPower) {
                Console.WriteLine("Свекла поддалась!");
                return true;
            } else {
                Console.WriteLine("Сила свеклы кажется безграничной. Нужна помощь");
                return false;
            }
        }
    }
}
