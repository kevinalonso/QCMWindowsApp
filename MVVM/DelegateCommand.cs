using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace MVVM
{
    /// <summary>
    ///     Commande qui déclanche des délégués.
    ///     Un objet commande doit implémenter l'interface <see cref="ICommand"/>.
    /// </summary>
    public class DelegateCommand : ICommand
    {
        #region Events

        /// <summary>
        ///     Se produit lorsque des modifications influent sur l'exécution de la commande.
        /// </summary>
        public event EventHandler CanExecuteChanged;

        #endregion

        #region Fields

        /// <summary>
        ///     Méthode de rappel pour l'exécution de la commande.
        /// </summary>
        private Action<object> _Execute;

        /// <summary>
        ///     Méthode de rappel pour vérifier si la commande peut être exécuté.
        ///     Si la méthode de rappel n'est pas définit, la commande pourra toujours être exécutée.
        /// </summary>
        private Func<object, bool> _CanExecute;

        #endregion

        #region Constructors

        /// <summary>
        ///     Initialise une nouvelle instance de la classe <see cref="DelegateCommand"/>.
        /// </summary>
        /// <param name="execute">Méthode de rappel pour l'exécution de la commande.</param>
        /// <param name="canExecute">Méthode de rappel pour vérifier si la commande peut être exécuté. Peut être null.</param>
        public DelegateCommand(Action<object> execute, Func<object,bool> canExecute = null )
        {
            if (execute == null)
            {
                throw new ArgumentNullException(nameof(execute));
            }

            _Execute = execute;
            _CanExecute = canExecute;
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Définit la méthode qui détermine si la commande peut s'exécuter dans son état actuel.
        /// </summary>
        /// <param name="parameter">Données utilisées par la commande. Si la commande ne requiert pas que les données soient passées, cet objet peut avoir la valeur null.</param>
        /// <returns>La valeur est true si cette commande peut être exécutée, sinon false.</returns>
        public bool CanExecute(object parameter)
        {
            return _CanExecute != null ? _CanExecute(parameter) : true;
        }

        /// <summary>
        ///     Définit la méthode à appeler lorsque la commande est appelée.
        /// </summary>
        /// <param name="parameter">Données utilisées par la commande. Si la commande ne requiert pas que les données soient passées, cet objet peut avoir la valeur null.</param>
        public void Execute(object parameter)
        {
            _Execute(parameter);
        }

        /// <summary>
        ///     Déclenche l'évènement <see cref="CanExecuteChanged"/> pour prévenir que la méthode CanExecute doit être réévaluée.
        /// </summary>
        public void OnCanExecuteChanged()
        {
            CanExecuteChanged?.Invoke(this, new EventArgs());
        }

        #endregion
    }
}
