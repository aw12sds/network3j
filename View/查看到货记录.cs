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
    public partial class 查看到货记录 : Form
    {
        public string 定位;
        public 查看到货记录(string id)
        {
            InitializeComponent();
            this.定位 = id;

        }

        private void 查看到货记录_Load(object sender, EventArgs e)
        {
            string Sql1 = "select id,定位,部门,发货数量,发货时间 from tb_fahuojilu where 定位='" + 定位 + "'";
            DataTable dt2 = SQLHELP.GetDataTable(Sql1, CommandType.Text);
            gridControl1.DataSource = dt2;
        }
    }
}
