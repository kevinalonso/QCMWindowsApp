using MVVM.Interfaces;
using QCMApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMApp.Interfaces
{
    public interface IViewModelBadAnswer : IViewModelItem<BadAnswer>
    {
        IViewModelBadAnswers ViewModelBadAnswers { get; }
    }
}
