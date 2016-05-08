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
    public class ViewModelBadAnswer : ViewModelItem<BadAnswer>, IViewModelBadAnswer
    {
        #region Fields

        private ViewModelBadAnswers _ViewModelBadAnswers;

        #endregion

        #region Properties

        public IViewModelBadAnswers ViewModelBadAnswers => _ViewModelBadAnswers;
        #endregion

        public ViewModelBadAnswer()
        {
            _ViewModelBadAnswers = new ViewModelBadAnswers();

        }

        public override void LoadData()
        {
            _ViewModelBadAnswers.LoadData();
        }
    }
}
