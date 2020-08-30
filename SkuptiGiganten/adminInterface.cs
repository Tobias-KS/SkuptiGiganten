using System;
using System.Collections.Generic;
using System.Text;

namespace SkuptiGiganten
{
    class adminInterface
    {
        public void interFace()
        {

            //Opretter en ny instans af Interface så brugeren kan komme tilbage til den forrig
            Interface itf = new Interface();

            //instantierer metoden som kan forbinde til SQL serveren.  
            Connect conn1 = new Connect();

            // her kan en administrator lave ændringer i SQL databasen, få en oversigt over varerne i databasen og deres karakterstikker. 

            Console.WriteLine("1. for at ændre varer");

            Console.WriteLine("2. Tilføj vare");

            Console.WriteLine("3. fjern vare");

            Console.WriteLine("4. Få en liste over produkter");

            Console.WriteLine("5. Gå tilbage til den forrige menu");


            // bruges til at vælge hvad der skal foretages 
            int adminValg1 = Int32.Parse(Console.ReadLine());

            try
            {

          
                //Ændrer prisen på en vare i databasen
                if (adminValg1 == 1)
                {
                    adminInterface.tst();
                }


                //forbinder til databasen og tilføjer en vare med de indtastede parametre
                if (adminValg1 == 2)
                {
                conn1.tilføgVare();
                }


                //forbinder til databasen og sletter produktet med det indtastede produkt ID
                if (adminValg1 == 3)
                {
                conn1.fjernVare();
                }


                 //forbinder til databasen og producerer en liste over produkter og deres pris.
                 if (adminValg1 == 4)
                {
                conn1.listeVare();  
                }

                // Sender brugeren tilbage til menuen hvor man kan vælge mellem bruger eller admin. 
                if (adminValg1 == 5)
                {
                    itf.Q();
                }


            }
            //Hvis man skriver et ugyldigt tal
                catch (Exception)
            {
                Console.WriteLine("ugyldigt input");
                interFace();
            }

        }
        // Fortsat fra adminvalg 1
        public static void tst()
        {
            Connect conn1 = new Connect();

            Console.WriteLine("Tryk 1 for at ændre navnet på en vare");
            Console.WriteLine("Tryk 2 for at ændre mærket på en vare på en vare");
            Console.WriteLine("Tryk 3 for at ændre prisen på en enkelt vare");
            Console.WriteLine("Tryk 4 for at ændre prisen på en kategori");

            int ændreValg = Int32.Parse(Console.ReadLine());
            if (ændreValg == 1)
            {
                conn1.ændreVareNavn();
            }
            if (ændreValg == 2)
            {
                conn1.ændreVareMærke();
            }
            if (ændreValg == 3)
            {
                conn1.ændrePrisEnkelt();
            }
            if (ændreValg == 4)
            {
                conn1.ændrePrisFlere();
            }
        }
    }
 
}
