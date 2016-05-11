using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Data;

namespace QCMApp.Entity
{
    public class User : ObservableObject
    {
        #region Fields
        private long _id;

        private string _login;
        #endregion

        #region Properties
        public long id
        {
            get { return _id; }
            set { SetProperty(nameof(id), ref _id, value); }
        }

        public string login
        {
            get { return _login; }
            set { SetProperty(nameof(login), ref _login, value); }
        }
        #endregion

        #region Methods

        public override string ToString()
        {
            return login;
        }

        #endregion

    }
}
