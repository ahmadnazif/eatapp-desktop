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

namespace EatAppDesktop.UI.Client
{
    public partial class MainScreen : Form
    {
        private readonly Switcher switcher;
        private readonly RestApiHelper api;

        public MainScreen(Switcher switcher, RestApiHelper api)
        {
            this.switcher = switcher;
            this.api = api;
            InitializeComponent();
        }

        private void MainScreen_FormClosed(object sender, FormClosedEventArgs e) => switcher.Show();

        private void MainScreen_Load(object sender, EventArgs e)
        {
            label_ConnectedTo.Text = $"Currently connected to {api.BaseUrl}";
            LoadAuthentication();
        }

        public void LoadAuthentication()
        {
            button_ChangeAuth.Text = Auth.IsAuthenticated ? "Logout" : "Login";
            button_ManageAcc.Visible = Auth.IsAuthenticated ? true : false;
            var loginInfo = $"Username: {Auth.CurrentUsername}\nLogin time: {Auth.LoggedInTime}";
            label_UserInfo.Text = Auth.IsAuthenticated ? loginInfo : "Please login to submit comment";
        }

        private void button_ChangeAuth_Click(object sender, EventArgs e)
        {
            if (Auth.IsAuthenticated)
            {
                var dr = MessageBox.Show("Logout from the system?", "Logout?", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                if (dr == DialogResult.Yes)
                {
                    Auth.Logout();
                    LoadAuthentication();
                }
            }
            else
                new Acc.Login(this, api).ShowDialog();
        }

        private void button_ManageAcc_Click(object sender, EventArgs e) => new Acc.Manage(this, api).ShowDialog();
    }
}
