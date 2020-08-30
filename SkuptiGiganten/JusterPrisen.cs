using System;
using System.Collections.Generic;
using System.Text;

namespace SkuptiGiganten
{
    class JusterPrisen
    {
        public static double PrisJustering(double x, double z)
        {
            double currentPrice = x;
            double justerProcent = z;
            int tilladtJustering = 0;
            double afrunder = 0;
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

            double justeretVærdi = 0;

            double justering = currentPrice * (justerProcent / 100);

            if (justering > tilladtJustering)
            {
                justeretVærdi = currentPrice + justering;
            }
            if (justering < -tilladtJustering)
            {
                justeretVærdi = currentPrice + justering;
            }

            double juster = justeretVærdi;
            double modulusValue = juster % 100;

            if (modulusValue <= 9)
            {
                for (double i = 0; i <= modulusValue; i++)
                {

                    afrunder++;
                }
            }
            {

                double preFinalValue = juster - (afrunder);
                double finalValue = Math.Floor(preFinalValue);
                return finalValue;
            }
        }
    }
}
