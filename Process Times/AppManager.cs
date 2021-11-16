using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Process_Times
{
    class AppManager
    {
        // This class calls functions from the rest of the classes based on user inputs.
        private readonly DataValidation _dataValidation = new DataValidation();
        private readonly DBManager _dbManager = new DBManager();
        private readonly Notifications _notifications = new Notifications();
        

        public void EnterData(MainWindow mainWindow)
        {
            // open a new Enter Data window, hide main window to prevent multiple windows opened at once
            
            // System.Diagnostics.Debug.WriteLine("Open Enter Data window.");

            EnterDataWindow enterDataWindow = new EnterDataWindow();
            enterDataWindow.Show();

            mainWindow.Hide();
        }

        public void ViewData()
        {
            // open View Data window
            System.Diagnostics.Debug.WriteLine("Open View Data window.");
        }

        public void About()
        {
            // open About window
            System.Diagnostics.Debug.WriteLine("Open About window.");
        }

    }
}
