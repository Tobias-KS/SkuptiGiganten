using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;

namespace SkuptiGiganten
{
    class userInterface
    {
        public void interFace()
        {
            //Denne metode agere som inkøbskurven I programmet
        SqlConnection conn = new SqlConnection("Data Source=den1.mssql8.gear.host; Initial Catalog = skupti01; User ID = skupti01; Password=Qr0cmLe7?!91");

            // den første del af metoden laver en menu og lader brugeren vælge en underkategori 
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


      

            Console.WriteLine("Vælg hvilke kategori du gerne vil handle i.");
            int ukID = Int32.Parse(Console.ReadLine());


            // Denne del af metoden opretter en tabel over de tilgængelige varer og lader brugeren hvælge hvilken de vil have. 
            string query2 = $"select * from varer where underKategoriID = '{ukID}'";
            SqlCommand Kommando2 = new SqlCommand(query2, conn);
            conn.Open();
            SqlDataReader rdr2 = Kommando2.ExecuteReader();
            Console.WriteLine("VareNR Varenavn Pris Mærke");
            while (rdr2.Read())
            {
                var vareID = rdr2.GetInt32(0);
                var vareNavn = rdr2.GetString(1);
                var pris = rdr2.GetInt32(3);
                var mærke = rdr2.GetString(4);
                Console.WriteLine($"{vareID} {vareNavn} {pris} {mærke}");
            }
            rdr2.Close();
            conn.Close();

            Console.WriteLine("vælg  Varenummeret på den vare du ønsker at købe");
            int VareID = Int32.Parse(Console.ReadLine());
            string query3 = $"select pris from varer where vareID = '{VareID}'";

            conn.Open();
            SqlCommand Kommando3 = new SqlCommand(query3, conn);
            int produktPris = (int)Kommando3.ExecuteScalar();
            conn.Close();

            //Denne sidste del lader brugeren vælge evt ydelelser og beregner den samlede pris
            int ydelsePris = Ydelser.ydelse();
            int finalpris = produktPris + ydelsePris;

            Console.WriteLine($" Din samlede pris er {finalpris} varen koster {produktPris} og service koster {ydelsePris}");
            Console.ReadKey();

        }
    }
}
