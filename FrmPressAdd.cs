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
    public partial class FrmPressAdd : Form
    {
        SQLHelp DB;
        DataTable dt;
        public FrmPressAdd()
        {
            InitializeComponent();
        }

        private void FrmPressAdd_Load(object sender, EventArgs e)
        {
            DB = new SQLHelp();
            //记载下拉列表框
            LoadComboxData();
        }

        void LoadComboxData()
        {
            string sql = "select * from 出版社类别";
            cboCategory.DisplayMember = "名称";
            cboCategory.ValueMember = "编号";

            dt = DB.FillDataTable(sql);
            cboCategory.DataSource = dt;

            cboCategory.SelectedIndex = -1;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string pressName = this.txtName.Text;
            string category = string.Empty;
            if (this.cboCategory.SelectedValue != null)
            {
                category = this.cboCategory.SelectedValue.ToString();
            }
            string purchaseNum = this.numPurchase.Value.ToString();

            if (string.IsNullOrEmpty(pressName))
            {
                this.txtName.BackColor = Color.Cyan;
                this.txtName.Focus();
                this.lblMsg.Text = "出版社名称不能为空！";
                return;
            }
            if (string.IsNullOrEmpty(category))
            {
                this.cboCategory.BackColor = Color.Cyan;
                this.cboCategory.Focus();
                this.lblMsg.Text = "请选择类别！";
                return;
            }

            string sql = "insert into 出版社(名称,类别编号,购书数量) values(@p1,@p2,@p3)";
            DB.ExecuteNoQuery(sql, pressName,category, purchaseNum);
            MessageBox.Show("新增出版社成功");

            //清空界面数据
            this.txtName.Clear();
            cboCategory.SelectedIndex = -1;
            numPurchase.Value = 0;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
