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
    public partial class FrmBookUpdate : Form
    {
        SQLHelp DB;
        DataTable dt = new DataTable();
        public readonly string bookNo1;
        public FrmBookUpdate(string bookNo)
        {
            InitializeComponent();
            this.bookNo1 = bookNo;
        }

        private void FrmBookUpdate_Load(object sender, EventArgs e)
        {
            DB = new SQLHelp();
            //记载下拉列表框
            LoadComboxData();

            //查询出版社信息
            string sql = "select * from 图书 where 书号=@p1";
            dt = DB.FillDataTable(sql,bookNo1);
            if (dt.Rows.Count > 0)
            {
                txtBookNo.Text = dt.Rows[0]["书号"].ToString();
                txtBookName.Text = dt.Rows[0]["书名"].ToString();
                txtAuthor.Text = dt.Rows[0]["作者"].ToString();
                cboPress.SelectedValue = dt.Rows[0]["出版社编号"].ToString();
                txtDate.Text = dt.Rows[0]["首版年月"].ToString();
                cboCategory.SelectedValue = dt.Rows[0]["种类编号"].ToString();
                numPrice.Value = (decimal)dt.Rows[0]["单价"];
                numAmount.Value = (int)dt.Rows[0]["数量"];
                if (dt.Rows[0]["备注"] != null)
                {
                    txtNote.Text = dt.Rows[0]["备注"].ToString();
                }
            }
            else
            {
                MessageBox.Show("未查询图书的信息");
                this.Close();
            }
        }

        void LoadComboxData()
        {
            string sql = "select * from 出版社";
            cboPress.DisplayMember = "名称";
            cboPress.ValueMember = "编号";

            dt = DB.FillDataTable(sql);
            cboPress.DataSource = dt;

            cboPress.SelectedIndex = -1;

            sql = "select * from 图书种类";
            cboCategory.DisplayMember = "名称";
            cboCategory.ValueMember = "编号";

            dt = DB.FillDataTable(sql);
            cboCategory.DataSource = dt;

            cboCategory.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string bookNo = this.txtBookNo.Text;
            string bookName = this.txtBookName.Text;
            string author = this.txtAuthor.Text;
            string pressNo = string.Empty;
            if (this.cboPress.SelectedValue != null)
            {
                pressNo = this.cboPress.SelectedValue.ToString();
            }
            string publishTime = this.txtDate.Text;
            string category = string.Empty;
            if (this.cboCategory.SelectedValue != null)
            {
                category = this.cboCategory.SelectedValue.ToString();
            }
            string price = this.numPrice.Value.ToString();
            string number = this.numAmount.Value.ToString();
            string note = string.Empty;
            if (this.txtNote.Text != null)
            {
                note = this.txtNote.Text;
            }

            if (string.IsNullOrEmpty(bookNo))
            {
                this.txtBookNo.BackColor = Color.Cyan;
                this.txtBookNo.Focus();
                this.lblMsg.Text = "请输入书号！";
                return;
            }
            if (string.IsNullOrEmpty(bookName))
            {
                this.txtBookName.BackColor = Color.Cyan;
                this.txtBookName.Focus();
                this.lblMsg.Text = "请输入书名！";
                return;
            }
            if (string.IsNullOrEmpty(author))
            {
                this.txtAuthor.BackColor = Color.Cyan;
                this.txtAuthor.Focus();
                this.lblMsg.Text = "请输入作者！";
                return;
            }
            if (string.IsNullOrEmpty(pressNo))
            {
                this.cboPress.BackColor = Color.Cyan;
                this.cboPress.Focus();
                this.lblMsg.Text = "请选择出版社！";
                return;
            }
            if (string.IsNullOrEmpty(publishTime))
            {
                this.txtDate.BackColor = Color.Cyan;
                this.txtDate.Focus();
                this.lblMsg.Text = "请输入首版年月！";
                return;
            }
            if (string.IsNullOrEmpty(category))
            {
                this.cboCategory.BackColor = Color.Cyan;
                this.cboCategory.Focus();
                this.lblMsg.Text = "请选择种类！";
                return;
            }

            string sql = "update 图书 set 书号=@p1,书名=@p2,作者=@p3,出版社编号=@p4,首版年月=@p5,种类编号=@p6,单价=@p7,数量=@p8,备注=@p9 where 书号=@p10";
            
            DB.ExecuteNoQuery(sql,bookNo,bookName,author,pressNo,publishTime,category,price,number,note,bookNo1);
            MessageBox.Show("修改图书成功");
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
