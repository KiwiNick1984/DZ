using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class Ded
    {
        protected int _dedPower;   //Дедова мощь
        protected Garden _garden;  //Дедов сад
        protected Repka _seizedRepka;    //Схваченная репка
        public Ded() {
            _dedPower = 30;
            _garden = new Garden();
        }
        public void plantRepka(int powr = 30)   //Посадить репку на пустой участок
        {
            _garden.PlantRepka(powr);
        }
        public void BoostTheRepka()             //Удобрить репку
        {
            Console.Clear();
            Console.WriteLine("Удобряем репку");
            _seizedRepka = SelectGardenArea();
            _seizedRepka?.Boost();
            Console.WriteLine("Нажмите Enter для проболжения.");
            Console.ReadLine();
        }
        public void PullTheRepka()              //Тянем репку
        {
            Console.Clear();
            Console.WriteLine("Дед тянет репку!");
            _seizedRepka = SelectGardenArea();
            if(_seizedRepka?.ToPull(_dedPower) ?? false)
            {
                _garden.DeleteRepka(_seizedRepka);
            }
            else
            {
                if(this is Babka babka)
                { babka.PullTheRepka(); }
            }
            Console.WriteLine("Нажмите Enter для проболжения.");
            Console.ReadLine();
        }
        private Repka SelectGardenArea()      //Выбор участка с репкой и получить/не_получить репку
        {
            int gardenArea = 0;
            Repka repka;
            while (true) {
                if (!_garden.PrintGarden()){
                    repka = null;
                    break;
                }
                Console.Write("\nВыбери участок -> ");
                gardenArea = Convert.ToInt32(Console.ReadLine());
                repka = _garden.GetRepka(gardenArea);
                if (repka != null) {
                    break;
                }
                else
                {
                    Console.WriteLine("Дед не нашел на этом участке репку.");
                    Console.WriteLine("Надо напрячь старое зрение и посмотреть ещё.");
                }
            }
            return repka;
        }
    }
}
