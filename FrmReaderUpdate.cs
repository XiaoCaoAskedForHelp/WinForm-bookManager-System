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
    public partial class FrmReaderUpdate : Form
    {
        SQLHelp DB;
        DataTable dt = new DataTable("读者信息");
        private readonly string account;
        public FrmReaderUpdate(string account)
        {
            InitializeComponent();
            this.account = account;
        }

        private void FrmReaderUpdate_Load(object sender, EventArgs e)
        {
            DB = new SQLHelp();
            //查询读者信息
            string sql = "select * from 读者信息 where 卡号=@p1";
            dt = DB.FillDataTable(sql, account);
            if (dt.Rows.Count > 0)
            {
                txtNo.Text = dt.Rows[0]["卡号"].ToString();
                txtName.Text = dt.Rows[0]["姓名"].ToString();
                txtPwd.Text = dt.Rows[0]["密码"].ToString();
            }
            else
            {
                MessageBox.Show("未查询读者的信息");
                this.Close();
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string nowaccount = this.txtNo.Text;
            string name = this.txtName.Text;
            string password = this.txtPwd.Text;
            if (string.IsNullOrEmpty(nowaccount))
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

            string sql = "update 读者信息 set 卡号=@p1,姓名=@p2,密码=@p3 where 卡号=@p4";
            DB.ExecuteNoQuery(sql, nowaccount, name, password,account);
            MessageBox.Show("修改读者成功");

            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
