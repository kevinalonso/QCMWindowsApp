using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Service
{
    /// <summary>
    ///     Constrat pour les services de message.
    /// </summary>
    public interface IMessageService : IService
    {
        /// <summary>
        ///     Affiche un message à l'utilisateur.
        /// </summary>
        /// <param name="message">Message à afficher.</param>
        void Show(string message);
    }
}
