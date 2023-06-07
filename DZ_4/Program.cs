using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ_4
{
    internal class Program
    {        
        static void Main(string[] args)
        {
            Ded ded = new Ded();
            ded.plantRepka(); 
            ded.plantPowerfulRepka();
            ded.plantRepka();
            Console.ReadLine();

            ded.BoostTheRepka();
            ded.PullTheRepka();
        }
    }
}
