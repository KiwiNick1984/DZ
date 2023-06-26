using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DZ_5.Generic;

namespace DZ_5{

    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            LinkedList<int> l = new LinkedList<int>();
            IMyEnumerable filter;

            #region [  MyList  ]
            //////////////////////////MyList////////////////////////////
            Console.WriteLine("\t!!!---MyList---!!!");
            MyList<int> myList = new MyList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(30);
            myList.Add(4);
            myList.Add(500);
            myList.Add(6);
            myList.Add(16);
            myList.Add(19);
            myList.Add(9);
            myList.Add(10);
            myList.Add(11);
            myList.Add(12);
            foreach (var item in myList)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine($"\n\nmyList.Sort()");
            myList.Sort();
            foreach (var item in myList)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine($"\n\nmyList.BinarySearch(19) = {myList.BinarySearch(19)}");
            Console.WriteLine("\nmyList.MySkip(3).MyWhere(i => i < 10)");
            filter = myList.MySkip(3).MyWhere(i => i < 10);
            foreach (var item in filter)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("\n\nmyList.MySkipWhile(i => i < 5)");
            filter = myList.MySkipWhile(i => i < 5);
            foreach (var item in filter)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine($"\n\nmyList.MyFirst(i => i == 10) = {myList.MyFirst(i => i == 10)}");
            Console.WriteLine($"myList.MyFirstOrDefault(i => i > 100) = {myList.MyFirstOrDefault(i => i > 100)}");
            Console.WriteLine($"myList.MyLastOrDefault(i => i == 10) = {myList.MyLastOrDefault(i => i == 10)}");
            Console.WriteLine($"myList.All(x => (x > 0 && x < 20)) = {myList.All(x => (x > 0 && x < 20))}");
            Console.WriteLine($"myList.Any(x => (x == 10))) = {myList.Any(x => (x == 10))}");

            Console.WriteLine("\nToList()");
            list = myList.ToList();
            foreach (int item in list)
            {
                Console.Write(item + ", ");
            }

            filter = myList.Select(x => x.ToString());
            filter = from p in myList select p.ToString();
            //foreach (var item in filter)
            //{
            //    Console.WriteLine(item.GetType());
            //}

            MyList<MyList<int>> myListList = new MyList<MyList<int>>();
            MyList<int> myList_1 = new MyList<int>();
            myList_1.Add(1);
            myList_1.Add(2);
            myList_1.Add(5);
            myList_1.Add(3);
            myList_1.Add(4);
            MyList<int> myList_2 = new MyList<int>();
            myList_2.Add(10);
            myList_2.Add(20);
            myList_2.Add(30);
            myList_2.Add(40);
            myList_2.Add(50);
            MyList<int> myList_3 = new MyList<int>();
            myList_3.Add(100);
            myList_3.Add(200);
            myList_3.Add(300);
            myList_3.Add(400);
            myList_3.Add(500);
            myListList.Add(myList_1);
            myListList.Add(myList_2);
            myListList.Add(myList_3);

