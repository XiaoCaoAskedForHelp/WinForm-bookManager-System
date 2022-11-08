
namespace 图书管理系统
{
    partial class FrmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.toolStripStatusLabel1 = new System.Windows.Forms.ToolStripStatusLabel();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.toolStripStatusLabel2 = new System.Windows.Forms.ToolStripStatusLabel();
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.读者管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增读者ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.读者列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出版社管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增出版社ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.出版社列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图书管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.新增图书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图书列表ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借还管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借阅ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.还书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询统计ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借还记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.逾期记录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出登录ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出系统ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.statusStrip1.SuspendLayout();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // timer1
            // 
            this.timer1.Enabled = true;
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // toolStripStatusLabel1
            // 
            this.toolStripStatusLabel1.Name = "toolStripStatusLabel1";
            this.toolStripStatusLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.toolStripStatusLabel1.Size = new System.Drawing.Size(167, 20);
            this.toolStripStatusLabel1.Text = "toolStripStatusLabel1";
            // 
            // statusStrip1
            // 
            this.statusStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.toolStripStatusLabel1,
            this.toolStripStatusLabel2});
            this.statusStrip1.Location = new System.Drawing.Point(0, 499);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.statusStrip1.Size = new System.Drawing.Size(912, 26);
            this.statusStrip1.TabIndex = 0;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // toolStripStatusLabel2
            // 
            this.toolStripStatusLabel2.Name = "toolStripStatusLabel2";
            this.toolStripStatusLabel2.Size = new System.Drawing.Size(69, 20);
            this.toolStripStatusLabel2.Text = "系统时间";
            this.toolStripStatusLabel2.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // menuStrip1
            // 
            this.menuStrip1.Font = new System.Drawing.Font("Microsoft YaHei UI", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.menuStrip1.ImageScalingSize = new System.Drawing.Size(20, 20);
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.读者管理ToolStripMenuItem,
            this.出版社管理ToolStripMenuItem,
            this.图书管理ToolStripMenuItem,
            this.借还管理ToolStripMenuItem,
            this.查询统计ToolStripMenuItem,
            this.退出登录ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(912, 30);
            this.menuStrip1.TabIndex = 2;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 读者管理ToolStripMenuItem
            // 
            this.读者管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增读者ToolStripMenuItem,
            this.读者列表ToolStripMenuItem});
            this.读者管理ToolStripMenuItem.Name = "读者管理ToolStripMenuItem";
            this.读者管理ToolStripMenuItem.Size = new System.Drawing.Size(83, 26);
            this.读者管理ToolStripMenuItem.Text = "学生管理";
            // 
            // 新增读者ToolStripMenuItem
            // 
            this.新增读者ToolStripMenuItem.Name = "新增读者ToolStripMenuItem";
            this.新增读者ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.新增读者ToolStripMenuItem.Text = "新增读者";
            this.新增读者ToolStripMenuItem.Click += new System.EventHandler(this.新增读者ToolStripMenuItem_Click);
            // 
            // 读者列表ToolStripMenuItem
            // 
            this.读者列表ToolStripMenuItem.Name = "读者列表ToolStripMenuItem";
            this.读者列表ToolStripMenuItem.Size = new System.Drawing.Size(224, 26);
            this.读者列表ToolStripMenuItem.Text = "读者列表";
            this.读者列表ToolStripMenuItem.Click += new System.EventHandler(this.读者列表ToolStripMenuItem_Click);
            // 
            // 出版社管理ToolStripMenuItem
            // 
            this.出版社管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增出版社ToolStripMenuItem,
            this.出版社列表ToolStripMenuItem});
            this.出版社管理ToolStripMenuItem.Name = "出版社管理ToolStripMenuItem";
            this.出版社管理ToolStripMenuItem.Size = new System.Drawing.Size(98, 26);
            this.出版社管理ToolStripMenuItem.Text = "出版社管理";
            // 
            // 新增出版社ToolStripMenuItem
            // 
            this.新增出版社ToolStripMenuItem.Name = "新增出版社ToolStripMenuItem";
            this.新增出版社ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.新增出版社ToolStripMenuItem.Text = "新增出版社";
            this.新增出版社ToolStripMenuItem.Click += new System.EventHandler(this.新增出版社ToolStripMenuItem_Click);
            // 
            // 出版社列表ToolStripMenuItem
            // 
            this.出版社列表ToolStripMenuItem.Name = "出版社列表ToolStripMenuItem";
            this.出版社列表ToolStripMenuItem.Size = new System.Drawing.Size(167, 26);
            this.出版社列表ToolStripMenuItem.Text = "出版社列表";
            this.出版社列表ToolStripMenuItem.Click += new System.EventHandler(this.出版社列表ToolStripMenuItem_Click);
            // 
            // 图书管理ToolStripMenuItem
            // 
            this.图书管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.新增图书ToolStripMenuItem,
            this.图书列表ToolStripMenuItem});
            this.图书管理ToolStripMenuItem.Name = "图书管理ToolStripMenuItem";
            this.图书管理ToolStripMenuItem.Size = new System.Drawing.Size(83, 26);
            this.图书管理ToolStripMenuItem.Text = "图书管理";
            // 
            // 新增图书ToolStripMenuItem
            // 
            this.新增图书ToolStripMenuItem.Name = "新增图书ToolStripMenuItem";
            this.新增图书ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.新增图书ToolStripMenuItem.Text = "新增图书";
            this.新增图书ToolStripMenuItem.Click += new System.EventHandler(this.新增图书ToolStripMenuItem_Click);
            // 
            // 图书列表ToolStripMenuItem
            // 
            this.图书列表ToolStripMenuItem.Name = "图书列表ToolStripMenuItem";
            this.图书列表ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.图书列表ToolStripMenuItem.Text = "图书列表";
            this.图书列表ToolStripMenuItem.Click += new System.EventHandler(this.图书列表ToolStripMenuItem_Click);
            // 
            // 借还管理ToolStripMenuItem
            // 
            this.借还管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.借阅ToolStripMenuItem,
            this.还书ToolStripMenuItem});
            this.借还管理ToolStripMenuItem.Name = "借还管理ToolStripMenuItem";
            this.借还管理ToolStripMenuItem.Size = new System.Drawing.Size(83, 26);
            this.借还管理ToolStripMenuItem.Text = "借还管理";
            // 
            // 借阅ToolStripMenuItem
            // 
            this.借阅ToolStripMenuItem.Name = "借阅ToolStripMenuItem";
            this.借阅ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.借阅ToolStripMenuItem.Text = "借阅图书";
            this.借阅ToolStripMenuItem.Click += new System.EventHandler(this.借阅ToolStripMenuItem_Click);
            // 
            // 还书ToolStripMenuItem
            // 
            this.还书ToolStripMenuItem.Name = "还书ToolStripMenuItem";
            this.还书ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.还书ToolStripMenuItem.Text = "归还图书";
            this.还书ToolStripMenuItem.Click += new System.EventHandler(this.还书ToolStripMenuItem_Click);
            // 
            // 查询统计ToolStripMenuItem
            // 
            this.查询统计ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.借还记录ToolStripMenuItem,
            this.逾期记录ToolStripMenuItem});
            this.查询统计ToolStripMenuItem.Name = "查询统计ToolStripMenuItem";
            this.查询统计ToolStripMenuItem.Size = new System.Drawing.Size(83, 26);
            this.查询统计ToolStripMenuItem.Text = "查询统计";
            // 
            // 借还记录ToolStripMenuItem
            // 
            this.借还记录ToolStripMenuItem.Name = "借还记录ToolStripMenuItem";
            this.借还记录ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.借还记录ToolStripMenuItem.Text = "借还记录";
            this.借还记录ToolStripMenuItem.Click += new System.EventHandler(this.借还记录ToolStripMenuItem_Click);
            // 
            // 逾期记录ToolStripMenuItem
            // 
            this.逾期记录ToolStripMenuItem.Name = "逾期记录ToolStripMenuItem";
            this.逾期记录ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.逾期记录ToolStripMenuItem.Text = "逾期记录";
            this.逾期记录ToolStripMenuItem.Click += new System.EventHandler(this.逾期记录ToolStripMenuItem_Click);
            // 
            // 退出登录ToolStripMenuItem
            // 
            this.退出登录ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.退出ToolStripMenuItem,
            this.退出系统ToolStripMenuItem});
            this.退出登录ToolStripMenuItem.Name = "退出登录ToolStripMenuItem";
            this.退出登录ToolStripMenuItem.Size = new System.Drawing.Size(53, 26);
            this.退出登录ToolStripMenuItem.Text = "退出";
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.退出ToolStripMenuItem.Text = "切换用户";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.切换用户ToolStripMenuItem_Click);
            // 
            // 退出系统ToolStripMenuItem
            // 
            this.退出系统ToolStripMenuItem.Name = "退出系统ToolStripMenuItem";
            this.退出系统ToolStripMenuItem.Size = new System.Drawing.Size(152, 26);
            this.退出系统ToolStripMenuItem.Text = "退出系统";
            this.退出系统ToolStripMenuItem.Click += new System.EventHandler(this.退出系统ToolStripMenuItem_Click);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(912, 525);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.menuStrip1);
            this.IsMdiContainer = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "学生档案管理系统";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.FrmMain_FormClosed);
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel1;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 读者管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增读者ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 读者列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出版社管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增出版社ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 出版社列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图书管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 新增图书ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图书列表ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借还管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借阅ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 还书ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询统计ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借还记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 逾期记录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出登录ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出系统ToolStripMenuItem;
        private System.Windows.Forms.ToolStripStatusLabel toolStripStatusLabel2;
    }
}