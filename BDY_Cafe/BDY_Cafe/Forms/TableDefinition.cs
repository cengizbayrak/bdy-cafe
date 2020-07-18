using System;
using System.Data;
using System.Data.SqlClient;
using System.Text.RegularExpressions;
using System.Windows.Forms;
using BDY_Cafe.Utils;

namespace BDY_Cafe
{
    public partial class TableDefinition : Form
    {
        private int lastHandledAdditionNumber;
        private int maxTableNumber;

        public TableDefinition()
        {
            InitializeComponent();
            cmbTableDirection.SelectedIndex = -1;
            cmbTableDirection.SelectedText = Resources.StringResources.CHOOSE_TABLE_DIRECTION;
        }

        private void frmTableDefinition_Shown(object sender, EventArgs e)
        {
            loadList();

            cmbTableDirection.SelectedIndex = -1;
            cmbTableDirection.Text = Resources.StringResources.CHOOSE_TABLE_DIRECTION;

            txtTableName.Focus();
        }

        private void btnAddTable_Click(object sender, EventArgs e)
        {
            // table number
            if (txtTableNumber.TextLength == 0)
            {
                MessageBox.Show(Resources.StringResources.ENTER_VALID_TABLE_NUMBER, Resources.StringResources.ADD_TABLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtTableNumber.Focus();
                return;
            }
            else
            {
                Regex regex = new Regex("^[0-9]+$");
                if (!regex.IsMatch(txtTableNumber.Text))
                {
                    MessageBox.Show(Resources.StringResources.TABLE_NUMBER_MUST_CONTAIN_DIGITS_ONLY, Resources.StringResources.ADD_TABLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                    txtTableNumber.Focus();
                    return;
                }
            }

            // table direction
            if (cmbTableDirection.SelectedIndex < 0)
            {
                MessageBox.Show(Resources.StringResources.CHOOSE_VALID_DIRECTION_INFO_FOR_TABLE, Resources.StringResources.ADD_TABLE, MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbTableDirection.Focus();
                cmbTableDirection.DroppedDown = true;
                return;
            }

            using (SqlConnection connection = new SqlConnection(DefaultValues.SQLConnection.CONNECTION_STRING))
            {
                string hexValueOfSymbol;
                switch (cmbTableDirection.SelectedIndex)
                {
                    case 0: // sağ
                        hexValueOfSymbol = "\u2192";
                        hexValueOfSymbol = "→";
                        break;
                    case 1: // sol
                        hexValueOfSymbol = "\u2190";
                        hexValueOfSymbol = "←";
                        break;
                    case 2: // ileri
                        hexValueOfSymbol = "\u2191";
                        hexValueOfSymbol = "↑";
                        break;
                    case 3: // geri
                        hexValueOfSymbol = "\u2193";
                        hexValueOfSymbol = "↓";
                        break;

                    case 4: // sağ geri
                        hexValueOfSymbol = "\u2198";
                        hexValueOfSymbol = "↘";
                        break;
                    case 5: // sol geri
                        hexValueOfSymbol = "\u2199";
                        hexValueOfSymbol = "↙";
                        break;
                    case 6: // sağ ileri
                        hexValueOfSymbol = "\u2197";
                        hexValueOfSymbol = "↗";
                        break;
                    case 7: // sol ileri
                        hexValueOfSymbol = "\u2196";
                        hexValueOfSymbol = "↖";
                        break;
                    default:
                        hexValueOfSymbol = cmbTableDirection.Text;
                        break;
                }

                string query = @"IF NOT EXISTS(SELECT * FROM Tables WHERE Number = @tableNumber) 
                                BEGIN 
                                    INSERT INTO Tables(Name, Number, Direction) VALUES(@tableName, @tableNumber, @tableDirection) 
                                END";
                SqlCommand command = new SqlCommand(query, connection);
                command.Parameters.AddWithValue("@tableNumber", txtTableNumber.Text);
                command.Parameters.AddWithValue("@tableName", txtTableName.Text);
                command.Parameters.Add("@tableDirection", SqlDbType.NVarChar, 50).Value = hexValueOfSymbol;
                connection.Open();
                int res = command.ExecuteNonQuery();
                if (res > 0)
                {
                    loadList();
                    MessageBox.Show(Resources.StringResources.TABLE_ADDED_SUCCESSFULLY, Resources.StringResources.ADD_TABLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    txtTableName.Clear();
                    txtTableNumber.Clear();
                    cmbTableDirection.SelectedIndex = -1;
                    cmbTableDirection.Text = Resources.StringResources.CHOOSE_TABLE_DIRECTION;
                    txtTableName.Focus();
                }
                else
                {
                    MessageBox.Show(Resources.StringResources.TABLE_NOT_ADDED, Resources.StringResources.ADD_TABLE, MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
                connection.Close();
            }
        }

        private void loadList()
        {
            try
            {
                DataTable list = null;
                using (SqlConnection connection = new SqlConnection(DefaultValues.SQLConnection.CONNECTION_STRING))
                {
                    string query = "SELECT Id, Name, Number, Direction FROM Tables";
                    SqlCommand command = new SqlCommand(query, connection);
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    list = new DataTable();
                    adapter.Fill(list);
                    dgvTables.DataSource = list;
                    dgvTables.Columns["Id"].Visible = false;
                    dgvTables.Columns["Name"].HeaderText = "Masa Adı";
                    dgvTables.Columns["Number"].HeaderText = "Masa Numarası";
                    dgvTables.Columns["Direction"].HeaderText = "Masa Yönü";

                    connection.Close();
                }

                if (dgvTables.Columns["delete"] != null)
                {
                    dgvTables.Columns.Remove("delete");
                }

                if (dgvTables.Columns["edit"] != null)
                {
                    dgvTables.Columns.Remove("edit");
                }
                if (list != null && list.Rows.Count > 0)
                {
                    DataGridViewButtonColumn edit = new DataGridViewButtonColumn();
                    edit.Text = "Düzenle";
                    edit.Name = "edit";
                    edit.UseColumnTextForButtonValue = true;
                    dgvTables.Columns.Add(edit);
                    dgvTables.Columns["edit"].HeaderText = "";

                    DataGridViewButtonColumn delete = new DataGridViewButtonColumn();
                    delete.Text = "Sil";
                    delete.Name = "delete";
                    delete.UseColumnTextForButtonValue = true;
                    dgvTables.Columns.Add(delete);
                    dgvTables.Columns["delete"].HeaderText = "";
                    dgvTables.CellClick += dgvTables_CellClick;

                    dgvTables.ClearSelection();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        void dgvTables_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            int rowIndex = e.RowIndex;
            int columnIndex = e.ColumnIndex;

            if (rowIndex != -1 && rowIndex < dgvTables.Rows.Count)
            {
                if (dgvTables.SelectedRows.Count == 1)
                {
                    if (columnIndex == dgvTables.Columns["delete"].Index)
                    {
                        gboxEditTable.Visible = false;
                        gboxAddTable.Visible = true;
                        try
                        {
                            int id = (int)dgvTables.Rows[rowIndex].Cells["Id"].Value;
                            DialogResult result = MessageBox.Show(Resources.StringResources.ARE_YOU_SURE_TO_DELETE_TABLE, Resources.StringResources.DELETE_TABLE, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
                            if (result == DialogResult.Yes)
                            {
                                using (SqlConnection connection = new SqlConnection(DefaultValues.SQLConnection.CONNECTION_STRING))
                                {
                                    string query = "DELETE FROM Tables WHERE Id=@id";
                                    SqlCommand command = new SqlCommand(query, connection);
                                    command.Parameters.AddWithValue("@id", id);
                                    connection.Open();
                                    try
                                    {
                                        int res = command.ExecuteNonQuery();
                                        if (res > 0)
                                        {
                                            MessageBox.Show(Resources.StringResources.TABLE_DELETED_SUCCESSFULLY, Resources.StringResources.DELETE_TABLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                                            loadList();
                                            if (dgvTables.SelectedRows.Count > 0)
                                            {
                                                dgvTables.ClearSelection();
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
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                    else if (columnIndex == dgvTables.Columns["edit"].Index)
                    {
                        gboxAddTable.Visible = false;
                        gboxEditTable.Visible = true;
                        try
                        {
                            int id = (int)dgvTables.Rows[rowIndex].Cells["Id"].Value;
                            string name = (string)dgvTables.Rows[rowIndex].Cells["Name"].Value;
                            int number = (int)dgvTables.Rows[rowIndex].Cells["Number"].Value;
                            string direction = (string)dgvTables.Rows[rowIndex].Cells["Direction"].Value;
                            btnEdit.Tag = id;

                            txtEditName.Text = name;
                            txtEditNumber.Text = number.ToString();
                            switch (direction)
                            {
                                case "→":
                                    cmbEditDirection.SelectedIndex = 0;
                                    break;
                                case "←":
                                    cmbEditDirection.SelectedIndex = 1;
                                    break;
                                case "↑":
                                    cmbEditDirection.SelectedIndex = 2;
                                    break;
                                case "↓":
                                    cmbEditDirection.SelectedIndex = 3;
                                    break;

                                case "↘":    // sağ geri
                                    cmbEditDirection.SelectedIndex = 4;
                                    break;
                                case "↙":    // sol geri
                                    cmbEditDirection.SelectedIndex = 5;
                                    break;
                                case "↗":    // sağ ileri
                                    cmbEditDirection.SelectedIndex = 6;
                                    break;
                                case "↖":   // sol ileri
                                    cmbEditDirection.SelectedIndex = 7;
                                    break;
                                default:
                                    cmbEditDirection.SelectedIndex = -1;
                                    cmbEditDirection.Text = Resources.StringResources.CHOOSE_TABLE_DIRECTION; ;
                                    break;
                            }
                            txtEditName.Focus();
                            txtEditName.SelectionStart = txtEditName.TextLength;
                        }
                        catch (Exception ex)
                        {
                            MessageBox.Show(ex.Message);
                        }
                    }
                }
            }
        }

        // close on esc key
        private void frmTableDefinition_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                this.Close();
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            int id = -1;
            if (int.TryParse((sender as Button).Tag.ToString(), out id))
            {
                string hexValueOfSymbol;
                switch (cmbEditDirection.SelectedIndex)
                {
                    case 0: // sağ
                        hexValueOfSymbol = "\u2192";
                        hexValueOfSymbol = "→";
                        break;
                    case 1: // sol
                        hexValueOfSymbol = "\u2190";
                        hexValueOfSymbol = "←";
                        break;
                    case 2: // ileri
                        hexValueOfSymbol = "\u2191";
                        hexValueOfSymbol = "↑";
                        break;
                    case 3: // geri
                        hexValueOfSymbol = "\u2193";
                        hexValueOfSymbol = "↓";
                        break;

                    case 4: // sağ geri
                        hexValueOfSymbol = "\u2193";
                        hexValueOfSymbol = "↘";
                        break;
                    case 5: // sol geri
                        hexValueOfSymbol = "\u2193";
                        hexValueOfSymbol = "↙";
                        break;
                    case 6: // sağ ileri
                        hexValueOfSymbol = "\u2193";
                        hexValueOfSymbol = "↗";
                        break;
                    case 7: // sol ileri
                        hexValueOfSymbol = "\u2193";
                        hexValueOfSymbol = "↖";
                        break;
                    default:
                        hexValueOfSymbol = cmbTableDirection.Text;
                        break;
                }

                using (SqlConnection connection = new SqlConnection(DefaultValues.SQLConnection.CONNECTION_STRING))
                {
                    SqlCommand command = new SqlCommand(DefaultValues.SQLQueries.updateTable, connection);
                    command.Parameters.AddWithValue("@id", id);
                    command.Parameters.AddWithValue("@name", txtEditName.Text);
                    command.Parameters.AddWithValue("@number", txtEditNumber.Text);
                    command.Parameters.Add("@direction", SqlDbType.NVarChar, 50).Value = hexValueOfSymbol;
                    connection.Open();
                    try
                    {
                        int res = command.ExecuteNonQuery();
                        if (res > 0)
                        {
                            btnCancel_Click(this, EventArgs.Empty);
                            MessageBox.Show(Resources.StringResources.TABLE_EDITED_SUCCESSFULLY, Resources.StringResources.EDIT_TABLE, MessageBoxButtons.OK, MessageBoxIcon.Information);
                            loadList();
                            if (dgvTables.SelectedRows.Count > 0)
                            {
                                dgvTables.ClearSelection();
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

        private void btnCancel_Click(object sender, EventArgs e)
        {
            txtEditName.Clear();
            txtEditNumber.Clear();
            cmbEditDirection.SelectedIndex = -1;
            gboxAddTable.Visible = true;
            gboxEditTable.Visible = false;
            dgvTables.ClearSelection();
        }
    }
}