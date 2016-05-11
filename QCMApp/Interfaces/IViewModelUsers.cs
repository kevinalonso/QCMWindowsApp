using MVVM.Interfaces;
using QCMApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMApp.Interfaces
{
    public interface IViewModelUsers : IViewModelList<User>
    {
        string Login { get; set; }
        string Password { get; set; }
    }
}
