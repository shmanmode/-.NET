using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OnClick
{
    public partial class FrmTextBoxes : Form
    {
        public FrmTextBoxes()
        {
            InitializeComponent();
        }

        private void btnShowFullName_Click(object sender, EventArgs e)
        {
            txtFullName.Text = txtFirstName.Text + " " + txtLastName.Text;
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            textBox1.Text = textBox3.Text + " " + textBox2.Text;
        }

        private void txtNum1_TextChanged(object sender, EventArgs e)
        {
            txtResult.Text = (Convert.ToInt32(txtNum1.Text) + Convert.ToInt32(txtNum2.Text)).ToString();
        }

        private void txtNum1_KeyPress(object sender, KeyPressEventArgs e)
        {
            //e.Handled = !char.IsNumber(e.KeyChar);
            e.Handled = !char.IsNumber(e.KeyChar);
        }

        private void FrmTextBoxes_Load(object sender, EventArgs e)
        {

        }

        private void radioAdd_CheckedChanged(object sender, EventArgs e)
        {
            textResult1122.Text = (Convert.ToInt32(textNum11.Text) + Convert.ToInt32(textNum22.Text)).ToString();
        }


        private void radioMul_CheckedChanged(object sender, EventArgs e)
        {
            textResult1122.Text = (Convert.ToInt32(textNum11.Text) * Convert.ToInt32(textNum22.Text)).ToString();

        }

        private void radioSub_CheckedChanged(object sender, EventArgs e)
        {
            textResult1122.Text = (Convert.ToInt32(textNum11.Text) - Convert.ToInt32(textNum22.Text)).ToString();

        }

        private void radioDiv_CheckedChanged(object sender, EventArgs e)
        {
            textResult1122.Text = (Convert.ToDouble(textNum11.Text) / Convert.ToDouble(textNum22.Text)).ToString();

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void radioRed_CheckedChanged(object sender, EventArgs e)
        {
            lbShubham.ForeColor = Color.FromName(((RadioButton)sender).Text);
        }

        private void radioButton4_CheckedChanged(object sender, EventArgs e)
        {
            lbShubham.BackColor = Color.FromName(((RadioButton)sender).Text);

        }

        private void btnChangeImage_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
        }

        private void openFileDialog1_FileOk(object sender, CancelEventArgs e)
        {
            pictureBox1.Image = Image.FromFile(openFileDialog1.FileName);
        }

        
    }
}
