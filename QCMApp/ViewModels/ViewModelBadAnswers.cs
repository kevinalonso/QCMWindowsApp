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
    public class ViewModelBadAnswers : ViewModelList<BadAnswer>, IViewModelBadAnswers
    {
        #region Fields

        //private static long resId = 0;
        public long IdQuestion { get; set; }

        public BadAnswer ItemBadAnswer { get; set; }

        #endregion

        #region Constructors

        public ViewModelBadAnswers()
        {
            LoadData();
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += WebClient_DownloadBadAnswerCompleted;
            wc.DownloadStringAsync(new Uri(GlobalConstant.URL_BADANSWER));
        }

        public void WebClient_DownloadBadAnswerCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string jsonstream = e.Result;

            //Get the name of array
            JObject tags = JObject.Parse(jsonstream);

            //Get data in the array from JSON
            JArray _badAnswer = (JArray)tags["badAnswers"];

            foreach (var item in _badAnswer)
            {
                BadAnswer badAnswers = new BadAnswer();
                if ((long)item[GlobalConstant.ID_QUESTION_TO_GOODANSWER] == this.IdQuestion)
                {
                    badAnswers.id = (long)item[GlobalConstant.ID_BADANSWER];
                    badAnswers.badAnswer = item[GlobalConstant.BADANSWER_NAME].ToString();
                    badAnswers.idQuestion = (long)item[GlobalConstant.ID_QUESTION_TO_BADANSWER];

                    this.ItemsSource.Add(badAnswers);
                }
            }

            OnDataLoaded();
        }

        #endregion
    }
}
