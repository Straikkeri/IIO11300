using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JAMK.IT.IIO11300 {
    class IkkunaVE0 {

        public double leveys, korkeus;
        public double LaskePintaala() {
            return leveys * korkeus;
        }
    }
    public class Ikkuna {
        //property = Ominaisuus
        private double korkeus;

        public double Korkeus {
            get { return korkeus; }
            set { korkeus = value; }
        }

        private double leveys;

        public double Leveys {
            get { return leveys; }
            set { leveys = value; }
        }

        //read.only tyyppinen property
        public double PintaAla {
            get {
                //return korkeus * leveys;
                return LaskeIPintaAla();
            }
        }
        //Metodit
        public double LaskePintaAla() {
            //return korkeus * leveys;
            return LaskeIPintaAla();
        }
        private double LaskeIPintaAla() {
            return korkeus * leveys;
        }
    }
}
