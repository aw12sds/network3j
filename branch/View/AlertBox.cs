using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetWorkLib.View
{
    public partial class AlertBox : Form
    {
        static string messageshow;
        public AlertBox(string message)
        {
            InitializeComponent();
            messageshow = message;
        }

        private void AlertBox_Load(object sender, EventArgs e)
        {
            this.Show();
            label1.Text = messageshow;
            this.TopMost = true;

            //Application.DoEvents();
            //shake(this);
        }
        public void shake(Form form)
        {
            var origin = this.Location;
            var ram = new Random(1337);
            const int shake_a = 10;
            for (int i = 0; i <= 50; i++)
            {
                this.Location = new Point(origin.X + ram.Next(-10, 10), origin.Y + ram.Next(-10, 10));
                System.Threading.Thread.Sleep(10);
            }
            timer1.Start();

        }


        private void timer1_Tick_1(object sender, EventArgs e)
        {
            var origin = this.Location;
            var ram = new Random(1337);
            const int shake_a = 10;
            for (int i = 0; i <= 50; i++)
            {
                this.Location = new Point(origin.X + ram.Next(-10, 10), origin.Y + ram.Next(-10, 10));
                System.Threading.Thread.Sleep(10);
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void AlertBox_Load_1(object sender, EventArgs e)
        {

        }
    }
}
