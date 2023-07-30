using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace DZ_11
{
    internal class Program
    {
        static void Main(string[] args)
        {
            System.Diagnostics.Process process = new System.Diagnostics.Process();
            process.StartInfo.FileName = @"D:\Training\C#\DZ_1\DZ_11_gen\bin\Debug\net7.0\DZ_11_gen.exe";
            process.StartInfo.Arguments = @"D:\CityInfo_List.txt";
            var sw = Stopwatch.StartNew();                
            process.Start();
            process.WaitForExit();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);

            process.StartInfo.FileName = @"d:\Training\C#\DZ_1\DZ_11_pars\bin\Debug\net7.0\DZ_11_pars.exe";
            process.StartInfo.Arguments = @"D:\CityInfo_List.txt";
            sw = Stopwatch.StartNew();
            process.Start();
            process.WaitForExit();
            sw.Stop();
            Console.WriteLine(sw.Elapsed);
        }
    }
}
