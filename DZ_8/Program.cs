using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_8
{
    internal class Program
    {
        class Film
        {
            public string Name { get; set; }
            public string Director { get; set; }
        }
        class Director
        {
            public string Name { get; set; }
            public string Country { get; set; }
        }


        static void Main(string[] args)
        {
            List<Film> films = new List<Film>()
            {
                new Film { Name = "The Silence of the Lambs", Director ="Jonathan Demme" },
                new Film { Name = "The World's Fastest Indian", Director ="Roger Donaldson" },
                new Film { Name = "The Recruit", Director ="Roger Donaldson" }
            };
            List<Director> directors = new List<Director>()
            {
                new Director {Name="Jonathan Demme", Country="USA"},
                new Director {Name="Roger Donaldson", Country="New Zealand"},
            };
            //Вивести всі фільми у такому форматі: "FilmName DirectorName (DirectorCountry)"
        }
    }
}
