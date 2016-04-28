using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace MVVM.Data
{
    /// <summary>
    ///     Traqueur de propriété qui déclenche un délégué lorsque la propriété suivie change.
    /// </summary>
    public class PropertyTrackerAction : PropertyTracker
    {
        #region Fields

        /// <summary>
        ///     Délégué sur une méthode de rappel à déclencher lorsque la propriété suivie change.
        /// </summary>
        private Action<object, string> _Action;

        #endregion

        #region Properties

        /// <summary>
        ///     Obtient le délégué sur une méthode de rappel à déclencher lorsque la propriété suivie change.
        /// </summary>
        public Action<object, string> Action
        {
            get { return _Action; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="PropertyTrackerAction"/>.
        /// </summary>
        /// <param name="trackedProperty">Nom de la propriété à traquer.</param>
        /// <param name="action">Méthode de rappel à déclencher lorsque la propriété change.</param>
        public PropertyTrackerAction(string trackedProperty, Action<object, string> action)
            : base(trackedProperty)
        {
            _Action = action;
        }

        #endregion
    }
}
