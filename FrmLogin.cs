using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using 图书管理系统.CommonLib;

namespace 图书管理系统
{
    public partial class FrmLogin : Form
    {
        SQLHelp DB;
        DataTable dt;
        public FrmLogin()
        {
            InitializeComponent();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.No;
        }

        private void FrmLogin_Load(object sender, EventArgs e)
        {
            DB = new SQLHelp();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            string account = this.txtAccount.Text;
            string password = this.txtPassword.Text;
            if (string.IsNullOrEmpty(account))
            {
                this.txtAccount.BackColor = Color.Cyan;
                this.txtAccount.Focus();
                this.lblMsg.Text = "用户名不能为空！";
                return;
            }
            if (String.IsNullOrEmpty(password))
            {
                this.txtPassword.BackColor = Color.Cyan;
                this.txtPassword.Focus();
                this.lblMsg.Text = "密码不能为空！";
                return;
            }

            string identity = "";
            string sql = "";

            if (rdoManager.Checked)
            {
                identity = "管理员";
                sql = "select * from 管理员 where 账号=@p1 and 密码=@p2";
            }
            else
            {
                identity = "读者";
                sql = "select * from 读者信息 where 卡号=@p1 and 密码=@p2";
            }

            dt = DB.FillDataTable(sql, account, password);
            if (dt.Rows.Count > 0)
            {
                this.DialogResult = DialogResult.Yes;
                GlobalParameter.account = account;
                GlobalParameter.password = password;
                GlobalParameter.name = dt.Rows[0]["姓名"].ToString();
                GlobalParameter.identity = identity;
            }
            else
            {
                MessageBox.Show("账号密码输入有误");
            }
        }
    }
}
