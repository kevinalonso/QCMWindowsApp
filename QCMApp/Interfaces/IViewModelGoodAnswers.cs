using MVVM.Interfaces;
using QCMApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMApp.Interfaces
{
    public interface IViewModelGoodAnswers : IViewModelList<GoodAnswer>
    {
        long IdQuestion { get; set; }

        GoodAnswer ItemGoodAnswer { get; set; }
    }
}
