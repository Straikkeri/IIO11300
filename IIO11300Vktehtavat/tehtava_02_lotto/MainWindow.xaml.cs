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

namespace tehtava_02_lotto {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Initialization();
        }
        
        int selectedLotto = 0;
        Lotto lottoOlio = new Lotto();

        private void Initialization() {
            drawsBox.Text = "0";
        }

        private void lottoBox_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            if (lottoBox.SelectedIndex == 0) {
                Console.WriteLine("suomi valittu.");
                selectedLotto = 1;
            }
            else if (lottoBox.SelectedIndex == 1) {
                Console.WriteLine("viking valittu.");
                selectedLotto = 2;
                Console.WriteLine("selectedLotto = " + selectedLotto);
            }
            else if (lottoBox.SelectedIndex == 2) {
                Console.WriteLine("euro valittu.");
                selectedLotto = 3;
            }
            else {
                Console.WriteLine(lottoBox.SelectedIndex == -1);
                selectedLotto = 0;
            }
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e) {

            int[][] tempTable;

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            try {
                Console.WriteLine("kutsutaan drawia loton arvolla: " + selectedLotto);
                tempTable = lottoOlio.draw(Int32.Parse(drawsBox.Text), selectedLotto);
            }
            catch (Exception) {
                MessageBox.Show("Draws luukussa oltava numero.");
                throw;
            }

            Console.WriteLine("tempTable pituus on: " + tempTable.Length);

            for (int j = 0; j < tempTable.Length; j++) {
                sb.Clear();
                Console.WriteLine("Kierros: " + j);
                Console.WriteLine("tempTable indeksi " + j + " pituus on: " + tempTable[j].Length);
                for (int i = 0; i < tempTable[j].Length; i++) {
                    Console.WriteLine(" -Kierros: " + i);
                    sb.Append(Convert.ToString(tempTable[j][i])).Append(", ");
                }
                drawsArea.Items.Add(sb.ToString()); 
            }
        }
        private void btnClear_Click(object sender, RoutedEventArgs e) {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {

        }


    }
}
