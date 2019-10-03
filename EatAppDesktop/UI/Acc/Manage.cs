using EatAppDesktop.Helpers;
using EatAppDesktop.Extensions;
using Auth =  EatAppDesktop.Helpers.AccAuthHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EatAppDesktop.UI.Acc
{
    public partial class Manage : Form
    {
        private readonly MainScreen mainScreen;
        private readonly RestApiHelper api;

        public Manage(MainScreen mainScreen, RestApiHelper api)
        {
            this.mainScreen = mainScreen;
            this.api = api;
            InitializeComponent();
        }

        private void SHOW_PROGRESSBAR(bool show) => BeginInvoke(new Action(() => { progressBar1.Visible = show; }));

        private async void Manage_Load(object sender, EventArgs e)
        {
            SHOW_PROGRESSBAR(true);

            label_Username.Text = Auth.CurrentUsername;
            label_LoginTime.Text = Auth.LoggedInTime;

            if (await api.IsAccessibleAsync())
            {
                var user = await api.GetUserAsync(Auth.CurrentUsername);

                label_Username.Text = $"{Auth.CurrentUsername} ({user.Role})";

                textBox_FullName.Text = user.Fullname;
                textBox_Email.Text = user.Email;
                label_UserCreatedOn.Text = user.CreatedTime.ToDbDateTimeString();
            }

            SHOW_PROGRESSBAR(false);
        }

        private async void button_ChangePassword_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox_OldPassword.Text) || string.IsNullOrWhiteSpace(textBox_NewPassword.Text))
            {
                MessageBox.Show("Old & new password is required", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SHOW_PROGRESSBAR(true);
            if (await api.IsAccessibleAsync())
            {
                var resp = await api.ChangePasswordAsync(Auth.CurrentUsername, textBox_OldPassword.Text, textBox_NewPassword.Text);
                if (resp.IsSuccess)
                {
                    MessageBox.Show("Password successfully changed. Please remember & used your new password", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    textBox_OldPassword.Clear();
                    textBox_NewPassword.Clear();
                    textBox_NewPassword.Focus();
                }
                else
                    MessageBox.Show(resp.Message, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            }
            SHOW_PROGRESSBAR(false);
        }

        private async void button_ChangePersonalInfo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_FullName.Text) || string.IsNullOrWhiteSpace(textBox_Email.Text))
            {
                MessageBox.Show("Fullname & email is required", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SHOW_PROGRESSBAR(true);

            var resp = await api.UpdateUserAsync(Auth.CurrentUsername, textBox_Email.Text, textBox_FullName.Text);
            if (resp.IsSuccess)
            {
                MessageBox.Show("User successfully updated", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
                MessageBox.Show(resp.Message, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

            SHOW_PROGRESSBAR(false);

        }
    }
}
