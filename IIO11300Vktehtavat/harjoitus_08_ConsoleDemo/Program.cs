using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient; //SQL Serveriä varten

namespace harjoitus_08_ConsoleDemo {
    class Program {
        static void Main(string[] args){
            try {
                /*basic steps*/
                /*1 luodaan yhteys*/
                string connStr = GetConnectionString();
                using (SqlConnection conn = new SqlConnection(connStr)) {
                    //avataan yhteys
                    conn.Open();
                    /*2tehdään SQL kysely*/
                    string sql = "SELECT asioid, lastname, firstname FROM Presences WHERE asioid ='salesa'";
                    SqlCommand cmd = new SqlCommand(sql, conn);
                    /*3 käsitellään "tulos"*/
                    SqlDataReader rdr = cmd.ExecuteReader();
                    //käydään reader-olio läpi, forward-only
                    if (rdr.HasRows) {
                        while (rdr.Read()) {
                            Console.WriteLine("Läsnäolosoi {0} {1} {2}", rdr.GetString(0), rdr.GetString(1), rdr.GetString(2));
                        }
                        Console.WriteLine("Tiedot haettu onnistuneesti");
                    }
                    rdr.Close();
                    conn.Close();
                    Console.WriteLine("Tietokantayhteys suljettu onnistuneesti");
                }
            } catch(Exception ex){
                Console.WriteLine(ex.Message);
            } finally {
                Console.ReadKey();
            }
        }

        private static string GetConnectionString() {
            //Luetaan connection string App.Configista
            return harjoitus_08_ConsoleDemo.Properties.Settings.Default.Tietokanta;
        }
    }
}
