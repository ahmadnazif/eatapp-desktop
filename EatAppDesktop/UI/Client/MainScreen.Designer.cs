namespace EatAppDesktop.UI.Client
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
            this.label_UserInfo = new System.Windows.Forms.Label();
            this.label_ConnectedTo = new System.Windows.Forms.Label();
            this.button_ManageAcc = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // button_ChangeAuth
            // 
            this.button_ChangeAuth.Location = new System.Drawing.Point(672, 8);
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
            this.panel1.Size = new System.Drawing.Size(757, 100);
            this.panel1.TabIndex = 1;
            // 
            // label_UserInfo
            // 
            this.label_UserInfo.Location = new System.Drawing.Point(478, 36);
            this.label_UserInfo.Name = "label_UserInfo";
            this.label_UserInfo.Size = new System.Drawing.Size(269, 61);
            this.label_UserInfo.TabIndex = 1;
            this.label_UserInfo.Text = "...";
            this.label_UserInfo.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
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
            // button_ManageAcc
            // 
            this.button_ManageAcc.Location = new System.Drawing.Point(595, 8);
            this.button_ManageAcc.Name = "button_ManageAcc";
            this.button_ManageAcc.Size = new System.Drawing.Size(75, 27);
            this.button_ManageAcc.TabIndex = 3;
            this.button_ManageAcc.Text = "Manage";
            this.button_ManageAcc.UseVisualStyleBackColor = true;
            this.button_ManageAcc.Visible = false;
            this.button_ManageAcc.Click += new System.EventHandler(this.button_ManageAcc_Click);
            // 
            // MainScreen
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(751, 514);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.Name = "MainScreen";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Client: MainScreen";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.MainScreen_FormClosed);
            this.Load += new System.EventHandler(this.MainScreen_Load);
            this.panel1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button_ChangeAuth;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label_UserInfo;
        private System.Windows.Forms.Label label_ConnectedTo;
        private System.Windows.Forms.Button button_ManageAcc;
    }
}