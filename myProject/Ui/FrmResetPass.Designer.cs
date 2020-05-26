namespace myProject.Ui
{
    partial class FrmResetPass
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FrmResetPass));
            this.panel1 = new System.Windows.Forms.Panel();
            this.pictureBoxClose = new System.Windows.Forms.PictureBox();
            this.lblTop = new System.Windows.Forms.Label();
            this.txtuserName = new System.Windows.Forms.TextBox();
            this.lbluserName = new System.Windows.Forms.Label();
            this.cmbuserType = new System.Windows.Forms.ComboBox();
            this.lbluserType = new System.Windows.Forms.Label();
            this.lblMotherName = new System.Windows.Forms.Label();
            this.txtMotherName = new System.Windows.Forms.TextBox();
            this.lblNewPass = new System.Windows.Forms.Label();
            this.txtNewPass = new System.Windows.Forms.TextBox();
            this.lblRepeatPass = new System.Windows.Forms.Label();
            this.txtRepeatPass = new System.Windows.Forms.TextBox();
            this.btnreset = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSeaGreen;
            this.panel1.Controls.Add(this.pictureBoxClose);
            this.panel1.Controls.Add(this.lblTop);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(547, 45);
            this.panel1.TabIndex = 4;
            // 
            // pictureBoxClose
            // 
            this.pictureBoxClose.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxClose.Image")));
            this.pictureBoxClose.Location = new System.Drawing.Point(494, 0);
            this.pictureBoxClose.Name = "pictureBoxClose";
            this.pictureBoxClose.Size = new System.Drawing.Size(51, 45);
            this.pictureBoxClose.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBoxClose.TabIndex = 1;
            this.pictureBoxClose.TabStop = false;
            this.pictureBoxClose.Click += new System.EventHandler(this.pictureBoxClose_Click);
            // 
            // lblTop
            // 
            this.lblTop.AutoSize = true;
            this.lblTop.BackColor = System.Drawing.Color.LightSeaGreen;
            this.lblTop.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTop.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.lblTop.Location = new System.Drawing.Point(178, 9);
            this.lblTop.Name = "lblTop";
            this.lblTop.Size = new System.Drawing.Size(180, 32);
            this.lblTop.TabIndex = 0;
            this.lblTop.Text = "Reset PassWord";
            // 
            // txtuserName
            // 
            this.txtuserName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtuserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtuserName.Location = new System.Drawing.Point(197, 77);
            this.txtuserName.Name = "txtuserName";
            this.txtuserName.Size = new System.Drawing.Size(243, 34);
            this.txtuserName.TabIndex = 6;
            // 
            // lbluserName
            // 
            this.lbluserName.AutoSize = true;
            this.lbluserName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserName.Location = new System.Drawing.Point(29, 77);
            this.lbluserName.Name = "lbluserName";
            this.lbluserName.Size = new System.Drawing.Size(103, 28);
            this.lbluserName.TabIndex = 5;
            this.lbluserName.Text = "UserName";
            // 
            // cmbuserType
            // 
            this.cmbuserType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmbuserType.FormattingEnabled = true;
            this.cmbuserType.Items.AddRange(new object[] {
            "User",
            "Admin"});
            this.cmbuserType.Location = new System.Drawing.Point(197, 132);
            this.cmbuserType.Name = "cmbuserType";
            this.cmbuserType.Size = new System.Drawing.Size(243, 36);
            this.cmbuserType.TabIndex = 8;
            // 
            // lbluserType
            // 
            this.lbluserType.AutoSize = true;
            this.lbluserType.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lbluserType.Location = new System.Drawing.Point(29, 134);
            this.lbluserType.Name = "lbluserType";
            this.lbluserType.Size = new System.Drawing.Size(92, 28);
            this.lbluserType.TabIndex = 7;
            this.lbluserType.Text = "UserType";
            // 
            // lblMotherName
            // 
            this.lblMotherName.AutoSize = true;
            this.lblMotherName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblMotherName.Location = new System.Drawing.Point(29, 195);
            this.lblMotherName.Name = "lblMotherName";
            this.lblMotherName.Size = new System.Drawing.Size(129, 28);
            this.lblMotherName.TabIndex = 5;
            this.lblMotherName.Text = "MotherName";
            // 
            // txtMotherName
            // 
            this.txtMotherName.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtMotherName.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtMotherName.Location = new System.Drawing.Point(197, 195);
            this.txtMotherName.Name = "txtMotherName";
            this.txtMotherName.Size = new System.Drawing.Size(243, 34);
            this.txtMotherName.TabIndex = 6;
            // 
            // lblNewPass
            // 
            this.lblNewPass.AutoSize = true;
            this.lblNewPass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblNewPass.Location = new System.Drawing.Point(29, 247);
            this.lblNewPass.Name = "lblNewPass";
            this.lblNewPass.Size = new System.Drawing.Size(137, 28);
            this.lblNewPass.TabIndex = 5;
            this.lblNewPass.Text = "New Password";
            // 
            // txtNewPass
            // 
            this.txtNewPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtNewPass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtNewPass.Location = new System.Drawing.Point(197, 247);
            this.txtNewPass.Name = "txtNewPass";
            this.txtNewPass.Size = new System.Drawing.Size(243, 34);
            this.txtNewPass.TabIndex = 6;
            this.txtNewPass.TextChanged += new System.EventHandler(this.textBox2_TextChanged);
            // 
            // lblRepeatPass
            // 
            this.lblRepeatPass.AutoSize = true;
            this.lblRepeatPass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblRepeatPass.Location = new System.Drawing.Point(29, 317);
            this.lblRepeatPass.Name = "lblRepeatPass";
            this.lblRepeatPass.Size = new System.Drawing.Size(162, 28);
            this.lblRepeatPass.TabIndex = 5;
            this.lblRepeatPass.Text = "Repeat PassWord";
            // 
            // txtRepeatPass
            // 
            this.txtRepeatPass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.txtRepeatPass.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txtRepeatPass.Location = new System.Drawing.Point(197, 317);
            this.txtRepeatPass.Name = "txtRepeatPass";
            this.txtRepeatPass.Size = new System.Drawing.Size(243, 34);
            this.txtRepeatPass.TabIndex = 6;
            // 
            // btnreset
            // 
            this.btnreset.BackColor = System.Drawing.Color.Brown;
            this.btnreset.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnreset.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnreset.ForeColor = System.Drawing.SystemColors.ButtonHighlight;
            this.btnreset.Location = new System.Drawing.Point(197, 377);
            this.btnreset.Name = "btnreset";
            this.btnreset.Size = new System.Drawing.Size(243, 64);
            this.btnreset.TabIndex = 9;
            this.btnreset.Text = "Reset";
            this.btnreset.UseVisualStyleBackColor = false;
            this.btnreset.Click += new System.EventHandler(this.btnreset_Click);
            // 
            // FrmResetPass
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.ClientSize = new System.Drawing.Size(547, 468);
            this.Controls.Add(this.btnreset);
            this.Controls.Add(this.cmbuserType);
            this.Controls.Add(this.lbluserType);
            this.Controls.Add(this.txtRepeatPass);
            this.Controls.Add(this.lblRepeatPass);
            this.Controls.Add(this.txtNewPass);
            this.Controls.Add(this.lblNewPass);
            this.Controls.Add(this.txtMotherName);
            this.Controls.Add(this.lblMotherName);
            this.Controls.Add(this.txtuserName);
            this.Controls.Add(this.lbluserName);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "FrmResetPass";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "FrmResetPass";
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxClose)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.PictureBox pictureBoxClose;
        private System.Windows.Forms.Label lblTop;
        private System.Windows.Forms.TextBox txtuserName;
        private System.Windows.Forms.Label lbluserName;
        private System.Windows.Forms.ComboBox cmbuserType;
        private System.Windows.Forms.Label lbluserType;
        private System.Windows.Forms.Label lblMotherName;
        private System.Windows.Forms.TextBox txtMotherName;
        private System.Windows.Forms.Label lblNewPass;
        private System.Windows.Forms.TextBox txtNewPass;
        private System.Windows.Forms.Label lblRepeatPass;
        private System.Windows.Forms.TextBox txtRepeatPass;
        private System.Windows.Forms.Button btnreset;
    }
}