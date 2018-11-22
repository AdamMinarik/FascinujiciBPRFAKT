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
        
        // Data Adapters
        private SqlDataAdapter daEntryCurr;
        private SqlDataAdapter daDIcat;
        private SqlDataAdapter daNCC;
        private SqlDataAdapter daProjOwner;
        private SqlDataAdapter daOrgUnit;
        private SqlDataAdapter daWTG;
        private SqlDataAdapter daOwner;
        private SqlDataAdapter daUser;

        // Data Tables
        private DataTable dsEntryCurr;
        private DataTable dsDIcat;
        private DataTable dsNCC;
        private DataTable dsProjOwner;
        private DataTable dsOrgUnit;
        private DataTable dsWTG;
        private DataTable dsOwner;
        private DataTable dsUser;
        

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
            System.Diagnostics.Process.Start("https://screenmessage.com/mehehehe");
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
            SqlConnection connection = new SqlConnection(connectionString.ConnectionString);
            connection.Open();
            string SQL = "SELECT * FROM rk_DIcat";

            daDIcat = new SqlDataAdapter(SQL, connection);
            dsDIcat = new DataTable();
            daDIcat.Fill(dsDIcat);
            DIcatData.DataSource = dsDIcat;
            connection.Close();

            tabController.SelectedIndex = 4;
        }

        private void nccButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString.ConnectionString);
            connection.Open();
            string SQL = "SELECT * FROM rk_NCC WHERE status = 1";

            daNCC = new SqlDataAdapter(SQL, connection);
            dsNCC = new DataTable();
            daNCC.Fill(dsNCC);
            nccData.DataSource = dsNCC;
            connection.Close();

            tabController.SelectedIndex = 5;
        }

        private void projectOwnerButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString.ConnectionString);
            connection.Open();
            string SQL = "SELECT pname,rk_users.FirstName + ' ' + rk_users.LastName as FullName FROM rk_Project LEFT JOIN rk_users ON rk_Users.ID = rk_Project.IDuser order by Pname";

            daProjOwner = new SqlDataAdapter(SQL, connection);
            dsProjOwner = new DataTable();
            daProjOwner.Fill(dsProjOwner);
            projOwnerData.DataSource = dsProjOwner;
            connection.Close();


            connection.Open();

            SQL = "SELECT ID,pname FROM rk_Project order by Pname";
            daProjOwner = new SqlDataAdapter(SQL, connection);
            dsProjOwner = new DataTable();
            daProjOwner.Fill(dsProjOwner);
            connection.Close();
   
            this.projNameCombo.DisplayMember = "pname";
            this.projNameCombo.ValueMember = "id";
            this.projNameCombo.DataSource = dsProjOwner;



            SQL = "SELECT ID,FirstName + ' ' + LastName as FullName FROM rk_Users order by LastName";
            daProjOwner = new SqlDataAdapter(SQL, connection);
            dsProjOwner = new DataTable();
            daProjOwner.Fill(dsProjOwner);
            connection.Close();

            this.projOwnerCombo.DisplayMember = "FullName";
            this.projOwnerCombo.ValueMember = "id";
            this.projOwnerCombo.DataSource = dsProjOwner;


            tabController.SelectedIndex = 6;
        }

        private void orgUnitButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString.ConnectionString);
            connection.Open();
            string SQL = "SELECT * FROM OriginatingList WHERE status = 1 ORDER BY Name";

            daOrgUnit = new SqlDataAdapter(SQL, connection);
            dsOrgUnit = new DataTable();
            daOrgUnit.Fill(dsOrgUnit);
            orgUnitData.DataSource = dsOrgUnit;
            connection.Close();
            tabController.SelectedIndex = 7;
        }

        private void wtgTypeButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString.ConnectionString);
            connection.Open();
            string SQL = "SELECT * FROM WTGtype WHERE IDstatus = 1";

            daWTG = new SqlDataAdapter(SQL, connection);
            dsWTG = new DataTable();
            daWTG.Fill(dsWTG);
            wtgData.DataSource = dsWTG;
            connection.Close();
            tabController.SelectedIndex = 8;
        }
        
        private void ownerButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString.ConnectionString);
            connection.Open();
            string SQL = "SELECT* FROM listofOwners WHERE status = 1 ORDER BY name; ";

            daOwner = new SqlDataAdapter(SQL, connection);
            dsOwner = new DataTable();
            daOwner.Fill(dsOwner);
            ownerData.DataSource = dsOwner;
            connection.Close();
            tabController.SelectedIndex = 9;
        }

        
        private void usersButton_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(connectionString.ConnectionString);
            connection.Open();
            string SQL = "SELECT* FROM rk_users ORDER BY Lastname, FirstName;";
            daUser = new SqlDataAdapter(SQL, connection);
            dsUser = new DataTable();
            daUser.Fill(dsUser);
            userData.DataSource = dsUser;


            SQL = "SELECT * FROM rk_Rolelist_view;";
            daUser = new SqlDataAdapter(SQL, connection);
            dsUser = new DataTable();
            daUser.Fill(dsUser);

            connection.Close();

            this.userPermCombo.DisplayMember = "roleName";
            this.userPermCombo.ValueMember = "ID";
            this.userPermCombo.DataSource = dsUser;

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
                    MessageBox.Show("Entry Currency Code cannot have more then 3 characters", "Data Not saved", MessageBoxButtons.OK);
                    continueBool = false;
                }
                if (this.codeEntryTextBox.Text.Length == 0 || this.countryEntryTextBox.Text.Length == 0)
                {
                    MessageBox.Show("Please fill Country and Code Fields", "Data Not saved", MessageBoxButtons.OK);
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

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void DIcatUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable changes = ((DataTable)DIcatData.DataSource).GetChanges();
                if (changes != null)
                {
                    daDIcat = new SqlDataAdapter("SELECT * FROM rk_DIcat", connectionString.ConnectionString);
                    SqlCommandBuilder mcb = new SqlCommandBuilder(daDIcat);
                    daDIcat.UpdateCommand = mcb.GetUpdateCommand();
                    daDIcat.Update(changes);
                    ((DataTable)DIcatData.DataSource).AcceptChanges();
                    MessageBox.Show("List Updated");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void DIcatInsertBtn_Click(object sender, EventArgs e)
        {
            bool continueBool = true;

            try
            {
              
                if (this.DIcatText.Text.Length == 0)
                {
                    MessageBox.Show("Please fill name field", "Data Not saved", MessageBoxButtons.OK);
                    continueBool = false;
                }

                if (continueBool == true)
                {
                    string query = "INSERT INTO rk_DIcat(ID,DIname) VALUES ((SELECT MAX(ID) FROM rk_DIcat) + 1,'" + this.DIcatText.Text + "')";

                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        Console.WriteLine(query);
                        command.ExecuteNonQuery();
                        string SQL = "SELECT * FROM rk_DIcat";
                        daDIcat = new SqlDataAdapter(SQL, connection);
                        dsDIcat = new DataTable();
                        daDIcat.Fill(dsDIcat);
                        DIcatData.DataSource = dsDIcat;
                        connection.Close();
                    }
                    this.DIcatText.Text = "";
                    MessageBox.Show("DI category Saved", "Data saved", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nccUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable changes = ((DataTable)nccData.DataSource).GetChanges();
                if (changes != null)
                {
                    daNCC = new SqlDataAdapter("SELECT * FROM rk_NCC WHERE status = 1; ", connectionString.ConnectionString);
                    SqlCommandBuilder mcb = new SqlCommandBuilder(daNCC);
                    daNCC.UpdateCommand = mcb.GetUpdateCommand();
                    daNCC.Update(changes);
                    ((DataTable)nccData.DataSource).AcceptChanges();
                    MessageBox.Show("List Updated");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void nccInsertBtn_Click(object sender, EventArgs e)
        {
            bool continueBool = true;

            try
            {

                if (this.nccText.Text.Length == 0)
                {
                    MessageBox.Show("Please fill name field", "Data Not saved", MessageBoxButtons.OK);
                    continueBool = false;
                }

                if (continueBool == true)
                {
                    string query = "INSERT INTO rk_NCC(status,name) VALUES (1,'" + this.nccText.Text + "')";

                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        Console.WriteLine(query);
                        command.ExecuteNonQuery();
                        string SQL = "SELECT * FROM rk_NCC WHERE status = 1";
                        daNCC = new SqlDataAdapter(SQL, connection);
                        dsNCC = new DataTable();
                        daNCC.Fill(dsNCC);
                        nccData.DataSource = dsNCC;
                        connection.Close();
                    }
                    this.nccText.Text = "";
                    MessageBox.Show("NCC Saved", "Data saved", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void projOwnerUpdateBtn_Click(object sender, EventArgs e)
        {
            bool continueBool = true;

            try
            {

                if (continueBool == true)
                {
                    string query = "UPDATE rk_Project SET IDuser =" + projOwnerCombo.SelectedValue + "WHERE ID = " + projNameCombo.SelectedValue;
                    
                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        Console.WriteLine(query);
                        command.ExecuteNonQuery();
                        string SQL = "SELECT pname,rk_users.FirstName + ' ' + rk_users.LastName as FullName FROM rk_Project LEFT JOIN rk_users ON rk_Users.ID = rk_Project.IDuser order by Pname";

                        daProjOwner = new SqlDataAdapter(SQL, connection);
                        dsProjOwner = new DataTable();
                        daProjOwner.Fill(dsProjOwner);
                        projOwnerData.DataSource = dsProjOwner;
                        connection.Close();
                    }
                    this.DIcatText.Text = "";
                    MessageBox.Show("Project Owner Updated", "Data saved", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void origUnitInsertBtn_Click(object sender, EventArgs e)
        {
            bool continueBool = true;

            try
            {

                if (this.orgUnitTxt.Text.Length == 0)
                {
                    MessageBox.Show("Please fill name field", "Data Not saved", MessageBoxButtons.OK);
                    continueBool = false;
                }

                if (continueBool == true)
                {
                    string query = "INSERT INTO OriginatingList(status,name) VALUES (1,'" + this.orgUnitTxt.Text + "')";

                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        Console.WriteLine(query);
                        command.ExecuteNonQuery();
                        string SQL = "SELECT * FROM OriginatingList WHERE status = 1 order by Name";
                        daOrgUnit = new SqlDataAdapter(SQL, connection);
                        dsOrgUnit = new DataTable();
                        daOrgUnit.Fill(dsOrgUnit);
                        orgUnitData.DataSource = dsOrgUnit;
                        connection.Close();
                    }
                    this.orgUnitTxt.Text = "";
                    MessageBox.Show("Originating Unit Saved", "Data saved", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void orgUnitUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable changes = ((DataTable)orgUnitData.DataSource).GetChanges();
                if (changes != null)
                {
                    daOrgUnit = new SqlDataAdapter("SELECT * FROM OriginatingList WHERE status = 1 order by Name; ", connectionString.ConnectionString);
                    SqlCommandBuilder mcb = new SqlCommandBuilder(daOrgUnit);
                    daOrgUnit.UpdateCommand = mcb.GetUpdateCommand();
                    daOrgUnit.Update(changes);
                    ((DataTable)orgUnitData.DataSource).AcceptChanges();
                    MessageBox.Show("List Updated");
                }
        }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
}

        private void wtgUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable changes = ((DataTable)wtgData.DataSource).GetChanges();
                if (changes != null)
                {
                    daWTG = new SqlDataAdapter("SELECT * FROM WTGtype WHERE IDstatus = 1;", connectionString.ConnectionString);
                    SqlCommandBuilder mcb = new SqlCommandBuilder(daWTG);
                    daWTG.UpdateCommand = mcb.GetUpdateCommand();
                    daWTG.Update(changes);
                    ((DataTable)wtgData.DataSource).AcceptChanges();
                    MessageBox.Show("List Updated");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void wtgInsertBtn_Click(object sender, EventArgs e)
        {
            bool continueBool = true;

            try
            {

                if (this.wtgTxt.Text.Length == 0)
                {
                    MessageBox.Show("Please fill name field", "Data Not saved", MessageBoxButtons.OK);
                    continueBool = false;
                }

                if (continueBool == true)
                {
                    string query = "INSERT INTO WTGtype(IDstatus,name) VALUES (1,'" + this.wtgTxt.Text + "')";

                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        Console.WriteLine(query);
                        command.ExecuteNonQuery();
                        string SQL = "SELECT * FROM WTGtype WHERE IDstatus = 1; ";
                        daWTG = new SqlDataAdapter(SQL, connection);
                        dsWTG = new DataTable();
                        daWTG.Fill(dsWTG);
                        wtgData.DataSource = dsWTG;
                        connection.Close();
                    }
                    this.wtgTxt.Text = "";
                    MessageBox.Show("WTG Saved", "Data saved", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ownerInsertBtn_Click(object sender, EventArgs e)
        {
            bool continueBool = true;

            try
            {
                if (this.ownerCodeTxt.Text.Length > 5)
                {
                    MessageBox.Show("Owner Code cannot have more then 5 characters", "Data Not saved", MessageBoxButtons.OK);
                    continueBool = false;
                }
                if (this.ownerCodeTxt.Text.Length == 0 || this.ownerNameTxt.Text.Length == 0)
                {
                    MessageBox.Show("Please fill Owner Name and Owner Code Fields", "Data Not saved", MessageBoxButtons.OK);
                    continueBool = false;
                }

                if (continueBool == true)
                {
                    string query = "INSERT INTO listofOwners(Name,Code) VALUES ('" + this.ownerNameTxt.Text + "','" + this.ownerCodeTxt.Text + "')";

                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        Console.WriteLine(query);
                        command.ExecuteNonQuery();
                        string SQL = "SELECT * FROM listofOwners WHERE status = 1 ORDER BY name; ";
                        daOwner = new SqlDataAdapter(SQL, connection);
                        dsOwner = new DataTable();
                        daOwner.Fill(dsOwner);
                        ownerData.DataSource = dsOwner;
                        connection.Close();
                    }
                    this.ownerCodeTxt.Text = "";
                    this.ownerNameTxt.Text = "";
                    MessageBox.Show("Owner Saved", "Data saved", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void ownerUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable changes = ((DataTable)ownerData.DataSource).GetChanges();
                if (changes != null)
                {
                    daOwner = new SqlDataAdapter("SELECT * FROM listofOwners WHERE status = 1 ORDER BY name; ", connectionString.ConnectionString);
                    SqlCommandBuilder mcb = new SqlCommandBuilder(daOwner);
                    daOwner.UpdateCommand = mcb.GetUpdateCommand();
                    daOwner.Update(changes);
                    ((DataTable)ownerData.DataSource).AcceptChanges();
                    MessageBox.Show("List Updated");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void userUpdateBtn_Click(object sender, EventArgs e)
        {
            try
            {
                DataTable changes = ((DataTable)userData.DataSource).GetChanges();
                if (changes != null)
                {
                    daUser = new SqlDataAdapter("SELECT * FROM rk_users ORDER BY Lastname, FirstName;", connectionString.ConnectionString);
                    SqlCommandBuilder mcb = new SqlCommandBuilder(daUser);
                    daUser.UpdateCommand = mcb.GetUpdateCommand();
                    daUser.Update(changes);
                    ((DataTable)userData.DataSource).AcceptChanges();
                    MessageBox.Show("List Updated");
                }
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void userInsertBtn_Click(object sender, EventArgs e)
        {
            bool continueBool = true;

            try
            {
          
                if (continueBool == true)
                {
                    string query = "INSERT INTO rk_users (Username,FirstName,MiddleName,LastName,IDroles,GID,email) VALUES ('" + this.userNameTxt.Text + "','" + this.userFirstNameTxt.Text + "','" + this.userMidNameTxt.Text + "','" + this.userLastNameTxt.Text + "'," + this.userPermCombo.SelectedValue + ",'" + this.userGIDTxt.Text + "','" + this.userEmailTxt.Text + "')";
                    MessageBox.Show(query);
                    using (SqlConnection connection = new SqlConnection(connectionString.ConnectionString))
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        connection.Open();
                        Console.WriteLine(query);
                        command.ExecuteNonQuery();
                        string SQL = "SELECT * FROM rk_users ORDER BY Lastname, FirstName;";
                        daUser = new SqlDataAdapter(SQL, connection);
                        dsUser = new DataTable();
                        daUser.Fill(dsUser);
                        userData.DataSource = dsUser;
                        connection.Close();
                    }
                    this.userNameTxt.Text = "";
                    this.userFirstNameTxt.Text = "";
                    this.userMidNameTxt.Text = "";
                    this.userLastNameTxt.Text = "";
                    this.userGIDTxt.Text = "";
                    this.userEmailTxt.Text = "";
                    this.userPermCombo.SelectedItem = 0;

                    MessageBox.Show("Owner Saved", "Data saved", MessageBoxButtons.OK);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void readPictureBox_Click(object sender, EventArgs e)
        {

        }

        private void portfolioRepGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void projectsData_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

       private void ruCostsTextBox_TextChanged(object sender, EventArgs e)
        {
            double ruCost;
            double buCost;
            if (ruCostsTextBox.Text == null || ruCostsTextBox.Text == "")
            {
                ruCost = 0;
            }
            else ruCost = Convert.ToDouble(ruCostsTextBox.Text);
            if (buCostsTextBox.Text == null || buCostsTextBox.Text == "")
            {
                buCost = 0;
            }
            else buCost = Convert.ToDouble(buCostsTextBox.Text);

            double totalCost = buCost + ruCost;
            totalProjectCostsTextBox.Text = Convert.ToString(totalCost);
        }

        private void buCostsTextBox_TextChanged(object sender, EventArgs e)
        {
            double ruCost;
            double buCost;
            if (ruCostsTextBox.Text == null || ruCostsTextBox.Text == "")
            {
                ruCost = 0;
            }
            else ruCost = Convert.ToDouble(ruCostsTextBox.Text);
            if (buCostsTextBox.Text == null || buCostsTextBox.Text == "")
            {
                buCost = 0;
            }
            else buCost = Convert.ToDouble(buCostsTextBox.Text);

            double totalCost = buCost + ruCost;
            totalProjectCostsTextBox.Text = Convert.ToString(totalCost);
        }

        private void buCostsTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Back))
            {
                string text = buCostsTextBox.Text.Replace(",", "");
                if (text.Length % 3 == 0)
                {
                    buCostsTextBox.Text += ",";
                    buCostsTextBox.SelectionStart = buCostsTextBox.Text.Length;
                }
            }
        }

        private void ruCostsTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Back))
            {
                string text = ruCostsTextBox.Text.Replace(",", "");
                if (text.Length % 3 == 0)
                {
                    ruCostsTextBox.Text += ",";
                    ruCostsTextBox.SelectionStart = ruCostsTextBox.Text.Length;
                }
            }
        }

        private void totalProjectCostsTextBox_KeyUp(object sender, KeyEventArgs e)
        {
            if (!(e.KeyCode == Keys.Back))
            {
                string text = totalProjectCostsTextBox.Text.Replace(",", "");
                if (text.Length % 3 == 0)
                {
                    totalProjectCostsTextBox.Text += ",";
                    totalProjectCostsTextBox.SelectionStart = totalProjectCostsTextBox.Text.Length;
                }
            }
        }

        private void buCurComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}

