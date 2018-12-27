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
    public partial class frmRadioButtons : Form
    {
        public frmRadioButtons()
        {
            InitializeComponent();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            lblSample.ForeColor = Color.Red;
        }

        private void radioButton6_CheckedChanged(object sender, EventArgs e)
        {
            //MessageBox.Show(((RadioButton)sender).Text);
            //lblSample.BackColor = Color.Black;
            lblSample.BackColor = Color.FromName(((RadioButton)sender).Text);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            lblSample.Font = new Font(txtFont.Text, 20);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            lblSample.Location = new Point(Convert.ToInt32(  txtX.Text), Convert.ToInt32(txtY.Text));
        }

        private void button3_Click(object sender, EventArgs e)
        {
            lblSample.TextAlign = ContentAlignment.BottomLeft;
        }
    }
}


/*
 class -> either create an object of that class or look for some static method from that class
 struct -> either create an object of that struct or look for some static method from that struct
 enum -> enumName.
 interface -> pass it an object of some class that implements that interface
 delegate -> pass it some func that matches the signature of the delegate
    
    */
