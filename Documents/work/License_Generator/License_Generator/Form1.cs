using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;
using System.Net;

namespace License_Generator
{
    public partial class MainWindow : Form
    {
        DataGrid_methods datagridmethods = new DataGrid_methods();
        Encode en;
        Node<Row> rowlist;
        string operationType;
        string operationInput;
        string IP;
        string user;
        string code;
        string serialnumber;
        string plink_path = "";
        string keyName;
        string keyPath = "";
        public MainWindow()
        {
            InitializeComponent();
            ipTB.Text = UserSettings.Default.IpAddress;
            userTB.Text = UserSettings.Default.User;
        }


        /// <summary>
        /// gets a license and puts it in the suitable row
        /// Input: No input
        /// Output: No output
        /// Author: amazingtali
        /// </summary>
        public void Generate_License()
        {
            if (FileLegal())
            {
                operationType = featCMB.Text;
                operationInput = featTB.Text;
                IP = ipTB.Text;
                user = userTB.Text;
                switch (operationType)
                {
                    case "Feature":
                        en = new Encode_text(IP, user, plink_path, keyName);
                        break;
                    case "Number":
                        en = new Encode_num(IP, user, plink_path, keyName);
                        break;
                }
                rowlist = datagridmethods.Read(dataGridView1);
                Node<Row> rowspointer = rowlist;

                en.CheckIfReachable(plink_path, IP, user);
                if (StaticVars.serverException == "")
                {
                    while (rowspointer != null)
                    {
                        rowspointer.GetValue().feature = operationInput;
                        code = rowspointer.GetValue().code;
                        serialnumber = rowspointer.GetValue().serial_number;
                        rowspointer.GetValue().license = en.Get_License(code, operationInput, serialnumber);
                        rowspointer.GetValue().verified = en.Verify();
                        progressBar.PerformStep();
                        rowspointer = rowspointer.GetNext();

                    }
                }
                else
                {
                    MessageBox.Show(StaticVars.serverException);
                }
                progressBar.Value = 0;
            }
            else
            {
                MessageBox.Show("File is illegal");
            }

        }

        public bool FileLegal()
        {
            bool a = false;
            bool b = false;
            bool c = false;
            bool d = false;
            bool e = false;
            if ( dataGridView1.ColumnCount >= 6)
            {
                a = !(dataGridView1.Columns[0].HeaderText == "ID");
                b = !(dataGridView1.Columns[1].HeaderText == "Hash Code");
                c = !(dataGridView1.Columns[2].HeaderText == "Serial Number");
                d = !(dataGridView1.Columns[3].HeaderText == "Feature");
                e = !(dataGridView1.Columns[4].HeaderText == "License");
            }
            return a && b && c && d && e;
        }
        
        /// <summary>
        /// Opens File Manager and imports an excel file to the DataGridView
        /// Input: No input
        /// Output: No output
        /// Author: amazingtali
        /// </summary>
        public void Import_File()
        {
            datagridmethods.OpenFileManager();
            datagridmethods.Import(dataGridView1);
            int rowcount = 0;

            for (int i = 0; i < dataGridView1.RowCount; i++)
            {
                var info = dataGridView1.Rows[i].Cells[2].Value;
                if (info != null)
                {
                    if (info.ToString().Contains("Hash") || datagridmethods.IsHash(info.ToString()))
                        rowcount++;
                }
            }
            if(dataGridView1.Rows.Count > 0)
            {
                progressBar.Visible = true;
                progressBar.Minimum = 0;
                progressBar.Maximum = rowcount;
                progressBar.Value = 0;
                progressBar.Step = 1;

            }

        }


        /// <summary>
        /// exports the data to a new excel file
        /// Input: No input
        /// Output: No output
        /// Author: amazingtali
        /// </summary>
        public void Export_File()
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Filter = "Excel Documents (*.xls)|*.xls";
            sfd.FileName = "export.xlsx";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Node<Row> rowspointer = rowlist;
                datagridmethods.Export(rowspointer, Path.GetFullPath(sfd.FileName));
            }
        }
        /// <summary>
        /// tells if the data written in the form is legal
        /// Input: No input
        /// Output: a boolean value that tells if the program can start generating the license
        /// Author: amazingtali
        /// </summary>
        public bool CanProceed()
        {
            bool keyChosen = true, plinkChosen = true,
                inTheSameDir = true, featureWritten = true,
                ipIsLegal = true, userWritten = true;
            IPAddress ip;
            if (keyPath == "")
            {
                keyChosen = false;
                StaticVars.guiException = "Please choose a key.";
            }
            else if (plink_path == "")
            {
                plinkChosen = false;
                StaticVars.guiException = "Please open PLINK.exe.";
            }
            else if (plink_path != keyPath)
            {
                inTheSameDir = false;
                StaticVars.guiException = "PLINK.exe and your key should be in the same directory.";
            }
            else if (featCMB.Text == "" || featTB.Text == "")
            {
                featureWritten = false;
                StaticVars.guiException = "Please write a feature or a number";
            }
            else if(!IPAddress.TryParse(ipTB.Text, out ip))
            {
                ipIsLegal = false;
                StaticVars.guiException = "Please write legal IP Address";
            }
            else if(userTB.Text == "")
            {
                userWritten = false;
                StaticVars.guiException = "Please write a user-name";
            }
            return keyChosen && plinkChosen && inTheSameDir && featureWritten && ipIsLegal && userWritten;
        }
        ////////////////////////////////////////////////////////////////////////

        private void importBTN_Click(object sender, EventArgs e)
        {
            Import_File();
        }

        private void exportBTN_Click(object sender, EventArgs e)
        {
            Export_File();
        }

        private void plinkBTN_Click(object sender, EventArgs e)
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Exe Files|*.exe;";
            openFileDialog.Title = "Select an exe File";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .exe file was selected, open it.  
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.  
                plink_path = openFileDialog.FileName;
                int index = plink_path.LastIndexOf(@"\");
                if (index > 0)
                {
                    plink_path = plink_path.Substring(0, index);
                }

            }
        }

        private void generateBTN_Click(object sender, EventArgs e)
        {
            UserSettings.Default.IpAddress = ipTB.Text;
            UserSettings.Default.User = userTB.Text;
            if (CanProceed())
            {
                Generate_License();
                Node<Row> rowspointer = rowlist;
                if (StaticVars.serverException == "" && FileLegal())
                {
                    datagridmethods.Update(rowspointer, dataGridView1);
                }
            }
            else
            {
                MessageBox.Show(StaticVars.guiException);
            }
        }

        private void keyBTN_Click(object sender, EventArgs e)
        {

            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Exe Files|*.ppk;";
            openFileDialog.Title = "Select a private key";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .exe file was selected, open it.  
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.  
                keyPath = openFileDialog.FileName;
                int index = keyPath.LastIndexOf(@"\");
                if (index > 0)
                {
                    keyName = keyPath.Split(char.Parse(@"\")).Last();
                    keyPath = keyPath.Substring(0, index);
                }

            }
            keyLBL.Text = keyName;
        }
    }
}
