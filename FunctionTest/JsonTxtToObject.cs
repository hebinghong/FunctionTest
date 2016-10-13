using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web.Script.Serialization;//引用System.Web.Extensions.dll
namespace FunctionTest
{
    class JsonTxtToObject
    {
        static void GetObject(string jsonTxt)
        {
            JavaScriptSerializer s = new JavaScriptSerializer();
            Dictionary<string, object> JsonData = (Dictionary<string, object>)s.DeserializeObject(jsonTxt);
        }
    }
}
