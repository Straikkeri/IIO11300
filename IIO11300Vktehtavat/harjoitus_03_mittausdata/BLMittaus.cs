using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300 {
    public class MittausData {
        private string kello;
        public string Kello {
            get { return kello; }
            set { kello = value; }
        }
        private string mittaus;

        public string Mittaus {
            get { return mittaus; }
            set { mittaus = value; }
        }
        public string DataMuoto {
            get { return kello + ";" + mittaus; }
        }
        #region CONSTRUCTORS
        //luokalle tehdään kaksi konstruktoria
        public MittausData() {
            kello = "0:00";
            mittaus = "empty";
        }

        public MittausData(string klo, string mdata) {
            this.kello = klo;
            this.mittaus = mdata;
        }
        #endregion
        //ylikirjoitetaan ToString
        public override string ToString() {
            //return base.ToString();
            return kello + "=" + mittaus;
        }
        #region METHODS
        public static void SaveDataToFile(List<MittausData> dataa, string filu) {
            //kirjoitetaan data tiedostoon, jos tiedosto on jo  olemassa liitetään se olemassa olevaan
            try {
                //tutkitaan onko tiedosto olemassa
                if (!System.IO.File.Exists(filu)) {
                    //luodaan uusi
                    using (System.IO.StreamWriter sw = System.IO.File.CreateText(filu)) {
                        //käydään kokoelma läpi ja kirjoitetaan kukin mittausdata omalle riville
                        foreach (var item in dataa) {
                            sw.WriteLine(item.DataMuoto);
                        }
                    }
                }
                else {
                    //lisätään olemassaolevaan tiedostoon
                    using ( System.IO.StreamWriter sw = System.IO.File.AppendText(filu)) {
                        foreach (var item in dataa) {
                            sw.WriteLine(item.DataMuoto);
                        }
                    }
                }
            }
            catch (Exception ex) {

                throw ex;
            }
        }

        public static List<MittausData> ReadDataFromFile(string filu) {
            //luetaan käyttäjän antamasta tiedostosta tekstirivejä ja muutetaan ne mittausdataksi
            try {
                if (System.IO.File.Exists(filu)) {
                    using(System.IO.StreamReader sr = System.IO.File.OpenText(filu)) {
                        
                        MittausData md;
                        List<MittausData> luetut = new List<MittausData>();
                        string rivi = "";
                        while((rivi = sr.ReadLine()) != null) {
                            //tutkitaan löytyykö sovittu erotinmerkki ; --> etupuolella on kellonaika ja jälkipuolella mittausarvo
                            if ((rivi.Length > 3) && rivi.Contains(";")) {
                                string[] split = rivi.Split(new char[] { ';' });
                                //luodaan tekstinpätistä olio
                                md = new MittausData(split[0], split[1]);
                                luetut.Add(md);
                            }
                        }
                        //palautetaan
                        return luetut;
                    }
                }
                else {
                    throw new System.IO.FileNotFoundException();
                }
            }
            catch (Exception ex) {

                throw ex;
            }
        }
        #endregion
    }
}
