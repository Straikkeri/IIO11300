using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tehtava_02_lotto {
    class Lotto {

        public int[] draw(int draws, int lotto) {

            Console.WriteLine("lotto on: " + lotto);
            
            int[] suomiTable = new int[7];
            int[] vikingTable = new int[6];
            int[] euroTable = new int[7];

            Random rand = new Random();

            rand.Next(1, 39);

            if (lotto == 1) {
                for (int i = 0; i < 7; i++) {
                    suomiTable[i] = rand.Next(1, 39);
                }
                Console.WriteLine("suomiTable pituus = " + suomiTable.Length);
            }
            if (lotto == 2) {
                for (int i = 0; i < 6; i++) {
                    vikingTable[i] = rand.Next(1, 48);
                }   
            }
            if (lotto == 3) { 
                for (int i = 0; i < 5; i++) {
                    euroTable[i] = rand.Next(1, 50);
                }
                    euroTable[5] = rand.Next(1, 8);
                    euroTable[6] = rand.Next(1, 8);
            } else { }

            switch (lotto) {
                case 0:
                    Console.WriteLine("Ei valittua lottoa.");
                    return suomiTable;  
                case 1:
                    Console.WriteLine("Suomilotto.");
                    return suomiTable;
                case 2:
                    Console.WriteLine("Vikinglotto.");
                    return vikingTable;
                case 3:
                    Console.WriteLine("eurolotto.");
                    return euroTable;
                default:
                    Console.WriteLine("Jokin meni vikaan. Lottomuuttujassa odottamaton arvo.");
                    return suomiTable;
            }
        }
    }
}

