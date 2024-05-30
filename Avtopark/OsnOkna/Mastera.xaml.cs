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
using NPOI.HSSF.UserModel;
using NPOI.SS.UserModel;
using NPOI.SS.Util;
using System.IO;
using Avtopark.Baza;

namespace Avtopark
{
    public partial class Mastera : Window
    {
        private DatabaseOperations dbOperations;
        private string connectionString = "Data Source=LEMAXXX\\SQLEXPRESS;Initial Catalog=prakt;Integrated Security=True;Connect Timeout=30;Encrypt=False";

        public Mastera()
        {
            InitializeComponent();
            dbOperations = new DatabaseOperations(connectionString);

            LoadData();
        }

        private void LoadData()
        {
            DataTable dataTable = GetDataTable();
            MasterGrid.ItemsSource = dataTable.DefaultView;
        }

        private DataTable GetDataTable()
        {
            DataTable dataTable1 = new DataTable();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = "SELECT Familia,Imia,Specialetet,Kont_nomer FROM Master";

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

        private void otchet(object sender, RoutedEventArgs e)
        {
            HSSFWorkbook workbook = new HSSFWorkbook();
            ISheet sheet = workbook.CreateSheet("Отчёт");

            IRow headerRow = sheet.CreateRow(0);
            headerRow.CreateCell(0).SetCellValue("Familia");
            headerRow.CreateCell(1).SetCellValue("Imia");
            headerRow.CreateCell(2).SetCellValue("Specialetet");
            headerRow.CreateCell(3).SetCellValue("Kont_nomer");

            DataTable dataTable = GetDataTable();

            for (int i = 0; i < dataTable.Rows.Count; i++)
            {
                DataRow dataRow = dataTable.Rows[i];
                IRow row = sheet.CreateRow(i);

                if (dataRow["Familia"] != DBNull.Value && dataRow["Imia"] != DBNull.Value &&
                    dataRow["Specialetet"] != DBNull.Value && dataRow["Kont_nomer"] != DBNull.Value)
                {
                    row.CreateCell(0).SetCellValue(dataRow["Familia"].ToString());
                    row.CreateCell(1).SetCellValue(dataRow["Imia"].ToString());
                    row.CreateCell(2).SetCellValue(dataRow["Specialetet"].ToString());
                    row.CreateCell(3).SetCellValue(dataRow["Kont_nomer"].ToString());
                }
            }

            using (FileStream fs = new FileStream("Отчет.xls", FileMode.Create, FileAccess.Write))
            {
                workbook.Write(fs);
            }

            MessageBox.Show("Отчёт создан успешно.");
        }

    }
}