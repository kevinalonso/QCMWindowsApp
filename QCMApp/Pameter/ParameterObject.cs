using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QCMApp.Pameter
{
    public class ParameterObject
    {
        public string id;
    public string value;

    public ParameterObject(string id, string val)
    {
        this.id = id;
        this.value = val;
    }
    }
}
