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

namespace WindowsFormsApp1
{
    public partial class executionForm : Form
    {
        private DataGridViewButtonColumn uninstallButtonColumn;

        private String projectName;
        private String projectOwnerID;
        private String projectID;
        private String loaID;
        private String projectManager;
        private String commercialPM;
        private String preparedBy;
        private String scope;
        private String typeFoundation;
        private String portOfPreAssembly;
        private String tocDate;
        private String segment;
        private String numberOfWTGs;
        private String typeOfWTGs;
        private String buCosts;
        private String buCurrency;
        private String buRate;
        private String ruCosts;
        private String ruCurrency;
        private String ruRate;
        private SqlConnectionStringBuilder connectionString;

        SqlDataAdapter daEntryCurr;
        DataTable dsEntryCurr;


        public object ProjectsData { get; private set; }

        public executionForm()
        {
            InitializeComponent();

            SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
            builder.DataSource = "riskdbsserver.database.windows.net";
            builder.UserID = "superuser@riskdbsserver";
            builder.Password = "Greenpear@1";
            builder.InitialCatalog = "[EW_Risk_Test]";
            connectionString = builder;

            uninstallButtonColumn = new DataGridViewButtonColumn();
            uninstallButtonColumn.Name = "Open";
            uninstallButtonColumn.Text = "Open";
            uninstallButtonColumn.UseColumnTextForButtonValue = true;


            if (projectsData.Columns["Open"] == null)
            {
                projectsData.Columns.Insert(0, uninstallButtonColumn);
            }
        }

        private void projectsButton_Click(object sender, EventArgs e)
        {
            //Setting panels visibility
            projectsPanel.Visible = true;
            portfolioPanel.Visible = false;
            createProjectPanel.Visible = false;
            tabController.SelectedIndex = 0;

            uninstallButtonColumn.Name = "Open";
            uninstallButtonColumn.Text = "Open";
            uninstallButtonColumn.UseColumnTextForButtonValue = true;

            if (projectsData.Columns["Open"] == null)
            {
                projectsData.Columns.Insert(0, uninstallButtonColumn);
            }
        }

        private void reportsButtons_Click(object sender, EventArgs e)
        {
            createProjectPanel.Visible = false;
            portfolioPanel.Visible = true;
            tabController.SelectedIndex = 1;
        }

        private void quitButton_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void createProjectButton_Click(object sender, EventArgs e)
        {
            if (createProjectPanel.Visible == false)
            {
                scopeComboBox.SelectedItem = null;
                projectOwnerComboBox.SelectedItem = null;
                foundationComboBox.SelectedItem = null;
                portComboBox.SelectedItem = null;
                segmentComboBox.SelectedItem = null;
                wtgTypeComboBox.SelectedItem = null;
                buCurComboBox.SelectedItem = null;
                ruCurComboBox.SelectedItem = null;
            }

            portfolioPanel.Visible = true;
            createProjectPanel.Visible = true;
            tabController.SelectedIndex = 2;

        }
        private void editButton_Click(object sender, EventArgs e)
        {
            if (this.nccButton.Visible == false)
            {
                this.entryCurButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.diCatButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.nccButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.projectOwnerButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.orgUnitButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.wtgTypeButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.ownerButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.usersButton.Visible = true;
                //System.Threading.Thread.Sleep(20);
                this.transfSalesProjButton.Visible = true;
            }
            else
            {
                this.transfSalesProjButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.usersButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.ownerButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.wtgTypeButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.orgUnitButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.projectOwnerButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.nccButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.diCatButton.Visible = false;
                System.Threading.Thread.Sleep(20);
                this.entryCurButton.Visible = false;
            }

        }
        private void userLabel_Click(object sender, EventArgs e)
        {
            if (this.adminPictureBox.Visible == true)
            {
                readPictureBox.Visible = true;
                adminPictureBox.Visible = false;
                writePictureBox.Visible = false;
                approvalPictureBox.Visible = false;
            }
            else if (this.readPictureBox.Visible == true)
            {
                readPictureBox.Visible = false;
                writePictureBox.Visible = true;
                approvalPictureBox.Visible = false;
                adminPictureBox.Visible = false;
            }
            else if (this.writePictureBox.Visible == true)
            {
                readPictureBox.Visible = false;
                writePictureBox.Visible = false;
                approvalPictureBox.Visible = true;
                adminPictureBox.Visible = false;
            }
            else if (this.approvalPictureBox.Visible == true)
            {
                readPictureBox.Visible = false;
                writePictureBox.Visible = false;
                approvalPictureBox.Visible = false;
                adminPictureBox.Visible = true;
            }
        }

