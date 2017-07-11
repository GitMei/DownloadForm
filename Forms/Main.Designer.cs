namespace yoedgeForm.Forms
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.txtComicNo = new System.Windows.Forms.TextBox();
            this.btnGetComicIndex = new System.Windows.Forms.Button();
            this.FilelistView = new System.Windows.Forms.ListView();
            this.InfoMenu = new System.Windows.Forms.ContextMenuStrip(this.components);
            this.下载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.全部下载ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.下载所选ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.IconList = new System.Windows.Forms.ImageList(this.components);
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.tabPage3 = new System.Windows.Forms.TabPage();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.Info_Lab = new System.Windows.Forms.ToolStripStatusLabel();
            this.UpdateDownLoadList_Timer = new System.Windows.Forms.Timer(this.components);
            this.DownloadListView = new yoedgeForm.Util.ListViewRel();
            this.xID = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.xName = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.DownLoadPath = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Speed = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.Schedule = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.State = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.InfoMenu.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Controls.Add(this.tabPage3);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(562, 484);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.txtComicNo);
            this.tabPage1.Controls.Add(this.btnGetComicIndex);
            this.tabPage1.Controls.Add(this.FilelistView);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(554, 458);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "漫画列表";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // txtComicNo
            // 
            this.txtComicNo.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.txtComicNo.Location = new System.Drawing.Point(6, 6);
            this.txtComicNo.Name = "txtComicNo";
            this.txtComicNo.Size = new System.Drawing.Size(461, 21);
            this.txtComicNo.TabIndex = 2;
            // 
            // btnGetComicIndex
            // 
            this.btnGetComicIndex.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.btnGetComicIndex.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.btnGetComicIndex.Location = new System.Drawing.Point(473, 6);
            this.btnGetComicIndex.Name = "btnGetComicIndex";
            this.btnGetComicIndex.Size = new System.Drawing.Size(75, 23);
            this.btnGetComicIndex.TabIndex = 1;
            this.btnGetComicIndex.Text = "获取章节";
            this.btnGetComicIndex.UseVisualStyleBackColor = true;
            this.btnGetComicIndex.Click += new System.EventHandler(this.btnGetComicIndex_Click);
            // 
            // FilelistView
            // 
            this.FilelistView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.FilelistView.ContextMenuStrip = this.InfoMenu;
            this.FilelistView.LargeImageList = this.IconList;
            this.FilelistView.Location = new System.Drawing.Point(5, 35);
            this.FilelistView.Name = "FilelistView";
            this.FilelistView.Size = new System.Drawing.Size(546, 417);
            this.FilelistView.TabIndex = 0;
            this.FilelistView.UseCompatibleStateImageBehavior = false;
            // 
            // InfoMenu
            // 
            this.InfoMenu.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.下载ToolStripMenuItem});
            this.InfoMenu.Name = "InfoMenu";
            this.InfoMenu.Size = new System.Drawing.Size(101, 26);
            this.InfoMenu.Opening += new System.ComponentModel.CancelEventHandler(this.InfoMenu_Opening);
            // 
            // 下载ToolStripMenuItem
            // 
            this.下载ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.全部下载ToolStripMenuItem,
            this.下载所选ToolStripMenuItem});
            this.下载ToolStripMenuItem.Name = "下载ToolStripMenuItem";
            this.下载ToolStripMenuItem.Size = new System.Drawing.Size(100, 22);
            this.下载ToolStripMenuItem.Text = "下载";
            // 
            // 全部下载ToolStripMenuItem
            // 
            this.全部下载ToolStripMenuItem.Name = "全部下载ToolStripMenuItem";
            this.全部下载ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.全部下载ToolStripMenuItem.Text = "全部下载";
            this.全部下载ToolStripMenuItem.Click += new System.EventHandler(this.全部下载ToolStripMenuItem_Click);
            // 
            // 下载所选ToolStripMenuItem
            // 
            this.下载所选ToolStripMenuItem.Name = "下载所选ToolStripMenuItem";
            this.下载所选ToolStripMenuItem.Size = new System.Drawing.Size(124, 22);
            this.下载所选ToolStripMenuItem.Text = "下载所选";
            this.下载所选ToolStripMenuItem.Click += new System.EventHandler(this.下载所选ToolStripMenuItem_Click);
            // 
            // IconList
            // 
            this.IconList.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("IconList.ImageStream")));
            this.IconList.TransparentColor = System.Drawing.Color.Transparent;
            this.IconList.Images.SetKeyName(0, "Dir.png");
            this.IconList.Images.SetKeyName(1, "Dir2.png");
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.DownloadListView);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Size = new System.Drawing.Size(578, 481);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "下载管理";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // tabPage3
            // 
            this.tabPage3.Location = new System.Drawing.Point(4, 22);
            this.tabPage3.Name = "tabPage3";
            this.tabPage3.Size = new System.Drawing.Size(578, 481);
            this.tabPage3.TabIndex = 2;
            this.tabPage3.Text = "数据管理";
            this.tabPage3.UseVisualStyleBackColor = true;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.Info_Lab});
            this.statusStrip1.Location = new System.Drawing.Point(0, 509);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(586, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // Info_Lab
            // 
            this.Info_Lab.Name = "Info_Lab";
            this.Info_Lab.Size = new System.Drawing.Size(44, 17);
            this.Info_Lab.Text = "等待中";
            // 
            // UpdateDownLoadList_Timer
            // 
            this.UpdateDownLoadList_Timer.Enabled = true;
            this.UpdateDownLoadList_Timer.Interval = 1000;
            this.UpdateDownLoadList_Timer.Tick += new System.EventHandler(this.UpdateDownLoadList_Timer_Tick);
            // 
            // DownloadListView
            // 
            this.DownloadListView.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.xID,
            this.xName,
            this.DownLoadPath,
            this.Speed,
            this.Schedule,
            this.State});
            this.DownloadListView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DownloadListView.FullRowSelect = true;
            this.DownloadListView.GridLines = true;
            this.DownloadListView.Location = new System.Drawing.Point(0, 0);
            this.DownloadListView.Name = "DownloadListView";
            this.DownloadListView.Size = new System.Drawing.Size(578, 481);
            this.DownloadListView.TabIndex = 0;
            this.DownloadListView.UseCompatibleStateImageBehavior = false;
            this.DownloadListView.View = System.Windows.Forms.View.Details;
            // 
            // xID
            // 
            this.xID.Text = "Id";
            this.xID.Width = 40;
            // 
            // xName
            // 
            this.xName.Text = "文件名";
            this.xName.Width = 90;
            // 
            // DownLoadPath
            // 
            this.DownLoadPath.Text = "文件路径";
            this.DownLoadPath.Width = 120;
            // 
            // Speed
            // 
            this.Speed.Text = "传输速度";
            this.Speed.Width = 90;
            // 
            // Schedule
            // 
            this.Schedule.Text = "输出进度";
            // 
            // State
            // 
            this.State.Text = "状态";
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(586, 531);
            this.Controls.Add(this.statusStrip1);
            this.Controls.Add(this.tabControl1);
            this.MinimumSize = new System.Drawing.Size(380, 38);
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "yoedge个人工具";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Main_FormClosed);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.InfoMenu.ResumeLayout(false);
            this.tabPage2.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.ListView FilelistView;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.TabPage tabPage3;
        private System.Windows.Forms.Button btnGetComicIndex;
        private System.Windows.Forms.TextBox txtComicNo;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel Info_Lab;
        private System.Windows.Forms.ImageList IconList;
        private System.Windows.Forms.ContextMenuStrip InfoMenu;
        private System.Windows.Forms.ToolStripMenuItem 下载ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 全部下载ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 下载所选ToolStripMenuItem;
        private Util.ListViewRel DownloadListView;
        private System.Windows.Forms.ColumnHeader xID;
        private System.Windows.Forms.ColumnHeader xName;
        private System.Windows.Forms.ColumnHeader DownLoadPath;
        private System.Windows.Forms.ColumnHeader Speed;
        private System.Windows.Forms.ColumnHeader Schedule;
        private System.Windows.Forms.ColumnHeader State;
        private System.Windows.Forms.Timer UpdateDownLoadList_Timer;
    }
}