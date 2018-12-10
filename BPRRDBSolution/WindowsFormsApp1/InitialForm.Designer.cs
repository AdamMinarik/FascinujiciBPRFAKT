namespace WindowsFormsApp1
{
    partial class InitialForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialForm));
            this.execUser = new System.Windows.Forms.Button();
            this.salesUser = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            this.curVersionLabel = new System.Windows.Forms.Label();
            this.upToDateVersionLbl = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.timer2 = new System.Windows.Forms.Timer(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // execUser
            // 
            this.execUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.execUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.execUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(163)))), ((int)(((byte)(185)))));
            this.execUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(209)))), ((int)(((byte)(220)))));
            this.execUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.execUser.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.execUser.Location = new System.Drawing.Point(335, 25);
            this.execUser.Margin = new System.Windows.Forms.Padding(2);
            this.execUser.Name = "execUser";
            this.execUser.Size = new System.Drawing.Size(330, 140);
            this.execUser.TabIndex = 0;
            this.execUser.Text = "Execution Projects";
            this.execUser.UseVisualStyleBackColor = true;
            this.execUser.Click += new System.EventHandler(this.execUser_Click);
            // 
            // salesUser
            // 
            this.salesUser.Cursor = System.Windows.Forms.Cursors.UpArrow;
            this.salesUser.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(163)))), ((int)(((byte)(185)))));
            this.salesUser.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(209)))), ((int)(((byte)(220)))));
            this.salesUser.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.salesUser.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.salesUser.Location = new System.Drawing.Point(335, 184);
            this.salesUser.Margin = new System.Windows.Forms.Padding(2);
            this.salesUser.Name = "salesUser";
            this.salesUser.Size = new System.Drawing.Size(330, 140);
            this.salesUser.TabIndex = 1;
            this.salesUser.Text = "Sales Projects";
            this.salesUser.UseVisualStyleBackColor = true;
            this.salesUser.Click += new System.EventHandler(this.salesUser_Click);
            // 
            // quitButton
            // 
            this.quitButton.FlatAppearance.MouseDownBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(173)))), ((int)(((byte)(163)))), ((int)(((byte)(185)))));
            this.quitButton.FlatAppearance.MouseOverBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(214)))), ((int)(((byte)(209)))), ((int)(((byte)(220)))));
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.quitButton.Font = new System.Drawing.Font("Trebuchet MS", 12F);
            this.quitButton.Location = new System.Drawing.Point(375, 341);
            this.quitButton.Margin = new System.Windows.Forms.Padding(2);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(250, 110);
            this.quitButton.TabIndex = 2;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(240, 465);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(520, 90);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(235)))), ((int)(((byte)(232)))), ((int)(((byte)(238)))));
            this.panel1.Controls.Add(this.curVersionLabel);
            this.panel1.Controls.Add(this.upToDateVersionLbl);
            this.panel1.Controls.Add(this.quitButton);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.salesUser);
            this.panel1.Controls.Add(this.execUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(978, 584);
            this.panel1.TabIndex = 4;
            // 
            // curVersionLabel
            // 
            this.curVersionLabel.AutoSize = true;
            this.curVersionLabel.Location = new System.Drawing.Point(700, 25);
            this.curVersionLabel.Name = "curVersionLabel";
            this.curVersionLabel.Size = new System.Drawing.Size(19, 13);
            this.curVersionLabel.TabIndex = 5;
            this.curVersionLabel.Text = "v1";
            // 
            // upToDateVersionLbl
            // 
            this.upToDateVersionLbl.AutoSize = true;
            this.upToDateVersionLbl.Location = new System.Drawing.Point(823, 25);
            this.upToDateVersionLbl.Name = "upToDateVersionLbl";
            this.upToDateVersionLbl.Size = new System.Drawing.Size(104, 13);
            this.upToDateVersionLbl.TabIndex = 4;
            this.upToDateVersionLbl.Text = "upToDateVersionLbl";
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(978, 584);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(2);
            this.Name = "InitialForm";
            this.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Risk Database";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button execUser;
        private System.Windows.Forms.Button salesUser;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Timer timer2;
        private System.Windows.Forms.Label upToDateVersionLbl;
        private System.Windows.Forms.Label curVersionLabel;
    }
}

