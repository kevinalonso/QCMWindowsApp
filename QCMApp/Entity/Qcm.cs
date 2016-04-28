using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Data;

namespace QCMApp.Entity
{
    public class Qcm : ObservableObject
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

        private long _id_type;

        #endregion

        #region Properties

        public long id
        {
            get { return _id; }
            set { SetProperty(nameof(id), ref _id, value); }
        }

        public string nameQcm
        {
            get { return _nameQcm; }
            set { SetProperty(nameof(nameQcm), ref _nameQcm, value); }
        }

        public string dateStart
        {
            get { return _dateStart; }
            set { SetProperty(nameof(dateStart), ref _dateStart, value); }
        }

        public string dateEnd
        {
            get { return _dateEnd; }
            set { SetProperty(nameof(dateEnd), ref _dateEnd, value); }
        }

        public bool isActive
        {
            get { return _isActive; }
            set { SetProperty(nameof(isActive), ref _isActive, value); }
        }

        public long id_type
        {
            get { return _id_type; }
            set { SetProperty(nameof(id_type), ref _id_type, value); }
        }

        #endregion

        #region Constructors

        /*public Qcm(long Id = 0,string NameQcm = null,string DateStart = null, string DateEnd = null, bool IsActive = false,long IdType = 0)
        {
            nameQcm = NameQcm;
            dateStart = DateStart;
            dateEnd = DateEnd;
            isActive = IsActive;
            id_type = IdType;
        }*/

        #endregion

        #region Methods

        public override string ToString()
        {
            return nameQcm;
        }

        #endregion

    }
}
