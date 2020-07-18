using System;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Windows.Forms;
using BDY_Cafe.Utils;

namespace BDY_Cafe
{
    public partial class AdditionTableMonitor : Form
    {
        #region fields
        private static int count = 0;
        private DataTable list; // addition & table matches
        #endregion

        #region constructors
        public AdditionTableMonitor()
        {
            InitializeComponent();
        }
        #endregion

        #region events
        private void frmMain_Load(object sender, EventArgs e)
        {
            try
            {
                using (StreamReader reader = new StreamReader("server.txt"))
                {
                    String line = reader.ReadToEnd();
                    String[] conParams = line.Split('|');
                    DefaultValues.SQLConnection.SERVER_NAME = conParams[0];
                    DefaultValues.SQLConnection.DATABASE_NAME = conParams[1];
                    DefaultValues.SQLConnection.USERNAME = conParams[2];
                    DefaultValues.SQLConnection.PASSWORD = conParams[3];
                }
            }
            catch (Exception)
            {

            }
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            loadList();
            tmrCheckUpdateList.Start();

            // open in monitor
            Screen[] screens = Screen.AllScreens;
            if (screens.Length > 1)
            {
                this.StartPosition = FormStartPosition.Manual;
                this.Location = Screen.AllScreens[1].WorkingArea.Location;
            }
            else
            {
                this.StartPosition = FormStartPosition.CenterScreen;
            }
            this.WindowState = FormWindowState.Maximized;
        }

        // refresh list with new values if any change has been found
        private void tmrCheckUpdateList_Tick(object sender, EventArgs e)
        {
            int toplam = -1;
            try
            {
                using (SqlConnection connection = new SqlConnection(DefaultValues.SQLConnection.CONNECTION_STRING))
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        SqlCommand command = new SqlCommand(DefaultValues.SQLQueries.unhandledCount, connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable result = new DataTable();
                        adapter.Fill(result);
                        if (result.Rows.Count > 0)
                        {
                            toplam = (int)result.Rows[0]["TOPLAM"];
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }

            if (toplam != -1 && toplam != count)
            {
                loadList();
            }
        }
        #endregion

        #region methods
        // load the list from database to datagridview
        private void loadList()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DefaultValues.SQLConnection.CONNECTION_STRING))
                {
                    connection.Open();
                    if (connection.State == ConnectionState.Open)
                    {
                        SqlCommand command = new SqlCommand(DefaultValues.SQLQueries.unhandledList, connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        list = new DataTable();
                        adapter.Fill(list);
                        count = list.Rows.Count;
                        dgvAdditionTable.DataSource = list;
                        dgvAdditionTable.Columns["Id"].Visible = false;
                        dgvAdditionTable.Columns["Direction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                        dgvAdditionTable.Columns["Direction"].Width = 120;
                        dgvAdditionTable.Columns["AdditionNumber"].HeaderText = "Adisyon No";
                        dgvAdditionTable.Columns["TableNumber"].HeaderText = "Masa No";
                        dgvAdditionTable.Columns["Direction"].HeaderText = "";
                        dgvAdditionTable.Columns["MatchDate"].HeaderText = "İşlem Zamanı";
                        dgvAdditionTable.Columns["MatchDate"].DefaultCellStyle.Format = "HH:mm:ss";

                        // TODO: geçen süreyi gösterecek sütun ekle
                        /*if (dgvAdditionTable.Columns["elapsed"] != null)
                        {
                            dgvAdditionTable.Columns.Remove("elapsed");
                        }
                        if (list != null && list.Rows.Count > 0)
                        {
                            DataGridViewColumn elapsed = new DataGridViewColumn();

                            elapsed.Text = "Geçen Süre";
                            elapsed.Name = "elapsed";
                            elapsed.UseColumnTextForButtonValue = true;
                            dgvAdditionTable.Columns.Add(elapsed);
                            dgvAdditionTable.Columns["elapsed"].HeaderText = "Geçen Süre";
                            dgvAdditionTable.ClearSelection();
                        }*/
                    }
                }

                if (count > 0)
                {
                    dgvAdditionTable.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }
        #endregion

        private void AdditionTableMonitor_KeyPress(object sender, KeyPressEventArgs e)
        {
            dgvAdditionTable.ClearSelection();
        }
    }
}
