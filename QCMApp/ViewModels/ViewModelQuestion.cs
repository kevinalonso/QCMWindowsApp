using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MVVM.ViewModels;
using QCMApp.Entity;
using QCMApp.Interfaces;
using MVVM;
using MVVM.Service;
using QCMApp.Constant;
using QCMApp.Views;
using MVVM.Interfaces;
using System.ComponentModel;
using System.Windows;
using QCMApp.Post;

namespace QCMApp.ViewModels
{
    public class ViewModelQuestion : ViewModelItem<Question>, IViewModelQuestion, INotifyPropertyChanged
    {
        #region Fields

        private ViewModelGoodAnswers _ViewModelGoodAnswers;
        private ViewModelBadAnswers _ViewModelBadAnswers;
        private ViewModelQuestions _ViewModelQuestions;
        private DelegateCommand _NextQuestionCommand;
        private DelegateCommand _PrevQuestionCommand;
        private DelegateCommand _SendAnswerCommand;
        private int nextValue = 0;
        private bool _IsSelectedBadAnswer;
        public bool _IsSelectedGoodAnswer;
        public bool _buttonVisible;
        public BadAnswer getBadAnswer { get; set; }
        public GoodAnswer getGoodAnswer { get; set; }
        public long IdUser { get; set; }

        List<UserAnswer> resultAnswers = new List<UserAnswer>();
        

        #endregion

        #region Properties

        public IViewModelQuestions ViewModelQuestions => _ViewModelQuestions;
        public IViewModelGoodAnswers ViewModelGoodAnswers => _ViewModelGoodAnswers;
        public IViewModelBadAnswers ViewModelBadAnswers => _ViewModelBadAnswers;
        public DelegateCommand NextQuestionCommand => _NextQuestionCommand;
        public DelegateCommand PrevQuestionCommand => _PrevQuestionCommand;
        public DelegateCommand SendAnswerCommand => _SendAnswerCommand;

        #endregion

        #region Constructors

        public ViewModelQuestion()
        {
            _ViewModelQuestions = new ViewModelQuestions();
            _ViewModelGoodAnswers = new ViewModelGoodAnswers();
            _ViewModelBadAnswers = new ViewModelBadAnswers();
            _NextQuestionCommand = new DelegateCommand(ExecuteNextQuestionCommand, CanExecuteNextQuestionCommand);
            _PrevQuestionCommand = new DelegateCommand(ExecutePrevQuestionCommand, CanExecutePrevQuestionCommand);
            _SendAnswerCommand = new DelegateCommand(ExecuteSendAnswerCommand, CanExecuteSendAnswerCommand);
        }

        #endregion

        #region Methods

        public override void LoadData()
        {
            _ViewModelQuestions.LoadData();   
        }

        #endregion

        #region NextQuestionCommand

        private bool CanExecuteNextQuestionCommand(object parameter)
        {
            return true;
        }

        #endregion

        #region PrevQuestionCommand

        private bool CanExecutePrevQuestionCommand(object parameter)
        {
            return true;
        }

        #endregion

        #region SendAnswerCommand

        private bool CanExecuteSendAnswerCommand(object parameter)
        {
            return true;
        }

        #endregion

