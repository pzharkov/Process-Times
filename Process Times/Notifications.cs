using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.ComponentModel;

namespace Process_Times
{
    class Notifications
    {
        // This class communicates results back to the user: success, error, etc.

        public void SuccessMessage()
        {
        }
        public void ErrorMessage()
        {
        }

        public bool ConfirmCancel(String windowName)
        {
            MessageBoxResult result = MessageBox.Show("Confirm cancel? Any entered information will be lost.", windowName, MessageBoxButton.YesNo, MessageBoxImage.Warning);
            System.Diagnostics.Debug.WriteLine("Confirm Cancel?");

            return result == MessageBoxResult.Yes;

        }

        public bool ConfirmCloseWindow(string windowName)
        {
            MessageBoxResult result = MessageBox.Show("Close Window?", windowName, MessageBoxButton.YesNo, MessageBoxImage.Warning);
            System.Diagnostics.Debug.WriteLine("Confirm Close Window?");

            return result == MessageBoxResult.Yes;
        }

    }
}
