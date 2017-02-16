using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace bounding_box_annotation
{
    public partial class FrmClasses : Form
    {
        string[] selectedLabels = null;
        public string[] SelectedLabels
        {
            get {
                if (lbLabels.SelectedIndex >= 0)
                {
                    
                    return (from object obj in lbLabels.SelectedItems
                           select obj.ToString()).ToArray<string>();
                    //return lbLabels.SelectedItem.ToString();                    
                }
                else if(lbRecent.SelectedIndex >= 0)
                {
                    return (from object obj in lbRecent.SelectedItems
                            select obj.ToString()).ToArray<string>();
                    //return lbRecent.SelectedItem.ToString();
                }
                else
                    return null;
            }
            set {
                selectedLabels = value ;
            }
        }

        public void SetRecentLabel(List<string> labels)
        {
            lbRecent.Items.Clear();
            lbRecent.Items.AddRange(labels.ToArray());
        }

        public FrmClasses()
        {
            InitializeComponent();
        }

        private void FrmClasses_Load(object sender, EventArgs e)
        {
            ClassLabelManager lblManager = new ClassLabelManager();
            lbLabels.Items.Clear();
            lbLabels.Items.AddRange(lblManager.ReadLabels().ToArray());
            if (selectedLabels != null && selectedLabels.Length > 0)
            {
                foreach (var lbl in selectedLabels)
                {
                    for (int i = 0; i < lbLabels.Items.Count; i++)
                    {
                        if (lbLabels.Items[i].ToString().Trim() == lbl.Trim())
                        {
                            lbLabels.SetSelected(i, true);
                            break;
                        }
                    }
                }
                
            }
            
        }
        
        private void lbLabels_DoubleClick(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
            
        }

        private void lbLabels_SelectedIndexChanges(object sender, EventArgs e)
        {
            if (sender == lbLabels)
            {
                if(lbLabels.SelectedIndex >= 0)
                    lbRecent.ClearSelected();
            }
            else if (sender == lbRecent)
            {
                if (lbRecent.SelectedIndex >= 0)
                    lbLabels.ClearSelected();
            }
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.No;
        }

        private void btnSelectAndClose_Click(object sender, EventArgs e)
        {
            this.DialogResult = System.Windows.Forms.DialogResult.Yes;
        }

        private void FrmClasses_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                btnSelectAndClose.PerformClick();
            }
        }
    }
}
