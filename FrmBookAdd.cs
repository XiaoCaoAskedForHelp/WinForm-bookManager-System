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
    public partial class FrmBookAdd : Form
    {
        SQLHelp DB;
        DataTable dt;
        public FrmBookAdd()
        {
            InitializeComponent();
        }

        private void FrmBookAdd_Load(object sender, EventArgs e)
        {
            DB = new SQLHelp();
            //记载下拉列表框
            LoadComboxData();
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

            string sql = "insert into 图书(书号,书名,作者,出版社编号,首版年月,种类编号,单价,数量,备注) " +
                "values(@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9)";
            
            DB.ExecuteNoQuery(sql,bookNo,bookName,author,pressNo,publishTime,category,price,number,note);
            MessageBox.Show("新增图书成功");

            //清空界面数据
            this.txtBookNo.Clear();
            this.txtBookName.Clear();
            this.txtAuthor.Clear();
            this.cboPress.SelectedIndex = -1;
            this.txtDate.Clear();
            this.cboCategory.SelectedIndex = -1;
            this.numPrice.Value = 0;
            this.numAmount.Value = 0;
            this.txtNote.Clear();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
