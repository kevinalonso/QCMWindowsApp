using MVVM.ViewModels;
using Newtonsoft.Json.Linq;
using QCMApp.Constant;
using QCMApp.Entity;
using QCMApp.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace QCMApp.ViewModels
{
    public class ViewModelUsers : ViewModelList<User>, IViewModelUsers
    {
        #region Fields
        public string Login { get; set; }
        public string Password { get; set; }

        #endregion

        #region Constructors

        public ViewModelUsers()
        {
            LoadData();
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += WebClient_DownloadUsersCompleted;
            wc.DownloadStringAsync(new Uri(GlobalConstant.URL_USER));

        }

        public void WebClient_DownloadUsersCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string jsonstream = e.Result;

            //Get the name of array
            JObject tags = JObject.Parse(jsonstream);

            //Get data in the array from JSON
            JArray _user = (JArray)tags["users"];

            foreach (var item in _user)
            {
                User user = new User();
                if (item[GlobalConstant.USER_LOGIN].ToString().Equals(this.Login) && item[GlobalConstant.USER_PASS].ToString().Equals(this.Password))
                {
                    user.id = (long)item[GlobalConstant.ID_USER];
                    user.login = item[GlobalConstant.USER_LOGIN].ToString();

                    this.ItemsSource.Add(user);
                }
            }

            OnDataLoaded();
        }

        #endregion
    }
}
