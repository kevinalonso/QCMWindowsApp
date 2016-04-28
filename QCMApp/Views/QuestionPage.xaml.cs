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

namespace QCMApp.Views
{
    public partial class QuestionPage : MVVMPhonePage
    {
        public QuestionPage()
        {
            this.ViewModel = new ViewModelQuestion();
            //this.ViewModel = new ViewModelGoodAnswers();
            InitializeComponent();
        }

    }
}