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
            this.button_GoToMainScreen = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(12, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(302, 22);
            this.label1.TabIndex = 0;
            this.label1.Text = "Select action";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button_GoToMainScreen
            // 
            this.button_GoToMainScreen.Location = new System.Drawing.Point(14, 56);
            this.button_GoToMainScreen.Name = "button_GoToMainScreen";
            this.button_GoToMainScreen.Size = new System.Drawing.Size(300, 28);
            this.button_GoToMainScreen.TabIndex = 1;
            this.button_GoToMainScreen.Text = "Go to Main Screen";
            this.button_GoToMainScreen.UseVisualStyleBackColor = true;
            this.button_GoToMainScreen.Click += new System.EventHandler(this.button_GoToMainScreen_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(-3, 99);
            this.progressBar1.MarqueeAnimationSpeed = 10;
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(336, 8);
            this.progressBar1.Style = System.Windows.Forms.ProgressBarStyle.Marquee;
            this.progressBar1.TabIndex = 24;
            this.progressBar1.Visible = false;
            // 
            // Switcher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 17F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(328, 107);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.button_GoToMainScreen);
            this.Controls.Add(this.label1);
            this.Font = new System.Drawing.Font("Segoe UI", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Switcher";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Switcher";
            this.Load += new System.EventHandler(this.Switcher_Load);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button_GoToMainScreen;
        private System.Windows.Forms.ProgressBar progressBar1;
    }
}