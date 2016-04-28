using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace MVVM.Interfaces
{
    /// <summary>
    ///     Contrat de base pour les vues-modèles.
    /// </summary>
    public interface IViewModel : INotifyPropertyChanged, INotifyPropertyChanging
    {
        /// <summary>
        ///     Se produit lorsque les données sont chargés.
        /// </summary>
        event EventHandler DataLoaded;

        /// <summary>
        ///     Obtient ou définit si le vue-modèle est occupé.
        /// </summary>
        bool IsBusy { get; set; }

        /// <summary>
        ///     Méthode de chargement des données.
        /// </summary>
        void LoadData();

        /// <summary>
        ///     Appelé juste avant qu'une page ne soit plus la page active dans une frame.
        /// </summary>
        /// <param name="uri">URI de la prochaine page.</param>
        /// <param name="cancel">Permet d'annuler la navigation.</param>
        /// <param name="isCancelable">Détermine si la navigation peut être annulée.</param>
        void OnNavigatingFrom(Uri uri, ref bool cancel, bool isCancelable);

        /// <summary>
        ///     Appelé lorsqu'une page n'est plus la page active dans une frame.
        /// </summary>
        /// <param name="viewModel">Vue-modèle de la page.</param>
        void OnNavigatedFrom(ref IViewModel viewModel);

        /// <summary>
        ///     Appelé lorsqu'une page devient la page active dans une frame.
        /// </summary>
        /// <param name="viewModel">Vue-modèle de la page.</param>
        void OnNavigatedTo(IViewModel viewModel);

        /// <summary>
        ///     Appelé lorsque l'utilisateur appuie sur le bouton Précédent situé sur le périphérique.
        /// </summary>
        /// <param name="cancel">permet d'annuler le retour arrière.</param>
        void OnBackKeyPress(ref bool cancel);
    }
}
