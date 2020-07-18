namespace BDY_Cafe
{
    partial class TableDefinition
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(TableDefinition));
            this.dgvTables = new System.Windows.Forms.DataGridView();
            this.pnlLeft = new System.Windows.Forms.Panel();
            this.gboxEditTable = new System.Windows.Forms.GroupBox();
            this.btnCancel = new System.Windows.Forms.Button();
            this.btnEdit = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.cmbEditDirection = new System.Windows.Forms.ComboBox();
            this.txtEditName = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtEditNumber = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.gboxAddTable = new System.Windows.Forms.GroupBox();
            this.btnAddTable = new System.Windows.Forms.Button();
            this.lblTableName = new System.Windows.Forms.Label();
            this.cmbTableDirection = new System.Windows.Forms.ComboBox();
            this.txtTableName = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txtTableNumber = new System.Windows.Forms.TextBox();
            this.lblTableNumber = new System.Windows.Forms.Label();
            this.InfoText = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.label5 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).BeginInit();
            this.pnlLeft.SuspendLayout();
            this.gboxEditTable.SuspendLayout();
            this.gboxAddTable.SuspendLayout();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // dgvTables
            // 
            this.dgvTables.AllowUserToAddRows = false;
            this.dgvTables.AllowUserToDeleteRows = false;
            this.dgvTables.AllowUserToResizeColumns = false;
            this.dgvTables.AllowUserToResizeRows = false;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dgvTables.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvTables.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvTables.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.SystemColors.Control;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle5.ForeColor = System.Drawing.SystemColors.WindowText;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvTables.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.dgvTables.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvTables.Location = new System.Drawing.Point(3, 163);
            this.dgvTables.MultiSelect = false;
            this.dgvTables.Name = "dgvTables";
            this.dgvTables.ReadOnly = true;
            this.dgvTables.RowHeadersVisible = false;
            this.dgvTables.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.AutoSizeToAllHeaders;
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dgvTables.RowsDefaultCellStyle = dataGridViewCellStyle6;
            this.dgvTables.RowTemplate.Height = 30;
            this.dgvTables.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvTables.Size = new System.Drawing.Size(1351, 529);
            this.dgvTables.TabIndex = 0;
            // 
            // pnlLeft
            // 
            this.pnlLeft.Controls.Add(this.gboxEditTable);
            this.pnlLeft.Controls.Add(this.gboxAddTable);
            this.pnlLeft.Location = new System.Drawing.Point(3, 91);
            this.pnlLeft.Name = "pnlLeft";
            this.pnlLeft.Size = new System.Drawing.Size(1344, 72);
            this.pnlLeft.TabIndex = 1;
            // 
            // gboxEditTable
            // 
            this.gboxEditTable.Controls.Add(this.btnCancel);
            this.gboxEditTable.Controls.Add(this.btnEdit);
            this.gboxEditTable.Controls.Add(this.label1);
            this.gboxEditTable.Controls.Add(this.cmbEditDirection);
            this.gboxEditTable.Controls.Add(this.txtEditName);
            this.gboxEditTable.Controls.Add(this.label2);
            this.gboxEditTable.Controls.Add(this.txtEditNumber);
            this.gboxEditTable.Controls.Add(this.label4);
            this.gboxEditTable.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gboxEditTable.Location = new System.Drawing.Point(3, 3);
            this.gboxEditTable.Name = "gboxEditTable";
            this.gboxEditTable.Size = new System.Drawing.Size(1338, 61);
            this.gboxEditTable.TabIndex = 8;
            this.gboxEditTable.TabStop = false;
            this.gboxEditTable.Text = "Masa Düzenle";
            this.gboxEditTable.Visible = false;
            // 
            // btnCancel
            // 
            this.btnCancel.Location = new System.Drawing.Point(799, 19);
            this.btnCancel.Name = "btnCancel";
            this.btnCancel.Size = new System.Drawing.Size(75, 27);
            this.btnCancel.TabIndex = 8;
            this.btnCancel.Text = "İptal";
            this.btnCancel.UseVisualStyleBackColor = true;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);
            // 
            // btnEdit
            // 
            this.btnEdit.Location = new System.Drawing.Point(880, 19);
            this.btnEdit.Name = "btnEdit";
            this.btnEdit.Size = new System.Drawing.Size(75, 27);
            this.btnEdit.TabIndex = 7;
            this.btnEdit.Text = "Güncelle";
            this.btnEdit.UseVisualStyleBackColor = true;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(6, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(67, 18);
            this.label1.TabIndex = 0;
            this.label1.Text = "Masa adı:";
            // 
            // cmbEditDirection
            // 
            this.cmbEditDirection.FormattingEnabled = true;
            this.cmbEditDirection.Items.AddRange(new object[] {
            "Sağ   →",
            "Sol    ←",
            "İleri    ↑",
            "Geri   ↓",
            "Sağ geri ↘",
            "Sol geri ↙",
            "Sağ ileri ↗",
            "Sol ileri ↖"});
            this.cmbEditDirection.Location = new System.Drawing.Point(609, 19);
            this.cmbEditDirection.Name = "cmbEditDirection";
            this.cmbEditDirection.Size = new System.Drawing.Size(140, 26);
            this.cmbEditDirection.TabIndex = 5;
            // 
            // txtEditName
            // 
            this.txtEditName.Location = new System.Drawing.Point(74, 19);
            this.txtEditName.Name = "txtEditName";
            this.txtEditName.Size = new System.Drawing.Size(140, 26);
            this.txtEditName.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(524, 22);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(79, 18);
            this.label2.TabIndex = 2;
            this.label2.Text = "Masa yönü:";
            // 
            // txtEditNumber
            // 
            this.txtEditNumber.Location = new System.Drawing.Point(353, 19);
            this.txtEditNumber.Name = "txtEditNumber";
            this.txtEditNumber.Size = new System.Drawing.Size(140, 26);
            this.txtEditNumber.TabIndex = 4;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(242, 22);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(105, 18);
            this.label4.TabIndex = 1;
            this.label4.Text = "Masa numarası:";
            // 
            // gboxAddTable
            // 
            this.gboxAddTable.Controls.Add(this.btnAddTable);
            this.gboxAddTable.Controls.Add(this.lblTableName);
            this.gboxAddTable.Controls.Add(this.cmbTableDirection);
            this.gboxAddTable.Controls.Add(this.txtTableName);
            this.gboxAddTable.Controls.Add(this.label3);
            this.gboxAddTable.Controls.Add(this.txtTableNumber);
            this.gboxAddTable.Controls.Add(this.lblTableNumber);
            this.gboxAddTable.Font = new System.Drawing.Font("Calibri", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gboxAddTable.Location = new System.Drawing.Point(3, 3);
            this.gboxAddTable.Name = "gboxAddTable";
            this.gboxAddTable.Size = new System.Drawing.Size(1338, 61);
            this.gboxAddTable.TabIndex = 6;
            this.gboxAddTable.TabStop = false;
            this.gboxAddTable.Text = "Masa Ekle";
            // 
            // btnAddTable
            // 
            this.btnAddTable.Location = new System.Drawing.Point(880, 19);
            this.btnAddTable.Name = "btnAddTable";
            this.btnAddTable.Size = new System.Drawing.Size(75, 27);
            this.btnAddTable.TabIndex = 7;
            this.btnAddTable.Text = "Ekle";
            this.btnAddTable.UseVisualStyleBackColor = true;
            this.btnAddTable.Click += new System.EventHandler(this.btnAddTable_Click);
            // 
            // lblTableName
            // 
            this.lblTableName.AutoSize = true;
            this.lblTableName.Location = new System.Drawing.Point(6, 22);
            this.lblTableName.Name = "lblTableName";
            this.lblTableName.Size = new System.Drawing.Size(67, 18);
            this.lblTableName.TabIndex = 0;
            this.lblTableName.Text = "Masa adı:";
            // 
            // cmbTableDirection
            // 
            this.cmbTableDirection.FormattingEnabled = true;
            this.cmbTableDirection.Items.AddRange(new object[] {
            "Sağ   →",
            "Sol    ←",
            "İleri    ↑",
            "Geri   ↓",
            "Sağ geri ↘",
            "Sol geri ↙",
            "Sağ ileri ↗",
            "Sol ileri ↖"});
            this.cmbTableDirection.Location = new System.Drawing.Point(609, 19);
            this.cmbTableDirection.Name = "cmbTableDirection";
            this.cmbTableDirection.Size = new System.Drawing.Size(140, 26);
            this.cmbTableDirection.TabIndex = 5;
            // 
            // txtTableName
            // 
            this.txtTableName.Location = new System.Drawing.Point(74, 19);
            this.txtTableName.Name = "txtTableName";
            this.txtTableName.Size = new System.Drawing.Size(140, 26);
            this.txtTableName.TabIndex = 3;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(524, 22);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(79, 18);
            this.label3.TabIndex = 2;
            this.label3.Text = "Masa yönü:";
            // 
            // txtTableNumber
            // 
            this.txtTableNumber.Location = new System.Drawing.Point(353, 19);
            this.txtTableNumber.Name = "txtTableNumber";
            this.txtTableNumber.Size = new System.Drawing.Size(140, 26);
            this.txtTableNumber.TabIndex = 4;
            // 
            // lblTableNumber
            // 
            this.lblTableNumber.AutoSize = true;
            this.lblTableNumber.Location = new System.Drawing.Point(242, 22);
            this.lblTableNumber.Name = "lblTableNumber";
            this.lblTableNumber.Size = new System.Drawing.Size(105, 18);
            this.lblTableNumber.TabIndex = 1;
            this.lblTableNumber.Text = "Masa numarası:";
            // 
            // InfoText
            // 
            this.InfoText.AutoSize = true;
            this.InfoText.BackColor = System.Drawing.Color.Transparent;
            this.InfoText.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.InfoText.Location = new System.Drawing.Point(75, 9);
            this.InfoText.Name = "InfoText";
            this.InfoText.Size = new System.Drawing.Size(115, 16);
            this.InfoText.TabIndex = 3;
            this.InfoText.Text = "Masa Tanımları";
            // 
            // panel1
            // 
            this.panel1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.panel1.BackColor = System.Drawing.Color.White;
            this.panel1.Controls.Add(this.label5);
            this.panel1.Controls.Add(this.pictureBox1);
            this.panel1.Controls.Add(this.InfoText);
            this.panel1.Location = new System.Drawing.Point(3, 3);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1344, 85);
            this.panel1.TabIndex = 2;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(78, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(653, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Masalarınızı bu ekran sayesinde tanımlayabilirsiniz. Masa yönlerini seçerken moni" +
    "tör için hazırlanmış listeyi ve monitör yönünü dikkate alınız.";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(7, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(62, 77);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // TableDefinition
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 692);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.pnlLeft);
            this.Controls.Add(this.dgvTables);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "TableDefinition";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Masalar";
            this.Shown += new System.EventHandler(this.frmTableDefinition_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmTableDefinition_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvTables)).EndInit();
            this.pnlLeft.ResumeLayout(false);
            this.gboxEditTable.ResumeLayout(false);
            this.gboxEditTable.PerformLayout();
            this.gboxAddTable.ResumeLayout(false);
            this.gboxAddTable.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvTables;
        private System.Windows.Forms.Panel pnlLeft;
        private System.Windows.Forms.GroupBox gboxAddTable;
        private System.Windows.Forms.Label lblTableName;
        private System.Windows.Forms.ComboBox cmbTableDirection;
        private System.Windows.Forms.TextBox txtTableName;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label lblTableNumber;
        private System.Windows.Forms.Button btnAddTable;
        private System.Windows.Forms.TextBox txtTableNumber;
        private System.Windows.Forms.GroupBox gboxEditTable;
        private System.Windows.Forms.Button btnEdit;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox cmbEditDirection;
        private System.Windows.Forms.TextBox txtEditName;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtEditNumber;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btnCancel;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label InfoText;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Label label5;
    }
}