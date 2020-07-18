namespace BDY_Cafe
{
    partial class Main
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Main));
            this.btnAdditionTable = new System.Windows.Forms.Button();
            this.btnTables = new System.Windows.Forms.Button();
            this.btnReport = new System.Windows.Forms.Button();
            this.btnAdditionTableList = new System.Windows.Forms.Button();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // btnAdditionTable
            // 
            this.btnAdditionTable.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdditionTable.Location = new System.Drawing.Point(12, 302);
            this.btnAdditionTable.Name = "btnAdditionTable";
            this.btnAdditionTable.Size = new System.Drawing.Size(276, 48);
            this.btnAdditionTable.TabIndex = 0;
            this.btnAdditionTable.Text = "Adisyon && Masa";
            this.btnAdditionTable.UseVisualStyleBackColor = true;
            this.btnAdditionTable.Click += new System.EventHandler(this.btnAdditionTable_Click);
            // 
            // btnTables
            // 
            this.btnTables.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnTables.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnTables.Location = new System.Drawing.Point(12, 356);
            this.btnTables.Name = "btnTables";
            this.btnTables.Size = new System.Drawing.Size(276, 48);
            this.btnTables.TabIndex = 1;
            this.btnTables.Text = "Masalar";
            this.btnTables.UseVisualStyleBackColor = true;
            this.btnTables.Click += new System.EventHandler(this.btnTables_Click);
            // 
            // btnReport
            // 
            this.btnReport.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnReport.Location = new System.Drawing.Point(12, 410);
            this.btnReport.Name = "btnReport";
            this.btnReport.Size = new System.Drawing.Size(276, 48);
            this.btnReport.TabIndex = 2;
            this.btnReport.Text = "Rapor";
            this.btnReport.UseVisualStyleBackColor = true;
            this.btnReport.Click += new System.EventHandler(this.btnReport_Click);
            // 
            // btnAdditionTableList
            // 
            this.btnAdditionTableList.Font = new System.Drawing.Font("Arial", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.btnAdditionTableList.Location = new System.Drawing.Point(12, 464);
            this.btnAdditionTableList.Name = "btnAdditionTableList";
            this.btnAdditionTableList.Size = new System.Drawing.Size(276, 48);
            this.btnAdditionTableList.TabIndex = 3;
            this.btnAdditionTableList.Text = "Adisyon && Masa (Monitör)";
            this.btnAdditionTableList.UseVisualStyleBackColor = true;
            this.btnAdditionTableList.Click += new System.EventHandler(this.btnAdditionTableList_Click);
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = ((System.Drawing.Image)(resources.GetObject("pictureBox1.Image")));
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(300, 285);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox1.TabIndex = 4;
            this.pictureBox1.TabStop = false;
            // 
            // Main
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(300, 527);
            this.Controls.Add(this.btnAdditionTableList);
            this.Controls.Add(this.btnReport);
            this.Controls.Add(this.btnTables);
            this.Controls.Add(this.btnAdditionTable);
            this.Controls.Add(this.pictureBox1);
            this.KeyPreview = true;
            this.MaximizeBox = false;
            this.Name = "Main";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Main";
            this.Load += new System.EventHandler(this.Main_Load);
            this.Shown += new System.EventHandler(this.frmMain_Shown);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.frmMain_KeyDown);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button btnAdditionTable;
        private System.Windows.Forms.Button btnTables;
        private System.Windows.Forms.Button btnReport;
        private System.Windows.Forms.Button btnAdditionTableList;
        private System.Windows.Forms.PictureBox pictureBox1;
    }
}