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

        private readonly DataValidation _dataValidation = new();
        private readonly DBManager _dbManager = new();
        private readonly Notifications _notifications = new();

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
        
        public void ManualEntry(WindowBase owner)
        {
            ManualEntryWindow _newWindow = new();
            OpenNewWindow(_newWindow, owner);
        }

        public void SubmitManualEntry(ManualEntryWindow manualEntryWindow, ValidEntry processTime, ValidEntry productSelected)
        {
            bool _validProcessTime = false;
            bool _validProductSelected = false;

            // validate process time

            _validProcessTime = IsValidDouble(processTime, "Only use positive decimal numbers.");
            _validProductSelected = IsNotNull(productSelected, "Missing selection.");

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
            GenerateDataSetWindow _newWindow = new();
            OpenNewWindow(_newWindow, owner);
        }

        public void SubmitGenerateDataSet(GenerateDataSetWindow generateDataSetWindow, ValidEntry numberOfEntries, ValidRange rangeA, ValidRange rangeB)
        {
            // validate
            bool _validNumberOfEntries = IsValidInt(numberOfEntries, "Only use positive integers.");
            bool _validRangeA = IsValidRange(rangeA);
            bool _validRangeB = IsValidRange(rangeB);

            if (_validNumberOfEntries && _validRangeA && _validRangeB)
            {
                System.Diagnostics.Debug.WriteLine("Valid Entries. Proceed.");
            }
            // determine next step


        }

        #endregion

        public void TestOpenNewWindow()
        {
            MainWindow _newWindow = new();
            OpenNewWindow(_newWindow, _newWindow);
        }
        private void OpenNewWindow(WindowBase newWindow, WindowBase owner)
        {
            System.Diagnostics.Debug.WriteLine("Open" + newWindow.Title + ".");

            newWindow.PassReference(this, owner);
            newWindow.Show();
            owner.Hide();
        }        

        #region View Data and Sub-Windows Functions
        public void ViewData(WindowBase owner)
        {
            ViewDataWindow newWindow = new();
            OpenNewWindow(newWindow, owner);
            
            // hide main window
            _mainWindow = (MainWindow)owner;
            HideMainWindow();
        }

        public void Summary(WindowBase owner)
        {
            SummaryWindow newWindow = new();
            OpenNewWindow(newWindow, owner);
        }

        public void AllData(ViewDataWindow owner)
        {
            AllDataWindow newWindow = new();
            OpenNewWindow(newWindow, owner);
        }
        #endregion

        #region About Window Functions
        public void About(MainWindow owner)
        {
            AboutWindow newWindow = new();
            OpenNewWindow(newWindow, owner);

            // hide main window
            _mainWindow = owner;
            HideMainWindow();
        }
        #endregion

        #region MainWindow Show and Hide
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
        public void HideMainWindow()
        {
            if (_mainWindow != null)
            {
                System.Diagnostics.Debug.WriteLine("Hide Main window.");
                _mainWindow.Hide();
            }
            else
            {
                System.Diagnostics.Debug.WriteLine("Main Window = null.");
            }
        }
        #endregion

        #region Notifications
        public void ConfirmCancel(WindowBase window)
        {
            if (_notifications.ConfirmCancel(window.Title))
            {
                    window.Close();                
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
        #endregion

        #region Validation
        private bool IsValidInt(ValidEntry entry, string invalidMessage)
        {
            bool _isValid = false;

            if (_dataValidation.IsValidInt(entry.entry))
            {
                ValidEntry(entry.label);

                _isValid = true;
            }
            else
            {
                InvalidEntry(entry.label, invalidMessage);
                _isValid = false;
            }

            return _isValid;
        }
        private bool IsValidDouble(ValidEntry entry, string invalidMessage)
        {
            bool _isValid = false;

            if (_dataValidation.IsValidDouble(entry.entry))
            {
                ValidEntry(entry.label);
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

            bool _isValidMin = false;
            bool _isValidMax = false;
            
            // check min
            if (_dataValidation.IsValidDouble(range.min))
            {
                _isValidMin = true;
                ValidEntry(range.minLabel);
            }
            else
            {
                InvalidEntry(range.minLabel, "Only use positive decimal numbers.");
            }

            // check max
            if (_dataValidation.IsValidDouble(range.max))
            {
                _isValidMax = true;
                ValidEntry(range.maxLabel);
            }
            else
            {
                InvalidEntry(range.maxLabel, "Only use positive decimal numbers.");
            }

            // check min < max ONLY if both are valid doubles
            if (_isValidMin && _isValidMax)
            {
                if (double.Parse(range.min) > double.Parse(range.max))
                    {
                        InvalidEntry(range.minLabel, "Ensure the minimum value is smaller than the maximum value.");
                        InvalidEntry(range.maxLabel, "Ensure the maximum value is larger than the minimum value.");
                    }
                else
                    {
                        ValidEntry(range.minLabel);
                        ValidEntry(range.maxLabel);

                        _isValid = true;
                    }
            }

            return _isValid;

        }
        private bool IsNotNull(ValidEntry entry, string invalidMessage)
        {
            bool _isValid = false;
            if (entry.entry != null)
            {
                ValidEntry(entry.label);

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

        private void ValidEntry(Label label)
        {
            label.Content = "OK";
            label.Foreground = System.Windows.Media.Brushes.Green;
        }
        #endregion
    }
}
