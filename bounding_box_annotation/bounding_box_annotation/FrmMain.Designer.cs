namespace bounding_box_annotation
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuOpenDir = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuNext = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPrev = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuDelete = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuExit = new System.Windows.Forms.ToolStripMenuItem();
            this.optionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPenColor = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuPen2 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPen3 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuPen4 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem6 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTran127 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTran200 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuTran255 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuConfirm = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuManageClass = new System.Windows.Forms.ToolStripMenuItem();
            this.toolsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuMoveImageCenter = new System.Windows.Forms.ToolStripMenuItem();
            this.lbFiles = new System.Windows.Forms.ListBox();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.statusStrip1 = new System.Windows.Forms.StatusStrip();
            this.stLblImage = new System.Windows.Forms.ToolStripStatusLabel();
            this.stsLblCropsize = new System.Windows.Forms.ToolStripStatusLabel();
            this.btnStatusZoom = new System.Windows.Forms.ToolStripDropDownButton();
            this.mnuZoom300 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuZoom200 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuzoom100 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuZoom50 = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuZoom25 = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuZoomDropdown = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuZoomBestFit = new System.Windows.Forms.ToolStripMenuItem();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.mnuAbout = new System.Windows.Forms.ToolStripMenuItem();
            this.mnuSave = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator5 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripSeparator6 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripMenuItem5 = new System.Windows.Forms.ToolStripSeparator();
            this.mnuShowMouseGuid = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripSeparator7 = new System.Windows.Forms.ToolStripSeparator();
            this.pbMain = new bounding_box_annotation.boundaingbox();
            this.menuStrip1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            this.statusStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.optionsToolStripMenuItem,
            this.toolsToolStripMenuItem,
            this.mnuAbout});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(798, 24);
            this.menuStrip1.TabIndex = 1;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuOpenDir,
            this.toolStripMenuItem1,
            this.mnuNext,
            this.mnuPrev,
            this.toolStripMenuItem2,
            this.mnuDelete,
            this.toolStripSeparator1,
            this.mnuSave,
            this.toolStripSeparator5,
            this.mnuExit});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // mnuOpenDir
            // 
            this.mnuOpenDir.Name = "mnuOpenDir";
            this.mnuOpenDir.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.O)));
            this.mnuOpenDir.Size = new System.Drawing.Size(164, 22);
            this.mnuOpenDir.Text = "Open Dir";
            this.mnuOpenDir.Click += new System.EventHandler(this.mnuOpenDir_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(161, 6);
            // 
            // mnuNext
            // 
            this.mnuNext.Name = "mnuNext";
            this.mnuNext.ShortcutKeyDisplayString = "D or 6";
            this.mnuNext.Size = new System.Drawing.Size(164, 22);
            this.mnuNext.Text = "Next";
            this.mnuNext.Click += new System.EventHandler(this.mnuNext_Click);
            // 
            // mnuPrev
            // 
            this.mnuPrev.Name = "mnuPrev";
            this.mnuPrev.ShortcutKeyDisplayString = "A or 4";
            this.mnuPrev.Size = new System.Drawing.Size(164, 22);
            this.mnuPrev.Text = "Previous";
            this.mnuPrev.Click += new System.EventHandler(this.mnuPrev_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(161, 6);
            // 
            // mnuDelete
            // 
            this.mnuDelete.Name = "mnuDelete";
            this.mnuDelete.ShortcutKeys = System.Windows.Forms.Keys.Delete;
            this.mnuDelete.Size = new System.Drawing.Size(164, 22);
            this.mnuDelete.Text = "Delete";
            this.mnuDelete.Click += new System.EventHandler(this.mnuDelete_Click);
            // 
            // mnuExit
            // 
            this.mnuExit.Name = "mnuExit";
            this.mnuExit.ShortcutKeys = ((System.Windows.Forms.Keys)((System.Windows.Forms.Keys.Control | System.Windows.Forms.Keys.Q)));
            this.mnuExit.Size = new System.Drawing.Size(164, 22);
            this.mnuExit.Text = "Exit";
            this.mnuExit.Click += new System.EventHandler(this.mnuExit_Click);
            // 
            // optionsToolStripMenuItem
            // 
            this.optionsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuPenColor,
            this.toolStripMenuItem4,
            this.mnuPen2,
            this.mnuPen3,
            this.mnuPen4,
            this.toolStripMenuItem5,
            this.toolStripMenuItem6,
            this.toolStripSeparator7,
            this.mnuShowMouseGuid,
            this.toolStripSeparator2,
            this.mnuConfirm,
            this.toolStripSeparator6,
            this.mnuManageClass});
            this.optionsToolStripMenuItem.Name = "optionsToolStripMenuItem";
            this.optionsToolStripMenuItem.Size = new System.Drawing.Size(61, 20);
            this.optionsToolStripMenuItem.Text = "Options";
            // 
            // mnuPenColor
            // 
            this.mnuPenColor.Name = "mnuPenColor";
            this.mnuPenColor.Size = new System.Drawing.Size(192, 22);
            this.mnuPenColor.Text = "Pen color";
            this.mnuPenColor.Click += new System.EventHandler(this.mnuPenColor_Click);
            // 
            // toolStripMenuItem4
            // 
            this.toolStripMenuItem4.Name = "toolStripMenuItem4";
            this.toolStripMenuItem4.Size = new System.Drawing.Size(189, 6);
            // 
            // mnuPen2
            // 
            this.mnuPen2.Checked = true;
            this.mnuPen2.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuPen2.Name = "mnuPen2";
            this.mnuPen2.Size = new System.Drawing.Size(192, 22);
            this.mnuPen2.Text = "Pen width 2";
            this.mnuPen2.Click += new System.EventHandler(this.mnuPen2_Click);
            // 
            // mnuPen3
            // 
            this.mnuPen3.Name = "mnuPen3";
            this.mnuPen3.Size = new System.Drawing.Size(192, 22);
            this.mnuPen3.Text = "Pen width 3";
            this.mnuPen3.Click += new System.EventHandler(this.mnuPen3_Click);
            // 
            // mnuPen4
            // 
            this.mnuPen4.Name = "mnuPen4";
            this.mnuPen4.Size = new System.Drawing.Size(192, 22);
            this.mnuPen4.Text = "Pen width 4";
            this.mnuPen4.Click += new System.EventHandler(this.mnuPen4_Click);
            // 
            // toolStripMenuItem6
            // 
            this.toolStripMenuItem6.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuTran127,
            this.mnuTran200,
            this.mnuTran255});
            this.toolStripMenuItem6.Name = "toolStripMenuItem6";
            this.toolStripMenuItem6.Size = new System.Drawing.Size(192, 22);
            this.toolStripMenuItem6.Text = "Pen transparency";
            // 
            // mnuTran127
            // 
            this.mnuTran127.Name = "mnuTran127";
            this.mnuTran127.Size = new System.Drawing.Size(92, 22);
            this.mnuTran127.Tag = "127";
            this.mnuTran127.Text = "127";
            this.mnuTran127.Click += new System.EventHandler(this.mnuTrans_Click);
            // 
            // mnuTran200
            // 
            this.mnuTran200.Name = "mnuTran200";
            this.mnuTran200.Size = new System.Drawing.Size(92, 22);
            this.mnuTran200.Tag = "200";
            this.mnuTran200.Text = "200";
            this.mnuTran200.Click += new System.EventHandler(this.mnuTrans_Click);
            // 
            // mnuTran255
            // 
            this.mnuTran255.Name = "mnuTran255";
            this.mnuTran255.Size = new System.Drawing.Size(92, 22);
            this.mnuTran255.Tag = "255";
            this.mnuTran255.Text = "255";
            this.mnuTran255.Click += new System.EventHandler(this.mnuTrans_Click);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(189, 6);
            // 
            // mnuConfirm
            // 
            this.mnuConfirm.Checked = true;
            this.mnuConfirm.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuConfirm.Name = "mnuConfirm";
            this.mnuConfirm.Size = new System.Drawing.Size(192, 22);
            this.mnuConfirm.Text = "Confirm before saving";
            this.mnuConfirm.Click += new System.EventHandler(this.mnuConfirm_Click);
            // 
            // mnuManageClass
            // 
            this.mnuManageClass.Name = "mnuManageClass";
            this.mnuManageClass.Size = new System.Drawing.Size(192, 22);
            this.mnuManageClass.Text = "Manage class labels";
            this.mnuManageClass.Click += new System.EventHandler(this.mnuManageClass_Click);
            // 
            // toolsToolStripMenuItem
            // 
            this.toolsToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuMoveImageCenter});
            this.toolsToolStripMenuItem.Name = "toolsToolStripMenuItem";
            this.toolsToolStripMenuItem.Size = new System.Drawing.Size(52, 20);
            this.toolsToolStripMenuItem.Text = "Image";
            // 
            // mnuMoveImageCenter
            // 
            this.mnuMoveImageCenter.Name = "mnuMoveImageCenter";
            this.mnuMoveImageCenter.Size = new System.Drawing.Size(152, 22);
            this.mnuMoveImageCenter.Text = "Move Center";
            this.mnuMoveImageCenter.Click += new System.EventHandler(this.mnuMoveImageCenter_Click);
            // 
            // lbFiles
            // 
            this.lbFiles.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbFiles.FormattingEnabled = true;
            this.lbFiles.Location = new System.Drawing.Point(0, 0);
            this.lbFiles.Name = "lbFiles";
            this.lbFiles.Size = new System.Drawing.Size(214, 492);
            this.lbFiles.TabIndex = 2;
            this.lbFiles.SelectedIndexChanged += new System.EventHandler(this.lbFiles_DoubleClick);
            this.lbFiles.DoubleClick += new System.EventHandler(this.lbFiles_DoubleClick);
            // 
            // splitContainer1
            // 
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.Location = new System.Drawing.Point(0, 24);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pbMain);
            this.splitContainer1.Panel1.Controls.Add(this.statusStrip1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.lbFiles);
            this.splitContainer1.Size = new System.Drawing.Size(798, 492);
            this.splitContainer1.SplitterDistance = 580;
            this.splitContainer1.TabIndex = 3;
            // 
            // statusStrip1
            // 
            this.statusStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.stLblImage,
            this.stsLblCropsize,
            this.btnStatusZoom});
            this.statusStrip1.Location = new System.Drawing.Point(0, 470);
            this.statusStrip1.Name = "statusStrip1";
            this.statusStrip1.Size = new System.Drawing.Size(580, 22);
            this.statusStrip1.TabIndex = 1;
            this.statusStrip1.Text = "statusStrip1";
            // 
            // stLblImage
            // 
            this.stLblImage.Name = "stLblImage";
            this.stLblImage.Size = new System.Drawing.Size(10, 17);
            this.stLblImage.Text = " ";
            // 
            // stsLblCropsize
            // 
            this.stsLblCropsize.Name = "stsLblCropsize";
            this.stsLblCropsize.Size = new System.Drawing.Size(10, 17);
            this.stsLblCropsize.Text = " ";
            // 
            // btnStatusZoom
            // 
            this.btnStatusZoom.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Text;
            this.btnStatusZoom.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.mnuZoom300,
            this.mnuZoom200,
            this.mnuzoom100,
            this.mnuZoom50,
            this.mnuZoom25,
            this.toolStripSeparator3,
            this.mnuZoomDropdown,
            this.toolStripSeparator4,
            this.mnuZoomBestFit});
            this.btnStatusZoom.Image = ((System.Drawing.Image)(resources.GetObject("btnStatusZoom.Image")));
            this.btnStatusZoom.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.btnStatusZoom.Name = "btnStatusZoom";
            this.btnStatusZoom.Size = new System.Drawing.Size(52, 20);
            this.btnStatusZoom.Text = "Zoom";
            // 
            // mnuZoom300
            // 
            this.mnuZoom300.Name = "mnuZoom300";
            this.mnuZoom300.Size = new System.Drawing.Size(181, 22);
            this.mnuZoom300.Tag = "300";
            this.mnuZoom300.Text = "300%";
            this.mnuZoom300.Click += new System.EventHandler(this.mnuZoom_Click);
            // 
            // mnuZoom200
            // 
            this.mnuZoom200.Name = "mnuZoom200";
            this.mnuZoom200.Size = new System.Drawing.Size(181, 22);
            this.mnuZoom200.Tag = "200";
            this.mnuZoom200.Text = "200%";
            this.mnuZoom200.Click += new System.EventHandler(this.mnuZoom_Click);
            // 
            // mnuzoom100
            // 
            this.mnuzoom100.Name = "mnuzoom100";
            this.mnuzoom100.Size = new System.Drawing.Size(181, 22);
            this.mnuzoom100.Tag = "100";
            this.mnuzoom100.Text = "100%";
            this.mnuzoom100.Click += new System.EventHandler(this.mnuZoom_Click);
            // 
            // mnuZoom50
            // 
            this.mnuZoom50.Name = "mnuZoom50";
            this.mnuZoom50.Size = new System.Drawing.Size(181, 22);
            this.mnuZoom50.Tag = "50";
            this.mnuZoom50.Text = "50%";
            this.mnuZoom50.Click += new System.EventHandler(this.mnuZoom_Click);
            // 
            // mnuZoom25
            // 
            this.mnuZoom25.Name = "mnuZoom25";
            this.mnuZoom25.Size = new System.Drawing.Size(181, 22);
            this.mnuZoom25.Tag = "25";
            this.mnuZoom25.Text = "25%";
            this.mnuZoom25.Click += new System.EventHandler(this.mnuZoom_Click);
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuZoomDropdown
            // 
            this.mnuZoomDropdown.Name = "mnuZoomDropdown";
            this.mnuZoomDropdown.Size = new System.Drawing.Size(121, 23);
            this.mnuZoomDropdown.TextChanged += new System.EventHandler(this.mnuZoomDropdown_TextChanged);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(178, 6);
            // 
            // mnuZoomBestFit
            // 
            this.mnuZoomBestFit.Name = "mnuZoomBestFit";
            this.mnuZoomBestFit.Size = new System.Drawing.Size(181, 22);
            this.mnuZoomBestFit.Text = "Best Fit";
            this.mnuZoomBestFit.Click += new System.EventHandler(this.mnuZoomBestFit_Click);
            // 
            // mnuAbout
            // 
            this.mnuAbout.Name = "mnuAbout";
            this.mnuAbout.Size = new System.Drawing.Size(52, 20);
            this.mnuAbout.Text = "About";
            this.mnuAbout.Click += new System.EventHandler(this.mnuAbout_Click);
            // 
            // mnuSave
            // 
            this.mnuSave.Name = "mnuSave";
            this.mnuSave.Size = new System.Drawing.Size(164, 22);
            this.mnuSave.Text = "Save";
            this.mnuSave.Click += new System.EventHandler(this.mnuSave_Click);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(161, 6);
            // 
            // toolStripSeparator5
            // 
            this.toolStripSeparator5.Name = "toolStripSeparator5";
            this.toolStripSeparator5.Size = new System.Drawing.Size(161, 6);
            // 
            // toolStripSeparator6
            // 
            this.toolStripSeparator6.Name = "toolStripSeparator6";
            this.toolStripSeparator6.Size = new System.Drawing.Size(189, 6);
            // 
            // toolStripMenuItem5
            // 
            this.toolStripMenuItem5.Name = "toolStripMenuItem5";
            this.toolStripMenuItem5.Size = new System.Drawing.Size(189, 6);
            // 
            // mnuShowMouseGuid
            // 
            this.mnuShowMouseGuid.Checked = true;
            this.mnuShowMouseGuid.CheckState = System.Windows.Forms.CheckState.Checked;
            this.mnuShowMouseGuid.Name = "mnuShowMouseGuid";
            this.mnuShowMouseGuid.Size = new System.Drawing.Size(192, 22);
            this.mnuShowMouseGuid.Text = "Show mouse guid";
            this.mnuShowMouseGuid.Click += new System.EventHandler(this.mnuShowMouseGuid_Click);
            // 
            // toolStripSeparator7
            // 
            this.toolStripSeparator7.Name = "toolStripSeparator7";
            this.toolStripSeparator7.Size = new System.Drawing.Size(189, 6);
            // 
            // pbMain
            // 
            this.pbMain.BackColor = System.Drawing.Color.White;
            this.pbMain.Bitmap = null;
            this.pbMain.BoundingBoxPenColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(0)))), ((int)(((byte)(0)))));
            this.pbMain.BoundingBoxPenWidth = 2F;
            this.pbMain.BoundingBoxTransparency = ((byte)(255));
            this.pbMain.Dock = System.Windows.Forms.DockStyle.Fill;
            this.pbMain.ImageLocation = "";
            this.pbMain.Location = new System.Drawing.Point(0, 0);
            this.pbMain.Name = "pbMain";
            this.pbMain.Scale = 1F;
            this.pbMain.ShowMouseGuid = true;
            this.pbMain.Size = new System.Drawing.Size(580, 470);
            this.pbMain.TabIndex = 2;
            this.pbMain.ScaleChanged += new bounding_box_annotation.boundaingbox.ScaleEventHandler(this.pbMain_ScaleChanged);
            // 
            // FrmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(798, 516);
            this.Controls.Add(this.splitContainer1);
            this.Controls.Add(this.menuStrip1);
            this.DoubleBuffered = true;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.KeyPreview = true;
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "FrmMain";
            this.Text = "Croppnig tool";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.FrmMain_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmMain_KeyPress);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            this.statusStrip1.ResumeLayout(false);
            this.statusStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuOpenDir;
        private System.Windows.Forms.ListBox lbFiles;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem mnuNext;
        private System.Windows.Forms.ToolStripMenuItem mnuPrev;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.ToolStripMenuItem optionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuPenColor;
        private System.Windows.Forms.ColorDialog colorDialog1;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem4;
        private System.Windows.Forms.ToolStripMenuItem mnuPen2;
        private System.Windows.Forms.ToolStripMenuItem mnuPen3;
        private System.Windows.Forms.ToolStripMenuItem mnuPen4;
        private System.Windows.Forms.ToolStripMenuItem mnuExit;
        private System.Windows.Forms.ToolStripMenuItem mnuConfirm;
        private System.Windows.Forms.ToolStripMenuItem toolStripMenuItem6;
        private System.Windows.Forms.ToolStripMenuItem mnuTran127;
        private System.Windows.Forms.ToolStripMenuItem mnuTran200;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripMenuItem mnuTran255;
        private System.Windows.Forms.ToolStripMenuItem mnuDelete;
        private System.Windows.Forms.ToolStripMenuItem toolsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem mnuMoveImageCenter;
        private boundaingbox pbMain;
        private System.Windows.Forms.StatusStrip statusStrip1;
        private System.Windows.Forms.ToolStripStatusLabel stLblImage;
        private System.Windows.Forms.ToolStripStatusLabel stsLblCropsize;
        private System.Windows.Forms.ToolStripDropDownButton btnStatusZoom;
        private System.Windows.Forms.ToolStripMenuItem mnuZoom300;
        private System.Windows.Forms.ToolStripMenuItem mnuZoom200;
        private System.Windows.Forms.ToolStripMenuItem mnuzoom100;
        private System.Windows.Forms.ToolStripMenuItem mnuZoom50;
        private System.Windows.Forms.ToolStripMenuItem mnuZoom25;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripComboBox mnuZoomDropdown;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripMenuItem mnuZoomBestFit;
        private System.Windows.Forms.ToolStripMenuItem mnuManageClass;
        private System.Windows.Forms.ToolStripMenuItem mnuAbout;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripMenuItem mnuSave;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator6;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem5;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator7;
        private System.Windows.Forms.ToolStripMenuItem mnuShowMouseGuid;
    }
}

