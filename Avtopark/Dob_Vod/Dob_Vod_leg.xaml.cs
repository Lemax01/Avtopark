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


namespace Avtopark.Dob_Vod
{
  
    public partial class Dob_Vod_leg : Window
    {
        public Dob_Vod_leg()
        {
            InitializeComponent();
        }

        private void Dob(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LEMAXXX\\SQLEXPRESS;Initial Catalog=prakt;Integrated Security=True;Connect Timeout=30;Encrypt=False";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string familia = Boxfamilia.Text;
                string imia = Boximia.Text;
                string kont_nomer = Boxkont_nom.Text;

                string query = "INSERT INTO Voditel_legkovoiAvto (Familia, Imia, Kont_nomer) VALUES (@Familia, @Imia, @Kont_nomer)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Familia", familia);
                    command.Parameters.AddWithValue("@Imia", imia);
                    command.Parameters.AddWithValue("@Kont_nomer", kont_nomer);

                    command.ExecuteNonQuery();
                }

                MessageBox.Show("Данные успешно добавлены в базу данных.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
            }
        }
        private void textKontNomer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true; 
                MessageBox.Show("Пожалуйста, введите только цифры.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }

        private void nazad(object sender, RoutedEventArgs e)
        {
            Voditel_Legkovoi parkovkaWindow = new Voditel_Legkovoi();
            parkovkaWindow.Show();
            Close();
        }
    }
}





