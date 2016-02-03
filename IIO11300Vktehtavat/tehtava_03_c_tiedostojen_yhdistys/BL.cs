using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace tehtava_03_c_tiedostojen_yhdistys {
    class BL {

        public static string[] listFiles(string path) {
            return Directory.GetFiles(path);
        }

        public static string[] readFiles(string path) {

            var lineCount = File.ReadAllLines(@path).Count();
            string[] line = new string[lineCount];

            try {
                using (StreamReader sr = new StreamReader(path)) {
                    for (int i = 0; i < lineCount; i++) {
                        line[i] = sr.ReadToEnd();
                    }
                    return line;
                }
            }
            catch (Exception e) {
                Console.WriteLine("Poikkeus tiedostosta luettaessa.");
                return null;
            }
        }
        public static void writeFile(string[] lines, string path) {
            Console.WriteLine(path);
            using (System.IO.StreamWriter file = new System.IO.StreamWriter(path, true)) {
                for (int i = 0; i < lines.Length; i++) {
                    Console.WriteLine(lines[i]);
                    file.WriteLine(lines[i]);
                }
                file.WriteLine("");
            }
        }
    }
}