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
    public partial class FrmPressUpdate : Form
    {
        SQLHelp DB;
        DataTable dt;
        public readonly int pressNo;
        public FrmPressUpdate(int pressNo)
        {
            InitializeComponent();
            this.pressNo = pressNo;
        }

        private void FrmPressUpdate_Load(object sender, EventArgs e)
        {
            DB = new SQLHelp();
            //记载下拉列表框
            LoadComboxData();

            string sql = "select * from 出版社 where 编号=@p1";
            dt = DB.FillDataTable(sql, pressNo);
            if (dt.Rows.Count > 0)
            {
                txtName.Text = dt.Rows[0]["名称"].ToString();
                cboCategory.SelectedValue = dt.Rows[0]["类别编号"].ToString();
                numPurchase.Value = (int)dt.Rows[0]["购书数量"];
            }
            else
            {
                MessageBox.Show("未查询出版社的信息");
                this.Close();
            }
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
            Console.WriteLine(purchaseNum);

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

            string sql = "update 出版社 set 名称=@p1,类别编号=@p2,购书数量=@p3 where 编号=@p4";
            DB.ExecuteNoQuery(sql,pressName,category,purchaseNum,pressNo);
            MessageBox.Show("修改出版社成功");

            DialogResult = DialogResult.OK;
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
