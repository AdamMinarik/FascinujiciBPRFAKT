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
    public partial class ExecRolog : Form
    {
        public ExecRolog()
        {
            InitializeComponent();
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
    }


    
}
