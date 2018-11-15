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
    public partial class 到货记录 : Form
    {
        public string id;
        public 到货记录(string id)
        {
            InitializeComponent();
            this.id = id;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string 发货数量 = textBox1.Text;
            string 发货时间 = dateEdit1.Text;




            if (发货数量 == "")
            {
                MessageBox.Show("发货数量不能为空");
                return;
            }
            if (发货时间 == "")
            {
                MessageBox.Show("发货时间不能为空");
                return;
            }
            string sql = "insert into tb_fahuojilu(定位,部门,发货数量,发货时间,类别) values('" + id + "','仓库','" + 发货数量 + "','" + 发货时间 + "','到货')";
            SQLHELP.ExecuteScalar(sql, CommandType.Text);
            this.Close();
        }
    }
}
