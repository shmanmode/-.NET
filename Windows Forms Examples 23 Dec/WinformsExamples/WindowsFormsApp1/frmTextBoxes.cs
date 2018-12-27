using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class frmTextBoxes : Form
    {
        public frmTextBoxes()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void btnShowFullName_Click(object sender, EventArgs e)
        {
            txtFullName.Text = txtFirstName.Text + " " + txtLastName.Text;
        }

        private void txtFirstName_TextChanged(object sender, EventArgs e)
        {
            txtFullName.Text = txtFirstName.Text + " " + txtLastName.Text;
        }

       
    }
}
