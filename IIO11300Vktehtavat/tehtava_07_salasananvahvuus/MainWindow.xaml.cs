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

namespace tehtava_07_salasananvahvuus {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            Initialize();
        }

        public void Initialize() {
            textBlock_6.Background = Brushes.Gray;
            textBlock_6.Text = "Anna salasana";
        }
        private void tbSalasana_TextChanged(object sender, TextChangedEventArgs e) {
            try {

                int vahvuus = tehtava_07_salasananvahvuus.BL.passwordStrength(tbSalasana.Text);

                if (vahvuus == 1) {
                    textBlock_6.Background = Brushes.Orange;
                    textBlock_6.Text = "Bad";
                }
                else if (vahvuus == 2) {
                    textBlock_6.Background = Brushes.Yellow;
                    textBlock_6.Text = "Fair";
                }
                else if (vahvuus == 1) {
                    textBlock_6.Background = Brushes.LightGreen;
                    textBlock_6.Text = "Moderate";
                }
                else if (vahvuus == 1) {
                    textBlock_6.Background = Brushes.Green;
                    textBlock_6.Text = "Good";
                }
                else {
                    textBlock_6.Background = Brushes.Gray;
                    textBlock_6.Text = "Anna salasana";
                }

            }
            catch (Exception) {
                throw;
            }
        }
    }
}

// päivitä luvut pääikkunan kenttiin, tarkista miksi text changed ei ammu