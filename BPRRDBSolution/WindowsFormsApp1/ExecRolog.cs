using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using WindowsFormsApp1.Model;
using WindowsFormsApp1.Mediator;

namespace WindowsFormsApp1
{
    public partial class ExecRolog : Form
    {
        private ModelManager modelManager;
        private EProjectItemList itemsList;


        public ExecRolog(ExecutionUser user, ExecutionProject execProject)
        {
            InitializeComponent();
            modelManager = new ModelManager();
            itemsList = modelManager.getItems(execProject.projectID, DateTime.Today.ToString(), "risk");
            userLabel.Text = user.firstName + ' ' + user.lastName;
            locationLabel.Text = execProject.name;
        }

        public void setLocationLabel(String value)
        {
            locationLabel.Text = value;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void createItemButton_Click(object sender, EventArgs e)
        {
            if (this.createRiskButton.Visible == false)
            {
                this.createRiskButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.createPIButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.createOppButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.createERButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.createOUButton.Visible = true;
            }
            else
            {
                this.createOUButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.createERButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.createOppButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.createPIButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.createRiskButton.Visible = false;
            }
        }

        private void overviewButton_Click(object sender, EventArgs e)
        {
            execROlogTabControl.SelectedIndex = 0;
        }

        private void guideButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("https://screenmessage.com/mehehehe");
        }

        private void MonValueLabel_Click(object sender, EventArgs e)
        {

        }

        private void EMVBeforeRCLabel_Click(object sender, EventArgs e)
        {

        }

        private void itemTabSelector_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (itemTabSelector.SelectedIndex == 0)
            {
                projectItemsTabControl.SelectedIndex = 0;
            }
            else if (itemTabSelector.SelectedIndex == 1)
            {
                projectItemsTabControl.SelectedIndex = 1;
            }
            else if (itemTabSelector.SelectedIndex == 2)
            {
                projectItemsTabControl.SelectedIndex = 2;
            }
            else if (itemTabSelector.SelectedIndex == 3)
            {
                projectItemsTabControl.SelectedIndex = 3;
            }
            else if (itemTabSelector.SelectedIndex == 4)
            {
                projectItemsTabControl.SelectedIndex = 4;
            }
            else MessageBox.Show("What the hell?");
        }

        private void reportsButtons_Click(object sender, EventArgs e)
        {
            execROlogTabControl.SelectedIndex = 6;
        }

        private void projectInfoButton_Click(object sender, EventArgs e)
        {
            execROlogTabControl.SelectedIndex = 9;
        }

        private void permissionsButton_Click(object sender, EventArgs e)
        {
            execROlogTabControl.SelectedIndex = 7;
        }

        private void approvalFuncButton_Click(object sender, EventArgs e)
        {
            execROlogTabControl.SelectedIndex = 8;
        }

        private void createRiskButton_Click(object sender, EventArgs e)
        {
            execROlogTabControl.SelectedIndex = 1;
        }

        private void createPIButton_Click(object sender, EventArgs e)
        {
            execROlogTabControl.SelectedIndex = 2;
        }

        private void createOppButton_Click(object sender, EventArgs e)
        {
            execROlogTabControl.SelectedIndex = 3;
        }

        private void createERButton_Click(object sender, EventArgs e)
        {
            execROlogTabControl.SelectedIndex = 4;
        }

        private void createOUButton_Click(object sender, EventArgs e)
        {
            execROlogTabControl.SelectedIndex = 5;
        }
    }
}


