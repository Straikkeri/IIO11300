using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
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

namespace tehtava_09_asiakkaidenMuokkaus {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        DataTable dt;
        DataView dv;
        public MainWindow() {
            InitializeComponent();
        }

        private void btnGetData_Click(object sender, RoutedEventArgs e) {
            //haetaan viiniasiakkaat palvelimelta ja näytetään ne ListBoxissa
            try {
                GetData();
                //VE1 dataview filtteroitta tai sorttaatte
                //datan sitominen UI-kontrolliin, kelpaa DataTable, DataView, DataReader, oliokokoelma
                dv = dt.DefaultView;
                customersDataGrid.ItemsSource = dv;
            }
            catch (Exception ex) {
                MessageBox.Show(ex.Message);
            }
        }

        private void GetData() {
            //luodaan yhteys tietokantaan connectionstringin avulla
            try {
                using (SqlConnection conn = new SqlConnection(tehtava_09_asiakkaidenMuokkaus.Properties.Settings.Default.Tietokanta)) {
                    dt = new DataTable();
                    string sql = "SELECT * FROM customer";
                    SqlDataAdapter da = new SqlDataAdapter(sql, conn);
                    //pistetään data-adapter hakeman tiedot muistiin=DataTableen
                    da.Fill(dt);
                }
            }
            catch (Exception ex) {

                MessageBox.Show(ex.Message);
            }
        }
        private void btnNewCustomer_Click(object sender, RoutedEventArgs e) {

            if (tbEnimi.Text == "" || tbSnimi.Text == "" || tbOsoite.Text == "" || tbPostinro.Text == "" || tbKaupunki.Text == "") {
                MessageBox.Show("Tietokentät eivät voi olla tyhjiä.");
            }
            else {
                try {
                    using (SqlConnection connection = new SqlConnection(tehtava_09_asiakkaidenMuokkaus.Properties.Settings.Default.Tietokanta)) {

                        SqlCommand cmd = new SqlCommand("INSERT INTO customer(firstname, lastname, address, zip, city) VALUES(@firstname, @lastname, @address, @zip, @city)");
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("@firstname", tbEnimi.Text);
                        cmd.Parameters.AddWithValue("@lastname", tbSnimi.Text);
                        cmd.Parameters.AddWithValue("@address", tbOsoite.Text);
                        cmd.Parameters.AddWithValue("@zip", tbPostinro.Text);
                        cmd.Parameters.AddWithValue("@city", tbKaupunki.Text);
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Asiakas lisätty onnistuneesti.");
                    }
                    
                }
                catch (Exception ex) {

                    MessageBox.Show(ex.ToString());
                }
            }
        }

        private void btnDeleteCustomer_Click(object sender, RoutedEventArgs e) {
            
            DataRow dr = dt.Rows[customersDataGrid.SelectedIndex];

            MessageBoxResult result = MessageBox.Show("Are you sure you wish to delete " + dr["firstname"].ToString() + "?", "Delete", MessageBoxButton.YesNo);

            if (result == MessageBoxResult.Yes) {
                try {
                    using (SqlConnection connection = new SqlConnection(tehtava_09_asiakkaidenMuokkaus.Properties.Settings.Default.Tietokanta)) {

                        SqlCommand cmd = new SqlCommand("DELETE FROM customer WHERE((firstname = @firstname) AND (lastname = @lastname) AND (address = @address) AND (zip = @zip) AND (city = @city))");
                        cmd.CommandType = CommandType.Text;
                        cmd.Connection = connection;
                        cmd.Parameters.AddWithValue("@firstname", dr["firstname"].ToString());
                        cmd.Parameters.AddWithValue("@lastname", dr["lastname"].ToString());
                        cmd.Parameters.AddWithValue("@address", dr["address"].ToString());
                        cmd.Parameters.AddWithValue("@zip", dr["zip"].ToString());
                        cmd.Parameters.AddWithValue("@city", dr["city"].ToString());
                        connection.Open();
                        cmd.ExecuteNonQuery();
                        connection.Close();
                        MessageBox.Show("Asiakas poistettu onnistuneesti.");
                        GetData();
                        dv = dt.DefaultView;
                        customersDataGrid.ItemsSource = dv;
                    }
                }
                catch (Exception ex) {

                    MessageBox.Show(ex.ToString());
                }
            }
            else if (result == MessageBoxResult.No) {
                
            }


        }

        private void btnSaveChanges_Click(object sender, RoutedEventArgs e) {

        }


    }
}
