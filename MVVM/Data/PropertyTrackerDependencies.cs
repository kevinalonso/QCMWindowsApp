using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVM.Data
{
    /// <summary>
    ///     Traqueur de propriété qui redéclenche l'évènement <see cref="ObservableObject.PropertyChanged"/> pour les propriétés dépendantes lorsque la propriété suivie change.
    /// </summary>
    public class PropertyTrackerDependencies : PropertyTracker
    {
        #region Fields

        /// <summary>
        ///     Tableau des propriétés dépendantes.
        /// </summary>
        private string[] _DependentProperties;

        #endregion

        #region Properties

        /// <summary>
        ///     Obtient le tableau des propriétés dépendantes.
        /// </summary>
        public string[] DependentProperties
        {
            get { return _DependentProperties; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="PropertyTrackerDependencies"/>.
        /// </summary>
        /// <param name="trackedProperty">Nom de la propriété traquée.</param>
        /// <param name="dependentProperties">Talbeau des propriétés dépendantes.</param>
        public PropertyTrackerDependencies(string trackedProperty, params string[] dependentProperties)
            : base(trackedProperty)
        {
            _DependentProperties = dependentProperties;
        }

        #endregion
    }
}
