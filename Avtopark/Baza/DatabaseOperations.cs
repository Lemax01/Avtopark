using System;
using System.Data.SqlClient;
using System.Windows;

namespace Avtopark.Baza
{
    public class DatabaseOperations
    {
        private string connectionString;

        public DatabaseOperations(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void DeleteRecord(string tableName, string columnName, string id)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = $"DELETE FROM {tableName} WHERE {columnName} = @Id";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Id", id);
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
    }
}