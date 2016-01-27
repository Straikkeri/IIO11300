using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tehtava_02_lotto {
    class Lotto {

        public int[][] draw(int draws, int lotto) {

            Console.WriteLine("lotto on: " + lotto);

            int[][] wrapperTable = new int[draws][];
            int[] suomiTable = new int[7];
            int[] vikingTable = new int[6];
            int[] euroTable = new int[7];

            Random rand = new Random();

            if (lotto == 1) {
                for (int j = 0; j < draws; j++) {
                    for (int i = 0; i < 7; i++) {
                        suomiTable[i] = rand.Next(1, 39);
                    }
                    System.Threading.Thread.Sleep(500);
                    wrapperTable[j] = suomiTable;
                    Console.WriteLine("suomiTable pituus = " + suomiTable.Length); 
                }
            }
            if (lotto == 2) {
                for (int j = 0; j < draws; j++) {
                    for (int i = 0; i < 6; i++) {
                        vikingTable[i] = rand.Next(1, 48);
                    }
                    System.Threading.Thread.Sleep(500);

                    for (int k = 0; k < vikingTable.Length; k++) {
                        Console.WriteLine("viking table indeksi " + k + " on: " + vikingTable[k]);
                    }

                    wrapperTable[j] = vikingTable;
                }   
            }
            if (lotto == 3) {
                for (int j = 0; j < draws; j++) {
                    for (int i = 0; i < 5; i++) {
                        euroTable[i] = rand.Next(1, 50);
                    }
                    System.Threading.Thread.Sleep(500);
                    euroTable[5] = rand.Next(1, 8);
                    euroTable[6] = rand.Next(1, 8);
                    wrapperTable[j] = euroTable;
                }
            } else { }

            switch (lotto) {
                case 0:
                    Console.WriteLine("Ei valittua lottoa.");
                    return wrapperTable;  
                case 1:
                    Console.WriteLine("Suomilotto.");
                    return wrapperTable;
                case 2:
                    Console.WriteLine("Vikinglotto.");
                    return wrapperTable;
                case 3:
                    Console.WriteLine("eurolotto.");
                    return wrapperTable;
                default:
                    Console.WriteLine("Jokin meni vikaan. Lottomuuttujassa odottamaton arvo.");
                    return wrapperTable;
            }
        }
    }
}

