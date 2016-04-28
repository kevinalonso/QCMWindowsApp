using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace MVVM.Service
{
    /// <summary>
    ///     Service de message pour Windows Phone.
    /// </summary>
    public class PhoneMessageService : IMessageService
    {
        /// <summary>
        ///     Affiche un message à l'utilisateur.
        /// </summary>
        /// <param name="message">Message à afficher.</param>
        public void Show(string message)
        {
            MessageBox.Show(message);
        }
    }
}
