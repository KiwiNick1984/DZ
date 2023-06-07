using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class Garden
    {
        List<Repka> garden = new List<Repka>();
        public void PlantRepka(int powr = 30) {
            int i;
            for (i = 0; i < garden.Count; i++) {
                garden[i] = garden[i] ?? new Repka(powr);
            }
            if (i == garden.Count) {
                garden.Add(new Repka(powr));
            }
            Console.WriteLine($"Репка посажена на участке #{i + 1}");
        }
        public bool CheсkGardenArea(int gardenArea) {
            return (gardenArea > 0 && gardenArea <= garden.Count && garden[gardenArea - 1] != null);
        }
        public void PrintGarden() {
            if()
            {


            }
        }
    }
}