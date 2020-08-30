using System;
using System.Collections.Generic;
using System.Text;

namespace SkuptiGiganten
{
    class Interface
    {
        // instansierer metoden som indeholder administrator brugerfladen. 
        adminInterface aInterface = new adminInterface();
        // instansierer metoden som indeholder kunde brugerfladen. 
        userInterface uInterface = new userInterface();

        public void Q()
        {
            Console.WriteLine("1. Kunde-login");
            Console.WriteLine("2. Administrator-login");


            var brugerValg = Int32.Parse(Console.ReadLine());
            if (brugerValg == 1)
            {
                uInterface.interFace();
            }
            if (brugerValg == 2)
            {
                aInterface.interFace();
            }
            else
            {
            
                Q();
                Console.WriteLine("Ugyldigt input");
            }
        
            }
    }
}
