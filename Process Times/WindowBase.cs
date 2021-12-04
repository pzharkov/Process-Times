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


        public void TryToClose(System.ComponentModel.CancelEventArgs closingEvent)
        {
            if (AllBlank())
            {
                CloseWindow();
            }
            else
            {
                if (CloseConfirmed())
                {
                    CloseWindow();
                }
                else
                {
                    closingEvent.Cancel = true;
                }
            }
        }

        public void PassReference(AppManager appManagerInstance, WindowBase ownerInstance)
        {
            appManager = appManagerInstance;
            parentWindow = ownerInstance;

            Left = parentWindow.Left;
            Top = parentWindow.Top;
        }
        
        public void ReturnToMainWindow()
        {
            WindowBase _mainWindow = (WindowBase)parentWindow.Owner;

            parentWindow.Owner = null;
            parentWindow.Close();

            parentWindow = _mainWindow;
            Close();

        }

        private bool CloseConfirmed()
        {
            MessageBoxResult result = MessageBox.Show("Confirm cancel? Any entered information will be lost.", Title, MessageBoxButton.YesNo, MessageBoxImage.Warning);
            System.Diagnostics.Debug.WriteLine("Confirm Cancel?");

            return result == MessageBoxResult.Yes;
        }

        private void CloseWindow()
        {
            if (parentWindow != null)
            {
                parentWindow.Show();
            }
        }

        private IEnumerable<T> WindowElements<T>(DependencyObject obj) where T : DependencyObject
        {
            // search through children and children of children and return all objects of type T

            if (obj != null)
            {
                foreach(object child in LogicalTreeHelper.GetChildren(obj))
                {
                    if (child is DependencyObject)
                    {
                        if (child is T)
                        {
                            yield return (T)child;
                        }
                        
                        foreach (T childOfChild in WindowElements<T>((DependencyObject)child))
                        {
                            yield return childOfChild;
                        }
                    }
                }
            }
        }

        private bool AllBlank()
        {
            // return false if any text boxes or list boxes are not blank or have selection

            bool _allBlank = true;

            foreach (TextBox textBox in WindowElements<TextBox>(this))
            {
                if (textBox.Text != "")
                {
                    _allBlank = false;
                }
            }

            foreach (ListBox listBox in WindowElements<ListBox>(this))
            {
                if (listBox.SelectedItem != null)
                {
                    _allBlank = false;
                }
            }

            return _allBlank;
        }
    }
}
