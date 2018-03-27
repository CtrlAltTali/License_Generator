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
            this.featLBL = new System.Windows.Forms.Label();
            this.featCMB = new System.Windows.Forms.ComboBox();
            this.featTB = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.userLBL = new System.Windows.Forms.Label();
            this.userTB = new System.Windows.Forms.TextBox();
            this.ipLBL = new System.Windows.Forms.Label();
            this.ipTB = new System.Windows.Forms.TextBox();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.importBTN = new System.Windows.Forms.Button();
            this.exportBTN = new System.Windows.Forms.Button();
            this.plinkBTN = new System.Windows.Forms.Button();
            this.keyBTN = new System.Windows.Forms.Button();
            this.generateBTN = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // featLBL
            // 
            this.featLBL.AutoSize = true;
            this.featLBL.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.featLBL.ForeColor = System.Drawing.Color.MidnightBlue;
            this.featLBL.Location = new System.Drawing.Point(833, 236);
            this.featLBL.Name = "featLBL";
            this.featLBL.Size = new System.Drawing.Size(74, 20);
            this.featLBL.TabIndex = 2;
            this.featLBL.Text = "Operation:";
            // 
            // featCMB
            // 
            this.featCMB.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.featCMB.Font = new System.Drawing.Font("Arial Narrow", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.featCMB.FormattingEnabled = true;
            this.featCMB.Items.AddRange(new object[] {
            "Number",
            "Feature"});
            this.featCMB.Location = new System.Drawing.Point(913, 236);
            this.featCMB.Name = "featCMB";
            this.featCMB.Size = new System.Drawing.Size(82, 24);
            this.featCMB.TabIndex = 3;
            // 
            // featTB
            // 
            this.featTB.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.featTB.Location = new System.Drawing.Point(1001, 235);
            this.featTB.Name = "featTB";
            this.featTB.Size = new System.Drawing.Size(80, 25);
            this.featTB.TabIndex = 4;
            // 
            // dataGridView1
            // 
            this.dataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView1.Location = new System.Drawing.Point(12, 12);
            this.dataGridView1.Name = "dataGridView1";
            this.dataGridView1.ReadOnly = true;
            this.dataGridView1.Size = new System.Drawing.Size(800, 545);
            this.dataGridView1.TabIndex = 6;
            // 
            // userLBL
            // 
            this.userLBL.AutoSize = true;
            this.userLBL.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLBL.ForeColor = System.Drawing.Color.MidnightBlue;
            this.userLBL.Location = new System.Drawing.Point(833, 279);
            this.userLBL.Name = "userLBL";
            this.userLBL.Size = new System.Drawing.Size(41, 20);
            this.userLBL.TabIndex = 7;
            this.userLBL.Text = "User:";
            // 
            // userTB
            // 
            this.userTB.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTB.Location = new System.Drawing.Point(913, 276);
            this.userTB.Name = "userTB";
            this.userTB.Size = new System.Drawing.Size(100, 25);
            this.userTB.TabIndex = 8;
            // 
            // ipLBL
            // 
            this.ipLBL.AutoSize = true;
            this.ipLBL.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipLBL.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ipLBL.Location = new System.Drawing.Point(833, 322);
            this.ipLBL.Name = "ipLBL";
            this.ipLBL.Size = new System.Drawing.Size(79, 20);
            this.ipLBL.TabIndex = 9;
            this.ipLBL.Text = "IP Address:";
            // 
            // ipTB
            // 
            this.ipTB.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipTB.Location = new System.Drawing.Point(913, 319);
            this.ipTB.Name = "ipTB";
            this.ipTB.Size = new System.Drawing.Size(151, 25);
            this.ipTB.TabIndex = 10;
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.progressBar.Location = new System.Drawing.Point(837, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(244, 23);
            this.progressBar.TabIndex = 11;
            // 
            // importBTN
            // 
            this.importBTN.BackColor = System.Drawing.Color.Thistle;
            this.importBTN.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.importBTN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.importBTN.Location = new System.Drawing.Point(837, 41);
            this.importBTN.Name = "importBTN";
            this.importBTN.Size = new System.Drawing.Size(133, 32);
            this.importBTN.TabIndex = 12;
            this.importBTN.Text = "Import Excel File";
            this.importBTN.UseVisualStyleBackColor = false;
            this.importBTN.Click += new System.EventHandler(this.importBTN_Click);
            // 
            // exportBTN
            // 
            this.exportBTN.BackColor = System.Drawing.Color.Thistle;
            this.exportBTN.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.exportBTN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.exportBTN.Location = new System.Drawing.Point(837, 79);
            this.exportBTN.Name = "exportBTN";
            this.exportBTN.Size = new System.Drawing.Size(133, 32);
            this.exportBTN.TabIndex = 13;
            this.exportBTN.Text = "Export Excel File";
            this.exportBTN.UseVisualStyleBackColor = false;
            this.exportBTN.Click += new System.EventHandler(this.exportBTN_Click);
            // 
            // plinkBTN
            // 
            this.plinkBTN.BackColor = System.Drawing.SystemColors.Control;
            this.plinkBTN.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.plinkBTN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.plinkBTN.Location = new System.Drawing.Point(837, 117);
            this.plinkBTN.Name = "plinkBTN";
            this.plinkBTN.Size = new System.Drawing.Size(133, 32);
            this.plinkBTN.TabIndex = 14;
            this.plinkBTN.Text = "Open PLINK.exe";
            this.plinkBTN.UseVisualStyleBackColor = false;
            this.plinkBTN.Click += new System.EventHandler(this.plinkBTN_Click);
            // 
            // keyBTN
            // 
            this.keyBTN.BackColor = System.Drawing.SystemColors.Control;
            this.keyBTN.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.keyBTN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.keyBTN.Location = new System.Drawing.Point(837, 155);
            this.keyBTN.Name = "keyBTN";
            this.keyBTN.Size = new System.Drawing.Size(133, 32);
            this.keyBTN.TabIndex = 15;
            this.keyBTN.Text = "Choose Key";
            this.keyBTN.UseVisualStyleBackColor = false;
            this.keyBTN.Click += new System.EventHandler(this.keyBTN_Click);
            // 
            // generateBTN
            // 
            this.generateBTN.BackColor = System.Drawing.Color.PowderBlue;
            this.generateBTN.Font = new System.Drawing.Font("Arial Narrow", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.generateBTN.ForeColor = System.Drawing.Color.MidnightBlue;
            this.generateBTN.Location = new System.Drawing.Point(931, 525);
            this.generateBTN.Name = "generateBTN";
            this.generateBTN.Size = new System.Drawing.Size(133, 32);
            this.generateBTN.TabIndex = 16;
            this.generateBTN.Text = "Generate";
            this.generateBTN.UseVisualStyleBackColor = false;
            this.generateBTN.Click += new System.EventHandler(this.generateBTN_Click);
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1091, 569);
            this.Controls.Add(this.generateBTN);
            this.Controls.Add(this.keyBTN);
            this.Controls.Add(this.plinkBTN);
            this.Controls.Add(this.exportBTN);
            this.Controls.Add(this.importBTN);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ipTB);
            this.Controls.Add(this.ipLBL);
            this.Controls.Add(this.userTB);
            this.Controls.Add(this.userLBL);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.featTB);
            this.Controls.Add(this.featCMB);
            this.Controls.Add(this.featLBL);
            this.Name = "MainWindow";
            this.Text = "License Generator";
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label featLBL;
        private System.Windows.Forms.ComboBox featCMB;
        private System.Windows.Forms.TextBox featTB;
        private System.Windows.Forms.DataGridView dataGridView1;
        private System.Windows.Forms.Label userLBL;
        private System.Windows.Forms.TextBox userTB;
        private System.Windows.Forms.Label ipLBL;
        private System.Windows.Forms.TextBox ipTB;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.Button importBTN;
        private System.Windows.Forms.Button exportBTN;
        private System.Windows.Forms.Button plinkBTN;
        private System.Windows.Forms.Button keyBTN;
        private System.Windows.Forms.Button generateBTN;
    }
}

