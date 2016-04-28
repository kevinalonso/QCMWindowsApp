using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.Phone.Controls;

namespace MVVM.Service
{
    /// <summary>
    ///     Service de navigation pour Windows Phone.
    /// </summary>
    public class PhoneNavigationService : INavigationService
    {
        #region Fields

        /// <summary>
        ///     Frame principal (conteneur des pages) de l'application Windows Phone.
        /// </summary>
        private PhoneApplicationFrame _PhoneApplicationFrame;

        #endregion

        #region Properties

        /// <summary>
        ///     Obtient le Frame principal (conteneur des pages) de l'application Windows Phone.
        /// </summary>
        public PhoneApplicationFrame PhoneApplicationFrame
        {
            get { return _PhoneApplicationFrame; }
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="PhoneNavigationService"/>.
        /// </summary>
        /// <param name="phoneApplicationFrame">Instance du Frame principal de l'application Windows Phone.</param>
        public PhoneNavigationService(PhoneApplicationFrame phoneApplicationFrame)
        {
            if (phoneApplicationFrame == null)
            {
                throw new ArgumentNullException(nameof(phoneApplicationFrame));
            }
            _PhoneApplicationFrame = phoneApplicationFrame;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Navigue jusqu'à l'Uri spécifiée.
        /// </summary>
        /// <param name="uri">Uri à atteindre.</param>
        /// <returns>Détermine si la navigation est prise en compte.</returns>
        public bool Navigate(Uri uri)
        {
            return PhoneApplicationFrame.Navigate(uri) == true;
        }

        /// <summary>
        ///     Retour à l'Uri précédente.
        /// </summary>
        public void GoBack()
        {
            PhoneApplicationFrame.GoBack();
        }

        #endregion
    }
}
