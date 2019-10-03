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

namespace EatAppDesktop.UI
{
    public partial class Switcher : Form
    {
        private readonly string baseUrl = "https://eatapi-254203.appspot.com";
        //private readonly string baseUrl = "http://localhost:5000";

        public const string NOT_ACCESSIBLE = "Sorry, the API isn't accessible right now";
        private RestApiHelper api;

        public Switcher()
        {
            InitializeComponent();
        }

        private void SHOW_PROGRESSBAR(bool show) => BeginInvoke(new Action(() => { progressBar1.Visible = show; }));

        private void Switcher_Load(object sender, EventArgs e) => api = new RestApiHelper(baseUrl);


        private async void button_GoToMainScreen_Click(object sender, EventArgs e)
        {
            SHOW_PROGRESSBAR(true);
            if (await api.IsAccessibleAsync())
            {
                var allUser = await api.ListAllUserAsync();
                new MainScreen(this, api, allUser).Show();
                this.Hide();
            }
            else
                MessageBox.Show(NOT_ACCESSIBLE, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
            SHOW_PROGRESSBAR(false);
        }
    }
}
