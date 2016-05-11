using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Data;

namespace QCMApp.Entity
{
    public class UserAnswer : ObservableObject
    {

        private long _idQuestion;

        private long _idAnswer;

        private long _idQcm;

        #region Properties

        public long idQuestion
        {
            get { return _idQuestion; }
            set { SetProperty(nameof(idQuestion), ref _idQuestion, value); }
        }

        public long idAnswer
        {
            get { return _idAnswer; }
            set { SetProperty(nameof(idAnswer), ref _idAnswer, value); }
        }

        public long idQcm
        {
            get { return _idQcm; }
            set { SetProperty(nameof(idQcm), ref _idQcm, value); }
        }

        #endregion
    }
}
