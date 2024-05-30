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

namespace Avtopark.Parkovki
{
 
    public partial class Parkovka1 : Window
    {
        public Parkovka1()
        {
            InitializeComponent();
        }

        private void Exit(object sender, RoutedEventArgs e)
        {
            ParkovkaOsn parkovkaWindow = new ParkovkaOsn();
            parkovkaWindow.Show();
            Close(); 
        }

        private void Legkovoi(object sender, RoutedEventArgs e)
        {
            LegkovoiAvtomobil parkovkaWindow1 = new LegkovoiAvtomobil();
            parkovkaWindow1.Show();
            Close();
        }
        private void Gryzovoi(object sender, RoutedEventArgs e)
        {
            GryzovoiAvtomobil parkovkaWindow1 = new GryzovoiAvtomobil();
            parkovkaWindow1.Show();
            Close(); 
        }
    }
}
