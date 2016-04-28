using Microsoft.Phone.Controls;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Service
{
    /// <summary>
    ///     Contrat pour les services de navigation.
    /// </summary>
    public interface INavigationService : IService
    {
        /// <summary>
        ///     Navigue jusqu'à l'Uri spécifiée.
        /// </summary>
        /// <param name="uri">Uri à atteindre.</param>
        /// <returns>Détermine si la navigation est prise en compte.</returns>
        bool Navigate(Uri uri);

        /// <summary>
        ///     Retour à l'Uri précédente.
        /// </summary>
        void GoBack();
    }
}
