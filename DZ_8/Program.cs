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
oneWayList.Add("str");
oneWayList.Add(52);
oneWayList.Add(4.8);
oneWayList.Add(true);
oneWayList.AddFirst("AddFirst");
oneWayList.Insert(2, 300);
Console.WriteLine(oneWayList.Contains(52));
Console.WriteLine();
foreach (var item in oneWayList)
{
    Console.WriteLine(item);
}


//TowWaysList towWaysList = new TowWaysList();
//towWaysList.Add("str");
//towWaysList.Add(52);
//towWaysList.Add(4.8);
//towWaysList.Add(true);
//towWaysList.AddFirst("AddFirst");
//towWaysList.Insert(2, 300);
//Console.WriteLine(towWaysList.Contains(4.9));
//Console.WriteLine();
//foreach (var item in towWaysList)
//{
//    Console.WriteLine(item);
//}



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