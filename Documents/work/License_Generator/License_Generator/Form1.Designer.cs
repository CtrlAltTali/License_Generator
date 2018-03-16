namespace License_Generator
{
    partial class MainWindow
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
            this.importBTN = new System.Windows.Forms.Button();
            this.exportBTN = new System.Windows.Forms.Button();
            this.featLBL = new System.Windows.Forms.Label();
            this.featCMB = new System.Windows.Forms.ComboBox();
            this.featTB = new System.Windows.Forms.TextBox();
            this.generateBTN = new System.Windows.Forms.Button();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // importBTN
            // 
            this.importBTN.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.importBTN.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBTN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.importBTN.Location = new System.Drawing.Point(12, 12);
            this.importBTN.Name = "importBTN";
            this.importBTN.Size = new System.Drawing.Size(95, 39);
            this.importBTN.TabIndex = 0;
            this.importBTN.Text = "Import";
            this.importBTN.UseVisualStyleBackColor = false;
            this.importBTN.Click += new System.EventHandler(this.importBTN_Click);
            // 
            // exportBTN
            // 
            this.exportBTN.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.exportBTN.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBTN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.exportBTN.Location = new System.Drawing.Point(113, 12);
            this.exportBTN.Name = "exportBTN";
            this.exportBTN.Size = new System.Drawing.Size(100, 39);
            this.exportBTN.TabIndex = 1;
            this.exportBTN.Text = "Export";
            this.exportBTN.UseVisualStyleBackColor = false;
            // 
            // featLBL
            // 
            this.featLBL.AutoSize = true;
            this.featLBL.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.featLBL.ForeColor = System.Drawing.Color.MidnightBlue;
            this.featLBL.Location = new System.Drawing.Point(495, 28);
            this.featLBL.Name = "featLBL";
            this.featLBL.Size = new System.Drawing.Size(86, 24);
            this.featLBL.TabIndex = 2;
            this.featLBL.Text = "Feature:";
            // 
            // featCMB
            // 
            this.featCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.featCMB.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.featCMB.FormattingEnabled = true;
            this.featCMB.Items.AddRange(new object[] {
            "Number",
            "Text"});
            this.featCMB.Location = new System.Drawing.Point(585, 25);
            this.featCMB.Name = "featCMB";
            this.featCMB.Size = new System.Drawing.Size(121, 32);
            this.featCMB.TabIndex = 3;
            // 
            // featTB
            // 
            this.featTB.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.featTB.Location = new System.Drawing.Point(712, 25);
            this.featTB.Name = "featTB";
            this.featTB.Size = new System.Drawing.Size(100, 30);
            this.featTB.TabIndex = 4;
            // 
            // generateBTN
            // 
            this.generateBTN.BackColor = System.Drawing.SystemColors.GradientActiveCaption;
            this.generateBTN.Font = new System.Drawing.Font("Trebuchet MS", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateBTN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.generateBTN.Location = new System.Drawing.Point(219, 12);
            this.generateBTN.Name = "generateBTN";
            this.generateBTN.Size = new System.Drawing.Size(134, 39);
            this.generateBTN.TabIndex = 5;
            this.generateBTN.Text = "Genarate";
            this.generateBTN.UseVisualStyleBackColor = false;
            this.generateBTN.Click += new System.EventHandler(this.generateBTN_Click);
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 71);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(800, 337);
            this.dataGridView1.TabIndex = 6;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(836, 451);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.generateBTN);
            this.Controls.Add(this.featTB);
            this.Controls.Add(this.featCMB);
            this.Controls.Add(this.featLBL);
            this.Controls.Add(this.exportBTN);
            this.Controls.Add(this.importBTN);
            this.Name = "MainWindow";
            this.Text = "License Generator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button importBTN;
        private System.Windows.Forms.Button exportBTN;
        private System.Windows.Forms.Label featLBL;
        private System.Windows.Forms.ComboBox featCMB;
        private System.Windows.Forms.TextBox featTB;
        private System.Windows.Forms.Button generateBTN;
        private System.Windows.Forms.DataGridView dataGridView1;
    }
}

