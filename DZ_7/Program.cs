using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace DZ_7
{
    public class Actor
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
                new Book() 
                {
                    Author = "Terry Pratchett", 
                    Name = "Guards! Guards!", 
                    Pages = 810 
                },
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
                    Author = "Martin Scorsese",
                    Name= "Film 2",
                    Actors = new List<Actor>()
                    {
                        new Actor() { Name = "Jack Nickolson", Birthdate = new DateTime(1937, 4, 22)},
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
            //1.Виведіть усі елементи, крім ArtObjects
            Console.WriteLine("1");
            Console.WriteLine(string.Join(", ", data.Where(i => !(i is ArtObject))));
            Console.WriteLine();
            //2. Виведіть імена всіх акторів
            Console.WriteLine("2");
            Console.WriteLine(string.Join(", ", data.OfType<Film>().Cast<Film>().SelectMany(f => f.Actors.Select(a => a?.Name)).Distinct()));
            Console.WriteLine();
            //3.Виведіть кількість акторів, які народилися в серпні
            Console.WriteLine("3");
            Console.WriteLine(string.Join(", ", data.OfType<Film>().Cast<Film>().SelectMany(i => i.Actors.Where(a => a.Birthdate.Month == 8).Select(a => a.Name)).Distinct()));
            Console.WriteLine();
            //4.Виведіть два найстаріших імена акторів
            Console.WriteLine("4");
            Console.WriteLine(string.Join(", ", data.OfType<Film>().Cast<Film>().SelectMany(i => i.Actors).OrderBy(a => a.Birthdate).Select(a => a.Name).Take(2)));
            Console.WriteLine();
            //5.Вивести кількість книг на авторів
            Console.WriteLine("5");
            Console.WriteLine(string.Join(", ", data.OfType<Book>().Cast<Book>().GroupBy(b => b.Author).Select(x => string.Join(" ", x.Key, x.Count()))));
            Console.WriteLine();
            //6.Виведіть кількість книг на одного автора та фільмів на одного режисера
            Console.WriteLine("6");
            Console.WriteLine(string.Join(", ", data.Where(b => b is Film || b is Book).GroupBy(b => (b is Film) ? ((Film)b).Author : ((Book)b).Author).Select(x => string.Join(" ", x.Key, x.Count()))));
            Console.WriteLine();
            //7.Виведіть, скільки різних букв використано в іменах усіх акторів
            Console.WriteLine("7");
            Console.WriteLine(string.Join(", ", data.OfType<Film>().Cast<Film>().SelectMany(f => f.Actors.Select(a => a?.Name)).GroupBy(a => a).Select(a => string.Join(" ", a.Key, (a.Key).Replace(" ", "").Distinct().Count()))));
            Console.WriteLine();
            //8.Виведіть назви всіх книг, упорядковані за іменами авторів і кількістю сторінок
            Console.WriteLine("8");
            Console.WriteLine(string.Join(", ", data.OfType<Book>().Cast<Book>().OrderBy(b => b.Author).ThenBy(b => b.Pages).Select(b => b.Name)));
            Console.WriteLine();
            //9.Виведіть ім'я актора та всі фільми за участю цього актора

            var rerult = data.OfType<Film>().
                  Cast<Film>().
                  SelectMany(f => f.Actors).
                  Select(f => f.Name).
                  Distinct().
                  Select(an => string.Concat(an + "\n", string.Join("\n", data.OfType<Film>().
                                                                        Cast<Film>().
                                                                        Where(f => f.Actors.Any(a => a.Name == an)).
                                                                        Select(f => "\t" + f.Name)
                                                            )
                            
                                            )
                        );
            foreach (var item in rerult)
            {
                Console.WriteLine(item);
            }

            //10.Виведіть суму загальної кількості сторінок у всіх книгах і всі значення int у всіх послідовностях у даних
            //Console.WriteLine(10);
            //foreach (var item in data.Where(i => i is List<int> || i is Book).Select(i => (i is Book) ? ((Book)i).Pages:1))
            //{
            //    Console.WriteLine(item);
            //}
            //11.Отримати словник з ключем - автор книги, значенням - список авторських книг
            //Dictionary<string, List<Book>> dict = data.OfType<Book>().Cast<Book>().GroupBy(x => x.Author, )
            //12.Вивести всі фільми "Метт Деймон", за винятком фільмів з акторами, імена яких представлені в даних у вигляді рядків

        }
    }
}
