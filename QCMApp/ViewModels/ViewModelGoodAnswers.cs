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
    public class ViewModelGoodAnswers : ViewModelList<GoodAnswer>, IViewModelGoodAnswers
    {
        #region Fields

        //private static long resId = 0;
        public long IdQuestion { get; set; }

        public GoodAnswer ItemGoodAnswer { get; set; }

        #endregion

        #region Constructors

        public ViewModelGoodAnswers()
        {
            LoadData();
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += WebClient_DownloadQuestionCompleted;
            wc.DownloadStringAsync(new Uri(GlobalConstant.URL_GOODANSWER));
        }

        public void WebClient_DownloadQuestionCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string jsonstream = e.Result;
            
            //Get the name of array
            JObject tags = JObject.Parse(jsonstream);

            //Get data in the array from JSON
            JArray _goodAnswer = (JArray)tags["goodAnswers"];

            foreach (var item in _goodAnswer)
            {
                GoodAnswer goodAnswers = new GoodAnswer();
                if((long)item[GlobalConstant.ID_QUESTION_TO_GOODANSWER] == this.IdQuestion)
                {
                    goodAnswers.id = (long)item[GlobalConstant.ID_GOODANSWER];
                    goodAnswers.answerQuestion= item[GlobalConstant.GOODANSWER_NAME].ToString();
                    goodAnswers.idQuestion = (long)item[GlobalConstant.ID_QUESTION_TO_GOODANSWER];

                    this.ItemsSource.Add(goodAnswers);
                }
            }

            OnDataLoaded();
        }

        #endregion
    }
}
