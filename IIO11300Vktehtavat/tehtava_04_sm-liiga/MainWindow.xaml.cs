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
using Microsoft.Win32;
using System.IO;

namespace tehtava_04_sm_liiga {
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        List<Pelaaja> pelaajat = new List<Pelaaja>();
        bool notEmpty = false;
        string hetu;
        SaveFileDialog saveFD = new SaveFileDialog();

        public MainWindow() {
            InitializeComponent();
            initialization();
        }

        private void initialization() {
            seuraBox.Items.Add("Seura1");
            seuraBox.Items.Add("Seura2");
            seuraBox.Items.Add("Seura3");
            seuraBox.Items.Add("Seura4");
            seuraBox.Items.Add("Seura5");
            seuraBox.Items.Add("Seura6");
            seuraBox.Items.Add("Seura7");
            seuraBox.Items.Add("Seura8");
            seuraBox.Items.Add("Seura9");
            seuraBox.Items.Add("Seura10");
            seuraBox.Items.Add("Seura11");
            seuraBox.Items.Add("Seura12");
            seuraBox.Items.Add("Seura13");
            seuraBox.Items.Add("Seura14");
            seuraBox.Items.Add("Seura15");
            saveFD.FileName = "pelaajat"; // Default file name
            saveFD.DefaultExt = ".txt"; // Default file extension
            saveFD.Filter = "Text documents (.txt)|*.txt"; // Filter files by extension

            try {
                if (System.IO.File.Exists(@"D:\pelaajat.txt")) {
                    Console.WriteLine("luettava oletustiedosto on olemassa.");
                    using (System.IO.StreamReader sr = System.IO.File.OpenText(@"D:\pelaajat.txt")) {

                        Pelaaja pelimies;
                        string rivi = "";
                        while ((rivi = sr.ReadLine()) != null) {
                            Console.WriteLine("Etsitään rivejä...");
                            //tutkitaan löytyykö sovittu erotinmerkki ; --> etupuolella on kellonaika ja jälkipuolella mittausarvo
                            if (rivi.Contains("|")) {
                                Console.WriteLine("Oikean syntaksin omaava rivi löytyi.");
                                string[] split = rivi.Split(new char[] { '|' });
                                //luodaan tekstinpätistä olio
                                pelimies = new Pelaaja(split[0], split[1], Int32.Parse(split[2]), split[3]);
                                pelaajat.Add(pelimies);
                            }
                        }
                    }
                }
                else {
                    throw new System.IO.FileNotFoundException();
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Pelaajat.txt tiedostoa ei löydy. Pelaajalista alkaa tyhjänä." + ex.ToString());
            }
            listviewPelaajat.ItemsSource = null;
            listviewPelaajat.ItemsSource = pelaajat;
        }

        private void btnLuo_Click(object sender, RoutedEventArgs e) {
            try {
                bool match = false;
                Pelaaja pelaaja = new Pelaaja(boxEnimi.Text, boxSnimi.Text, Int32.Parse(boxHinta.Text), seuraBox.SelectedItem.ToString());
                if (notEmpty) {
                    foreach (var item in pelaajat) {
                        if (item.kokonimi == pelaaja.kokonimi) {
                            match = true;
                        }
                    }
                    if (match == false) {
                        pelaajat.Add(pelaaja);
                        SBTBStatus.Text = "Pelaaja lisätty onnistuneesti.";
                    }
                }
                else {
                    Console.WriteLine(pelaaja.esitysnimi);
                    pelaajat.Add(pelaaja);
                    notEmpty = true;
                    SBTBStatus.Text = "Pelaaja lisätty onnistuneesti.";
                }
            }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
                SBTBStatus.Text = "Pelaaja ei voitu lisätä.";
            }
            listviewPelaajat.ItemsSource = null;
            listviewPelaajat.ItemsSource = pelaajat;
        }

        private void btnKirjoita_Click(object sender, RoutedEventArgs e) {
            Nullable<bool> result = saveFD.ShowDialog();
            string filename = "";
            // Process save file dialog box results
            if (result == true) {
                // Save document
                filename = saveFD.FileName;
                Console.WriteLine("result = true: " + filename);
            }

            try {
                    //tutkitaan onko tiedosto olemassa
                    if (!System.IO.File.Exists(filename)) {
                    Console.WriteLine("Tiedosto ei ole olemassa.");
                        //luodaan uusi
                        using (System.IO.StreamWriter sw = System.IO.File.CreateText(filename)) {
                        File.WriteAllText(filename,"");
                            //käydään kokoelma läpi ja kirjoitetaan kukin mittausdata omalle riville
                            foreach (var item in pelaajat) {
                                sw.WriteLine(item.etunimi + "|" + item.sukunimi + "|" + item.siirtohinta + "|" + item.seura );
                                Console.WriteLine("Rivi kirjoitettu uuteen.");
                            }
                        }
                    }
                    else {
                        //lisätään olemassaolevaan tiedostoon
                        using (System.IO.StreamWriter sw = System.IO.File.AppendText(filename)) {
                            foreach (var item in pelaajat) {
                                sw.WriteLine(item.etunimi + "|" + item.sukunimi + "|" + item.siirtohinta + "|" + item.seura);
                                Console.WriteLine("Rivi kirjoitettu olemassaolevaan.");
                            }
                        }
                    }
                }
            catch (Exception ex) {
                MessageBox.Show(ex.ToString());
            }
        }

