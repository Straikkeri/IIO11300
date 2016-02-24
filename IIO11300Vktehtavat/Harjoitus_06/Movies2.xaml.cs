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
using System.Windows.Shapes;
using System.Xml;

namespace Harjoitus_06 {
    /// <summary>
    /// Interaction logic for Movies2.xaml
    /// </summary>
    public partial class Movies2 : Window {
        public Movies2() {
            InitializeComponent();
        }

        private void btnSave_Click(object sender, RoutedEventArgs e) {
            //tallennetaan muuttunut tieto XML-tiedostoon

            try {
                string filu = xdpMovies.Source.LocalPath;
                xdpMovies.Document.Save(filu);
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void btnNew_Click(object sender, RoutedEventArgs e) {
            if (lbMovies.SelectedIndex > -1) {
                //huom listboxit ja listbox bindattu dataan
                lbMovies.SelectedIndex = -1;
            }
            else {
                //lisätään uusi node
                string filu = xdpMovies.Source.LocalPath;
                //viittaus xmldokumenttiin ja sen juurielementtiin
                XmlDocument doc = xdpMovies.Document;
                XmlNode root = doc.SelectSingleNode("/Movies");
                //luodaan uusi node
                XmlNode newMovie = doc.CreateElement("Movie");
                //lisätään attribuutit
                XmlAttribute attr = doc.CreateAttribute("Name");
                attr.Value = movieName.Text;
                newMovie.Attributes.Append(attr);
                XmlAttribute attr2 = doc.CreateAttribute("Director");
                attr2.Value = director.Text;
                newMovie.Attributes.Append(attr2);
                XmlAttribute attr3 = doc.CreateAttribute("Country");
                attr3.Value = country.Text;
                newMovie.Attributes.Append(attr3);
                //lisätään noodin juureen
                root.AppendChild(newMovie);
                //tallennetaan filuun
                xdpMovies.Document.Save(filu);
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e) {

        }
    }
}
