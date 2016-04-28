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
    public class ViewModelGoodAnswer : ViewModelItem<GoodAnswer>, IViewModelGoodAnswer
    {
        #region Fields

        private ViewModelGoodAnswers _ViewModelGoodAnswers;

        #endregion

        #region Properties

        public IViewModelGoodAnswers ViewModelGoodAnswers => _ViewModelGoodAnswers;
        #endregion

        public ViewModelGoodAnswer()
        {
            _ViewModelGoodAnswers = new ViewModelGoodAnswers();
           
        }

        public override void LoadData()
        {

            _ViewModelGoodAnswers.LoadData();
        }
    }
}
