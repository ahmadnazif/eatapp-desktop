using EatAppDesktop.Helpers;
using Auth = EatAppDesktop.Helpers.UserAuthHelper;
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
    public partial class Login : Form
    {
        private readonly MainScreen mainScreen;
        private readonly RestApiHelper api;

        public Login(MainScreen mainScreen, RestApiHelper api)
        {
            this.mainScreen = mainScreen;
            this.api = api;
            InitializeComponent();
        }

        private void Login_Load(object sender, EventArgs e)
        {

        }

        private async void button_Login_Click(object sender, EventArgs e)
        {
            if (await api.IsAccessibleAsync())
            {
                var resp = await Auth.LoginAsync(api, textBox_Username.Text, textBox_Password.Text);
                MessageBox.Show(resp.Message, "Login", MessageBoxButtons.OK, MessageBoxIcon.Information);

                if (resp.IsSuccess)
                {
                    this.Close();
                    mainScreen.LoadAuthentication();
                }

                textBox_Username.Focus();
            }
            else
                MessageBox.Show(Switcher.NOT_ACCESSIBLE, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
