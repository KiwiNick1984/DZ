using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class Count
    {
        static int _countStaticNumber;      //Для автоматического приращения индекса
        public int _countNumber;            //Номер счета
        public Money _balance = new Money();//Баланс
        public double _bid;                 //Ставка
        public Client _client;              //Клиент

        public Count(double bid = 12.4)
        {
            _countNumber = ++_countStaticNumber;
            _bid = bid;
        }
        public void PutMoney(double summ)   //Положить деньги на счет
        {
            _balance += summ;
        }
        public void WithdrawMoney(double summ)  //Снять деньги со счета
        {
            _balance -= summ;
        }

    }
}
