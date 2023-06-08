using System;

namespace DZ_4
{
    internal class Ded : Babka
    {
        protected int _dedPower;        //Дедова мощь
        protected Plant _plant;         //Растение
        public Ded(int plantPower = 30) {
            _dedPower = 30;
            Console.WriteLine("Что посадить деду?");
            Console.WriteLine("1 - репку?");
            Console.WriteLine("2 - свеклу?");
            int selectPlant;
            while (true)    //Выбор растения
            {  
                selectPlant = Convert.ToInt32(Console.ReadLine());
                switch (selectPlant)
                {  
                    case 1:
                        _plant = new Repka(plantPower);
                        break;
                    case 2:
                        _plant = new Beet(plantPower);
                        break;
                    default:
                        Console.WriteLine("Нет таких семян у деда?");
                        break;
                }
                if (_plant != null)
                    break;
            }
        }
        public void DedPull()   //Тянем растение
        {
            if(_plant is Repka repka)
            {
                Console.WriteLine("Дед тянет репку!");
                if (!repka.Pull(_dedPower))
                    BabkaPull(repka, _dedPower);
            }                    
            else if (_plant is Beet beet)
            {
                Console.WriteLine("Дед тянет свеклу!");
                if (!beet.Pull(_dedPower))
                    BabkaPull(beet, _dedPower);
            }
        }
    }
}
