using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows;

namespace tehtava_07_salasananvahvuus {
    class BL {

        static public int passwordStrength(string pwd) {

            int upperCaseCount = 0;
            int lowerCaseCount = 0;
            int specialCharCount = 0;
            int wordLength = 0;
            int numberCount = 0;
            int complexity = 0; // complexity 1-4, kasvaa pienten ja suurten kirjainten, numeroiden ja erityismerkkien esiintyvyyden mukaan
            int strength = 0;   //palautusarvo, johdettu salasanan pituudesta ja monimutkaisuudesta
            bool doOnce1 = false;
            bool doOnce2 = false;
            bool doOnce3 = false;

            //MessageBox.Show("BL:ssä mennään.");

            char[] password = pwd.ToCharArray();

            for (int i = 0; i < password.Length; i++) { //lasketaan uppercase kirjaimet
                if (char.IsUpper(password[i])) {
                    //MessageBox.Show("Isokirjan löytynyt.");
                    upperCaseCount++;
                    if (!doOnce1) {
                        complexity++;
                       // MessageBox.Show("eka doOnce, complexity: " + complexity);
                        doOnce1 = true;
                    }
                }
                if (char.IsLower(password[i])) { //lasketaan lowercase kirjaimet
                    lowerCaseCount++;
                    if (!doOnce2) {
                        //MessageBox.Show("Pienikirjain löytynyt.");
                        complexity++;
                        doOnce2 = true;
                    }
                }
            }

            string specialCharacters = @"%!@#$%^&*()?/>.<,:;'\|}]{[_~`+=-" + "\""; 
            char[] specialCharactersArray = specialCharacters.ToCharArray();

            for (int j = 0; j < password.Length; j++) { //tutkitaan joukko erikoismerkkejä ja lasketaan niiden esiintyvyys
                for (int k = 0; k < specialCharactersArray.Length; k++) {
                    if (password[j] == specialCharactersArray[k]) {
                        //MessageBox.Show("Erikoismerkki löytynyt.");
                        specialCharCount++;
                        if (!doOnce3) {
                            complexity++;
                            doOnce3 = true;
                        }
                    }
                }
            }

            numberCount = pwd.Count(Char.IsDigit);  //tutkitaan kuinka monta numeroa salasanassa

            if (numberCount > 0) {
                //MessageBox.Show("Numero löytynyt.");
                complexity++;
            }

            wordLength = upperCaseCount + lowerCaseCount + specialCharCount + numberCount;  //lasketaan koko salasanan pituus

            /*
            bad            merkkejä vähemmän kuin kahdeksan tai pelkästään yhden merkkiluokan merkkejä
            fair            merkkejä vähemmän kuin kaksitoista ja vain kahden merkkiluokkan merkkejä
            moderate   merkkejä vähemmän kuin kuusitoista ja kolmen merkkiluokan merkkejä
            good         merkkejä vähintään kuusitoista ja sisältää kaikkien neljän merkkiluokan 
            */

            if (wordLength < 8 || complexity <= 1) { //todetaan salasanan vahvuus
                //MessageBox.Show("Eka if toteutuu.");
                strength = 0;
            }
            if ((wordLength >= 8 && wordLength < 12) && complexity >= 2) {
                //MessageBox.Show("Toka if toteutuu.");
                strength = 1;
            }
            if ((wordLength > 12 && wordLength < 16) && complexity == 3) {
                //MessageBox.Show("Kolmas if toteutuu.");
                strength = 3;
            }
            if (wordLength >= 16 && complexity == 4) {
                //MessageBox.Show("Neljäs if toteutuu.");
                strength = 4;
            }
            MessageBox.Show("Complexity: " + complexity + " Palautetaan " + strength);
            return strength;
        }
    }
}
