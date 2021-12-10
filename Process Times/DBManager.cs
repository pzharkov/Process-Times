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
        private readonly string filePath = Environment.CurrentDirectory + "\\Database\\Database.db";

        public void AddEntry(float processTime, string product)
        {
        }

        public void CreateDatabase()
        {
            if (DatabaseExists())
            {
                //do nothing
                System.Diagnostics.Debug.WriteLine("Database file already exists.");
            }
            else
            {
                // create database
                SQLiteConnection.CreateFile(filePath);
            }
        }

        private bool DatabaseExists()
        {
            return System.IO.File.Exists(filePath);
        }
    }
}
