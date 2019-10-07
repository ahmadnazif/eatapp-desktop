using EatAppDesktop.Helpers;
using EatAppDesktop.Extensions;
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
using EatAppDesktop.Models;

namespace EatAppDesktop.UI.Fnb
{
    public partial class Review : Form
    {
        private readonly MainScreen mainScreen;
        private readonly RestApiHelper api;
        private readonly int fnbId;
        private readonly string fnbName;
        private readonly List<Models.UserProfile> allUser;

        public Review(MainScreen mainScreen, RestApiHelper api, List<Models.UserProfile> allUser, int fnbId, string fnbName)
        {
            this.mainScreen = mainScreen;
            this.api = api;
            this.fnbId = fnbId;
            this.fnbName = fnbName;
            this.allUser = allUser;
            InitializeComponent();
        }

        private void SHOW_PROGRESSBAR(bool show) => BeginInvoke(new Action(() => { progressBar1.Visible = show; }));

        private void ENABLE_BUTTONS(bool enable)
        {
            button_SubmitReview.Enabled = enable;
        }

        private async void Review_Load(object sender, EventArgs e)
        {
            if (!Auth.IsAuthenticated)
            {
                groupBox1.Enabled = false;
                label_NotLogin.Visible = true;
            }

            label_FnbName.Text = fnbName;
            await LoadGvAsync();

        }

        public async Task LoadGvAsync()
        {
            SHOW_PROGRESSBAR(true);
            ENABLE_BUTTONS(false);
            var fnbCommentList = await api.ListAllFnbCommentAsync(fnbId);
            var gv = this.DataGridView;

            DataTable dt = new DataTable();
            dt.Columns.Add("#");
            dt.Columns.Add("Reviewer");
            dt.Columns.Add("Rating");
            dt.Columns.Add("Comment");
            dt.Columns.Add("Added on");

            int starRating = 0, ratingCount = 0;

            int i = 0;
            foreach (var fnbComment in fnbCommentList)
            {
                i++;

                DataRow dr = dt.NewRow();
                dr[0] = i;
                dr[1] = GetUser(fnbComment.CommenterId);
                dr[2] = $"{fnbComment.Rating} / {(int)fnbComment.BaseRating}";
                dr[3] = fnbComment.Comment;
                dr[4] = fnbComment.CreatedTime.ToDbDateTimeString();
                dt.Rows.Add(dr);

                starRating += fnbComment.Rating;
                ratingCount++;
            }

            gv.DataSource = dt;

            gv.DefaultCellStyle.WrapMode = DataGridViewTriState.False;
            gv.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
            gv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;

            gv.Columns[0].Width = 50;
            gv.Columns[1].Width = 120;
            gv.Columns[2].Width = 100;
            gv.Columns[3].Width = 300;
            gv.Columns[4].Width = 150;

            CommonProperties(gv);
            SHOW_PROGRESSBAR(false);
            ENABLE_BUTTONS(true);

            var starRatingPer5 = ratingCount > 0 ? Math.Round((double)starRating / ratingCount, 2) / 2 : 0;
            label_StarRating.Text = $"{starRatingPer5} ⭐";

            string GetUser(int userId)
            {
                var username = allUser.Where(d => d.Id == userId).Select(d => d.Username).SingleOrDefault();
                return username ?? $"Deleted user (UserId: {userId})";
            }
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



        private void trackBar1_Scroll(object sender, EventArgs e) => label_Rating.Text = $"{trackBar1.Value} star";

        private async void button_SubmitReview_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textBox1.Text))
            {
                MessageBox.Show("Input needed", "Sorry", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                return;
            }

            SHOW_PROGRESSBAR(true);
            var me = await api.GetUserAsync(Auth.CurrentUsername);
            var msg = await api.AddFnbCommentAsync(fnbId, textBox1.Text, trackBar1.Value, me.Id);
            SHOW_PROGRESSBAR(false);

            MessageBox.Show(msg, "Response", MessageBoxButtons.OK, MessageBoxIcon.Information);
            await LoadGvAsync();
        }
    }
}
