using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QCMApp.Entity;
using MVVM.Interfaces;

namespace QCMApp.Interfaces
{
    public interface IViewModelQuestions : IViewModelList<Question>
    {
        long IdQuestion { get; set; }
        Question ItemQuestion { get; set; }
    }

    /*public interface IViewModelTest : IViewModelList<GoodAnswer>
    {
        GoodAnswer ItemGoodAnswer { get; set; }
    }*/
}
