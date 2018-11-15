using DevComponents.DotNetBar;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Windows.Forms;

namespace NetWorkLib.View
{
    public partial class AlertBox : Office2007Form
    {
        static string messageshow;
        public AlertBox(string message)
        {
            this.EnableGlass = false;
            InitializeComponent();
            messageshow = message;
        }

       
        public void shake(Form form)
        {
            var origin = this.Location;
            var ram = new Random(1337);
            //const int shake_a = 10;
            for (int i = 0; i <= 50; i++)
            {
                this.Location = new Point(origin.X + ram.Next(-10, 10), origin.Y + ram.Next(-10, 10));
                System.Threading.Thread.Sleep(10);
            }
            timer1.Start();

        }
        
        private void AlertBox_Load_1(object sender, EventArgs e)
        {
            int x = Screen.PrimaryScreen.WorkingArea.Right - this.Width;
            int y = Screen.PrimaryScreen.WorkingArea.Bottom - this.Height;
            this.Location = new Point(x, y);
            this.Show();
            textBox1.Text = messageshow;
            this.TopMost = true;
            shake(this);
        }
        
        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            Thread importThread = new Thread(new ThreadStart(ImportDialog));
            importThread.SetApartmentState(ApartmentState.STA);
            importThread.Start();
           

        }
        public void ImportDialog()
        {
            //string sql = "select 工作令号,项目名称,设备名称,时间 from tb_jishubumen where id='" + zifuchuan[1] + "'";
            string sql = "";
            DataTable dt = SQLHELP.GetDataTable(sql, CommandType.Text);

            string gonglinghao = dt.Rows[0]["工作令号"].ToString();
            string xiangmumingcheng = dt.Rows[0]["项目名称"].ToString();
            string shebeimingcheng = dt.Rows[0]["设备名称"].ToString();
            string shijian = dt.Rows[0]["时间"].ToString();

            FRwuliubuliaodan form = new FRwuliubuliaodan();
            form.gongzuolinghao = gonglinghao;
            form.xiangmumingcheng = xiangmumingcheng;
            form.shijian = shijian;
            form.ShowDialog();
        }

        private void AlertBox_FormClosed(object sender, FormClosedEventArgs e)
        {

        }
    }
}
