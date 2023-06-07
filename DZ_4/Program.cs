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
            ded.plantRepka();
            ded.BoostTheRepka();
            ded.PullTheRepka();
            //Console.WriteLine(ded.SelectGardenArea());
        }
    }
}