        private void guideButton_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://www.google.com");
        }

        private void tableLayoutPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void entryCurButton_Click(object sender, EventArgs e)
        {

            SqlConnection connection = new SqlConnection(connectionString.ConnectionString);
            connection.Open();
            string SQL = "SELECT * FROM rk_CurrencyName ORDER BY Country";

            daEntryCurr = new SqlDataAdapter(SQL, connection);
            dsEntryCurr = new DataTable();
            daEntryCurr.Fill(dsEntryCurr);
            entryCurData.DataSource = dsEntryCurr;
            connection.Close();

            tabController.SelectedIndex = 3;
        }




        private void diCatButton_Click(object sender, EventArgs e)
        {
            tabController.SelectedIndex = 4;
        }

        private void nccButton_Click(object sender, EventArgs e)
        {
            tabController.SelectedIndex = 5;
        }

        private void projectOwnerButton_Click(object sender, EventArgs e)
        {
            tabController.SelectedIndex = 6;
        }

        private void orgUnitButton_Click(object sender, EventArgs e)
        {
            tabController.SelectedIndex = 7;
        }

        private void wtgTypeButton_Click(object sender, EventArgs e)
        {
            tabController.SelectedIndex = 8;
        }

        private void ownerButton_Click(object sender, EventArgs e)
        {
            tabController.SelectedIndex = 9;
        }

        private void usersButton_Click(object sender, EventArgs e)
        {
            tabController.SelectedIndex = 10;
        }

        private void transfSalesProjButton_Click(object sender, EventArgs e)
        {
            tabController.SelectedIndex = 11;
        }

        private void executionForm_Load(object sender, EventArgs e)
        {
            // TODO: Tento řádek načte data do tabulky 'dataSet1.rk_UsersList_view'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.rk_UsersList_viewTableAdapter.Fill(this.dataSet1.rk_UsersList_view);
            // TODO: Tento řádek načte data do tabulky 'dataSet1.rk_users'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.rk_usersTableAdapter.Fill(this.dataSet1.rk_users);
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
            // TODO: Tento řádek načte data do tabulky 'dataSet1.new_project_view'. Můžete jej přesunout nebo jej odstranit podle potřeby.
            this.new_project_viewTableAdapter.Fill(this.dataSet1.new_project_view);

        }

