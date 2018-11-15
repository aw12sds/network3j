using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Management;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

namespace NetWorkLib.util
{
    public class getdevice
    {
        public string yonghu;
        public string tuzhimingcheng;
        public string tuzhileixing;

        private long fileSize = 0;//文件大小
        private string fileName = null;//文件名字
        private byte[] tuzhifiles;//文件

        private BinaryReader read = null;//二进制读取
        public getdevice()
        {

        }
        public static Dictionary<string, string> getdevice1()
        {
            Dictionary<string, string> hashMap = new Dictionary<string, string>();
            if (MyGlobal.ip.Equals("10.15.1.252"))
            {
                hashMap.Add("内外网", "内网");
            }else if (MyGlobal.ip.Equals("47.97.210.239"))
            {
                hashMap.Add("内外网", "外网");
            }
            hashMap.Add("操作系统", GetSystemName());
            
            hashMap.Add("公网ip", GetClientInternetIPAddress2());
            hashMap.Add("内网ip", getinnerip());
            hashMap.Add("硬盘序号", GetDiskID());
            hashMap.Add("cpuid", GetCpuID());
            hashMap.Add("mac号", getmacnumber());
            hashMap.Add("显卡信息", getvideodevice());
            hashMap.Add("机子类型", getpctype());
            return hashMap;
        }
       public static string getinnerip()
        {
            var host = Dns.GetHostEntry(Dns.GetHostName());
            string ip1 = "";
            foreach (var ip in host.AddressList)
            {
                if (ip.AddressFamily == AddressFamily.InterNetwork)
                {
                    ip1= ip.ToString();
                }
            }
            return ip1;
        }

        public static string getmacnumber()
        {
            string strMac = string.Empty;
            string mac1 = "";
            ManagementClass mc = new ManagementClass("Win32_NetworkAdapterConfiguration");
            ManagementObjectCollection moc = mc.GetInstances();
            foreach (ManagementObject mo in moc)
            {
                if ((bool)mo["IPEnabled"] == true)
                {
                    strMac = mo["MacAddress"].ToString();
                }
            }
            moc = null;
            mc = null;
            return mac1 = strMac;
        }
        /// <summary>  
        /// 获取操作系统名称  
        /// </summary>  
        /// <returns>操作系统名称</returns>  
        public static string GetSystemName()
        {
            try
            {
                string strSystemName = string.Empty;
                ManagementObjectSearcher mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT PartComponent FROM Win32_SystemOperatingSystem");
                foreach (ManagementObject mo in mos.Get())
                {
                    strSystemName = mo["PartComponent"].ToString();
                }
                mos = new ManagementObjectSearcher("root\\CIMV2", "SELECT Caption FROM Win32_OperatingSystem");
                foreach (ManagementObject mo in mos.Get())
                {
                    strSystemName = mo["Caption"].ToString();
                }
                return strSystemName;
            }
            catch
            {
                return "unknown";
            }
        }
        /// <summary>  
        /// 获取本机公网IP地址  
        /// </summary>  
        /// <returns>本机公网IP地址</returns>  
        private static string GetClientInternetIPAddress2()
        {
            //string externalip = new WebClient().DownloadString("http://icanhazip.com");
            string externalip = "";
            return externalip;
        }
        /// <summary>  
        /// 获取硬盘序号  
        /// </summary>  
        /// <returns>硬盘序号</returns>  
        public static string GetDiskID()
        {
            try
            {
                string strDiskID = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_DiskDrive");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    strDiskID = mo.Properties["Model"].Value.ToString();
                }
                moc = null;
                mc = null;
                return strDiskID;
            }
            catch
            {
                return "unknown";
            }
        }
        /// <summary>  
        /// 获取CpuID  
        /// </summary>  
        /// <returns>CpuID</returns>  
        public static string GetCpuID()
        {
            try
            {
                string strCpuID = string.Empty;
                ManagementClass mc = new ManagementClass("Win32_Processor");
                ManagementObjectCollection moc = mc.GetInstances();
                foreach (ManagementObject mo in moc)
                {
                    strCpuID = mo.Properties["ProcessorId"].Value.ToString();
                }
                moc = null;
                mc = null;
                return strCpuID;
            }
            catch
            {
                return "unknown";
            }
        }
        public static string  getvideodevice()
        {
            ManagementObjectSearcher objvide = new ManagementObjectSearcher("select * from Win32_VideoController");
            string video = "";
            foreach (ManagementObject obj in objvide.Get())
            {
                 video = video + "-----"+ obj["Name"];
               
            }
            return video;
        }
        public static string getpctype()
        {
            if (SystemInformation.PowerStatus.BatteryChargeStatus == BatteryChargeStatus.NoSystemBattery)
            {
                return "台式机";
            }
            else
            {
                return "笔记本";
            }
        }

        public void readdata(string yonghu)
        {
            int iWidth = Screen.PrimaryScreen.Bounds.Width;
            int iHeight = Screen.PrimaryScreen.Bounds.Height;
            Image img = new Bitmap(iWidth, iHeight);
            Graphics gc = Graphics.FromImage(img);
            gc.CopyFromScreen(new Point(0, 0), new Point(0, 0), new Size(iWidth, iHeight));
            string path = Environment.CurrentDirectory + "\\" + Guid.NewGuid().ToString() + ".jpg";
            img.Save(path);
            FileInfo info = new FileInfo(path);
            //获得文件大小
            fileSize = info.Length;
            //提取文件名,三步走
            int index = info.FullName.LastIndexOf(".");
            fileName = info.FullName.Remove(index);
            fileName = fileName.Substring(fileName.LastIndexOf(@"\") + 1);
            tuzhimingcheng = fileName;
            //获得文件扩展名
            tuzhileixing = info.Extension.Replace(".", "");
            tuzhifiles = new byte[Convert.ToInt32(fileSize)];
            FileStream file = new FileStream(path, FileMode.Open, FileAccess.Read);
            read = new BinaryReader(file);
            read.Read(tuzhifiles, 0, Convert.ToInt32(fileSize));
            sendpic(yonghu);
        }
        public void sendpic(string yonghu)
        {
            string sql1 = "INSERT INTO tb_test(附件名称,附件类型,附件,用户,时间) VALUES('" + tuzhimingcheng + "','" + tuzhileixing + "'," + "@pic,'" + yonghu + "','" + System.DateTime.Now + "')";
            SQLHELP.ExecuteNonquery(sql1, CommandType.Text, tuzhifiles);
        }
    }
}
