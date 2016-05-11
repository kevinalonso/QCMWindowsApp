using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMApp.Pameter
{
    public class Parameters
    {
        public List<ParameterObject> prms;

        public Parameters()
        {
            prms = new List<ParameterObject>();
        }

        public void AddPair(string id, string val)
        {
            prms.Add(new ParameterObject(id, val));
        }

        public String FormPostData()
        {
            StringBuilder buffer = new StringBuilder();

            for (int i = 0; i < prms.Count; i++)
            {
                if (i == 0)
                {
                    buffer.Append(System.Net.HttpUtility.UrlEncode(prms[i].id) + "=" + System.Net.HttpUtility.UrlEncode(prms[i].value));
                }
                else
                {
                    buffer.Append("&" + System.Net.HttpUtility.UrlEncode(prms[i].id) + "=" + System.Net.HttpUtility.UrlEncode(prms[i].value));
                }
            }

            return buffer.ToString();
        }
    }
}
