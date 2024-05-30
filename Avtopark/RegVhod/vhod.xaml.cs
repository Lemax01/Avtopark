using System;
using System.Data.SqlClient;
using System.Windows;

namespace Avtopark
{
    public partial class vhod : Window
    {
        private string connectionString = "Data Source=LEMAXXX\\SQLEXPRESS;Initial Catalog=prakt;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public vhod()
        {
            InitializeComponent();
        }

        public event EventHandler IsAdminChanged;

        private bool _isAdmin;
        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                if (_isAdmin != value)
                {
                    _isAdmin = value;
                    OnIsAdminChanged();
                }
            }
        }

        protected virtual void OnIsAdminChanged()
        {
            IsAdminChanged?.Invoke(this, EventArgs.Empty);
        }

        private void Authenticate(string username, string password)
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = "SELECT IsAdmin FROM Users WHERE Login = @Username AND Parol = @Password";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
                object result = command.ExecuteScalar();
                if (result != null && result != DBNull.Value && (bool)result)
                {
                    IsAdmin = true;
                }
                else
                {
                    IsAdmin = false;
                }
            }
        }

        private void Park_Button_Click(object sender, RoutedEventArgs e)
        {
            string Login = textLogin.Text;
            string Parol = textPass.Password;

            Authenticate(Login, Parol);

            if (IsAdmin)
            {
                if (Login == "Maxim")
                {
                    ParkovkaOsn_2 parkovkaWindow = new ParkovkaOsn_2();
                    parkovkaWindow.Show();
                }
                else
                {
                    ParkovkaOsn parkovkaWindow = new ParkovkaOsn();
                    parkovkaWindow.Show();
                }
                Close();
            }
            else
            {
                MessageBox.Show("Неверные данные пользователя.");
            }
        }
    }
}