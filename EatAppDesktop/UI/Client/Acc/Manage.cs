using EatAppDesktop.Helpers;
using Auth =  EatAppDesktop.Helpers.UserAccountHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EatAppDesktop.UI.Client.Acc
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

        private async void Manage_Load(object sender, EventArgs e)
        {
            label_Username.Text = Auth.CurrentUsername;
            label_LoginTime.Text = Auth.LoggedInTime;

            if(await api.IsAccessibleAsync())
            {
                var user = await api.GetUserAsync(Auth.CurrentUsername);
                //textBox_FullName.Text = user.Fullname;
                //textBox_Email.Text = user.Email;
            }
        }

        private async void button_ChangePassword_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox_OldPassword.Text) || string.IsNullOrWhiteSpace(textBox_NewPassword.Text))
            {
                MessageBox.Show("Old & new password is required", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

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
        }

        private void button_ChangePersonalInfo_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox_FullName.Text) || string.IsNullOrWhiteSpace(textBox_Email.Text))
            {
                MessageBox.Show("Fullname & email is required", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

        }
    }
}
