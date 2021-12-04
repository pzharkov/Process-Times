﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Process_Times
{
    public partial class AllDataWindow : WindowBase
    {
        private ViewDataWindow _owner = null;

        public AllDataWindow()
        {
            InitializeComponent();
        }

        private void MainWindowClick(object sender, RoutedEventArgs e)
        {
            _owner.Close();
            appManager.ShowMainWindow();

            Close();
        }

        private void BackClick(object sender, RoutedEventArgs e)
        {
            Close();
        }
    }
}
