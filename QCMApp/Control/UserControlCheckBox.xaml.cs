using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using MVVM.Views;
using QCMApp.ViewModels;

namespace QCMApp.Control
{
    public partial class UserControlCheckBox : MVVMPhonePage
    {
        public UserControlCheckBox()
        {
            //this.ViewModel = new ViewModelGoodAnswer();
            InitializeComponent();
        }
    }
}
