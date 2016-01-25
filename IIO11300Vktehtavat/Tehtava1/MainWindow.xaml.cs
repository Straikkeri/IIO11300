/*
* Copyright (C) JAMK/IT/Esa Salmikangas
* This file is part of the IIO11300 course project.
* Created: 12.1.2015
* Authors: Aleksi Tommila, Esa Salmikangas
*/using System;
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

namespace Tehtava1
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void btnCalculate_Click(object sender, RoutedEventArgs e)
        {
            //TODO
            try{
                tulosPA.Text = Convert.ToString(Double.Parse(boxWinHeight.Text) * Double.Parse(boxWinWidth.Text));
                tulosKP.Text = Convert.ToString((Double.Parse(boxWinWidth.Text) + Double.Parse(boxSideWidth.Text)*2)*2 + Double.Parse(boxWinHeight.Text)*2);
                tulosKPA.Text = Convert.ToString(Double.Parse(boxWinHeight.Text) * Double.Parse(boxSideWidth.Text) + ((Double.Parse(boxWinWidth.Text) + Double.Parse(boxSideWidth.Text) * 2) * Double.Parse(boxSideWidth.Text)) * 2);
            }
            catch (Exception ex){
               MessageBox.Show(ex.Message);
            }
            finally{
                //yield to a user that everything okay
            }  
        }

        private void btnClose_Click(object sender, RoutedEventArgs e){

        }

        private void btnCalculateArea00_Click(object sender, RoutedEventArgs e) {
            JAMK.IT.IIO11300.Ikkuna ikk = new JAMK.IT.IIO11300.Ikkuna();
            ikk.Korkeus = double.Parse(boxWinHeight.Text);
            ikk.Leveys = double.Parse(boxWinWidth.Text);
            //MessageBox.Show(ikk.LaskePintaAla().ToString());
            MessageBox.Show(ikk.PintaAla.ToString());
        }
    }

    public class BusinessLogicWindow {
            
    }
}
