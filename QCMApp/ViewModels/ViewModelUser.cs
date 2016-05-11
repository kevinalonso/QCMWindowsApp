using MVVM.ViewModels;
using QCMApp.Entity;
using QCMApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMApp.ViewModels
{
    public class ViewModelUser : ViewModelItem<User>, IViewModelUser
    {
        #region Fields

        private ViewModelUsers _ViewModelUsers;

        #endregion

        #region Properties
        public IViewModelUsers ViewModelUsers => _ViewModelUsers;
        #endregion

        #region Constructors

        public ViewModelUser()
        {
            _ViewModelUsers = new ViewModelUsers();
           
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            _ViewModelUsers.LoadData();
        }

        #endregion
    }
}
