using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DZ_8
{
    internal class Program
    {
        #region [Class for LINQ]
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
        #endregion

        static void Main(string[] args)
        {
            #region [LINQ]
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
            Console.WriteLine(films.Join(directors,
                                        f => f.Director,
                                        d => d.Name,
                                        (f, d) => new { fName = f.Name, dNane = d.Name, dCountry = d.Country }).
                                    Select(u => $"\"{u.fName}\" {u.dNane} {u.dCountry}\n").
                                    Aggregate((x, y) => x + y)
                             );
            Console.WriteLine(films.Join(directors,
                                        f => f.Director,
                                        d => d.Name,
                                        (f, d) => new { fName = f.Name, dNane = d.Name }).
                                    GroupBy(u => u.dNane).
                                    Select(gr => new { dNane = gr.Key, films = gr.Select(g => g.fName) }).
                                    Select(u => $"{u.dNane} \n {u.films.Aggregate((x, y) => x + ", " + y)}").
                                    Aggregate((x, y) => x + "\n" + y)
                             );
            #endregion
        }
    }
}
