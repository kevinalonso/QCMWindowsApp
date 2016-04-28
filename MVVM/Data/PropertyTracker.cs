using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVM.Data
{
    /// <summary>
    ///     Classe de base pour les traqueurs de propriété.
    /// </summary>
    public abstract class PropertyTracker
    {
        #region Fields

        /// <summary>
        ///     Nom de la propriété à traquer.
        /// </summary>
        private string _TrackedProperty;

        #endregion
        
        #region Properties

        /// <summary>
        ///     Obtient le nom de la propriété à traquer.
        /// </summary>
        public string TrackedProperty
        {
            get { return _TrackedProperty; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="PropertyTracker"/>.
        /// </summary>
        /// <param name="trackedProperty">Nom de la propriété à traquer.</param>
        public PropertyTracker(string trackedProperty)
        {
            _TrackedProperty = trackedProperty;
        }

        #endregion
    }
}
