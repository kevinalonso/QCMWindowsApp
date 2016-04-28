using MVVM.Data;
using MVVM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;

namespace MVVM.ViewModels
{
    /// <summary>
    ///     Classe de base pour les vues-modèle.
    /// </summary>
    public abstract class ViewModel : ObservableObject, IViewModel
    {
        #region Events

        /// <summary>
        ///     Se produit lorsque les données sont chargés.
        /// </summary>
        public event EventHandler DataLoaded;

        #endregion

        #region Fields

        /// <summary>
        ///     Détermine si le vue-modèle est occupé.
        /// </summary>
        private bool _IsBusy;

        #endregion

        #region Properties

        /// <summary>
        ///     Obtient ou définit si le vue-modèle est occupé.
        /// </summary>
        public bool IsBusy
        {
            get { return _IsBusy; }
            set { SetProperty(nameof(IsBusy), ref _IsBusy, value); }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Méthode de chargement des données.
        /// </summary>
        public virtual void LoadData()
        {

        }

        /// <summary>
        ///     Appelé lorsqu'une page n'est plus la page active dans une frame.
        /// </summary>
        /// <param name="viewModel">Vue-modèle de la page.</param>
        public virtual void OnNavigatedFrom(ref IViewModel viewModel)
        {

        }

        /// <summary>
        ///     Appelé lorsqu'une page devient la page active dans une frame.
        /// </summary>
        /// <param name="viewModel">Vue-modèle de la page.</param>
        public virtual void OnNavigatedTo(IViewModel viewModel)
        {

        }

        /// <summary>
        ///     Appelé juste avant qu'une page ne soit plus la page active dans une frame.
        /// </summary>
        /// <param name="uri">URI de la prochaine page.</param>
        /// <param name="cancel">Permet d'annuler la navigation.</param>
        /// <param name="isCancelable">Détermine si la navigation peut être annulée.</param>
        public virtual void OnNavigatingFrom(Uri uri, ref bool cancel, bool isCancelable)
        {

        }

        /// <summary>
        ///     Appelé lorsque l'utilisateur appuie sur le bouton Précédent situé sur le périphérique.
        /// </summary>
        /// <param name="cancel">permet d'annuler le retour arrière.</param>
        public virtual void OnBackKeyPress(ref bool cancel)
        {

        }

        /// <summary>
        ///     Déclenche l'évènement <see cref="ViewModel.DataLoaded"/>.
        /// </summary>
        protected virtual void OnDataLoaded()
        {
            DataLoaded?.Invoke(this, new EventArgs());
        }

        #endregion

    }
}
