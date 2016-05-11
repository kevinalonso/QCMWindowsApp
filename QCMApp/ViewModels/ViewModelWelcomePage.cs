using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QCMApp.Entity;
using MVVM.ViewModels;
using MVVM.Service;
using MVVM.Interfaces;
using QCMApp.Constant;
using System.Net;
using Newtonsoft.Json;
using QCMApp.Interfaces;
using Newtonsoft.Json.Linq;
using System.Windows.Controls;

namespace QCMApp.ViewModels
{
    public class ViewModelWelcomePage : ViewModelList<Qcm>, IViewModelWelcomePage
    {
        #region Field

        private ViewModelGoodAnswer _ViewModelGoodAnswer;
        private ViewModelBadAnswer _ViewModelBadAnswer;


        #endregion

        #region Properties

        #endregion

        #region Constructors

        public ViewModelWelcomePage()
        {
            LoadData();

        }

        #endregion

        #region Methods
        public override void LoadData()
        {
            //Progress bar is busy
            IsBusy = true;

            WebClient wc = new WebClient();
            wc.DownloadStringCompleted += WebClient_DownloadQcmCompleted;
            wc.DownloadStringAsync(new Uri(GlobalConstant.URL_QCM));

        }

        public void WebClient_DownloadQcmCompleted(object sender, DownloadStringCompletedEventArgs e)
        {
            string jsonstream = e.Result;
            //Get the name of array
            JObject tags = JObject.Parse(jsonstream);

            //Get data in the array from JSON
            JArray _qcm = (JArray)tags["qcm"];

            foreach(var item in _qcm)
            {
                Qcm qcms = new Qcm();

                qcms.id = (long)item[GlobalConstant.ID];
                qcms.nameQcm = item[GlobalConstant.NAME_QCM].ToString();
                qcms.dateStart = item[GlobalConstant.DATE_START].ToString();
                qcms.dateEnd = item[GlobalConstant.DATE_END].ToString();
                qcms.isActive = (bool)item[GlobalConstant.ID];

                this.ItemsSource.Add(qcms);
         
            }
            
            System.Windows.Deployment.Current.Dispatcher.BeginInvoke(() =>
            {
                //Progress bar in not occuped
                IsBusy = false;
            });
        }

        protected override void InitializePropertyTrackers()
        {
            base.InitializePropertyTrackers();

            this.AddPropertyTrackerAction(nameof(SelectedItem), (sender, args) =>
            {
                if (SelectedItem != null)
                {
                    ServiceResolver.GetService<INavigationService>().Navigate(new Uri(GlobalConstant.WINDOWS_QUESTION, UriKind.Relative));
                    
                }
            });
        }
        #endregion

        #region Navigation

        public override void OnNavigatedTo(IViewModel viewModel)
        {
            base.OnNavigatedTo(viewModel);
        }

        /// <summary>
        /// Id transfer in other window
        /// </summary>
        /// <param name="viewModel"></param>
        public override void OnNavigatedFrom(ref IViewModel viewModel)
        {
            base.OnNavigatedFrom(ref viewModel);

            if(viewModel is IViewModelQuestion)
            {
                IViewModelQuestion vm = ((IViewModelQuestion)viewModel);
               
                vm.ViewModelQuestions.IdQuestion = this.SelectedItem.id;

                _ViewModelGoodAnswer = new ViewModelGoodAnswer();
                IViewModelGoodAnswer vGoodAnswer = ((IViewModelGoodAnswer)_ViewModelGoodAnswer);

                _ViewModelBadAnswer = new ViewModelBadAnswer();
                IViewModelBadAnswer vBadAnswer = ((IViewModelBadAnswer)_ViewModelBadAnswer);
                
                
                vGoodAnswer.ViewModelGoodAnswers.IdQuestion = vm.ViewModelQuestions.IdQuestion;
                vBadAnswer.ViewModelBadAnswers.IdQuestion = vm.ViewModelQuestions.IdQuestion;
                
                vm.ViewModelQuestions.DataLoaded += (sender, args) =>
                {
                    vm.Item = vm.ViewModelQuestions.ItemsSource.FirstOrDefault();
                    
                };

                vGoodAnswer.ViewModelGoodAnswers.DataLoaded += (sender, args) =>
                {
                   
                    vm.Item.goodAnswer = vGoodAnswer.ViewModelGoodAnswers.ItemsSource.FirstOrDefault();
                };

                vBadAnswer.ViewModelBadAnswers.DataLoaded += (sender, args) =>
                {
                    vm.Item.badAnswer1 = vBadAnswer.ViewModelBadAnswers.ItemsSource.FirstOrDefault();
                    vm.Item.badAnswer2 = vBadAnswer.ViewModelBadAnswers.ItemsSource.LastOrDefault();

                };

                
            }
        }

        #endregion

    }
}
