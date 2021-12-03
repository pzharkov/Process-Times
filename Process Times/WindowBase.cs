using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Process_Times
{
    // Manages common elements and methods of all windows
    public class WindowBase : Window
    {
        private AppManager _appManager;
        private WindowBase _parentWindow;

        public AppManager appManager { get => _appManager; set => _appManager = value; }
        public WindowBase parentWindow { get => _parentWindow; set => _parentWindow = value; }


        public void TryToClose(bool needConfirmation, System.ComponentModel.CancelEventArgs closingEvent)
        {
            /*
            if (closingEvent != null)
            {
                if (needConfirmation && !CloseConfirmed())
                {
                    closingEvent.Cancel = true;
                }
            }
            else
            {
                if (needConfirmation)
                {
                    if (CloseConfirmed())
                    {
                        CloseWindow();
                    }
                }
                else
                {
                    CloseWindow();
                }
            }
            */
            AllBlank();
        }

        public void PassReference(AppManager appManagerInstance, WindowBase ownerInstance)
        {
            appManager = appManagerInstance;
            parentWindow = ownerInstance;
        }

        private bool CloseConfirmed()
        {
            MessageBoxResult result = MessageBox.Show("Confirm cancel? Any entered information will be lost.", Title, MessageBoxButton.YesNo, MessageBoxImage.Warning);
            System.Diagnostics.Debug.WriteLine("Confirm Cancel?");

            return result == MessageBoxResult.Yes;
        }

        private void CloseWindow()
        {
            parentWindow.Show();
            Close();
        }

        public static IEnumerable<T> WindowControls<T>(DependencyObject depObj) where T : DependencyObject
        {
            if (depObj != null)
            {
                foreach(object rawChild in LogicalTreeHelper.GetChildren(depObj))
                {
                    if (rawChild is DependencyObject)
                    {
                        DependencyObject child = (DependencyObject)rawChild;
                        if (child is T)
                        {
                            yield return (T)child;
                        }

                        foreach (T childOfChild in WindowControls<T>(child))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }

        private void AllBlank()
        {
            foreach (TextBox textBox in WindowControls<TextBox>(this))
            {
                System.Diagnostics.Debug.WriteLine(textBox.Text);
            }
        }
    }
}
