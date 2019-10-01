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

namespace EatAppDesktop.UI.Client.Fnb
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
                var type = radioButton1.Checked ? FnbType.Food : FnbType.Baverage;
                var msg = await api.AddFnbAsync(textBox_FnbName.Text, type);
                SHOW_PROGRESSBAR(false);
                MessageBox.Show(msg, "Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void SHOW_PROGRESSBAR(bool show) => BeginInvoke(new Action(() => { progressBar1.Visible = show; }));

        private async void Add_FormClosed(object sender, FormClosedEventArgs e) => await mainScreen.LoadGvAsync();
    }
}
