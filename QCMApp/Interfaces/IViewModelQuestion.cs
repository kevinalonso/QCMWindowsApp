using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Interfaces;
using QCMApp.Entity;

namespace QCMApp.Interfaces
{
    interface IViewModelQuestion : IViewModelItem<Question>//, IViewModelItem<GoodAnswer>
    {
        IViewModelQuestions ViewModelQuestions { get; }
        //IViewModelGoodAnswers ViewModelGoodAnswers { get; }
    }
}
