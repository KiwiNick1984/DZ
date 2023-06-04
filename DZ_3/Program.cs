using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_3
{
    class Card
    {
        private int _valueCard;
        public int ValueCard
        {
            get { return _valueCard; }
            private set
            { 
                if ((value >= 1 && value <= 3) || (value >= 6 && value <= 11))
                    _valueCard = value;
                else
                    _valueCard = 1;
            }
        }

        private int _suitCard;
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
        public Card(int value, int suint)
        {
            ValueCard = value;
            SuitCard = suint;
        }

        public void PrintCard()
        {
            switch (_valueCard)
            {
                case 1:
                    Console.Write("J");
                    break;
                case 2:
                    Console.Write("Q");
                    break;
                case 3:
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
                    Console.WriteLine("\u2660");
                    break;
                case 2:     // трефы \u2663
                    Console.WriteLine("\u2663");
                    break;
                case 3:     // червы \u2665
                    Console.WriteLine("\u2665");
                    break;
                case 11:    // бубны \u2666
                    Console.WriteLine("\u2666");
                    break;
            }

        }
    }


    public enum SuitCard
    {
        Spades,     // пики \u2660
        Clubs,      // трефы \u2663
        Hearts,     // червы \u2665
        Diamonds,   // бубны \u2666
    }

    internal class Program
    {
        static void Main(string[] args)
        {
            Card card_1 = new Card(8, 2);
            card_1.PrintCard();
            //Console.WriteLine("\u2660");
        }
    }
}
