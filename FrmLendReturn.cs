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
    public partial class FrmLendReturn : Form
    {
        SQLHelp DB;
        DataTable dt = new DataTable("图书");
        public FrmLendReturn()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }
        private void FrmLendReturn_Load(object sender, EventArgs e)
        {
            DB = new SQLHelp();
            LoadComboxData();
            Query();
        }

        void LoadComboxData()
        {
            string sql = "select null as 编号,'请选择' as 名称 union select 编号,名称 from 出版社";
            cboPress.DisplayMember = "名称";
            cboPress.ValueMember = "编号";

            dt = DB.FillDataTable(sql);
            cboCategory.DataSource = null;
            cboPress.DataSource = dt;

            sql = "select null as 编号,'请选择' as 名称 union select 编号,名称 from 图书种类";
            cboCategory.DisplayMember = "名称";
            cboCategory.ValueMember = "编号";

            dt = DB.FillDataTable(sql);
            cboCategory.DataSource = null;
            cboCategory.DataSource = dt;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        void Query()
        {
            string bookNo = "%" + txtBookNo.Text + "%";
            string bookName = "%" + txtBookName.Text + "%";
            string PressNo = string.Empty;
            string CategoryNo = string.Empty;
            if (cboPress.SelectedValue != null)
            {
                PressNo = "%" + cboPress.SelectedValue.ToString() + "%";
            }
            if (cboCategory.SelectedValue != null)
            {
                CategoryNo = "%" + cboCategory.SelectedValue.ToString() + "%";
            }
            //只显示读者未归还的图书
            string sql = "select 图书.*,出版社.名称 as 出版社,图书种类.名称 as 种类,借书记录.借书日期,借书记录.数量 as 借书数量 from 图书,出版社,图书种类,借书记录 " +
                "where 图书.出版社编号=出版社.编号 and 图书.种类编号=图书种类.编号 and 图书.书号=借书记录.图书书号 and 借书记录.读者卡号=@p1 and 借书记录.状态='借阅中' " +
                "and 图书.书号 like @p2 and 图书.书名 like @p3 and 图书.出版社编号 like @p4 and 图书.种类编号 like @p5";
            dt = DB.FillDataTable(sql,GlobalParameter.account ,bookNo, bookName,PressNo,CategoryNo);

            dataGridView1.DataSource = dt;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            string bookNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            int lendNumber = (int)dataGridView1.CurrentRow.Cells[4].Value;

            try
            {
                //事务
                DB.BeginTransaction();
                string sql = "update 图书 set 数量=数量+@p1 where 书号=@p2";
                DB.ExecuteNoQuery(sql, lendNumber, bookNo);

                sql = "update 借书记录 set 状态=@p1,还书日期=getdate() where 读者卡号=@p2 and 图书书号=@p3 and 数量=@p4";
                DB.ExecuteNoQuery(sql, "已归还", GlobalParameter.account, bookNo, lendNumber);
                DB.Commit();
                MessageBox.Show("归还成功");
                Query();
            }
            catch
            {
                DB.Rollback();
            }
        }
       
    }
}
