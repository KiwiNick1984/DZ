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
            Ded ded = new Ded(50); //сила деда = 30, 50 - сила растения
            ded.DedPull();
        }
    }
}
