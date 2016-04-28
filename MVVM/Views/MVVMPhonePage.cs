using Microsoft.Phone.Controls;
using MVVM.Interfaces;
using MVVM.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Navigation;
using System.ComponentModel;

namespace MVVM.Views
{
    /// <summary>
    ///     Classe de base pour une page MVVM.
    /// </summary>
    public class MVVMPhonePage : PhoneApplicationPage, IMVVMPage
    {
        #region Properties

        /// <summary>
        ///     Obtient ou définit le vue-modèle associé à la page.
        ///     Transtype la propriété DataContext.
        /// </summary>
        public IViewModel ViewModel
        {
            get { return this.DataContext as IViewModel; }
            set { this.DataContext = value; }
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Appelé juste avant qu'une page ne soit plus la page active dans une frame.
        /// </summary>
        /// <param name="e">Objet qui contient les données d'événement.</param>
        protected override void OnNavigatingFrom(NavigatingCancelEventArgs e)
        {
            bool cancel = e.Cancel;
            this.ViewModel.OnNavigatingFrom(e.Uri, ref cancel, e.IsCancelable);
            e.Cancel = cancel;

            base.OnNavigatingFrom(e);
        }

        /// <summary>
        ///     Appelé lorsqu'une page n'est plus la page active dans une frame.
        /// </summary>
        /// <param name="e">Objet qui contient les données d'événement.</param>
        protected override void OnNavigatedFrom(NavigationEventArgs e)
        {
            base.OnNavigatedFrom(e);

            if (e.Content is IMVVMPage)
            {
                IViewModel viewModel = ((IMVVMPage)e.Content).ViewModel;
                this.ViewModel.OnNavigatedFrom(ref viewModel);
                if (((IMVVMPage)e.Content).ViewModel != viewModel)
                {
                    ((IMVVMPage)e.Content).ViewModel = viewModel;
                }
            }
        }

        /// <summary>
        ///     Appelé lorsqu'une page devient la page active dans une frame.
        /// </summary>
        /// <param name="e">Objet qui contient les données d'événement.</param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            base.OnNavigatedTo(e);

            if (e.Content is IMVVMPage)
            {
                this.ViewModel.OnNavigatedTo(((IMVVMPage)e.Content).ViewModel);
            }
        }

        /// <summary>
        ///     Appelé lorsque l'utilisateur appuie sur le bouton Précédent situé sur le périphérique.
        /// </summary>
        /// <param name="e">Appelé lorsque l'utilisateur appuie sur le bouton Précédent situé sur le périphérique.</param>
        protected override void OnBackKeyPress(CancelEventArgs e)
        {
            base.OnBackKeyPress(e);

            if (this.ViewModel != null)
            {
                bool cancel = e.Cancel;
                this.ViewModel.OnBackKeyPress(ref cancel);
                e.Cancel = cancel;
            }
        }

        #endregion
    }
}
