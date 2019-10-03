namespace EatAppDesktop.UI
{
    partial class MainScreen
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
            this.button_ChangeAuth = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.button_ManageAcc = new System.Windows.Forms.Button();
            this.label_ConnectedTo = new System.Windows.Forms.Label();
            this.label_UserInfo = new System.Windows.Forms.Label();
            this.DataGridView_Fnb = new System.Windows.Forms.DataGridView();
            this.button_Fnb_Reload = new System.Windows.Forms.Button();
            this.label_Fnb_ReloadTime = new System.Windows.Forms.Label();
            this.button_Fnb_AddNew = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.button_Fnb_Review = new System.Windows.Forms.Button();
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage_Fnb = new System.Windows.Forms.TabPage();
            this.tabPage_User = new System.Windows.Forms.TabPage();
            this.DataGridView_User = new System.Windows.Forms.DataGridView();
            this.button_User_Reload = new System.Windows.Forms.Button();
            this.button_User_AddNew = new System.Windows.Forms.Button();
            this.label_User_ReloadTime = new System.Windows.Forms.Label();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Fnb)).BeginInit();
            this.tabControl1.SuspendLayout();
            this.tabPage_Fnb.SuspendLayout();
            this.tabPage_User.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_User)).BeginInit();
            this.SuspendLayout();
            // 
            // button_ChangeAuth
            // 
            this.button_ChangeAuth.Location = new System.Drawing.Point(678, 8);
            this.button_ChangeAuth.Name = "button_ChangeAuth";
            this.button_ChangeAuth.Size = new System.Drawing.Size(75, 27);
            this.button_ChangeAuth.TabIndex = 0;
            this.button_ChangeAuth.Text = "Login";
            this.button_ChangeAuth.UseVisualStyleBackColor = true;
            this.button_ChangeAuth.Click += new System.EventHandler(this.button_ChangeAuth_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.PowderBlue;
            this.panel1.Controls.Add(this.button_ManageAcc);
            this.panel1.Controls.Add(this.label_ConnectedTo);
            this.panel1.Controls.Add(this.label_UserInfo);
            this.panel1.Controls.Add(this.button_ChangeAuth);
            this.panel1.Location = new System.Drawing.Point(-2, -1);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(765, 100);
            this.panel1.TabIndex = 1;
            // 
            // button_ManageAcc
            // 
            this.button_ManageAcc.Location = new System.Drawing.Point(601, 8);
            this.button_ManageAcc.Name = "button_ManageAcc";
            this.button_ManageAcc.Size = new System.Drawing.Size(75, 27);
            this.button_ManageAcc.TabIndex = 3;
            this.button_ManageAcc.Text = "Manage";
            this.button_ManageAcc.UseVisualStyleBackColor = true;
            this.button_ManageAcc.Visible = false;
            this.button_ManageAcc.Click += new System.EventHandler(this.button_ManageAcc_Click);
            // 
            // label_ConnectedTo
            // 
            this.label_ConnectedTo.Location = new System.Drawing.Point(14, 24);
            this.label_ConnectedTo.Name = "label_ConnectedTo";
            this.label_ConnectedTo.Size = new System.Drawing.Size(269, 39);
            this.label_ConnectedTo.TabIndex = 2;
            this.label_ConnectedTo.Text = "...";
            this.label_ConnectedTo.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // label_UserInfo
            // 
            this.label_UserInfo.Location = new System.Drawing.Point(484, 36);
            this.label_UserInfo.Name = "label_UserInfo";
            this.label_UserInfo.Size = new System.Drawing.Size(269, 61);
            this.label_UserInfo.TabIndex = 1;
            this.label_UserInfo.Text = "...";
            this.label_UserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // DataGridView_Fnb
            // 
            this.DataGridView_Fnb.AllowUserToAddRows = false;
            this.DataGridView_Fnb.AllowUserToDeleteRows = false;
            this.DataGridView_Fnb.BackgroundColor = System.Drawing.Color.LightGray;
            this.DataGridView_Fnb.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView_Fnb.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_Fnb.Location = new System.Drawing.Point(6, 38);
            this.DataGridView_Fnb.Name = "DataGridView_Fnb";
            this.DataGridView_Fnb.ReadOnly = true;
            this.DataGridView_Fnb.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGridView_Fnb.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_Fnb.Size = new System.Drawing.Size(723, 382);
            this.DataGridView_Fnb.TabIndex = 20;
            // 
            // button_Fnb_Reload
            // 
            this.button_Fnb_Reload.Location = new System.Drawing.Point(657, 5);
            this.button_Fnb_Reload.Name = "button_Fnb_Reload";
            this.button_Fnb_Reload.Size = new System.Drawing.Size(75, 27);
            this.button_Fnb_Reload.TabIndex = 4;
            this.button_Fnb_Reload.Text = "Reload";
            this.button_Fnb_Reload.UseVisualStyleBackColor = true;
            this.button_Fnb_Reload.Click += new System.EventHandler(this.button_Fnb_Reload_Click);
            // 
            // label_Fnb_ReloadTime
            // 
            this.label_Fnb_ReloadTime.Location = new System.Drawing.Point(210, 6);
            this.label_Fnb_ReloadTime.Name = "label_Fnb_ReloadTime";
            this.label_Fnb_ReloadTime.Size = new System.Drawing.Size(441, 25);
            this.label_Fnb_ReloadTime.TabIndex = 4;
            this.label_Fnb_ReloadTime.Text = "...";
            this.label_Fnb_ReloadTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // button_Fnb_AddNew
            // 
            this.button_Fnb_AddNew.Location = new System.Drawing.Point(92, 6);
            this.button_Fnb_AddNew.Name = "button_Fnb_AddNew";
            this.button_Fnb_AddNew.Size = new System.Drawing.Size(75, 27);
            this.button_Fnb_AddNew.TabIndex = 21;
            this.button_Fnb_AddNew.Text = "Add New";
            this.button_Fnb_AddNew.UseVisualStyleBackColor = true;
            this.button_Fnb_AddNew.Visible = false;
            this.button_Fnb_AddNew.Click += new System.EventHandler(this.button_Fnb_AddNew_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-2, 98);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(765, 8);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 22;
            this.progressBar1.Visible = false;
            // 
            // button_Fnb_Review
            // 
            this.button_Fnb_Review.Location = new System.Drawing.Point(6, 6);
            this.button_Fnb_Review.Name = "button_Fnb_Review";
            this.button_Fnb_Review.Size = new System.Drawing.Size(80, 27);
            this.button_Fnb_Review.TabIndex = 23;
            this.button_Fnb_Review.Text = "Review";
            this.button_Fnb_Review.UseVisualStyleBackColor = true;
            this.button_Fnb_Review.Click += new System.EventHandler(this.button_Fnb_Review_Click);
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage_Fnb);
            this.tabControl1.Controls.Add(this.tabPage_User);
            this.tabControl1.Location = new System.Drawing.Point(10, 112);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(743, 455);
            this.tabControl1.TabIndex = 24;
            // 
            // tabPage_Fnb
            // 
            this.tabPage_Fnb.Controls.Add(this.button_Fnb_Review);
            this.tabPage_Fnb.Controls.Add(this.DataGridView_Fnb);
            this.tabPage_Fnb.Controls.Add(this.button_Fnb_Reload);
            this.tabPage_Fnb.Controls.Add(this.button_Fnb_AddNew);
            this.tabPage_Fnb.Controls.Add(this.label_Fnb_ReloadTime);
            this.tabPage_Fnb.Location = new System.Drawing.Point(4, 26);
            this.tabPage_Fnb.Name = "tabPage_Fnb";
            this.tabPage_Fnb.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_Fnb.Size = new System.Drawing.Size(735, 425);
            this.tabPage_Fnb.TabIndex = 0;
            this.tabPage_Fnb.Text = "Food & Beverages";
            this.tabPage_Fnb.UseVisualStyleBackColor = true;
            // 
            // tabPage_User
            // 
            this.tabPage_User.Controls.Add(this.DataGridView_User);
            this.tabPage_User.Controls.Add(this.button_User_Reload);
            this.tabPage_User.Controls.Add(this.button_User_AddNew);
            this.tabPage_User.Controls.Add(this.label_User_ReloadTime);
            this.tabPage_User.Location = new System.Drawing.Point(4, 26);
            this.tabPage_User.Name = "tabPage_User";
            this.tabPage_User.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage_User.Size = new System.Drawing.Size(735, 425);
            this.tabPage_User.TabIndex = 1;
            this.tabPage_User.Text = "User Management";
            this.tabPage_User.UseVisualStyleBackColor = true;
            // 
            // DataGridView_User
            // 
            this.DataGridView_User.AllowUserToAddRows = false;
            this.DataGridView_User.AllowUserToDeleteRows = false;
            this.DataGridView_User.BackgroundColor = System.Drawing.Color.LightGray;
            this.DataGridView_User.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.DataGridView_User.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DataGridView_User.Location = new System.Drawing.Point(6, 38);
            this.DataGridView_User.Name = "DataGridView_User";
            this.DataGridView_User.ReadOnly = true;
            this.DataGridView_User.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.DataGridView_User.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.DataGridView_User.Size = new System.Drawing.Size(723, 382);
            this.DataGridView_User.TabIndex = 24;
            // 
            // button_User_Reload
            // 
            this.button_User_Reload.Location = new System.Drawing.Point(657, 5);
            this.button_User_Reload.Name = "button_User_Reload";
            this.button_User_Reload.Size = new System.Drawing.Size(75, 27);
            this.button_User_Reload.TabIndex = 22;
            this.button_User_Reload.Text = "Reload";
            this.button_User_Reload.UseVisualStyleBackColor = true;
            this.button_User_Reload.Click += new System.EventHandler(this.button_User_Reload_Click);
            // 
            // button_User_AddNew
            // 
            this.button_User_AddNew.Location = new System.Drawing.Point(7, 6);
            this.button_User_AddNew.Name = "button_User_AddNew";
            this.button_User_AddNew.Size = new System.Drawing.Size(75, 27);
            this.button_User_AddNew.TabIndex = 25;
            this.button_User_AddNew.Text = "Add New";
            this.button_User_AddNew.UseVisualStyleBackColor = true;
            this.button_User_AddNew.Click += new System.EventHandler(this.button_User_AddNew_Click);
            // 
            // label_User_ReloadTime
            // 
            this.label_User_ReloadTime.Location = new System.Drawing.Point(210, 6);
            this.label_User_ReloadTime.Name = "label_User_ReloadTime";
            this.label_User_ReloadTime.Size = new System.Drawing.Size(441, 25);
            this.label_User_ReloadTime.TabIndex = 23;
            this.label_User_ReloadTime.Text = "...";
            this.label_User_ReloadTime.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(761, 575);
            this.Controls.Add(this.tabControl1);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Margin = new System.Windows.Forms.Padding(4);
            this.MaximizeBox = false;
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "...";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainScreen_FormClosed);
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_Fnb)).EndInit();
            this.tabControl1.ResumeLayout(false);
            this.tabPage_Fnb.ResumeLayout(false);
            this.tabPage_User.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DataGridView_User)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_ChangeAuth;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_UserInfo;
        private System.Windows.Forms.Label label_ConnectedTo;
        private System.Windows.Forms.Button button_ManageAcc;
        public System.Windows.Forms.DataGridView DataGridView_Fnb;
        private System.Windows.Forms.Button button_Fnb_Reload;
        private System.Windows.Forms.Label label_Fnb_ReloadTime;
        private System.Windows.Forms.Button button_Fnb_AddNew;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button button_Fnb_Review;
        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage_Fnb;
        private System.Windows.Forms.TabPage tabPage_User;
        public System.Windows.Forms.DataGridView DataGridView_User;
        private System.Windows.Forms.Button button_User_Reload;
        private System.Windows.Forms.Button button_User_AddNew;
        private System.Windows.Forms.Label label_User_ReloadTime;
    }

}