using EatAppDesktop.Helpers;
using Auth = EatAppDesktop.Helpers.UserAccountHelper;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using EatAppDesktop.Models;
using EatAppDesktop.Extensions;

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

        private void SHOW_PROGRESSBAR(bool show) => BeginInvoke(new Action(() => { progressBar1.Visible = show; }));

        private async void MainScreen_Load(object sender, EventArgs e)
        {
            label_ConnectedTo.Text = $"Currently connected to {api.BaseUrl}";
            LoadAuthentication();

            if(await api.IsAccessibleAsync())
                await LoadGvAsync();
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

        public async Task LoadGvAsync()
        {
            SHOW_PROGRESSBAR(true);
            var fnbList = await api.ListAllFnbAsync();
            label_ReloadTime.Text = $"List loaded on {DateTime.Now.ToDbDateTimeString()}";
            var gv = this.DataGridView;

            DataTable dt = new DataTable();
            dt.Columns.Add("ID");
            dt.Columns.Add("Fnb name");
            dt.Columns.Add("Type");
            dt.Columns.Add("Total review");
            dt.Columns.Add("Added on");

            int i = 0;
            foreach (var fnb in fnbList)
            {
                DataRow dr = dt.NewRow();
                dr[0] = fnb.Id;
                dr[1] = fnb.Name;
                dr[2] = fnb.FnbType;
                dr[3] = 0; // fnb.MessageContent;
                dr[4] = fnb.CreatedTime.ToDbDateTimeString();
                dt.Rows.Add(dr);

                i++;
            }

            gv.DataSource = dt;

            gv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            gv.Columns[0].Width = 50;
            gv.Columns[1].Width = 230;
            gv.Columns[2].Width = 130;
            gv.Columns[3].Width = 130;
            gv.Columns[4].Width = 170;

            CommonProperties(gv);
            SHOW_PROGRESSBAR(false);
        }

        private void CommonProperties(DataGridView gv)
        {
            // only assign when there's column. This cause by async method
            if (gv.ColumnCount > 0)
            {
                gv.Columns[0].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                gv.Columns[1].DefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);
            }

            //for (int i = 0; i < gv.RowCount; i++) { gv.Rows[i].Height = 35; }
            //gv.RowTemplate.Height = 35;

            gv.RowHeadersVisible = false;
            gv.AllowUserToResizeRows = false;
            gv.AllowUserToResizeColumns = false;
            gv.ClearSelection();
            gv.DefaultCellStyle.SelectionBackColor = Color.LightBlue;
            gv.DefaultCellStyle.SelectionForeColor = Color.Black;
        }

        private async void button_Reload_Click(object sender, EventArgs e)
        {
            if (await api.IsAccessibleAsync())
                await LoadGvAsync();
        }

        private void button_AddNew_Click(object sender, EventArgs e)
        {
            if (Auth.IsAuthenticated)
                new Fnb.Add(this, api).ShowDialog();
            else
                MessageBox.Show("Sorry, you are not allowed to add new FNB, please login", "Not allowed", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
        }
    }
}
