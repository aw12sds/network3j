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
    public partial class cailiaozhongliang1 : Form
    {
        public string gx1;
        public string gx2;
        public string gx3;
        public string gx4;

        public string cailiao1;
        public string cailiao2;
        public string cailiao3;
        public string cailiao4;
        public string zhongliang1;
        public string zhongliang2;
        public string zhongliang3;
        public string zhongliang4;
        double midu, w;
        public cailiaozhongliang1()
        {
            InitializeComponent();
        }

        private void cailiaozhongliang1_Load(object sender, EventArgs e)
        {
            textBox1.Text = gx1;
            textBox2.Text = gx2;
            textBox3.Text = gx3;
            textBox4.Text = gx4;

            comboBox1.Items.Clear();
            string sql = "select 材料 from db_cailiaoguige ";
            DataTable dt = SQLhelp1.GetDataTable(sql, CommandType.Text);

            foreach (DataRow row in dt.Rows)
            {
                string a = row["材料"].ToString();
                if (comboBox1.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox1.Items.Add(a);
            }

            comboBox2.Items.Clear();
            string sql1 = "select 材料 from db_cailiaoguige ";
            DataTable dt1 = SQLhelp1.GetDataTable(sql1, CommandType.Text);

            foreach (DataRow row in dt1.Rows)
            {
                string a = row["材料"].ToString();
                if (comboBox2.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox2.Items.Add(a);
            }

            comboBox3.Items.Clear();
            string sql2 = "select 材料 from db_cailiaoguige ";
            DataTable dt2 = SQLhelp1.GetDataTable(sql2, CommandType.Text);

            foreach (DataRow row in dt2.Rows)
            {
                string a = row["材料"].ToString();
                if (comboBox3.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox3.Items.Add(a);
            }

            comboBox4.Items.Clear();
            string sql3 = "select 材料 from db_cailiaoguige ";
            DataTable dt3 = SQLhelp1.GetDataTable(sql3, CommandType.Text);

            foreach (DataRow row in dt3.Rows)
            {
                string a = row["材料"].ToString();
                if (comboBox4.Items.Cast<object>().All(x => x.ToString() != a))
                    comboBox4.Items.Add(a);
            }
        }

        private void comboBox5_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void comboBox5_Click(object sender, EventArgs e)
        {
            comboBox5.Items.Clear();
            string sql = "select 规格 from db_cailiaoguige where 材料='" + comboBox1.Text.Trim() + "' ";
            string ret = Convert.ToString(SQLhelp1.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp1.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["规格"].ToString();
                    if (comboBox5.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox5.Items.Add(a);
                }
            }
        }

        private void comboBox6_Click(object sender, EventArgs e)
        {
            comboBox6.Items.Clear();
            string sql = "select 规格 from db_cailiaoguige where 材料='" + comboBox2.Text.Trim() + "' ";
            string ret = Convert.ToString(SQLhelp1.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp1.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["规格"].ToString();
                    if (comboBox6.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox6.Items.Add(a);
                }
            }
        }

        private void comboBox7_Click(object sender, EventArgs e)
        {
            comboBox7.Items.Clear();
            string sql = "select 规格 from db_cailiaoguige where 材料='" + comboBox3.Text.Trim() + "' ";
            string ret = Convert.ToString(SQLhelp1.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp1.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["规格"].ToString();
                    if (comboBox7.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox7.Items.Add(a);
                }
            }
        }

        private void comboBox8_Click(object sender, EventArgs e)
        {
            comboBox8.Items.Clear();
            string sql = "select 规格 from db_cailiaoguige where 材料='" + comboBox4.Text.Trim() + "' ";
            string ret = Convert.ToString(SQLhelp1.ExecuteScalar(sql, CommandType.Text));
            if (ret != "")
            {

                DataTable dt = SQLhelp1.GetDataTable(sql, CommandType.Text);

                foreach (DataRow row in dt.Rows)
                {
                    string a = row["规格"].ToString();
                    if (comboBox8.Items.Cast<object>().All(x => x.ToString() != a))
                        comboBox8.Items.Add(a);
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            zl1.Text = "";
            zl2.Text = "";
            zl3.Text = "";
            zl4.Text = "";

            if (comboBox1.Text.Trim() != "" && comboBox5.Text.Trim() != "")
            {
                double danzhong = chaxundanzhong(comboBox1.Text.Trim(), comboBox5.Text.Trim());//查询到单重/密度
                double zhongliang = jisuanzhongliang(comboBox1.Text.Trim(), B_C1.Text.Trim(), B_K1.Text.Trim(), B_G1.Text.Trim(), J_C1.Text.Trim(), Y_W1.Text.Trim(), Y_C1.Text.Trim(), Y_B1.Text.Trim(), C_C1.Text.Trim(), G_C1.Text.Trim(), F_C1.Text.Trim());//重量
                double z = danzhong * zhongliang * 1000;
                zl1.Text = Convert.ToString(z);
            }

            if (comboBox2.Text.Trim() != "" && comboBox6.Text.Trim() != "")
            {
                double danzhong = chaxundanzhong(comboBox2.Text.Trim(), comboBox6.Text.Trim());//查询到单重/密度
                double zhongliang = jisuanzhongliang(comboBox2.Text.Trim(), B_C2.Text.Trim(), B_K2.Text.Trim(), B_G2.Text.Trim(), J_C2.Text.Trim(), Y_W2.Text.Trim(), Y_C2.Text.Trim(), Y_B2.Text.Trim(), C_C2.Text.Trim(), G_C2.Text.Trim(), F_C2.Text.Trim());//重量
                double z = danzhong * zhongliang * 1000;
                zl2.Text = Convert.ToString(z);
            }

            if (comboBox3.Text.Trim() != "" && comboBox7.Text.Trim() != "")
            {
                double danzhong = chaxundanzhong(comboBox3.Text.Trim(), comboBox7.Text.Trim());//查询到单重/密度
                double zhongliang = jisuanzhongliang(comboBox3.Text.Trim(), B_C3.Text.Trim(), B_K3.Text.Trim(), B_G3.Text.Trim(), J_C3.Text.Trim(), Y_W3.Text.Trim(), Y_C3.Text.Trim(), Y_B3.Text.Trim(), C_C3.Text.Trim(), G_C3.Text.Trim(), F_C3.Text.Trim());//重量
                double z = danzhong * zhongliang * 1000;
                zl3.Text = Convert.ToString(z);
            }

            if (comboBox4.Text.Trim() != "" && comboBox8.Text.Trim() != "")
            {
                double danzhong = chaxundanzhong(comboBox4.Text.Trim(), comboBox8.Text.Trim());//查询到单重/密度
                double zhongliang = jisuanzhongliang(comboBox4.Text.Trim(), B_C4.Text.Trim(), B_K4.Text.Trim(), B_G4.Text.Trim(), J_C4.Text.Trim(), Y_W4.Text.Trim(), Y_C4.Text.Trim(), Y_B4.Text.Trim(), C_C4.Text.Trim(), G_C4.Text.Trim(), F_C4.Text.Trim());//重量
                double z = danzhong * zhongliang * 1000;
                zl4.Text = Convert.ToString(z);
            }
        }
        private double chaxundanzhong(string a, string b)
        {
            string sql = "select 密度单重 from db_cailiaoguige where 材料='" + a + "' and 规格='" + b + "'";
            string ret = Convert.ToString(SQLhelp1.ExecuteScalar(sql, CommandType.Text));

            if (ret != "")
            {
                midu = Math.Round(Convert.ToDouble(ret), 3);
            }
            else
            {
                midu = Convert.ToDouble(0);
            }
            return midu;
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            zhongliang1 = zl1.Text.Trim();
            zhongliang2 = zl2.Text.Trim();
            zhongliang3 = zl3.Text.Trim();
            zhongliang4 = zl4.Text.Trim();
            cailiao1 = comboBox1.Text.Trim() + comboBox5.Text.Trim();
            cailiao2 = comboBox2.Text.Trim() + comboBox6.Text.Trim();
            cailiao3 = comboBox3.Text.Trim() + comboBox7.Text.Trim();
            cailiao4 = comboBox4.Text.Trim() + comboBox8.Text.Trim();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text.Trim() != "")
            {
                switch (comboBox1.Text.Trim())
                {
                    case "板":
                        B_C1.Enabled = true; B_K1.Enabled = true; B_G1.Enabled = true; J_C1.Enabled = false; Y_W1.Enabled = false; Y_C1.Enabled = false; Y_B1.Enabled = false; C_C1.Enabled = false; G_C1.Enabled = false; F_C1.Enabled = false;
                        break;
                    case "角钢":
                        B_C1.Enabled = false; B_K1.Enabled = false; B_G1.Enabled = false; J_C1.Enabled = true; Y_W1.Enabled = false; Y_C1.Enabled = false; Y_B1.Enabled = false; C_C1.Enabled = false; G_C1.Enabled = false; F_C1.Enabled = false;
                        break;
                    case "圆钢":
                        B_C1.Enabled = false; B_K1.Enabled = false; B_G1.Enabled = false; J_C1.Enabled = false; Y_W1.Enabled = true; Y_C1.Enabled = true; Y_B1.Enabled = true; C_C1.Enabled = false; G_C1.Enabled = false; F_C1.Enabled = false;
                        break;
                    case "圆管":
                        B_C1.Enabled = false; B_K1.Enabled = false; B_G1.Enabled = false; J_C1.Enabled = false; Y_W1.Enabled = true; Y_C1.Enabled = true; Y_B1.Enabled = true; C_C1.Enabled = false; G_C1.Enabled = false; F_C1.Enabled = false;
                        break;
                    case "槽钢":
                        B_C1.Enabled = false; B_K1.Enabled = false; B_G1.Enabled = false; J_C1.Enabled = false; Y_W1.Enabled = false; Y_C1.Enabled = false; Y_B1.Enabled = false; C_C1.Enabled = true; G_C1.Enabled = false; F_C1.Enabled = false;
                        break;
                    case "工字钢":
                        B_C1.Enabled = false; B_K1.Enabled = false; B_G1.Enabled = false; J_C1.Enabled = false; Y_W1.Enabled = false; Y_C1.Enabled = false; Y_B1.Enabled = false; C_C1.Enabled = false; G_C1.Enabled = true; F_C1.Enabled = false;
                        break;
                    case "方管":
                        B_C1.Enabled = false; B_K1.Enabled = false; B_G1.Enabled = false; J_C1.Enabled = false; Y_W1.Enabled = false; Y_C1.Enabled = false; Y_B1.Enabled = false; C_C1.Enabled = false; G_C1.Enabled = false; F_C1.Enabled = true;
                        break;

                }
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox2.Text.Trim() != "")
            {
                switch (comboBox2.Text.Trim())
                {
                    case "板":
                        B_C2.Enabled = true; B_K2.Enabled = true; B_G2.Enabled = true; J_C2.Enabled = false; Y_W2.Enabled = false; Y_C2.Enabled = false; Y_B2.Enabled = false; C_C2.Enabled = false; G_C2.Enabled = false; F_C2.Enabled = false;
                        break;
                    case "角钢":
                        B_C2.Enabled = false; B_K2.Enabled = false; B_G2.Enabled = false; J_C2.Enabled = true; Y_W2.Enabled = false; Y_C2.Enabled = false; Y_B2.Enabled = false; C_C2.Enabled = false; G_C2.Enabled = false; F_C2.Enabled = false;
                        break;
                    case "圆钢":
                        B_C2.Enabled = false; B_K2.Enabled = false; B_G2.Enabled = false; J_C2.Enabled = false; Y_W2.Enabled = true; Y_C2.Enabled = true; Y_B2.Enabled = true; C_C2.Enabled = false; G_C2.Enabled = false; F_C2.Enabled = false;
                        break;
                    case "圆管":
                        B_C2.Enabled = false; B_K2.Enabled = false; B_G2.Enabled = false; J_C2.Enabled = false; Y_W2.Enabled = true; Y_C2.Enabled = true; Y_B2.Enabled = true; C_C2.Enabled = false; G_C2.Enabled = false; F_C2.Enabled = false;
                        break;
                    case "槽钢":
                        B_C2.Enabled = false; B_K2.Enabled = false; B_G2.Enabled = false; J_C2.Enabled = false; Y_W2.Enabled = false; Y_C2.Enabled = false; Y_B2.Enabled = false; C_C2.Enabled = true; G_C2.Enabled = false; F_C2.Enabled = false;
                        break;
                    case "工字钢":
                        B_C2.Enabled = false; B_K2.Enabled = false; B_G2.Enabled = false; J_C2.Enabled = false; Y_W2.Enabled = false; Y_C2.Enabled = false; Y_B2.Enabled = false; C_C2.Enabled = false; G_C2.Enabled = true; F_C2.Enabled = false;
                        break;
                    case "方管":
                        B_C2.Enabled = false; B_K2.Enabled = false; B_G2.Enabled = false; J_C2.Enabled = false; Y_W2.Enabled = false; Y_C2.Enabled = false; Y_B2.Enabled = false; C_C2.Enabled = false; G_C2.Enabled = false; F_C2.Enabled = true;
                        break;

                }
            }
        }

        private void comboBox3_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox3.Text.Trim() != "")
            {
                switch (comboBox3.Text.Trim())
                {
                    case "板":
                        B_C3.Enabled = true; B_K3.Enabled = true; B_G3.Enabled = true; J_C3.Enabled = false; Y_W3.Enabled = false; Y_C3.Enabled = false; Y_B3.Enabled = false; C_C3.Enabled = false; G_C3.Enabled = false; F_C3.Enabled = false;
                        break;
                    case "角钢":
                        B_C3.Enabled = false; B_K3.Enabled = false; B_G3.Enabled = false; J_C3.Enabled = true; Y_W3.Enabled = false; Y_C3.Enabled = false; Y_B3.Enabled = false; C_C3.Enabled = false; G_C3.Enabled = false; F_C3.Enabled = false;
                        break;
                    case "圆钢":
                        B_C3.Enabled = false; B_K3.Enabled = false; B_G3.Enabled = false; J_C3.Enabled = false; Y_W3.Enabled = true; Y_C3.Enabled = true; Y_B3.Enabled = true; C_C3.Enabled = false; G_C3.Enabled = false; F_C3.Enabled = false;
                        break;
                    case "圆管":
                        B_C3.Enabled = false; B_K3.Enabled = false; B_G3.Enabled = false; J_C3.Enabled = false; Y_W3.Enabled = true; Y_C3.Enabled = true; Y_B3.Enabled = true; C_C3.Enabled = false; G_C3.Enabled = false; F_C3.Enabled = false;
                        break;
                    case "槽钢":
                        B_C3.Enabled = false; B_K3.Enabled = false; B_G3.Enabled = false; J_C3.Enabled = false; Y_W3.Enabled = false; Y_C3.Enabled = false; Y_B3.Enabled = false; C_C3.Enabled = true; G_C3.Enabled = false; F_C3.Enabled = false;
                        break;
                    case "工字钢":
                        B_C3.Enabled = false; B_K3.Enabled = false; B_G3.Enabled = false; J_C3.Enabled = false; Y_W3.Enabled = false; Y_C3.Enabled = false; Y_B3.Enabled = false; C_C3.Enabled = false; G_C3.Enabled = true; F_C3.Enabled = false;
                        break;
                    case "方管":
                        B_C3.Enabled = false; B_K3.Enabled = false; B_G3.Enabled = false; J_C3.Enabled = false; Y_W3.Enabled = false; Y_C3.Enabled = false; Y_B3.Enabled = false; C_C3.Enabled = false; G_C3.Enabled = false; F_C3.Enabled = true;
                        break;

                }
            }
        }

        private void comboBox4_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox4.Text.Trim() != "")
            {
                switch (comboBox4.Text.Trim())
                {
                    case "板":
                        B_C4.Enabled = true; B_K4.Enabled = true; B_G4.Enabled = true; J_C4.Enabled = false; Y_W4.Enabled = false; Y_C4.Enabled = false; Y_B4.Enabled = false; C_C4.Enabled = false; G_C4.Enabled = false; F_C4.Enabled = false;
                        break;
                    case "角钢":
                        B_C4.Enabled = false; B_K4.Enabled = false; B_G4.Enabled = false; J_C4.Enabled = true; Y_W4.Enabled = false; Y_C4.Enabled = false; Y_B4.Enabled = false; C_C4.Enabled = false; G_C4.Enabled = false; F_C4.Enabled = false;
                        break;
                    case "圆钢":
                        B_C4.Enabled = false; B_K4.Enabled = false; B_G4.Enabled = false; J_C4.Enabled = false; Y_W4.Enabled = true; Y_C4.Enabled = true; Y_B4.Enabled = true; C_C4.Enabled = false; G_C4.Enabled = false; F_C4.Enabled = false;
                        break;
                    case "圆管":
                        B_C4.Enabled = false; B_K4.Enabled = false; B_G4.Enabled = false; J_C4.Enabled = false; Y_W4.Enabled = true; Y_C4.Enabled = true; Y_B4.Enabled = true; C_C4.Enabled = false; G_C4.Enabled = false; F_C4.Enabled = false;
                        break;
                    case "槽钢":
                        B_C4.Enabled = false; B_K4.Enabled = false; B_G4.Enabled = false; J_C4.Enabled = false; Y_W4.Enabled = false; Y_C4.Enabled = false; Y_B4.Enabled = false; C_C4.Enabled = true; G_C4.Enabled = false; F_C4.Enabled = false;
                        break;
                    case "工字钢":
                        B_C4.Enabled = false; B_K4.Enabled = false; B_G4.Enabled = false; J_C4.Enabled = false; Y_W4.Enabled = false; Y_C4.Enabled = false; Y_B4.Enabled = false; C_C4.Enabled = false; G_C4.Enabled = true; F_C4.Enabled = false;
                        break;
                    case "方管":
                        B_C4.Enabled = false; B_K4.Enabled = false; B_G4.Enabled = false; J_C4.Enabled = false; Y_W4.Enabled = false; Y_C4.Enabled = false; Y_B4.Enabled = false; C_C4.Enabled = false; G_C4.Enabled = false; F_C4.Enabled = true;
                        break;

                }
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            zhongliang1 = zl1.Text.Trim();
            zhongliang2 = zl2.Text.Trim();
            zhongliang3 = zl3.Text.Trim();
            zhongliang4 = zl4.Text.Trim();
            cailiao1 = comboBox1.Text.Trim() + comboBox5.Text.Trim();
            cailiao2 = comboBox2.Text.Trim() + comboBox6.Text.Trim();
            cailiao3 = comboBox3.Text.Trim() + comboBox7.Text.Trim();
            cailiao4 = comboBox4.Text.Trim() + comboBox8.Text.Trim();
        }

        private void button2_Click_2(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;
            zhongliang1 = zl1.Text.Trim();
            zhongliang2 = zl2.Text.Trim();
            zhongliang3 = zl3.Text.Trim();
            zhongliang4 = zl4.Text.Trim();
            cailiao1 = comboBox1.Text.Trim() + comboBox5.Text.Trim();
            cailiao2 = comboBox2.Text.Trim() + comboBox6.Text.Trim(); 
            cailiao3 = comboBox3.Text.Trim() + comboBox7.Text.Trim();
            cailiao4 = comboBox4.Text.Trim() + comboBox8.Text.Trim();
        }

        private double jisuanzhongliang(string cailiao, string k1, string k2, string k3, string k4, string k5, string k6, string k7, string k8, string k9, string k10)
        {
            double a1, b1, c1, a2, a3, b3, c3, a4, a5, a6;
            if (k1 != "" && k2 != "" && k3 != "")
            {
                a1 = Convert.ToDouble(k1);
                b1 = Convert.ToDouble(k2);
                c1 = Convert.ToDouble(k3);
                w = (a1 * b1 * c1) / 1000000000;
            }

            if (k4 != "")
            {
                a2 = Convert.ToDouble(k4);
                w = a2 / 1000000;
            }

            if (k5 != "" && k6 != "" && k7 != "")
            {
                a3 = Convert.ToDouble(k5);//外径
                b3 = Convert.ToDouble(k6);//长
                c3 = Convert.ToDouble(k7);//壁厚
                switch (cailiao)
                {
                    case "圆管":
                        w = (((Math.Pow((a3 / 2), 2) * 3.14) - (Math.Pow((a3 - 2 * c3) / 2, 2) * 3.14)) * b3) / 1000000000;
                        break;
                    case "圆钢":
                        w = ((Math.Pow((a3 / 2), 2) * 3.14) * b3) / 1000000000;
                        break;
                }

            }

            if (k8 != "")
            {
                a4 = Convert.ToDouble(k8);
                w = a4 / 1000000;
            }

            if (k9 != "")
            {
                a5 = Convert.ToDouble(k9);
                w = a5 / 1000000;
            }

            if (k10 != "")
            {
                a6 = Convert.ToDouble(k10);
                w = a6 / 1000000;
            }

            return w;
        }
}
}
