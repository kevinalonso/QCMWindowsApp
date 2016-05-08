using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Interfaces;
using QCMApp.Entity;

namespace QCMApp.Interfaces
{
    interface IViewModelQuestion : IViewModelItem<Question>
    {
        IViewModelQuestions ViewModelQuestions { get; }
        IViewModelGoodAnswers ViewModelGoodAnswers { get; }
        IViewModelBadAnswers ViewModelBadAnswers { get; }
    }
}
