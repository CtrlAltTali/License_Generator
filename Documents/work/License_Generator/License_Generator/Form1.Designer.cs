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
            this.components = new System.ComponentModel.Container();
            this.featLBL = new System.Windows.Forms.Label();
            this.featCMB = new System.Windows.Forms.ComboBox();
            this.featTB = new System.Windows.Forms.TextBox();
            this.dataGridView1 = new System.Windows.Forms.DataGridView();
            this.mainMenu1 = new System.Windows.Forms.MainMenu(this.components);
            this.fileMI = new System.Windows.Forms.MenuItem();
            this.importMI = new System.Windows.Forms.MenuItem();
            this.exportMI = new System.Windows.Forms.MenuItem();
            this.keyMI = new System.Windows.Forms.MenuItem();
            this.generateMI = new System.Windows.Forms.MenuItem();
            this.userLBL = new System.Windows.Forms.Label();
            this.userTB = new System.Windows.Forms.TextBox();
            this.ipLBL = new System.Windows.Forms.Label();
            this.ipTB = new System.Windows.Forms.TextBox();
            this.plinkMI = new System.Windows.Forms.MenuItem();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView1)).BeginInit();
            this.SuspendLayout();
            // 
            // featLBL
            // 
            this.featLBL.AutoSize = true;
            this.featLBL.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.featLBL.ForeColor = System.Drawing.Color.MidnightBlue;
            this.featLBL.Location = new System.Drawing.Point(818, 56);
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
            this.featCMB.Location = new System.Drawing.Point(893, 56);
            this.featCMB.Name = "featCMB";
            this.featCMB.Size = new System.Drawing.Size(82, 24);
            this.featCMB.TabIndex = 3;
            // 
            // featTB
            // 
            this.featTB.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.featTB.Location = new System.Drawing.Point(981, 56);
            this.featTB.Name = "featTB";
            this.featTB.Size = new System.Drawing.Size(100, 25);
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
            // mainMenu1
            // 
            this.mainMenu1.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.fileMI,
            this.keyMI,
            this.plinkMI,
            this.generateMI});
            // 
            // fileMI
            // 
            this.fileMI.Index = 0;
            this.fileMI.MenuItems.AddRange(new System.Windows.Forms.MenuItem[] {
            this.importMI,
            this.exportMI});
            this.fileMI.Text = "File";
            // 
            // importMI
            // 
            this.importMI.Index = 0;
            this.importMI.Text = "Import";
            this.importMI.Click += new System.EventHandler(this.importMI_Click);
            // 
            // exportMI
            // 
            this.exportMI.Index = 1;
            this.exportMI.Text = "Export";
            this.exportMI.Click += new System.EventHandler(this.exportMI_Click);
            // 
            // keyMI
            // 
            this.keyMI.Index = 1;
            this.keyMI.Text = "Key";
            // 
            // generateMI
            // 
            this.generateMI.Index = 3;
            this.generateMI.Text = "Generate";
            this.generateMI.Click += new System.EventHandler(this.generateMI_Click);
            // 
            // userLBL
            // 
            this.userLBL.AutoSize = true;
            this.userLBL.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userLBL.ForeColor = System.Drawing.Color.MidnightBlue;
            this.userLBL.Location = new System.Drawing.Point(818, 104);
            this.userLBL.Name = "userLBL";
            this.userLBL.Size = new System.Drawing.Size(41, 20);
            this.userLBL.TabIndex = 7;
            this.userLBL.Text = "User:";
            // 
            // userTB
            // 
            this.userTB.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.userTB.Location = new System.Drawing.Point(865, 104);
            this.userTB.Name = "userTB";
            this.userTB.Size = new System.Drawing.Size(100, 25);
            this.userTB.TabIndex = 8;
            // 
            // ipLBL
            // 
            this.ipLBL.AutoSize = true;
            this.ipLBL.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipLBL.ForeColor = System.Drawing.Color.MidnightBlue;
            this.ipLBL.Location = new System.Drawing.Point(818, 148);
            this.ipLBL.Name = "ipLBL";
            this.ipLBL.Size = new System.Drawing.Size(79, 20);
            this.ipLBL.TabIndex = 9;
            this.ipLBL.Text = "IP Address:";
            // 
            // ipTB
            // 
            this.ipTB.Font = new System.Drawing.Font("Arial Narrow", 11.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ipTB.Location = new System.Drawing.Point(903, 148);
            this.ipTB.Name = "ipTB";
            this.ipTB.Size = new System.Drawing.Size(151, 25);
            this.ipTB.TabIndex = 10;
            // 
            // plinkMI
            // 
            this.plinkMI.Index = 2;
            this.plinkMI.Text = "Open PLINK";
            this.plinkMI.Click += new System.EventHandler(this.plinkMI_Click);
            // 
            // progressBar
            // 
            this.progressBar.ForeColor = System.Drawing.Color.RoyalBlue;
            this.progressBar.Location = new System.Drawing.Point(837, 12);
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(244, 23);
            this.progressBar.TabIndex = 11;
            // 
            // MainWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1098, 569);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.ipTB);
            this.Controls.Add(this.ipLBL);
            this.Controls.Add(this.userTB);
            this.Controls.Add(this.userLBL);
            this.Controls.Add(this.dataGridView1);
            this.Controls.Add(this.featTB);
            this.Controls.Add(this.featCMB);
            this.Controls.Add(this.featLBL);
            this.Menu = this.mainMenu1;
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
        private System.Windows.Forms.MainMenu mainMenu1;
        private System.Windows.Forms.MenuItem fileMI;
        private System.Windows.Forms.MenuItem importMI;
        private System.Windows.Forms.MenuItem exportMI;
        private System.Windows.Forms.MenuItem keyMI;
        private System.Windows.Forms.MenuItem generateMI;
        private System.Windows.Forms.Label userLBL;
        private System.Windows.Forms.TextBox userTB;
        private System.Windows.Forms.Label ipLBL;
        private System.Windows.Forms.TextBox ipTB;
        private System.Windows.Forms.MenuItem plinkMI;
        private System.Windows.Forms.ProgressBar progressBar;
    }
}

