﻿using EatAppDesktop.Helpers;
using Auth = EatAppDesktop.Helpers.AccAuthHelper;
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

        private void SHOW_PROGRESSBAR(bool show) => BeginInvoke(new Action(() => { progressBar1.Visible = show; }));

        private async void button_Login_Click(object sender, EventArgs e)
        {
            if(string.IsNullOrWhiteSpace(textBox_Username.Text) || string.IsNullOrWhiteSpace(textBox_Password.Text))
            {
                MessageBox.Show("Input needed", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                textBox_Username.Focus();
                return;
            }

            if (await api.IsAccessibleAsync())
            {
                SHOW_PROGRESSBAR(true);
                var resp = await Auth.LoginAsync(api, textBox_Username.Text, textBox_Password.Text);

                if (resp.IsSuccess)
                {
                    MessageBox.Show($"Welcome, {textBox_Username.Text}", "Login success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                    mainScreen.LoadAuthentication();
                }
                else MessageBox.Show(resp.Message, "Login failed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);

                SHOW_PROGRESSBAR(false);
                textBox_Username.Focus();
            }
            else
            {
                MessageBox.Show(Switcher.NOT_ACCESSIBLE, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                SHOW_PROGRESSBAR(false);
            }
        }
    }
}
