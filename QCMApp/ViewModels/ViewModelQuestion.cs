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
        private int nextValue = 0;
        private bool _IsSelectedBadAnswer;
        public bool _IsSelectedGoodAnswer;
        public BadAnswer getBadAnswer { get; set; }
        public GoodAnswer getGoodAnswer { get; set; }
        

        #endregion

        #region Properties

        public IViewModelQuestions ViewModelQuestions => _ViewModelQuestions;
        public IViewModelGoodAnswers ViewModelGoodAnswers => _ViewModelGoodAnswers;
        public IViewModelBadAnswers ViewModelBadAnswers => _ViewModelBadAnswers;
        public DelegateCommand NextQuestionCommand => _NextQuestionCommand;
        public DelegateCommand PrevQuestionCommand => _PrevQuestionCommand;

        #endregion

        #region Constructors

        public ViewModelQuestion()
        {
            _ViewModelQuestions = new ViewModelQuestions();
            _ViewModelGoodAnswers = new ViewModelGoodAnswers();
            _ViewModelBadAnswers = new ViewModelBadAnswers();
            _NextQuestionCommand = new DelegateCommand(ExecuteNextQuestionCommand, CanExecuteNextQuestionCommand);
            _PrevQuestionCommand = new DelegateCommand(ExecutePrevQuestionCommand, CanExecutePrevQuestionCommand);
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

        #region PrevQuestionCommand

        private bool CanExecutePrevQuestionCommand(object parameter)
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
            /*if (yourBoolVariableContainingPropertyValue == true)
            {
                
            }*/
            //Get the next Question
            if (nextValue != _ViewModelQuestions.ItemsSource.Count())
            {
                nextValue++;
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
            else
            {
                /*Microsoft.Phone.Shell.ShellToast toast = new Microsoft.Phone.Shell.ShellToast();
                toast.Title = GlobalConstant.END_QCM;
                toast.Show();*/
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

        public bool IsCheckedBadAnswer1
        {
            get
            {
                return _IsSelectedBadAnswer;
            }
            set
            {
                //load value from last checked/unchcked value
                //if (yourBoolVariableContainingPropertyValue = value) return;
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
                //load value from last checked/unchcked value
                //if (yourBoolVariableContainingPropertyValue = value) return;
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
                //load value from last checked/unchcked value
                //if (yourBoolVariableContainingPropertyValue = value) return;
                _IsSelectedGoodAnswer = value;
                //getBadAnswer = _IsSelectedGoodAnswer ? this.Item.goodAnswer;
                if(_IsSelectedGoodAnswer == true)
                {
                    getGoodAnswer = this.Item.goodAnswer;
                }
            }
        }

    }
    #endregion
}
