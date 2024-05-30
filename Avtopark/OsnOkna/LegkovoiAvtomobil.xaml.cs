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
using System.Windows.Shapes;

namespace Avtopark
{
    public partial class LegkovoiAvtomobil : Window
    {
        private string connectionString = "Data Source=LEMAXXX\\SQLEXPRESS;Initial Catalog=prakt;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public LegkovoiAvtomobil()
        {
            InitializeComponent();

            DataTable dataTable = GetDataTable();

            LegkovoiGrid.ItemsSource = dataTable.DefaultView;



        }

        private DataTable GetDataTable()
        {
            DataTable dataTable1 = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Marka,Model,Gos_nomer,Mochnost_dvigatelay,Rashod_topliva FROM Legkovoi_Avto";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                dataAdapter.Fill(dataTable1);
            }

            return dataTable1;
        }
        private void nazad(object sender, RoutedEventArgs e)
        {
            Parkovki.Parkovka1 parkovkaWindow = new Parkovki.Parkovka1();
            parkovkaWindow.Show();
            Close(); 
        }

        private void O_Voditele(object sender, RoutedEventArgs e)
        {
            Voditel_Legkovoi parkovkaWindow = new Voditel_Legkovoi();
            parkovkaWindow.Show();
            Close(); 
        }

        private void O_Mastere(object sender, RoutedEventArgs e)
        {
            Mastera parkovkaWindow = new Mastera();
            parkovkaWindow.Show();
            Close(); 
        }

        private void Dob(object sender, RoutedEventArgs e)
        {
            Dob_Avt.Dob_leg parkovkaWindow = new Dob_Avt.Dob_leg();
            parkovkaWindow.Show();
            Close(); 
        }
    }
}
