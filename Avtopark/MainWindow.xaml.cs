using System;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows;
using System.Windows.Media;

namespace Avtopark
{
    public partial class MainWindow : Window
    {
        private string connectionString = "Data Source=LEMAXXX\\SQLEXPRESS;Initial Catalog=prakt;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_Click_vhod(object sender, RoutedEventArgs e)
        {
            vhod otherWindow = new vhod();
            otherWindow.Show();
            this.Close();
        }

        private void Button_Click_Reg(object sender, RoutedEventArgs e)
        {
            string login = textLogin.Text.Trim();
            string pass = textPass.Password.Trim();
            string pass1 = textPass1.Password.Trim();

            if (login.Length < 5)
            {
                textLogin.ToolTip = "Логин слишком короткий. Попробуйте ещё раз";
                textLogin.Background = Brushes.Red;
                return;
            }

            if (!Regex.IsMatch(pass, @"^(?=.*[a-z])(?=.*\d)(?=.*[!@#$%^]).{6,}$"))
            {
                textPass.ToolTip = "Пароль не соответствует требованиям. Попробуйте ещё раз";
                textPass.Background = Brushes.Red;
                return;
            }

            if (pass1 != pass)
            {
                textPass1.ToolTip = "Пароль не совпадает. Попробуйте ещё раз";
                textPass1.Background = Brushes.Red;
                return;
            }

            textLogin.ToolTip = " ";
            textLogin.Background = Brushes.Transparent;
            textPass.ToolTip = " ";
            textPass.Background = Brushes.Transparent;
            textPass1.ToolTip = " ";
            textPass1.Background = Brushes.Transparent;


            string ConnectionString = "Data Source=LEMAXXX\\SQLEXPRESS;Initial Catalog=prakt;Integrated Security=True;Connect Timeout=30;Encrypt=False";
            string username = textLogin.Text;
            string password = textPass.Password; 
            string repeatPassword = textPass1.Password;

            if (password != repeatPassword)
            {
                MessageBox.Show("Пароли не совпадают. Пожалуйста, введите одинаковые пароли.");
                return;
            }

            using (SqlConnection connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                string query = "INSERT INTO Users (Login, Parol) VALUES (@Login, @Parol)";
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@Login", username);
                    command.Parameters.AddWithValue("@Parol", password);
                    int result = command.ExecuteNonQuery();
                    if (result > 0)
                    {
                        System.Windows.MessageBox.Show("Пользователь успешно зарегистрирован.", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);

                    }
                    else
                    {
                        System.Windows.MessageBox.Show("Произошла ошибка при регистрации пользователя.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);

                    }
                }
            }
            ParkovkaOsn otherWindow = new ParkovkaOsn();
            otherWindow.Show();
            this.Close();
        }
    }
}