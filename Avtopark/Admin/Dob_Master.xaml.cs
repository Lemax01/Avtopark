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

namespace Avtopark.Admin
{

    public partial class Dob_Master : Window
    {
        public Dob_Master()
        {
            InitializeComponent();
        }


        private void Dob(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=LEMAXXX\\SQLEXPRESS;Initial Catalog=prakt;Integrated Security=True;Connect Timeout=30;Encrypt=False";

            if (string.IsNullOrWhiteSpace(textFamilia.Text) || string.IsNullOrWhiteSpace(textImia.Text) ||
                string.IsNullOrWhiteSpace(textSpec.Text) || string.IsNullOrWhiteSpace(textNom.Text))
            {
                MessageBox.Show("Пожалуйста, заполните все поля перед добавлением данных.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                return;
            }

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                string familia = textFamilia.Text;
                string imia = textImia.Text;
                string specialitet = textSpec.Text;
                string kont_nomer = textNom.Text;

                string query = "INSERT INTO Master (Familia, Imia, Specialetet, Kont_nomer) VALUES (@Familia, @Imia, @Specialetet, @Kont_nomer)";

                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Familia", familia);
                    command.Parameters.AddWithValue("@Imia", imia);
                    command.Parameters.AddWithValue("@Specialetet", specialitet);
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
        private void textFamilia_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text) || !textBox.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Пожалуйста, введите хотя бы одну букву в фамилии.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Handled = true;
            }
        }
        private void textImia_TextChanged(object sender, TextChangedEventArgs e)
        {
            TextBox textBox = sender as TextBox;
            if (string.IsNullOrWhiteSpace(textBox.Text) || !textBox.Text.Any(char.IsLetter))
            {
                MessageBox.Show("Пожалуйста, введите хотя бы одну букву в имени.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                e.Handled = true; 
            }
        }
        private void nazad(object sender, RoutedEventArgs e)
            {
                Mastera_2 parkovkaWindow = new Mastera_2();
                parkovkaWindow.Show();
                Close(); 
            }
        }
    }






