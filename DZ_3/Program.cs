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

        public Deck()
        {
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
                if((i+1) % 9 == 0)
                    Console.WriteLine();
                else
                    Console.Write(", ");
            }
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
            //Card card_1 = new Card(8, 2);
            //card_1.PrintCard();
            Deck deck_1 = new Deck();
            deck_1.PrintDeck();
        }
    }
}
