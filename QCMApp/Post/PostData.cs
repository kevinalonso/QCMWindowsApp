using QCMApp.Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using QCMApp.Pameter;

namespace QCMApp.Post
{
    public class PostData
    {
        public void Post(UserAnswer userAnswer)
        {
            /*WebClient webClient = new WebClient();
            Uri url = new Uri("http://192.168.1.14/app_dev.php/api/answers/users/new");

            string JsonStringParams = "{'idQuestion':'" + userAnswer.idQuestion + "','idAnswer':'" + userAnswer.idAnswer + "','idQcm':'"+userAnswer.idQcm+"'}";
            webClient.UploadStringCompleted += wc_UploadStringCompleted;
            webClient.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            webClient.Encoding = Encoding.UTF8;
            webClient.UploadStringAsync(url, "POST", JsonStringParams);*/

            WebClient wc = new WebClient();
            Uri url = new Uri("http://192.168.1.14/app_dev.php/api/answers/users/new");
            wc.UploadStringCompleted += new UploadStringCompletedEventHandler(wc_UploadStringCompleted);
            wc.Headers["Content-Type"] = "application/x-www-form-urlencoded";
            wc.Encoding = Encoding.UTF8;

            Parameters prms = new Parameters();
            prms.AddPair("idQuestion", userAnswer.idQuestion.ToString());
            prms.AddPair("idAnswer", userAnswer.idAnswer.ToString());
            prms.AddPair("idQcm", userAnswer.idQcm.ToString());

            wc.UploadStringAsync(url, "POST", prms.FormPostData(), null);
        }

        public void wc_UploadStringCompleted(object sender, UploadStringCompletedEventArgs e)
        {
            try
            {
                if (e.Result != null)
                {
                    string responce = e.Result.ToString();
                    //To Do Your functionality 
                }
            }
            catch(Exception ex)
            {
                //ex.StackTrace();
            }
        }
    }
}
