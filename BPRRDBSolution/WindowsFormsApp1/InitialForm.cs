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
using System.Net;
using System.Diagnostics;

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

            timer2.Start(); upToDateVersionLbl.Text = new WebClient().DownloadString("https://drive.google.com/uc?authuser=0&id=17oR7o31L1HND8-OWAm1LiDQOm1m6P2-g&export=download");
            timer1.Start();
            upToDateVersionLbl.Text = new WebClient().DownloadString("https://drive.google.com/uc?authuser=0&id=17oR7o31L1HND8-OWAm1LiDQOm1m6P2-g&export=download");

            if(curVersionLabel.Text != upToDateVersionLbl.Text)
            {
                downloadNewVersion();
            }
        }


        private void downloadNewVersion()
        {
            MessageBox.Show("There is a new version of the Risk Tool. Press OK to Download it Now!");
            string url = @"https://drive.google.com/uc?authuser=0&id=10l1wPZXBT6QxQ9SeXE4onstZnC3LeYeI&export=download";
            string userDesktopPath = @"C:\Users\" + Environment.UserName.ToString() + @"\Desktop\Risk Tool.exe";

            // Create an instance of WebClient
            WebClient client = new WebClient();
            client.DownloadFile(url, userDesktopPath);
            Process.Start(@"C:\Users\" + Environment.UserName.ToString() + @"\Desktop\Risk Tool.exe");
            Application.Exit();
            Close();
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
