using NetWorkLib.util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace NetWorkLib.Net
{
    public class version
    {
        httputil httputil = new httputil();

        public static bool judgeversion(string versionlocal, string appname)
        {
            bool result = false;
            string url = "http://" + MyGlobal.ip + ":8080/ZttErp/zttCodeversionController/getversion?param=" + appname;
            httputil httputil = new httputil();
            Hashtable hashtable = httputil.Httpwconnection(url, appname);
            if (hashtable["status"].Equals("fail"))
            {
                result = false;
            }
            if (!hashtable["status"].Equals("success"))
            {
                return false;
            }
            string text = hashtable["content"].ToString();
            if (text.Equals(versionlocal))
            {
                return result;
            }
            return true;
        }

        public string getversion(string appname)
        {
            string url = "http://" + MyGlobal.ip + ":8080/ZttErp/zttCodeversionController/getversion?param=" + appname;
            httputil httputil = new httputil();
            Hashtable hashtable = httputil.Httpwconnection(url, appname);
            string result = null;
            if (hashtable["status"].Equals("success"))
            {
                result = hashtable["content"].ToString();
            }
            return result;
        }


    }
}
