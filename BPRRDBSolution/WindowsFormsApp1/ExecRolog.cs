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
using OfficeOpenXml;
using System.IO;

namespace WindowsFormsApp1
{
    public partial class ExecRolog : Form
    {
        private ModelManager modelManager;
        private EProjectItemList itemsList;
        private DataGridViewButtonColumn riskDetailButton;
        private ERisk riskItemDetail;
        private int ProjectID;


        public ExecRolog(ExecutionUser user, ExecutionProject execProject, int ProjectID)
        {
            InitializeComponent();
            this.ProjectID = ProjectID;
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
            setRiskDetailEmpty();
            execROlogTabControl.SelectedIndex = 2;
            
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
            
            // Ignore clicks that are not in our 
            if (e.ColumnIndex == rologGridView.Columns["Open"].Index && e.RowIndex >= 0)
            {
                //get projectID from the list
                riskID = (int)rologGridView.Rows[e.RowIndex].Cells[1].Value;
                //get project object from mediator
                riskItemDetail = (ERisk)itemsList.getItem(riskID);
                execROlogTabControl.SelectedIndex = 2;
                setRiskDetail(riskItemDetail);
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
            statusComboBox.SelectedIndex = riskItem.itemStatusID - 1;
            if(riskItem.createDate.Year < 2000) { createdDateTimePicker.CustomFormat = " "; createdDateTimePicker.Format = DateTimePickerFormat.Custom; } else {createdDateTimePicker.Text = riskItem.createDate.ToString();}
            if (riskItem.updateDate.Year < 2000) { updatedDateTimePicker.CustomFormat = " "; updatedDateTimePicker.Format = DateTimePickerFormat.Custom; } else {updatedDateTimePicker.Text = riskItem.updateDate.ToString();}
            if (riskItem.customerShareID == 1){canBeSharedCheckBox.Checked = true;}else{canBeSharedCheckBox.Checked = false;};
            rootCauseTextBox.Text = riskItem.mainRootCause.ToString();
            otherRootCausesTextBox.Text = riskItem.otherRootCause.ToString();
            if (riskItem.categoryID == 0) { categoryComboBox.SelectedIndex = -1; } else { categoryComboBox.SelectedIndex = riskItem.categoryID - 1; }
            probabilityBeforeResponseTextBox.Text = riskItem.percentageBefore.ToString();
            if (riskItem.respStratRootCauseID == 0) { responseStrategyComboBox.SelectedIndex = -1; } else { responseStrategyComboBox.SelectedIndex = riskItem.respStratRootCauseID - 1; }
            if (riskItem.actionOwnerRootCauseID == 0) { riskActionOwnerComboBox.SelectedIndex = -1; } else { riskActionOwnerComboBox.SelectedIndex = riskItem.actionOwnerRootCauseID - 1; }
            rootCauseActionsTextBox.Text = riskItem.actionsRootCause.ToString();
            rootCauseCostTextBox.Text = riskItem.costRootCause.ToString();
            if (riskItem.ResponseRootCauseDate.Year < 2000) { responsePlanDateTimePicker.CustomFormat = " "; responsePlanDateTimePicker.Format = DateTimePickerFormat.Custom; } else { responsePlanDateTimePicker.Text = riskItem.ResponseRootCauseDate.ToString();}
            probabilityAfterResponseTextBox.Text = riskItem.percentageAfter.ToString();
            aggregatedMonateryValueBeforeTextBox.Text = riskItem.monetaryValueBefore.ToString();
            expectedMonetaryValueBeforeTextBox.Text = (riskItem.monetaryValueBefore * riskItem.percentageBefore).ToString();
            aggregatedMonateryValueAfterTextBox.Text = riskItem.monetaryValueAfter.ToString();
            expectedMonateryValueAfterTextBox.Text = (riskItem.monetaryValueAfter * riskItem.percentageAfter).ToString();
            if (riskItem.nccID == 0) { nccComboBox.SelectedIndex = -1; } else { nccComboBox.SelectedIndex = riskItem.nccID - 1; }
            if (riskItem.orgUnitID == 0) { operatingUnitComboBox.SelectedIndex = -1; } else { operatingUnitComboBox.SelectedIndex = riskItem.orgUnitID - 1; }
            remarksTextBox.Text = riskItem.remarks.ToString();
            timeImpactInDaysBeforeTextBox.Text = riskItem.daysImpactBefore.ToString();
            expectedTimeImpactInDaysBeforeTextBox.Text = ((riskItem.daysImpactBefore * riskItem.percentageBefore) / 100).ToString();
            timeImpactInDaysAfterTextBox.Text = riskItem.daysImpactAfter.ToString();
            expectedTimeImpactInDaysAfterTextBox.Text = ((riskItem.daysImpactAfter * riskItem.percentageAfter) / 100).ToString();
            riskDescriptionTextBox.Text = riskItem.itemDescription.ToString();
            if (riskItem.riskOwnerID == 0) { riskOwnerComboBox.SelectedIndex = -1; } else { riskOwnerComboBox.SelectedIndex = riskItem.riskOwnerID - 1; }
            timeCheckBox.Checked = riskItem.timeObjective;
            costCheckBox.Checked = riskItem.costObjective;
            customerSatisfactionCheckBox.Checked = riskItem.customerSatisfObjective;
            safetyCheckBox.Checked = riskItem.safetyObjective;
            qualityCheckBox.Checked = riskItem.qualityObjective;
            if (riskItem.phaseID == 0) { phaseComboBox.SelectedIndex = -1; } else { phaseComboBox.SelectedIndex = riskItem.phaseID - 1; }
            if (riskItem.wbsID == 0) { wbsComboBox.SelectedIndex = -1; } else { wbsComboBox.SelectedIndex = riskItem.wbsID - 1; }
            impactDescriptionTextBox.Text = riskItem.itemDescription.ToString();
            timeImpactsInDaysBeforeTextBox.Text = riskItem.daysImpactBefore.ToString();
            daysAfterTextBox.Text = riskItem.daysImpactAfter.ToString();
            monetaryValueFormulaTextBox.Text = riskItem.formulaBefore.ToString();
            monetaryValueBeforeTextBox.Text = riskItem.monetaryValueBefore.ToString();
            formulaBeforeDescTextBox.Text = riskItem.formulaBeforeDesc.ToString();
            if (riskItem.actionOwnerImpactID == 0) { impactActionOwnerComboBox.SelectedIndex = -1; } else { impactActionOwnerComboBox.SelectedIndex = riskItem.actionOwnerImpactID - 1; }
            if (riskItem.respStratImpactID == 0) { reStrategyImpactComboBox.SelectedIndex = -1;  } else { reStrategyImpactComboBox.SelectedIndex = riskItem.respStratImpactID - 1; }
            impactActionsTextBox.Text = riskItem.actionsImpact.ToString();
            responseCostEstimateTextBox.Text = riskItem.costImpact.ToString();
            if (riskItem.ResponseImpactDate.Year < 2000) { responsePlanImplementationDateTimePicker.CustomFormat = " "; responsePlanImplementationDateTimePicker.Format = DateTimePickerFormat.Custom; } else { responsePlanImplementationDateTimePicker.Text = riskItem.ResponseImpactDate.ToString(); }
            daysAfterTextBox.Text = riskItem.daysImpactAfter.ToString();

            if (riskItem.impactStartDate.Year < 2000) { impactStartDateDateTimePicker.CustomFormat = " "; impactStartDateDateTimePicker.Format = DateTimePickerFormat.Custom; } else { impactStartDateDateTimePicker.Text = riskItem.impactStartDate.ToString(); }
            if (riskItem.impactEndDate.Year < 2000) { impactEndDateDateTimePicker.CustomFormat = " "; impactEndDateDateTimePicker.Format = DateTimePickerFormat.Custom; } else { impactEndDateDateTimePicker.Text = riskItem.impactEndDate.ToString(); }
            monetaryValueAfterTextBox.Text = riskItem.monetaryValueAfter.ToString();
        }

        private void setRiskDetailEmpty()
        {
            indivRiskIDLabel.Text = (int.Parse(itemsList.getHighestExcelID()) + 1).ToString();
            riskNameTextBox.Text = null;
            statusComboBox.SelectedIndex = 0;
            createdDateTimePicker.Text = null;
            updatedDateTimePicker.Text = null;
            canBeSharedCheckBox.Checked = false; 
            rootCauseTextBox.Text = null;
            otherRootCausesTextBox.Text = null;
            categoryComboBox.SelectedIndex = -1;
            probabilityBeforeResponseTextBox.Text = "0";
            responseStrategyComboBox.SelectedIndex = -1; 
            riskActionOwnerComboBox.SelectedIndex = -1; 
            rootCauseActionsTextBox.Text = null;
            rootCauseCostTextBox.Text = "0";

            responsePlanDateTimePicker.CustomFormat = " ";
            responsePlanDateTimePicker.Format = DateTimePickerFormat.Custom;

            probabilityAfterResponseTextBox.Text = "0";
            aggregatedMonateryValueBeforeTextBox.Text = "0";
            expectedMonetaryValueBeforeTextBox.Text = "0";
            aggregatedMonateryValueAfterTextBox.Text = "0";
            expectedMonateryValueAfterTextBox.Text = "0";
            nccComboBox.SelectedIndex = -1;
            operatingUnitComboBox.SelectedIndex = -1;
            remarksTextBox.Text = null;

            timeImpactInDaysBeforeTextBox.Text = "0";
            expectedTimeImpactInDaysBeforeTextBox.Text = "0";
            timeImpactInDaysAfterTextBox.Text = "0";
            expectedTimeImpactInDaysAfterTextBox.Text = "0";

            riskDescriptionTextBox.Text = null;
            riskOwnerComboBox.SelectedIndex = -1;
            timeCheckBox.Checked = false;
            costCheckBox.Checked = false;
            customerSatisfactionCheckBox.Checked = false;
            safetyCheckBox.Checked =  false;
            qualityCheckBox.Checked =  false;
            phaseComboBox.SelectedIndex = -1;
            wbsComboBox.SelectedIndex = -1;
            impactDescriptionTextBox.Text = null;
            timeImpactsInDaysBeforeTextBox.Text = "0";
            daysAfterTextBox.Text = "0";
            monetaryValueFormulaTextBox.Text = "0";
            monetaryValueBeforeTextBox.Text = "0";
            formulaBeforeDescTextBox.Text = null;
            impactActionOwnerComboBox.SelectedIndex = -1; 
            reStrategyImpactComboBox.SelectedIndex = -1;
            impactActionsTextBox.Text = null;
            responseCostEstimateTextBox.Text = "0";

            responsePlanImplementationDateTimePicker.CustomFormat = " ";
            responsePlanImplementationDateTimePicker.Format = DateTimePickerFormat.Custom;

            daysAfterTextBox.Text = "0";

            impactStartDateDateTimePicker.CustomFormat = " ";
            impactStartDateDateTimePicker.Format = DateTimePickerFormat.Custom;

            impactEndDateDateTimePicker.CustomFormat = " ";
            impactEndDateDateTimePicker.Format = DateTimePickerFormat.Custom;

            monetaryValueAfterTextBox.Text = "0";
        }








        private void ExecRolog_Load(object sender, EventArgs e)
        {
            // TODO: Tento řádek načte data do tabulky 'dataSet1.rk_WBS'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.rk_WBSTableAdapter.Fill(this.dataSet1.rk_WBS);
            // TODO: Tento řádek načte data do tabulky 'dataSet1.rk_response'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.rk_responseTableAdapter.Fill(this.dataSet1.rk_response);
            // TODO: Tento řádek načte data do tabulky 'dataSet1.rk_phases'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.rk_phasesTableAdapter.Fill(this.dataSet1.rk_phases);
            // TODO: Tento řádek načte data do tabulky 'dataSet1.rk_risk_cat'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.rk_risk_catTableAdapter.Fill(this.dataSet1.rk_risk_cat);
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

        private void updateRiskBtn_Click(object sender, EventArgs e)
        {
            riskItemDetail.excelID = indivRiskIDLabel.Text;
            riskItemDetail.itemName = riskNameTextBox.Text;
            riskItemDetail.itemStatusID = statusComboBox.SelectedIndex;
            riskItemDetail.createDate = createdDateTimePicker.Value;
            riskItemDetail.updateDate = updatedDateTimePicker.Value;
            if (canBeSharedCheckBox.Checked == true){riskItemDetail.customerShareID = 1;} else {riskItemDetail.customerShareID = 0;};
            riskItemDetail.mainRootCause = rootCauseTextBox.Text;
            riskItemDetail.otherRootCause = otherRootCausesTextBox.Text;
            riskItemDetail.categoryID = categoryComboBox.SelectedIndex;
            riskItemDetail.percentageBefore = double.Parse(probabilityBeforeResponseTextBox.Text);
            riskItemDetail.respStratRootCauseID = responseStrategyComboBox.SelectedIndex;
            riskItemDetail.actionOwnerRootCauseID = riskActionOwnerComboBox.SelectedIndex;
            riskItemDetail.actionsRootCause = rootCauseActionsTextBox.Text;
            riskItemDetail.costRootCause = double.Parse(rootCauseCostTextBox.Text);
            riskItemDetail.ResponseRootCauseDate = responsePlanDateTimePicker.Value;
            riskItemDetail.percentageAfter = double.Parse(probabilityAfterResponseTextBox.Text);
            riskItemDetail.monetaryValueBefore = double.Parse(aggregatedMonateryValueBeforeTextBox.Text);
            riskItemDetail.monetaryValueAfter = double.Parse(aggregatedMonateryValueAfterTextBox.Text);
            riskItemDetail.nccID = nccComboBox.SelectedIndex;
            riskItemDetail.orgUnitID = operatingUnitComboBox.SelectedIndex;
            riskItemDetail.remarks = remarksTextBox.Text;
            riskItemDetail.daysImpactBefore = int.Parse(timeImpactInDaysBeforeTextBox.Text);
            riskItemDetail.daysImpactAfter = int.Parse(timeImpactInDaysAfterTextBox.Text);
            riskItemDetail.itemDescription = riskDescriptionTextBox.Text;
            riskItemDetail.riskOwnerID = riskOwnerComboBox.SelectedIndex;
            riskItemDetail.timeObjective = timeCheckBox.Checked;
            riskItemDetail.costObjective = costCheckBox.Checked;
            riskItemDetail.customerSatisfObjective = customerSatisfactionCheckBox.Checked;
            riskItemDetail.safetyObjective = safetyCheckBox.Checked;
            riskItemDetail.qualityObjective = qualityCheckBox.Checked;
            riskItemDetail.phaseID = phaseComboBox.SelectedIndex;
            riskItemDetail.wbsID = wbsComboBox.SelectedIndex;
            riskItemDetail.itemDescription = impactDescriptionTextBox.Text;
            riskItemDetail.daysImpactBefore = int.Parse(timeImpactsInDaysBeforeTextBox.Text);
            riskItemDetail.daysImpactAfter = int.Parse(daysAfterTextBox.Text);
            riskItemDetail.formulaBefore = monetaryValueFormulaTextBox.Text;
            riskItemDetail.monetaryValueBefore = double.Parse(monetaryValueBeforeTextBox.Text);
            riskItemDetail.formulaBeforeDesc = formulaBeforeDescTextBox.Text;
            riskItemDetail.actionOwnerImpactID = reStrategyImpactComboBox.SelectedIndex;
            riskItemDetail.respStratImpactID = reStrategyImpactComboBox.SelectedIndex;
            riskItemDetail.actionsImpact = impactActionsTextBox.Text;
            riskItemDetail.costImpact = double.Parse(responseCostEstimateTextBox.Text);
            riskItemDetail.ResponseImpactDate = responsePlanImplementationDateTimePicker.Value;
            riskItemDetail.daysImpactAfter = int.Parse(daysAfterTextBox.Text);
            riskItemDetail.impactStartDate = impactStartDateDateTimePicker.Value;
            riskItemDetail.impactEndDate = impactEndDateDateTimePicker.Value;
            riskItemDetail.monetaryValueAfter = double.Parse(monetaryValueAfterTextBox.Text);

            modelManager.updateItem(riskItemDetail, true, "risk");
        }

        private void impactStartDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            impactStartDateDateTimePicker.CustomFormat = "dd/MM/yyyy";
        }

        private void impactEndDateDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            impactEndDateDateTimePicker.CustomFormat = "dd/MM/yyyy";
        }

