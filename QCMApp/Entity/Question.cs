using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Data;

namespace QCMApp.Entity
{
    public class Question : ObservableObject
    {
        #region Fields

        private long _id;

        private string _textQuestion;

        private long _idType;

        private long _idQcm;

        #endregion

        #region Properties

        public long id
        {
            get { return _id; }
            set { SetProperty(nameof(id), ref _id, value); }
        }

        public string textQuestion
        {
            get { return _textQuestion; }
            set { SetProperty(nameof(textQuestion), ref _textQuestion, value); }
        }

        public long idType
        {
            get { return _idType; }
            set { SetProperty(nameof(idType), ref _idType, value); }
        }

        public long idQcm
        {
            get { return _idQcm; }
            set { SetProperty(nameof(idQcm), ref _idQcm, value); }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return textQuestion;
        }

        #endregion

    }
}
