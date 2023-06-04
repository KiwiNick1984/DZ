using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_3
{
    class Card
    {
        static Card _lastCard = new Card();
        ///////////////////////Поля///////////////////////
        private int _valueCard;     //Достоинство карты
        public int ValueCard
        {
            get { return _valueCard; }
            private set
            { 
                if ((value >= 2 && value <= 4) || (value >= 6 && value <= 11))
                    _valueCard = value;
                else
                    _valueCard = 6;
            }
        }

        private int _suitCard;      //Масть карты
        public int SuitCard
        {
            get { return _suitCard; }
            private set 
            {
                if (value < 1)
                    _suitCard = 1;
                else if (value > 4)
                    _suitCard = 4;
                else
                    _suitCard = value;
            }
        }
        ///////////////////////Конструкторы///////////////////////
        private Card()
        {
            _valueCard = 0;
            _suitCard = 0;
        }
        public Card(int value, int suint)
        {
            ValueCard = value;
            SuitCard = suint;
            //запомнить последнюю созданную карту (для метода Next)
            _lastCard._valueCard = value;
            _lastCard._suitCard = suint;
        }
        ///////////////////////Методы///////////////////////
        public void PrintCard()             //Вывод карты на экран
        {
            switch (_valueCard)
            {
                case 2:
                    Console.Write("J");
                    break;
                case 3:
                    Console.Write("Q");
                    break;
                case 4:
                    Console.Write("K");
                    break;
                case 11:
                    Console.Write("T");
                    break;
                case 6:
                    Console.Write(_valueCard);
                    break;
                case 7:
                    Console.Write(_valueCard);
                    break;
                case 8:
                    Console.Write(_valueCard);
                    break;
                case 9:
                    Console.Write(_valueCard);
                    break;
                case 10:
                    Console.Write(_valueCard);
                    break;
            }
            switch (_suitCard)
            {   
                case 1:     // пики \u2660
                    Console.Write("\u2660");
                    break;
                case 2:     // трефы \u2663
                    Console.Write("\u2663");
                    break;
                case 3:     // червы \u2665
                    Console.Write("\u2665");
                    break;
                case 4:    // бубны \u2666
                    Console.Write("\u2666");
                    break;
            }

        }
        static public void ResetLastCard()  //Сбросить предыдущую карту
        {
            _lastCard._valueCard = 0;
            _lastCard._suitCard = 0;
        }
        static public Card NextCard()       //Выдать следующую по порядку карту
        {
            if (_lastCard._valueCard == 0)
                return new Card(6, 1);
            else if((_lastCard._valueCard >=6 && _lastCard._valueCard < 10) || (_lastCard._valueCard >= 2 && _lastCard._valueCard <= 3))
                return new Card(_lastCard._valueCard+1, _lastCard._suitCard);
            else if (_lastCard._valueCard == 10)
                return new Card(2, _lastCard._suitCard);
            else if (_lastCard._valueCard == 4)
                return new Card(11, _lastCard._suitCard);
            else if (_lastCard._valueCard == 11 && _lastCard._suitCard < 4)
                return new Card(6, _lastCard._suitCard+1);
            else
            {
                _lastCard._valueCard = 0;
                _lastCard._suitCard = 0;
                return null;
            }
            
        }
    }

    class Deck
    {
        private Card[] _deck = new Card[36];
        private Card[] _shakeDeck = new Card[36];
        private int _playedCardsNumber;

        public Deck()
        {
            _playedCardsNumber = 0;
            Card.ResetLastCard(); //для начала работы метода NextCard (обнулить предыдущую карту)
            for (int i = 0; i < 36; i++)
            {
                _deck[i] = Card.NextCard();
            }
        }

        public void PrintDeck() //Вывод колоды на экран
        {
            for (int i = 0; i < 36; i++)
            {
                _deck[i].PrintCard();
                if ((i + 1) % 9 == 0)
                    Console.WriteLine();
                else
                    Console.Write(", ");
            }
        }
        public void Shake()     //Перемешать колоду
        {
            Random random = new Random();
            int i;
            foreach (var item in _deck)
            {
                while (true) {
                    i = random.Next(0, 36);
                    if (_shakeDeck[i] == null)
                    {
                        _shakeDeck[i] = item;
                        break;
                    }
                }
            }
            for (int j = 0; j < _deck.Length; j++)
            {
                _deck[j] = _shakeDeck[j];
            }
        }
        public void PrintAcePosition()  //Вывод позиции тузов в колоде на экран
        {
            int i = 0;
            for (int j = 0; j < _deck.Length; j++)
            {
                if(_deck[j].ValueCard == 11)
                {
                    if(i<4)
                        Console.Write((j+1) + ", ");
                    else
                    {
                        Console.Write(j+1);
                        break;
                    }
                    i++;
                }
            }
        }
        public void SpadesToStart()     //Пики в начало колоды
        {
            Card tempCard;
            int cardPosition = 0;
            for (int i = 0; i < _deck.Length; i++)
            {
                if (_deck[i].SuitCard == 1)
                {
                    tempCard = _deck[i];
                    _deck[i] = _deck[cardPosition];
                    _deck[cardPosition] = tempCard;
                    cardPosition++;
                }
            }
        }
        public void Sort()              //Сортировка
        {
            Card tempCard;
            int i;
            for (int j = 1; j < _deck.Length; j++)
            {
                tempCard = _deck[j];
                i = j - 1;
                while (i>=0 && ((_deck[i].ValueCard > tempCard.ValueCard && _deck[i].SuitCard == tempCard.SuitCard) || (_deck[i].SuitCard > tempCard.SuitCard)))
                {
                    _deck[i + 1] = _deck[i];
                    i = i - 1;
                }
                _deck[i+1] = tempCard;
            }
        }

        public Card GiveCard()
        {
            return _deck[_playedCardsNumber++];
        }
    }

    class TheGame
    {
        private Deck _deck = new Deck();                    //Колода
        private bool _whoIsFirst;                           //Флаг кто первый FALSE - бот, TRUE - игрок
        private List<Card> _playerHand = new List<Card>();  //рука игрока
        private List<Card> _botHand = new List<Card>();     //рука бота
        private int _playerPoints;                          //Очки игрока
        private int _botPoints;                             //Очки бота

        public TheGame()
        {
            _deck.Shake();
            _playerPoints = 0;
            _botPoints = 0;
            Console.WriteLine("Кто первый?");
            Console.WriteLine("1 - бот");
            Console.WriteLine("2 - игрок");
            Console.Write("- >");
            _whoIsFirst = Convert.ToInt32(Console.ReadLine()) == 2;
            GivePlayerCard();
            GivePlayerCard();
            GiveBotCard();
            GiveBotCard();
            PrintPlayerHand();
            PrintBotHand();
        }

        public void PrintPoins()
        {
            Console.WriteLine($"Игрок - {_playerPoints}");
            Console.WriteLine($"Бот - {_botPoints}");
        }
        private void GivePlayerCard()
        {
            _playerHand.Add(_deck.GiveCard());
            _playerPoints += _playerHand.Last().ValueCard ;
        }
        private void GiveBotCard()
        {
            _botHand.Add(_deck.GiveCard());
            _botPoints += _botHand.Last().ValueCard;
        }

        private void PrintPlayerHand()
        {
            Console.Write("Игрок -> ");
            foreach (var item in _playerHand)
            {
                item.PrintCard();
                Console.Write(" ");
            }
            Console.WriteLine();
        }
        private void PrintBotHand()
        {
            Console.Write("Бот -> ");
            foreach (var item in _botHand)
            {
                item.PrintCard();
                Console.Write(" ");
            }
            Console.WriteLine();
        }

        public void Game()
        { 

        }
    }
    //public enum SuitCard
    //{
    //    Spades,     // пики \u2660
    //    Clubs,      // трефы \u2663
    //    Hearts,     // червы \u2665
    //    Diamonds,   // бубны \u2666
    //}

    internal class Program
    {
        static void Main(string[] args)
        {
            Console.OutputEncoding = Encoding.Unicode;
            Console.WriteLine("Згенерувати впорядковану колоду карт");
            Deck deck_1 = new Deck();
            deck_1.PrintDeck();
            Console.WriteLine("Перемішати колоду карт");
            deck_1.Shake();
            deck_1.PrintDeck();
            Console.WriteLine("Знайти позиції всіх тузів у колоді");
            deck_1.PrintAcePosition();
            Console.WriteLine("\nПеремістити всі пікові карти на початок колоди");
            deck_1.SpadesToStart();
            deck_1.PrintDeck();
            Console.WriteLine("Відсортувати колоду (по очкам)");
            deck_1.Sort();
            deck_1.PrintDeck();
            //Ожидание "Enter"
            Console.WriteLine("\nПерейти к игре -> \"Enter\"...");
            Console.ReadLine();
            Console.Clear();

            //Игра 21
            TheGame theGame = new TheGame();
        }
    }
}
