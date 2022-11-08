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
    public partial class FrmLendConfirm : Form
    {
        SQLHelp DB;
        DataTable dt = new DataTable();
        public readonly string bookNo1;
        public FrmLendConfirm(string bookNo)
        {
            InitializeComponent();
            this.bookNo1 = bookNo;
        }

        private void FrmLendConfirm_Load(object sender, EventArgs e)
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

            sql = "select * from 图书种类";
            cboCategory.DisplayMember = "名称";
            cboCategory.ValueMember = "编号";

            dt = DB.FillDataTable(sql);
            cboCategory.DataSource = dt;
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            string bookNo = this.txtBookNo.Text;
            
            int storeNumber = (int)this.numAmount.Value;
            int lendNumber = (int)this.numLend.Value;

            if (lendNumber < 1)
            {
                MessageBox.Show("借书数量不能小于1！");
                return;
            }

            if (storeNumber < lendNumber)
            {
                MessageBox.Show("库存数量不足。无法借书！");
                return;
            }
            try
            {
                //事务
                DB.BeginTransaction();
                string sql = "update 图书 set 数量=数量-@p1 where 书号=@p2";
                DB.ExecuteNoQuery(sql, lendNumber, bookNo);
                sql = "insert into 借书记录(读者卡号,图书书号,数量,状态) " +
                    "values(@p1,@p2,@p3,@p4)";
                DB.ExecuteNoQuery(sql, GlobalParameter.account, bookNo, lendNumber, "借阅中");
                DB.Commit();
                MessageBox.Show("借书成功");
                DialogResult = DialogResult.OK;
            }
            catch
            {
                DB.Rollback();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
