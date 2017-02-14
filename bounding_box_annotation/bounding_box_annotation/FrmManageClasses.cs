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
    public partial class FrmManageClasses : Form
    {
        ClassLabelManager lblManager = new ClassLabelManager();

        public FrmManageClasses()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            if (txtLabel.Text.Trim().Length == 0)
            {
                return;
            }
            for (int i = 0; i < lbClassLabels.Items.Count; i++)            
            {
                if (txtLabel.Text.Trim() == lbClassLabels.Items[i].ToString().Trim())
                {
                    MessageBox.Show("The labels already exists in the list. The items will be selected after closing this dialog.");
                    lbClassLabels.SelectedIndex = i;
                    return;
                }
            }
            lbClassLabels.Items.Add(txtLabel.Text);
            lbClassLabels.SelectedIndex = lbClassLabels.Items.Count - 1;
            txtLabel.Clear();
        }

        private void FrmManageClasses_Load(object sender, EventArgs e)
        {
            lbClassLabels.Items.AddRange(lblManager.ReadLabels().ToArray());            
        }

        private void mnuDelete_Click(object sender, EventArgs e)
        {
            if (lbClassLabels.SelectedIndex >= 0)
            {
                lbClassLabels.Items.RemoveAt(lbClassLabels.SelectedIndex);
            }
        }

        private void txtLabel_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Return)
            {
                btnAdd.PerformClick();
            }
        }

        private void btnDeleteSelected_Click(object sender, EventArgs e)
        {
            mnuDelete.PerformClick();
        }

        private void btnClose_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {            
            var a = lbClassLabels.Items.Cast<String>();
            lblManager.SaveLabels(a.ToArray());
            MessageBox.Show("Class labels were saved!");

        }

        private void btnSort_Click(object sender, EventArgs e)
        {

            var a = from object s in lbClassLabels.Items
                    orderby s.ToString()
                    select s.ToString();
            
            string[] sorted = a.ToArray();
            lbClassLabels.Items.Clear();
            lbClassLabels.Items.AddRange(sorted);
            /*string[] items = new string[lbClassLabels.Items.Count];
            for (int i = 0; i < lbClassLabels.Items.Count; i++)
            {
                items[i] = lbClassLabels.Items[i].ToString();
            }
            Array.Sort(items);
            lbClassLabels.Items.Clear();
            foreach (var item in items)
            {
                lbClassLabels.Items.Add(item);
            }*/

        }

        private void mnuDeleteAll_Click(object sender, EventArgs e)
        {
            lbClassLabels.Items.Clear();
        }
    }
}
