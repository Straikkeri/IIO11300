using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tehtava_04_sm_liiga {
    class Pelaaja {

        string enimi, snimi, pseura, hetu;
        int shinta;

        public Pelaaja(string enimi, string snimi, int hinta, string seura){
            this.enimi = enimi;
            this.snimi = snimi;
            shinta = hinta;
            this.pseura = seura;
            hetu = Convert.ToString(DateTime.Now.Millisecond);
        }

        public string kokonimi {
            get { return snimi + " " + etunimi; }
        }
        public string esitysnimi {
            get { return enimi + " " + snimi + ", " + pseura; }
        }

        public string etunimi {
            get { return enimi; }
            set { enimi = value; }
        }

        public string sukunimi {
            get { return snimi; }
            set { snimi = value; }
        }

        public int siirtohinta {
            get { return shinta; }
            set { shinta = value; }
        }

        public string seura {
            get { return pseura; }
            set { pseura = value; }
        }
        public string henkilotunnus {
            get { return hetu; }
        }

        public override string ToString() {
            return esitysnimi;
        }


    }
}