            var employees = myListList.SelectMany(c => c);
            Console.WriteLine("\n\n!!!Список списков!!!");
            Console.WriteLine("myListList.SelectMany(c => c)");
            foreach (var item in employees)
            {
                Console.Write(item + ", ");
            }
            //Ожидание "Enter"
            Console.WriteLine("\n\nMyList<Person>  -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region [  MyList<Person>  ]
            MyList<Person> people = new MyList<Person>();
            people.Add(new Person(25, "Stevie"));
            people.Add(new Person(31, "Joi"));
            people.Add(new Person(27, "Pamela"));
            people.Add(new Person(38, "Nick"));
            people.Sort();
            foreach (var item in people)
            {
                Console.WriteLine(item._age + " " + item._name);                
            }
            //Ожидание "Enter"
            Console.WriteLine("\n\nMyObservableCollection  -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region [  MyObservableCollection  ]

            MyObservableCollection<int> myObservableCollection = new MyObservableCollection<int>();
            void AddLog(string strlog) => Console.WriteLine(strlog);
            myObservableCollection.Add(1, AddLog);
            myObservableCollection.Add(2, AddLog);
            myObservableCollection.Add(3, AddLog);
            //Ожидание "Enter"
            Console.WriteLine("\n\nOneWayList  -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region [  OneWayList  ]
            //////////////////////////OneWayList////////////////////////////
            Console.WriteLine("\t!!!---OneWayList---!!!");
            OneWayList<int> oneWayList = new OneWayList<int>();
            oneWayList.Add(55);
            oneWayList.Add(52);
            oneWayList.Add(3);
            oneWayList.Add(6);
            oneWayList.Add(8);
            foreach (var item in oneWayList)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("\n\noneWayList.MySkip(3)");
            filter = oneWayList.MySkip(3);
            foreach (var item in filter)
            {
                Console.Write(item + ", ");
            }
            //Ожидание "Enter"
            Console.WriteLine("\n\nTowWaysList  -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region [  TowWaysList  ]
            ////////////////////////TowWaysList////////////////////////////
            Console.WriteLine("\t!!!---TowWaysList---!!!");
            TowWaysList<int> towWaysList = new TowWaysList<int>();
            towWaysList.Add(1);
            towWaysList.Add(2);
            towWaysList.Add(3);
            towWaysList.Add(4);
            towWaysList.Add(5);
            foreach (var item in towWaysList)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("\n\ntowWaysList.MySkip(3)");
            filter = towWaysList.MySkip(3);
            foreach (var item in filter)
            {
                Console.Write(item + ", ");
            }
            //Ожидание "Enter"
            Console.WriteLine("\n\nMyStack  -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region [  MyStack  ]
            //////////////////////////MyStack////////////////////////////
            Console.WriteLine("\t!!!---MyStack---!!!");
            MyStack<int> myStack = new MyStack<int>();
            myStack.Push(1);
            myStack.Push(2);
            myStack.Push(3);
            myStack.Push(4);
            myStack.Push(5);
            foreach (var item in myStack)
            {
                Console.Write(item + ", ");
            }
            Console.WriteLine("\n\nmyStack.MySkip(3)");
            filter = myStack.MySkip(3);
            foreach (var item in filter)
            {
                Console.Write(item + ", ");
            }
            //Ожидание "Enter"
            Console.WriteLine("\n\nMyQueue  -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region [  MyQueue  ]
            //////////////////////////MyQueue////////////////////////////
            Console.WriteLine("\t!!!---MyQueue---!!!");
            MyQueue<int> myQueue = new MyQueue<int>();
            myQueue.Enqueue(1);
            myQueue.Enqueue(2);
            myQueue.Enqueue(3);
            myQueue.Enqueue(4);
            myQueue.Enqueue(5);
            foreach (var item in myQueue)
            {
                Console.Write(item + ", ");
            }
            filter = myQueue.MySkip(3);
            foreach (var item in filter)
            {
                Console.Write(item + ", ");
            }
            //Ожидание "Enter"
            Console.WriteLine("\n\nMyTree  -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();
            #endregion

            #region [  3_MyTree  ]
            /////////////////////////////3_MyTree//////////////////////////////
            Console.WriteLine("\t!!!---MyTree---!!!");
            MyTree<int> tree = new MyTree<int>();
            tree.Add(100);
            tree.Add(50);
            tree.Add(40);
            tree.Add(60);
            tree.Add(140);
            tree.Add(135);
            tree.Add(145);
            tree.Add(160);

            Console.WriteLine("\ntree.Contains(160)");
            Console.WriteLine(tree.Contains(160));
            Console.WriteLine("tree.Contains(55)");
            Console.WriteLine(tree.Contains(55));
            Console.WriteLine();

            int[] arr = tree.ToArray();
            foreach (int item in arr)
            { 
                Console.Write(item + ", "); 
            }
            Console.WriteLine();
            #endregion
        }
    }

    internal class Person : IComparable<Person>
    {
        public int _age;
        public string _name;

        public Person(int age, string name) 
        {
            _age = age;
            _name = name;
        }

        public int CompareTo(Person other)
        {
            if (other == null) 
                return -1;
            return _age.CompareTo(other._age);
        }
    }
}
