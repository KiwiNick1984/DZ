using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class Bank
    {
        List<Client> _clients = new List<Client>(); //Список клиентов
        List<Count> _counts = new List<Count>();    //Список счетов
        List<HistoryLine> _history = new List<HistoryLine>();

        public void NewClient(string firstName, string lastName) //Добавить клиента
        {
            _clients.Add(new Client(firstName, lastName));
        }
        public void PrintClients() //Список клиентов на єкран
        {
            foreach (Client client in _clients) 
            {
                Console.WriteLine("ID: " + client._clientID +". "+ client._firstName + " " + client._lastName);
                client.GetBalance();
                Console.WriteLine();
            }
        }

        public void NewCount() //Добавить счет
        {
            _counts.Add(new Count());
            _history.Add(new HistoryLine(DateTime.Now, Operation.Create, 0.0, _counts.Last()._countNumber));
        }
        public void PrintCounts() //Список счетов на экран
        { 
            foreach (Count count in _counts)
            {
                Console.WriteLine("Номер счета: " + count._countNumber);
                count._balance.Print();
                Console.WriteLine("Ставка: " + count._bid);
                Console.WriteLine("Владелец: " + count._client._firstName + " " + count._client._lastName);
                Console.WriteLine();
            }
            
        }

        public bool CountToClient(int clientID, int countNumber) //Привязать счет к клиенту
        {
            Client client = GetClient(clientID);
            Count count = GetCount(countNumber);
            if(client == null)
                return false;
            if(!client.NewCount(count))
                return false;
            count._client = client;
            _history.Add(new HistoryLine(DateTime.Now, Operation.AddToClient, 0.0, countNumber, clientID));
            return true;
        }

        public void PutMoney(int countNumber, double summ) //Положить деньги на счет
        {
            GetCount(countNumber)?.PutMoney(summ);
            _history.Add(new HistoryLine(DateTime.Now, Operation.Put, summ, countNumber));
        }
        public bool WithdrawMoney(int countNumber, double summ) //Снять деньги со счета
        {
            if(GetCount(countNumber)._balance >= summ)
            {
                GetCount(countNumber)?.WithdrawMoney(summ);
                _history.Add(new HistoryLine(DateTime.Now, Operation.Withdraw, summ, countNumber));
                return true;
            }
            return false;
        }
        public void TransferMonu(int sourseCountNumber, int destinationCountNumber, double summ) //Перевод со счета на счет
        {            
            if(GetCount(sourseCountNumber)._balance >= summ)
            {
                GetCount(sourseCountNumber)._balance -= summ;
                GetCount(destinationCountNumber)._balance += summ;
                _history.Add(new HistoryLine(DateTime.Now, Operation.Transfer, summ, sourseCountNumber, destinationCountNumber));
            }
        }
        public void ChangeBid(int countNumber, double bid) //Изменить ставку
        {
            GetCount(countNumber)._bid = bid;
            _history.Add(new HistoryLine(DateTime.Now, Operation.ChangeBid, bid, countNumber));
        }

        public void PringCountHistory(int countNumber) //История счета на экран
        {
            Console.WriteLine("Логи счета #"+ countNumber);
            foreach (var line in _history)
            {
                if(line._sourseCountNumber == countNumber || line._destinationCountNumber == countNumber)
                {
                    Console.Write(line._dateTime + ": ");
                    switch (line._operation)
                    {
                        case Operation.Create:                            
                            Console.WriteLine("Создан.");
                            break;
                        case Operation.AddToClient:
                            Console.WriteLine("Привязан к киенту " + GetClient(line._destinationCountNumber)._lastName);
                            break;
                        case Operation.Put:
                            Console.WriteLine("Пополнен на " + line._summ + "грн.");
                            break;
                        case Operation.Withdraw:
                            Console.WriteLine("Снято со счета " + line._summ + "грн.");
                            break;
                        case Operation.Transfer:
                            if (line._sourseCountNumber == countNumber) {
                                Console.WriteLine(line._summ + " грн. переведены на счет #" + line._destinationCountNumber);
                            } else {
                                Console.WriteLine(line._summ + " грн. поступили со счет #" + line._sourseCountNumber);
                            }
                            break;
                        case Operation.ChangeBid:
                            Console.WriteLine("Ставка теперь составляет " + line._summ + "%");
                            break;
                        default:
                            break;
                    }
                }
            }
        }

        private Count GetCount(int countNumber) //Поиск счета по номеру
        {
            foreach (var count in _counts)
            {
                if (count._countNumber == countNumber)
                {
                    return count;
                }
            }
            return null;
        }
        private Client GetClient(int clientID) //Поиск клиента по ID
        {
            foreach (var client in _clients)
            {
                if (client._clientID == clientID)
                {
                    return client;
                }
            }
            return null;
        }
    }

    enum Operation
    {
        Create,     //
        AddToClient,//
        Put,        //
        Withdraw,   //
        Transfer,   //
        ChangeBid   //
    }
    struct HistoryLine
    {
        public DateTime _dateTime;
        public Operation _operation;
        public double _summ;
        public int _sourseCountNumber;
        public int _destinationCountNumber;


        public HistoryLine(DateTime dateTime, Operation operation, double summ, int sourseCountNumber, int _destinationCountNumber = 0)
        {
            this._dateTime = dateTime;
            this._operation = operation;
            this._summ = summ;
            this._sourseCountNumber = sourseCountNumber;
            this._destinationCountNumber = _destinationCountNumber;
        }
    }
}
