using MVVM.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMApp.Entity
{
    public class BadAnswer : ObservableObject
    {
        #region Fields

        private long _id;

        private string _badAnswer;


        private long _idQuestion;

        #endregion

        #region Properties

        public long id
        {
            get { return _id; }
            set { SetProperty(nameof(id), ref _id, value); }
        }

        public string badAnswer
        {
            get { return _badAnswer; }
            set { SetProperty(nameof(badAnswer), ref _badAnswer, value); }
        }


        public long idQuestion
        {
            get { return _idQuestion; }
            set { SetProperty(nameof(idQuestion), ref _idQuestion, value); }
        }

        #endregion

        #region Methods

        public override string ToString()
        {
            return badAnswer;
        }

        #endregion
    }
}
