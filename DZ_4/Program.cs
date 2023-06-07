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
            ded.plantRepka(30); 
            ded.plantRepka(40);
            ded.plantRepka(50);
            ded.plantRepka(70);
            ded.DedPull();
            ded.DedPull();
        }
    }
}
