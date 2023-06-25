using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using DZ_8.Generic;

namespace DZ_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<int> list = new List<int>();
            //////////////////////////MyList////////////////////////////
            MyList<int> myList = new MyList<int>();
            myList.Add(1);
            myList.Add(2);
            myList.Add(3);
            myList.Add(4);
            myList.Add(5);
            myList.Add(6);
            myList.Add(10);
            myList.Add(10);
            myList.Add(9);
            myList.Add(10);
            myList.Add(11);
            myList.Add(12);

            IMyEnumerable filter;
            //var filter = myList.MySkip(3).MyWhere(i => i < 10);
            //foreach (var item in filter)
            //{
            //    Console.WriteLine(item);
            //}
            //filter = myList.MySkipWhile(i => i < 5);
            //foreach (var item in filter)
            //{
            //    Console.WriteLine(item);
            //}
            //Console.WriteLine(myList.MyFirst(i => i > 100));
            //Console.WriteLine(myList.MyFirstOrDefault(i => i > 5));
            //Console.WriteLine(myList.MyLastOrDefault(i => i == 10));
            //filter = myList.Select(x => x.ToString());
            //filter = from p in myList select p.ToString();
            //foreach (var item in filter)
            //{
            //    Console.WriteLine(item.GetType());
            //}            
            //MyList<MyList<int>> myListList = new MyList<MyList<int>>();
            //MyList<int> myList_1 = new MyList<int>();
            //myList_1.Add(1);
            //myList_1.Add(2);
            //myList_1.Add(5);
            //myList_1.Add(3);
            //myList_1.Add(4);
            //MyList<int> myList_2 = new MyList<int>();
            //myList_2.Add(10);
            //myList_2.Add(20);
            //myList_2.Add(30);
            //myList_2.Add(40);
            //myList_2.Add(50);
            //MyList<int> myList_3 = new MyList<int>();
            //myList_3.Add(100);
            //myList_3.Add(200);
            //myList_3.Add(300);
            //myList_3.Add(400);
            //myList_3.Add(500);
            //myListList.Add(myList_1);
            //myListList.Add(myList_2);
            //myListList.Add(myList_3);
            //var employees = myListList.SelectMany(c => c);
            //foreach (var item in employees)
            //{
            //    Console.WriteLine(item.GetType());
            //}
            //Console.WriteLine(myList.All(x => (x > 0 && x < 20)));
            //Console.WriteLine(myList.Any(x => (x == 100)));
            //list = myList.ToList();
            //foreach (int item in list)
            //{
            //    Console.WriteLine(item);
            //}



            //myList.Add(true);
            ////////////////////////////OneWayList////////////////////////////
            //OneWayList<int> oneWayList = new OneWayList<int>();
            //oneWayList.Add(55);
            //oneWayList.Add(52);
            //oneWayList.Add(3);
            //oneWayList.Add(6);
            //oneWayList.Add(8);
            //foreach (var item in oneWayList)
            //{
            //    Console.WriteLine(item);
            //}
            //filter = oneWayList.MySkip(3);
            //Console.WriteLine();
            //foreach (var item in filter)
            //{
            //    Console.WriteLine(item);
            //}
            //////////////////////////TowWaysList////////////////////////////
            //Stack<int> stack = new Stack<int>();
            //TowWaysList<int> towWaysList = new TowWaysList<int>();
            //towWaysList.Add(1);
            //towWaysList.Add(2);
            //towWaysList.Add(3);
            //towWaysList.Add(4);
            //towWaysList.Add(5);
            //foreach (var item in towWaysList)
            //{
            //    Console.WriteLine(item);
            //}
            //filter = towWaysList.MySkip(3);
            //Console.WriteLine();
            //foreach (var item in filter)
            //{
            //    Console.WriteLine(item);
            //}
            ////////////////////////////MyStack////////////////////////////
            //MyStack<int> myStack = new MyStack<int>();
            //myStack.Push(1);
            //myStack.Push(2);
            //myStack.Push(3);
            //myStack.Push(4);
            //myStack.Push(5);
            //filter = myStack.MySkip(3);
            //foreach (var item in filter)
            //{
            //    Console.WriteLine(item);
            //}
            ////////////////////////////MyQueue////////////////////////////
            //MyQueue<int> myQueue = new MyQueue<int>();
            //myQueue.Enqueue(1);
            //myQueue.Enqueue(2);
            //myQueue.Enqueue(3);
            //myQueue.Enqueue(4);
            //myQueue.Enqueue(5);
            //filter = myQueue.MySkip(3);
            //foreach (var item in filter)
            //{
            //    Console.WriteLine(item);
            //}
            ///////////////////////////////3_MyTree//////////////////////////////
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

            int[] arr = tree.ToArray();
            foreach (int item in arr)
            { Console.WriteLine(item); }
        }
    }
}
