using MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Interfaces
{
    /// <summary>
    ///     Contrat pour les pages MVVM.
    /// </summary>
    public interface IMVVMPage
    {
        /// <summary>
        ///     Obtient ou définit le vue-modèle associé à la page.
        /// </summary>
        IViewModel ViewModel { get; set; }
    }
}
