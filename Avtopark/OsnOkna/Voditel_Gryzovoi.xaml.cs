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
    public partial class Voditel_Gryzovoi : Window
    {
        private string connectionString = "Data Source=LEMAXXX\\SQLEXPRESS;Initial Catalog=prakt;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public Voditel_Gryzovoi()
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
                string query = "SELECT Familia,Imia,Kont_nomer FROM Voditel_gryzovoiAvto";

                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);

                dataAdapter.Fill(dataTable1);
            }

            return dataTable1;
        }

        private void nazad(object sender, RoutedEventArgs e)
        {
            GryzovoiAvtomobil parkovkaWindow = new GryzovoiAvtomobil();
            parkovkaWindow.Show();
            Close(); 
        }

        private void Dobavit(object sender, RoutedEventArgs e)
        {
            Dob_Vod.Dob_Vod_Gryz parkovkaWindow = new Dob_Vod.Dob_Vod_Gryz();
            parkovkaWindow.Show();
            Close(); 
        }

    }
}