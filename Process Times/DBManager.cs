using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;

namespace Process_Times
{
    // This class is responsible for managing DB related functions.
    class DBManager
    {
        private readonly string filePath = Environment.CurrentDirectory + "\\Database.db";

        SQLiteCommand sqlCommand;
        SQLiteConnection sqlConnection;

        public void PrepareDatabase()
        {
                if (!DatabaseExists())
                {
                    SQLiteConnection.CreateFile(filePath);
                }
                if (sqlConnection == null)
                {
                    CreateConnection();
                }

                TryToCreateTable();
        }
        public void AddEntry(float processTime, string product)
        {
            float _roundedProcessTime = (float)Math.Round(processTime, 2);

            string _command = "INSERT INTO Data_Table (process_time, product_type) VALUES (" + _roundedProcessTime + ", '" + product + "')";
            ExecuteQuery(_command);
        }

        private void TryToCreateTable()
        {
            string _command = "CREATE TABLE IF NOT EXISTS Data_Table (id INTEGER PRIMARY KEY AUTOINCREMENT, process_time FLOAT(5,2), product_type VARCHAR(1))";
            ExecuteQuery(_command);
        }

        private void CreateConnection()
        {
            sqlConnection = new SQLiteConnection(string.Format("Data Source = {0};", filePath));
            sqlCommand = sqlConnection.CreateCommand();
        }

        private void ExecuteQuery(string command)
        {
            sqlConnection.Open();
            SQLiteCommand _command = sqlConnection.CreateCommand();
            _command.CommandText = command;
            _command.ExecuteNonQuery();
            
            sqlConnection.Close();
        }

        private bool DatabaseExists()
        {
            return System.IO.File.Exists(filePath);
        }
    }
}
