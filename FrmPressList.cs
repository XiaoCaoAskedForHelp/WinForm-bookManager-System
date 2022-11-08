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
    public partial class FrmPressList : Form
    {
        SQLHelp DB;
        DataTable dt = new DataTable("出版社");
        public FrmPressList()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }
        private void FrmPressList_Load(object sender, EventArgs e)
        {
            DB = new SQLHelp();
            LoadComboxData();
            Query();
        }

        void LoadComboxData()
        {
            string sql = "select null as 编号,'请选择' as 名称 union select 编号,名称 from 出版社类别";
            cboCategory.DisplayMember = "名称";
            cboCategory.ValueMember = "编号";

            dt = DB.FillDataTable(sql);
            cboCategory.DataSource = dt;
        }

        /// <summary>
        /// 查询数据
        /// </summary>
        void Query()
        {
            string PressName = "%" + txtName.Text + "%";
            string category = string.Empty;
            if (cboCategory.SelectedValue != null)
            {
                category = "%" + cboCategory.SelectedValue.ToString() + "%";
            }
            string sql = "select 出版社.*,出版社类别.名称 as 类别 from 出版社,出版社类别 " +
                "where 出版社.类别编号=出版社类别.编号 and 出版社.名称 like @p1 and 出版社.类别编号 like @p2";
            dt = DB.FillDataTable(sql, PressName, category);

            dataGridView1.DataSource = null;
            dataGridView1.DataSource = dt;
        }

        private void btnSelect_Click(object sender, EventArgs e)
        {
            Query();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            int pressNo = (int)dataGridView1.CurrentRow.Cells[0].Value;

            //打开修改页面
            FrmPressUpdate form = new FrmPressUpdate(pressNo);
            DialogResult dr = form.ShowDialog();
            if(dr == DialogResult.OK)
            {
                Query();
            }

        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.CurrentRow.Index < 0)
            {
                return;
            }
            int pressNo = (int)dataGridView1.CurrentRow.Cells[0].Value;

            //删除数据
            if (MessageBox.Show("确认要删除此出版社信息吗？", "删除确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string sql = "delete from 出版社 where 编号=@p1";
                DB.ExecuteNoQuery(sql, pressNo);

                MessageBox.Show("删除出版社信息成功");
                Query();
            }
            
        }
    }
}
