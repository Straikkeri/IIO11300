using System;
using System.Data;  //for general ADO-classes
using System.Data.SqlClient; //for SQL Server specific classes
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

namespace tehtava_08_ViiniAsiakkaat {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        DataTable dt;
        DataView dv;
        List<string> cities;
        public MainWindow() {
            InitializeComponent();
        }

        public void IniMyStuff() {
            cities = new List<string>();
            //VE1 kaupungin nimet "kovakoodattu"
           /*ities.Add("Jyväskylä");
            cities.Add("Helsinki");
            cities.Add("New York");*/
            cbCities.ItemsSource = cities;
            //V2 käydään loppittamalla DataTable läpi
            string kaupunki = "";
            foreach (DataRow item in dt.Rows) {
                kaupunki = item["City"].ToString();
                //Tai
                kaupunki = item[3].ToString();
                //lisätään kukin kaupunki vain kerran listaan
                if (!cities.Contains(kaupunki)) {
                    cities.Add(kaupunki);
                }
            }
            //VE3 LINQ:lla voi tehdä kyselyn tyypitettyyn DataTableen, huom ei kaikille datatablella
            //var result = (from c in dt select c.City).Distinct();
            //databindaus
            cbCities.ItemsSource = cities;
        }

        private void btnGetData_Click(object sender, RoutedEventArgs e) {
            //haetaan viiniasiakkaat palvelimelta ja näytetään ne ListBoxissa
            try {
                GetData();
                //VE1 dataview filtteroitta tai sorttaatte
                //datan sitominen UI-kontrolliin, kelpaa DataTable, DataView, DataReader, oliokokoelma
                dv = dt.DefaultView;
                //datan sitominen UI-kontrolliin
                lbCustomers.DataContext = dv;
                //huom DataTable sarake (column) on case sensitiivinen
                lbCustomers.DisplayMemberPath = "Lastname";
                IniMyStuff();
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void lbCustomers_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            //vaihdetaan stackpanelin datacontext viittaamaan valittuun asiakkaaseen
            spCustomer.DataContext = lbCustomers.SelectedItem;
        }

        #region METHODS
        private void GetData() {
            //luodaan yhteys tietokantaan connectionstringin avulla
            try {
                using (SqlConnection conn = new SqlConnection(tehtava_08_ViiniAsiakkaat.Properties.Settings.Default.Tietokanta)) {
                    dt = new DataTable();
                    string sql = "SELECT * FROM vCustomers";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    //pistetään data-adapter hakeman tiedot muistiin=DataTableen
                    da.Fill(dt);
                }
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }
        #endregion
        private void cbCities_SelectionChanged(object sender, SelectionChangedEventArgs e) {
            //asetetaab DataView:llä filtteri
            dv.RowFilter = string.Format("City LIKE '{0}'", cbCities.SelectedValue);
        }
    }
}
