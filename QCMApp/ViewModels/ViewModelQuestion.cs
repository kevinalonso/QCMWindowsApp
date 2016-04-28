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

namespace QCMApp.ViewModels
{
    public class ViewModelQuestion : ViewModelItem<Question>, IViewModelQuestion
    {
        #region Fields

        //private ViewModelGoodAnswers _ViewModelGoodAnswers;
        private ViewModelQuestions _ViewModelQuestions;
        private DelegateCommand _NextQuestionCommand;
        private int nextValue = 0;
       
        #endregion

        #region Properties

        public IViewModelQuestions ViewModelQuestions => _ViewModelQuestions;
        //public IViewModelGoodAnswers ViewModelGoodAnswers => _ViewModelGoodAnswers;
        public DelegateCommand NextQuestionCommand => _NextQuestionCommand;

        #endregion

        #region Constructors

        public ViewModelQuestion()
        {
            _ViewModelQuestions = new ViewModelQuestions();
            //_ViewModelGoodAnswers = new ViewModelGoodAnswers();
            _NextQuestionCommand = new DelegateCommand(ExecuteNextQuestionCommand, CanExecuteNextQuestionCommand);
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

        /// <summary>
        /// If CanExecuteConnectionCommand return true you can navigate to new windows
        /// </summary>
        /// <param name="parameter"></param>
        private void ExecuteNextQuestionCommand(object parameter)
        {
            //Get the next Question
            if(nextValue != _ViewModelQuestions.ItemsSource.Count())
            {
                nextValue++;
                this.Item = _ViewModelQuestions.ItemsSource.ElementAt<Question>(nextValue);
                
            }
            else
            {
                /*Microsoft.Phone.Shell.ShellToast toast = new Microsoft.Phone.Shell.ShellToast();
                toast.Title = GlobalConstant.END_QCM;
                toast.Show();*/
            }
           
        }

        #endregion
    }
}
