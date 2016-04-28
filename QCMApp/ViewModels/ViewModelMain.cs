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

namespace QCMApp.ViewModels
{
    public class ViewModelMain : ViewModel, IViewModelMainPage
    {
        #region Fields

        private DelegateCommand _ConnectionCommand;

        #endregion

        #region Properties

        public DelegateCommand ConnectionCommand => _ConnectionCommand;

        #endregion

        #region Constructors

        public ViewModelMain()
        {
            _ConnectionCommand = new DelegateCommand(ExecuteConnectionCommand,CanExecuteConnectionCommand);
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
            ServiceResolver.GetService<INavigationService>().Navigate(new Uri(GlobalConstant.WINDOW_WELCOME, UriKind.Relative));
        }

        #endregion
    }
}
