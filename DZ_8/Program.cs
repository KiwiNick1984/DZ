//List<int> list = new List<int> { 1, 2, 3 };

using DZ_8;
using System.Collections.Generic;

MyList myList = new MyList();
myList.Add("str");
myList.Add(52);
myList.Add(4.8);
myList.Add(true);
MyStack stack = new MyStack();
stack.Push(1);
stack.Push(2);
stack.Push(3);
Queue<int> queue = new Queue<int>();
LinkedList<int> list = new LinkedList<int>();
foreach (var item in stack)
{
    Console.WriteLine(item);
}

//Console.WriteLine(myList[2]);
Console.WriteLine("Hello, World!");
