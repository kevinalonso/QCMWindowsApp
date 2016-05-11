using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM;
using MVVM.Data;
using MVVM.Service;
using QCMApp.Constant;
using MVVM.ViewModels;
using QCMApp.Interfaces;
using System.ComponentModel;
using Windows.Security.Cryptography;
using Windows.Security.Cryptography.Core;
using QCMApp.Hash;
using QCMApp.Entity;

namespace QCMApp.ViewModels
{
    public class ViewModelMain : ViewModel, IViewModelMainPage, INotifyPropertyChanged
    {
        #region Fields

        private DelegateCommand _ConnectionCommand;
        private ViewModelUser _ViewModelUser;
        private string login;
        private string password;
        private ViewModelWelcomePage _ViewModelWelcomePage;

        #endregion

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;
        protected void RaisePropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            if (handler != null) handler(this, new PropertyChangedEventArgs(name));
        }
        #endregion

        #region Properties

        public DelegateCommand ConnectionCommand => _ConnectionCommand;

        #endregion

        #region Constructors

        public ViewModelMain()
        {
            _ConnectionCommand = new DelegateCommand(ExecuteConnectionCommand, CanExecuteConnectionCommand);
        }

        #endregion

        #region Methods

        //Add InitializeProperty if there are actions in textbox

        #endregion

        #region ConnectionCommand

        private bool CanExecuteConnectionCommand(object parameter)
        {
            return true;
        }

        /// <summary>
        /// If CanExecuteConnectionCommand return true you can navigate to new windows
        /// </summary>
        /// <param name="parameter"></param>
        private void ExecuteConnectionCommand(object parameter)
        {
            _ViewModelUser = new ViewModelUser();
            IViewModelUser vUser = ((IViewModelUser)_ViewModelUser);
            vUser.ViewModelUsers.Login = this.login;
            vUser.ViewModelUsers.Password = this.password;
            vUser.ViewModelUsers.DataLoaded += (sender, args) =>
            {
                if(vUser.ViewModelUsers.ItemsSource != null)
                {
                    User user = new User();
                    user = vUser.ViewModelUsers.ItemsSource.FirstOrDefault();
                    if (this.login.Equals(user.login))
                    {
                        
                        ServiceResolver.GetService<INavigationService>().Navigate(new Uri(GlobalConstant.WINDOW_WELCOME, UriKind.Relative));
                       
                    }
                    else
                    {
                        //TODO add error Toast
                    }
                } 
            };
        }

        #endregion

        #region Get TextBox

        
        public string Logintxt
        {
            get { return this.login; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.login, value))
                {
                    this.login = value;
                    this.RaisePropertyChanged("Logintxt"); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }

        public string Passwordtxt
        {
            get { return this.password; }
            set
            {
                // Implement with property changed handling for INotifyPropertyChanged
                if (!string.Equals(this.password, value))
                {
                    this.password = value;
                    this.RaisePropertyChanged("Passwordtxt"); // Method to raise the PropertyChanged event in your BaseViewModel class...
                }
            }
        }
        #endregion
    }
}
