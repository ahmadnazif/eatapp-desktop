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
        public const string NOT_ACCESSIBLE = "Sorry, the API isn't accessible right now";
        private RestApiHelper api;

        public Switcher()
        {
            InitializeComponent();
        }

        private void Switcher_Load(object sender, EventArgs e) => api = new RestApiHelper(baseUrl);


        private async void button_Client_Click(object sender, EventArgs e)
        {
            if (await api.IsAccessibleAsync())
            {
                new Client.MainScreen(this, api).Show();
                this.Hide();
            }
            else
                MessageBox.Show(NOT_ACCESSIBLE, "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }

        private void button_Admin_Click(object sender, EventArgs e)
        {

        }

    }
}
