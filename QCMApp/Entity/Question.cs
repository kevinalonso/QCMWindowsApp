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

        private GoodAnswer _goodAnswer;

        private BadAnswer _badAnswer1;

        private BadAnswer _badAnswer2;

        

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

        public GoodAnswer goodAnswer
        {
            get { return _goodAnswer; }
            set { SetProperty(nameof(goodAnswer), ref _goodAnswer, value); }
        }

        public BadAnswer badAnswer1
        {
            get { return _badAnswer1; }
            set { SetProperty(nameof(badAnswer1), ref _badAnswer1, value); }
        }

        public BadAnswer badAnswer2
        {
            get { return _badAnswer2; }
            set { SetProperty(nameof(badAnswer2), ref _badAnswer2, value); }
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
