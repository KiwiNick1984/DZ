using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class Garden
    {
        List<Repka> _garden = new List<Repka>();
        public void PlantRepka(int powr = 30)           //Посадить репку 
        {
            int i;
            for (i = 0; i < _garden.Count; i++) {
                _garden[i] = _garden[i] ?? new Repka(powr);
            }
            if (i == _garden.Count) {
                _garden.Add(new Repka(powr));
            }
            Console.WriteLine($"Репка посажена на участке #{i + 1}");
        }
        //private bool CheсkGardenArea(int gardenArea)    //Проверить участок на наличие репки 
        //{
        //    return (gardenArea > 0 && gardenArea <= _garden.Count && _garden[gardenArea - 1] != null);
        //}
        public bool PrintGarden()       //Состояние сада на экран
        {
            bool thereIsRepka = false;
            if (_garden.Count>0) {
                Console.Write("Номера участков с репкой:");
                for (int i = 0; i < _garden.Count; i++) {
                    if (_garden[i] != null) {
                        Console.Write($" {i + 1},");
                        thereIsRepka = true;
                    }
                }
            }
            if (!thereIsRepka) {
                Console.WriteLine("\nДед или забы посадить репку, или выдернул все!");
            }
            return thereIsRepka;
        }
        public Repka GetRepka(int gardenArea)
        {
            if (gardenArea > 0 && gardenArea <= _garden.Count && _garden[gardenArea - 1] != null)   //есть ли репка на участке
                return _garden[gardenArea - 1];
            else
                return null;
        }
        public void DeleteRepka(Repka repka)
        {
            for (int i = 0; i < _garden.Count; i++)
            {
                if (_garden[i].GetHashCode() == repka.GetHashCode())
                    _garden[i] = null;
            }
        }
    }
}