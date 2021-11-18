﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;

namespace Process_Times
{
    public class AppManager
    {
        // This class calls functions from the rest of the classes based on user inputs.
        
        private readonly DataValidation _dataValidation = new DataValidation();
        private readonly DBManager _dbManager = new DBManager();
        private readonly Notifications _notifications = new Notifications();

        private MainWindow _mainWindow = null;

        public void EnterData(MainWindow mainWindow)
        {
            // open a new Enter Data window, hide main window to prevent multiple windows opened at once
            
            System.Diagnostics.Debug.WriteLine("Open Enter Data window.");

            // create and show new window
            EnterDataWindow enterDataWindow = new EnterDataWindow();
            enterDataWindow.Show();

            // pass references
            enterDataWindow.PassReferences(this);

            // hide main window
            _mainWindow = mainWindow;
            HideMainWindow();
        }

        public void ViewData(MainWindow mainWindow)
        {
            // open View Data window
            System.Diagnostics.Debug.WriteLine("Open View Data window.");

            // create and show new window
            ViewDataWindow viewDataWindow = new ViewDataWindow();
            viewDataWindow.Show();

            // pass references
            viewDataWindow.PassReferences(this);

            // hide main window
            _mainWindow = mainWindow;
            HideMainWindow();
        }

        public void About(MainWindow mainWindow)
        {
            // open About window
            System.Diagnostics.Debug.WriteLine("Open About window.");

            // create and show new window
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.Show();

            // pass references
            aboutWindow.PassReferences(this);

            // hide main window
            _mainWindow = mainWindow;
            HideMainWindow();
        }

        public void HideMainWindow()
        {
            if (_mainWindow != null)
            {
                System.Diagnostics.Debug.WriteLine("Show Main window.");
                _mainWindow.Hide();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Main Window = null.");
            }
        }

        public void ShowMainWindow()
        {
            if (_mainWindow != null)
            {
                System.Diagnostics.Debug.WriteLine("Show Main window.");
                _mainWindow.Show();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Main Window = null.");
            }
        }

        public void ConfirmWindowClose(string windowName, CancelEventArgs e, bool isMainWindow)
        {
            if (_notifications.ConfirmCloseWindow(windowName))
            {
                System.Diagnostics.Debug.WriteLine("Close " + windowName + " window.");
                
                if (!isMainWindow)
                {
                    ShowMainWindow();
                }
            }
            else
            {
                e.Cancel = true;
                System.Diagnostics.Debug.WriteLine("Cancel Close Window.");
            }

        }

    }
}
