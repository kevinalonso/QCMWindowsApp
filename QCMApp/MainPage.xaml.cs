using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using QCMApp.Resources;
using MVVM.Views;

namespace QCMApp
{
    public partial class MainPage : MVVMPhonePage
    {
        // Constructeur
        public MainPage()
        {
            this.ViewModel = new ViewModels.ViewModelMain();
            InitializeComponent();
        }
    }
}