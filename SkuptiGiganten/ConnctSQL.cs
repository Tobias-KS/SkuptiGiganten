using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace SkuptiGiganten
{
    class Connect
    {
        adminInterface aInterface = new adminInterface();
        // public connection string
        #region
        public SqlConnection conn = new SqlConnection("Data Source=den1.mssql8.gear.host; Initial Catalog = skupti01; User ID = skupti01; Password=Qr0cmLe7?!91; MultipleActiveResultSets=True");
        #endregion


        // Denne metode kan tilføje en vare til databasen
        public void tilføgVare()
        {

            adminInterface aInterface = new adminInterface();

            Console.WriteLine("indtast underKategori nummer");
            int uktgNummer = Int32.Parse(Console.ReadLine());

            Console.WriteLine("indtat navnet på produktet");
            string produktNavn = Console.ReadLine();

            Console.WriteLine("indtast den ønskede pris på produktet");
            int pris = Int32.Parse(Console.ReadLine());

            Console.WriteLine("Indtast mærket på produltet");
            string mærkeNavn = Console.ReadLine();

         

            conn.Open();
            string query = $"INSERT INTO varer (UnderKategoriID, vareNavn, pris, mærke) values ({uktgNummer},'{produktNavn}',{pris}, '{mærkeNavn}')";
            SqlCommand Kommando = new SqlCommand(query, conn);

            string query3 = $"select * from varer where vareNavn = '{produktNavn}'";
            SqlCommand Kommando3 = new SqlCommand(query3, conn);

            Kommando.ExecuteNonQuery();
      
            Console.WriteLine("Vare tilføjet");
            Console.ReadKey();
            

            conn.Close();

            aInterface.interFace();
        }
    
        //fjernvare metoden
        #region
        // Denne metode kan fjerne en vare fra databasen
        public void fjernVare()
        {
            Console.WriteLine("indtast produktID på det produkt du gerne vil fjerne");

            
            int sletID = Int32.Parse(Console.ReadLine());

            conn.Open();
            string query = $"DELETE FROM varer WHERE vareID ={sletID}";
            SqlCommand Kommando = new SqlCommand(query, conn);

            Kommando.ExecuteNonQuery();

            Console.WriteLine("Vare fjernet (Hvis den eksisterer)");

            conn.Close();

            aInterface.interFace();
        }


        // Denne metode laver en liste af alle produkter i underkategorien
        public void listeVare()
        {
            //denne del af metoden skriver en liste af de forskellige underkategorier
            string query1 = "select * from underKategori";
            SqlCommand Kommando1 = new SqlCommand(query1, conn);

            conn.Open();
            SqlDataReader rdr1 = Kommando1.ExecuteReader();

            while (rdr1.Read())
            {
                var UKInt = rdr1.GetInt32(0);
                var UKNavn = rdr1.GetString(1);
                Console.WriteLine($"{UKInt} {UKNavn}");
            }
            rdr1.Close();
            conn.Close();


            Console.WriteLine("Indtast kategorien du gerne vil se");
            int ukID = Int32.Parse(Console.ReadLine());

            // Denne del af metoden opretter en tabel over de tilgængelige varer og lader brugeren hvælge hvilken de vil have. 
            string query2 = $"select * from varer where underKategoriID = '{ukID}'";
            SqlCommand Kommando2 = new SqlCommand(query2, conn);
            conn.Open();
            SqlDataReader rdr2 = Kommando2.ExecuteReader();
            Console.WriteLine("vareNR Produktnavn  Pris Mærke");
            while (rdr2.Read())
            {
                var vareID = rdr2.GetInt32(0);
                var vareNavn = rdr2.GetString(1);
                var pris = rdr2.GetInt32(3);
                var mærke = rdr2.GetString(4);
                Console.WriteLine($"{vareID}      {vareNavn}    {pris}   {mærke}");
            }
            rdr2.Close();
            conn.Close();
            Console.ReadKey();

            aInterface.interFace();

        }
        #endregion

        //Ændrer navnet på en vare
        public void ændreVareNavn()
        {
            int VareID;
            Console.WriteLine("indtast vare ID");
            VareID = Int32.Parse(Console.ReadLine());

            conn.Open();
            Console.WriteLine("indtast det nye navn");
            string nytNavn = Console.ReadLine();
            string query = $"update varer SET Varenavn = '{nytNavn}' where vareID = {VareID}";
            SqlCommand Kommando2 = new SqlCommand(query, conn);
            Kommando2.ExecuteNonQuery();
            Console.WriteLine("Navn ændret!");

            conn.Close();
            aInterface.interFace();
        }

        //Ændrer mærket af en vare.
        public void ændreVareMærke()
        {
            int VareID;
            Console.WriteLine("indtast vare ID");
            VareID = Int32.Parse(Console.ReadLine());

            conn.Open();
            Console.WriteLine("indtast det nye navn");
            string nytMærke = Console.ReadLine();

            string query = $"update varer SET mærke = '{nytMærke}' where vareID = {VareID}";
            SqlCommand Kommando2 = new SqlCommand(query, conn);
            Kommando2.ExecuteNonQuery();

            Console.WriteLine("mærke ændret!");

            conn.Close();
            aInterface.interFace();
        }

        //Ændrer prisen på en enkelt vare
        public void ændrePrisEnkelt()
        {
            int VareID = 0;
            Console.WriteLine("indtast vare ID");
            VareID = Int32.Parse(Console.ReadLine());

            conn.Open();
            string query1 = $"select pris from varer where vareid = {VareID}";
            SqlCommand Kommando1 = new SqlCommand(query1, conn);

            double gammelPris = (int)Kommando1.ExecuteScalar();
            conn.Close();


            //Kører metoden som beregner den nye pris (justerPris)
            Console.WriteLine($"den nuværende pris er {gammelPris}, hvor meget vil du ændre den med? I procent");
            int ændring = Int32.Parse(Console.ReadLine());
            
            JusterPrisen.PrisJustering(gammelPris, ændring);
            double nyPris = (JusterPrisen.PrisJustering(gammelPris, ændring));
            Console.WriteLine($"Den nye pris er {nyPris}");


            //Ændrer prisen i databasen
            conn.Open();
            string query2 = $"update varer SET pris = {nyPris} where vareID = {VareID}";
            SqlCommand Kommando2 = new SqlCommand(query2, conn);

            Kommando2.ExecuteNonQuery();

            string query3 = $"select pris from varer where vareid = {VareID}";
            SqlCommand Kommando3 = new SqlCommand(query3, conn);

            double færdigPris = (int)Kommando3.ExecuteScalar();

            
            conn.Close();
            aInterface.interFace();

        }
        public void ændrePrisFlere()
        {
                    // Denne del finder prisen i databasen
                      int rdrCount = 0;


                        Console.WriteLine("Skriv ID på den under kategori du gerne vil ændre");
                        int ukID = Int32.Parse(Console.ReadLine());

                        Console.WriteLine("hvor meget vil du gerne ændre den med? I procent");
                        int ændring = Int32.Parse(Console.ReadLine());

                        conn.Open();

                        string query = $"select vareid,pris from varer where UnderKategoriID = {ukID}";

                        SqlCommand Kommando = new SqlCommand(query, conn);

                        SqlDataReader rdr = Kommando.ExecuteReader();
                        List<PrisList> prisList = new List<PrisList>();

                        while (rdr.Read())
                        {
                            prisList.Add(new PrisList { vareNR = rdr.GetInt32(0), PrisVærdi = rdr.GetInt32(1) });
                            Console.WriteLine(prisList[rdrCount].vareNR);
                            Console.WriteLine(prisList[rdrCount].PrisVærdi);
                            rdrCount++;
                        }
                        rdr.Close();
                        conn.Close();
                        
                          for (int i = 0; i < rdrCount; i++)
                          {

                              double gammelPris = prisList[i].PrisVærdi;
                              int localVareID = prisList[i].vareNR;
                              double nypris = JusterPrisen.PrisJustering(gammelPris, ændring);
   

                              conn.Open();
                              string query4 = $"update varer SET pris = {nypris} where vareID = {localVareID}";
                              SqlCommand Kommando4 = new SqlCommand(query4, conn);
                              Kommando4.BeginExecuteNonQuery();
                                
                              Console.WriteLine(nypris);
                              conn.Close();

                          }
            aInterface.interFace();
        }        
        
                }

            }

        
    



