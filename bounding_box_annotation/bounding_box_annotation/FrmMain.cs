using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace bounding_box_annotation
{
    public partial class FrmMain : Form
    {
        bool has_changed = false;
        
        public FrmMain()
        {
            InitializeComponent();
        }

        private void mnuOpenDir_Click(object sender, EventArgs e)
        {
            if (folderBrowserDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                string[] files = Directory.GetFiles(folderBrowserDialog1.SelectedPath);
                lbFiles.Items.Clear();
                lbFiles.Tag = folderBrowserDialog1.SelectedPath;
                this.Text = "Cropping tool-" + folderBrowserDialog1.SelectedPath;
                foreach (string str in files)
                {
                    string ext = Path.GetExtension(str).ToLower();
                    if (ext.IndexOf("jpg") < 0 && ext.IndexOf("png") < 0)
                    {
                        continue;
                    }
                    lbFiles.Items.Add(Path.GetFileName(str));    
                    
                }
                if (lbFiles.Items.Count > 0)
                {
                    lbFiles.SelectedIndex = 0;
                    lbFiles_DoubleClick(sender, e);
                }

            }
        }

        private void lbFiles_DoubleClick(object sender, EventArgs e)
        {
            if (lbFiles.SelectedIndex < 0)
            {
                return;
            }
            pbMain.Clear();
            pbMain.ImageLocation = lbFiles.Tag.ToString() + "\\"+ lbFiles.SelectedItem.ToString();
            stLblImage.Text = string.Format("Size of image (WxH): {0}x{1}", pbMain.Bitmap.Width, pbMain.Bitmap.Height);
            if (File.Exists(Path.GetDirectoryName(pbMain.ImageLocation) + "\\" + Path.GetFileNameWithoutExtension(pbMain.ImageLocation) + ".txt"))
            {
                System.IO.StreamReader sr = new StreamReader(Path.GetDirectoryName(pbMain.ImageLocation) + "\\" + Path.GetFileNameWithoutExtension(pbMain.ImageLocation) + ".txt");
                string str = sr.ReadToEnd();
                sr.Close();
                if (str.IndexOf("chal=0") >= 0)
                {
                    
                }
                else if (str.IndexOf("chal=1") >= 0)
                {
                    
                }
                
            }
            else
            {
                
                
            }
        }

       

        private void mnuSave_Click(object sender, EventArgs e)
        {
            /*bool save_flag = true;
            if (pbMain.OriginalImage == null)
            {
                return;
            }
            if (mnuConfirm.Checked)
            {
                save_flag = MessageBox.Show("Are you sure to overwrite the image?", "confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes;
            }
            if (save_flag)
            {                
                string path = pbMain.ImageLocation;
                string temp_path = Application.StartupPath + "\\" + "temp" + Path.GetExtension(path);
                pbMain.OriginalImage.Save(temp_path);
                System.IO.File.Copy(temp_path,path,true);
                has_changed = false;
            }*/
        }

        private void mnuApplyCrop_Click(object sender, EventArgs e)
        {
           /* if (pbMain.OriginalImage == null)
            {
                return;
            }
            AForge.Imaging.Filters.Crop crp = new AForge.Imaging.Filters.Crop(pbMain.CropRectangle);
            pbMain.OriginalImage = crp.Apply((Bitmap)pbMain.OriginalImage);
            has_changed = true;*/
        }

        private void mnuNext_Click(object sender, EventArgs e)
        {
            if (lbFiles.SelectedIndex < lbFiles.Items.Count-1)
            {
                lbFiles.SelectedIndex += 1;
                lbFiles_DoubleClick(sender, e);
            }
        }

        private void mnuPrev_Click(object sender, EventArgs e)
        {
            if (lbFiles.SelectedIndex > 0)
            {
                lbFiles.SelectedIndex -= 1;
                lbFiles_DoubleClick(sender, e);
            }
        }

        private void pbMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Right)
            {
                mnuNext.PerformClick();
            }
        }

        private void FrmMain_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.D6 || e.KeyChar == 'd' || e.KeyChar == 'D')
            {
                mnuNext.PerformClick();
            }
            else if (e.KeyChar == (char)Keys.D4 || e.KeyChar == 'a' || e.KeyChar == 'A')
            {
                mnuPrev.PerformClick();
            }
        }

        private void mnuPenColor_Click(object sender, EventArgs e)
        {
            if (colorDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                pbMain.BoundingBoxPenColor = colorDialog1.Color;
            }
        }
        
        private void mnuPen2_Click(object sender, EventArgs e)
        {
            mnuPen2.Checked = true;
            mnuPen3.Checked = mnuPen4.Checked = false;
            pbMain.BoundingBoxPenWidth = 2;
        }

        private void mnuPen3_Click(object sender, EventArgs e)
        {
            mnuPen3.Checked = true;
            mnuPen2.Checked = mnuPen4.Checked = false;
            pbMain.BoundingBoxPenWidth = 3;
        }

        private void mnuPen4_Click(object sender, EventArgs e)
        {
            mnuPen4.Checked = true;
            mnuPen3.Checked = mnuPen2.Checked = false;
            pbMain.BoundingBoxPenWidth = 4;
        }

        private void FrmMain_Load(object sender, EventArgs e)
        {
            mnuPen3.PerformClick();
            mnuTran200.PerformClick();
        }

        private void mnuExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void mnuConfirm_Click(object sender, EventArgs e)
        {
            mnuConfirm.Checked = !mnuConfirm.Checked;
        }

        private void mnuClearCrop_Click(object sender, EventArgs e)
        {
            //pbMain.ClearCrop();
        }

        private void mnuTrans_Click(object sender, EventArgs e)
        {
            mnuTran127.Checked = mnuTran200.Checked = mnuTran255.Checked = false;
            ((ToolStripMenuItem)sender).Checked = true;
            pbMain.BoundingBoxTransparency = Convert.ToByte(((ToolStripMenuItem)sender).Tag);
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            /*if (File.Exists(pbMain.ImageLocation))
            {
                if (MessageBox.Show("Are you sure to delete the image?", "Confirmation", MessageBoxButtons.YesNo, MessageBoxIcon.Question, MessageBoxDefaultButton.Button1) == System.Windows.Forms.DialogResult.Yes)
                {
                    File.Delete(pbMain.ImageLocation);
                    int cur_ind = lbFiles.SelectedIndex;
                    lbFiles.Items.RemoveAt(lbFiles.SelectedIndex);
                    lbFiles.SelectedIndex = cur_ind;
                    //lbFiles_DoubleClick(sender, e);
                    
                }
            }*/
        }

        private void pbMain_CropChanged(object sender, EventArgs e)
        {
            //stsLblCropsize.Text = string.Format("Crop size (WxH): {0}x{1}", pbMain.CropRectangle.Width, pbMain.CropRectangle.Height);
        }

        private void mnuMoveImageCenter_Click(object sender, EventArgs e)
        {
            pbMain.MoveImageToCenter();
        }

        private void mnuZoom_Click(object sender, EventArgs e)
        {
            pbMain.Scale = Convert.ToSingle(((ToolStripMenuItem)sender).Tag)/100;
        }

        private void mnuZoomDropdown_TextChanged(object sender, EventArgs e)
        {
            pbMain.Scale = Convert.ToSingle(mnuZoomDropdown.Text) / 100;
        }

        private void mnuZoomBestFit_Click(object sender, EventArgs e)
        {
            if (pbMain.Bitmap != null)
            {
                if (pbMain.Bitmap.Height > pbMain.Bitmap.Width)
                {
                    pbMain.Scale = (float)pbMain.Height/pbMain.Bitmap.Height;
                }
                else
                {
                    pbMain.Scale = (float)pbMain.Width/ pbMain.Bitmap.Width;
                }
            }
        }

        private void mnuManageClass_Click(object sender, EventArgs e)
        {
            FrmManageClasses frm = new FrmManageClasses();
            frm.ShowDialog();
        }

        private void mnuAbout_Click(object sender, EventArgs e)
        {
            FrmAbout frm = new FrmAbout();
            frm.ShowDialog();
        }
    }   
}
