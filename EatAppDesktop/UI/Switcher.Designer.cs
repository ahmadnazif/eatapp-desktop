namespace EatAppDesktop.UI
{
    partial class Switcher
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
            this.label1 = new System.Windows.Forms.Label();
            this.button_Client = new System.Windows.Forms.Button();
            this.button_Admin = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select role";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_Client
            // 
            this.button_Client.Location = new System.Drawing.Point(14, 56);
            this.button_Client.Name = "button_Client";
            this.button_Client.Size = new System.Drawing.Size(146, 28);
            this.button_Client.TabIndex = 1;
            this.button_Client.Text = "Client";
            this.button_Client.UseVisualStyleBackColor = true;
            this.button_Client.Click += new System.EventHandler(this.button_Client_Click);
            // 
            // button_Admin
            // 
            this.button_Admin.Location = new System.Drawing.Point(166, 56);
            this.button_Admin.Name = "button_Admin";
            this.button_Admin.Size = new System.Drawing.Size(146, 28);
            this.button_Admin.TabIndex = 2;
            this.button_Admin.Text = "Admin";
            this.button_Admin.UseVisualStyleBackColor = true;
            this.button_Admin.Click += new System.EventHandler(this.button_Admin_Click);
            // 
            // Switcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 103);
            this.Controls.Add(this.button_Admin);
            this.Controls.Add(this.button_Client);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.Name = "Switcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Switcher";
            this.Load += new System.EventHandler(this.Switcher_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_Client;
        private System.Windows.Forms.Button button_Admin;
    }
}