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

        #region Window Management Methods
        private void OpenNewWindow(WindowBase newWindow, WindowBase owner)
        {
            System.Diagnostics.Debug.WriteLine("Open " + newWindow.Title + ".");

            newWindow.PassReference(this, owner);
            newWindow.Show();
            owner.Hide();
        }
        public void About(MainWindow owner)
        {
            AboutWindow newWindow = new();
            OpenNewWindow(newWindow, owner);
        }
        public void AllData(ViewDataWindow owner)
        {
            AllDataWindow newWindow = new();
            OpenNewWindow(newWindow, owner);

            _dbManager.LoadAllData(newWindow.dataGrid);
            newWindow.UpdateHeaders();
        }
        public void EnterData(WindowBase owner)
        {
            EnterDataWindow _newWindow = new();
            OpenNewWindow(_newWindow, owner);
        }
        public void GenerateDataSet(EnterDataWindow owner)
        {
            GenerateDataSetWindow _newWindow = new();
            OpenNewWindow(_newWindow, owner);
        }
        public void ManualEntry(WindowBase owner)
        {
            ManualEntryWindow _newWindow = new();
            OpenNewWindow(_newWindow, owner);
        }
        public void Summary(WindowBase owner)
        {
            SummaryWindow newWindow = new();
            OpenNewWindow(newWindow, owner);
            newWindow.UpdateSummary(_dbManager.GetSummary());
        }
        public void ViewData(WindowBase owner)
        {
            ViewDataWindow newWindow = new();
            OpenNewWindow(newWindow, owner);
        }                
        #endregion

        #region Submit Methods
        public void SubmitManualEntry(ManualEntryWindow manualEntryWindow, EntryInput processTime, EntryInput productSelected)
        {   
            // validate

            bool _validProcessTime = IsValidFloat(processTime, "Only use positive numbers < 10,000.");
            bool _validProductSelected = IsNotNull(productSelected, "Missing selection.");
                        
            if (_validProcessTime && _validProductSelected)
            {
                System.Diagnostics.Debug.WriteLine("Valid Entries. Proceed.");
                
                // Convert
                float _processTime = float.Parse(processTime.entry);

                // update DB
                _dbManager.PrepareDatabase();
                _dbManager.AddEntry(_processTime, productSelected.entry);

                SuccessfulEntryNotification(manualEntryWindow);
            }
        }

        public void SubmitGenerateDataSet(GenerateDataSetWindow generateDataSetWindow, EntryInput numberOfEntries, RangeInput rangeA, RangeInput rangeB)
        {
            // validate
            bool _validNumberOfEntries = IsValidInt(numberOfEntries, "Only use positive integers < 10,000.");
            bool _validRangeA = IsValidRange(rangeA);
            bool _validRangeB = IsValidRange(rangeB);

            System.Diagnostics.Debug.WriteLine("Range A: min " + rangeA.min + ", max " + rangeA.max);
            System.Diagnostics.Debug.WriteLine("Range A: min " + rangeB.min + ", max " + rangeB.max);

            if (_validNumberOfEntries && _validRangeA && _validRangeB)
            {
                System.Diagnostics.Debug.WriteLine("Valid Entries. Proceed.");

                // convert strings to ints and float ranges, create an array to randomize product types
                int _numberOfEntries = Int32.Parse(numberOfEntries.entry);

                ValidRange _rangeA = new ValidRange(float.Parse(rangeA.min), float.Parse(rangeA.max));
                ValidRange _rangeB = new ValidRange(float.Parse(rangeB.min), float.Parse(rangeB.max));

                ValidRange[] _products = { _rangeA, _rangeB };

                // for each entry, randomize product type and process time based on product ranges
                for (int i = 0; i < _numberOfEntries; i++)
                {
                    Random random = new();
                    int _product = Convert.ToInt32(random.NextDouble());

                    float _processTime = GenerateRandomFloat(_products[_product].min, _products[_product].max);

                    string _productName(int _productIndex) => _productIndex == 0 ? "A" : "B";

                    _dbManager.AddEntry(_processTime, _productName(_product));
                    System.Diagnostics.Debug.WriteLine("Randomized process time: " + _processTime);
                }

                SuccessfulEntryNotification(generateDataSetWindow);
            }

        }
        #endregion
        
        #region Notifications
        public bool ConfirmCancel(WindowBase window)
        {
            return _notifications.ConfirmCancel(window.Title);
        }
        public bool ConfirmClose(WindowBase window)
        {
            return _notifications.ConfirmCloseWindow(window.Title);
        }

        private void SuccessfulEntryNotification(WindowBase window)
        {
            // notification
            _notifications.SuccessMessage("Record added.");

            // close
            window.okToClose = true;
            window.Close();
        }
        #endregion

        #region Validation Methods
        private bool IsValidInt(EntryInput entry, string invalidMessage)
        {
            bool _isValid = _dataValidation.IsValidInt(entry.entry);

            if (_isValid)
            {
                ValidEntry(entry.label);
            }
            else
            {
                InvalidEntry(entry.label, invalidMessage);
            }

            return _isValid;
        }
        private bool IsValidFloat(EntryInput entry, string invalidMessage)
        {
            bool _isValid = _dataValidation.IsValidFloat(entry.entry);

            if (_isValid)
            {
                ValidEntry(entry.label);
            }
            else
            {
                InvalidEntry(entry.label, invalidMessage);
            }

            return _isValid;
        }
        private bool IsValidRange(RangeInput range)
        {
            bool _isValid = false;

            bool _isValidMin = false;
            bool _isValidMax = false;
            
            // check min
            if (_dataValidation.IsValidFloat(range.min))
            {
                _isValidMin = true;
                ValidEntry(range.minLabel);
            }
            else
            {
                InvalidEntry(range.minLabel, "Only use positive numbers < 10,000.");
            }

            // check max
            if (_dataValidation.IsValidFloat(range.max))
            {
                _isValidMax = true;
                ValidEntry(range.maxLabel);
            }
            else
            {
                InvalidEntry(range.maxLabel, "Only use positive numbers < 10,000.");
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
        private bool IsNotNull(EntryInput entry, string invalidMessage)
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
        private float GenerateRandomFloat(float min, float max)
        {
            Random random = new Random();
            double _randomFloat = random.NextDouble() * (max - min) + min;

            return (float)_randomFloat;
        }
        public void Initialization()
        {
            // check DB, table, connection exist and create if needed
            _dbManager.PrepareDatabase();
        }
    }
}
