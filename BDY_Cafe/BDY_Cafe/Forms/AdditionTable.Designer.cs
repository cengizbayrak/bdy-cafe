namespace BDY_Cafe
{
    partial class AdditionTable
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
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle1 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle2 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle3 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            DevExpress.XtraPrinting.BarCode.Code128Generator code128Generator1 = new DevExpress.XtraPrinting.BarCode.Code128Generator();
            this.dgvAdditionTable = new System.Windows.Forms.DataGridView();
            this.tmrCheckUpdateList = new System.Windows.Forms.Timer(this.components);
            this.txtSearch = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.pnlFeatures = new System.Windows.Forms.Panel();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.gboxAutoHandle = new System.Windows.Forms.GroupBox();
            this.btnSave = new System.Windows.Forms.Button();
            this.numud = new System.Windows.Forms.NumericUpDown();
            this.lblMinute = new System.Windows.Forms.Label();
            this.lblAutoHandleNote = new System.Windows.Forms.Label();
            this.gboxQRCode = new System.Windows.Forms.GroupBox();
            this.lblQRCode = new System.Windows.Forms.Label();
            this.barcode = new DevExpress.XtraEditors.BarCodeControl();
            this.gboxAdditionSearch = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.toolTip = new System.Windows.Forms.ToolTip(this.components);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdditionTable)).BeginInit();
            this.pnlFeatures.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.gboxAutoHandle.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numud)).BeginInit();
            this.gboxQRCode.SuspendLayout();
            this.gboxAdditionSearch.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvAdditionTable
            // 
            this.dgvAdditionTable.AllowUserToAddRows = false;
            this.dgvAdditionTable.AllowUserToDeleteRows = false;
            this.dgvAdditionTable.AllowUserToResizeColumns = false;
            this.dgvAdditionTable.AllowUserToResizeRows = false;
            dataGridViewCellStyle1.BackColor = System.Drawing.Color.WhiteSmoke;
            dataGridViewCellStyle1.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dgvAdditionTable.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle1;
            this.dgvAdditionTable.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dgvAdditionTable.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            dataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(42)))), ((int)(((byte)(98)))), ((int)(((byte)(143)))));
            dataGridViewCellStyle2.Font = new System.Drawing.Font("Calibri", 27.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight;
            dataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.dgvAdditionTable.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle2;
            this.dgvAdditionTable.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleCenter;
            dataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.Window;
            dataGridViewCellStyle3.Font = new System.Drawing.Font("Calibri", 18F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            dataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.ControlText;
            dataGridViewCellStyle3.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(62)))), ((int)(((byte)(146)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.HighlightText;
            dataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.dgvAdditionTable.DefaultCellStyle = dataGridViewCellStyle3;
            this.dgvAdditionTable.EnableHeadersVisualStyles = false;
            this.dgvAdditionTable.Location = new System.Drawing.Point(140, 0);
            this.dgvAdditionTable.MultiSelect = false;
            this.dgvAdditionTable.Name = "dgvAdditionTable";
            this.dgvAdditionTable.ReadOnly = true;
            this.dgvAdditionTable.RowHeadersVisible = false;
            this.dgvAdditionTable.RowHeadersWidth = 100;
            dataGridViewCellStyle4.Font = new System.Drawing.Font("Calibri", 32.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.dgvAdditionTable.RowsDefaultCellStyle = dataGridViewCellStyle4;
            this.dgvAdditionTable.RowTemplate.Height = 54;
            this.dgvAdditionTable.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.dgvAdditionTable.Size = new System.Drawing.Size(1210, 745);
            this.dgvAdditionTable.TabIndex = 0;
            // 
            // tmrCheckUpdateList
            // 
            this.tmrCheckUpdateList.Interval = 1500;
            this.tmrCheckUpdateList.Tick += new System.EventHandler(this.tmrCheckUpdateList_Tick);
            // 
            // txtSearch
            // 
            this.txtSearch.Font = new System.Drawing.Font("Calibri", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.txtSearch.Location = new System.Drawing.Point(9, 45);
            this.txtSearch.Name = "txtSearch";
            this.txtSearch.Size = new System.Drawing.Size(113, 47);
            this.txtSearch.TabIndex = 0;
            this.txtSearch.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.txtSearch_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(10, 16);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(113, 26);
            this.label1.TabIndex = 1;
            this.label1.Text = "Adisyon ara";
            // 
            // pnlFeatures
            // 
            this.pnlFeatures.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.pnlFeatures.Controls.Add(this.pictureBox1);
            this.pnlFeatures.Controls.Add(this.gboxAutoHandle);
            this.pnlFeatures.Controls.Add(this.gboxQRCode);
            this.pnlFeatures.Controls.Add(this.gboxAdditionSearch);
            this.pnlFeatures.Location = new System.Drawing.Point(0, 0);
            this.pnlFeatures.Name = "pnlFeatures";
            this.pnlFeatures.Size = new System.Drawing.Size(138, 745);
            this.pnlFeatures.TabIndex = 1;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::BDY_Cafe.Properties.Resources.arjantin_logo;
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(138, 131);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // gboxAutoHandle
            // 
            this.gboxAutoHandle.Controls.Add(this.btnSave);
            this.gboxAutoHandle.Controls.Add(this.numud);
            this.gboxAutoHandle.Controls.Add(this.lblMinute);
            this.gboxAutoHandle.Controls.Add(this.lblAutoHandleNote);
            this.gboxAutoHandle.Location = new System.Drawing.Point(3, 376);
            this.gboxAutoHandle.Name = "gboxAutoHandle";
            this.gboxAutoHandle.Size = new System.Drawing.Size(132, 194);
            this.gboxAutoHandle.TabIndex = 6;
            this.gboxAutoHandle.TabStop = false;
            this.gboxAutoHandle.Text = "Otomatik kapatma";
            // 
            // btnSave
            // 
            this.btnSave.Location = new System.Drawing.Point(54, 58);
            this.btnSave.Name = "btnSave";
            this.btnSave.Size = new System.Drawing.Size(75, 23);
            this.btnSave.TabIndex = 11;
            this.btnSave.Text = "Kaydet";
            this.btnSave.UseVisualStyleBackColor = true;
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // numud
            // 
            this.numud.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.numud.Location = new System.Drawing.Point(9, 19);
            this.numud.Name = "numud";
            this.numud.Size = new System.Drawing.Size(63, 33);
            this.numud.TabIndex = 9;
            this.numud.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            this.numud.Value = new decimal(new int[] {
            100,
            0,
            0,
            0});
            // 
            // lblMinute
            // 
            this.lblMinute.AutoSize = true;
            this.lblMinute.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblMinute.Location = new System.Drawing.Point(73, 26);
            this.lblMinute.Name = "lblMinute";
            this.lblMinute.Size = new System.Drawing.Size(54, 19);
            this.lblMinute.TabIndex = 10;
            this.lblMinute.Text = "dakika";
            // 
            // lblAutoHandleNote
            // 
            this.lblAutoHandleNote.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblAutoHandleNote.Location = new System.Drawing.Point(6, 87);
            this.lblAutoHandleNote.Name = "lblAutoHandleNote";
            this.lblAutoHandleNote.Size = new System.Drawing.Size(126, 104);
            this.lblAutoHandleNote.TabIndex = 8;
            this.lblAutoHandleNote.Text = "NOT: Belirlenen ve kaydedilen dakika sonra, kapatılmamış adisyonların otomatik ka" +
    "panmasını sağlar.\r\n0 dakika olarak ayarlandığında bu özellik pasif duruma gelir." +
    "";
            // 
            // gboxQRCode
            // 
            this.gboxQRCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.gboxQRCode.Controls.Add(this.lblQRCode);
            this.gboxQRCode.Controls.Add(this.barcode);
            this.gboxQRCode.Location = new System.Drawing.Point(3, 580);
            this.gboxQRCode.Name = "gboxQRCode";
            this.gboxQRCode.Size = new System.Drawing.Size(132, 162);
            this.gboxQRCode.TabIndex = 7;
            this.gboxQRCode.TabStop = false;
            this.gboxQRCode.Text = "Tablet bağlantı ayarı";
            // 
            // lblQRCode
            // 
            this.lblQRCode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblQRCode.AutoSize = true;
            this.lblQRCode.Font = new System.Drawing.Font("Calibri", 11.25F, ((System.Drawing.FontStyle)((System.Drawing.FontStyle.Bold | System.Drawing.FontStyle.Underline))), System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.lblQRCode.Location = new System.Drawing.Point(13, 15);
            this.lblQRCode.Name = "lblQRCode";
            this.lblQRCode.Size = new System.Drawing.Size(106, 18);
            this.lblQRCode.TabIndex = 3;
            this.lblQRCode.Text = "Bağlantı QR Kod";
            this.toolTip.SetToolTip(this.lblQRCode, "Açılır ekranda görmek için tıklayın.");
            this.lblQRCode.Click += new System.EventHandler(this.lblQRCode_Click);
            // 
            // barcode
            // 
            this.barcode.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.barcode.HorizontalAlignment = DevExpress.Utils.HorzAlignment.Center;
            this.barcode.Location = new System.Drawing.Point(10, 36);
            this.barcode.Name = "barcode";
            this.barcode.Padding = new System.Windows.Forms.Padding(10, 2, 10, 0);
            this.barcode.Size = new System.Drawing.Size(113, 113);
            this.barcode.Symbology = code128Generator1;
            this.barcode.TabIndex = 2;
            this.barcode.VerticalAlignment = DevExpress.Utils.VertAlignment.Center;
            // 
            // gboxAdditionSearch
            // 
            this.gboxAdditionSearch.Controls.Add(this.txtSearch);
            this.gboxAdditionSearch.Controls.Add(this.label1);
            this.gboxAdditionSearch.Controls.Add(this.label2);
            this.gboxAdditionSearch.Location = new System.Drawing.Point(3, 146);
            this.gboxAdditionSearch.Name = "gboxAdditionSearch";
            this.gboxAdditionSearch.Size = new System.Drawing.Size(132, 218);
            this.gboxAdditionSearch.TabIndex = 5;
            this.gboxAdditionSearch.TabStop = false;
            this.gboxAdditionSearch.Text = "Adisyon arama";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label2.Location = new System.Drawing.Point(6, 95);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(124, 121);
            this.label2.TabIndex = 0;
            this.label2.Text = "NOT: Bir adisyon numarasını arayın. Liste aramaya göre daralacaktır. Arama yaptık" +
    "tan sonra Enter\'a bastığınızda listede seçili durumdaki adisyonu kapatmanız yönü" +
    "nde sizi uyarır.";
            // 
            // AdditionTable
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1350, 745);
            this.Controls.Add(this.pnlFeatures);
            this.Controls.Add(this.dgvAdditionTable);
            this.KeyPreview = true;
            this.Name = "AdditionTable";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Adisyon & Masa";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.dgvAdditionTable)).EndInit();
            this.pnlFeatures.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.gboxAutoHandle.ResumeLayout(false);
            this.gboxAutoHandle.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.numud)).EndInit();
            this.gboxQRCode.ResumeLayout(false);
            this.gboxQRCode.PerformLayout();
            this.gboxAdditionSearch.ResumeLayout(false);
            this.gboxAdditionSearch.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvAdditionTable;
        private System.Windows.Forms.Timer tmrCheckUpdateList;
        private System.Windows.Forms.TextBox txtSearch;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlFeatures;
        private System.Windows.Forms.GroupBox gboxAutoHandle;
        private System.Windows.Forms.Label lblAutoHandleNote;
        private System.Windows.Forms.GroupBox gboxQRCode;
        private System.Windows.Forms.Label lblQRCode;
        private DevExpress.XtraEditors.BarCodeControl barcode;
        private System.Windows.Forms.GroupBox gboxAdditionSearch;
        private System.Windows.Forms.Button btnSave;
        private System.Windows.Forms.NumericUpDown numud;
        private System.Windows.Forms.Label lblMinute;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.ToolTip toolTip;
    }
}

