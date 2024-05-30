using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Runtime.CompilerServices;
using System.Windows;
using System.Windows.Controls;

namespace Avtopark
{
    public partial class ParkovkaOsn : Window, INotifyPropertyChanged
    {
        private string connectionString = "Data Source=LEMAXXX\\SQLEXPRESS;Initial Catalog=prakt;Integrated Security=True;Connect Timeout=30;Encrypt=False";
        private bool _isAdmin;

        public bool IsAdmin
        {
            get { return _isAdmin; }
            set
            {
                if (_isAdmin != value)
                {
                    _isAdmin = value;
                    OnPropertyChanged();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ParkovkaOsn()
        {
            InitializeComponent();
            LoadData(); 

            this.DataContext = this; 

            vhod loginWindow = new vhod();
            loginWindow.IsAdminChanged += (sender, e) =>
            {
                IsAdmin = loginWindow.IsAdmin;
            };
        }


        private void LoadData()
        {
            DataTable dataTable = GetDataTable();
            ParkovkaGrid.ItemsSource = dataTable.DefaultView;
        }

        private DataTable GetDataTable()
        {
            DataTable dataTable = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Nazvanie, Gorod, Ylica, Dom, Kont_nomer, Kont_lico FROM Parkovka";
                SqlDataAdapter dataAdapter = new SqlDataAdapter(query, connection);
                dataAdapter.Fill(dataTable);
            }

            return dataTable;
        }

        private void Click_parkovka_1(object sender, RoutedEventArgs e)
        {
            Parkovki.Parkovka1 parkovkaWindow = new Parkovki.Parkovka1();
            parkovkaWindow.Show();
            Close();
        }
    }
}