        private void listviewPelaajat_SelectionChanged(object sender, SelectionChangedEventArgs e) {

            foreach (var item in pelaajat) {

                //Nimen perusteella etsitään listasta ja täytetään tekstikentät. JATKA TÄSTÄ.
                if (listviewPelaajat.SelectedIndex >= 0) {
                    if (item.esitysnimi == listviewPelaajat.SelectedItem.ToString()) {
                        hetu = item.henkilotunnus;

                        boxEnimi.Text = item.etunimi;
                        boxSnimi.Text = item.sukunimi;
                        boxHinta.Text = Convert.ToString(item.siirtohinta);
                        int i = -1;

                        Console.WriteLine(item.seura);

                        switch (item.seura.ToLower()) {
                            case "seura1":
                                Console.WriteLine("Case 1");
                                i = 0;
                                break;
                            case "seura2":
                                Console.WriteLine("Case 2");
                                i = 1;
                                break;
                            case "seura3":
                                Console.WriteLine("Case 3");
                                i = 2;
                                break;
                            case "seura4":
                                Console.WriteLine("Case 4");
                                i = 3;
                                break;
                            case "seura5":
                                Console.WriteLine("Case 5");
                                i = 4;
                                break;
                            case "seura6":
                                Console.WriteLine("Case 6");
                                i = 5;
                                break;
                            case "seura7":
                                Console.WriteLine("Case 7");
                                i = 6;
                                break;
                            case "seura8":
                                Console.WriteLine("Case 8");
                                i = 7;
                                break;
                            case "seura9":
                                Console.WriteLine("Case 9");
                                i = 8;
                                break;
                            case "seura10":
                                Console.WriteLine("Case 10");
                                i = 9;
                                break;
                            case "seura11":
                                Console.WriteLine("Case 11");
                                i = 10;
                                break;
                            case "seura12":
                                Console.WriteLine("Case 12");
                                i = 11;
                                break;
                            case "seura13":
                                Console.WriteLine("Case 13");
                                i = 12;
                                break;
                            case "seura14":
                                Console.WriteLine("Case 14");
                                i = 13;
                                break;
                            case "seura15":
                                Console.WriteLine("Case 15");
                                i = 14;
                                break;
                            default:
                                Console.WriteLine("Default case");
                                i = 0;
                                break;
                        }
                        seuraBox.SelectedIndex = i;
                        break;
                    }
                }
            }
        }

        private void btnTalleta_Click(object sender, RoutedEventArgs e) {
            foreach (var item in pelaajat) {
                if (item.henkilotunnus == hetu) {
                    Console.WriteLine("Päivitetään tämä.");
                    item.etunimi = boxEnimi.Text;
                    item.sukunimi = boxSnimi.Text;
                    item.siirtohinta = Int32.Parse(boxHinta.Text);
                    item.seura = seuraBox.SelectedItem.ToString();
                } else {
                    Console.WriteLine("Ei päivitetä tätä.");
                }
            }
            listviewPelaajat.ItemsSource = null;
            listviewPelaajat.ItemsSource = pelaajat;
            SBTBStatus.Text = "Pelaaja tallennettu onnistuneesti.";
        }

        private void btnPoista_Click(object sender, RoutedEventArgs e) {
            try {
                int i = 0;
                foreach (var item in pelaajat) {
                    if (item.henkilotunnus == hetu) {
                        pelaajat.RemoveAt(i);
                        Console.WriteLine("Poistetaan tämä.");
                        boxEnimi.Text = "";
                        boxHinta.Text = "";
                        boxSnimi.Text = "";
                        seuraBox.SelectedIndex = -1;
                        SBTBStatus.Text = "Pelaaja poistettu onnistuneesti.";
                        listviewPelaajat.ItemsSource = null;
                        listviewPelaajat.ItemsSource = pelaajat;
                        break;
                    }
                    else {
                        Console.WriteLine("Ei poisteta tätä.");
                    }
                    i++;
                }
            }
            catch (Exception ex) {
                MessageBox.Show("Virhe poistettaessa pelaajaa: " + ex.ToString());
            }
        }

        private void btnLopeta_Click(object sender, RoutedEventArgs e) {
            Application.Current.Shutdown();
        }
    }
}
