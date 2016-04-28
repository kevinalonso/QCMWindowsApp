using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Interfaces
{
    /// <summary>
    ///     Contrat pour les vues-modèles d'affichage d'un élément.
    /// </summary>
    /// <typeparam name="T">Type de l'élément.</typeparam>
    public interface IViewModelItem<T> : IViewModel
    {
        /// <summary>
        ///     Obtient ou définit l'élément à afficher.
        /// </summary>
        T Item { get; set; }
    }
}
