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
        private ExecutionProject execProject;
        private executionForm executionForm;
        private String sqlConnectionString;
        SqlDataAdapter dataAdapter;
        DataTable dataTable;
        private string permission;
        private ExecutionUser user;
        private DateTime selectedDate;


        public ExecRolog(ExecutionUser user, ExecutionProject execProject, executionForm executionForm, string permission)
        {
            InitializeComponent();
            this.execProject = execProject;
            this.ProjectID = execProject.projectID;
            this.modelManager = new ModelManager();
            this.executionForm = executionForm;
            this.permission = permission;
            this.user = user;
            this.selectedDate = DateTime.Today;

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "riskdbsserver.database.windows.net";
            builder.UserID = "superuser@riskdbsserver";
            builder.Password = "Greenpear@1";
            builder.InitialCatalog = "[EW_Risk_Test]";
            this.sqlConnectionString = builder.ConnectionString;

            setDateComboBox();
            setFilterObjectivesComboBox();

            //CREATE ITEM LIST BY CALLING GETITEMS METHOD FROM MODEL MANAGER
            itemsList = modelManager.getItems(execProject.projectID, selectedDate, "risk");
            //SHOW ROLOG ITEMS IN ROLOG DATA GRID VIEW
            setROlogGridView(itemsList);
            //SET USER NAME LABEL
            userLabel.Text = user.firstName + ' ' + user.lastName;
            //SET PROJECT NAME LABEL
            locationLabel.Text = execProject.name;


        }

        public void refreshROlogItems()
        {
            itemsList = modelManager.getItems(execProject.projectID, selectedDate, "risk");
            setROlogGridView(itemsList);
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
            //CREATE ITEM LIST BY CALLING GETITEMS METHOD FROM MODEL MANAGER
            itemsList = modelManager.getItems(execProject.projectID, selectedDate, "risk");
            //SHOW ROLOG ITEMS IN ROLOG DATA GRID VIEW
            setROlogGridView(itemsList);
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

        private void reportsButtons_Click(object sender, EventArgs e)
        {
            execROlogTabControl.SelectedIndex = 6;
        }

        private void projectInfoButton_Click(object sender, EventArgs e)
        {
            //SET PROJECT INFORMATION FIELDS
            if (projectNameTextBox.Text == "")
            {
                setProjectInformation();
            }

            execROlogTabControl.SelectedIndex = 9;
        }

        private void permissionsButton_Click(object sender, EventArgs e)
        {

            //FILL DATAGRIDVIEW WITH SET PERMISSIONS
            refreshPermissionUsersData();

            //FILL USER COMBOBOX WITH USERS PERMISSION LEVEL 5
            SqlConnection connection = new SqlConnection(sqlConnectionString);
            connection.Open();
            string SQL = "SELECT ID, FirstName +' ' + LastName + ' ｜ Username = ' + UserName as FullName FROM rk_UsersList_view WHERE role = 5;";
            dataAdapter = new SqlDataAdapter(SQL, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);

            userPermissionComboBox.DataSource = dataTable;
            userPermissionComboBox.DisplayMember = "FullName";
            userPermissionComboBox.ValueMember = "ID";
            connection.Close();

            execROlogTabControl.SelectedIndex = 7;
        }

        private void approvalFuncButton_Click(object sender, EventArgs e)
        {
            setNewItemsApprovalView();
            setChangedItemsApprovalView();

            //SELECT APPROVAL FUNCTION TAB
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
                recalculateBottomValues();
            }
        }

        // SETS GRIDVIEW WITH PROJECT RISKS
        private void setROlogGridView(EProjectItemList itemList)
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

            //ADD OPEN BUTTON TO ROLOG DATA GRID VIEW
            riskDetailButton = new DataGridViewButtonColumn();
            riskDetailButton.Name = "Open";
            riskDetailButton.Text = "Open Risk..";
            riskDetailButton.UseColumnTextForButtonValue = true;
            if (rologGridView.Columns["Open"] == null) { rologGridView.Columns.Insert(0, riskDetailButton); }

        }



        private void setRiskDetail(ERisk riskItem)
        {
            indivRiskIDLabel.Text = riskItem.excelID.ToString();
            riskNameTextBox.Text = riskItem.itemName.ToString();
            statusComboBox.SelectedIndex = riskItem.itemStatusID - 1;
            if (riskItem.createDate.Year < 2000) { createdDateTimePicker.CustomFormat = " "; createdDateTimePicker.Format = DateTimePickerFormat.Custom; } else { createdDateTimePicker.Text = riskItem.createDate.ToString(); }
            if (riskItem.updateDate.Year < 2000) { updatedDateTimePicker.CustomFormat = " "; updatedDateTimePicker.Format = DateTimePickerFormat.Custom; } else { updatedDateTimePicker.Text = riskItem.updateDate.ToString(); }
            if (riskItem.customerShareID == 1) { canBeSharedCheckBox.Checked = true; } else { canBeSharedCheckBox.Checked = false; };
            rootCauseTextBox.Text = riskItem.mainRootCause.ToString();
            otherRootCausesTextBox.Text = riskItem.otherRootCause.ToString();
            if (riskItem.categoryID == 0) { categoryComboBox.SelectedIndex = -1; } else { categoryComboBox.SelectedIndex = riskItem.categoryID - 1; }
            probabilityBeforeResponseTextBox.Text = riskItem.percentageBefore.ToString();
            if (riskItem.respStratRootCauseID == 0) { responseStrategyComboBox.SelectedIndex = -1; } else { responseStrategyComboBox.SelectedIndex = riskItem.respStratRootCauseID - 1; }
            if (riskItem.actionOwnerRootCauseID == 0) { riskActionOwnerComboBox.SelectedIndex = -1; } else { riskActionOwnerComboBox.SelectedIndex = riskItem.actionOwnerRootCauseID - 1; }
            rootCauseActionsTextBox.Text = riskItem.actionsRootCause.ToString();
            rootCauseCostTextBox.Text = riskItem.costRootCause.ToString();
            if (riskItem.ResponseRootCauseDate.Year < 2000) { responsePlanDateTimePicker.CustomFormat = " "; responsePlanDateTimePicker.Format = DateTimePickerFormat.Custom; } else { responsePlanDateTimePicker.Text = riskItem.ResponseRootCauseDate.ToString(); }
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
            if (riskItem.respStratImpactID == 0) { reStrategyImpactComboBox.SelectedIndex = -1; } else { reStrategyImpactComboBox.SelectedIndex = riskItem.respStratImpactID - 1; }
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
            safetyCheckBox.Checked = false;
            qualityCheckBox.Checked = false;
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
            // TODO: Tento řádek načte data do tabulky 'dataSet1.rk_CurrencyName'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.rk_CurrencyNameTableAdapter.Fill(this.dataSet1.rk_CurrencyName);
            // TODO: Tento řádek načte data do tabulky 'dataSet1.WTGtype'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.wTGtypeTableAdapter.Fill(this.dataSet1.WTGtype);
            // TODO: Tento řádek načte data do tabulky 'dataSet1.rk_Segment'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.rk_SegmentTableAdapter.Fill(this.dataSet1.rk_Segment);
            // TODO: Tento řádek načte data do tabulky 'dataSet1.rk_PreAssemblyHarbour'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.rk_PreAssemblyHarbourTableAdapter.Fill(this.dataSet1.rk_PreAssemblyHarbour);
            // TODO: Tento řádek načte data do tabulky 'dataSet1.rk_FoundationType'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.rk_FoundationTypeTableAdapter.Fill(this.dataSet1.rk_FoundationType);
            // TODO: Tento řádek načte data do tabulky 'dataSet1.rk_scope'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.rk_scopeTableAdapter.Fill(this.dataSet1.rk_scope);
            // TODO: Tento řádek načte data do tabulky 'dataSet1.rk_UsersList_view'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.rk_UsersList_viewTableAdapter.Fill(this.dataSet1.rk_UsersList_view);
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

            //UPDATE OBJECT WITH CAPTURED DATA
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
            riskItemDetail.monetaryValueAfter = double.Parse(aggregatedMonateryValueAfterTextBox.Text.Replace(",", "."));
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


            //CALL METHOD FROM MODEL MANAGER TO UPDATE DATABASE
            if (permission == "owner")
            {
                modelManager.updateItem(riskItemDetail, true, "risk");
            }
            else
            {
                modelManager.updateItem(riskItemDetail, false, "risk");
            }

            //REFRESH LIST OF ITEMS WITH UPDATED DATA
            refreshROlogItems();
            //RETURN TO OVERVIEW
            execROlogTabControl.SelectedIndex = 0;
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
            riskItemDetail = new ERisk(0, "", "", "", "", "", "", "", "", "", "", "", "", 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, false, false, false, false, false, false, false, false, 0, 0, 0, 0,
                new DateTime(1900, 1, 1), new DateTime(1900, 1, 1), new DateTime(1900, 1, 1), new DateTime(1900, 1, 1), new DateTime(1900, 1, 1), new DateTime(1900, 1, 1));


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

            if (permission == "owner")
            {
                modelManager.addItem(riskItemDetail, false, "risk", ProjectID, user.userName);
            }
            else
            {
                modelManager.addItem(riskItemDetail, true, "risk", ProjectID, user.userName);
            }
            //REFRESH LIST OF ITEMS WITH UPDATED DATA
            refreshROlogItems();
            //RETURN TO OVERVIEW
            execROlogTabControl.SelectedIndex = 0;
        }

        private void roLogReportBtn_Click(object sender, EventArgs e)
        {
            ExportROlogToExcel(itemsList.getRisks());
        }

        public void ExportROlogToExcel(EProjectItemList listOfItems)
        {
            using (ExcelPackage excel = new ExcelPackage())
            {
                List<EProjectItem> itemList = listOfItems.itemList;
                excel.Workbook.Worksheets.Add("Project Information");
                excel.Workbook.Worksheets.Add("ROlog");

                // Target a worksheet
                var worksheet = excel.Workbook.Worksheets["ROlog"];

                var headerRow = new List<string[]>()
                {
                new string[] { "Risk ID", "Risk Type", "Status", "Creation date", "Last modification date", "Risk name", "BU%", "RU%", "Root Causes", "Category", "Risk Description",
                               "Risk Owner", "Direct Impact", "Objectives Impacted", "Phase", "WBS","Impact Start Date", "Impact End Date", "Root Cause Probability before Response",
                               "Direct Impact before response", "Time Impact before response (Days)", "Expected Monetary Value before Response", "Response strategy to Root Cause",
                               "Response plan to ROot Cause", "Risk Actions Owner", "Cost Estimate for Response plan to be implemented","Earliest Date for response plan to be implemented",
                               "Response Strategy to Impact", "Risk Actions Owner",
                               "Cost Estimate for Response plan implementation", "Earliest Date for Response plan to be implemented", "Root Cause Propbability after Response",
                               "Direct Impact after Response", "Time Impact after response (days)", "Expected Monetary Value afte response (Risk Contingency)", "Response Exposure",
                               "Can be shared with Customer?",  "NCC", "Originating Unit", "Remarks"
                              }
                };

                // Determine the header range (e.g. A1:D1)
                string headerRange = "A1:" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "1";
                // Popular header row data
                worksheet.Cells[headerRange].LoadFromArrays(headerRow);

                for (int i = 0; i < itemList.Count; i++)
                {
                    //Risks
                    if (itemList[i].GetType() == typeof(ERisk))
                    {

                        ERisk riskItem = (ERisk)itemList[i];

                        headerRow = new List<string[]>()
                       {
                       new string[] { riskItem.excelID.ToString(), "Individual Risk", riskItem.itemStatusID.ToString(), riskItem.createDate.ToString(), riskItem.updateDate.ToString(),
                                      riskItem.itemName.ToString(), riskItem.buRate.ToString(), (100-riskItem.buRate).ToString(), riskItem.mainRootCause + " " + riskItem.otherRootCause,
                                      riskItem.categoryID.ToString(), riskItem.itemDescription, riskItem.riskOwnerID.ToString(), riskItem.impactDesc, "OBJECTIVES TODO",
                                      riskItem.phaseID.ToString(),riskItem.wbsID.ToString(),riskItem.impactStartDate.ToString(), riskItem.impactEndDate.ToString(),
                                      riskItem.percentageBefore.ToString(), riskItem.monetaryValueBefore.ToString(), riskItem.daysImpactBefore.ToString(),
                                      (riskItem.monetaryValueBefore * riskItem.percentageBefore / 100).ToString(), riskItem.respStratRootCauseID.ToString(),
                                      riskItem.actionsRootCause, riskItem.actionOwnerRootCauseID.ToString(), riskItem.costRootCause.ToString(), riskItem.ResponseRootCauseDate.ToString(),
                                      riskItem.respStratImpactID.ToString(), riskItem.actionOwnerImpactID.ToString(), riskItem.costImpact.ToString(),
                                      riskItem.ResponseImpactDate.ToString(), riskItem.percentageAfter.ToString(), riskItem.monetaryValueAfter.ToString(),
                                      riskItem.daysImpactAfter.ToString(), (riskItem.monetaryValueAfter * riskItem.percentageAfter / 100).ToString(),
                                      ((riskItem.monetaryValueAfter * riskItem.percentageAfter / 100) - (riskItem.monetaryValueBefore * riskItem.percentageBefore / 100)).ToString(),
                                      riskItem.customerShareID.ToString(),  riskItem.nccID.ToString(), riskItem.orgUnitID.ToString(), riskItem.remarks
                                    }
                       };
                        MessageBox.Show(i.ToString());
                        // Determine the header range (e.g. A1:D1)
                        headerRange = "A" + (i + 2) + ":" + Char.ConvertFromUtf32(headerRow[0].Length + 64) + "" + (i + 2);
                        // Popular header row data
                        worksheet.Cells[headerRange].LoadFromArrays(headerRow);

                    }
                }

                FileInfo excelFile = new FileInfo(@"C:\Users\Asparagus\Desktop\test.xlsx");
                excel.SaveAs(excelFile);

            }
        }


        public void setProjectInformation()
        {
            projectNameTextBox.Text = execProject.name;
            projectOwnerComboBox.SelectedItem = execProject.ownerID - 1;
            projectIDTextBox.Text = execProject.sap;
            LoaIDTextBox.Text = execProject.loa;
            PMTextBox.Text = execProject.pm;
            scopeComboBox.SelectedItem = execProject.scopeID - 1;
            CPMTextBox.Text = execProject.cpm;
            preparedByTextBox.Text = execProject.prepBy;
            tocTextBox.Text = execProject.toc.ToString();
            wtgNoTextBox.Text = execProject.numberWtgs.ToString();
            buCostsTextBox.Text = execProject.BUcontract.ToString();
            ruCostsTextBox.Text = execProject.RUcontract.ToString();
            totalProjectCostsTextBox.Text = (execProject.BUcontract + execProject.RUcontract).ToString();
            buCurComboBox.SelectedItem = execProject.BUCurID;
            ruCurComboBox.SelectedItem = execProject.RUCurID;
            buRateTextBox.Text = execProject.BUrate.ToString();
            ruRateTextBox.Text = execProject.RUrate.ToString();
            foundationComboBox.SelectedItem = execProject.foundationID;
            portComboBox.SelectedItem = execProject.harbourID;
            segmentComboBox.SelectedItem = execProject.segmentID;
            wtgTypeComboBox.SelectedItem = execProject.wtgID;

        }

        private void updateProjectButton_Click(object sender, EventArgs e)
        {
            //UPDATE PROJECT OBJECT
            execProject.name = projectNameTextBox.Text;
            execProject.ownerID = int.Parse(projectOwnerComboBox.SelectedValue.ToString());
            execProject.sap = projectIDTextBox.Text;
            execProject.loa = LoaIDTextBox.Text;
            execProject.pm = PMTextBox.Text;
            execProject.scopeID = (int)scopeComboBox.SelectedValue;
            execProject.cpm = CPMTextBox.Text;
            execProject.prepBy = preparedByTextBox.Text;
            execProject.toc = tocTextBox.Value;
            execProject.numberWtgs = int.Parse(wtgNoTextBox.Text);
            execProject.BUcontract = double.Parse(buCostsTextBox.Text);
            execProject.RUcontract = double.Parse(ruCostsTextBox.Text);
            execProject.BUCurID = (int)buCurComboBox.SelectedValue;
            execProject.RUCurID = (int)ruCurComboBox.SelectedValue;
            execProject.BUrate = decimal.Parse(buRateTextBox.Text);
            execProject.RUrate = decimal.Parse(ruRateTextBox.Text);
            execProject.foundationID = (int)foundationComboBox.SelectedValue;
            execProject.harbourID = (int)portComboBox.SelectedValue;
            execProject.segmentID = (int)segmentComboBox.SelectedValue;
            execProject.wtgID = (int)wtgTypeComboBox.SelectedValue;
            //UPDATE DATABASE PROJECT TABLE
            modelManager.updateProject(execProject);
            //CHANGE PROJECT NAME LABEL
            locationLabel.Text = execProject.name;
            //REFRESH PROJECTS DATA GRID VIEW IN EXECUTION FORM
            this.executionForm.setProjectsData();
            //GO TO OVERVIEW TAB
            execROlogTabControl.SelectedIndex = 0;
        }



        private void refreshPermissionUsersData()
        {
            //FILL DATAGRIDVIEW WITH SET PERMISSIONS
            SqlConnection connection = new SqlConnection(sqlConnectionString);
            connection.Open();
            string SQL = "SELECT FirstName,LastName,UserName,  CASE WHEN WriteID = 1 THEN 'No' ELSE 'Yes' END AS WritePermission FROM rk_pro_permission_view WHERE rk_pro_permission_view.projID = " + execProject.projectID.ToString() + " ORDER BY LastName ASC, FirstName ASC";

            dataAdapter = new SqlDataAdapter(SQL, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            userPermissionData.DataSource = dataTable;
            connection.Close();
        }

        private void writeGrantBtn_Click(object sender, EventArgs e)
        {
            string SQL = "INSERT INTO rk_pro_permission(userID,projId,readID,writeID) VALUES ( " + userPermissionComboBox.SelectedValue.ToString() + "," + execProject.projectID.ToString() + ",1,2)";
            string SQL_ = "DELETE FROM rk_pro_permission WHERE userID =" + userPermissionComboBox.SelectedValue.ToString() + " AND projID =" + execProject.projectID.ToString();

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            using (SqlCommand command = new SqlCommand(SQL_, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            using (SqlCommand command = new SqlCommand(SQL, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            refreshPermissionUsersData();
        }

        private void delPermissionBtn_Click(object sender, EventArgs e)
        {
            string SQL_ = "DELETE FROM rk_pro_permission WHERE userID =" + userPermissionComboBox.SelectedValue.ToString() + " AND projID =" + execProject.projectID.ToString();

            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            using (SqlCommand command = new SqlCommand(SQL_, connection))
            {
                connection.Open();
                command.ExecuteNonQuery();
                connection.Close();
            }

            refreshPermissionUsersData();
        }

        private void overviewTab_Click(object sender, EventArgs e)
        {

        }



        private void monetaryValueFormulaTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                double result = Convert.ToDouble(new DataTable().Compute(monetaryValueFormulaTextBox.Text, null));


                if (Math.Abs(double.Parse(monetaryValueAfterTextBox.Text)) > Math.Abs(result))
                {
                    MessageBox.Show("Monetary value after response needs to be lower then or equals to monetary value before response");
                    monetaryValueAfterTextBox.Focus();
                }
                else if (result < 0)
                {
                    monetaryValueBeforeTextBox.Text = result.ToString();
                    recalculateBottomValues();
                }
                else
                {
                    MessageBox.Show("Monetary value after response needs to be negative");
                    monetaryValueFormulaTextBox.Focus();
                }

            }
            catch
            {
                MessageBox.Show("Invalid Formula");
                monetaryValueFormulaTextBox.Focus();
            }
        }

        private void probabilityBeforeResponseTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                int p = int.Parse(probabilityBeforeResponseTextBox.Text);
                if (p < 0 || p > 100)
                {
                    MessageBox.Show("Probability needs to be number between 0 and 100");
                    probabilityBeforeResponseTextBox.Focus();
                }
                else if (int.Parse(probabilityAfterResponseTextBox.Text) > int.Parse(probabilityBeforeResponseTextBox.Text))
                {
                    MessageBox.Show("Probability after response needs to be lower then or equals to probability before response");
                    probabilityBeforeResponseTextBox.Focus();
                }
                recalculateBottomValues();
            }
            catch
            {
                MessageBox.Show("Probability needs to be number between 0 and 100");
                probabilityBeforeResponseTextBox.Focus();
            }
        }

        private void probabilityAfterResponseTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                int p = int.Parse(probabilityAfterResponseTextBox.Text);
                if (p < 0 || p > 100)
                {
                    MessageBox.Show("Probability needs to be number between 0 and 100");
                    probabilityAfterResponseTextBox.Focus();
                }
                else if (int.Parse(probabilityAfterResponseTextBox.Text) > int.Parse(probabilityBeforeResponseTextBox.Text))
                {
                    MessageBox.Show("Probability after response needs to be lower then or equals to probability before response");
                    probabilityAfterResponseTextBox.Focus();
                }
                recalculateBottomValues();
            }
            catch
            {
                MessageBox.Show("Probability needs to be number between 0 and 100");
                probabilityAfterResponseTextBox.Focus();
            }
        }

        private void rootCauseCostTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(rootCauseCostTextBox.Text) > 0)
                {
                    MessageBox.Show("Root cause response cost needs to be a negative number");
                    rootCauseCostTextBox.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Root cause response cost needs to be a negative number");
                rootCauseCostTextBox.Focus();
            }
        }

        private void responseCostEstimateTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (double.Parse(rootCauseCostTextBox.Text) > 0)
                {
                    MessageBox.Show("Root cause response cost needs to be a negative number");
                    rootCauseCostTextBox.Focus();
                }
            }
            catch
            {
                MessageBox.Show("Root cause response cost needs to be a negative number");
                rootCauseCostTextBox.Focus();
            }
        }

        private void monetaryValueAfterTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                double result = Convert.ToDouble(new DataTable().Compute(monetaryValueFormulaTextBox.Text, null));

                if (double.Parse(monetaryValueAfterTextBox.Text) > 0)
                {
                    MessageBox.Show("Monetary value after response needs to be a negative number");
                    monetaryValueAfterTextBox.Focus();
                }
                else if (Math.Abs(double.Parse(monetaryValueAfterTextBox.Text)) > Math.Abs(result))
                {
                    MessageBox.Show("Monetary value after response needs to be lower then or equals to monetary value before response");
                    monetaryValueAfterTextBox.Focus();
                }
                recalculateBottomValues();
            }
            catch
            {
                MessageBox.Show("Monetary value after response needs to be a negative number");
                monetaryValueAfterTextBox.Focus();
            }
        }

        private void timeImpactsInDaysBeforeTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (decimal.Parse(timeImpactsInDaysBeforeTextBox.Text) < 0)
                {
                    MessageBox.Show("Time impact needs to be a positive number");
                    timeImpactsInDaysBeforeTextBox.Focus();
                }
                else if (decimal.Parse(timeImpactsInDaysBeforeTextBox.Text) < decimal.Parse(daysAfterTextBox.Text))
                {
                    MessageBox.Show("Time after response needs to be lower then or equals to time before response");
                    timeImpactsInDaysBeforeTextBox.Focus();
                }

                recalculateBottomValues();
            }
            catch
            {
                MessageBox.Show("Time impact needs to be a positive number");
                timeImpactsInDaysBeforeTextBox.Focus();
            }
        }

        private void daysAfterTextBox_Leave(object sender, EventArgs e)
        {
            try
            {
                if (decimal.Parse(daysAfterTextBox.Text) < 0)
                {
                    MessageBox.Show("Time impact needs to be a positive number");
                    daysAfterTextBox.Focus();
                }
                else if (decimal.Parse(timeImpactsInDaysBeforeTextBox.Text) < decimal.Parse(daysAfterTextBox.Text))
                {
                    MessageBox.Show("Time after response needs to be lower then or equals to time before response");
                    daysAfterTextBox.Focus();
                }
                recalculateBottomValues();
            }
            catch
            {
                MessageBox.Show("Time impact needs to be a positive number");
                daysAfterTextBox.Focus();
            }
        }

        public void recalculateBottomValues()
        {
            decimal result = Convert.ToDecimal(new DataTable().Compute(monetaryValueFormulaTextBox.Text, null));
            monetaryValueBeforeTextBox.Text = result.ToString();

            //LEFT MONET VALUES
            aggregatedMonateryValueBeforeTextBox.Text = result.ToString();
            expectedMonetaryValueBeforeTextBox.Text = (result * decimal.Parse(probabilityBeforeResponseTextBox.Text) / 100).ToString();
            //RIGHT MONET VALUES
            aggregatedMonateryValueAfterTextBox.Text = decimal.Parse(monetaryValueAfterTextBox.Text).ToString();
            expectedMonateryValueAfterTextBox.Text = (decimal.Parse(monetaryValueAfterTextBox.Text) * decimal.Parse(probabilityAfterResponseTextBox.Text) / 100).ToString();

            //LEFT DAY VALUES
            timeImpactInDaysBeforeTextBox.Text = decimal.Parse(timeImpactsInDaysBeforeTextBox.Text).ToString();
            expectedTimeImpactInDaysBeforeTextBox.Text = (decimal.Parse(timeImpactsInDaysBeforeTextBox.Text) * decimal.Parse(probabilityBeforeResponseTextBox.Text) / 100).ToString();
            //RIGHT DAY VALUES
            timeImpactInDaysAfterTextBox.Text = decimal.Parse(daysAfterTextBox.Text).ToString();
            expectedTimeImpactInDaysAfterTextBox.Text = (decimal.Parse(daysAfterTextBox.Text) * decimal.Parse(probabilityAfterResponseTextBox.Text) / 100).ToString();
        }

        private void newItemsApprovalData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int newRiskID = int.Parse(newItemsApprovalData.Rows[e.RowIndex].Cells[2].Value.ToString());

            // Ignore clicks that are not in our 
            if (e.ColumnIndex == newItemsApprovalData.Columns["Approve"].Index && e.RowIndex >= 0)
            {
                //APPROVE NEW ITEM
                modelManager.approveNewItem(execProject.projectID, newRiskID);
                //REFRESH NEW ITEMS APPROVAL DATA GRID VIEW
                setNewItemsApprovalView();
                //CREATE ITEM LIST BY CALLING GETITEMS METHOD FROM MODEL MANAGER
                itemsList = modelManager.getItems(execProject.projectID, selectedDate, "risk");
                //SHOW ROLOG ITEMS IN ROLOG DATA GRID VIEW
                setROlogGridView(itemsList);
            }
            else if (e.ColumnIndex == newItemsApprovalData.Columns["Decline"].Index && e.RowIndex >= 0)
            {
                //DECLINE NEW ITEM
                modelManager.declineNewItem(execProject.projectID, newRiskID);
                //REFRESH NEW ITEMS APPROVAL DATA GRID VIEW
                setNewItemsApprovalView();
            }
        }

        public void setChangedItemsApprovalView()
        {
            //SET NEW RISKS DATAGRIDVIEW
            DataGridViewButtonColumn approveButtonColumn;
            DataGridViewButtonColumn declineButtonColumn;

            SqlConnection connection = new SqlConnection(sqlConnectionString);
            connection.Open();
            string SQL = "SELECT * FROM rk_ROlogChanges WHERE ProjectID =" + execProject.projectID.ToString();
            dataAdapter = new SqlDataAdapter(SQL, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            changesApprovalData.DataSource = dataTable;

            approveButtonColumn = new DataGridViewButtonColumn();
            approveButtonColumn.Name = "Approve";
            approveButtonColumn.Text = "Approve";
            approveButtonColumn.UseColumnTextForButtonValue = true;
            approveButtonColumn.HeaderText = "";
            if (changesApprovalData.Columns["Approve"] == null)
            {
                changesApprovalData.Columns.Insert(18, approveButtonColumn);
            }

            declineButtonColumn = new DataGridViewButtonColumn();
            declineButtonColumn.Name = "Decline";
            declineButtonColumn.Text = "Decline";
            declineButtonColumn.UseColumnTextForButtonValue = true;
            declineButtonColumn.HeaderText = "";
            if (changesApprovalData.Columns["Decline"] == null)
            {
                changesApprovalData.Columns.Insert(19, declineButtonColumn);
            }
        }


        public void setNewItemsApprovalView()
        {
            //SET NEW RISKS DATAGRIDVIEW
            DataGridViewButtonColumn approveButtonColumn;
            DataGridViewButtonColumn declineButtonColumn;

            SqlConnection connection = new SqlConnection(sqlConnectionString);
            connection.Open();
            string SQL = "SELECT ID, ExcelCode, addItemType, Rname, updatedate, FirstName, LastName FROM newItemsViewApproval WHERE IDproj = " + execProject.projectID.ToString() + " order by updateDate;";
            dataAdapter = new SqlDataAdapter(SQL, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            newItemsApprovalData.DataSource = dataTable;

            approveButtonColumn = new DataGridViewButtonColumn();
            approveButtonColumn.Name = "Approve";
            approveButtonColumn.Text = "Approve";
            approveButtonColumn.UseColumnTextForButtonValue = true;
            approveButtonColumn.HeaderText = "";
            if (newItemsApprovalData.Columns["Approve"] == null)
            {
                newItemsApprovalData.Columns.Insert(7, approveButtonColumn);
            }

            declineButtonColumn = new DataGridViewButtonColumn();
            declineButtonColumn.Name = "Decline";
            declineButtonColumn.Text = "Decline";
            declineButtonColumn.UseColumnTextForButtonValue = true;
            declineButtonColumn.HeaderText = "";
            if (newItemsApprovalData.Columns["Decline"] == null)
            {
                newItemsApprovalData.Columns.Insert(8, declineButtonColumn);
            }
        }

        private void changesApprovalData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            int projectID = execProject.projectID;

            int changedItemID = int.Parse(changesApprovalData.Rows[e.RowIndex].Cells[19].Value.ToString());
            int UpdatedColID = int.Parse(changesApprovalData.Rows[e.RowIndex].Cells[13].Value.ToString());
            string newValueString = changesApprovalData.Rows[e.RowIndex].Cells[6].Value.ToString();
            int newColumnID = -1;
            if (changesApprovalData.Rows[e.RowIndex].Cells[7].Value.ToString() != "")
            {
                newColumnID = int.Parse(changesApprovalData.Rows[e.RowIndex].Cells[7].Value.ToString());
            }
            string updatedColumntxt = changesApprovalData.Rows[e.RowIndex].Cells[12].Value.ToString();
            int idOfChange = int.Parse(changesApprovalData.Rows[e.RowIndex].Cells[2].Value.ToString());

            // Ignore clicks that are not in our 
            if (e.ColumnIndex == changesApprovalData.Columns["Approve"].Index && e.RowIndex >= 0)
            {
                //APPROVE CHANGED ITEM
                modelManager.approveChangedItem(projectID, changedItemID, UpdatedColID, newValueString, newColumnID, updatedColumntxt, idOfChange);
                //REFRESH CHANGES APPROVAL DATA GRID VIEW
                setChangedItemsApprovalView();

                //CREATE ITEM LIST BY CALLING GETITEMS METHOD FROM MODEL MANAGER
                itemsList = modelManager.getItems(execProject.projectID, selectedDate, "risk");
                //SHOW ROLOG ITEMS IN ROLOG DATA GRID VIEW
                setROlogGridView(itemsList);
            }
            else if (e.ColumnIndex == changesApprovalData.Columns["Decline"].Index && e.RowIndex >= 0)
            {
                //DECLINE CHANGED ITEM
                modelManager.declineChangedItem(projectID, changedItemID, UpdatedColID, newValueString, newColumnID, updatedColumntxt, idOfChange);
                //REFRESH CHANGES APPROVAL DATA GRID VIEW
                setChangedItemsApprovalView();
                //CREATE ITEM LIST BY CALLING GETITEMS METHOD FROM MODEL MANAGER
                itemsList = modelManager.getItems(execProject.projectID, selectedDate, "risk");
                //SHOW ROLOG ITEMS IN ROLOG DATA GRID VIEW
                setROlogGridView(itemsList);
            }
        }

        public void setDateComboBox()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                string queryString = "EXEC ListOfDatesProcedure @IDProj =" + execProject.projectID.ToString();
                SqlCommand command = new SqlCommand(queryString, connection);
                connection.Open();
                command.CommandTimeout = 120;
                command.ExecuteNonQuery();
                connection.Close();

                connection.Open();
                string SQL = "SELECT * FROM rk_DateSelectionTable ORDER BY ID desc";
                dataAdapter = new SqlDataAdapter(SQL, connection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                reportingMonthComboBox.DataSource = dataTable;
                reportingMonthComboBox.DisplayMember = "listDate";
                reportingMonthComboBox.ValueMember = "ID";
                DataRowView ComboRowView = reportingMonthComboBox.SelectedItem as DataRowView;

                string listDate = string.Empty;

                if (ComboRowView != null)
                {
                    listDate = ComboRowView.Row["listDate"] as string;
                    //MessageBox.Show(listDate.Substring(0, 2).Replace("-", ""));
                    selectedDate = DateTime.Parse("1-" + listDate);
                }

                connection.Close();
            }
        }

        private void reportingMonthComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            DataRowView ComboRowView = reportingMonthComboBox.SelectedItem as DataRowView;
            string listDate = string.Empty;

            if (ComboRowView != null)
            {
                listDate = ComboRowView.Row["listDate"] as string;
                //MessageBox.Show(listDate.Substring(0, 2).Replace("-", ""));
                selectedDate = DateTime.Parse("1-" + listDate);
                //CREATE ITEM LIST BY CALLING GETITEMS METHOD FROM MODEL MANAGER
                itemsList = modelManager.getItems(execProject.projectID, selectedDate, "risk");
                //SHOW ROLOG ITEMS IN ROLOG DATA GRID VIEW
                setROlogGridView(itemsList);

            }
        }

        public void setFilterObjectivesComboBox()
        {
            using (SqlConnection connection = new SqlConnection(sqlConnectionString))
            {
                connection.Open();
                string SQL = "SELECT * FROM rk_FilterObjectives";
                dataAdapter = new SqlDataAdapter(SQL, connection);
                dataTable = new DataTable();
                dataAdapter.Fill(dataTable);

                filterObjectivesComboBox.DataSource = dataTable;
                filterObjectivesComboBox.DisplayMember = "code";
                filterObjectivesComboBox.ValueMember = "ID";
                connection.Close();
            }
            filterObjectivesComboBox.SelectedIndex = -1;
        }

        private void filterObjectivesComboBox_SelectionChangeCommitted(object sender, EventArgs e)
        {
            if (filterObjectivesComboBox.SelectedIndex != -1)
            {
                //PROJECT OWNER
                if (filterObjectivesComboBox.SelectedIndex == 0)
                {
                    using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                    {
                        connection.Open();
                        string SQL = "SELECT ID,Package FROM rk_risk_packgs";
                        dataAdapter = new SqlDataAdapter(SQL, connection);
                        dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        filterCriteriaComboBox.DataSource = dataTable;
                        filterCriteriaComboBox.DisplayMember = "Package";
                        filterCriteriaComboBox.ValueMember = "ID";
                        connection.Close();
                    }
                }
                //ACTION OWNER
                else if (filterObjectivesComboBox.SelectedIndex == 1)
                {
                    using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                    {
                        connection.Open();
                        string SQL = "SELECT ID,Name FROM listOfOwners";
                        dataAdapter = new SqlDataAdapter(SQL, connection);
                        dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        filterCriteriaComboBox.DataSource = dataTable;
                        filterCriteriaComboBox.DisplayMember = "Name";
                        filterCriteriaComboBox.ValueMember = "ID";
                        connection.Close();
                    }
                }
                //CATEGORY OWNER
                else if (filterObjectivesComboBox.SelectedIndex == 2)
                {
                    using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                    {
                        connection.Open();
                        string SQL = "SELECT ID,Cname FROM rk_risk_cat";
                        dataAdapter = new SqlDataAdapter(SQL, connection);
                        dataTable = new DataTable();
                        dataAdapter.Fill(dataTable);

                        filterCriteriaComboBox.DataSource = dataTable;
                        filterCriteriaComboBox.DisplayMember = "Cname";
                        filterCriteriaComboBox.ValueMember = "ID";
                        connection.Close();
                    }
                }
            }
        }

        private void filterBtn_Click(object sender, EventArgs e)
        {
            int filterObjectiveID = filterObjectivesComboBox.SelectedIndex;
            int filterCriteriaID = int.Parse(filterCriteriaComboBox.SelectedValue.ToString());

            //PROJECT OWNER
            if (filterObjectivesComboBox.SelectedIndex == 0)
            {
                itemsList = modelManager.getFilterItems(execProject.projectID, selectedDate, filterObjectiveID, filterCriteriaID);
            }
            //ACTION OWNER
            else if (filterObjectivesComboBox.SelectedIndex == 1)
            {
                itemsList = modelManager.getFilterItems(execProject.projectID, selectedDate, filterObjectiveID, filterCriteriaID);
            }
            //CATEGORY OWNER
            else if (filterObjectivesComboBox.SelectedIndex == 2)
            {
                itemsList = modelManager.getFilterItems(execProject.projectID, selectedDate, filterObjectiveID, filterCriteriaID);
            }

            if (itemsList.itemList.Count == 0)
            {
                itemsList = modelManager.getItems(execProject.projectID, selectedDate, "risk");
                MessageBox.Show("No items found.");
            }

            //SHOW ROLOG ITEMS IN ROLOG DATA GRID VIEW
            setROlogGridView(itemsList);

        }

        private void clearFilterBtn_Click(object sender, EventArgs e)
        {
            itemsList = modelManager.getItems(execProject.projectID, selectedDate, "risk");
            setROlogGridView(itemsList);
            filterObjectivesComboBox.SelectedIndex = -1;
            filterCriteriaComboBox.SelectedIndex = -1;
        }

        private void mainCostBtn_Click(object sender, EventArgs e)
        {
            setMainCostData();
            execROlogTabControl.SelectedIndex = 10;
        }

        private void createNewCostItemBtn_Click(object sender, EventArgs e)
        {
            if (newCostItemNameTxt.Text == "")
            {
                MessageBox.Show("Please fill main cost item name");
            }

            if(newCostItemCostTxt.Text == "")
            {
                newCostItemCostTxt.Text = "0";
            }

            else
            {
                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string queryString = "INSERT INTO rk_MainCostItems (Name,Cost,Comment,IDproj,MainCost) VALUES ('" + newCostItemNameTxt.Text + "'," + newCostItemCostTxt.Text + ",' " + newCostItemCommentTxt.Text + "', " + execProject.projectID + ",0)";
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }

                newCostItemNameTxt.Text = "";
                newCostItemCommentTxt.Text = "";
                newCostItemCostTxt.Text = "";
                setMainCostData();

            }
        }

        private void setMainCostData()
        {
            SqlConnection connection = new SqlConnection(sqlConnectionString);
            connection.Open();
            string SQL = "SELECT * FROM rk_MainCostItems WHERE IDproj = " + execProject.projectID + " AND MainCost = 1 ";
            dataAdapter = new SqlDataAdapter(SQL, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            mainCostItemsData.DataSource = dataTable;
            connection.Close();

            connection.Open();
            SQL = "SELECT * FROM rk_MainCostItems WHERE IDproj = " + execProject.projectID + " AND MainCost = 0 ";
            dataAdapter = new SqlDataAdapter(SQL, connection);
            dataTable = new DataTable();
            dataAdapter.Fill(dataTable);
            otherCostItemsData.DataSource = dataTable;
            connection.Close();
        }

        private void mainCostItemsData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int mainCostID = int.Parse(mainCostItemsData.Rows[e.RowIndex].Cells[0].Value.ToString());
                string name = mainCostItemsData.Rows[e.RowIndex].Cells[1].Value.ToString();
                int cost = int.Parse(mainCostItemsData.Rows[e.RowIndex].Cells[2].Value.ToString());
                string comment = mainCostItemsData.Rows[e.RowIndex].Cells[3].Value.ToString();

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string queryString = "UPDATE rk_MainCostItems set name ='" + name + "', cost =" + cost + ",comment ='" + comment + "' WHERE ID = " + mainCostID;
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Main Cost has to be a numeric value");
            }
            
        }

        private void otherCostItemsData_CellValueChanged(object sender, DataGridViewCellEventArgs e)
        {
            try
            {
                int mainCostID = int.Parse(otherCostItemsData.Rows[e.RowIndex].Cells[0].Value.ToString());
                string name = otherCostItemsData.Rows[e.RowIndex].Cells[1].Value.ToString();
                int cost = int.Parse(otherCostItemsData.Rows[e.RowIndex].Cells[2].Value.ToString());
                string comment = otherCostItemsData.Rows[e.RowIndex].Cells[3].Value.ToString();

                using (SqlConnection connection = new SqlConnection(sqlConnectionString))
                {
                    string queryString = "UPDATE rk_MainCostItems set name ='" + name + "', cost =" + cost + ",comment ='" + comment + "' WHERE ID = " + mainCostID;
                    SqlCommand command = new SqlCommand(queryString, connection);
                    connection.Open();
                    command.ExecuteNonQuery();
                    connection.Close();
                }
            }
            catch
            {
                MessageBox.Show("Main Cost has to be a numeric value");
            }
        }

        private void mainCostItemsData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
                MessageBox.Show("Cost value needs to be numeric");
        }

        private void otherCostItemsData_DataError(object sender, DataGridViewDataErrorEventArgs e)
        {
                MessageBox.Show("Cost value needs to be numeric");
        }
    }
}


