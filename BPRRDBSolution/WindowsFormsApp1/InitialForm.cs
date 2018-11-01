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
    public partial class InitialForm : Form
    {
        public InitialForm()
        {
            InitializeComponent();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
            Console.WriteLine("Prcat");
        }

        private void execUser_Click(object sender, EventArgs e)
        {
            executionForm execForm = new executionForm();
            execForm.Show();
        }

        private void salesUser_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Available soon!", "Sales Projects", MessageBoxButtons.OK);
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        public void closeMe()
        {
            Close();
        }
    }
}
