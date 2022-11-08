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
    public partial class FrmLendBook : Form
    {
        SQLHelp DB;
        DataTable dt = new DataTable("图书");
        public FrmLendBook()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }
        private void FrmLendBook_Load(object sender, EventArgs e)
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
            //只显示库存大于0的图书
            string sql = "select 图书.*,出版社.名称 as 出版社,图书种类.名称 as 种类 from 图书,出版社,图书种类 " +
                "where 图书.出版社编号=出版社.编号 and 图书.种类编号=图书种类.编号 " +
                "and 图书.书号 like @p1 and 图书.书名 like @p2 and 图书.出版社编号 like @p3 and 图书.种类编号 like @p4 and 图书.数量>0";
            dt = DB.FillDataTable(sql, bookNo, bookName,PressNo,CategoryNo);

            dataGridView1.DataSource = dt;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void btnLend_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            string bookNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            //打开修改页面
            FrmLendConfirm form = new FrmLendConfirm(bookNo);
            DialogResult dr = form.ShowDialog();
            if(dr == DialogResult.OK)
            {
                Query();
            }

        }
       
    }
}
