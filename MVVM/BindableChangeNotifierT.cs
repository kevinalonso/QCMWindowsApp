using MVVM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM
{
    /// <summary>
    ///     Encapsule un objet non observable pour le rendre observable.
    /// </summary>
    /// <typeparam name="T">Type de l'objet à encapsuler.</typeparam>
    public sealed class BindableChangeNotifier<T> : ObservableObject
    {
        #region Fields

        /// <summary>
        ///     Instance de l'objet encapsulée.
        /// </summary>
        private T _Instance;

        #endregion

        #region Properties

        /// <summary>
        ///     Obtient l'instance de l'objet encapsulée.
        /// </summary>
        public T Instance => _Instance;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="BindableChangeNotifier{T}"/>.
        /// </summary>
        /// <param name="instance">Instance de l'objet à encapsuler.</param>
        public BindableChangeNotifier(T instance)
        {
            _Instance = instance;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Déclenche l'évènement <see cref="ObservableObject.PropertyChanged"/> pour l'ensemble des propriétés.
        /// </summary>
        public void OnPropertyChanged()
        {
            OnPropertyChanged("");
        }

        #endregion
    }
}
