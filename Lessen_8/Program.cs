using DataStructures;
using System.Collections;
using System.Linq;

var list = new DataStructures.List();

var filtered = list.Skip(3);
//    .FilterAlt(o => ((string)o).EndsWith("C"));
//.Filter(o => ((string)o).StartsWith("A"))
//;

list.Add("AB");
list.Add("B");
list.Add("AC");
list.Add("C");
list.Add("AC");
list.Add("D");
list.Add("W");

//var list2 = new List<string>();
//list2.Skip(2).Take(3);

list.Add("AC");
list.Add("AC");
//var iter = list.GetEnumerator();
//while (iter.MoveNext())
//{
//    Console.WriteLine(iter.Current);
//}

//var resultList = new List();

foreach (var item in filtered)
{
    Console.WriteLine(item);
}

//for (int i = 0; i < list.Count; i++)
//{
//    Console.WriteLine(list[i]);
//}
