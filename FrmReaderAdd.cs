using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace 图书管理系统
{
    public partial class FrmReaderAdd : Form
    {
        SQLHelp DB;
        DataTable dt = new DataTable("读者信息");
        public FrmReaderAdd()
        {
            InitializeComponent();
        }

        private void FrmAddReader_Load(object sender, EventArgs e)
        {
            DB = new SQLHelp();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string account = this.txtNo.Text;
            string name = this.txtName.Text;
            string password = this.txtPwd.Text;

            if (string.IsNullOrEmpty(account))
            {
                this.txtNo.BackColor = Color.Cyan;
                this.txtNo.Focus();
                this.lblMsg.Text = "卡号不能为空！";
                return;
            }
            if (string.IsNullOrEmpty(name))
            {
                this.txtName.BackColor = Color.Cyan;
                this.txtName.Focus();
                this.lblMsg.Text = "姓名不能为空！";
                return;
            }
            if (String.IsNullOrEmpty(password))
            {
                this.txtPwd.BackColor = Color.Cyan;
                this.txtPwd.Focus();
                this.lblMsg.Text = "密码不能为空！";
                return;
            }

            string sql = "insert into 读者信息(卡号,姓名,密码) values(@p1,@p2,@p3)";
            DB.ExecuteNoQuery(sql, account, name, password);
            MessageBox.Show("新增读者成功");

            //清空界面数据
            this.txtNo.Clear();
            this.txtName.Clear();
            this.txtPwd.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lblMsg_Click(object sender, EventArgs e)
        {

        }

        private void txtPwd_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtName_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtNo_TextChanged(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
