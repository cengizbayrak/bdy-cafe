using System;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using BDY_Cafe.Utils;

namespace BDY_Cafe.Forms
{
    public partial class Report : Form
    {
        private DataTable list;

        public Report()
        {
            InitializeComponent();
        }

        private void loadList()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DefaultValues.SQLConnection.CONNECTION_STRING))
                {
                    SqlCommand command = new SqlCommand(DefaultValues.SQLQueries.reportList, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    list = new DataTable();
                    adapter.Fill(list);
                    dgvReport.DataSource = list;
                    dgvReport.Columns["Id"].Visible = false;
                    dgvReport.Columns["AdditionNumber"].HeaderText = "Adisyon Numarası";
                    dgvReport.Columns["TableNumber"].HeaderText = "Masa Numarası";
                    dgvReport.Columns["Direction"].HeaderText = "Masa Yönü";
                    dgvReport.Columns["MatchDate"].HeaderText = "İşlem Tarihi";

                    dgvReport.Columns["Direction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;

                    lblTotal.Text = list.Rows.Count.ToString();
                    lblToday.Text = list.AsEnumerable().Where(x => (((DateTime)x["MatchDate"]).Year == DateTime.Today.Year && ((DateTime)x["MatchDate"]).Month == DateTime.Today.Month && ((DateTime)x["MatchDate"]).Day == DateTime.Today.Day)).ToList().Count.ToString();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void Report_Shown(object sender, EventArgs e)
        {
            loadList();
        }

        private void Report_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }
    }
}