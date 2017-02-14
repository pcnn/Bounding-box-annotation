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
                else
                {
                    return "";
                }
            }
            set {
                selectedLabe = value.Trim(); ;
            }
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

        private void btnSelect_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void lbLabels_DoubleClick(object sender, EventArgs e)
        {
            btnSelect.PerformClick();
        }
    }
}
