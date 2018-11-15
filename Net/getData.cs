using NetWorkLib;
using NetWorkLib.util;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.NetworkInformation;
using System.Net.Sockets;
using System.Security.Cryptography;
using System.Text;

namespace NetWork.util
{
    public class getData
    {
        httputil httputil = new httputil();
        public static DataTable getdata(string sqlbefore, string db, params SqlParameter[] pars)
        {

            string info = "getdata";
            string sql = ToBase64String(doit(sqlbefore, "12345678876543211234567887654abc"));
            String url = "http://" + MyGlobal.ip + ":82/UserHandler.ashx?sql=" + sql + "&type=desktop&info=" + info + "&db=" + db + "&version=1";
            //String url = "http://localhost/WebApplication1/UserHandler.ashx?sql=" + sql + "&type=desktop&info=" + info + "&db=" + db + "&version=1";
            httputil httputil = new httputil();
            string s = httputil.getrrreturndata(url);
            StringReader sr = new StringReader(s);
            DataSet ds =  new DataSet();
            ds.ReadXml(sr);
            DataTable dt = new DataTable();
            if (ds.Tables.Count ==0)
            {

            }else
            {
                dt = ds.Tables[0];
            }
           
            return dt;
        }
        public static object ExecuteScalar(string sqlbefore, string db, params SqlParameter[] pars)
        {
            string info = "ExecuteScalar";
            string sql = ToBase64String(doit(sqlbefore, "12345678876543211234567887654abc"));
            String url = "http://" + MyGlobal.ip + ":82/UserHandler.ashx?sql=" + sql + "&type=desktop&info=" + info + "&db=" + db + "&version=1";
            //String url = "http://localhost/WebApplication1/UserHandler.ashx?sql=" + sql + "&type=desktop&info=" + info + "&db=" + db;
            httputil httputil = new httputil();
            string s = httputil.getrrreturndata(url);
            return s;
        }
        public static int ExecuteNonquery(string sqlbefore, string db, byte[] files,params SqlParameter[] pars)
        {
            string info = "ExecuteNonquery";
            string sql = ToBase64String(doit(sqlbefore, "12345678876543211234567887654abc"));
            String url = "http://" + MyGlobal.ip + ":82/UserHandler.ashx?sql=" + sql + "&type=desktop&info=" + info + "&db=" + db + "&files" + files + "&version=1";
            //String url = "http://localhost/WebApplication1/UserHandler.ashx?sql=" + sql + "&type=desktop&info=" + info + "&db=" + db + "&files" + files + "&version=1";
            httputil httputil = new httputil();
            string s = httputil.getrrreturnstream1(url, files, sql);
            return int.Parse(s);
        }
        public static int ExecuteNonquerytuzhi(string sqlbefore, string db, byte[] files, params SqlParameter[] pars)
        {
            string info = "ExecuteNonquerytuzhi";
            string sql = ToBase64String(doit(sqlbefore, "12345678876543211234567887654abc"));
            String url = "http://" + MyGlobal.ip + ":82/UserHandler.ashx?sql=" + sql + "&type=desktop&info=" + info + "&db=" + db + "&files" + files + "&version=1";
            httputil httputil = new httputil();
            string s = httputil.getrrreturnstream1(url, files, sql);
            return int.Parse(s);
        }
        public static int innn(string sqlbefore, string db, params SqlParameter[] pars)
        {
            string info = "innn";
            string sql = ToBase64String(doit(sqlbefore, "12345678876543211234567887654abc"));
            String url = "http://" + MyGlobal.ip + ":82/UserHandler.ashx?sql=" + sql + "&type=desktop&info=" + info + "&db=" + db + "&version=1";
            httputil httputil = new httputil();
            string s = httputil.getrrreturndata(url);
            return int.Parse(s);
        }
        public static byte[] duqu(string sqlbefore, string db, params SqlParameter[] pars)
        {

            string info = "duqu";
            string sql = ToBase64String(doit(sqlbefore, "12345678876543211234567887654abc"));
            String url = "http://" + MyGlobal.ip + ":82/UserHandler.ashx?sql=" + sql + "&type=desktop&info=" + info + "&db=" + db + "&version=1";
            httputil httputil = new httputil();
            byte[] dt = httputil.getrrreturnstream(url, sql);
            return dt;
        }
      
        public static Boolean ifping(string ip)
        {

            Boolean flag;
            Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            IAsyncResult result = socket.BeginConnect(ip, 82, null, null);

            bool success = result.AsyncWaitHandle.WaitOne(1000, true);

            if (socket.Connected)
            {
                flag = true;
            }
            else
            {
                flag = false;
            }
            return flag;



        }
        public static string getiprouter()
        {
            
            if (ifping("10.15.1.252"))
            {
                MyGlobal.ip = "10.15.1.252";
            }
            else if (ifping("47.97.210.239"))
            {
                MyGlobal.ip = "47.97.210.239";
            }
            return MyGlobal.ip;
        }
        public static string doit(string str, string key)
        {
            if (string.IsNullOrEmpty(str)) return null;
            Byte[] toEncryptArray = Encoding.UTF8.GetBytes(str);

            RijndaelManaged rm = new RijndaelManaged
            {
                Key = Encoding.UTF8.GetBytes(key),
                Mode = CipherMode.ECB,
                Padding = PaddingMode.PKCS7
            };

            ICryptoTransform cTransform = rm.CreateEncryptor();
            Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

            return Convert.ToBase64String(resultArray, 0, resultArray.Length);
        }
        public static string ToBase64String(string value)
        {
            if (value == null || value == "")
            {
                return "";
            }
            byte[] bytes = Encoding.UTF8.GetBytes(value);
            return Convert.ToBase64String(bytes);
        }
        public static string getservertime()
        {
            string sql = "select getdate() as SysDate";
            string name = SQLHELP.ExecuteScalar(sql, CommandType.Text).ToString();
            return name;
        }
    }
}
