using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMApp.Constant
{
    public static class GlobalConstant
    {
        #region Web Service URL

        /// <summary>
        /// Url to get all qcm from web service
        /// </summary>
        public const string URL_QCM = "http://192.168.1.14/app_dev.php/api/all/qcm";
        public const string URL_QUESTION = "http://192.168.1.14/app_dev.php/api/all/question";
        public const string URL_GOODANSWER = "http://192.168.1.14/app_dev.php/api/all/good/answer";
        public const string URL_BADANSWER = "http://192.168.1.14/app_dev.php/api/all/bad/answer";
        public const string URL_USER = "http://192.168.1.14/app_dev.php/api/all/users";

        #endregion

        #region Navigation Windows Phone

        /// <summary>
        /// Adress to Welcome window in windows phone
        /// </summary>
        public const string WINDOW_WELCOME = "/Views/WelcomePage.xaml";

        /// <summary>
        /// Adress to Question window in windows phone
        /// </summary>
        public const string WINDOWS_QUESTION = "/Views/QuestionPage.xaml";


        #endregion

        #region Name element in Array

        #region Qcm JSON

        public const string ID = "id";
        public const string NAME_QCM = "nameQcm";
        public const string DATE_START = "dateStart";
        public const string DATE_END = "dateEnd";
        public const string IS_ACTIVE = "isActive";
        public const string ID_TYPE = "idType";

        #endregion

        #region Question JSON

        public const string ID_QUESTION = "idQuestion";
        public const string QUESTION_NAME = "textQuestion";
        public const string ID_QCM_TO_QUESTION = "idQcm";

        #endregion

        #region GoodAnswer JSON

        public const string ID_GOODANSWER = "id";
        public const string GOODANSWER_NAME = "answerQuestion";
        public const string ID_QUESTION_TO_GOODANSWER = "idQuestion";

        #endregion

        #region BadAnswer JSON

        public const string ID_BADANSWER = "id";
        public const string BADANSWER_NAME = "badAnswerQuestion";
        public const string ID_QUESTION_TO_BADANSWER = "idQuestion";

        #endregion

        #region User JSON

        public const string ID_USER = "id";
        public const string USER_LOGIN = "login";
        public const string USER_PASS = "password";

        #endregion

        #endregion

        #region String Value

        public const string END_QCM = "Le Qcm est terminé";
        
        #endregion

    }
}
