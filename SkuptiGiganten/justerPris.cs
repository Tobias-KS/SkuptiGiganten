using System;
using System.Collections.Generic;
using System.Text;

namespace SkuptiGiganten
{
    class justerPris
    {
       
        private double tilladtJustering;
        private double currentPrice;
        private double justerProcent;
        public justerPris(double x, double z, ref double y)
            {
            currentPrice = x;
            justerProcent = z;
            y = FærdigVærdi();
           
        }
        public double returnInt()
        {

            if (currentPrice < 100)
            {
                tilladtJustering = 5;
            }
            if (currentPrice >= 100 && currentPrice < 200)
            {
                tilladtJustering = 25;
            }
            if (currentPrice >= 200 && currentPrice < 500)
            {
                tilladtJustering = 50;
            }
            if (currentPrice >= 500)
            {
               tilladtJustering = 100;
            }
   

            return tilladtJustering;
        }
        public double Juster()
        {
            double justeretVærdi;
            Console.WriteLine("hvor meget vil du ændre prisen med? i procent");

            double justering = currentPrice * (justerProcent / 100);
  
            if (justering > tilladtJustering)
            {
                justeretVærdi = currentPrice + justering;
               
              
                return justeretVærdi;

            }
            if (justering < -tilladtJustering)
            {
                justeretVærdi = currentPrice + justering;
                return justeretVærdi;

            }
            else
            {
                return currentPrice;
            }

        }
        public double FærdigVærdi()
        {
            double juster = Juster();
            double afrunder = 0;
            double modulusValue = juster % 100;
            if (modulusValue >= 9)
            {
                return juster;
            }
          
            
            else
            {
                for (double i = 0; i <= modulusValue; i++)
                {
                  
                    afrunder++;
                }
                double finalValue = juster - (afrunder);
                return finalValue;
            }
        }
    }
}
