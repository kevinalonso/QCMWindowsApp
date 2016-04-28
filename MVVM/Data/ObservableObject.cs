using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Shapes;

namespace MVVM.Data
{
    /// <summary>
    ///     Classe de base pour les objets observables.
    ///     Un objet observable est compatible avec le système de liaison de données (DataBinding).
    ///     Pour être compatible avec le système de liaison de données, il faut implémenter les interfaces <see cref="INotifyPropertyChanging"/> et <see cref="INotifyPropertyChanged"/>.
    /// </summary>
    public class ObservableObject : INotifyPropertyChanging, INotifyPropertyChanged
    {
        #region Events

        /// <summary>
        ///     Se produit lorsqu'une valeur de propriété change.
        /// </summary>
        public event PropertyChangingEventHandler PropertyChanging;

        /// <summary>
        ///     Se produit lorsqu'une valeur de propriété est modifiée.
        /// </summary>
        public event PropertyChangedEventHandler PropertyChanged;

        #endregion

        #region Fields

        /// <summary>
        ///     Liste des traqueurs de propriétés.
        /// </summary>
        private List<PropertyTrackerDependencies> _PropertyTrackerDependencies;

        /// <summary>
        ///     Liste des traqueurs de propriétés avec action.
        /// </summary>
        private List<PropertyTrackerAction> _PropertyTrackerActions;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="ObservableObject"/.>
        /// </summary>
        public ObservableObject()
        {
            InitializePropertyTrackers();
        }

        #endregion

        #region Methods

        #region PropertyTracker

        /// <summary>
        ///     Méthode de rappel pour la création des traqueurs de propriété.
        /// </summary>
        protected virtual void InitializePropertyTrackers()
        {
            _PropertyTrackerActions = new List<PropertyTrackerAction>();
            _PropertyTrackerDependencies = new List<PropertyTrackerDependencies>();
        }

        /// <summary>
        ///     Ajoute un traqueur de propriété.
        /// </summary>
        /// <param name="trackedProperty">Propriété à suivre.</param>
        /// <param name="dependentProperties">Propriétés dépendances.</param>
        public void AddPropertyTrackerDependencies(string trackedProperty, params string[] dependentProperties)
        {
            _PropertyTrackerDependencies.Add(new PropertyTrackerDependencies(trackedProperty, dependentProperties));
        }

        /// <summary>
        ///     Ajoute un traqueur de propriété avec action.
        /// </summary>
        /// <param name="trackedProperty">Propriété à suivre.</param>
        /// <param name="action">Action à déclencher.</param>
        public void AddPropertyTrackerAction(string trackedProperty, Action<object, string> action)
        {
            _PropertyTrackerActions.Add(new PropertyTrackerAction(trackedProperty, action));
        }

        #endregion

        /// <summary>
        ///     Affecte un champ et déclenche les évènements <see cref="PropertyChanging"/> et <see cref="PropertyChanged"/>.
        /// </summary>
        /// <typeparam name="T">Type du champ.</typeparam>
        /// <param name="propertyName">Nom de la propriété affectée.</param>
        /// <param name="field">Référence sur le champt à modifier.</param>
        /// <param name="newValue">Nouvelle valeur du champ.</param>
        protected void SetProperty<T>(string propertyName, ref T field, T newValue)
        {
            if (field == null && newValue != null ||
                field != null && !field.Equals(newValue))
            {
                OnPropertyChanging(propertyName);
                field = newValue;
                OnPropertyChanged(propertyName);
            }
        }

        /// <summary>
        ///     Déclenche l'évènement <see cref="ObservableObject.PropertyChanging"/>.
        /// </summary>
        /// <param name="propertyName">Nom de la propriété qui s'apprète à changer.</param>
        protected virtual void OnPropertyChanging(string propertyName)
        {
            PropertyChanging?.Invoke(this, new PropertyChangingEventArgs(propertyName));
        }

        /// <summary>
        ///     Déclenche l'évènement <see cref="ObservableObject.PropertyChanged"/>.
        /// </summary>
        /// <param name="propertyName">Nom de la propriété qui a changé.</param>
        protected virtual void OnPropertyChanged(string propertyName)
        {
            //C#5
            //PropertyChangedEventHandler handler = PropertyChanged;

            //if (handler != null)
            //{
            //    handler(this, new PropertyChangedEventArgs(propertyName));
            //}

            //C#6
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            if (_PropertyTrackerDependencies != null)
            {
                foreach (string dependentProperty in _PropertyTrackerDependencies.Where(propertyTracker => propertyTracker.TrackedProperty == propertyName).SelectMany(propertyTracker => propertyTracker.DependentProperties))
                {
                    OnPropertyChanged(dependentProperty);
                }
            }
            if (_PropertyTrackerActions != null)
            {
                foreach (PropertyTrackerAction propertyTrackerAction in _PropertyTrackerActions.Where(propertyTracker => propertyTracker.TrackedProperty == propertyName))
                {
                    propertyTrackerAction.Action(this, propertyName);
                }
            }
        }


        #endregion
    }
}
