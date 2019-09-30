using EatAppDesktop.Helpers;
using Auth =  EatAppDesktop.Helpers.UserAuthHelper;
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

        private void Manage_Load(object sender, EventArgs e)
        {
            label_Username.Text = Auth.CurrentUsername;
            label_LoginTime.Text = Auth.LoggedInTime;
        }

        private async void button_ChangePassword_Click(object sender, EventArgs e)
        {
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
    }
}
