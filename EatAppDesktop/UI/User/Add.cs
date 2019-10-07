using EatAppDesktop.Common;
using EatAppDesktop.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EatAppDesktop.UI.User
{
    public partial class Add : Form
    {
        private readonly MainScreen mainScreen;
        private readonly RestApiHelper api;

        public Add(MainScreen mainScreen, RestApiHelper api)
        {
            this.mainScreen = mainScreen;
            this.api = api;
            InitializeComponent();
        }

        private async void button_Create_Click(object sender, EventArgs e)
        {
            if (await api.IsAccessibleAsync())
            {
                SHOW_PROGRESSBAR(true);

                var role = radioButton1.Checked ? UserRole.User : UserRole.Admin;
                var msg = await api.AddUserAsync(textBox_Username.Text, textBox_Password.Text, textBox_Email.Text, role);
                SHOW_PROGRESSBAR(false);
                MessageBox.Show(msg, "Response", MessageBoxButtons.OK, MessageBoxIcon.Information);

                textBox_Username.Clear();
                textBox_Password.Clear();
                textBox_Email.Clear();
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void SHOW_PROGRESSBAR(bool show) => BeginInvoke(new Action(() => { progressBar1.Visible = show; }));

        private async void Add_FormClosed(object sender, FormClosedEventArgs e) => await mainScreen.LoadGvUserAsync();
    }

}
