using DZ_8;
using System.Collections.Generic;

//MyList myList = new MyList();
//myList.Add("str");
//myList.Add(52);
//myList.Add(4.8);
//myList.Add(true);
//myList.Add("str");
//myList.Add(52);
//myList.Add(4.8);
//myList.Add(true);

OneWayList oneWayList = new OneWayList();
oneWayList.AddLast("str");
oneWayList.AddLast(52);
oneWayList.AddLast(4.8);
oneWayList.AddLast(true);
oneWayList.AddLast("str");
oneWayList.AddLast(52);
oneWayList.AddLast(4.8);
oneWayList.AddLast(true);

//foreach (var item in oneWayList)
//{
//    Console.WriteLine(item);
//}

TowWaysList towWaysList = new TowWaysList();
towWaysList.Add("str");
towWaysList.Add(52);
towWaysList.Add(4.8);
towWaysList.Add(true);
towWaysList.Add("str");
towWaysList.Add(52);
towWaysList.Add(4.8);
towWaysList.Add(true);
towWaysList.Clear();
foreach (var item in towWaysList)
{
    Console.WriteLine(item);
}



//MyStack stack = new MyStack();


//stack.Push(1);
//stack.Push(2);
//stack.Push(3);
//foreach (var item in stack)
//{
//    Console.WriteLine(item);
//}

////Console.WriteLine(myList[2]);
//Console.WriteLine("Hello, World!");