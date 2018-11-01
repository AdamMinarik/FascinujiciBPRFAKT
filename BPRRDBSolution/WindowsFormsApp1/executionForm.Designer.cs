using System;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    partial class executionForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(executionForm));
            this.locationPanel = new System.Windows.Forms.Panel();
            this.readPictureBox = new System.Windows.Forms.PictureBox();
            this.approvalPictureBox = new System.Windows.Forms.PictureBox();
            this.writePictureBox = new System.Windows.Forms.PictureBox();
            this.adminPictureBox = new System.Windows.Forms.PictureBox();
            this.userLabel = new System.Windows.Forms.Label();
            this.locationLabel = new System.Windows.Forms.Label();
            this.buttonPanel = new System.Windows.Forms.Panel();
            this.transfSalesProjButton = new System.Windows.Forms.Button();
            this.usersButton = new System.Windows.Forms.Button();
            this.ownerButton = new System.Windows.Forms.Button();
            this.wtgTypeButton = new System.Windows.Forms.Button();
            this.orgUnitButton = new System.Windows.Forms.Button();
            this.projectOwnerButton = new System.Windows.Forms.Button();
            this.nccButton = new System.Windows.Forms.Button();
            this.diCatButton = new System.Windows.Forms.Button();
            this.entryCurButton = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.guideButton = new System.Windows.Forms.Button();
            this.settingsButton = new System.Windows.Forms.Button();
            this.editButton = new System.Windows.Forms.Button();
            this.createProjectButton = new System.Windows.Forms.Button();
            this.reportsButtons = new System.Windows.Forms.Button();
            this.projectsButton = new System.Windows.Forms.Button();
            this.projectsPanel = new System.Windows.Forms.Panel();
            this.projectsData = new System.Windows.Forms.DataGridView();
            this.pnameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.segmentIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.scopeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.wtgDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.owneDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.sapDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDuserDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.iDProjectTypeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.newprojectviewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.dataSet1 = new WindowsFormsApp1.DataSet1();
            this.portfolioPanel = new System.Windows.Forms.Panel();
            this.tableauButton = new System.Windows.Forms.Button();
            this.riskContingencyButton = new System.Windows.Forms.Button();
            this.rologButton = new System.Windows.Forms.Button();
            this.top20Button = new System.Windows.Forms.Button();
            this.portfolioRepGridView = new System.Windows.Forms.DataGridView();
            this.createProjectPanel = new System.Windows.Forms.Panel();
            this.newProjectTableLayout = new System.Windows.Forms.TableLayoutPanel();
            this.projectNameTextBox = new System.Windows.Forms.TextBox();
            this.projectIDLabel = new System.Windows.Forms.Label();
            this.projectIDTextBox = new System.Windows.Forms.TextBox();
            this.pmLabel = new System.Windows.Forms.Label();
            this.wtgNoTextBox = new System.Windows.Forms.TextBox();
            this.PMTextBox = new System.Windows.Forms.TextBox();
            this.cpmLabel = new System.Windows.Forms.Label();
            this.CPMTextBox = new System.Windows.Forms.TextBox();
            this.wtgNoLabel = new System.Windows.Forms.Label();
            this.preparedByLabel = new System.Windows.Forms.Label();
            this.preparedByTextBox = new System.Windows.Forms.TextBox();
            this.TOCLabel = new System.Windows.Forms.Label();
            this.totalProjectCostsTextBox = new System.Windows.Forms.TextBox();
            this.totalCostsLabel = new System.Windows.Forms.Label();
            this.ruCostsTextBox = new System.Windows.Forms.TextBox();
            this.RUcostsLabel = new System.Windows.Forms.Label();
            this.buCostsTextBox = new System.Windows.Forms.TextBox();
            this.BUcostsLabel = new System.Windows.Forms.Label();
            this.BUCurLabel = new System.Windows.Forms.Label();
            this.buCurComboBox = new System.Windows.Forms.ComboBox();
            this.rkCurrencyNameBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.ruCurComboBox = new System.Windows.Forms.ComboBox();
            this.RUcurLabel = new System.Windows.Forms.Label();
            this.ruEurLabel = new System.Windows.Forms.Label();
            this.buEurLabel = new System.Windows.Forms.Label();
            this.ruRateTextBox = new System.Windows.Forms.TextBox();
            this.buRateTextBox = new System.Windows.Forms.TextBox();
            this.projectNameLabel = new System.Windows.Forms.Label();
            this.foundationLabel = new System.Windows.Forms.Label();
            this.preassemblyLabel = new System.Windows.Forms.Label();
            this.portComboBox = new System.Windows.Forms.ComboBox();
            this.rkPreAssemblyHarbourBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.foundationComboBox = new System.Windows.Forms.ComboBox();
            this.rkFoundationTypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.segmentLabel = new System.Windows.Forms.Label();
            this.scopeLabel = new System.Windows.Forms.Label();
            this.segmentComboBox = new System.Windows.Forms.ComboBox();
            this.rkSegmentBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.scopeComboBox = new System.Windows.Forms.ComboBox();
            this.rkscopeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.wtgTypeLabel = new System.Windows.Forms.Label();
            this.wtgTypeComboBox = new System.Windows.Forms.ComboBox();
            this.wTGtypeBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.LoAIDLabel = new System.Windows.Forms.Label();
            this.LoaIDTextBox = new System.Windows.Forms.TextBox();
            this.projectSpecificDataLabel = new System.Windows.Forms.Label();
            this.projectPersonalDataLabel = new System.Windows.Forms.Label();
            this.projectOrderDataLabel = new System.Windows.Forms.Label();
            this.projectCostsLabel = new System.Windows.Forms.Label();
            this.scopeLocationLabel = new System.Windows.Forms.Label();
            this.insertProjectButton = new System.Windows.Forms.Button();
            this.projectOwnerLabel = new System.Windows.Forms.Label();
            this.projectOwnerComboBox = new System.Windows.Forms.ComboBox();
            this.rkUsersListviewBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.tocTextBox = new System.Windows.Forms.DateTimePicker();
            this.dataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.new_project_viewTableAdapter = new WindowsFormsApp1.DataSet1TableAdapters.new_project_viewTableAdapter();
            this.rk_scopeTableAdapter = new WindowsFormsApp1.DataSet1TableAdapters.rk_scopeTableAdapter();
            this.rk_FoundationTypeTableAdapter = new WindowsFormsApp1.DataSet1TableAdapters.rk_FoundationTypeTableAdapter();
            this.rk_PreAssemblyHarbourTableAdapter = new WindowsFormsApp1.DataSet1TableAdapters.rk_PreAssemblyHarbourTableAdapter();
            this.rk_SegmentTableAdapter = new WindowsFormsApp1.DataSet1TableAdapters.rk_SegmentTableAdapter();
            this.wTGtypeTableAdapter = new WindowsFormsApp1.DataSet1TableAdapters.WTGtypeTableAdapter();
            this.rk_CurrencyNameTableAdapter = new WindowsFormsApp1.DataSet1TableAdapters.rk_CurrencyNameTableAdapter();
            this.rkusersBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rk_usersTableAdapter = new WindowsFormsApp1.DataSet1TableAdapters.rk_usersTableAdapter();
            this.rkUsersListviewBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.rk_UsersList_viewTableAdapter = new WindowsFormsApp1.DataSet1TableAdapters.rk_UsersList_viewTableAdapter();
            this.dataSet11 = new WindowsFormsApp1.DataSet1();
            this.tabController = new System.Windows.Forms.TabControl();
            this.projectDataTab = new System.Windows.Forms.TabPage();
            this.portfolioReportsTab = new System.Windows.Forms.TabPage();
            this.createProjectTab = new System.Windows.Forms.TabPage();
            this.entryCurTab = new System.Windows.Forms.TabPage();
            this.panel1 = new System.Windows.Forms.Panel();
            this.entryCurrInsertButton = new System.Windows.Forms.Button();
            this.codeEntryTextBox = new System.Windows.Forms.TextBox();
            this.countryEntryTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.entryCurList = new System.Windows.Forms.Panel();
            this.entryCurrUpdateBtn = new System.Windows.Forms.Button();
            this.entryCurData = new System.Windows.Forms.DataGridView();
            this.diCatTab = new System.Windows.Forms.TabPage();
            this.nccTab = new System.Windows.Forms.TabPage();
            this.projectOwnershipTab = new System.Windows.Forms.TabPage();
            this.orgUnitTab = new System.Windows.Forms.TabPage();
            this.wtgTypeTab = new System.Windows.Forms.TabPage();
            this.ownerTab = new System.Windows.Forms.TabPage();
            this.usersTab = new System.Windows.Forms.TabPage();
            this.transfSalesProjTab = new System.Windows.Forms.TabPage();
            this.rkCurrencyNameBindingSource1 = new System.Windows.Forms.BindingSource(this.components);
            this.locationPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.readPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.approvalPictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.writePictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminPictureBox)).BeginInit();
            this.buttonPanel.SuspendLayout();
            this.projectsPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.projectsData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.newprojectviewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).BeginInit();
            this.portfolioPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.portfolioRepGridView)).BeginInit();
            this.createProjectPanel.SuspendLayout();
            this.newProjectTableLayout.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rkCurrencyNameBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkPreAssemblyHarbourBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkFoundationTypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkSegmentBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkscopeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.wTGtypeBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkUsersListviewBindingSource1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkusersBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkUsersListviewBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).BeginInit();
            this.tabController.SuspendLayout();
            this.projectDataTab.SuspendLayout();
            this.portfolioReportsTab.SuspendLayout();
            this.createProjectTab.SuspendLayout();
            this.entryCurTab.SuspendLayout();
            this.panel1.SuspendLayout();
            this.entryCurList.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.entryCurData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkCurrencyNameBindingSource1)).BeginInit();
            this.SuspendLayout();
            // 
            // locationPanel
            // 
            this.locationPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(80)))), ((int)(((byte)(64)))), ((int)(((byte)(77)))));
            this.locationPanel.Controls.Add(this.readPictureBox);
            this.locationPanel.Controls.Add(this.approvalPictureBox);
            this.locationPanel.Controls.Add(this.writePictureBox);
            this.locationPanel.Controls.Add(this.adminPictureBox);
            this.locationPanel.Controls.Add(this.userLabel);
            this.locationPanel.Controls.Add(this.locationLabel);
            this.locationPanel.Dock = System.Windows.Forms.DockStyle.Top;
            this.locationPanel.Location = new System.Drawing.Point(0, 0);
            this.locationPanel.Name = "locationPanel";
            this.locationPanel.Size = new System.Drawing.Size(1241, 41);
            this.locationPanel.TabIndex = 0;
            // 
            // readPictureBox
            // 
            this.readPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.readPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("readPictureBox.BackgroundImage")));
            this.readPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.readPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("readPictureBox.InitialImage")));
            this.readPictureBox.Location = new System.Drawing.Point(1195, 6);
            this.readPictureBox.Name = "readPictureBox";
            this.readPictureBox.Size = new System.Drawing.Size(35, 25);
            this.readPictureBox.TabIndex = 5;
            this.readPictureBox.TabStop = false;
            this.readPictureBox.Visible = false;
            this.readPictureBox.WaitOnLoad = true;
            // 
            // approvalPictureBox
            // 
            this.approvalPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.approvalPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("approvalPictureBox.BackgroundImage")));
            this.approvalPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.approvalPictureBox.InitialImage = null;
            this.approvalPictureBox.Location = new System.Drawing.Point(1195, 6);
            this.approvalPictureBox.Name = "approvalPictureBox";
            this.approvalPictureBox.Size = new System.Drawing.Size(35, 25);
            this.approvalPictureBox.TabIndex = 4;
            this.approvalPictureBox.TabStop = false;
            this.approvalPictureBox.Visible = false;
            this.approvalPictureBox.WaitOnLoad = true;
            // 
            // writePictureBox
            // 
            this.writePictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.writePictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("writePictureBox.BackgroundImage")));
            this.writePictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.writePictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("writePictureBox.InitialImage")));
            this.writePictureBox.Location = new System.Drawing.Point(1195, 6);
            this.writePictureBox.Name = "writePictureBox";
            this.writePictureBox.Size = new System.Drawing.Size(35, 25);
            this.writePictureBox.TabIndex = 3;
            this.writePictureBox.TabStop = false;
            this.writePictureBox.Visible = false;
            this.writePictureBox.WaitOnLoad = true;
            // 
            // adminPictureBox
            // 
            this.adminPictureBox.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.adminPictureBox.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("adminPictureBox.BackgroundImage")));
            this.adminPictureBox.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.adminPictureBox.InitialImage = ((System.Drawing.Image)(resources.GetObject("adminPictureBox.InitialImage")));
            this.adminPictureBox.Location = new System.Drawing.Point(1195, 6);
            this.adminPictureBox.Name = "adminPictureBox";
            this.adminPictureBox.Size = new System.Drawing.Size(35, 25);
            this.adminPictureBox.TabIndex = 2;
            this.adminPictureBox.TabStop = false;
            this.adminPictureBox.WaitOnLoad = true;
            // 
            // userLabel
            // 
            this.userLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.userLabel.AutoSize = true;
            this.userLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.userLabel.Location = new System.Drawing.Point(1071, 10);
            this.userLabel.Name = "userLabel";
            this.userLabel.Size = new System.Drawing.Size(105, 20);
            this.userLabel.TabIndex = 1;
            this.userLabel.Text = "Adam Minarik";
            this.userLabel.Click += new System.EventHandler(this.userLabel_Click);
            // 
            // locationLabel
            // 
            this.locationLabel.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.locationLabel.AutoSize = true;
            this.locationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.locationLabel.Location = new System.Drawing.Point(12, 10);
            this.locationLabel.Name = "locationLabel";
            this.locationLabel.Size = new System.Drawing.Size(190, 20);
            this.locationLabel.TabIndex = 0;
            this.locationLabel.Text = "EXECUTION PROJECTS";
            // 
            // buttonPanel
            // 
            this.buttonPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.buttonPanel.Controls.Add(this.transfSalesProjButton);
            this.buttonPanel.Controls.Add(this.usersButton);
            this.buttonPanel.Controls.Add(this.ownerButton);
            this.buttonPanel.Controls.Add(this.wtgTypeButton);
            this.buttonPanel.Controls.Add(this.orgUnitButton);
            this.buttonPanel.Controls.Add(this.projectOwnerButton);
            this.buttonPanel.Controls.Add(this.nccButton);
            this.buttonPanel.Controls.Add(this.diCatButton);
            this.buttonPanel.Controls.Add(this.entryCurButton);
            this.buttonPanel.Controls.Add(this.quitButton);
            this.buttonPanel.Controls.Add(this.guideButton);
            this.buttonPanel.Controls.Add(this.settingsButton);
            this.buttonPanel.Controls.Add(this.editButton);
            this.buttonPanel.Controls.Add(this.createProjectButton);
            this.buttonPanel.Controls.Add(this.reportsButtons);
            this.buttonPanel.Controls.Add(this.projectsButton);
            this.buttonPanel.Dock = System.Windows.Forms.DockStyle.Left;
            this.buttonPanel.Location = new System.Drawing.Point(0, 41);
            this.buttonPanel.Name = "buttonPanel";
            this.buttonPanel.Size = new System.Drawing.Size(275, 725);
            this.buttonPanel.TabIndex = 1;
            // 
            // transfSalesProjButton
            // 
            this.transfSalesProjButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.transfSalesProjButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.transfSalesProjButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.transfSalesProjButton.FlatAppearance.BorderSize = 0;
            this.transfSalesProjButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(104)))), ((int)(((byte)(120)))));
            this.transfSalesProjButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.transfSalesProjButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.transfSalesProjButton.Location = new System.Drawing.Point(-1, 462);
            this.transfSalesProjButton.Name = "transfSalesProjButton";
            this.transfSalesProjButton.Size = new System.Drawing.Size(275, 30);
            this.transfSalesProjButton.TabIndex = 15;
            this.transfSalesProjButton.Text = "         • Transferred Sales Projects";
            this.transfSalesProjButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.transfSalesProjButton.UseVisualStyleBackColor = false;
            this.transfSalesProjButton.Visible = false;
            this.transfSalesProjButton.Click += new System.EventHandler(this.transfSalesProjButton_Click);
            // 
            // usersButton
            // 
            this.usersButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.usersButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.usersButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.usersButton.FlatAppearance.BorderSize = 0;
            this.usersButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(104)))), ((int)(((byte)(120)))));
            this.usersButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.usersButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.usersButton.Location = new System.Drawing.Point(-1, 432);
            this.usersButton.Name = "usersButton";
            this.usersButton.Size = new System.Drawing.Size(275, 30);
            this.usersButton.TabIndex = 14;
            this.usersButton.Text = "         • Users";
            this.usersButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.usersButton.UseVisualStyleBackColor = false;
            this.usersButton.Visible = false;
            this.usersButton.Click += new System.EventHandler(this.usersButton_Click);
            // 
            // ownerButton
            // 
            this.ownerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.ownerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.ownerButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.ownerButton.FlatAppearance.BorderSize = 0;
            this.ownerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(104)))), ((int)(((byte)(120)))));
            this.ownerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.ownerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ownerButton.Location = new System.Drawing.Point(-2, 402);
            this.ownerButton.Name = "ownerButton";
            this.ownerButton.Size = new System.Drawing.Size(275, 30);
            this.ownerButton.TabIndex = 13;
            this.ownerButton.Text = "         •  Owner";
            this.ownerButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.ownerButton.UseVisualStyleBackColor = false;
            this.ownerButton.Visible = false;
            this.ownerButton.Click += new System.EventHandler(this.ownerButton_Click);
            // 
            // wtgTypeButton
            // 
            this.wtgTypeButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.wtgTypeButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.wtgTypeButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.wtgTypeButton.FlatAppearance.BorderSize = 0;
            this.wtgTypeButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(104)))), ((int)(((byte)(120)))));
            this.wtgTypeButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.wtgTypeButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wtgTypeButton.Location = new System.Drawing.Point(-2, 372);
            this.wtgTypeButton.Name = "wtgTypeButton";
            this.wtgTypeButton.Size = new System.Drawing.Size(275, 30);
            this.wtgTypeButton.TabIndex = 12;
            this.wtgTypeButton.Text = "         • WTG Type";
            this.wtgTypeButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.wtgTypeButton.UseVisualStyleBackColor = false;
            this.wtgTypeButton.Visible = false;
            this.wtgTypeButton.Click += new System.EventHandler(this.wtgTypeButton_Click);
            // 
            // orgUnitButton
            // 
            this.orgUnitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.orgUnitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.orgUnitButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.orgUnitButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.orgUnitButton.FlatAppearance.BorderSize = 0;
            this.orgUnitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(104)))), ((int)(((byte)(120)))));
            this.orgUnitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.orgUnitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.orgUnitButton.Location = new System.Drawing.Point(-2, 342);
            this.orgUnitButton.Name = "orgUnitButton";
            this.orgUnitButton.Size = new System.Drawing.Size(275, 30);
            this.orgUnitButton.TabIndex = 11;
            this.orgUnitButton.Text = "         • Originating Unit";
            this.orgUnitButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.orgUnitButton.UseVisualStyleBackColor = false;
            this.orgUnitButton.Visible = false;
            this.orgUnitButton.Click += new System.EventHandler(this.orgUnitButton_Click);
            // 
            // projectOwnerButton
            // 
            this.projectOwnerButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectOwnerButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.projectOwnerButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.projectOwnerButton.FlatAppearance.BorderSize = 0;
            this.projectOwnerButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(104)))), ((int)(((byte)(120)))));
            this.projectOwnerButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.projectOwnerButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectOwnerButton.Location = new System.Drawing.Point(-2, 312);
            this.projectOwnerButton.Name = "projectOwnerButton";
            this.projectOwnerButton.Size = new System.Drawing.Size(275, 30);
            this.projectOwnerButton.TabIndex = 10;
            this.projectOwnerButton.Text = "         •  Project Ownership";
            this.projectOwnerButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.projectOwnerButton.UseVisualStyleBackColor = false;
            this.projectOwnerButton.Visible = false;
            this.projectOwnerButton.Click += new System.EventHandler(this.projectOwnerButton_Click);
            // 
            // nccButton
            // 
            this.nccButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.nccButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.nccButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.nccButton.FlatAppearance.BorderSize = 0;
            this.nccButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(104)))), ((int)(((byte)(120)))));
            this.nccButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.nccButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.nccButton.Location = new System.Drawing.Point(-2, 282);
            this.nccButton.Name = "nccButton";
            this.nccButton.Size = new System.Drawing.Size(275, 30);
            this.nccButton.TabIndex = 9;
            this.nccButton.Text = "         • NCC";
            this.nccButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.nccButton.UseVisualStyleBackColor = false;
            this.nccButton.Visible = false;
            this.nccButton.Click += new System.EventHandler(this.nccButton_Click);
            // 
            // diCatButton
            // 
            this.diCatButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.diCatButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.diCatButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.diCatButton.FlatAppearance.BorderSize = 0;
            this.diCatButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(104)))), ((int)(((byte)(120)))));
            this.diCatButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.diCatButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.diCatButton.Location = new System.Drawing.Point(-2, 252);
            this.diCatButton.Name = "diCatButton";
            this.diCatButton.Size = new System.Drawing.Size(275, 30);
            this.diCatButton.TabIndex = 8;
            this.diCatButton.Text = "         • DI Category";
            this.diCatButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.diCatButton.UseVisualStyleBackColor = false;
            this.diCatButton.Visible = false;
            this.diCatButton.Click += new System.EventHandler(this.diCatButton_Click);
            // 
            // entryCurButton
            // 
            this.entryCurButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryCurButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(134)))), ((int)(((byte)(134)))), ((int)(((byte)(134)))));
            this.entryCurButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.entryCurButton.FlatAppearance.BorderColor = System.Drawing.Color.White;
            this.entryCurButton.FlatAppearance.BorderSize = 0;
            this.entryCurButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(104)))), ((int)(((byte)(120)))));
            this.entryCurButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.entryCurButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.entryCurButton.Location = new System.Drawing.Point(-2, 222);
            this.entryCurButton.Name = "entryCurButton";
            this.entryCurButton.Size = new System.Drawing.Size(275, 30);
            this.entryCurButton.TabIndex = 7;
            this.entryCurButton.Text = "         • Entry Currency";
            this.entryCurButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.entryCurButton.UseVisualStyleBackColor = false;
            this.entryCurButton.Visible = false;
            this.entryCurButton.Click += new System.EventHandler(this.entryCurButton_Click);
            // 
            // quitButton
            // 
            this.quitButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.quitButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(60)))), ((int)(((byte)(60)))), ((int)(((byte)(60)))));
            this.quitButton.FlatAppearance.BorderColor = System.Drawing.Color.Black;
            this.quitButton.FlatAppearance.BorderSize = 0;
            this.quitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent;
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.quitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.quitButton.Location = new System.Drawing.Point(0, 679);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(275, 46);
            this.quitButton.TabIndex = 6;
            this.quitButton.Text = "QUIT";
            this.quitButton.UseVisualStyleBackColor = false;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // guideButton
            // 
            this.guideButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.guideButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.guideButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.guideButton.FlatAppearance.BorderSize = 0;
            this.guideButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(116)))), ((int)(((byte)(150)))));
            this.guideButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(104)))), ((int)(((byte)(120)))));
            this.guideButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.guideButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.guideButton.Image = ((System.Drawing.Image)(resources.GetObject("guideButton.Image")));
            this.guideButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.guideButton.Location = new System.Drawing.Point(1, 147);
            this.guideButton.Name = "guideButton";
            this.guideButton.Size = new System.Drawing.Size(275, 38);
            this.guideButton.TabIndex = 5;
            this.guideButton.Text = "         TOOL GUIDE";
            this.guideButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.guideButton.UseVisualStyleBackColor = false;
            this.guideButton.Click += new System.EventHandler(this.guideButton_Click);
            // 
            // settingsButton
            // 
            this.settingsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.settingsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.settingsButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.settingsButton.FlatAppearance.BorderSize = 0;
            this.settingsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(116)))), ((int)(((byte)(150)))));
            this.settingsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(104)))), ((int)(((byte)(120)))));
            this.settingsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.settingsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.settingsButton.Image = ((System.Drawing.Image)(resources.GetObject("settingsButton.Image")));
            this.settingsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.Location = new System.Drawing.Point(0, 109);
            this.settingsButton.Name = "settingsButton";
            this.settingsButton.Size = new System.Drawing.Size(275, 38);
            this.settingsButton.TabIndex = 4;
            this.settingsButton.Text = "         SETTINGS";
            this.settingsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.settingsButton.UseVisualStyleBackColor = false;
            // 
            // editButton
            // 
            this.editButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.editButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.editButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.editButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.editButton.FlatAppearance.BorderSize = 0;
            this.editButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(116)))), ((int)(((byte)(150)))));
            this.editButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(104)))), ((int)(((byte)(120)))));
            this.editButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.editButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.editButton.Image = ((System.Drawing.Image)(resources.GetObject("editButton.Image")));
            this.editButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editButton.Location = new System.Drawing.Point(1, 185);
            this.editButton.Name = "editButton";
            this.editButton.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.editButton.Size = new System.Drawing.Size(275, 37);
            this.editButton.TabIndex = 3;
            this.editButton.Text = "         EDIT";
            this.editButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.editButton.UseVisualStyleBackColor = false;
            this.editButton.Click += new System.EventHandler(this.editButton_Click);
            // 
            // createProjectButton
            // 
            this.createProjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createProjectButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.createProjectButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.createProjectButton.FlatAppearance.BorderSize = 0;
            this.createProjectButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(116)))), ((int)(((byte)(150)))));
            this.createProjectButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(104)))), ((int)(((byte)(120)))));
            this.createProjectButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.createProjectButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.createProjectButton.Image = ((System.Drawing.Image)(resources.GetObject("createProjectButton.Image")));
            this.createProjectButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createProjectButton.Location = new System.Drawing.Point(0, 71);
            this.createProjectButton.Name = "createProjectButton";
            this.createProjectButton.Size = new System.Drawing.Size(275, 38);
            this.createProjectButton.TabIndex = 2;
            this.createProjectButton.Text = "         CREATE PROJECT";
            this.createProjectButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.createProjectButton.UseVisualStyleBackColor = false;
            this.createProjectButton.Click += new System.EventHandler(this.createProjectButton_Click);
            // 
            // reportsButtons
            // 
            this.reportsButtons.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.reportsButtons.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.reportsButtons.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.reportsButtons.FlatAppearance.BorderSize = 0;
            this.reportsButtons.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(116)))), ((int)(((byte)(150)))));
            this.reportsButtons.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(104)))), ((int)(((byte)(120)))));
            this.reportsButtons.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.reportsButtons.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.reportsButtons.Image = ((System.Drawing.Image)(resources.GetObject("reportsButtons.Image")));
            this.reportsButtons.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportsButtons.Location = new System.Drawing.Point(0, 35);
            this.reportsButtons.Name = "reportsButtons";
            this.reportsButtons.Size = new System.Drawing.Size(275, 38);
            this.reportsButtons.TabIndex = 1;
            this.reportsButtons.Text = "         PORTFOLIO REPORTS";
            this.reportsButtons.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.reportsButtons.UseVisualStyleBackColor = false;
            this.reportsButtons.Click += new System.EventHandler(this.reportsButtons_Click);
            // 
            // projectsButton
            // 
            this.projectsButton.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.projectsButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(99)))), ((int)(((byte)(99)))), ((int)(((byte)(99)))));
            this.projectsButton.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.projectsButton.FlatAppearance.BorderColor = System.Drawing.Color.Silver;
            this.projectsButton.FlatAppearance.BorderSize = 0;
            this.projectsButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(132)))), ((int)(((byte)(116)))), ((int)(((byte)(150)))));
            this.projectsButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(121)))), ((int)(((byte)(104)))), ((int)(((byte)(120)))));
            this.projectsButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.projectsButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectsButton.Image = ((System.Drawing.Image)(resources.GetObject("projectsButton.Image")));
            this.projectsButton.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.projectsButton.Location = new System.Drawing.Point(0, -1);
            this.projectsButton.Name = "projectsButton";
            this.projectsButton.Size = new System.Drawing.Size(275, 38);
            this.projectsButton.TabIndex = 0;
            this.projectsButton.Text = "         PROJECTS";
            this.projectsButton.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.projectsButton.UseVisualStyleBackColor = false;
            this.projectsButton.Click += new System.EventHandler(this.projectsButton_Click);
            // 
            // projectsPanel
            // 
            this.projectsPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(232)))), ((int)(((byte)(238)))));
            this.projectsPanel.Controls.Add(this.projectsData);
            this.projectsPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectsPanel.Location = new System.Drawing.Point(3, 3);
            this.projectsPanel.Name = "projectsPanel";
            this.projectsPanel.Size = new System.Drawing.Size(952, 693);
            this.projectsPanel.TabIndex = 2;
            // 
            // projectsData
            // 
            this.projectsData.AllowUserToAddRows = false;
            this.projectsData.AllowUserToDeleteRows = false;
            this.projectsData.AutoGenerateColumns = false;
            this.projectsData.BackgroundColor = System.Drawing.Color.White;
            this.projectsData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.projectsData.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.pnameDataGridViewTextBoxColumn,
            this.segmentIDDataGridViewTextBoxColumn,
            this.scopeDataGridViewTextBoxColumn,
            this.wtgDataGridViewTextBoxColumn,
            this.owneDataGridViewTextBoxColumn,
            this.sapDataGridViewTextBoxColumn,
            this.iDDataGridViewTextBoxColumn,
            this.iDuserDataGridViewTextBoxColumn,
            this.iDProjectTypeDataGridViewTextBoxColumn});
            this.projectsData.DataSource = this.newprojectviewBindingSource;
            this.projectsData.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectsData.Location = new System.Drawing.Point(0, 0);
            this.projectsData.Name = "projectsData";
            this.projectsData.Size = new System.Drawing.Size(952, 693);
            this.projectsData.TabIndex = 0;
            this.projectsData.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.projectsData_CellClick);
            // 
            // pnameDataGridViewTextBoxColumn
            // 
            this.pnameDataGridViewTextBoxColumn.DataPropertyName = "pname";
            this.pnameDataGridViewTextBoxColumn.HeaderText = "pname";
            this.pnameDataGridViewTextBoxColumn.Name = "pnameDataGridViewTextBoxColumn";
            // 
            // segmentIDDataGridViewTextBoxColumn
            // 
            this.segmentIDDataGridViewTextBoxColumn.DataPropertyName = "segmentID";
            this.segmentIDDataGridViewTextBoxColumn.HeaderText = "segmentID";
            this.segmentIDDataGridViewTextBoxColumn.Name = "segmentIDDataGridViewTextBoxColumn";
            // 
            // scopeDataGridViewTextBoxColumn
            // 
            this.scopeDataGridViewTextBoxColumn.DataPropertyName = "scope";
            this.scopeDataGridViewTextBoxColumn.HeaderText = "scope";
            this.scopeDataGridViewTextBoxColumn.Name = "scopeDataGridViewTextBoxColumn";
            this.scopeDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // wtgDataGridViewTextBoxColumn
            // 
            this.wtgDataGridViewTextBoxColumn.DataPropertyName = "wtg";
            this.wtgDataGridViewTextBoxColumn.HeaderText = "wtg";
            this.wtgDataGridViewTextBoxColumn.Name = "wtgDataGridViewTextBoxColumn";
            this.wtgDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // owneDataGridViewTextBoxColumn
            // 
            this.owneDataGridViewTextBoxColumn.DataPropertyName = "owne";
            this.owneDataGridViewTextBoxColumn.HeaderText = "owne";
            this.owneDataGridViewTextBoxColumn.Name = "owneDataGridViewTextBoxColumn";
            this.owneDataGridViewTextBoxColumn.ReadOnly = true;
            // 
            // sapDataGridViewTextBoxColumn
            // 
            this.sapDataGridViewTextBoxColumn.DataPropertyName = "sap";
            this.sapDataGridViewTextBoxColumn.HeaderText = "sap";
            this.sapDataGridViewTextBoxColumn.Name = "sapDataGridViewTextBoxColumn";
            // 
            // iDDataGridViewTextBoxColumn
            // 
            this.iDDataGridViewTextBoxColumn.DataPropertyName = "ID";
            this.iDDataGridViewTextBoxColumn.HeaderText = "ID";
            this.iDDataGridViewTextBoxColumn.Name = "iDDataGridViewTextBoxColumn";
            // 
            // iDuserDataGridViewTextBoxColumn
            // 
            this.iDuserDataGridViewTextBoxColumn.DataPropertyName = "IDuser";
            this.iDuserDataGridViewTextBoxColumn.HeaderText = "IDuser";
            this.iDuserDataGridViewTextBoxColumn.Name = "iDuserDataGridViewTextBoxColumn";
            // 
            // iDProjectTypeDataGridViewTextBoxColumn
            // 
            this.iDProjectTypeDataGridViewTextBoxColumn.DataPropertyName = "IDProjectType";
            this.iDProjectTypeDataGridViewTextBoxColumn.HeaderText = "IDProjectType";
            this.iDProjectTypeDataGridViewTextBoxColumn.Name = "iDProjectTypeDataGridViewTextBoxColumn";
            // 
            // newprojectviewBindingSource
            // 
            this.newprojectviewBindingSource.DataMember = "new_project_view";
            this.newprojectviewBindingSource.DataSource = this.dataSet1;
            // 
            // dataSet1
            // 
            this.dataSet1.DataSetName = "projectDataSet";
            this.dataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // portfolioPanel
            // 
            this.portfolioPanel.Controls.Add(this.tableauButton);
            this.portfolioPanel.Controls.Add(this.riskContingencyButton);
            this.portfolioPanel.Controls.Add(this.rologButton);
            this.portfolioPanel.Controls.Add(this.top20Button);
            this.portfolioPanel.Controls.Add(this.portfolioRepGridView);
            this.portfolioPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portfolioPanel.Location = new System.Drawing.Point(3, 3);
            this.portfolioPanel.Name = "portfolioPanel";
            this.portfolioPanel.Size = new System.Drawing.Size(952, 693);
            this.portfolioPanel.TabIndex = 3;
            this.portfolioPanel.Visible = false;
            // 
            // tableauButton
            // 
            this.tableauButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.tableauButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.tableauButton.Location = new System.Drawing.Point(648, 650);
            this.tableauButton.Name = "tableauButton";
            this.tableauButton.Size = new System.Drawing.Size(183, 34);
            this.tableauButton.TabIndex = 4;
            this.tableauButton.Text = "Tableau Reports";
            this.tableauButton.UseVisualStyleBackColor = true;
            // 
            // riskContingencyButton
            // 
            this.riskContingencyButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.riskContingencyButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.riskContingencyButton.Location = new System.Drawing.Point(436, 651);
            this.riskContingencyButton.Name = "riskContingencyButton";
            this.riskContingencyButton.Size = new System.Drawing.Size(183, 34);
            this.riskContingencyButton.TabIndex = 3;
            this.riskContingencyButton.Text = "Risk Contingency Report";
            this.riskContingencyButton.UseVisualStyleBackColor = true;
            // 
            // rologButton
            // 
            this.rologButton.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.rologButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.rologButton.Location = new System.Drawing.Point(220, 651);
            this.rologButton.Name = "rologButton";
            this.rologButton.Size = new System.Drawing.Size(183, 34);
            this.rologButton.TabIndex = 2;
            this.rologButton.Text = "Risk && Opportunity log Report";
            this.rologButton.UseVisualStyleBackColor = true;
            // 
            // top20Button
            // 
            this.top20Button.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.top20Button.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.top20Button.Location = new System.Drawing.Point(6, 651);
            this.top20Button.Name = "top20Button";
            this.top20Button.Size = new System.Drawing.Size(183, 34);
            this.top20Button.TabIndex = 1;
            this.top20Button.Text = "Top 20 Report";
            this.top20Button.UseVisualStyleBackColor = true;
            // 
            // portfolioRepGridView
            // 
            this.portfolioRepGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.portfolioRepGridView.BackgroundColor = System.Drawing.Color.White;
            this.portfolioRepGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.portfolioRepGridView.Location = new System.Drawing.Point(6, 6);
            this.portfolioRepGridView.Name = "portfolioRepGridView";
            this.portfolioRepGridView.Size = new System.Drawing.Size(937, 638);
            this.portfolioRepGridView.TabIndex = 0;
            // 
            // createProjectPanel
            // 
            this.createProjectPanel.Controls.Add(this.newProjectTableLayout);
            this.createProjectPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.createProjectPanel.Location = new System.Drawing.Point(3, 3);
            this.createProjectPanel.Name = "createProjectPanel";
            this.createProjectPanel.Size = new System.Drawing.Size(952, 693);
            this.createProjectPanel.TabIndex = 5;
            // 
            // newProjectTableLayout
            // 
            this.newProjectTableLayout.AutoSize = true;
            this.newProjectTableLayout.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.newProjectTableLayout.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(232)))), ((int)(((byte)(238)))));
            this.newProjectTableLayout.ColumnCount = 7;
            this.newProjectTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.469074F));
            this.newProjectTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.03613F));
            this.newProjectTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 4.938149F));
            this.newProjectTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 37.03613F));
            this.newProjectTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 6.175157F));
            this.newProjectTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 9.876299F));
            this.newProjectTableLayout.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 2.469074F));
            this.newProjectTableLayout.Controls.Add(this.projectNameTextBox, 1, 2);
            this.newProjectTableLayout.Controls.Add(this.projectIDLabel, 1, 3);
            this.newProjectTableLayout.Controls.Add(this.projectIDTextBox, 1, 4);
            this.newProjectTableLayout.Controls.Add(this.pmLabel, 1, 6);
            this.newProjectTableLayout.Controls.Add(this.wtgNoTextBox, 1, 16);
            this.newProjectTableLayout.Controls.Add(this.PMTextBox, 1, 7);
            this.newProjectTableLayout.Controls.Add(this.cpmLabel, 1, 8);
            this.newProjectTableLayout.Controls.Add(this.CPMTextBox, 1, 9);
            this.newProjectTableLayout.Controls.Add(this.wtgNoLabel, 1, 15);
            this.newProjectTableLayout.Controls.Add(this.preparedByLabel, 1, 10);
            this.newProjectTableLayout.Controls.Add(this.preparedByTextBox, 1, 11);
            this.newProjectTableLayout.Controls.Add(this.TOCLabel, 1, 13);
            this.newProjectTableLayout.Controls.Add(this.totalProjectCostsTextBox, 1, 28);
            this.newProjectTableLayout.Controls.Add(this.totalCostsLabel, 1, 27);
            this.newProjectTableLayout.Controls.Add(this.ruCostsTextBox, 1, 26);
            this.newProjectTableLayout.Controls.Add(this.RUcostsLabel, 1, 25);
            this.newProjectTableLayout.Controls.Add(this.buCostsTextBox, 1, 22);
            this.newProjectTableLayout.Controls.Add(this.BUcostsLabel, 1, 21);
            this.newProjectTableLayout.Controls.Add(this.BUCurLabel, 3, 21);
            this.newProjectTableLayout.Controls.Add(this.buCurComboBox, 3, 22);
            this.newProjectTableLayout.Controls.Add(this.ruCurComboBox, 3, 26);
            this.newProjectTableLayout.Controls.Add(this.RUcurLabel, 3, 25);
            this.newProjectTableLayout.Controls.Add(this.ruEurLabel, 4, 26);
            this.newProjectTableLayout.Controls.Add(this.buEurLabel, 4, 22);
            this.newProjectTableLayout.Controls.Add(this.ruRateTextBox, 5, 26);
            this.newProjectTableLayout.Controls.Add(this.buRateTextBox, 5, 22);
            this.newProjectTableLayout.Controls.Add(this.projectNameLabel, 1, 1);
            this.newProjectTableLayout.Controls.Add(this.foundationLabel, 3, 8);
            this.newProjectTableLayout.Controls.Add(this.preassemblyLabel, 3, 10);
            this.newProjectTableLayout.Controls.Add(this.portComboBox, 3, 11);
            this.newProjectTableLayout.Controls.Add(this.foundationComboBox, 3, 9);
            this.newProjectTableLayout.Controls.Add(this.segmentLabel, 3, 13);
            this.newProjectTableLayout.Controls.Add(this.scopeLabel, 3, 6);
            this.newProjectTableLayout.Controls.Add(this.segmentComboBox, 3, 14);
            this.newProjectTableLayout.Controls.Add(this.scopeComboBox, 3, 7);
            this.newProjectTableLayout.Controls.Add(this.wtgTypeLabel, 3, 15);
            this.newProjectTableLayout.Controls.Add(this.wtgTypeComboBox, 3, 16);
            this.newProjectTableLayout.Controls.Add(this.LoAIDLabel, 3, 3);
            this.newProjectTableLayout.Controls.Add(this.LoaIDTextBox, 3, 4);
            this.newProjectTableLayout.Controls.Add(this.projectSpecificDataLabel, 1, 0);
            this.newProjectTableLayout.Controls.Add(this.projectPersonalDataLabel, 1, 5);
            this.newProjectTableLayout.Controls.Add(this.projectOrderDataLabel, 1, 12);
            this.newProjectTableLayout.Controls.Add(this.projectCostsLabel, 1, 17);
            this.newProjectTableLayout.Controls.Add(this.scopeLocationLabel, 3, 5);
            this.newProjectTableLayout.Controls.Add(this.insertProjectButton, 5, 30);
            this.newProjectTableLayout.Controls.Add(this.projectOwnerLabel, 3, 1);
            this.newProjectTableLayout.Controls.Add(this.projectOwnerComboBox, 3, 2);
            this.newProjectTableLayout.Controls.Add(this.tocTextBox, 1, 14);
            this.newProjectTableLayout.Dock = System.Windows.Forms.DockStyle.Fill;
            this.newProjectTableLayout.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.newProjectTableLayout.Location = new System.Drawing.Point(0, 0);
            this.newProjectTableLayout.Name = "newProjectTableLayout";
            this.newProjectTableLayout.RowCount = 32;
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Absolute, 30F));
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.RowStyles.Add(new System.Windows.Forms.RowStyle());
            this.newProjectTableLayout.Size = new System.Drawing.Size(952, 693);
            this.newProjectTableLayout.TabIndex = 42;
            this.newProjectTableLayout.Paint += new System.Windows.Forms.PaintEventHandler(this.tableLayoutPanel1_Paint);
            // 
            // projectNameTextBox
            // 
            this.projectNameTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectNameTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectNameTextBox.Location = new System.Drawing.Point(26, 48);
            this.projectNameTextBox.Multiline = true;
            this.projectNameTextBox.Name = "projectNameTextBox";
            this.projectNameTextBox.Size = new System.Drawing.Size(346, 21);
            this.projectNameTextBox.TabIndex = 18;
            // 
            // projectIDLabel
            // 
            this.projectIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectIDLabel.Location = new System.Drawing.Point(26, 72);
            this.projectIDLabel.Name = "projectIDLabel";
            this.projectIDLabel.Size = new System.Drawing.Size(130, 15);
            this.projectIDLabel.TabIndex = 1;
            this.projectIDLabel.Text = "Project ID";
            this.projectIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // projectIDTextBox
            // 
            this.projectIDTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectIDTextBox.Location = new System.Drawing.Point(26, 90);
            this.projectIDTextBox.Multiline = true;
            this.projectIDTextBox.Name = "projectIDTextBox";
            this.projectIDTextBox.Size = new System.Drawing.Size(346, 21);
            this.projectIDTextBox.TabIndex = 20;
            // 
            // pmLabel
            // 
            this.pmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.pmLabel.Location = new System.Drawing.Point(26, 144);
            this.pmLabel.Name = "pmLabel";
            this.pmLabel.Size = new System.Drawing.Size(130, 15);
            this.pmLabel.TabIndex = 4;
            this.pmLabel.Text = "Project Manager";
            this.pmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wtgNoTextBox
            // 
            this.wtgNoTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wtgNoTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wtgNoTextBox.Location = new System.Drawing.Point(26, 360);
            this.wtgNoTextBox.Multiline = true;
            this.wtgNoTextBox.Name = "wtgNoTextBox";
            this.wtgNoTextBox.Size = new System.Drawing.Size(346, 21);
            this.wtgNoTextBox.TabIndex = 30;
            // 
            // PMTextBox
            // 
            this.PMTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.PMTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.PMTextBox.Location = new System.Drawing.Point(26, 162);
            this.PMTextBox.Multiline = true;
            this.PMTextBox.Name = "PMTextBox";
            this.PMTextBox.Size = new System.Drawing.Size(346, 21);
            this.PMTextBox.TabIndex = 22;
            // 
            // cpmLabel
            // 
            this.cpmLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.cpmLabel.Location = new System.Drawing.Point(26, 186);
            this.cpmLabel.Name = "cpmLabel";
            this.cpmLabel.Size = new System.Drawing.Size(186, 15);
            this.cpmLabel.TabIndex = 3;
            this.cpmLabel.Text = "Commerctial Project Manager";
            this.cpmLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // CPMTextBox
            // 
            this.CPMTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.CPMTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.CPMTextBox.Location = new System.Drawing.Point(26, 204);
            this.CPMTextBox.Multiline = true;
            this.CPMTextBox.Name = "CPMTextBox";
            this.CPMTextBox.Size = new System.Drawing.Size(346, 21);
            this.CPMTextBox.TabIndex = 23;
            // 
            // wtgNoLabel
            // 
            this.wtgNoLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wtgNoLabel.Location = new System.Drawing.Point(26, 342);
            this.wtgNoLabel.Name = "wtgNoLabel";
            this.wtgNoLabel.Size = new System.Drawing.Size(130, 15);
            this.wtgNoLabel.TabIndex = 9;
            this.wtgNoLabel.Text = "Number of WTGs";
            this.wtgNoLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // preparedByLabel
            // 
            this.preparedByLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.preparedByLabel.Location = new System.Drawing.Point(26, 228);
            this.preparedByLabel.Name = "preparedByLabel";
            this.preparedByLabel.Size = new System.Drawing.Size(130, 15);
            this.preparedByLabel.TabIndex = 5;
            this.preparedByLabel.Text = "Prepared by";
            this.preparedByLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // preparedByTextBox
            // 
            this.preparedByTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.preparedByTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.preparedByTextBox.Location = new System.Drawing.Point(26, 246);
            this.preparedByTextBox.Multiline = true;
            this.preparedByTextBox.Name = "preparedByTextBox";
            this.preparedByTextBox.Size = new System.Drawing.Size(346, 21);
            this.preparedByTextBox.TabIndex = 24;
            // 
            // TOCLabel
            // 
            this.TOCLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.TOCLabel.Location = new System.Drawing.Point(26, 300);
            this.TOCLabel.Name = "TOCLabel";
            this.TOCLabel.Size = new System.Drawing.Size(130, 15);
            this.TOCLabel.TabIndex = 6;
            this.TOCLabel.Text = "TOC Date";
            this.TOCLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // totalProjectCostsTextBox
            // 
            this.totalProjectCostsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.totalProjectCostsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.totalProjectCostsTextBox.Location = new System.Drawing.Point(26, 516);
            this.totalProjectCostsTextBox.Multiline = true;
            this.totalProjectCostsTextBox.Name = "totalProjectCostsTextBox";
            this.totalProjectCostsTextBox.ReadOnly = true;
            this.totalProjectCostsTextBox.Size = new System.Drawing.Size(346, 21);
            this.totalProjectCostsTextBox.TabIndex = 38;
            // 
            // totalCostsLabel
            // 
            this.totalCostsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.totalCostsLabel.Location = new System.Drawing.Point(26, 498);
            this.totalCostsLabel.Name = "totalCostsLabel";
            this.totalCostsLabel.Size = new System.Drawing.Size(130, 15);
            this.totalCostsLabel.TabIndex = 15;
            this.totalCostsLabel.Text = "Total Project costs";
            this.totalCostsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ruCostsTextBox
            // 
            this.ruCostsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ruCostsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ruCostsTextBox.Location = new System.Drawing.Point(26, 474);
            this.ruCostsTextBox.Multiline = true;
            this.ruCostsTextBox.Name = "ruCostsTextBox";
            this.ruCostsTextBox.Size = new System.Drawing.Size(346, 21);
            this.ruCostsTextBox.TabIndex = 35;
            // 
            // RUcostsLabel
            // 
            this.RUcostsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RUcostsLabel.Location = new System.Drawing.Point(26, 456);
            this.RUcostsLabel.Name = "RUcostsLabel";
            this.RUcostsLabel.Size = new System.Drawing.Size(130, 15);
            this.RUcostsLabel.TabIndex = 14;
            this.RUcostsLabel.Text = "Projects costs RU";
            this.RUcostsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buCostsTextBox
            // 
            this.buCostsTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buCostsTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buCostsTextBox.Location = new System.Drawing.Point(26, 432);
            this.buCostsTextBox.Multiline = true;
            this.buCostsTextBox.Name = "buCostsTextBox";
            this.buCostsTextBox.Size = new System.Drawing.Size(346, 21);
            this.buCostsTextBox.TabIndex = 32;
            // 
            // BUcostsLabel
            // 
            this.BUcostsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BUcostsLabel.Location = new System.Drawing.Point(26, 414);
            this.BUcostsLabel.Name = "BUcostsLabel";
            this.BUcostsLabel.Size = new System.Drawing.Size(130, 15);
            this.BUcostsLabel.TabIndex = 13;
            this.BUcostsLabel.Text = "Projects costs BU";
            this.BUcostsLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // BUCurLabel
            // 
            this.BUCurLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.BUCurLabel.Location = new System.Drawing.Point(425, 414);
            this.BUCurLabel.Name = "BUCurLabel";
            this.BUCurLabel.Size = new System.Drawing.Size(130, 15);
            this.BUCurLabel.TabIndex = 16;
            this.BUCurLabel.Text = "BU currency";
            this.BUCurLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buCurComboBox
            // 
            this.buCurComboBox.DataSource = this.rkCurrencyNameBindingSource;
            this.buCurComboBox.DisplayMember = "Code";
            this.buCurComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buCurComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buCurComboBox.FormattingEnabled = true;
            this.buCurComboBox.Location = new System.Drawing.Point(425, 432);
            this.buCurComboBox.Name = "buCurComboBox";
            this.buCurComboBox.Size = new System.Drawing.Size(346, 21);
            this.buCurComboBox.TabIndex = 33;
            this.buCurComboBox.ValueMember = "ID";
            // 
            // rkCurrencyNameBindingSource
            // 
            this.rkCurrencyNameBindingSource.DataMember = "rk_CurrencyName";
            this.rkCurrencyNameBindingSource.DataSource = this.dataSet1;
            // 
            // ruCurComboBox
            // 
            this.ruCurComboBox.DataSource = this.rkCurrencyNameBindingSource;
            this.ruCurComboBox.DisplayMember = "Code";
            this.ruCurComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ruCurComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ruCurComboBox.FormattingEnabled = true;
            this.ruCurComboBox.Location = new System.Drawing.Point(425, 474);
            this.ruCurComboBox.Name = "ruCurComboBox";
            this.ruCurComboBox.Size = new System.Drawing.Size(346, 21);
            this.ruCurComboBox.TabIndex = 36;
            this.ruCurComboBox.ValueMember = "ID";
            // 
            // RUcurLabel
            // 
            this.RUcurLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.RUcurLabel.Location = new System.Drawing.Point(425, 456);
            this.RUcurLabel.Name = "RUcurLabel";
            this.RUcurLabel.Size = new System.Drawing.Size(130, 15);
            this.RUcurLabel.TabIndex = 17;
            this.RUcurLabel.Text = "RU currency";
            this.RUcurLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // ruEurLabel
            // 
            this.ruEurLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ruEurLabel.Location = new System.Drawing.Point(777, 471);
            this.ruEurLabel.Name = "ruEurLabel";
            this.ruEurLabel.Size = new System.Drawing.Size(40, 21);
            this.ruEurLabel.TabIndex = 38;
            this.ruEurLabel.Text = "/EUR";
            this.ruEurLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // buEurLabel
            // 
            this.buEurLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buEurLabel.Location = new System.Drawing.Point(777, 429);
            this.buEurLabel.Name = "buEurLabel";
            this.buEurLabel.Size = new System.Drawing.Size(40, 21);
            this.buEurLabel.TabIndex = 39;
            this.buEurLabel.Text = "/EUR";
            this.buEurLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buEurLabel.Click += new System.EventHandler(this.buEurLabel_Click);
            // 
            // ruRateTextBox
            // 
            this.ruRateTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.ruRateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.ruRateTextBox.Location = new System.Drawing.Point(835, 474);
            this.ruRateTextBox.Multiline = true;
            this.ruRateTextBox.Name = "ruRateTextBox";
            this.ruRateTextBox.Size = new System.Drawing.Size(88, 21);
            this.ruRateTextBox.TabIndex = 37;
            // 
            // buRateTextBox
            // 
            this.buRateTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.buRateTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buRateTextBox.Location = new System.Drawing.Point(835, 432);
            this.buRateTextBox.Multiline = true;
            this.buRateTextBox.Name = "buRateTextBox";
            this.buRateTextBox.Size = new System.Drawing.Size(88, 21);
            this.buRateTextBox.TabIndex = 34;
            // 
            // projectNameLabel
            // 
            this.projectNameLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectNameLabel.Location = new System.Drawing.Point(26, 30);
            this.projectNameLabel.Name = "projectNameLabel";
            this.projectNameLabel.Size = new System.Drawing.Size(130, 15);
            this.projectNameLabel.TabIndex = 0;
            this.projectNameLabel.Text = "Project Name";
            this.projectNameLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // foundationLabel
            // 
            this.foundationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.foundationLabel.Location = new System.Drawing.Point(425, 186);
            this.foundationLabel.Name = "foundationLabel";
            this.foundationLabel.Size = new System.Drawing.Size(130, 15);
            this.foundationLabel.TabIndex = 11;
            this.foundationLabel.Text = "Type of Foundation";
            this.foundationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // preassemblyLabel
            // 
            this.preassemblyLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.preassemblyLabel.Location = new System.Drawing.Point(425, 228);
            this.preassemblyLabel.Name = "preassemblyLabel";
            this.preassemblyLabel.Size = new System.Drawing.Size(130, 15);
            this.preassemblyLabel.TabIndex = 12;
            this.preassemblyLabel.Text = "Port of Pre-assembly";
            this.preassemblyLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // portComboBox
            // 
            this.portComboBox.DataSource = this.rkPreAssemblyHarbourBindingSource;
            this.portComboBox.DisplayMember = "Code";
            this.portComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.portComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.portComboBox.FormattingEnabled = true;
            this.portComboBox.Location = new System.Drawing.Point(425, 246);
            this.portComboBox.Name = "portComboBox";
            this.portComboBox.Size = new System.Drawing.Size(346, 21);
            this.portComboBox.TabIndex = 27;
            this.portComboBox.ValueMember = "ID";
            // 
            // rkPreAssemblyHarbourBindingSource
            // 
            this.rkPreAssemblyHarbourBindingSource.DataMember = "rk_PreAssemblyHarbour";
            this.rkPreAssemblyHarbourBindingSource.DataSource = this.dataSet1;
            // 
            // foundationComboBox
            // 
            this.foundationComboBox.DataSource = this.rkFoundationTypeBindingSource;
            this.foundationComboBox.DisplayMember = "Code";
            this.foundationComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.foundationComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.foundationComboBox.FormattingEnabled = true;
            this.foundationComboBox.Location = new System.Drawing.Point(425, 204);
            this.foundationComboBox.Name = "foundationComboBox";
            this.foundationComboBox.Size = new System.Drawing.Size(346, 21);
            this.foundationComboBox.TabIndex = 26;
            this.foundationComboBox.ValueMember = "ID";
            this.foundationComboBox.SelectedIndexChanged += new System.EventHandler(this.foundationComboBox_SelectedIndexChanged);
            // 
            // rkFoundationTypeBindingSource
            // 
            this.rkFoundationTypeBindingSource.DataMember = "rk_FoundationType";
            this.rkFoundationTypeBindingSource.DataSource = this.dataSet1;
            // 
            // segmentLabel
            // 
            this.segmentLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.segmentLabel.Location = new System.Drawing.Point(425, 300);
            this.segmentLabel.Name = "segmentLabel";
            this.segmentLabel.Size = new System.Drawing.Size(130, 15);
            this.segmentLabel.TabIndex = 7;
            this.segmentLabel.Text = "Segment";
            this.segmentLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // scopeLabel
            // 
            this.scopeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scopeLabel.Location = new System.Drawing.Point(425, 144);
            this.scopeLabel.Name = "scopeLabel";
            this.scopeLabel.Size = new System.Drawing.Size(130, 15);
            this.scopeLabel.TabIndex = 10;
            this.scopeLabel.Text = "Scope";
            this.scopeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // segmentComboBox
            // 
            this.segmentComboBox.DataSource = this.rkSegmentBindingSource;
            this.segmentComboBox.DisplayMember = "Segment";
            this.segmentComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.segmentComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.segmentComboBox.FormattingEnabled = true;
            this.segmentComboBox.Location = new System.Drawing.Point(425, 318);
            this.segmentComboBox.Name = "segmentComboBox";
            this.segmentComboBox.Size = new System.Drawing.Size(346, 21);
            this.segmentComboBox.TabIndex = 29;
            this.segmentComboBox.ValueMember = "ID";
            // 
            // rkSegmentBindingSource
            // 
            this.rkSegmentBindingSource.DataMember = "rk_Segment";
            this.rkSegmentBindingSource.DataSource = this.dataSet1;
            // 
            // scopeComboBox
            // 
            this.scopeComboBox.DataSource = this.rkscopeBindingSource;
            this.scopeComboBox.DisplayMember = "scope";
            this.scopeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.scopeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scopeComboBox.FormattingEnabled = true;
            this.scopeComboBox.Location = new System.Drawing.Point(425, 162);
            this.scopeComboBox.Name = "scopeComboBox";
            this.scopeComboBox.Size = new System.Drawing.Size(346, 21);
            this.scopeComboBox.TabIndex = 25;
            this.scopeComboBox.ValueMember = "ID";
            // 
            // rkscopeBindingSource
            // 
            this.rkscopeBindingSource.DataMember = "rk_scope";
            this.rkscopeBindingSource.DataSource = this.dataSet1;
            // 
            // wtgTypeLabel
            // 
            this.wtgTypeLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wtgTypeLabel.Location = new System.Drawing.Point(425, 342);
            this.wtgTypeLabel.Name = "wtgTypeLabel";
            this.wtgTypeLabel.Size = new System.Drawing.Size(130, 15);
            this.wtgTypeLabel.TabIndex = 8;
            this.wtgTypeLabel.Text = "Type of WTG";
            this.wtgTypeLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // wtgTypeComboBox
            // 
            this.wtgTypeComboBox.DataSource = this.wTGtypeBindingSource;
            this.wtgTypeComboBox.DisplayMember = "Name";
            this.wtgTypeComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.wtgTypeComboBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.wtgTypeComboBox.FormattingEnabled = true;
            this.wtgTypeComboBox.Location = new System.Drawing.Point(425, 360);
            this.wtgTypeComboBox.Name = "wtgTypeComboBox";
            this.wtgTypeComboBox.Size = new System.Drawing.Size(346, 21);
            this.wtgTypeComboBox.TabIndex = 31;
            this.wtgTypeComboBox.ValueMember = "ID";
            // 
            // wTGtypeBindingSource
            // 
            this.wTGtypeBindingSource.DataMember = "WTGtype";
            this.wTGtypeBindingSource.DataSource = this.dataSet1;
            // 
            // LoAIDLabel
            // 
            this.LoAIDLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoAIDLabel.Location = new System.Drawing.Point(425, 72);
            this.LoAIDLabel.Name = "LoAIDLabel";
            this.LoAIDLabel.Size = new System.Drawing.Size(130, 15);
            this.LoAIDLabel.TabIndex = 2;
            this.LoAIDLabel.Text = "LoA ID";
            this.LoAIDLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // LoaIDTextBox
            // 
            this.LoaIDTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.LoaIDTextBox.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.LoaIDTextBox.Location = new System.Drawing.Point(425, 90);
            this.LoaIDTextBox.Multiline = true;
            this.LoaIDTextBox.Name = "LoaIDTextBox";
            this.LoaIDTextBox.Size = new System.Drawing.Size(346, 21);
            this.LoaIDTextBox.TabIndex = 21;
            // 
            // projectSpecificDataLabel
            // 
            this.projectSpecificDataLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.projectSpecificDataLabel.AutoSize = true;
            this.projectSpecificDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectSpecificDataLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.projectSpecificDataLabel.Location = new System.Drawing.Point(26, 8);
            this.projectSpecificDataLabel.Name = "projectSpecificDataLabel";
            this.projectSpecificDataLabel.Size = new System.Drawing.Size(128, 13);
            this.projectSpecificDataLabel.TabIndex = 42;
            this.projectSpecificDataLabel.Text = "Project Specific Data";
            // 
            // projectPersonalDataLabel
            // 
            this.projectPersonalDataLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.projectPersonalDataLabel.AutoSize = true;
            this.projectPersonalDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectPersonalDataLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.projectPersonalDataLabel.Location = new System.Drawing.Point(26, 122);
            this.projectPersonalDataLabel.Name = "projectPersonalDataLabel";
            this.projectPersonalDataLabel.Size = new System.Drawing.Size(131, 13);
            this.projectPersonalDataLabel.TabIndex = 43;
            this.projectPersonalDataLabel.Text = "Project Personal Data";
            // 
            // projectOrderDataLabel
            // 
            this.projectOrderDataLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.projectOrderDataLabel.AutoSize = true;
            this.projectOrderDataLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectOrderDataLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.projectOrderDataLabel.Location = new System.Drawing.Point(26, 278);
            this.projectOrderDataLabel.Name = "projectOrderDataLabel";
            this.projectOrderDataLabel.Size = new System.Drawing.Size(113, 13);
            this.projectOrderDataLabel.TabIndex = 44;
            this.projectOrderDataLabel.Text = "Project Order Data";
            // 
            // projectCostsLabel
            // 
            this.projectCostsLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.projectCostsLabel.AutoSize = true;
            this.projectCostsLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectCostsLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.projectCostsLabel.Location = new System.Drawing.Point(26, 392);
            this.projectCostsLabel.Name = "projectCostsLabel";
            this.projectCostsLabel.Size = new System.Drawing.Size(82, 13);
            this.projectCostsLabel.TabIndex = 45;
            this.projectCostsLabel.Text = "Project Costs";
            // 
            // scopeLocationLabel
            // 
            this.scopeLocationLabel.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.scopeLocationLabel.AutoSize = true;
            this.scopeLocationLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.scopeLocationLabel.ForeColor = System.Drawing.SystemColors.ButtonShadow;
            this.scopeLocationLabel.Location = new System.Drawing.Point(425, 122);
            this.scopeLocationLabel.Name = "scopeLocationLabel";
            this.scopeLocationLabel.Size = new System.Drawing.Size(107, 13);
            this.scopeLocationLabel.TabIndex = 46;
            this.scopeLocationLabel.Text = "Scope && Location";
            // 
            // insertProjectButton
            // 
            this.insertProjectButton.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.insertProjectButton.Location = new System.Drawing.Point(835, 543);
            this.insertProjectButton.Name = "insertProjectButton";
            this.insertProjectButton.Size = new System.Drawing.Size(88, 62);
            this.insertProjectButton.TabIndex = 47;
            this.insertProjectButton.Text = "GO!";
            this.insertProjectButton.UseVisualStyleBackColor = true;
            this.insertProjectButton.Click += new System.EventHandler(this.insertProjectButton_Click);
            // 
            // projectOwnerLabel
            // 
            this.projectOwnerLabel.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.projectOwnerLabel.Location = new System.Drawing.Point(425, 30);
            this.projectOwnerLabel.Name = "projectOwnerLabel";
            this.projectOwnerLabel.Size = new System.Drawing.Size(130, 15);
            this.projectOwnerLabel.TabIndex = 48;
            this.projectOwnerLabel.Text = "Project Owner";
            this.projectOwnerLabel.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // projectOwnerComboBox
            // 
            this.projectOwnerComboBox.DataSource = this.rkUsersListviewBindingSource1;
            this.projectOwnerComboBox.DisplayMember = "LastName";
            this.projectOwnerComboBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.projectOwnerComboBox.FormattingEnabled = true;
            this.projectOwnerComboBox.Location = new System.Drawing.Point(425, 48);
            this.projectOwnerComboBox.Name = "projectOwnerComboBox";
            this.projectOwnerComboBox.Size = new System.Drawing.Size(346, 21);
            this.projectOwnerComboBox.TabIndex = 19;
            this.projectOwnerComboBox.ValueMember = "ID";
            // 
            // rkUsersListviewBindingSource1
            // 
            this.rkUsersListviewBindingSource1.DataMember = "rk_UsersList_view";
            this.rkUsersListviewBindingSource1.DataSource = this.dataSet1;
            // 
            // tocTextBox
            // 
            this.tocTextBox.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tocTextBox.Location = new System.Drawing.Point(26, 318);
            this.tocTextBox.Name = "tocTextBox";
            this.tocTextBox.Size = new System.Drawing.Size(346, 20);
            this.tocTextBox.TabIndex = 28;
            // 
            // dataSet1BindingSource
            // 
            this.dataSet1BindingSource.DataSource = this.dataSet1;
            this.dataSet1BindingSource.Position = 0;
            // 
            // new_project_viewTableAdapter
            // 
            this.new_project_viewTableAdapter.ClearBeforeFill = true;
            // 
            // rk_scopeTableAdapter
            // 
            this.rk_scopeTableAdapter.ClearBeforeFill = true;
            // 
            // rk_FoundationTypeTableAdapter
            // 
            this.rk_FoundationTypeTableAdapter.ClearBeforeFill = true;
            // 
            // rk_PreAssemblyHarbourTableAdapter
            // 
            this.rk_PreAssemblyHarbourTableAdapter.ClearBeforeFill = true;
            // 
            // rk_SegmentTableAdapter
            // 
            this.rk_SegmentTableAdapter.ClearBeforeFill = true;
            // 
            // wTGtypeTableAdapter
            // 
            this.wTGtypeTableAdapter.ClearBeforeFill = true;
            // 
            // rk_CurrencyNameTableAdapter
            // 
            this.rk_CurrencyNameTableAdapter.ClearBeforeFill = true;
            // 
            // rkusersBindingSource
            // 
            this.rkusersBindingSource.DataMember = "rk_users";
            this.rkusersBindingSource.DataSource = this.dataSet1;
            // 
            // rk_usersTableAdapter
            // 
            this.rk_usersTableAdapter.ClearBeforeFill = true;
            // 
            // rkUsersListviewBindingSource
            // 
            this.rkUsersListviewBindingSource.DataMember = "rk_UsersList_view";
            this.rkUsersListviewBindingSource.DataSource = this.dataSet1;
            // 
            // rk_UsersList_viewTableAdapter
            // 
            this.rk_UsersList_viewTableAdapter.ClearBeforeFill = true;
            // 
            // dataSet11
            // 
            this.dataSet11.DataSetName = "DataSet1";
            this.dataSet11.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // tabController
            // 
            this.tabController.Controls.Add(this.projectDataTab);
            this.tabController.Controls.Add(this.portfolioReportsTab);
            this.tabController.Controls.Add(this.createProjectTab);
            this.tabController.Controls.Add(this.entryCurTab);
            this.tabController.Controls.Add(this.diCatTab);
            this.tabController.Controls.Add(this.nccTab);
            this.tabController.Controls.Add(this.projectOwnershipTab);
            this.tabController.Controls.Add(this.orgUnitTab);
            this.tabController.Controls.Add(this.wtgTypeTab);
            this.tabController.Controls.Add(this.ownerTab);
            this.tabController.Controls.Add(this.usersTab);
            this.tabController.Controls.Add(this.transfSalesProjTab);
            this.tabController.Dock = System.Windows.Forms.DockStyle.Fill;
            this.tabController.Location = new System.Drawing.Point(275, 41);
            this.tabController.Name = "tabController";
            this.tabController.SelectedIndex = 0;
            this.tabController.Size = new System.Drawing.Size(966, 725);
            this.tabController.TabIndex = 3;
            // 
            // projectDataTab
            // 
            this.projectDataTab.Controls.Add(this.projectsPanel);
            this.projectDataTab.Location = new System.Drawing.Point(4, 22);
            this.projectDataTab.Name = "projectDataTab";
            this.projectDataTab.Padding = new System.Windows.Forms.Padding(3);
            this.projectDataTab.Size = new System.Drawing.Size(958, 699);
            this.projectDataTab.TabIndex = 0;
            this.projectDataTab.Text = "Projects";
            this.projectDataTab.UseVisualStyleBackColor = true;
            // 
            // portfolioReportsTab
            // 
            this.portfolioReportsTab.Controls.Add(this.portfolioPanel);
            this.portfolioReportsTab.Location = new System.Drawing.Point(4, 22);
            this.portfolioReportsTab.Name = "portfolioReportsTab";
            this.portfolioReportsTab.Padding = new System.Windows.Forms.Padding(3);
            this.portfolioReportsTab.Size = new System.Drawing.Size(958, 699);
            this.portfolioReportsTab.TabIndex = 1;
            this.portfolioReportsTab.Text = "Portfolio Reports";
            this.portfolioReportsTab.UseVisualStyleBackColor = true;
            // 
            // createProjectTab
            // 
            this.createProjectTab.Controls.Add(this.createProjectPanel);
            this.createProjectTab.Location = new System.Drawing.Point(4, 22);
            this.createProjectTab.Name = "createProjectTab";
            this.createProjectTab.Padding = new System.Windows.Forms.Padding(3);
            this.createProjectTab.Size = new System.Drawing.Size(958, 699);
            this.createProjectTab.TabIndex = 2;
            this.createProjectTab.Text = "Create Project";
            this.createProjectTab.UseVisualStyleBackColor = true;
            // 
            // entryCurTab
            // 
            this.entryCurTab.Controls.Add(this.panel1);
            this.entryCurTab.Controls.Add(this.entryCurList);
            this.entryCurTab.Location = new System.Drawing.Point(4, 22);
            this.entryCurTab.Name = "entryCurTab";
            this.entryCurTab.Padding = new System.Windows.Forms.Padding(3);
            this.entryCurTab.Size = new System.Drawing.Size(958, 699);
            this.entryCurTab.TabIndex = 3;
            this.entryCurTab.Text = "Entry Currency";
            this.entryCurTab.UseVisualStyleBackColor = true;
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.entryCurrInsertButton);
            this.panel1.Controls.Add(this.codeEntryTextBox);
            this.panel1.Controls.Add(this.countryEntryTextBox);
            this.panel1.Controls.Add(this.label2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Right;
            this.panel1.Location = new System.Drawing.Point(488, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(467, 693);
            this.panel1.TabIndex = 1;
            // 
            // entryCurrInsertButton
            // 
            this.entryCurrInsertButton.Location = new System.Drawing.Point(143, 276);
            this.entryCurrInsertButton.Name = "entryCurrInsertButton";
            this.entryCurrInsertButton.Size = new System.Drawing.Size(180, 25);
            this.entryCurrInsertButton.TabIndex = 4;
            this.entryCurrInsertButton.Text = "INSERT";
            this.entryCurrInsertButton.UseVisualStyleBackColor = true;
            this.entryCurrInsertButton.Click += new System.EventHandler(this.entryCurrInsertButton_Click);
            // 
            // codeEntryTextBox
            // 
            this.codeEntryTextBox.Location = new System.Drawing.Point(108, 224);
            this.codeEntryTextBox.Name = "codeEntryTextBox";
            this.codeEntryTextBox.Size = new System.Drawing.Size(250, 20);
            this.codeEntryTextBox.TabIndex = 3;
            // 
            // countryEntryTextBox
            // 
            this.countryEntryTextBox.Location = new System.Drawing.Point(107, 181);
            this.countryEntryTextBox.Name = "countryEntryTextBox";
            this.countryEntryTextBox.Size = new System.Drawing.Size(250, 20);
            this.countryEntryTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(105, 206);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Code";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(105, 165);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(50, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Country";
            // 
            // entryCurList
            // 
            this.entryCurList.Controls.Add(this.entryCurrUpdateBtn);
            this.entryCurList.Controls.Add(this.entryCurData);
            this.entryCurList.Dock = System.Windows.Forms.DockStyle.Left;
            this.entryCurList.Location = new System.Drawing.Point(3, 3);
            this.entryCurList.Name = "entryCurList";
            this.entryCurList.Size = new System.Drawing.Size(952, 693);
            this.entryCurList.TabIndex = 0;
            // 
            // entryCurrUpdateBtn
            // 
            this.entryCurrUpdateBtn.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.entryCurrUpdateBtn.Location = new System.Drawing.Point(151, 645);
            this.entryCurrUpdateBtn.Name = "entryCurrUpdateBtn";
            this.entryCurrUpdateBtn.Size = new System.Drawing.Size(180, 25);
            this.entryCurrUpdateBtn.TabIndex = 1;
            this.entryCurrUpdateBtn.Text = "UPDATE";
            this.entryCurrUpdateBtn.UseVisualStyleBackColor = true;
            this.entryCurrUpdateBtn.Click += new System.EventHandler(this.entryCurrUpdateBtn_Click);
            // 
            // entryCurData
            // 
            this.entryCurData.AllowUserToAddRows = false;
            this.entryCurData.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.entryCurData.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.entryCurData.Location = new System.Drawing.Point(3, 3);
            this.entryCurData.Name = "entryCurData";
            this.entryCurData.Size = new System.Drawing.Size(476, 613);
            this.entryCurData.TabIndex = 0;
            // 
            // diCatTab
            // 
            this.diCatTab.Location = new System.Drawing.Point(4, 22);
            this.diCatTab.Name = "diCatTab";
            this.diCatTab.Padding = new System.Windows.Forms.Padding(3);
            this.diCatTab.Size = new System.Drawing.Size(958, 699);
            this.diCatTab.TabIndex = 4;
            this.diCatTab.Text = "DI Category";
            this.diCatTab.UseVisualStyleBackColor = true;
            // 
            // nccTab
            // 
            this.nccTab.Location = new System.Drawing.Point(4, 22);
            this.nccTab.Name = "nccTab";
            this.nccTab.Padding = new System.Windows.Forms.Padding(3);
            this.nccTab.Size = new System.Drawing.Size(958, 699);
            this.nccTab.TabIndex = 5;
            this.nccTab.Text = "NCC";
            this.nccTab.UseVisualStyleBackColor = true;
            // 
            // projectOwnershipTab
            // 
            this.projectOwnershipTab.Location = new System.Drawing.Point(4, 22);
            this.projectOwnershipTab.Name = "projectOwnershipTab";
            this.projectOwnershipTab.Padding = new System.Windows.Forms.Padding(3);
            this.projectOwnershipTab.Size = new System.Drawing.Size(958, 699);
            this.projectOwnershipTab.TabIndex = 6;
            this.projectOwnershipTab.Text = "Project Ownership";
            this.projectOwnershipTab.UseVisualStyleBackColor = true;
            // 
            // orgUnitTab
            // 
            this.orgUnitTab.Location = new System.Drawing.Point(4, 22);
            this.orgUnitTab.Name = "orgUnitTab";
            this.orgUnitTab.Padding = new System.Windows.Forms.Padding(3);
            this.orgUnitTab.Size = new System.Drawing.Size(958, 699);
            this.orgUnitTab.TabIndex = 7;
            this.orgUnitTab.Text = "OriginatingUnit";
            this.orgUnitTab.UseVisualStyleBackColor = true;
            // 
            // wtgTypeTab
            // 
            this.wtgTypeTab.Location = new System.Drawing.Point(4, 22);
            this.wtgTypeTab.Name = "wtgTypeTab";
            this.wtgTypeTab.Padding = new System.Windows.Forms.Padding(3);
            this.wtgTypeTab.Size = new System.Drawing.Size(958, 699);
            this.wtgTypeTab.TabIndex = 9;
            this.wtgTypeTab.Text = "WTG Type";
            this.wtgTypeTab.UseVisualStyleBackColor = true;
            // 
            // ownerTab
            // 
            this.ownerTab.Location = new System.Drawing.Point(4, 22);
            this.ownerTab.Name = "ownerTab";
            this.ownerTab.Padding = new System.Windows.Forms.Padding(3);
            this.ownerTab.Size = new System.Drawing.Size(958, 699);
            this.ownerTab.TabIndex = 10;
            this.ownerTab.Text = "Owner";
            this.ownerTab.UseVisualStyleBackColor = true;
            // 
            // usersTab
            // 
            this.usersTab.Location = new System.Drawing.Point(4, 22);
            this.usersTab.Name = "usersTab";
            this.usersTab.Padding = new System.Windows.Forms.Padding(3);
            this.usersTab.Size = new System.Drawing.Size(958, 699);
            this.usersTab.TabIndex = 11;
            this.usersTab.Text = "Users";
            this.usersTab.UseVisualStyleBackColor = true;
            // 
            // transfSalesProjTab
            // 
            this.transfSalesProjTab.Location = new System.Drawing.Point(4, 22);
            this.transfSalesProjTab.Name = "transfSalesProjTab";
            this.transfSalesProjTab.Padding = new System.Windows.Forms.Padding(3);
            this.transfSalesProjTab.Size = new System.Drawing.Size(958, 699);
            this.transfSalesProjTab.TabIndex = 12;
            this.transfSalesProjTab.Text = "Transferred Sales Projects";
            this.transfSalesProjTab.UseVisualStyleBackColor = true;
            // 
            // rkCurrencyNameBindingSource1
            // 
            this.rkCurrencyNameBindingSource1.DataMember = "rk_CurrencyName";
            this.rkCurrencyNameBindingSource1.DataSource = this.dataSet1;
            // 
            // executionForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1241, 766);
            this.Controls.Add(this.tabController);
            this.Controls.Add(this.buttonPanel);
            this.Controls.Add(this.locationPanel);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.Name = "executionForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "executionForm";
            this.Load += new System.EventHandler(this.executionForm_Load);
            this.locationPanel.ResumeLayout(false);
            this.locationPanel.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.readPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.approvalPictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.writePictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.adminPictureBox)).EndInit();
            this.buttonPanel.ResumeLayout(false);
            this.projectsPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.projectsData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.newprojectviewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1)).EndInit();
            this.portfolioPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.portfolioRepGridView)).EndInit();
            this.createProjectPanel.ResumeLayout(false);
            this.createProjectPanel.PerformLayout();
            this.newProjectTableLayout.ResumeLayout(false);
            this.newProjectTableLayout.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.rkCurrencyNameBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkPreAssemblyHarbourBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkFoundationTypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkSegmentBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkscopeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.wTGtypeBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkUsersListviewBindingSource1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkusersBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkUsersListviewBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dataSet11)).EndInit();
            this.tabController.ResumeLayout(false);
            this.projectDataTab.ResumeLayout(false);
            this.portfolioReportsTab.ResumeLayout(false);
            this.createProjectTab.ResumeLayout(false);
            this.entryCurTab.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.entryCurList.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.entryCurData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.rkCurrencyNameBindingSource1)).EndInit();
            this.ResumeLayout(false);

        }

      

        #endregion

        private System.Windows.Forms.Panel locationPanel;
        private System.Windows.Forms.Panel buttonPanel;
        private System.Windows.Forms.Button projectsButton;
        private System.Windows.Forms.Label locationLabel;
        private System.Windows.Forms.Panel projectsPanel;
        private System.Windows.Forms.Label userLabel;
        private System.Windows.Forms.Button reportsButtons;
        private System.Windows.Forms.Button createProjectButton;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.Button guideButton;
        private System.Windows.Forms.Button settingsButton;
        private System.Windows.Forms.Button editButton;
        private System.Windows.Forms.DataGridView projectsData;
        private System.Windows.Forms.Panel portfolioPanel;
        private System.Windows.Forms.DataGridView portfolioRepGridView;
        private System.Windows.Forms.Button rologButton;
        private System.Windows.Forms.Button top20Button;
        private System.Windows.Forms.Button tableauButton;
        private System.Windows.Forms.Button riskContingencyButton;
        private System.Windows.Forms.Panel createProjectPanel;
        private System.Windows.Forms.Label projectNameLabel;
        private System.Windows.Forms.Label totalCostsLabel;
        private System.Windows.Forms.Label RUcostsLabel;
        private System.Windows.Forms.Label BUcostsLabel;
        private System.Windows.Forms.TextBox ruCostsTextBox;
        private System.Windows.Forms.TextBox buCostsTextBox;
        private System.Windows.Forms.TextBox totalProjectCostsTextBox;
        private System.Windows.Forms.TableLayoutPanel newProjectTableLayout;
        private System.Windows.Forms.TextBox wtgNoTextBox;
        private System.Windows.Forms.TextBox preparedByTextBox;
        private System.Windows.Forms.TextBox PMTextBox;
        private System.Windows.Forms.TextBox CPMTextBox;
        private System.Windows.Forms.TextBox projectIDTextBox;
        private System.Windows.Forms.TextBox projectNameTextBox;
        private System.Windows.Forms.Label wtgNoLabel;
        private System.Windows.Forms.Label TOCLabel;
        private System.Windows.Forms.Label preparedByLabel;
        private System.Windows.Forms.Label pmLabel;
        private System.Windows.Forms.Label cpmLabel;
        private System.Windows.Forms.Label projectIDLabel;
        private System.Windows.Forms.Label buEurLabel;
        private System.Windows.Forms.TextBox buRateTextBox;
        private System.Windows.Forms.Label ruEurLabel;
        private System.Windows.Forms.TextBox ruRateTextBox;
        private System.Windows.Forms.ComboBox ruCurComboBox;
        private System.Windows.Forms.TextBox LoaIDTextBox;
        private System.Windows.Forms.Label segmentLabel;
        private System.Windows.Forms.ComboBox buCurComboBox;
        private System.Windows.Forms.ComboBox segmentComboBox;
        private System.Windows.Forms.Label RUcurLabel;
        private System.Windows.Forms.ComboBox scopeComboBox;
        private System.Windows.Forms.Label BUCurLabel;
        private System.Windows.Forms.Label wtgTypeLabel;
        private System.Windows.Forms.ComboBox foundationComboBox;
        private System.Windows.Forms.ComboBox wtgTypeComboBox;
        private System.Windows.Forms.ComboBox portComboBox;
        private System.Windows.Forms.Label preassemblyLabel;
        private System.Windows.Forms.Label foundationLabel;
        private System.Windows.Forms.Label scopeLabel;
        private System.Windows.Forms.Label LoAIDLabel;
        private System.Windows.Forms.Label projectSpecificDataLabel;
        private System.Windows.Forms.Label projectPersonalDataLabel;
        private System.Windows.Forms.Label projectOrderDataLabel;
        private System.Windows.Forms.Label projectCostsLabel;
        private System.Windows.Forms.Label scopeLocationLabel;
        private System.Windows.Forms.Button transfSalesProjButton;
        private System.Windows.Forms.Button usersButton;
        private System.Windows.Forms.Button ownerButton;
        private System.Windows.Forms.Button wtgTypeButton;
        private System.Windows.Forms.Button orgUnitButton;
        private System.Windows.Forms.Button projectOwnerButton;
        private System.Windows.Forms.Button nccButton;
        private System.Windows.Forms.Button diCatButton;
        private System.Windows.Forms.Button entryCurButton;
        private System.Windows.Forms.PictureBox adminPictureBox;
        private System.Windows.Forms.PictureBox approvalPictureBox;
        private System.Windows.Forms.PictureBox writePictureBox;
        private System.Windows.Forms.PictureBox readPictureBox;
        private DataSet1 dataSet1;
        private System.Windows.Forms.BindingSource newprojectviewBindingSource;
        private DataSet1TableAdapters.new_project_viewTableAdapter new_project_viewTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn pnameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn segmentIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn scopeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn wtgDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn owneDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn sapDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDuserDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn iDProjectTypeDataGridViewTextBoxColumn;
        private System.Windows.Forms.BindingSource rkscopeBindingSource;
        private DataSet1TableAdapters.rk_scopeTableAdapter rk_scopeTableAdapter;
        private System.Windows.Forms.BindingSource rkFoundationTypeBindingSource;
        private DataSet1TableAdapters.rk_FoundationTypeTableAdapter rk_FoundationTypeTableAdapter;
        private System.Windows.Forms.BindingSource rkPreAssemblyHarbourBindingSource;
        private DataSet1TableAdapters.rk_PreAssemblyHarbourTableAdapter rk_PreAssemblyHarbourTableAdapter;
        private System.Windows.Forms.BindingSource rkSegmentBindingSource;
        private DataSet1TableAdapters.rk_SegmentTableAdapter rk_SegmentTableAdapter;
        private System.Windows.Forms.BindingSource wTGtypeBindingSource;
        private DataSet1TableAdapters.WTGtypeTableAdapter wTGtypeTableAdapter;
        private System.Windows.Forms.BindingSource rkCurrencyNameBindingSource;
        private DataSet1TableAdapters.rk_CurrencyNameTableAdapter rk_CurrencyNameTableAdapter;
        private System.Windows.Forms.Button insertProjectButton;
        private System.Windows.Forms.Label projectOwnerLabel;
        private System.Windows.Forms.ComboBox projectOwnerComboBox;
        private System.Windows.Forms.BindingSource rkusersBindingSource;
        private DataSet1TableAdapters.rk_usersTableAdapter rk_usersTableAdapter;
        private System.Windows.Forms.BindingSource rkUsersListviewBindingSource;
        private DataSet1TableAdapters.rk_UsersList_viewTableAdapter rk_UsersList_viewTableAdapter;
        private System.Windows.Forms.BindingSource dataSet1BindingSource;
        private DataSet1 dataSet11;
        private System.Windows.Forms.BindingSource rkUsersListviewBindingSource1;
        private System.Windows.Forms.DateTimePicker tocTextBox;
        private TabControl tabController;
        private TabPage projectDataTab;
        private TabPage portfolioReportsTab;
        private TabPage createProjectTab;
        private TabPage entryCurTab;
        private TabPage diCatTab;
        private TabPage nccTab;
        private TabPage projectOwnershipTab;
        private TabPage orgUnitTab;
        private TabPage wtgTypeTab;
        private TabPage ownerTab;
        private TabPage usersTab;
        private TabPage transfSalesProjTab;
        private Panel panel1;
        private Panel entryCurList;
        private DataGridView entryCurData;
        private BindingSource rkCurrencyNameBindingSource1;
        private Button entryCurrUpdateBtn;
        private Button entryCurrInsertButton;
        private TextBox codeEntryTextBox;
        private TextBox countryEntryTextBox;
        private Label label2;
        private Label label1;
    }
}