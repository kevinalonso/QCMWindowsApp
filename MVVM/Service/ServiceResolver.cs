using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVVM.Service
{
    /// <summary>
    ///     Permet d'enregistrer ou de résoudre un service.
    ///     Un service doit implémenter l'interface IService.
    ///     Il n'est pas possible d'avoir plusieurs instances pour un type de service.
    /// </summary>
    public class ServiceResolver
    {
        #region Fields

        /// <summary>
        ///     Dictionnaire des services enregistrés.
        /// </summary>
        private static Dictionary<Type, IService> _Services;

        #endregion

        #region Constructors

        /// <summary>
        ///     Constructeur statique de la classe <see cref="ServiceResolver"/>.
        /// </summary>
        static ServiceResolver()
        {
            _Services = new Dictionary<Type, IService>();
        }

        #endregion

        #region Methods

        /// <summary>
        ///     Enregistre une instance pour un type de service.
        /// </summary>
        /// <typeparam name="T">Type du service à enregistrer.</typeparam>
        /// <param name="service">Instance du service à enregistrer.</param>
        /// <param name="overrideIfExist">Détermine si le service doit être remplacé si une instance est déjà enregistrée pour ce type.</param>
        public static void RegisterService<T>(T service, bool overrideIfExist = true)
            where T : IService
        {
            Type serviceType = typeof(T);
            bool serviceAllreadyRegistered = _Services.ContainsKey(serviceType);

            if (!serviceAllreadyRegistered)
            {
                _Services.Add(serviceType, service);
            }

            if (serviceAllreadyRegistered && overrideIfExist)
            {
                _Services[serviceType] = service;
            }
            else if(serviceAllreadyRegistered && !overrideIfExist)
            {
                throw new Exception("Une instance d'un service est déjà enregistrée pour ce type de service.");
            }
        }

        /// <summary>
        ///     Retourne l'instance d'un service en fonction du type du service souhaité.
        /// </summary>
        /// <typeparam name="T">Type de service à résoudre.</typeparam>
        /// <returns>Instance du service associé.</returns>
        public static T GetService<T>()
            where T : IService
        {
            Type serviceType = typeof(T);
            T service = default(T);

            if (_Services.ContainsKey(serviceType))
            {
                service = (T)_Services[serviceType];
            }
            else
            {
                throw new Exception("Aucun service enregistré pour le type de service spécifié.");
            }

            return service;
        }

        #endregion
    }
}
