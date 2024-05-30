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

namespace Avtopark.Dob_Avt
{

    public partial class Dob_leg : Window
    {
        public Dob_leg()
        {
            InitializeComponent();
        }

        private void Dob(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LEMAXXX\\SQLEXPRESS;Initial Catalog=prakt;Integrated Security=True;Connect Timeout=30;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string Marka = MarkaBox.Text;
                string Model = ModelBox.Text;
                string Gos_nomer = GosBox.Text;
                string Mochnost_dvigatelay = MochnostBox.Text;
                string Rashod_topliva = RashodBox.Text;

                string query = "INSERT INTO Legkovoi_avto (Marka,Model,Gos_nomer,Mochnost_dvigatelay,Rashod_topliva) VALUES (@Marka,@Model,@Gos_nomer,@Mochnost_dvigatelay,@Rashod_topliva)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Marka", Marka);
                    command.Parameters.AddWithValue("@Model", Model);
                    command.Parameters.AddWithValue("@Gos_nomer", Gos_nomer);
                    command.Parameters.AddWithValue("@Mochnost_dvigatelay", Mochnost_dvigatelay);
                    command.Parameters.AddWithValue("@Rashod_topliva", Rashod_topliva);

                    command.ExecuteNonQuery();
                }
                MessageBox.Show("Данные успешно добавлены в базу данных.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void nazad(object sender, RoutedEventArgs e)
        {
            LegkovoiAvtomobil parkovkaWindow = new LegkovoiAvtomobil();
            parkovkaWindow.Show();
            Close();

        }
    }
}