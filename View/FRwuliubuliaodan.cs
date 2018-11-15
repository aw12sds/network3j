using DevComponents.DotNetBar;
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
    public partial class FRwuliubuliaodan : Office2007Form
    {
        public FRwuliubuliaodan()
        {
            this.EnableGlass = false;
            InitializeComponent();
        }
        public string gongzuolinghao;
        public string xiangmumingcheng;
        public string shijian;
        public string lujing;
        DataTable dt;
        private void FRwuliubuliaodan_Load(object sender, EventArgs e)
        {
            string sql1 = "select id, 序号,编码,型号,名称,单位,数量,类型,项目工令号,要求到货日期,备注,制造类型,申购人,收到料单日期,供方名称,合同号,实际采购数量,报价, 采购单价,实际到货日期,当前状态,采购料单备注,附件名称,附件类型,合同预计时间 from  tb_caigouliaodan  where 工作令号='" + gongzuolinghao + "' and 项目名称='" + xiangmumingcheng + "'and 时间='" + shijian + "' and   制造类型!='自制零部件' and   制造类型!='装配零部件'  and   制造类型!='库存件'";
            dt = SQLHELP.GetDataTable(sql1, CommandType.Text);
            dataGridViewX2.DataSource = dt;

        }
    }
}
