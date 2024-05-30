using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace Avtopark.Admin
{
    public partial class Dob_parkovka : Window
    {
        public Dob_parkovka()
        {
            InitializeComponent();
        }

        private void Dob(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LEMAXXX\\SQLEXPRESS;Initial Catalog=prakt;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string Nazvanie = textNazv.Text;
                string Gorod = textGorod.Text;
                string Ylica = textYlica.Text;
                string Dom = textDom.Text;
                int Kont_nomer;
                if (int.TryParse(textKontNomer.Text, out Kont_nomer))
                {
                    string Kont_lico = textKontLico.Text;

                    string query = "INSERT INTO Parkovka (Nazvanie, Gorod, Ylica, Dom, Kont_nomer, Kont_lico) VALUES (@Nazvanie, @Gorod, @Ylica, @Dom, @Kont_nomer, @Kont_lico)";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nazvanie", Nazvanie);
                        command.Parameters.AddWithValue("@Gorod", Gorod);
                        command.Parameters.AddWithValue("@Ylica", Ylica);
                        command.Parameters.AddWithValue("@Dom", Dom);
                        command.Parameters.AddWithValue("@Kont_nomer", Kont_nomer);
                        command.Parameters.AddWithValue("@Kont_lico", Kont_lico);
                        command.ExecuteNonQuery();
                    }
                    MessageBox.Show("Данные успешно добавлены в базу данных.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                }
                else
                {
                    MessageBox.Show("Пожалуйста, введите только цифры в поле 'Контактный номер'.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void nazad(object sender, RoutedEventArgs e)
        {
            ParkovkaOsn parkovkaWindow = new ParkovkaOsn();
            parkovkaWindow.Show();
            Close();
        }

        private void textKontNomer_PreviewTextInput(object sender, TextCompositionEventArgs e)
        {
            if (!char.IsDigit(e.Text, e.Text.Length - 1))
            {
                e.Handled = true; 
                MessageBox.Show("Пожалуйста, введите только цифры.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
            }
        }
    }
}
