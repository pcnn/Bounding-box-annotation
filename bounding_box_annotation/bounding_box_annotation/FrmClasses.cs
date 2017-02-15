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
        string selectedLabe = "";
        public string SelectedLabel
        {
            get {
                if (lbLabels.SelectedIndex >= 0)
                {
                    return lbLabels.SelectedItem.ToString();
                }
                else if(lbRecent.SelectedIndex >= 0)
                {
                    return lbRecent.SelectedItem.ToString();
                }
                else
                    return "";
            }
            set {
                selectedLabe = value.Trim(); ;
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
            if (selectedLabe.Length > 0)
            {
                for (int i = 0; i < lbLabels.Items.Count; i++)
                {
                    if (lbLabels.Items[i].ToString().Trim() == selectedLabe.Trim())
                    {
                        lbLabels.SelectedIndex = i;
                        break;
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
    }
}
