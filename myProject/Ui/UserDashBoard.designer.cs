namespace myProject
{
    partial class UserDashBoard
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
            this.menuStripTop = new System.Windows.Forms.MenuStrip();
            this.purhcaseToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.salesFormsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.inventoryToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.customerToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.lblLoggedinUser = new System.Windows.Forms.Label();
            this.lblLname = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.lblAppFName = new System.Windows.Forms.Label();
            this.lblUser = new System.Windows.Forms.Label();
            this.panelfooter = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.menuStripTop.SuspendLayout();
            this.panelfooter.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStripTop
            // 
            this.menuStripTop.ImageScalingSize = new System.Drawing.Size(24, 24);
            this.menuStripTop.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.purhcaseToolStripMenuItem,
            this.salesFormsToolStripMenuItem,
            this.inventoryToolStripMenuItem,
            this.customerToolStripMenuItem});
            this.menuStripTop.Location = new System.Drawing.Point(0, 0);
            this.menuStripTop.Name = "menuStripTop";
            this.menuStripTop.Size = new System.Drawing.Size(1260, 33);
            this.menuStripTop.TabIndex = 0;
            this.menuStripTop.Text = "menuStrip1";
            // 
            // purhcaseToolStripMenuItem
            // 
            this.purhcaseToolStripMenuItem.Name = "purhcaseToolStripMenuItem";
            this.purhcaseToolStripMenuItem.Size = new System.Drawing.Size(102, 29);
            this.purhcaseToolStripMenuItem.Text = "Purchcase";
            this.purhcaseToolStripMenuItem.Click += new System.EventHandler(this.purhcaseToolStripMenuItem_Click);
            // 
            // salesFormsToolStripMenuItem
            // 
            this.salesFormsToolStripMenuItem.Name = "salesFormsToolStripMenuItem";
            this.salesFormsToolStripMenuItem.Size = new System.Drawing.Size(69, 29);
            this.salesFormsToolStripMenuItem.Text = "Sales ";
            this.salesFormsToolStripMenuItem.Click += new System.EventHandler(this.salesFormsToolStripMenuItem_Click);
            // 
            // inventoryToolStripMenuItem
            // 
            this.inventoryToolStripMenuItem.Name = "inventoryToolStripMenuItem";
            this.inventoryToolStripMenuItem.Size = new System.Drawing.Size(99, 29);
            this.inventoryToolStripMenuItem.Text = "Inventory";
            this.inventoryToolStripMenuItem.Click += new System.EventHandler(this.inventoryToolStripMenuItem_Click);
            // 
            // customerToolStripMenuItem
            // 
            this.customerToolStripMenuItem.Name = "customerToolStripMenuItem";
            this.customerToolStripMenuItem.Size = new System.Drawing.Size(101, 29);
            this.customerToolStripMenuItem.Text = "Customer";
            this.customerToolStripMenuItem.Click += new System.EventHandler(this.customerToolStripMenuItem_Click);
            // 
            // lblLoggedinUser
            // 
            this.lblLoggedinUser.AutoSize = true;
            this.lblLoggedinUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLoggedinUser.ForeColor = System.Drawing.Color.ForestGreen;
            this.lblLoggedinUser.Location = new System.Drawing.Point(80, 51);
            this.lblLoggedinUser.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblLoggedinUser.Name = "lblLoggedinUser";
            this.lblLoggedinUser.Size = new System.Drawing.Size(17, 28);
            this.lblLoggedinUser.TabIndex = 3;
            this.lblLoggedinUser.Text = " ";
            // 
            // lblLname
            // 
            this.lblLname.AutoSize = true;
            this.lblLname.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblLname.Location = new System.Drawing.Point(874, 343);
            this.lblLname.Margin = new System.Windows.Forms.Padding(1, 0, 1, 0);
            this.lblLname.Name = "lblLname";
            this.lblLname.Size = new System.Drawing.Size(144, 54);
            this.lblLname.TabIndex = 4;
            this.lblLname.Text = "STORE";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI Semibold", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.MediumSeaGreen;
            this.label2.Location = new System.Drawing.Point(686, 397);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(458, 38);
            this.label2.TabIndex = 5;
            this.label2.Text = "Billing and Inventory Management";
            // 
            // lblAppFName
            // 
            this.lblAppFName.AutoSize = true;
            this.lblAppFName.Font = new System.Drawing.Font("Segoe UI", 20F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblAppFName.Location = new System.Drawing.Point(784, 343);
            this.lblAppFName.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.lblAppFName.Name = "lblAppFName";
            this.lblAppFName.Size = new System.Drawing.Size(101, 54);
            this.lblAppFName.TabIndex = 6;
            this.lblAppFName.Text = "ANY";
            // 
            // lblUser
            // 
            this.lblUser.AutoSize = true;
            this.lblUser.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblUser.Location = new System.Drawing.Point(19, 51);
            this.lblUser.Margin = new System.Windows.Forms.Padding(3, 0, 1, 0);
            this.lblUser.Name = "lblUser";
            this.lblUser.Size = new System.Drawing.Size(55, 28);
            this.lblUser.TabIndex = 7;
            this.lblUser.Text = "User:";
            // 
            // panelfooter
            // 
            this.panelfooter.BackColor = System.Drawing.Color.Teal;
            this.panelfooter.Controls.Add(this.label1);
            this.panelfooter.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelfooter.Location = new System.Drawing.Point(0, 568);
            this.panelfooter.Name = "panelfooter";
            this.panelfooter.Size = new System.Drawing.Size(1260, 41);
            this.panelfooter.TabIndex = 8;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(788, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(201, 28);
            this.label1.TabIndex = 0;
            this.label1.Text = "Developed By SHADY";
            // 
            // UserDashBoard
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1260, 609);
            this.Controls.Add(this.panelfooter);
            this.Controls.Add(this.lblLoggedinUser);
            this.Controls.Add(this.lblLname);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lblAppFName);
            this.Controls.Add(this.lblUser);
            this.Controls.Add(this.menuStripTop);
            this.MainMenuStrip = this.menuStripTop;
            this.Name = "UserDashBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "User DashBoard";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.UserDashBoard_FormClosed);
            this.Load += new System.EventHandler(this.UserDashBoard_Load);
            this.menuStripTop.ResumeLayout(false);
            this.menuStripTop.PerformLayout();
            this.panelfooter.ResumeLayout(false);
            this.panelfooter.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStripTop;
        private System.Windows.Forms.ToolStripMenuItem purhcaseToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem salesFormsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem inventoryToolStripMenuItem;
        private System.Windows.Forms.Label lblLoggedinUser;
        private System.Windows.Forms.Label lblLname;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label lblAppFName;
        private System.Windows.Forms.Label lblUser;
        private System.Windows.Forms.Panel panelfooter;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ToolStripMenuItem customerToolStripMenuItem;
    }
}