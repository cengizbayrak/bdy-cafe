using System;
using System.Data.SqlClient;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Windows.Forms;
using BDY_Cafe.Forms;
using BDY_Cafe.Utils;

namespace BDY_Cafe
{
    public partial class Main : Form
    {
        public Main()
        {
            InitializeComponent();

            StartPosition = FormStartPosition.Manual;
            //this.Location = Screen.AllScreens[0].WorkingArea.Location;

            var area = Screen.PrimaryScreen.WorkingArea;
            var location = area.Location;

            Location = new Point(area.Width / 2 - Width / 2, area.Height / 2 - Height / 2);


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
                    DefaultValues.SQLConnection.constructConnectionString();
                }
            }
            catch (Exception)
            {

            }
            handleOldAdditions();
        }

        #region events
        private void Main_Load(object sender, EventArgs e)
        {
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Text = Resources.StringResources.APP_TITLE;
            AdditionTableMonitor frmList = new AdditionTableMonitor();
            frmList.Show();
            AdditionTable frm = new AdditionTable();
            frm.Show();
        }

        private void frmMain_Shown(object sender, EventArgs e)
        {
            this.Activate();
        }

        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnAdditionTable_Click(object sender, EventArgs e)
        {
            AdditionTable frm = new AdditionTable();
            if (Application.OpenForms[frm.Name] == null)
            {
                frm.Show();
            }
            else
            {
                Application.OpenForms[frm.Name].Activate();
            }
        }

        private void btnTables_Click(object sender, EventArgs e)
        {
            TableDefinition frm = new TableDefinition();
            if (Application.OpenForms[frm.Name] == null)
            {
                frm.Show();
            }
            else
            {
                Application.OpenForms[frm.Name].Activate();
            }
        }

        private void btnReport_Click(object sender, EventArgs e)
        {
            Report frm = new Report();
            if (Application.OpenForms[frm.Name] == null)
            {
                frm.Show();
            }
            else
            {
                Application.OpenForms[frm.Name].Activate();
            }
        }

        private void btnAdditionTableList_Click(object sender, EventArgs e)
        {
            AdditionTableMonitor frm = new AdditionTableMonitor();
            if (Application.OpenForms[frm.Name] == null)
            {
                frm.Show();
            }
            else
            {
                Application.OpenForms[frm.Name].Activate();
            }
        }
        #endregion

        #region methods
        private void handleOldAdditions()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DefaultValues.SQLConnection.CONNECTION_STRING))
                {
                    SqlCommand command = new SqlCommand(DefaultValues.SQLQueries.closeOldAdditions, connection);
                    connection.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                    Debug.WriteLine("Main_handleOldAdditions: " + recordsAffected);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Main_handleOldAdditions: " + ex.Message);
            }
        }
        #endregion
    }
}