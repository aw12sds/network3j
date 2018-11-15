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
    
        public static bool judgeversion(string versionlocal)
        {
            //flag为true,则需下载
            bool flag = false;
            String param = "zttoffice";
            String url = "http://"+ MyGlobal.ip+":8080/ZttErp/zttCodeversionController/getversion?param=" + param;
            httputil httputil = new httputil();
            Hashtable ht = httputil.Httpwconnection(url, param);
            if (ht["status"].Equals("fail"))
            {
                flag = false;
            }
            if (ht["status"].Equals("success"))
            {
                String content = ht["content"].ToString();
                if (!content.Equals(versionlocal))
                {
                    return true;
                }
            }

            else
            {

                return false;
            }
            return flag;
        }

        public String getversion()
        {
            //flag为true,则需下载
            String param = "zttoffice";

            String url = "http://" + MyGlobal.ip + ":8080/ZttErp/zttCodeversionController/getversion?param=" + param;
            httputil httputil = new httputil();
            Hashtable ht = httputil.Httpwconnection(url, param);
            String content = null;
            if (ht["status"].Equals("success"))
            {
                content = ht["content"].ToString();

            }
            return content;
        }
       

    }
}
