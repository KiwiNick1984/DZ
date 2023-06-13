using RepkaStory;
using System;
using System.Collections.Generic;

namespace DZ_4
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            ///////////////////////////1_RepkaStory//////////////////////////////
            //List<Personage> personageList = new List<Personage>();
            //personageList.Add(new Ded());
            //personageList.Add(new Babka());
            //personageList.Add(new Vnychka());

            ////Дед садит репку с силой 15
            //Plant plant = ((Ded)personageList[0]).Plant(PlantsType.Repka, 17);
            ////Дед садит свеклу с силой 13
            ////Plant plant = ((Ded)personageList[0]).Plant(PlantsType.Beet, 13);
            //int pullPower = 0;
            //foreach (var pers in personageList)
            //{
            //    pullPower += pers.PersonagePower;
            //    if (pers.Pull(plant, pullPower))
            //        break;
            //}

            /////////////////////////////1_Bank//////////////////////////////
            //Bank bank = new Bank();
            ////Создать клиентов
            //bank.NewClient("Jack", "Sparrow");
            //bank.NewClient("Walter", "White");
            //bank.NewClient("John", " Wick");

            ////Создать счета
            //bank.NewCount();
            //bank.NewCount();
            //bank.NewCount();
            //bank.NewCount();
            //bank.NewCount();

            ////Привязать счета к клиентам
            //bank.CountToClient(2, 1);
            //bank.CountToClient(2, 2);
            //bank.CountToClient(3, 3);
            //bank.CountToClient(3, 4);
            //bank.CountToClient(3, 5);

            ////Изменить ставку
            //bank.ChangeBid(1, 13.8);
            //bank.ChangeBid(2, 10.8);

            ////Положить деньги на счета
            //bank.PutMoney(1, 1506.21);
            //bank.PutMoney(2, 545.80);
            //bank.PutMoney(3, 10.56);
            //bank.PutMoney(4, 425.35);

            ////Снять деньги со счета
            //bank.WithdrawMoney(1, 800.40);
            //bank.WithdrawMoney(4, 35.20);

            ////Перевод денег со счета на счет
            //bank.TransferMonu(1, 5, 350.40);

            //Console.WriteLine("***********Список клиентов***********");
            //bank.PrintClients();
            //Console.WriteLine("************Список счетов************");
            //bank.PrintCounts(); //Распечатать счетов

            ////История счета #1
            //bank.PringCountHistory(1);

            ///////////////////////////3_ListStruct//////////////////////////////
            //ListStruct listStruct = new ListStruct();
            //listStruct.Add(35);
            //listStruct.Add(3.5);
            //listStruct.Add(true);
            //listStruct.Add(1650);
            //listStruct.Print();

            //Console.WriteLine($"\n_listStruct.Insert(1, -300)");
            //listStruct.Insert(1, -300);
            //listStruct.Print();

            //Console.WriteLine($"\n_listStruct.Remove(-300)");
            //listStruct.Remove(-300);
            //listStruct.Print();

            //Console.WriteLine($"\n_listStruct.RemoveAt(2)");
            //listStruct.RemoveAt(2);
            //listStruct.Print();

            //Console.WriteLine($"\n_listStruct.Clear()");
            //listStruct.Clear();
            //listStruct.Add(35);
            //listStruct.Add(3.5);
            //listStruct.Add(true);
            //listStruct.Add(1650);
            //listStruct.Print();

            //Console.WriteLine($"\n_listStruct.Contains(3.5)");
            //Console.WriteLine(listStruct.Contains(3.5));
            //Console.WriteLine($"listStruct.Contains(30)");
            //Console.WriteLine(listStruct.Contains(30));

            //Console.WriteLine($"\n_listStruct.IndexOf(1650)");
            //Console.WriteLine(listStruct.IndexOf(1650));
            //Console.WriteLine($"listStruct.IndexOf(30)");
            //Console.WriteLine(listStruct.IndexOf(30));

            //Console.WriteLine($"\n_listStruct.Reverse()");
            //listStruct.Reverse();
            //listStruct.Print();

            ///////////////////////////3_OneWayList//////////////////////////////
            OneWayList oneWayList = new OneWayList();

        }
    }
}
