using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Windows.Forms;

namespace NetWorkLib.util
{
   public class httputil
    {

        public httputil()
        {
                
        }
        public Hashtable Httpwconnection(String url, String param)
        {

            Hashtable ht = new Hashtable();
            String postdata = "";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = null;
            try
            {
                request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "text/html; charset=UTF-8";
                request.ContentLength = data.Length;
                Stream newStream = request.GetRequestStream();
                newStream.Write(data, 0, data.Length);
                newStream.Close();
                HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string content = reader.ReadToEnd();
                ht.Add("status", "success");
                ht.Add("content", content);
            }
            catch

            {
                ht.Add("status", "fail");

            }
            return ht;
        }
        public string getrrreturndata(String url)
        {
           
            Hashtable ht = new Hashtable();
            String postdata = "";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = null;
            
            request = (HttpWebRequest)WebRequest.Create(url);
                request.Method = "POST";
                request.ContentType = "text/html; charset=UTF-8";
                request.ContentLength = data.Length;
            request.KeepAlive = false;
            Stream newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
                HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
                StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
                string content = reader.ReadToEnd();
                return content;
           
        }
        public byte[] getrrreturnstream(String url, String param)
        {

            Hashtable ht = new Hashtable();
            String postdata = "";
            byte[] data = Encoding.UTF8.GetBytes(postdata);
            HttpWebRequest request = null;

            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "text/html; charset=UTF-8";
            request.ContentLength = data.Length;
            Stream newStream = request.GetRequestStream();
            newStream.Write(data, 0, data.Length);
            newStream.Close();
            HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
            MemoryStream ms = new MemoryStream();
            myResponse.GetResponseStream().CopyTo(ms);
            byte[] content = ms.ToArray();
            return content;

        }

        public string getrrreturnstream1(String url, byte[] files,String param)
        {

            Hashtable ht = new Hashtable();
            byte[] data = files;
            HttpWebRequest request = null;

            request = (HttpWebRequest)WebRequest.Create(url);
            request.Method = "POST";
            request.ContentType = "text/html; charset=UTF-8";
            request.ContentLength = data.Length;



            Stream newStream = request.GetRequestStream();


            newStream.Write(data, 0, data.Length);
            newStream.Close();
            request.Timeout = 300000;
            HttpWebResponse myResponse = (HttpWebResponse)request.GetResponse();
            StreamReader reader = new StreamReader(myResponse.GetResponseStream(), Encoding.UTF8);
            string content = reader.ReadToEnd();
            return content;

        }


    }
}
