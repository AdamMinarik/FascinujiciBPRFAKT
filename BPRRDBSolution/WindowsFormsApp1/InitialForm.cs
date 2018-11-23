using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Mediator;
using WindowsFormsApp1.Model;


namespace WindowsFormsApp1
{
    public partial class InitialForm : Form
    {
        private ModelManager modelManager;
        public ExecutionUser user;

        public InitialForm()
        {
            InitializeComponent();
            modelManager = new ModelManager();
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void execUser_Click(object sender, EventArgs e)
        {
            user = modelManager.getExecutionUser(Environment.UserName.ToString());
            if (user != null)
            {
                executionForm execForm = new executionForm(user);
                execForm.Show();
            }
            else
            {
                MessageBox.Show("You do not have permission.");
            }
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

        public  ExecutionUser getExecutionUser()
        {
            return user;
        }
    }
}
