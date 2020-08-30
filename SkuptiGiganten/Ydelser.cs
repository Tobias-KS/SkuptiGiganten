using System;
using System.Collections.Generic;
using System.Text;

namespace SkuptiGiganten
{
    class Ydelser
    {
        public static int ydelse()
        {
            //Den
            Console.WriteLine("Vælg den ydelse du ønsker");
            int leveringPris = 0;
            string levering = "levering";
            Console.WriteLine($"Tryk 1 for at få {levering} til døren det koster {leveringPris}");

            int indbæringPris = 195;
            string indbæring = "Indbæring";
            Console.WriteLine($"Tryk 2 for at få {indbæring} det koster {indbæringPris}");

            int monteringPris = 495;
            string montering = "montering";
            Console.WriteLine($"Tryk 3 for at få {montering} det koster {monteringPris}");


            int ydelseValg = Int32.Parse(Console.ReadLine());

            if (ydelseValg == 1)
            {
                return leveringPris;
            }
            if (ydelseValg == 2)
            {
                return indbæringPris;
            }
            if (ydelseValg == 3)
            {
                return monteringPris;
            }
            else
            {
                return 0;
            }
        }
    }
}
