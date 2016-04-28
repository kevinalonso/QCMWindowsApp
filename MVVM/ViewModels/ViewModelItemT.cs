using MVVM.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.ViewModels
{
    /// <summary>
    ///     Vue-modèle pour afficher un élément.
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class ViewModelItem<T> : ViewModel, IViewModelItem<T>
    {
        #region Fields

        /// <summary>
        ///     Instance de l'élément à afficher.
        /// </summary>
        private T _Item;

        #endregion

        #region Properties

        /// <summary>
        ///     Obtient ou définit l'élément à afficher.
        /// </summary>
        public T Item
        {
            get { return _Item; }
            set { SetProperty(nameof(Item), ref _Item, value); }
        }

        #endregion
    }
}
