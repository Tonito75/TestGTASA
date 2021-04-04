using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Tests
{
    class Program
    {
        static void Main(string[] args)
        {
            //DFF.process();
            //Textures.AnalyseTXD();
            //Saves.processfast();
            //gta3.setAllTXD();
            Analyse.Analys();
            gta3.setObjects();
            Console.WriteLine("\n\nfini");
            Console.ReadKey();
           
        }
    }
}
