using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SQLite;
using System.Data;
using System.Windows.Controls;

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

            string _command = "INSERT INTO Data_Table (product_type, process_time) VALUES ('" + product + "', " + _roundedProcessTime + ")";
            ExecuteQuery(_command);
        }

        private void TryToCreateTable()
        {
            string _command = "CREATE TABLE IF NOT EXISTS Data_Table (id INTEGER PRIMARY KEY AUTOINCREMENT, product_type VARCHAR(1), process_time FLOAT(5,2))";
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

        public SummaryStats GetSummary()
        {
            SummaryStats _stats = new SummaryStats(CountEntries("A"), CountEntries("B"), CountEntries(null), CalculateAverage("A"), CalculateAverage("B"), CalculateAverage(null));
            return _stats;
        }
        private int CountEntries(string product)
        {
            sqlConnection.Open();
            
            SQLiteCommand _command = sqlConnection.CreateCommand();

            if (product == null)
            {
                _command.CommandText = "SELECT COUNT(id) FROM Data_Table";
            }
            else
            {
                _command.CommandText = "SELECT COUNT(id) FROM Data_Table WHERE product_type = '" + product + "'";
            }

            int _count = Convert.ToInt32(_command.ExecuteScalar());
                        
            sqlConnection.Close();
            return _count;
        }

        private float CalculateAverage(string product)
        {
            sqlConnection.Open();

            SQLiteCommand _command = sqlConnection.CreateCommand();

            if (product == null)
            {
                _command.CommandText = "SELECT AVG(process_time) FROM Data_Table";
            }
            else
            {
                _command.CommandText = "SELECT AVG(process_time) FROM Data_Table WHERE product_type = '" + product + "'";
            }
            double _result = Convert.ToDouble(_command.ExecuteScalar());

            float _average = (float)Math.Round(_result, 1);

            sqlConnection.Close();
            return _average;
        }

        public void LoadAllData(DataGrid dataGrid)
        {
            sqlConnection.Open();

            string _commandText = "SELECT * FROM Data_Table";

            SQLiteCommand _command = sqlConnection.CreateCommand();
            _command.CommandText = _commandText;

            SQLiteDataAdapter _adapter = new SQLiteDataAdapter(_command);
            DataTable _dataTable = new DataTable("Data_Table");

            _adapter.Fill(_dataTable);

            dataGrid.ItemsSource = _dataTable.DefaultView;

            sqlConnection.Close();
        }

    }
}
