using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace NetWorkLib.erp号
{
    public partial class Frerpcreat1 : Form
    {

        public string id;
        public string 工作令号;
        public string 项目名称;
        public Frerpcreat1(string id, string 工作令号, string 项目名称, string yonghu)
        {
            InitializeComponent();
            this.id = id;
            this.工作令号 = 工作令号;
            this.项目名称 = 项目名称;
            this.yonghu = yonghu;
        }
        public string yonghu;
        public string wuzi;
        public string erpnumber;
        public string 三级名称;
        public string 型号;
        public string 单位;
        private void Frerpcreat1_Load(object sender, EventArgs e)
        {
            string sql = "select * from tb_erpfirst";
            DataTable dt = SQLHELP.GetDataTable(sql, CommandType.Text);

            List<string> spaceminute1 = new List<string>();
            for (int i = 0; i < dt.Rows.Count; i++)
            {

                string n = dt.Rows[i]["一级"].ToString();
                spaceminute1.Add(n);

            }
            foreach (string s in spaceminute1)
            {
                comboBoxEdit1.Properties.Items.Add(s);

            }
            textBox1.Text = 工作令号;
            textBox2.Text = 项目名称;
            textBox_id.Text = id;
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            if (txtwuzi.Text.Trim() == "")
            {
                MessageBox.Show("请输入需要查找的内容");
                return;
            }
            string sql = " select* from tb_xinerp    where  一级 like '%" + txtwuzi.Text.Trim() + "%' or 二级 like '%" + txtwuzi.Text.Trim() + "%'  or 三级 like '%" + txtwuzi.Text.Trim() + "%'  or 四级 like '%" + txtwuzi.Text.Trim() + "%' ";
            gridControl4.DataSource = SQLHELP.GetDataTable(sql, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
            gridView4.Columns["生成人"].Visible = false;
            gridView4.Columns["生成时间"].Visible = false;

        }

        private void gridView4_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > -1)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }

        }


        private void simpleButton3_Click(object sender, EventArgs e)
        {
            comboBoxEdit1.Text = "";
            comboBoxEdit2.Text = "";
            comboBoxEdit3.Text = "";
            comdanwei.Text = "";
            gridView4.Columns.Clear();
            comboBoxEdit1.Enabled = true;
            comboBoxEdit2.Enabled = true;
            comboBoxEdit3.Enabled = true;
            txtyulan.Text = "";
        }


        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (comdanwei.Text.Trim() == "")
            {

                MessageBox.Show("必须选择单位！");
                return;
            }
            if (comboBoxEdit1.Text.Trim() == "")
            {

                MessageBox.Show("必须选择一级名称！");
                return;
            }
            if (comboBoxEdit2.Text.Trim() == "")
            {

                MessageBox.Show("必须选择二级名称！");
                return;
            }
            if (comboBoxEdit3.Text.Trim() == "")
            {

                MessageBox.Show("必须选择三级名称！");
                return;
            }
            if (txtyulan.Text == "")
            {
                MessageBox.Show("预览为空，请先预览再生成！");
                return;
            }

            string sql111 = "select * from tb_erpfirst where 一级='" + comboBoxEdit1.Text + "'";
            string yiji1 = Convert.ToString(SQLHELP.ExecuteScalar(sql111, CommandType.Text));
            if (yiji1 == "")
            {
                MessageBox.Show("一级名称不存在，请重新输入！");
                return;
            }
            string sql222 = "select * from tb_erpsecond where 二级='" + comboBoxEdit2.Text + "'";
            string erji2 = Convert.ToString(SQLHELP.ExecuteScalar(sql222, CommandType.Text));
            if (erji2 == "")
            {
                MessageBox.Show("二级名称不存在，请重新输入！");
                return;
            }
            string sql333 = "select * from tb_erpthird where 三级='" + comboBoxEdit3.Text + "'";
            string sanji3 = Convert.ToString(SQLHELP.ExecuteScalar(sql333, CommandType.Text));
            if (sanji3 == "")
            {
                MessageBox.Show("三级名称不存在，请重新输入！");
                return;
            }
            string sql1122 = "select * from tb_xinerp where 三级='" + comboBoxEdit3.Text + "' and 四级='" + txtyulan.Text.Trim() + "'";
            DataTable dtttt = SQLHELP.GetDataTable(sql1122, CommandType.Text);
            if (dtttt.Rows.Count > 0)
            {
                MessageBox.Show("该ERP已存在！");
                gridControl4.DataSource = SQLHELP.GetDataTable(sql1122, CommandType.Text);
                return;
            }

            if (MessageBox.Show("确认生号吗？", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {
                string sql12345 = "insert into tb_xinerp (一级,二级,三级,四级,单位,生成时间,生成人) VALUES ('" + comboBoxEdit1.Text.Trim() + "','" + comboBoxEdit2.Text.Trim() + "','" + comboBoxEdit3.Text.Trim() + "','" + txtyulan.Text.Trim() + "','" + comdanwei.Text.Trim() + "','" + DateTime.Now + "','" + yonghu + "')";
                SQLHELP.ExecuteScalar(sql12345, CommandType.Text);
                string sql11 = "select * from tb_xinerp where 新编号 is  null ";
                DataTable dt = SQLHELP.GetDataTable(sql11, CommandType.Text);
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    string id = dt.Rows[i]["id"].ToString();
                    string yiji = dt.Rows[i]["一级"].ToString();
                    string sql12 = " Select 编号 from tb_erpfirst where 一级='" + yiji.Trim() + "' ";
                    string id1 = SQLHELP.ExecuteScalar(sql12, CommandType.Text).ToString();
                    string yiji2 = dt.Rows[i]["二级"].ToString();
                    string sql2 = " Select id from tb_erpsecond where  二级='" + yiji2.Trim() + "' ";
                    string id2 = SQLHELP.ExecuteScalar(sql2, CommandType.Text).ToString();

                    if (id2.Length == 1)
                    {

                        id2 = "00" + id2;
                    }
                    if (id2.Length == 2)
                    {

                        id2 = "0" + id2;
                    }
                    string yiji3 = dt.Rows[i]["三级"].ToString();
                    string sql3 = " Select id from tb_erpthird where  三级='" + yiji3.Trim() + "' ";
                    string id3 = SQLHELP.ExecuteScalar(sql3, CommandType.Text).ToString();

                    if (id3.Length == 1)
                    {

                        id3 = "00000" + id3;
                    }
                    if (id3.Length == 2)
                    {

                        id3 = "0000" + id3;
                    }
                    if (id3.Length == 3)
                    {

                        id3 = "000" + id3;
                    }
                    if (id3.Length == 4)
                    {

                        id3 = "00" + id3;
                    }
                    if (id3.Length == 5)
                    {

                        id3 = "0" + id3;
                    }

                    string id4 = dt.Rows[i]["id"].ToString();

                    if (id4.Length == 1)
                    {

                        id4 = "00000" + id4;
                    }
                    if (id4.Length == 2)
                    {

                        id4 = "0000" + id4;
                    }
                    if (id4.Length == 3)
                    {

                        id4 = "000" + id4;
                    }
                    if (id4.Length == 4)
                    {

                        id4 = "00" + id4;
                    }
                    if (id4.Length == 5)
                    {

                        id4 = "0" + id4;
                    }
                    string yiji4 = id1 + id2 + id3 + id4;

                    string sql123456 = "update tb_xinerp set 新编号='" + yiji4 + "' where id='" + id + "'";
                    SQLHELP.ExecuteScalar(sql123456, CommandType.Text);
                    MessageBox.Show("生成成功！");

                    string sql112233 = " select * from tb_xinerp    where  新编号 ='" + yiji4 + "' ";
                    gridControl4.DataSource = SQLHELP.GetDataTable(sql112233, CommandType.Text);
                    gridView4.Columns["id"].Visible = false;
                    gridView4.Columns["生成人"].Visible = false;
                    gridView4.Columns["生成时间"].Visible = false;
                }

            }
        }

        private void 添加到料单ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认将该行物资添加到料单中吗", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                this.wuzi = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "新编号"));
                this.DialogResult = DialogResult.OK;
                this.Close();


            }
        }


        private void comboBoxEdit1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text != "")
            {
                comboBoxEdit2.Properties.Items.Clear();
                string sql = "select * from tb_erpsecond where 关联一级='" + comboBoxEdit1.Text + "'";
                DataTable dt = SQLHELP.GetDataTable(sql, CommandType.Text);
                DataView myDataView = new DataView(dt);
                string[] strComuns = { "关联一级", "二级" };
                dt = myDataView.ToTable(true, strComuns);


                List<string> spaceminute1 = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string n = dt.Rows[i]["二级"].ToString();
                    spaceminute1.Add(n);

                }
                foreach (string s in spaceminute1)
                {
                    comboBoxEdit2.Properties.Items.Add(s);

                }
                comboBoxEdit1.Enabled = false;
                string sql11 = " select * from tb_xinerp    where  一级 ='" + comboBoxEdit1.Text.Trim() + "' ";
                gridControl4.DataSource = SQLHELP.GetDataTable(sql11, CommandType.Text);
                gridView4.Columns["id"].Visible = false;
                gridView4.Columns["生成人"].Visible = false;
                gridView4.Columns["生成时间"].Visible = false;

            }
        }

        private void comboBoxEdit2_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (comboBoxEdit2.Text != "")
            {
                comboBoxEdit3.Properties.Items.Clear();
                string sql = "select * from tb_erpthird where 关联二级='" + comboBoxEdit2.Text + "'";
                DataTable dt = SQLHELP.GetDataTable(sql, CommandType.Text);
                DataView myDataView = new DataView(dt);
                string[] strComuns = { "关联二级", "三级" };
                dt = myDataView.ToTable(true, strComuns);


                List<string> spaceminute1 = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string n = dt.Rows[i]["三级"].ToString();
                    spaceminute1.Add(n);

                }
                foreach (string s in spaceminute1)
                {
                    comboBoxEdit3.Properties.Items.Add(s);

                }
                comboBoxEdit2.Enabled = false;
                string sql11 = " select * from tb_xinerp    where  一级 ='" + comboBoxEdit1.Text.Trim() + "' and 二级= '" + comboBoxEdit2.Text.Trim() + "'";
                gridControl4.DataSource = SQLHELP.GetDataTable(sql11, CommandType.Text);
                gridView4.Columns["id"].Visible = false;
                gridView4.Columns["生成人"].Visible = false;
                gridView4.Columns["生成时间"].Visible = false;

            }
        }

        private void comboBoxEdit3_SelectedIndexChanged(object sender, EventArgs e)
        {

            comboBoxEdit3.Enabled = false;
            string sql11 = " select * from tb_xinerp    where  一级 ='" + comboBoxEdit1.Text.Trim() + "' and 二级= '" + comboBoxEdit2.Text.Trim() + "'  and 三级= '" + comboBoxEdit3.Text.Trim() + "'";
            gridControl4.DataSource = SQLHELP.GetDataTable(sql11, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
            gridView4.Columns["生成人"].Visible = false;
            gridView4.Columns["生成时间"].Visible = false;
        }

        private void simpleButton1_Click_1(object sender, EventArgs e)
        {
            if (txtguobiao.Text.Trim() == "" && txtcaizhi.Text.Trim() == "" && txtchicun.Text.Trim() == "" && txtpinpai.Text.Trim() == "")
            {
                MessageBox.Show("必须得填一个描述！");
                return;

            }

            if (txtguobiao.Text.Trim() == "" && txtcaizhi.Text.Trim() == "" && txtchicun.Text.Trim() == "" && txtpinpai.Text.Trim() != "")
            {


                txtyulan.Text = txtpinpai.Text.Trim();



            }
            if (txtguobiao.Text.Trim() != "" && txtcaizhi.Text.Trim() == "" && txtchicun.Text.Trim() == "" && txtpinpai.Text.Trim() == "")
            {


                txtyulan.Text = txtguobiao.Text.Trim();

            }

            if (txtguobiao.Text.Trim() == "" && txtcaizhi.Text.Trim() != "" && txtchicun.Text.Trim() == "" && txtpinpai.Text.Trim() == "")
            {


                txtyulan.Text = txtcaizhi.Text.Trim();

            }

            if (txtguobiao.Text.Trim() == "" && txtcaizhi.Text.Trim() == "" && txtchicun.Text.Trim() != "" && txtpinpai.Text.Trim() == "")
            {


                txtyulan.Text = txtchicun.Text.Trim();

            }

            if (txtguobiao.Text.Trim() != "" && txtcaizhi.Text.Trim() != "" && txtchicun.Text.Trim() == "" && txtpinpai.Text.Trim() == "")
            {


                txtyulan.Text = txtguobiao.Text.Trim() + "|" + txtcaizhi.Text.Trim();

            }

            if (txtguobiao.Text.Trim() != "" && txtcaizhi.Text.Trim() == "" && txtchicun.Text.Trim() != "" && txtpinpai.Text.Trim() == "")
            {


                txtyulan.Text = txtguobiao.Text.Trim() + "|" + txtchicun.Text.Trim();

            }

            if (txtguobiao.Text.Trim() != "" && txtcaizhi.Text.Trim() == "" && txtchicun.Text.Trim() == "" && txtpinpai.Text.Trim() != "")
            {


                txtyulan.Text = txtguobiao.Text.Trim() + "|" + txtpinpai.Text.Trim();

            }

            if (txtguobiao.Text.Trim() == "" && txtcaizhi.Text.Trim() != "" && txtchicun.Text.Trim() != "" && txtpinpai.Text.Trim() == "")
            {


                txtyulan.Text = txtchicun.Text.Trim() + "|" + txtcaizhi.Text.Trim();

            }

            if (txtguobiao.Text.Trim() == "" && txtcaizhi.Text.Trim() != "" && txtchicun.Text.Trim() == "" && txtpinpai.Text.Trim() != "")
            {


                txtyulan.Text = txtcaizhi.Text.Trim() + "|" + txtpinpai.Text.Trim();

            }

            if (txtguobiao.Text.Trim() == "" && txtcaizhi.Text.Trim() == "" && txtchicun.Text.Trim() != "" && txtpinpai.Text.Trim() != "")
            {


                txtyulan.Text = txtchicun.Text.Trim() + "|" + txtpinpai.Text.Trim();

            }


            if (txtguobiao.Text.Trim() != "" && txtcaizhi.Text.Trim() != "" && txtchicun.Text.Trim() != "" && txtpinpai.Text.Trim() == "")
            {


                txtyulan.Text = txtguobiao.Text.Trim() + "|" + txtchicun.Text.Trim() + "|" + txtcaizhi.Text.Trim();

            }


            if (txtguobiao.Text.Trim() != "" && txtcaizhi.Text.Trim() != "" && txtchicun.Text.Trim() == "" && txtpinpai.Text.Trim() != "")
            {


                txtyulan.Text = txtguobiao.Text.Trim() + "|" + txtcaizhi.Text.Trim() + "|" + txtpinpai.Text.Trim();


            }

            if (txtguobiao.Text.Trim() != "" && txtcaizhi.Text.Trim() == "" && txtchicun.Text.Trim() != "" && txtpinpai.Text.Trim() != "")
            {


                txtyulan.Text = txtguobiao.Text.Trim() + "|" + txtchicun.Text.Trim() + "|" + txtpinpai.Text.Trim();


            }

            if (txtguobiao.Text.Trim() == "" && txtcaizhi.Text.Trim() != "" && txtchicun.Text.Trim() != "" && txtpinpai.Text.Trim() != "")
            {


                txtyulan.Text = txtchicun.Text.Trim() + "|" + txtcaizhi.Text.Trim() + "|" + txtpinpai.Text.Trim();


            }

            if (txtguobiao.Text.Trim() != "" && txtcaizhi.Text.Trim() != "" && txtchicun.Text.Trim() != "" && txtpinpai.Text.Trim() != "")
            {


                txtyulan.Text = txtguobiao.Text.Trim() + "|" + txtchicun.Text.Trim() + "|" + txtcaizhi.Text.Trim() + "|" + txtpinpai.Text.Trim();

            }
        }

        private void simpleButton5_Click(object sender, EventArgs e)
        {
            //if (yonghu == "钱陆亦" || yonghu == "张旭" )
            //{
            //    Frxinzengsanji form1 = new Frxinzengsanji();
            //    form1.ShowDialog();
            //}
            //else
            //{
            //    MessageBox.Show("无权限！");
            //}
        }

        private void 添加到模具部erpToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认将erp添加到模具部吗", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                this.erpnumber = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "新编号"));
                this.DialogResult = DialogResult.OK;
                this.Close();


            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
        }

        private void comboBoxEdit1_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            if (comboBoxEdit1.Text != "")
            {
                comboBoxEdit2.Properties.Items.Clear();
                string sql = "select * from tb_erpsecond where 关联一级='" + comboBoxEdit1.Text + "'";
                DataTable dt = SQLHELP.GetDataTable(sql, CommandType.Text);
                DataView myDataView = new DataView(dt);
                string[] strComuns = { "关联一级", "二级" };
                dt = myDataView.ToTable(true, strComuns);


                List<string> spaceminute1 = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string n = dt.Rows[i]["二级"].ToString();
                    spaceminute1.Add(n);

                }
                foreach (string s in spaceminute1)
                {
                    comboBoxEdit2.Properties.Items.Add(s);

                }
                comboBoxEdit1.Enabled = false;
                string sql11 = " select * from tb_xinerp    where  一级 ='" + comboBoxEdit1.Text.Trim() + "' ";
                gridControl4.DataSource = SQLHELP.GetDataTable(sql11, CommandType.Text);
                gridView4.Columns["id"].Visible = false;
                gridView4.Columns["生成人"].Visible = false;
                gridView4.Columns["生成时间"].Visible = false;

            }
        }

        private void comboBoxEdit2_SelectedIndexChanged_1(object sender, EventArgs e)
        {

            if (comboBoxEdit2.Text != "")
            {
                comboBoxEdit3.Properties.Items.Clear();
                string sql = "select * from tb_erpthird where 关联二级='" + comboBoxEdit2.Text + "'";
                DataTable dt = SQLHELP.GetDataTable(sql, CommandType.Text);
                DataView myDataView = new DataView(dt);
                string[] strComuns = { "关联二级", "三级" };
                dt = myDataView.ToTable(true, strComuns);


                List<string> spaceminute1 = new List<string>();
                for (int i = 0; i < dt.Rows.Count; i++)
                {

                    string n = dt.Rows[i]["三级"].ToString();
                    spaceminute1.Add(n);

                }
                foreach (string s in spaceminute1)
                {
                    comboBoxEdit3.Properties.Items.Add(s);

                }
                comboBoxEdit2.Enabled = false;
                string sql11 = " select * from tb_xinerp    where  一级 ='" + comboBoxEdit1.Text.Trim() + "' and 二级= '" + comboBoxEdit2.Text.Trim() + "'";
                gridControl4.DataSource = SQLHELP.GetDataTable(sql11, CommandType.Text);
                gridView4.Columns["id"].Visible = false;
                gridView4.Columns["生成人"].Visible = false;
                gridView4.Columns["生成时间"].Visible = false;

            }
        }

        private void comboBoxEdit3_SelectedIndexChanged_1(object sender, EventArgs e)
        {
            comboBoxEdit3.Enabled = false;
            string sql11 = " select * from tb_xinerp    where  一级 ='" + comboBoxEdit1.Text.Trim() + "' and 二级= '" + comboBoxEdit2.Text.Trim() + "'  and 三级= '" + comboBoxEdit3.Text.Trim() + "'";
            gridControl4.DataSource = SQLHELP.GetDataTable(sql11, CommandType.Text);
            gridView4.Columns["id"].Visible = false;
            gridView4.Columns["生成人"].Visible = false;
            gridView4.Columns["生成时间"].Visible = false;
        }

        private void 添加到模具部erpToolStripMenuItem_Click_1(object sender, EventArgs e)
        {
            if (MessageBox.Show("确认将erp添加到模具部吗", "软件提示", MessageBoxButtons.YesNo, MessageBoxIcon.Exclamation) == DialogResult.Yes)
            {

                this.erpnumber = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "新编号"));
                this.三级名称 = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "三级"));
                this.型号 = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "四级"));
                this.单位 = Convert.ToString(this.gridView4.GetRowCellValue(this.gridView4.FocusedRowHandle, "单位"));
                this.DialogResult = DialogResult.OK;
                this.Close();


            }
        }

        private void simpleButton5_Click_1(object sender, EventArgs e)
        {

        }

        private void simpleButton3_Click_1(object sender, EventArgs e)
        {
            comboBoxEdit1.Text = "";
            comboBoxEdit2.Text = "";
            comboBoxEdit3.Text = "";
            comdanwei.Text = "";
            gridView4.Columns.Clear();
            comboBoxEdit1.Enabled = true;
            comboBoxEdit2.Enabled = true;
            comboBoxEdit3.Enabled = true;
            txtyulan.Text = "";
        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}