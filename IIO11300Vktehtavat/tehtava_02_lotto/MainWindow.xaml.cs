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
        }

        int selectedLotto = 0;
        Lotto lottoOlio = new Lotto();

        private void lottoBox_SelectedIndexChanged(object sender, System.EventArgs e) {
            if (lottoBox.Text == "Suomi") {
                selectedLotto = 1;
            }
            else if (lottoBox.Text == "VikingLotto") {
                selectedLotto = 2;
            }
            else if (lottoBox.Text == "EuroJackpot") {
                selectedLotto = 3;
            } else {
                selectedLotto = 0;
            }
        }

        private void btnDraw_Click(object sender, RoutedEventArgs e) {

            System.Text.StringBuilder sb = new System.Text.StringBuilder();
            int[] tempTable = lottoOlio.draw(Int32.Parse(drawsBox.Text), selectedLotto);

            for (int i = 0; i < tempTable.Length; i++) {
                sb.Append(Convert.ToString(tempTable[i])).Append(", ");
            }
            drawsArea.Items.Add(sb.ToString());
        }
        private void btnClear_Click(object sender, RoutedEventArgs e) {

        }

        private void btnClose_Click(object sender, RoutedEventArgs e) {

        }
    }
}
