using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;
using System.Windows.Controls;

namespace Process_Times
{
    public class AppManager
    {
        // This class calls functions from the rest of the classes based on user inputs.

        private readonly DataValidation _dataValidation = new DataValidation();
        private readonly DBManager _dbManager = new DBManager();
        private readonly Notifications _notifications = new Notifications();

        private MainWindow _mainWindow = null;

        #region Enter Data and Sub-Windows Functions       
        public void EnterData(MainWindow mainWindow)
        {
            // open a new Enter Data window, hide main window to prevent multiple windows opened at once
            System.Diagnostics.Debug.WriteLine("Open Enter Data window.");

            // create and show new window
            EnterDataWindow enterDataWindow = new EnterDataWindow();
            enterDataWindow.Show();

            // pass reference to app manager
            enterDataWindow.PassReferences(this);

            // hide main window
            _mainWindow = mainWindow;
            HideMainWindow();
        }
        
        public void ManualEntry(EnterDataWindow owner)
        {
            System.Diagnostics.Debug.WriteLine("Open Manual Entry window.");

            // create, pass reference to appmanager and show dialog
            ManualEntryWindow manualEntryWindow = new ManualEntryWindow();
            manualEntryWindow.PassReferences(this);
            manualEntryWindow.Owner = owner;
            manualEntryWindow.ShowDialog();
        }

        public void SubmitManualEntry(ManualEntryWindow manualEntryWindow, ValidEntry processTime, ValidEntry productSelected)
        {
            bool _validProcessTime = false;
            bool _validProductSelected = false;

            // validate process time

            _validProcessTime = IsValidDouble(processTime, "ENTER PROCESS TIME", "Only use positive decimal numbers.");
            _validProductSelected = IsNotNull(productSelected, "SELECT PRODUCT", "Missing selection.");

            // determine next step
            if (_validProcessTime && _validProductSelected)
            {
                // update DB

                // update UI
                manualEntryWindow.Close();
            }
        }

        public void GenerateDataSet(EnterDataWindow owner)
        {
            System.Diagnostics.Debug.WriteLine("Open Generate Data Set window.");

            // create, pass reference to appmanager and show dialog
            GenerateDataSetWindow generateDataSetWindow = new GenerateDataSetWindow();
            generateDataSetWindow.PassReferences(this);
            generateDataSetWindow.Owner = owner;
            generateDataSetWindow.ShowDialog();
            
        }

        public void SubmitGenerateDataSet(GenerateDataSetWindow generateDataSetWindow, ValidEntry numberOfEntries, ValidRange rangeA, ValidRange rangeB)
        {
            // validate
            bool _validNumberOfEntries = IsValidInt(numberOfEntries, "NUMBER OF ENTRIES", "Only use positive integers.");
            bool _validRangeA = IsValidRange(rangeA);
            bool _validRangeB = IsValidRange(rangeB);

            if (_validNumberOfEntries && _validRangeA && _validRangeB)
            {
                System.Diagnostics.Debug.WriteLine("Valid Entries. Proceed.");
            }
            // determine next step


        }

        #endregion

        #region View Data and Sub-Windows Functions
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

        public void Summary(ViewDataWindow owner)
        {
            System.Diagnostics.Debug.WriteLine("Open Summary window.");

            // create and show new window
            SummaryWindow summaryWindow = new SummaryWindow();
            
            summaryWindow.PassReferences(this, owner);
            summaryWindow.Owner = owner;
            summaryWindow.ShowDialog();            
        }

        public void AllData(ViewDataWindow owner)
        {
            System.Diagnostics.Debug.WriteLine("Open All Data window.");

            // create and show new window
            AllDataWindow allDataWindow = new AllDataWindow();

            allDataWindow.PassReferences(this, owner);
            allDataWindow.Owner = owner;
            allDataWindow.ShowDialog();
        }
        #endregion


        public void About(MainWindow mainWindow)
        {
            // open About window
            System.Diagnostics.Debug.WriteLine("Open About window.");

            // create, pass reference to app manager and show new window
            AboutWindow aboutWindow = new AboutWindow();
            aboutWindow.PassReferences(this);
            aboutWindow.Show();            

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
        public void ConfirmCancel(string windowName, ManualEntryWindow manualEntryWindow, GenerateDataSetWindow generateDataSetWindow)
        {
            if (_notifications.ConfirmCancel(windowName))
            {
                if (manualEntryWindow != null)
                {
                    manualEntryWindow.Close();
                }
                if (generateDataSetWindow != null)
                {
                    generateDataSetWindow.Close();
                }
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

        #region Validation
        private bool IsValidInt(ValidEntry entry, string validMessage, string invalidMessage)
        {
            bool _isValid = false;

            if (_dataValidation.IsValidInt(entry.entry))
            {
                entry.label.Foreground = System.Windows.Media.Brushes.Black;
                entry.label.Content = validMessage;

                _isValid = true;
            }
            else
            {
                InvalidEntry(entry.label, invalidMessage);
                _isValid = false;
            }

            return _isValid;
        }
        private bool IsValidDouble(ValidEntry entry, string validMessage, string invalidMessage)
        {
            bool _isValid = false;

            if (_dataValidation.IsValidDouble(entry.entry))
            {
                entry.label.Foreground = System.Windows.Media.Brushes.Black;
                entry.label.Content = validMessage;
            }
            else
            {
                InvalidEntry(entry.label, invalidMessage);
                _isValid = false;
            }

            return _isValid;
        
        }
        private bool IsValidRange(ValidRange range)
        {
            bool _isValid = false;

            if (_dataValidation.IsValidDouble(range.min) && _dataValidation.IsValidDouble(range.max))
            {
                if (double.Parse(range.min) > double.Parse(range.max))
                {
                    InvalidEntry(range.minLabel, "Ensure the minimum value is smaller than the maximum and vice versa.");
                }
                else
                {
                    range.minLabel.Content = "MIN";
                    range.minLabel.Foreground = System.Windows.Media.Brushes.Black;
                    range.maxLabel.Content = "MAX";
                    range.maxLabel.Foreground = System.Windows.Media.Brushes.Black;

                    _isValid = true;
                }
            }
            if (!_dataValidation.IsValidDouble(range.min))
            {
                InvalidEntry(range.minLabel, "Only use positive decimal numbers.");
            }
            if (!_dataValidation.IsValidDouble(range.max))
            {
                InvalidEntry(range.maxLabel, "Only use positive decimal numbers.");
            }            

            return _isValid;

        }
        private bool IsNotNull(ValidEntry entry, string validMessage, string invalidMessage)
        {
            bool _isValid = false;
            if (entry.entry != null)
            {
                entry.label.Foreground = System.Windows.Media.Brushes.Black;
                entry.label.Content = validMessage;

                _isValid = true;
            }
            else
            {
                InvalidEntry(entry.label, invalidMessage);
                _isValid = false;
            }

            return _isValid;
        }        
        private void InvalidEntry(Label label, string details)
        {
            label.Content = "Invalid entry: " + details;
            label.Foreground = System.Windows.Media.Brushes.Red;
            System.Diagnostics.Debug.WriteLine("Invalid entry: " + details);
        }
        #endregion
    }
}
