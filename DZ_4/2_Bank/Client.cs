using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class Client
    {
        static int _clientStaticID;     //Для автоматического приращения индекса
        public int _clientID;           //ID клиента
        public string _firstName;       //Имя
        public string _lastName;        //Фамилия
        public List<Count> _counts = new List<Count>();//Список счетов

        public Client(string firstName, string lastName)
        {
            _clientID = ++_clientStaticID;
            _firstName = firstName;
            _lastName = lastName;
        }
        public bool NewCount(Count count) //Добавить счет
        {
            if (count != null)
            {
                _counts.Add(count);
                return true;
            }
            return false;
        }
        public void GetBalance() //Получить баланс
        {
            if (_counts.Count > 0)
            {
                foreach (var count in _counts)
                {
                    Console.Write("Номер счета: " + count._countNumber + ". Баланс: ");
                    count._balance.Print();
                }
            } else {
                Console.WriteLine("У клиента нет счета!");
            }

        }
    }
}
