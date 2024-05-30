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
    public partial class ParkovkaOsn_2 : Window, INotifyPropertyChanged
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
                    UpdateButtonVisibility();
                }
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ParkovkaOsn_2()
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

        private void UpdateButtonVisibility()
        {
            btnAdd.Visibility = IsAdmin ? Visibility.Visible : Visibility.Collapsed;
            btnEdit.Visibility = IsAdmin ? Visibility.Visible : Visibility.Collapsed;
            btnDelete.Visibility = IsAdmin ? Visibility.Visible : Visibility.Collapsed;
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

        private void Dob(object sender, RoutedEventArgs e)
        {
            Admin.Dob_parkovka parkovkaWindow = new Admin.Dob_parkovka();
            parkovkaWindow.Show();
            Close();
        }

        private void Izm(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)ParkovkaGrid.SelectedItem;
            if (selectedRow != null)
            {
                string Nazvanie = selectedRow["Nazvanie"].ToString();
                string Gorod = selectedRow["Gorod"].ToString();
                string Ylica = selectedRow["Ylica"].ToString();
                string Dom = selectedRow["Dom"].ToString();
                string Kont_nomer = selectedRow["Kont_nomer"].ToString();
                string Kont_lico = selectedRow["Kont_lico"].ToString();

                if (MessageBox.Show("Вы уверены, что хотите редактировать эту строку?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    UpdateRecord(Nazvanie, Gorod, Ylica, Dom, Kont_nomer, Kont_lico);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для обновления.");
            }
        }

        private void UpdateRecord(string Nazvanie, string Gorod, string Ylica, string Dom, string Kont_nomer, string Kont_lico)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "UPDATE Parkovka SET Nazvanie=@Nazvanie, Gorod=@Gorod, Ylica=@Ylica, Dom=@Dom, Kont_nomer=@Kont_nomer, Kont_lico=@Kont_lico";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nazvanie", Nazvanie);
                        command.Parameters.AddWithValue("@Gorod", Gorod);
                        command.Parameters.AddWithValue("@Ylica", Ylica);
                        command.Parameters.AddWithValue("@Dom", Dom);
                        command.Parameters.AddWithValue("@Kont_nomer", Kont_nomer);
                        command.Parameters.AddWithValue("@Kont_lico", Kont_lico);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Строка успешно обновлена.");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось обновить строку.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении строки: " + ex.Message);
            }
        }

        private void Ydal(object sender, RoutedEventArgs e)
        {
            DataRowView selectedRow = (DataRowView)ParkovkaGrid.SelectedItem;
            if (selectedRow != null)
            {
                string id = selectedRow["Nazvanie"].ToString();
                if (MessageBox.Show("Вы уверены, что хотите удалить эту запись?", "Подтверждение", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    DeleteRecord(id);
                    LoadData();
                }
            }
            else
            {
                MessageBox.Show("Выберите строку для удаления.");
            }
        }

        private void DeleteRecord(string id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "DELETE FROM Parkovka WHERE Nazvanie = @Nazvanie";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Nazvanie", id);
                        int rowsAffected = command.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            MessageBox.Show("Запись успешно удалена.");
                        }
                        else
                        {
                            MessageBox.Show("Не удалось удалить запись.");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при удалении записи: " + ex.Message);
            }
        }

        private void K_Mastery(object sender, RoutedEventArgs e)
        {
            Mastera_2 parkovkaWindow = new Mastera_2();
            parkovkaWindow.Show();
            Close();
        }
    }
}