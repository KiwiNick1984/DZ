using System;

namespace DZ_4
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            //Ded ded = new Ded(50); //сила деда = 30, 50 - сила растения
            //ded.DedPull();

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

            Console.WriteLine("История счета #1");
            bank.PringCountHistory(1);


        }
    }
}
