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
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            FrmLogin login = new FrmLogin();

            if (login.ShowDialog() != DialogResult.Yes)
            {
                this.Close();
            }
            else
            {
                this.toolStripStatusLabel1.Text = "用户:" + GlobalParameter.name;
            }

            if (GlobalParameter.identity == "管理员")
            {
                借还管理ToolStripMenuItem.Visible = false;
            }
            if (GlobalParameter.identity == "读者")
            {
                图书管理ToolStripMenuItem.Visible = false;
                出版社管理ToolStripMenuItem.Visible = false;
                读者管理ToolStripMenuItem.Visible = false;
            }
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            this.toolStripStatusLabel2.Text = "系统当前时间：" + DateTime.Now.ToString("yyyy-MM-dd hh:mm:ss");
        }

        private void 新增读者ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReaderAdd form = new FrmReaderAdd();
            form.ShowDialog();
        }

        private void 读者列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmReaderList form = new FrmReaderList();
            form.MdiParent = this;
            form.Show();
        }

        private void 新增出版社ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPressAdd form = new FrmPressAdd();
            form.ShowDialog();
        }

        private void 出版社列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmPressList form = new FrmPressList();
            form.MdiParent = this;
            form.Show();
        }

        private void 新增图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBookAdd form = new FrmBookAdd();
            form.ShowDialog();
        }

        private void 图书列表ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmBookList form = new FrmBookList();
            form.MdiParent = this;
            form.Show();
        }

        private void 借阅ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLendBook form = new FrmLendBook();
            form.MdiParent = this;
            form.Show();
        }

        private void 还书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLendReturn form = new FrmLendReturn();
            form.MdiParent = this;
            form.Show();
        }

        private void 借还记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLendRecord form = new FrmLendRecord();
            form.MdiParent = this;
            form.Show();
        }

        private void 切换用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Application.Restart();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("真的要退出系统么？", "图书管理系统", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void 逾期记录ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FrmLendOverdue form = new FrmLendOverdue();
            form.MdiParent = this;
            form.Show();
        }

    }
}
