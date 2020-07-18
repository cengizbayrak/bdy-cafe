using System;
using System.Data;
using System.Data.SqlClient;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Net;
using System.Windows.Forms;
using BDY_Cafe.Utils;

namespace BDY_Cafe
{
    public partial class AdditionTable : Form
    {
        #region fields
        private static int count = 0;
        private DataTable list; // addition & table matches

        private static int autoHandleInterval = 10; // default value 10 minutes
        #endregion

        #region constructors
        public AdditionTable()
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
            loadAutoHandleInterval();
            loadList();
            tmrCheckUpdateList.Start();

            this.StartPosition = FormStartPosition.CenterScreen;
            this.WindowState = FormWindowState.Maximized;

            connectionQRCode();

            txtSearch.Focus();
        }

        // close on esc key
        private void frmMain_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (txtSearch.Text.Length > 0)
                {
                    txtSearch.Clear();
                    txtSearch.Focus();
                    return;
                }
                this.Close();
            }
        }

        // handle button on datagridview
        private void dgvAdditionTable_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            if (rowIndex != -1 && rowIndex < dgvAdditionTable.Rows.Count)
            {
                if (dgvAdditionTable.SelectedRows.Count == 1)
                {
                    int id = Convert.ToInt32(dgvAdditionTable.SelectedRows[0].Cells["Id"].Value);
                    string additionNo = dgvAdditionTable.SelectedRows[0].Cells["AdditionNumber"].Value.ToString();

                    if (columnIndex == dgvAdditionTable.Columns["change"].Index)
                    {
                        bool success = false;
                        while (!success)
                        {
                            string input = Microsoft.VisualBasic.Interaction.InputBox(Resources.StringResources.ENTER_NEW_TABLE_NUMBER,
                                Resources.StringResources.ADDITION_TABLE_CHANGE,
                                "");
                            if (string.IsNullOrWhiteSpace(input))
                            {
                                break;
                            }

                            int tableNumber = -1;
                            if (int.TryParse(input, out tableNumber))
                            {
                                using (SqlConnection connection = new SqlConnection(DefaultValues.SQLConnection.CONNECTION_STRING))
                                {
                                    SqlCommand command = new SqlCommand(DefaultValues.SQLQueries.changeAdditionTable, connection);
                                    command.Parameters.AddWithValue("@id", id);
                                    command.Parameters.AddWithValue("@number", input);
                                    connection.Open();
                                    int affectedRecords = command.ExecuteNonQuery();
                                    if (affectedRecords > 0)
                                    {
                                        success = true;
                                        loadList();
                                        string message = string.Format(Resources.StringResources.ADDITION_TABLE_CHANGED_SUCCESSFULLY, additionNo, tableNumber);
                                        MessageBox.Show(message, Resources.StringResources.ADDITION_TABLE_CHANGE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                        continue;
                                    }
                                }
                            }

                            MessageBox.Show(Resources.StringResources.ENTER_VALID_TABLE_NUMBER, Resources.StringResources.ADDITION_TABLE_CHANGE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                    else if (columnIndex == dgvAdditionTable.Columns["handle"].Index)
                    {
                        DialogResult result = MessageBox.Show(string.Format(Resources.StringResources.ARE_YOU_SURE_TO_HANDLE_ADDITION, additionNo),
                            Resources.StringResources.HANDLE_ADDITION,
                            MessageBoxButtons.YesNo,
                            MessageBoxIcon.Question);
                        if (result == DialogResult.Yes)
                        {
                            try
                            {
                                using (SqlConnection connection = new SqlConnection(DefaultValues.SQLConnection.CONNECTION_STRING))
                                {
                                    SqlCommand command = new SqlCommand(DefaultValues.SQLQueries.closeAddition, connection);
                                    command.Parameters.AddWithValue("@id", id);
                                    connection.Open();
                                    int res = command.ExecuteNonQuery();
                                    if (res > 0)
                                    {
                                        loadList();
                                        txtSearch.Clear();
                                        txtSearch.Focus();
                                    }
                                }
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(ex.Message);
                            }
                        }
                    }
                }
            }
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
                        #region update list
                        SqlCommand command = new SqlCommand(DefaultValues.SQLQueries.unhandledCount, connection);
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable result = new DataTable();
                        adapter.Fill(result);
                        if (result.Rows.Count > 0)
                        {
                            toplam = (int)result.Rows[0]["TOPLAM"];
                        }
                        #endregion

                        #region autoHandle
                        if (autoHandleInterval > 0)
                        {
                            SqlCommand commandAutoHandle = new SqlCommand(DefaultValues.SQLQueries.autoHandleAddition, connection);
                            commandAutoHandle.Parameters.AddWithValue("@minute", autoHandleInterval);
                            int affectedRows = commandAutoHandle.ExecuteNonQuery();
                        }
                        #endregion
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

        // addition number search
        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            if (txtSearch.Text.Length > 0)
            {
                try
                {
                    int addNo = -1;
                    if (int.TryParse(txtSearch.Text, out addNo))
                    {
                        DataView dataview = new DataView(list);
                        dataview.RowFilter = string.Format("convert(AdditionNumber, 'System.String') LIKE '%{0}%'", addNo.ToString());
                        //dataview.RowFilter = string.Format("AdditionNumber={0}", addNo);
                        dataview.Sort = "AdditionNumber ASC";
                        dgvAdditionTable.DataSource = dataview;
                    }
                    else
                    {
                        dgvAdditionTable.ClearSelection();
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
            else
            {
                dgvAdditionTable.DataSource = list;
                dgvAdditionTable.ClearSelection();
            }
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                if (dgvAdditionTable.SelectedRows.Count == 1)
                {
                    int rowIndex = dgvAdditionTable.SelectedRows[0].Index;
                    int columnIndex = dgvAdditionTable.Columns["handle"].Index;
                    DataGridViewCellEventArgs eventArgs = new DataGridViewCellEventArgs(columnIndex, rowIndex);
                    dgvAdditionTable_CellClick(dgvAdditionTable, eventArgs);
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                int value = (int)numud.Value;
                if (value == 0)
                {
                    DialogResult result = MessageBox.Show("0 olarak güncellemeniz halinde otomatik kapatma işlemi pasif duruma geçecektir. Devam etmek istiyor musunuz?", "Otomatik Adisyon Kapatma", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                    if (result != DialogResult.Yes)
                    {
                        return;
                    }
                }

                using (SqlConnection connection = new SqlConnection(DefaultValues.SQLConnection.CONNECTION_STRING))
                {
                    SqlCommand command = new SqlCommand(DefaultValues.SQLQueries.updateAutoHandleInterval, connection);
                    command.Parameters.AddWithValue("@value", value);
                    connection.Open();
                    int recordsAffected = command.ExecuteNonQuery();
                    if (recordsAffected > 0)
                    {
                        autoHandleInterval = value;
                        MessageBox.Show("Otomatik adisyon kapatma süresi " + value + " dakika olarak güncellendi.", "Otomatik Adisyon Kapatma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("AdditionTable_btnSave_Click: " + ex.Message);
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
                    SqlCommand command = new SqlCommand(DefaultValues.SQLQueries.unhandledList, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    list = new DataTable();
                    adapter.Fill(list);
                    count = list.Rows.Count;
                    dgvAdditionTable.DataSource = list;
                    dgvAdditionTable.Columns["Id"].Visible = false;
                    dgvAdditionTable.Columns["Direction"].Width = 100;
                    dgvAdditionTable.Columns["Direction"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                    dgvAdditionTable.Columns["AdditionNumber"].HeaderText = Resources.StringResources.ADDITION_NO;
                    dgvAdditionTable.Columns["TableNumber"].HeaderText = Resources.StringResources.TABLE_NO;
                    dgvAdditionTable.Columns["Direction"].HeaderText = "";
                    dgvAdditionTable.Columns["MatchDate"].HeaderText = Resources.StringResources.OPERATION_TIME;
                    dgvAdditionTable.Columns["MatchDate"].DefaultCellStyle.Format = DefaultValues.Formatting.TIME_FORMAT;
                }

                // TODO: geçen süreyi gösterecek sütun ekle

                if (dgvAdditionTable.Columns["change"] != null)
                {
                    dgvAdditionTable.Columns.Remove("change");
                }

                if (dgvAdditionTable.Columns["handle"] != null)
                {
                    dgvAdditionTable.Columns.Remove("handle");
                }
                if (count > 0)
                {
                    DataGridViewButtonColumn change = new DataGridViewButtonColumn();
                    change.Text = "Değiştir";
                    change.Name = "change";
                    change.UseColumnTextForButtonValue = true;
                    dgvAdditionTable.Columns.Add(change);
                    dgvAdditionTable.Columns["change"].HeaderText = Resources.StringResources.TABLE_CHANGE;
                    dgvAdditionTable.Columns["change"].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;


                    DataGridViewButtonColumn handle = new DataGridViewButtonColumn();
                    handle.Text = "Kapat";
                    handle.Name = "handle";
                    handle.UseColumnTextForButtonValue = true;
                    dgvAdditionTable.Columns.Add(handle);
                    dgvAdditionTable.Columns["handle"].HeaderText = Resources.StringResources.ORDER_DELIVERY;

                    dgvAdditionTable.CellClick += dgvAdditionTable_CellClick;
                    dgvAdditionTable.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void connectionQRCode()
        {
            IPAddress localhost = Dns.GetHostEntry(Dns.GetHostName()).AddressList
                .Where(add => !add.IsIPv6LinkLocal && !add.IsIPv6Multicast && !add.IsIPv6SiteLocal).First();

            string address = localhost.ToString();
            string port = "1433";
            string server = DefaultValues.SQLConnection.SERVER_NAME;
            string pcname = string.Empty;
            string instance = string.Empty;
            //if (server.Contains('\\'))
            //{
            //    string[] serverParams = server.Split('\\');
            //    pcname = serverParams[0];
            //    instance = serverParams[1];
            //}
            //else
            //{
            //    instance = server;
            //}
            string database = DefaultValues.SQLConnection.DATABASE_NAME;
            string username = DefaultValues.SQLConnection.USERNAME;
            string password = DefaultValues.SQLConnection.PASSWORD;

            barcode.AutoModule = true;
            barcode.ShowText = false;
            // TODO buraya bir bak pcname & instance
            //barcode.Text = "bdy|" + address + "|" + port + "|" + instance + "|" + database + "|" + username + "|" + password;
            barcode.Text = "bdy|" + address + "|" + port + "|" + server + "|" + database + "|" + username + "|" + password;

            DevExpress.XtraPrinting.BarCode.QRCodeGenerator generator = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
            barcode.Symbology = generator;
            generator.CompactionMode = DevExpress.XtraPrinting.BarCode.QRCodeCompactionMode.Byte;
            generator.ErrorCorrectionLevel = DevExpress.XtraPrinting.BarCode.QRCodeErrorCorrectionLevel.H;
            generator.Version = DevExpress.XtraPrinting.BarCode.QRCodeVersion.AutoVersion;
        }

        private void loadAutoHandleInterval()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DefaultValues.SQLConnection.CONNECTION_STRING))
                {
                    SqlCommand command = new SqlCommand(DefaultValues.SQLQueries.getAutoHandleInterval, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable result = new DataTable();
                    adapter.Fill(result);
                    if (result.Rows.Count == 1)
                    {
                        string value = result.Rows[0]["Value"].ToString();
                        if (!string.IsNullOrWhiteSpace(value))
                        {
                            autoHandleInterval = int.Parse(value);
                        }
                    }

                    numud.Value = autoHandleInterval;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        #endregion

        private void lblQRCode_Click(object sender, EventArgs e)
        {
            IPAddress localhost = Dns.GetHostEntry(Dns.GetHostName()).AddressList
                .Where(ipaddress => !ipaddress.IsIPv6LinkLocal && !ipaddress.IsIPv6Multicast && !ipaddress.IsIPv6SiteLocal).First();

            string address = localhost.ToString();
            string port = "1433";
            string server = DefaultValues.SQLConnection.SERVER_NAME;
            string pcname = string.Empty;
            string instance = string.Empty;
            string database = DefaultValues.SQLConnection.DATABASE_NAME;
            string username = DefaultValues.SQLConnection.USERNAME;
            string password = DefaultValues.SQLConnection.PASSWORD;

            DevExpress.XtraEditors.BarCodeControl barcodeControl = new DevExpress.XtraEditors.BarCodeControl();
            barcodeControl.AutoModule = true;
            barcodeControl.ShowText = false;
            // TODO buraya bir bak pcname & instance
            //barcode.Text = "bdy|" + address + "|" + port + "|" + instance + "|" + database + "|" + username + "|" + password;
            barcodeControl.Text = "bdy|" + address + "|" + port + "|" + server + "|" + database + "|" + username + "|" + password;

            DevExpress.XtraPrinting.BarCode.QRCodeGenerator generator = new DevExpress.XtraPrinting.BarCode.QRCodeGenerator();
            barcodeControl.Symbology = generator;
            generator.CompactionMode = DevExpress.XtraPrinting.BarCode.QRCodeCompactionMode.Byte;
            generator.ErrorCorrectionLevel = DevExpress.XtraPrinting.BarCode.QRCodeErrorCorrectionLevel.H;
            generator.Version = DevExpress.XtraPrinting.BarCode.QRCodeVersion.AutoVersion;

            Form popup = new Form();
            popup.Text = "Bağlantı ayarları QR kodu";
            popup.StartPosition = FormStartPosition.CenterScreen;
            popup.Width = 300;
            popup.Height = 300;
            popup.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            popup.KeyPreview = true;
            popup.KeyDown += popup_KeyDown;

            barcodeControl.Width = 250;
            barcodeControl.Height = 250;
            barcodeControl.Left = 16;
            barcodeControl.Top = 5;
            barcodeControl.HorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            barcodeControl.VerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            barcodeControl.ShowText = false;
            barcodeControl.Parent = popup;
            popup.Show();
        }

        void popup_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                (sender as Form).Close();
            }
        }
    }
}