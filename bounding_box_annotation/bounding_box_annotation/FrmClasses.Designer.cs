namespace bounding_box_annotation
{
    partial class FrmClasses
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
            this.btnClose = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnSelectAndClose = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.lbRecent = new System.Windows.Forms.ListBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.lbLabels = new System.Windows.Forms.ListBox();
            this.groupBox1.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnClose
            // 
            this.btnClose.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.btnClose.Location = new System.Drawing.Point(12, 22);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(68, 23);
            this.btnClose.TabIndex = 1;
            this.btnClose.Text = "dummyButton";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Visible = false;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnSelectAndClose);
            this.groupBox1.Controls.Add(this.btnClose);
            this.groupBox1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.groupBox1.Location = new System.Drawing.Point(0, 506);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(402, 57);
            this.groupBox1.TabIndex = 8;
            this.groupBox1.TabStop = false;
            // 
            // btnSelectAndClose
            // 
            this.btnSelectAndClose.Location = new System.Drawing.Point(129, 17);
            this.btnSelectAndClose.Name = "btnSelectAndClose";
            this.btnSelectAndClose.Size = new System.Drawing.Size(144, 23);
            this.btnSelectAndClose.TabIndex = 2;
            this.btnSelectAndClose.Text = "Select and &Close";
            this.btnSelectAndClose.UseVisualStyleBackColor = true;
            this.btnSelectAndClose.Click += new System.EventHandler(this.btnSelectAndClose_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.lbRecent);
            this.groupBox3.Dock = System.Windows.Forms.DockStyle.Right;
            this.groupBox3.Location = new System.Drawing.Point(202, 0);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(200, 506);
            this.groupBox3.TabIndex = 9;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Recent labels";
            // 
            // lbRecent
            // 
            this.lbRecent.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbRecent.FormattingEnabled = true;
            this.lbRecent.Location = new System.Drawing.Point(3, 16);
            this.lbRecent.Name = "lbRecent";
            this.lbRecent.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbRecent.Size = new System.Drawing.Size(194, 487);
            this.lbRecent.TabIndex = 0;
            this.lbRecent.SelectedIndexChanged += new System.EventHandler(this.lbLabels_SelectedIndexChanges);
            this.lbRecent.DoubleClick += new System.EventHandler(this.lbLabels_DoubleClick);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.lbLabels);
            this.groupBox2.Dock = System.Windows.Forms.DockStyle.Left;
            this.groupBox2.Location = new System.Drawing.Point(0, 0);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(200, 506);
            this.groupBox2.TabIndex = 10;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Labels";
            // 
            // lbLabels
            // 
            this.lbLabels.Dock = System.Windows.Forms.DockStyle.Fill;
            this.lbLabels.FormattingEnabled = true;
            this.lbLabels.Location = new System.Drawing.Point(3, 16);
            this.lbLabels.Name = "lbLabels";
            this.lbLabels.SelectionMode = System.Windows.Forms.SelectionMode.MultiExtended;
            this.lbLabels.Size = new System.Drawing.Size(194, 487);
            this.lbLabels.TabIndex = 0;
            this.lbLabels.SelectedIndexChanged += new System.EventHandler(this.lbLabels_SelectedIndexChanges);
            this.lbLabels.DoubleClick += new System.EventHandler(this.lbLabels_DoubleClick);
            // 
            // FrmClasses
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.btnClose;
            this.ClientSize = new System.Drawing.Size(402, 563);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FrmClasses";
            this.StartPosition = System.Windows.Forms.FormStartPosition.Manual;
            this.Text = "Select label";
            this.Load += new System.EventHandler(this.FrmClasses_Load);
            this.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.FrmClasses_KeyPress);
            this.groupBox1.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.ListBox lbRecent;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lbLabels;
        private System.Windows.Forms.Button btnSelectAndClose;

    }
}