        private void responsePlanImplementationDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            responsePlanImplementationDateTimePicker.CustomFormat = "dd/MM/yyyy";
        }

        private void responsePlanDateTimePicker_ValueChanged(object sender, EventArgs e)
        {
            responsePlanDateTimePicker.CustomFormat = "dd/MM/yyyy";
        }

        private void insertRiskBtn_Click(object sender, EventArgs e)
        {
            riskItemDetail = new ERisk(0,"","","","","","","","","","","","",0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,0,false,false,false,false,false,false,false, false,0,0,0,0,
                new DateTime(1900, 1,1), new DateTime(1900, 1, 1), new DateTime(1900, 1, 1), new DateTime(1900, 1, 1), new DateTime(1900, 1, 1), new DateTime(1900, 1, 1));


            riskItemDetail.excelID = indivRiskIDLabel.Text;
            riskItemDetail.itemName = riskNameTextBox.Text;
            riskItemDetail.itemStatusID = statusComboBox.SelectedIndex + 1;
            riskItemDetail.createDate = createdDateTimePicker.Value;
            riskItemDetail.updateDate = updatedDateTimePicker.Value;
            if (canBeSharedCheckBox.Checked == true) { riskItemDetail.customerShareID = 1; } else { riskItemDetail.customerShareID = 0; };
            riskItemDetail.mainRootCause = rootCauseTextBox.Text;
            riskItemDetail.otherRootCause = otherRootCausesTextBox.Text;
            riskItemDetail.categoryID = categoryComboBox.SelectedIndex + 1;
            riskItemDetail.percentageBefore = double.Parse(probabilityBeforeResponseTextBox.Text);
            riskItemDetail.respStratRootCauseID = responseStrategyComboBox.SelectedIndex + 1;
            riskItemDetail.actionOwnerRootCauseID = riskActionOwnerComboBox.SelectedIndex + 1;
            riskItemDetail.actionsRootCause = rootCauseActionsTextBox.Text;
            riskItemDetail.costRootCause = double.Parse(rootCauseCostTextBox.Text);
            riskItemDetail.ResponseRootCauseDate = responsePlanDateTimePicker.Value;
            riskItemDetail.percentageAfter = double.Parse(probabilityAfterResponseTextBox.Text);
            riskItemDetail.monetaryValueBefore = double.Parse(aggregatedMonateryValueBeforeTextBox.Text);
            riskItemDetail.monetaryValueAfter = double.Parse(aggregatedMonateryValueAfterTextBox.Text);
            riskItemDetail.nccID = nccComboBox.SelectedIndex + 1;
            riskItemDetail.orgUnitID = operatingUnitComboBox.SelectedIndex + 1;
            riskItemDetail.remarks = remarksTextBox.Text;
            riskItemDetail.daysImpactBefore = int.Parse(timeImpactInDaysBeforeTextBox.Text);
            riskItemDetail.daysImpactAfter = int.Parse(timeImpactInDaysAfterTextBox.Text);
            riskItemDetail.itemDescription = riskDescriptionTextBox.Text;
            riskItemDetail.riskOwnerID = riskOwnerComboBox.SelectedIndex + 1;
            riskItemDetail.timeObjective = timeCheckBox.Checked;
            riskItemDetail.costObjective = costCheckBox.Checked;
            riskItemDetail.customerSatisfObjective = customerSatisfactionCheckBox.Checked;
            riskItemDetail.safetyObjective = safetyCheckBox.Checked;
            riskItemDetail.qualityObjective = qualityCheckBox.Checked;
            riskItemDetail.phaseID = phaseComboBox.SelectedIndex + 1;
            riskItemDetail.wbsID = wbsComboBox.SelectedIndex + 1;
            riskItemDetail.itemDescription = impactDescriptionTextBox.Text;
            riskItemDetail.daysImpactBefore = int.Parse(timeImpactsInDaysBeforeTextBox.Text);
            riskItemDetail.daysImpactAfter = int.Parse(daysAfterTextBox.Text);
            riskItemDetail.formulaBefore = monetaryValueFormulaTextBox.Text;
            riskItemDetail.monetaryValueBefore = double.Parse(monetaryValueBeforeTextBox.Text);
            riskItemDetail.formulaBeforeDesc = formulaBeforeDescTextBox.Text;
            riskItemDetail.actionOwnerImpactID = reStrategyImpactComboBox.SelectedIndex + 1;
            riskItemDetail.respStratImpactID = reStrategyImpactComboBox.SelectedIndex + 1;
            riskItemDetail.actionsImpact = impactActionsTextBox.Text;
            riskItemDetail.costImpact = double.Parse(responseCostEstimateTextBox.Text);
            riskItemDetail.ResponseImpactDate = responsePlanImplementationDateTimePicker.Value;
            riskItemDetail.daysImpactAfter = int.Parse(daysAfterTextBox.Text);
            riskItemDetail.impactStartDate = impactStartDateDateTimePicker.Value;
            riskItemDetail.impactEndDate = impactEndDateDateTimePicker.Value;
            riskItemDetail.monetaryValueAfter = double.Parse(monetaryValueAfterTextBox.Text);

            modelManager.addItem(riskItemDetail, false, "risk", ProjectID);
        }

        private void roLogReportBtn_Click(object sender, EventArgs e)
        {
            ExportROlogToExcel();
        }



        public void ExportROlogToExcel()
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                excel.Workbook.Worksheets.Add("Project Information");
                excel.Workbook.Worksheets.Add("ROlog");

                var headerRow = new List<string[]>()
                {
                new string[] { "Risk ID", "Risk Name", "Risk Description", "etc." }
                };

                // Determine the header range (e.g. A1:D1)
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";
                // Target a worksheet
                var worksheet = excel.Workbook.Worksheets["ROlog"];
                // Popular header row data
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);


                FileInfo excelFile = new FileInfo(@"C:\Users\Asparagus\Desktop\test.xlsx");
                excel.SaveAs(excelFile);



            }
        }
    }
}