        /// <summary>
        /// If CanExecuteConnectionCommand return true you can navigate to new windows
        /// </summary>
        /// <param name="parameter"></param>
        private void ExecuteNextQuestionCommand(object parameter)
        {
            if(_ViewModelQuestions.ItemsSource.Count() == resultAnswers.Count())
            {

                this.Item.textQuestion = GlobalConstant.END_QCM;
                this.Item.goodAnswer.answerQuestion = GlobalConstant.END_QCM;
                this.Item.badAnswer1.badAnswer = GlobalConstant.END_QCM;
                this.Item.badAnswer2.badAnswer = GlobalConstant.END_QCM;
            }
            else
            {
                //Add answer selected to list for send after with POST method
                if (!_IsSelectedBadAnswer || !_IsSelectedGoodAnswer)
                {
                    if (getBadAnswer != null)
                    {
                        UserAnswer userAnswer = new UserAnswer();

                        userAnswer.idQcm = Item.idQcm;
                        userAnswer.idQuestion = Item.id;
                        userAnswer.idAnswer = getBadAnswer.id;

                        resultAnswers.Add(userAnswer);

                    }
                    else
                    {
                        UserAnswer userAnswer = new UserAnswer();

                        userAnswer.idQcm = Item.idQcm;
                        userAnswer.idQuestion = Item.id;
                        userAnswer.idAnswer = getGoodAnswer.id;

                        resultAnswers.Add(userAnswer);
                    }
                }
            }

            //Get the next Question
            nextValue++;
            if (nextValue < _ViewModelQuestions.ItemsSource.Count())
            {
                
                this.Item = _ViewModelQuestions.ItemsSource.ElementAt<Question>(nextValue);

                _ViewModelGoodAnswers.IdQuestion = this.Item.id;
                _ViewModelGoodAnswers.LoadData();
                _ViewModelGoodAnswers.DataLoaded += (sender, args) =>
                {
                    this.Item.goodAnswer = _ViewModelGoodAnswers.ItemsSource.FirstOrDefault();
                };

                _ViewModelBadAnswers.IdQuestion = this.Item.id;
                _ViewModelBadAnswers.LoadData();
                _ViewModelBadAnswers.DataLoaded += (sender, args) =>
                {
                    this.Item.badAnswer1 = _ViewModelBadAnswers.ItemsSource.FirstOrDefault();
                    this.Item.badAnswer2 = _ViewModelBadAnswers.ItemsSource.LastOrDefault();
                   
                };
            }
           
        }

        private void ExecutePrevQuestionCommand(object parameter)
        {

            if(nextValue != 0)
            {
                nextValue--;
                this.Item = _ViewModelQuestions.ItemsSource.ElementAt<Question>(nextValue);

                _ViewModelGoodAnswers.IdQuestion = this.Item.id;
                _ViewModelGoodAnswers.LoadData();
                _ViewModelGoodAnswers.DataLoaded += (sender, args) =>
                {
                    this.Item.goodAnswer = _ViewModelGoodAnswers.ItemsSource.FirstOrDefault();
                };

                _ViewModelBadAnswers.IdQuestion = this.Item.id;
                _ViewModelBadAnswers.LoadData();
                _ViewModelBadAnswers.DataLoaded += (sender, args) =>
                {
                    this.Item.badAnswer1 = _ViewModelBadAnswers.ItemsSource.FirstOrDefault();
                    this.Item.badAnswer2 = _ViewModelBadAnswers.ItemsSource.LastOrDefault();
                };
            }
        }

        private void ExecuteSendAnswerCommand(object parameter)
        {
            PostData post = new PostData();
            foreach(UserAnswer item in resultAnswers)
            {
                post.Post(item);
            }

        }

        #region CheckBox Value
        public bool IsCheckedBadAnswer1
        {
            get
            {
                return _IsSelectedBadAnswer;
            }
            set
            {
                _IsSelectedBadAnswer = value;
                if (_IsSelectedBadAnswer == true)
                {
                    getBadAnswer = this.Item.badAnswer1;
                }
            }   
        }

        public bool IsCheckedBadAnswer2
        {
            get
            {
                return _IsSelectedBadAnswer;
            }
            set
            {
                _IsSelectedBadAnswer = value;
                if (_IsSelectedBadAnswer == true)
                {
                    getBadAnswer = this.Item.badAnswer2;
                }
            }
        }

        public bool IsCheckedGoodAnswer
        {
            get
            {
                return _IsSelectedGoodAnswer;
            }
            set
            {
                _IsSelectedGoodAnswer = value;
                if(_IsSelectedGoodAnswer == true)
                {
                    getGoodAnswer = this.Item.goodAnswer;
                }
            }
        }
        #endregion

        #region Button Visible
        public bool isVisible
        {
            get { return _buttonVisible; }
            set
            {
                _buttonVisible = value;
                OnPropertyChanged("isVisible");
            }
        }

        #endregion

    }
   
}
