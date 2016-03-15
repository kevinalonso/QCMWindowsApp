using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMApp.Entity
{
    class Qcm
    {
        #region Fields

        /**
        * Qcm id
        */
        private long _id;
        /**
         * Qcm name
         */
        private string _nameQcm;
        /**
         * Qcm date start
         */
        private string _dateStart;
        /**
         * Qcm date end
         */
        private string _dateEnd;
        /**
         * Qcm if active qcm
         */
        private bool _isActive;

        private int _id_type;

        #endregion

        #region Properties

        public long id
        {
            get { return _id; }
            set { SetProperty(nameof(id), ref _id, value); }
        }

        #endregion

        #region Constructors



        #endregion

        #region Methods



        #endregion

    }
}
