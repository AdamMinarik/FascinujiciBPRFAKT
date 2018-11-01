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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(InitialForm));
            this.execUser = new System.Windows.Forms.Button();
            this.salesUser = new System.Windows.Forms.Button();
            this.quitButton = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.panel1 = new System.Windows.Forms.Panel();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // execUser
            // 
            this.execUser.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.execUser.Cursor = System.Windows.Forms.Cursors.Default;
            this.execUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.execUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.execUser.Location = new System.Drawing.Point(230, 25);
            this.execUser.Margin = new System.Windows.Forms.Padding(2);
            this.execUser.Name = "execUser";
            this.execUser.Size = new System.Drawing.Size(175, 78);
            this.execUser.TabIndex = 0;
            this.execUser.Text = "I am an Execution User";
            this.execUser.UseVisualStyleBackColor = true;
            this.execUser.Click += new System.EventHandler(this.execUser_Click);
            // 
            // salesUser
            // 
            this.salesUser.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.salesUser.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.salesUser.Location = new System.Drawing.Point(230, 107);
            this.salesUser.Margin = new System.Windows.Forms.Padding(2);
            this.salesUser.Name = "salesUser";
            this.salesUser.Size = new System.Drawing.Size(175, 78);
            this.salesUser.TabIndex = 1;
            this.salesUser.Text = "I am a Sales User";
            this.salesUser.UseVisualStyleBackColor = true;
            this.salesUser.Click += new System.EventHandler(this.salesUser_Click);
            // 
            // quitButton
            // 
            this.quitButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.quitButton.Font = new System.Drawing.Font("Microsoft Sans Serif", 7.875F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.quitButton.Location = new System.Drawing.Point(259, 194);
            this.quitButton.Margin = new System.Windows.Forms.Padding(2);
            this.quitButton.Name = "quitButton";
            this.quitButton.Size = new System.Drawing.Size(116, 52);
            this.quitButton.TabIndex = 2;
            this.quitButton.Text = "Quit";
            this.quitButton.UseVisualStyleBackColor = true;
            this.quitButton.Click += new System.EventHandler(this.quitButton_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.InitialImage")));
            this.pictureBox1.Location = new System.Drawing.Point(120, 267);
            this.pictureBox1.Margin = new System.Windows.Forms.Padding(2);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(387, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 3;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.quitButton);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.salesUser);
            this.panel1.Controls.Add(this.execUser);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Margin = new System.Windows.Forms.Padding(2);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(640, 379);
            this.panel1.TabIndex = 4;
            // 
            // InitialForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(640, 379);
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
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button execUser;
        private System.Windows.Forms.Button salesUser;
        private System.Windows.Forms.Button quitButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Panel panel1;
    }
}

