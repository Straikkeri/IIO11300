using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.IO;

namespace tehtava_03_c_tiedostojen_yhdistys {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
        }

        private void btn_hae_Click(object sender, RoutedEventArgs e) {
            string[] tempTable = BL.listFiles(txtBox_hakemisto.Text);

            for (int i = 0; i < tempTable.Length; i++) {
                listView_files.Items.Add(tempTable[i]);
            }
        }

        private void btn_yhdista_Click(object sender, RoutedEventArgs e) {

            int lkmChosen = listView_files.SelectedItems.Count;
            string[] chosenPaths = new string[lkmChosen];

            if (lkmChosen >= 1) {
                for (int i = 0; i < lkmChosen; i++) {
                    
                    chosenPaths[i] = listView_files.SelectedItems[i].ToString();
                    Console.WriteLine("saatu osoite: " + chosenPaths[i]);
                }
            }
            if (!File.Exists(txtBox_tulos.Text)) {
                File.Create(txtBox_tulos.Text);
                for (int i = 0; i < lkmChosen; i++) {
                    string[] tempTable = BL.readFiles(chosenPaths[i]);
                    for (int j = 0; j < tempTable.Length; j++) { Console.WriteLine(tempTable[j]); }
                    BL.writeFile(tempTable, txtBox_tulos.Text);
                }
            }
            else {
                Console.WriteLine("File already exists!");
            }
        }
    }
}

