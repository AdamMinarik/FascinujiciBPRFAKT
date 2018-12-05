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
        private DataGridViewButtonColumn riskDetailButton;


        public ExecRolog(ExecutionUser user, ExecutionProject execProject)
        {
            InitializeComponent();
            modelManager = new ModelManager();
            itemsList = modelManager.getItems(execProject.projectID, DateTime.Today.ToString(), "risk");
            userLabel.Text = user.firstName + ' ' + user.lastName;
            locationLabel.Text = execProject.name;

            setROlogGridView(itemsList);
            riskDetailButton = new DataGridViewButtonColumn();
            riskDetailButton.Name = "Open";
            riskDetailButton.Text = "Open Risk..";
            riskDetailButton.UseColumnTextForButtonValue = true;

            if (rologGridView.Columns["Open"] == null)
            {
                rologGridView.Columns.Insert(0, riskDetailButton);
            }

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

        private void tableLayoutPanel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void rologGridView_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int riskID;
            ERisk riskItem;
            // Ignore clicks that are not in our 
            if (e.ColumnIndex == rologGridView.Columns["Open"].Index && e.RowIndex >= 0)
            {
                //get projectID from the list
                riskID = (int)rologGridView.Rows[e.RowIndex].Cells[1].Value;
                //get project object from mediator
                riskItem = (ERisk)itemsList.getItem(riskID);
                execROlogTabControl.SelectedIndex = 2;
                setRiskDetail(riskItem);
            }
        }

       // SETS GRIDVIEW WITH PROJECT RISKS
        private void setROlogGridView (EProjectItemList itemList)
        {
            DataTable dt = new DataTable();

            dt.Columns.Add("ID", typeof(int));
            dt.Columns.Add("ExcelID", typeof(string));
            dt.Columns.Add("Name", typeof(string));
            dt.Columns.Add("Status", typeof(string));
            dt.Columns.Add("Risk Owner", typeof(string));
            dt.Columns.Add("Monetary Value Before", typeof(double));
            dt.Columns.Add("Percentage Before", typeof(double));
            dt.Columns.Add("Expected Monetary Value Before", typeof(double));
            dt.Columns.Add("Monetary Value After", typeof(double));
            dt.Columns.Add("Percentage After", typeof(double));
            dt.Columns.Add("Expected Monetary Value After", typeof(double));
       
            foreach (ERisk item in itemList.itemList)
            {
                DataRow NewRow = dt.NewRow();
                NewRow[0] = item.itemID;
                NewRow[1] = item.excelID;
                NewRow[2] = item.itemName;
                NewRow[3] = item.itemStatusID;
                NewRow[4] = item.riskOwnerID;
                NewRow[5] = item.monetaryValueBefore;
                NewRow[6] = item.percentageBefore;
                NewRow[7] = (item.monetaryValueBefore * item.percentageBefore) / 100;
                NewRow[8] = item.monetaryValueAfter;
                NewRow[9] = item.percentageAfter;
                NewRow[10] = (item.monetaryValueAfter * item.percentageAfter) / 100;

                dt.Rows.Add(NewRow);
            }

            rologGridView.DataSource = dt;

        }



        private void setRiskDetail(ERisk riskItem)
        {

            indivRiskIDLabel.Text = riskItem.excelID.ToString();
            riskNameTextBox.Text = riskItem.itemName.ToString();
            statusComboBox.SelectedIndex = riskItem.itemStatusID;
            createdDateTimePicker.Text = riskItem.createDate.ToString();
            updatedDateTimePicker.Text = riskItem.updateDate.ToString();
            if (riskItem.customerShareID == 1)
            {
                canBeSharedCheckBox.Checked = true;
            }
            else
            {
                canBeSharedCheckBox.Checked = false;
            };
            mainRootCauseTextBox.Text = riskItem.mainRootCause.ToString();
            otherRootCausesTextBox.Text = riskItem.otherRootCause.ToString();
            categoryComboBox.Text = riskItem.categoryID.ToString();
            probabilityBeforeResponseTextBox.Text = riskItem.percentageBefore.ToString();
            if (riskItem.respStratRootCauseID == 0) { responseStrategyComboBox.SelectedIndex = -1;} else { responseStrategyComboBox.SelectedIndex = riskItem.respStratRootCauseID;}
            if (riskItem.actionOwnerRootCauseID == 0) { riskActionOwnerComboBox.SelectedIndex = -1; } else { riskActionOwnerComboBox.SelectedIndex = riskItem.actionOwnerRootCauseID;}
            rootCauseActionsTextBox.Text = riskItem.actionsRootCause.ToString();
            responseCostTextBox.Text = riskItem.costRootCause.ToString();
            responsePlanDateTimePicker.Text = riskItem.ResponseRootCauseDate.ToString();
            probabilityAfterResponseTextBox.Text = riskItem.percentageAfter.ToString();

            aggregatedMonateryValueBeforeTextBox.Text = riskItem.monetaryValueBefore.ToString();
            expectedMonetaryValueBeforeTextBox.Text = (riskItem.monetaryValueBefore * riskItem.percentageBefore).ToString();


            aggregatedMonateryValueAfterTextBox.Text = riskItem.monetaryValueAfter.ToString();
            expectedMonateryValueAfterTextBox.Text = (riskItem.monetaryValueAfter * riskItem.percentageAfter).ToString();

            if (riskItem.nccID == 0) { nccComboBox.SelectedIndex = -1;}else{ nccComboBox.SelectedIndex = riskItem.nccID; }
            if (riskItem.orgUnitID == 0) { operatingUnitComboBox.SelectedIndex = -1; } else { operatingUnitComboBox.SelectedIndex = riskItem.orgUnitID; }
            remarksTextBox.Text = riskItem.remarks.ToString();
            timeImpactInDaysBeforeTextBox.Text = riskItem.daysImpactBefore.ToString();
            expectedTimeImpactInDaysBeforeTextBox.Text = (riskItem.daysImpactBefore * riskItem.percentageBefore).ToString();
            timeImpactInDaysAfterTextBox.Text = riskItem.daysImpactAfter.ToString();
            expectedTimeImpactInDaysAfterTextBox.Text = (riskItem.daysImpactAfter * riskItem.percentageAfter).ToString();
            riskDescriptionTextBox.Text = riskItem.itemDescription.ToString();
            riskOwnerComboBox.SelectedIndex = riskItem.riskOwnerID;
            timeCheckBox.Checked = riskItem.timeObjective;
            costCheckBox.Checked = riskItem.costObjective;
            customerSatisfactionCheckBox.Checked = riskItem.customerSatisfObjective;
            safetyCheckBox.Checked = riskItem.safetyObjective;
            qualityCheckBox.Checked = riskItem.qualityObjective;
            if (riskItem.phaseID == 0) { phaseComboBox.SelectedIndex = -1; } else { phaseComboBox.SelectedIndex = riskItem.phaseID; }
            if (riskItem.wbsID == 0) { wbsComboBox.SelectedIndex = -1; } else { wbsComboBox.SelectedIndex = riskItem.wbsID; }
            impactDescriptionTextBox.Text = riskItem.itemDescription.ToString();
            timeImpactsInDaysBeforeTextBox.Text = riskItem.daysImpactBefore.ToString();
            daysAfterTextBox.Text = riskItem.daysImpactAfter.ToString();
            monetaryValueFormulaTextBox.Text = riskItem.formulaBefore.ToString();
            monetaryValueBeforeTextBox.Text = riskItem.monetaryValueBefore.ToString();
            formulaBeforeDescTextBox.Text = riskItem.formulaBeforeDesc.ToString();
            if (riskItem.actionOwnerImpactID == 0) { reStrategyImpactComboBox.SelectedIndex = -1; } else { reStrategyImpactComboBox.SelectedIndex = riskItem.actionOwnerImpactID;}
            if (riskItem.respStratImpactID == 0) { reStrategyImpactComboBox.SelectedIndex = -1;  } else { reStrategyImpactComboBox.SelectedIndex = riskItem.respStratImpactID; }
            impactActionsTextBox.Text = riskItem.actionsImpact.ToString();
            responseCostEstimateTextBox.Text = riskItem.costImpact.ToString();
            responsePlanImplementationDateTimePicker.Text = riskItem.ResponseImpactDate.ToString();
            daysAfterTextBox.Text = riskItem.daysImpactAfter.ToString();
            impactStartDateDateTimePicker.Text = riskItem.impactStartDate.ToString();
            impactEndDateDateTimePicker.Text = riskItem.impactEndDate.ToString();
            monetaryValueAfterTextBox.Text = riskItem.monetaryValueAfter.ToString();
            //calculationDescAfterTextBox.Text = riskItem


        }

        private void ExecRolog_Load(object sender, EventArgs e)
        {
            // TODO: This line of code loads data into the 'dataSet1.rk_risk_packgs' table. You can move, or remove it, as needed.
            this.rk_risk_packgsTableAdapter.Fill(this.dataSet1.rk_risk_packgs);
            // TODO: This line of code loads data into the 'dataSet1.Originating_view' table. You can move, or remove it, as needed.
            this.originating_viewTableAdapter.Fill(this.dataSet1.Originating_view);
            // TODO: This line of code loads data into the 'dataSet1.rk_NCC' table. You can move, or remove it, as needed.
            this.rk_NCCTableAdapter.Fill(this.dataSet1.rk_NCC);
            // TODO: Tento řádek načte data do tabulky 'dataSet1.ListOfOwners'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.listOfOwnersTableAdapter.Fill(this.dataSet1.ListOfOwners);
            // TODO: Tento řádek načte data do tabulky 'dataSet1.rk_resp_Root'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.rk_resp_RootTableAdapter.Fill(this.dataSet1.rk_resp_Root);
            // TODO: Tento řádek načte data do tabulky 'dataSet1.rk_statusOfRisk'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.rk_statusOfRiskTableAdapter.Fill(this.dataSet1.rk_statusOfRisk);

        }
    }
}


