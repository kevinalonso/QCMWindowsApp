using MVVM.Interfaces;
using QCMApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMApp.Interfaces
{
    public interface IViewModelBadAnswers : IViewModelList<BadAnswer>
    {
        long IdQuestion { get; set; }
        BadAnswer ItemBadAnswer { get; set; }
    }
}
