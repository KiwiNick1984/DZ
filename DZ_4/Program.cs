using RepkaStory;
using System;
using System.Collections.Generic;

namespace DZ_4
{
    internal class Program
    {
        static void Main(string[] args)
        {
            /////////////////////////1_RepkaStory//////////////////////////////
            List<Personage> personageList = new List<Personage>();
            personageList.Add(new Ded());
            personageList.Add(new Babka());
            personageList.Add(new Vnychka());

            //Дед садит репку с силой 15
            Plant plant = ((Ded)personageList[0]).Plant(PlantsType.Repka, 17);
            //Дед садит свеклу с силой 13
            //Plant plant = ((Ded)personageList[0]).Plant(PlantsType.Beet, 13);
            int pullPower = 0;
            foreach (var pers in personageList)
            {
                pullPower += pers.PersonagePower;
                if (pers.Pull(plant, pullPower))
                    break;
            }
            //Ожидание "Enter"
            Console.WriteLine("\n2_Bank -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();

            ///////////////////////////2_Bank//////////////////////////////
            Bank bank = new Bank();
            //Создать клиентов
            bank.NewClient("Jack", "Sparrow");
            bank.NewClient("Walter", "White");
            bank.NewClient("John", " Wick");

            //Создать счета
            bank.NewCount();
            bank.NewCount();
            bank.NewCount();
            bank.NewCount();
            bank.NewCount();

            //Привязать счета к клиентам
            bank.CountToClient(2, 1);
            bank.CountToClient(2, 2);
            bank.CountToClient(3, 3);
            bank.CountToClient(3, 4);
            bank.CountToClient(3, 5);

            //Изменить ставку
            bank.ChangeBid(1, 13.8);
            bank.ChangeBid(2, 10.8);

            //Положить деньги на счета
            bank.PutMoney(1, 1506.21);
            bank.PutMoney(2, 545.80);
            bank.PutMoney(3, 10.56);
            bank.PutMoney(4, 425.35);

            //Снять деньги со счета
            bank.WithdrawMoney(1, 800.40);
            bank.WithdrawMoney(4, 35.20);

            //Перевод денег со счета на счет
            bank.TransferMonu(1, 5, 350.40);

            Console.WriteLine("***********Список клиентов***********");
            bank.PrintClients();
            Console.WriteLine("************Список счетов************");
            bank.PrintCounts(); //Распечатать счетов

            //История счета #1
            bank.PringCountHistory(1);

            //Ожидание "Enter"
            Console.WriteLine("\n3_ListStruct -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();

            /////////////////////////3_ListStruct//////////////////////////////
            ListStruct listStruct = new ListStruct();
            listStruct.Add(35);
            listStruct.Add(3.5);
            listStruct.Add(true);
            listStruct.Add(1650);
            listStruct.Print();

            Console.WriteLine($"\n_listStruct.Insert(1, -300)");
            listStruct.Insert(1, -300);
            listStruct.Print();

            Console.WriteLine($"\n_listStruct.Remove(-300)");
            listStruct.Remove(-300);
            listStruct.Print();

            Console.WriteLine($"\n_listStruct.RemoveAt(2)");
            listStruct.RemoveAt(2);
            listStruct.Print();

            Console.WriteLine($"\n_listStruct.Clear()");
            listStruct.Clear();
            listStruct.Add(35);
            listStruct.Add(3.5);
            listStruct.Add(true);
            listStruct.Add(1650);
            listStruct.Print();

            Console.WriteLine($"\n_listStruct.Contains(3.5)");
            Console.WriteLine(listStruct.Contains(3.5));
            Console.WriteLine($"listStruct.Contains(30)");
            Console.WriteLine(listStruct.Contains(30));

            Console.WriteLine($"\n_listStruct.IndexOf(1650)");
            Console.WriteLine(listStruct.IndexOf(1650));
            Console.WriteLine($"listStruct.IndexOf(30)");
            Console.WriteLine(listStruct.IndexOf(30));

            Console.WriteLine($"\n_listStruct.Reverse()");
            listStruct.Reverse();
            listStruct.Print();

            //Ожидание "Enter"
            Console.WriteLine("\n3_OneWayList -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();

            ///////////////////////////3_OneWayList//////////////////////////////
            Console.Clear();
            Console.WriteLine("Односвязный список");
            OneWayList oneWayList = new OneWayList();
            oneWayList.Add(35);
            oneWayList.Add(3.5);
            oneWayList.Add(true);
            oneWayList.Add(1650);
            oneWayList.Print();

            Console.WriteLine($"\noneWayList.AddFirst(\"string!\");");
            oneWayList.AddFirst("string!");
            oneWayList.Print();

            Console.WriteLine($"\noneWayList.Insert(1, false)");
            oneWayList.Insert(1, false);
            oneWayList.Print();

            Console.WriteLine($"\noneWayList.Clear()");
            oneWayList.Clear();

            Console.WriteLine();
            oneWayList.Add(35);
            oneWayList.Add(3.5);
            oneWayList.Add(false);
            oneWayList.Add(1650);
            oneWayList.Print();

            Console.WriteLine($"\noneWayList.Contains(1650)");
            Console.WriteLine(oneWayList.Contains(1650));
            Console.WriteLine($"oneWayList.Contains(true)");
            Console.WriteLine(oneWayList.Contains(true));

            Console.WriteLine("\noneWayList.ToArray()");
            object[] objArr = oneWayList.ToArray();
            foreach (var item in objArr)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\noneWayList.Count");
            Console.WriteLine(oneWayList.Count);

            //Ожидание "Enter"
            Console.WriteLine("\n3_TwoWaysList -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();

            /////////////////////////////3_TwoWaysList//////////////////////////////
            Console.Clear();
            Console.WriteLine("Двусвязный список");
            TwoWaysList twoWaysList = new TwoWaysList();
            twoWaysList.AddLast(35);
            twoWaysList.AddLast(3.5);
            twoWaysList.AddLast(true);
            twoWaysList.AddLast(1650);
            twoWaysList.Print();

            Console.WriteLine($"\ntwoWaysList.AddFirst(\"string!\");");
            twoWaysList.AddFirst("string!");
            twoWaysList.Print();

            Console.WriteLine($"\ntwoWaysList.RemoveFirst();");
            twoWaysList.RemoveFirst();
            twoWaysList.Print();

            Console.WriteLine($"\ntwoWaysList.RemoveLast();");
            twoWaysList.RemoveLast();
            twoWaysList.Print();

            Console.WriteLine($"\ntwoWaysList.Contains(1650)");
            Console.WriteLine(twoWaysList.Contains(1650));
            Console.WriteLine($"twoWaysList.Contains(true)");
            Console.WriteLine(twoWaysList.Contains(true));

            Console.WriteLine("\ntwoWaysList.ToArray()");
            object[] objArr2 = twoWaysList.ToArray();
            foreach (var item in objArr2)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\ntwoWaysList.Clear()");
            twoWaysList.Clear();

            //Ожидание "Enter"
            Console.WriteLine("\n3_MyQueue -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();

            /////////////////////////////3_MyQueue//////////////////////////////
            Console.Clear();
            Console.WriteLine("Очередь");
            MyQueue queue = new MyQueue();
            queue.Enqueue(35);
            queue.Enqueue(3.5);
            queue.Enqueue(true);
            queue.Enqueue(1650);
            queue.Print();

            Console.WriteLine($"\nqueue.Dequeue()");
            Console.WriteLine(queue.Dequeue());

            Console.WriteLine($"queue.Contains(1650)");
            Console.WriteLine(queue.Contains(1650));
            Console.WriteLine($"queue.Contains(30)");
            Console.WriteLine(queue.Contains(30));

            Console.WriteLine();
            queue.Print();
            Console.WriteLine($"queue.Peek()");
            Console.WriteLine(queue.Peek());

            Console.WriteLine("\nqueue.ToArray()");
            object[] objArr3 = queue.ToArray();
            foreach (var item in objArr3)
            {
                Console.WriteLine(item);
            }

            Console.WriteLine($"\nqueue.Clear()");
            queue.Clear();

            //Ожидание "Enter"
            Console.WriteLine("\n3_MyTree -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();

            ///////////////////////////////3_MyTree//////////////////////////////
            MyTree tree = new MyTree();
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
            foreach(int item in arr)
            { Console.WriteLine(item); }
        }
    }
}
