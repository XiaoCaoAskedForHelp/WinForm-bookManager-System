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
    public partial class FrmLendRecord : Form
    {
        SQLHelp DB;
        DataTable dt = new DataTable("图书");
        public FrmLendRecord()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }
        private void FrmLendRecord_Load(object sender, EventArgs e)
        {
            DB = new SQLHelp();
            //管理员显示读者卡号搜索框
            if (GlobalParameter.identity == "管理员")
            {
                label5.Visible = true;
                txtReaderNo.Visible = true;
            }
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
            string ReaderNo = "%" + txtReaderNo.Text + "%";
            if (cboPress.SelectedValue != null)
            {
                PressNo = "%" + cboPress.SelectedValue.ToString() + "%";
            }
            if (cboCategory.SelectedValue != null)
            {
                CategoryNo = "%" + cboCategory.SelectedValue.ToString() + "%";
            }
            string sql = "select 图书.*,出版社.名称 as 出版社,图书种类.名称 as 种类,借书记录.借书日期,借书记录.数量 as 借书数量,借书记录.状态,借书记录.还书日期,借书记录.读者卡号 from 图书,出版社,图书种类,借书记录 " +
                "where 图书.出版社编号=出版社.编号 and 图书.种类编号=图书种类.编号 and 图书.书号=借书记录.图书书号 " +
                "and 图书.书号 like @p1 and 图书.书名 like @p2 and 图书.出版社编号 like @p3 and 图书.种类编号 like @p4 and 借书记录.读者卡号 like @p5 ";
            //不同角色查询范围不同
            if (GlobalParameter.identity == "读者")
            {
                sql += " and 借书记录.读者卡号=@p6 ";
                dt = DB.FillDataTable(sql, bookNo, bookName, PressNo, CategoryNo,ReaderNo, GlobalParameter.account);
            }
            else
            {
                dt = DB.FillDataTable(sql, bookNo, bookName, PressNo, CategoryNo, ReaderNo);
            }

            dataGridView1.DataSource = dt;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Query();
        }
       
    }
}
