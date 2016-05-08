using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.ViewModels;
using QCMApp.Entity;
using QCMApp.Interfaces;
using System.Net;
using QCMApp.Constant;
using Newtonsoft.Json.Linq;
using MVVM.Interfaces;

namespace QCMApp.ViewModels
{
    public class ViewModelQuestions : ViewModelList<Question>, IViewModelQuestions
    {
        #region Fields

        //private static long resId = 0;
        public long IdQuestion { get; set; }

        public Question ItemQuestion { get;set;}

        public List<GoodAnswer> ListGoodAnswers;


        #endregion

        #region Constructors

        public ViewModelQuestions()
        {
            LoadData();
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += WebClient_DownloadQuestionCompleted;
            wc.DownloadStringAsync(new Uri(GlobalConstant.URL_QUESTION));

        }

        public void WebClient_DownloadQuestionCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string jsonstream = e.Result;
            
            //Get the name of array
            JObject tags = JObject.Parse(jsonstream);

            //Get data in the array from JSON
            JArray _question = (JArray)tags["questions"];

            foreach (var item in _question)
            {
                Question questions = new Question();
                if((long)item[GlobalConstant.ID_QCM_TO_QUESTION] == this.IdQuestion)
                {
                    questions.id = (long)item[GlobalConstant.ID_QUESTION];
                    questions.textQuestion = item[GlobalConstant.QUESTION_NAME].ToString();
                    questions.idQcm = (long)item[GlobalConstant.ID_QCM_TO_QUESTION];

                    this.ItemsSource.Add(questions);
                }
            }

            OnDataLoaded();
            //_ViewModelGoodAnswers.LoadData();
        }

        #endregion
    }
}