        private void insertProjectButton_Click(object sender, EventArgs e)
        {
            String missingCompulsory = "Missing values:\n\n";
            DateTime oDate;
            bool isMissing = false;

            if (projectNameTextBox.Text == "")
            {
                missingCompulsory = missingCompulsory + "Project Name\n";
                isMissing = true;
            }
            else projectName = projectNameTextBox.Text;

            if (projectOwnerComboBox.SelectedValue == null)
            {
                missingCompulsory += "Project Owner\n";
                isMissing = true;
            }
            else projectOwnerID = projectOwnerComboBox.SelectedValue.ToString();

            if (preparedByTextBox.Text == "")
            {
                missingCompulsory += "Prepared By\n";
                isMissing = true;
            }
            else preparedBy = preparedByTextBox.Text;

            if (segmentComboBox.SelectedValue == null)
            {
                missingCompulsory += "Segment\n";
                isMissing = true;
            }
            else segment = segmentComboBox.SelectedValue.ToString();

            if (buCostsTextBox.Text == "")
            {
                missingCompulsory += "Project Costs BU\n";
                isMissing = true;
            }
            else buCosts = buCostsTextBox.Text;

            if (buCurComboBox.SelectedValue == null)
            {
                missingCompulsory += "BU Currency\n";
                isMissing = true;
            }
            else buCurrency = buCurComboBox.SelectedValue.ToString();

            if (ruCostsTextBox.Text == "")
            {
                missingCompulsory += "Project Costs RU\n";
                isMissing = true;
            }
            else ruCosts = ruCostsTextBox.Text;

            if (ruCurComboBox.SelectedValue == null)
            {
                missingCompulsory += "RU Currency\n";
                isMissing = true;
            }
            else ruCurrency = ruCurComboBox.SelectedValue.ToString();

            if (buRateTextBox.Text == "")
            {
                missingCompulsory += "BU Rate\n";
                isMissing = true;
            }
            else buRate = buRateTextBox.Text;

            if (ruRateTextBox.Text == "")
            {
                missingCompulsory += "RU Rate\n";
                isMissing = true;
            }
            else ruRate = ruRateTextBox.Text;

            if (isMissing == true) MessageBox.Show(missingCompulsory, "Data Missing!", MessageBoxButtons.OK);
            else
            {
                projectID = projectIDTextBox.Text;
                if (LoaIDTextBox.Text == "") loaID = "99";
                else loaID = LoaIDTextBox.Text;
                projectManager = PMTextBox.Text;
                commercialPM = CPMTextBox.Text;
                scope = scopeComboBox.SelectedValue.ToString();
                typeFoundation = foundationComboBox.SelectedValue.ToString();
                portOfPreAssembly = portComboBox.SelectedValue.ToString();
                numberOfWTGs = wtgNoTextBox.Text;
                typeOfWTGs = wtgTypeComboBox.SelectedValue.ToString();

                //Converting return of datepicker to format suitable for database
                oDate = Convert.ToDateTime(tocTextBox.Text);
                tocDate = oDate.ToString("yyyy-MM-dd");

                SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder();
                builder.DataSource = "riskdbsserver.database.windows.net";
                builder.UserID = "superuser@riskdbsserver";
                builder.Password = "Greenpear@1";
                builder.InitialCatalog = "[EW_Risk_Test]";

                string query = "INSERT INTO rk_project(Pname, IDUser, sap, loa, pm, cpm, prepby, scopeID, FoundationTypeID, HarbourID, toc, segmentID, noWTGs,WTGType, BUcontract, BUIDcur, BUrate, RUcontract, RUIDcur, RUrate) VALUES ('" + projectName + "'," + projectOwnerID + "," + projectID + "," + loaID + ",'" + projectManager + "', '" + commercialPM + "', '" + preparedBy + "'," + scope + "," + typeFoundation + "," + portOfPreAssembly + ", '" + tocDate + "'," + segment + "," + numberOfWTGs + "," + typeOfWTGs + "," + buCosts + "," + buCurrency + "," + buRate + "," + ruCosts + "," + ruCurrency + "," + ruRate + ")";


                using (SqlConnection connection = new SqlConnection(builder.ConnectionString))
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    connection.Open();
                    Console.WriteLine(query);
                    command.ExecuteNonQuery();
                    connection.Close();
                }


                MessageBox.Show("Project Created", "Data saved", MessageBoxButtons.OK);
            }



        }

        private void foundationComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }


        private void projectsData_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string projectName = "";

            // Ignore clicks that are not in our 
            if (e.ColumnIndex == projectsData.Columns["Open"].Index && e.RowIndex >= 0)
            {
                ExecRolog execROlogForm = new ExecRolog();
                execROlogForm.Show();

                projectName = projectsData.Rows[e.RowIndex].Cells[1].Value.ToString();
                execROlogForm.setLocationLabel(projectName.ToUpper());
            }
        }

        private void buEurLabel_Click(object sender, EventArgs e)
        {

        }

        private void entryCurrUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable changes = ((DataTable)entryCurData.DataSource).GetChanges();
                if (changes != null)
                {
                    daEntryCurr = new SqlDataAdapter("SELECT * FROM rk_CurrencyName ORDER BY Country", connectionString.ConnectionString);
                    SqlCommandBuilder mcb = new SqlCommandBuilder(daEntryCurr);
                    daEntryCurr.UpdateCommand = mcb.GetUpdateCommand();
                    daEntryCurr.Update(changes);
                    ((DataTable)entryCurData.DataSource).AcceptChanges();
                    MessageBox.Show("List Updated");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void entryCurrInsertButton_Click(object sender, EventArgs e)
        {
            bool continueBool = true;

            try
            {
                if (this.codeEntryTextBox.Text.Length > 3)
                {
                    MessageBox.Show("Entry Currency Code cannot have more then 3 characters", "Data saved", MessageBoxButtons.OK);
                    continueBool = false;
                }
                if (this.codeEntryTextBox.Text.Length == 0 || this.countryEntryTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Please fill Country and Code Fields", "Data saved", MessageBoxButtons.OK);
                    continueBool = false;
                }

                if(continueBool == true) { 
                string query = "INSERT INTO rk_CurrencyName(Country,Code) VALUES ('" + this.countryEntryTextBox.Text + "','" + this.codeEntryTextBox.Text + "')";

                        using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            connection.Open();
                            Console.WriteLine(query);
                            command.ExecuteNonQuery();
                            string SQL = "SELECT * FROM rk_CurrencyName ORDER BY Country";
                            daEntryCurr = new SqlDataAdapter(SQL, connection);
                            dsEntryCurr = new DataTable();
                            daEntryCurr.Fill(dsEntryCurr);
                            entryCurData.DataSource = dsEntryCurr;
                            connection.Close();
                        }
                        this.countryEntryTextBox.Text = "";
                        this.codeEntryTextBox.Text = "";
                        MessageBox.Show("Entry Currency Saved", "Data saved", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }



        }
    }
}

