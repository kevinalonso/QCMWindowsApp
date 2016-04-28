using MVVM.Data;
using MVVM.Interfaces;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    /// <summary>
    ///     Vue-modèle pour représenter une liste d'objet.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ViewModelList<T> : ViewModel, IViewModelList<T>
    {
        #region Fields

        /// <summary>
        ///     Collection pour la source de données.
        /// </summary>
        private ObservableCollection<T> _ItemsSource;

        /// <summary>
        ///     Instance de l'élément sélectionné dans la liste.
        /// </summary>
        private T _SelectedItem;

        /// <summary>
        ///     Commande pour ajouter un élément dans la liste.
        /// </summary>
        private DelegateCommand _AddItemCommand;

        #endregion

        #region Properties

        /// <summary>
        ///     Obtient ou définit la collection pour la source de données.
        /// </summary>
        public ObservableCollection<T> ItemsSource
        {
            get { return _ItemsSource; }
            set { SetProperty(nameof(ItemsSource), ref _ItemsSource, value); }
        }

        /// <summary>
        ///     Obtient ou définit l'instance de l'élément sélectionné dans la liste.
        /// </summary>
        public T SelectedItem
        {
            get { return _SelectedItem; }
            set { SetProperty(nameof(SelectedItem), ref _SelectedItem, value); }
        }

        /// <summary>
        ///     Obtient la commande pour ajouter un élément dans la liste.
        /// </summary>
        public DelegateCommand AddItemCommand => _AddItemCommand;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="ViewModelList{T}"/>.
        /// </summary>
        public ViewModelList()
        {
            ItemsSource = new ObservableCollection<T>();

            _AddItemCommand = new DelegateCommand(ExecuteAddItem, CanExecuteAddItem);
        }

        #endregion

        #region Methods

        #region AddItemCommand

        /// <summary>
        ///     Méthode de test de la commande AddItem.
        ///     Par défaut, la commande est désactivée.
        /// </summary>
        /// <param name="parameter">Paramètre de la commande.</param>
        /// <returns>Détermine si la commande peut être exécutée ou non.</returns>
        protected virtual bool CanExecuteAddItem(object parameter)
        {
            return false;
        }

        /// <summary>
        ///     Méthode d'exécution de la commande AddItem.
        /// </summary>
        /// <param name="parameter">Paramètre de la commande.</param>
        protected virtual void ExecuteAddItem(object parameter)
        {

        }

        #endregion

        #endregion
    }
}
