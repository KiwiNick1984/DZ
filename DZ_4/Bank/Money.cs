using System;

using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class Money
    {
        int _hrn;   //Гривни
        int _kop;   //Копейки
        public Money(int hrn = 0, int cop = 0)
        { 
            _hrn = hrn;
            _kop = cop;
        }
        public void Print() //Баланс на экран
        {
            Console.WriteLine(_hrn + "грн. " + _kop + "коп.");
        }

        public static Money operator +(Money money, double summVal)
        {
            double balsnse = (double)money._hrn;
            balsnse += (double)(money._kop / 100.0);
            balsnse += Math.Round(summVal, 2);

            money._hrn = (int)Math.Truncate(balsnse);
            money._kop = (int)((balsnse-money._hrn)*100);

            return money;
        }
        public static Money operator -(Money money, double summVal)
        {
            double balsnse = (double)money._hrn;
            balsnse += (double)(money._kop / 100.0);
            balsnse -= Math.Round(summVal, 2);

            money._hrn = (int)Math.Truncate(balsnse);
            money._kop = (int)((balsnse - money._hrn) * 100);

            return money;
        }

        public static bool operator > (Money money, double summVal)
        {
            double balsnse = (double)money._hrn;
            balsnse += (double)(money._kop / 100.0);
            return balsnse > summVal;
        }
        public static bool operator < (Money money, double summVal)
        {
            double balsnse = (double)money._hrn;
            balsnse += (double)(money._kop / 100.0);
            return balsnse < summVal;
        }
        public static bool operator >= (Money money, double summVal)
        {
            double balsnse = (double)money._hrn;
            balsnse += (double)(money._kop / 100.0);
            return balsnse >= summVal;
        }
        public static bool operator <=(Money money, double summVal)
        {
            double balsnse = (double)money._hrn;
            balsnse += (double)(money._kop / 100.0);
            return balsnse <= summVal;
        }
        public static bool operator == (Money money, double summVal)
        {
            double balsnse = (double)money._hrn;
            balsnse += (double)(money._kop / 100.0);
            return balsnse == summVal;
        }
        public static bool operator != (Money money, double summVal)
        {
            double balsnse = (double)money._hrn;
            balsnse += (double)(money._kop / 100.0);
            return balsnse != summVal;
        }
    }
}
