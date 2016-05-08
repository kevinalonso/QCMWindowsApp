using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.Data;

namespace QCMApp.Entity
{
    public class GoodAnswer : ObservableObject
    {

        #region Fields

        private long _id;

        private string _answerQuestion;


        private long _idQuestion;

        #endregion

        #region Properties

        public long id
        {
            get { return _id; }
            set { SetProperty(nameof(id), ref _id, value); }
        }

        public string answerQuestion
        {
            get { return _answerQuestion; }
            set { SetProperty(nameof(answerQuestion), ref _answerQuestion, value); }
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
            return answerQuestion;
        }

        #endregion

    }
}
