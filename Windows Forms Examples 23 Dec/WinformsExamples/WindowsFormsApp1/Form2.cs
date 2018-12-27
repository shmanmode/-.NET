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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            TreeNode rootNode = treeView1.Nodes.Add("Root Node");
            TreeNode parentNode =rootNode.Nodes.Add("Parent1");
            parentNode.Nodes.Add("Child1");
            parentNode.Nodes.Add("Child2");

            parentNode = rootNode.Nodes.Add("Parent2");
            parentNode.Nodes.Add("Child3");
            parentNode.Nodes.Add("Child4");

        }
    }
}
