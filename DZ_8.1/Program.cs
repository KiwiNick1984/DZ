﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DZ_8.Generic;

namespace DZ_8
{
    internal class Program
    {
        static void Main(string[] args)
        {
            List<string> list = new List<string>();
            //////////////////////////MyList////////////////////////////
            
            MyList<int> myList = new MyList<int>();
            myList.Add(53);
            myList.Add(52);
            myList.Add(90);
            myList.Add(12);
            myList.Add(120);
            myList.Add(520);
            myList.Add(300);

            var filter = myList.MyLast();

            foreach (var item in filter)
            {
                Console.WriteLine(item);
            }
            //myList.Add(true);
            ////////////////////////////OneWayList////////////////////////////
            //OneWayList oneWayList = new OneWayList();
            //oneWayList.Add("str");
            //oneWayList.Add(52);
            //oneWayList.Add(4.8);
            //oneWayList.Add(true);
            //oneWayList.Add("Add");
            //var filter = oneWayList.MySkip(3);
            //foreach (var item in filter)
            //{
            //    Console.WriteLine(item);
            //}
            //////////////////////////TowWaysList////////////////////////////
            //TowWaysList towWaysList = new TowWaysList();
            //towWaysList.Add("str");
            //towWaysList.Add(52);
            //towWaysList.Add(4.8);
            //towWaysList.Add(true);
            //towWaysList.Add("Add");
            //var filter = towWaysList.MySkip(3);
            //foreach (var item in filter)
            //{
            //    Console.WriteLine(item);
            //}
            ////////////////////////////MyStack////////////////////////////
            //MyStack myStack = new MyStack();
            //myStack.Push(1);
            //myStack.Push(2);
            //myStack.Push(3);
            //myStack.Push(4);
            //var filter = myStack.MySkip(3);
            //foreach (var item in filter)
            //{
            //    Console.WriteLine(item);
            //}
            ////////////////////////////MyQueue////////////////////////////
            //MyQueue myQueue = new MyQueue();
            //myQueue.Enqueue(1);
            //myQueue.Enqueue(2);
            //myQueue.Enqueue(3);
            //myQueue.Enqueue(4);
            //var filter = myQueue.MySkip(3);
            //foreach (var item in filter)
            //{
            //    Console.WriteLine(item);
            //}
        }
    }
}
