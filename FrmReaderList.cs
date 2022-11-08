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
    public partial class FrmReaderList : Form
    {
        SQLHelp DB;
        DataTable dt = new DataTable("读者信息");
        public FrmReaderList()
        {
            InitializeComponent();
            dataGridView1.AutoGenerateColumns = false;
        }
        private void FrmReaderList_Load(object sender, EventArgs e)
        {
            DB = new SQLHelp();
            Query();
        }
        /// <summary>
        /// 查询数据
        /// </summary>
        void Query()
        {
            string readerNo = "%" + txtNo.Text + "%";
            string name = "%" + txtName.Text + "%";
            string sql = "select * from 读者信息 where 卡号 like @p1 and 姓名 like @p2";
            dt = DB.FillDataTable(sql, readerNo, name);

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
            string readerNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            //打开修改页面
            FrmReaderUpdate form = new FrmReaderUpdate(readerNo);
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
            string readerNo = dataGridView1.CurrentRow.Cells[0].Value.ToString();

            //删除数据
            if (MessageBox.Show("确认要删除此读者信息吗？", "删除确认", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                string sql = "delete from 读者信息 where 卡号=@p1";
                DB.ExecuteNoQuery(sql, readerNo);

                MessageBox.Show("删除读者信息成功");
                Query();
            }
            
        }
    }
}
