using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_7
{
    class Actor
    {
        public string Name { get; set; }
        public DateTime Birthdate { get; set; }
    }

    abstract class ArtObject
    {
        public string Author { get; set; }
        public string Name { get; set; }
        public int Year { get; set; }
    }

    class Film : ArtObject
    {
        public int Length { get; set; }
        public IEnumerable<Actor> Actors { get; set; }
    }

    class Book : ArtObject
    {
        public int Pages { get; set; }
    }
    internal class Program
    {
        static void Main(string[] args)
        {
            var data = new List<object>()
            {
                "Hello",
                new Book() { Author = "Terry Pratchett", Name = "Guards! Guards!", Pages = 810 },
                new List<int>() {4, 6, 8, 2},
                new string[] {"Hello inside array"},
                new Film()
                {
                    Author = "Martin Scorsese",
                    Name= "The Departed",
                    Actors = new List<Actor>()
                    {
                        new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
                        new Actor() { Name = "Leonardo DiCaprio", Birthdate = new DateTime(1974, 11, 11)},
                        new Actor() { Name = "Matt Damon", Birthdate = new DateTime(1970, 8, 10)}
                    }
                },
                new Film()
                {
                    Author = "Gus Van Sant",
                    Name = "Good Will Hunting",
                    Actors = new List<Actor>()
                    {
                        new Actor()
                        {
                            Name = "Matt Damon",
                            Birthdate = new DateTime(1970, 8, 10)
                        },
                        new Actor()
                        {
                            Name = "Robin Williams",
                            Birthdate = new DateTime(1951, 8, 11)
                        }
                    }
                },
                new Book()
                {
                    Author = "Stephen King",
                    Name="Finders Keepers",
                    Pages = 200
                },
                "Leonardo DiCaprio"
            };
            Console.WriteLine(string.Compare());
            foreach (var item in data.Where(i => !(i is ArtObject)))
            {
                Console.WriteLine(item);
            }
            //foreach (var item in data.Select(c =>
            //    {
            //        if (c is Film ArtObject)
            //            return null;
            //        return c; 
            //    }).SelectMany(c => c.object))
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
