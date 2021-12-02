using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Process_Times
{
    // Manages common elements and methods of all windows
    public class WindowBase : Window
    {
        private AppManager _appManager;
        private WindowBase _parentWindow;

        public AppManager appManager { get => _appManager; set => _appManager = value; }
        public WindowBase parentWindow { get => _parentWindow; set => _parentWindow = value; }


        public void CloseWindow(bool needConfirmation)
        {
            if (needConfirmation)
            {
                appManager.ConfirmCancel(this);
            }
            else
            {
                parentWindow.Show();
                Close();
            }
        }

        public void PassReference(AppManager appManagerInstance, WindowBase ownerInstance)
        {
            appManager = appManagerInstance;
            parentWindow = ownerInstance;
        }

    }
}
