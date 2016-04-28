using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Interfaces
{
    /// <summary>
    ///     Contrat pour les vues-modèles d'affichage d'une liste.
    /// </summary>
    /// <typeparam name="T">Type des éléments de la liste.</typeparam>
    public interface IViewModelList<T> : IViewModel
    {
        /// <summary>
        ///     Obtient ou définit l'élément sélectionné dans la liste.
        /// </summary>
        T SelectedItem { get; set; }

        /// <summary>
        ///     Obtient ou définit la source de données de la liste.
        /// </summary>
        ObservableCollection<T> ItemsSource { get; set; }

        /// <summary>
        ///     Obtient la commande pour ajouter un élément dans la liste.
        /// </summary>
        DelegateCommand AddItemCommand { get; }

    }
}
