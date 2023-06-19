//List<int> list = new List<int> { 1, 2, 3 };

using DZ_8;
using System.Collections.Generic;

//MyList myList = new MyList();
//myList.Add("str");
//myList.Add(52);
//myList.Add(4.8);
//myList.Add(true);
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


GetBike getBike = (string color) => new SportBike(color);
Bike MyBike = getBike("Green");
MyBike.GetColor();
Console.WriteLine();



public class Bike
{
    public string _color;
    public Bike(string color) => _color = color;
    public virtual void GetColor() => Console.WriteLine($"Color bike is {_color}");
}

public class SportBike : Bike
{
    public SportBike(string color) : base(color)
    { }
    public override void GetColor() => Console.WriteLine($"Color sportbike is {_color}");

}

delegate Bike GetBike(string color);