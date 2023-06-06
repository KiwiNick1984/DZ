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
        private int dedPower = 30;          //Дедова мощь
        List<Repka> garden = new List<Repka>();       
        public Ded() {
        }
        public void plantRepka()            //Посадить репку на пустой участок
        {
            int i;
            for (i = 0; i < garden.Count; i++) {
                garden[i] = garden[i] ?? new Repka();
            }
            if (i == garden.Count)
                garden.Add(new Repka());
            Console.WriteLine($"Репка посажена на участке #{i + 1}");
        }
        public void plantPowerfulRepka()    //Посадить мощную репку на пустой участок
        {
            int i;
            for (i = 0; i < garden.Count; i++) {
                garden[i] = garden[i] ?? new Repka(40);
            }
            if (i == garden.Count)
                garden.Add(new Repka(40));
            Console.WriteLine($"Репка посажена на участке #{i + 1}");
        }

        public void BoostTheRepka()         //Удобрить репку
        {
            int gardenArea = SelectGardenArea();
            if(gardenArea>0)
                garden[gardenArea - 1].Boost();
        }
        public void PullTheRepka()
        {
            int gardenArea = SelectGardenArea();
            if (gardenArea > 0)
            {
                Console.WriteLine(garden[gardenArea - 1].ToPull(dedPower));
            }
                
            //bool thereIsRepka = false;

            //Console.Write("Номера участков с репкой:");
            //for (int i = 0; i < garden.Count; i++) {
            //    if(garden[i] != null)
            //        Console.Write($" {i+1},");
            //}
            //Console.Write("\nИз какого участка тянуть? -> ");
        }

        private int SelectGardenArea()      //Выбор участка с репкой
        {
            int gardenArea = 0;
            bool thereIsRepka = false;
            while (true)
            {
                Console.Clear();
                Console.Write("Номера участков с репкой:");
                for (int i = 0; i < garden.Count; i++)
                {
                    if (garden[i] != null)
                    {
                        Console.Write($" {i + 1},");
                        thereIsRepka = true;
                    }
                }
                if (!thereIsRepka)
                {
                    Console.WriteLine("\nДед или забы посадить репку, или выдернул все!");
                    return 0;
                }
                Console.Write("\nВыбери участок -> ");
                gardenArea = Convert.ToInt32(Console.ReadLine());
                if (gardenArea > 0 && gardenArea <= garden.Count)
                {
                    if (garden[gardenArea - 1] != null)
                        return gardenArea;
                }
            }
        }
    }
}
