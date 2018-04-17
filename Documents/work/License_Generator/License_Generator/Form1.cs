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
        string keyName;
        string keyPath = "";
        string info;

        int idealnumberofcols = 6;
        public MainWindow()
        {
            InitializeComponent();
            ipTB.Text = UserSettings.Default.IpAddress;
            userTB.Text = UserSettings.Default.User;
            keyBTN.Enabled = false;
            userTB.Enabled = false;
            costumerCB.Enabled = false;
            ipTB.Enabled = false;
            generateBTN.Enabled = false;
            StaticVars.costumers.Add("Servotronix", "S");
            StaticVars.costumers.Add("HNC", "S");
            StaticVars.costumers.Add("Greatoo", "G");

        }


        /// <summary>
        /// gets a license and puts it in the suitable row
        /// Input: No input
        /// Output: No output
        /// Author: amazingtali
        /// </summary>
        public void Generate_License()
        {
            operationInput = featTB.Text;
            IP = ipTB.Text;
            user = userTB.Text;
            switch (operationType)
            {
                case "Feature":
                    en = new Encode_text(IP, user, keyName);
                    break;
                case "Number":
                    en = new Encode_num(IP, user, keyName);
                    break;
                case "web":
                    en = new Encode_web(IP);
                    break;
            }
            rowlist = datagridmethods.Read(dataGridView1);
            Node<Row> rowspointer = rowlist;
            en.CheckIfReachable(IP);
            if (StaticVars.serverException == "")
            {
                while (rowspointer != null)
                {
                    rowspointer.GetValue().feature = operationInput;
                    code = rowspointer.GetValue().code;
                    serialnumber = rowspointer.GetValue().serial_number;
                    info = rowspointer.GetValue().info;
                    if(operationType == "web")
                        rowspointer.GetValue().license = en.Get_License(info, operationInput, costumerCB.Text);
                    else
                        rowspointer.GetValue().license = en.Get_License(code, operationInput, serialnumber);
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
            if (dataGridView1.Rows.Count > 0)
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
            bool keyChosen = true, featureWritten = true,
                ipIsLegal = true, userWritten = true;
            IPAddress ip;
            if (keyPath == "" && operationType != "web")
            {
                keyChosen = false;
                StaticVars.guiException = "Please choose a key.";
            }
            else if (featCMB.Text == "" || featTB.Text == "")
            {
                featureWritten = false;
                StaticVars.guiException = "Please write a feature or a number";
            }
            //else if (!IPAddress.TryParse(ipTB.Text, out ip) || !CheckURLValid(ipTB.Text))
            //{
            //    ipIsLegal = false;
            //    StaticVars.guiException = "Please write a legal address";
            //}
            else if (userTB.Text == "")
            {
                userWritten = false;
                StaticVars.guiException = "Please write a user-name";
            }
            return keyChosen && featureWritten && ipIsLegal && userWritten;
        }
        //public static bool CheckURLValid( string source)
        //{
        //    Uri uriResult;
        //    return Uri.TryCreate(source, UriKind.Absolute, out uriResult) && uriResult.Scheme == Uri.UriSchemeHttp;
        //}
        public void NormalizeTable(int startindex, int quantity)
        {
            while (quantity > 0)
            {
                string name = "F" + startindex;
                if (dataGridView1.Columns.Contains(name))
                    dataGridView1.Columns.Remove(name);
                DataGridViewColumn column = new DataGridViewTextBoxColumn();
                column.DataPropertyName = name;
                column.Name = name;
                dataGridView1.Columns.Add(column);
                quantity -= 1;
                startindex += 1;
            }
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



        private void generateBTN_Click(object sender, EventArgs e)
        {
            UserSettings.Default.IpAddress = ipTB.Text;
            UserSettings.Default.User = userTB.Text;
            if (dataGridView1.Columns.Count < idealnumberofcols)
            {
                int startindex = dataGridView1.Columns.Count;
                int quantity = idealnumberofcols - startindex + 1;
                NormalizeTable(startindex, quantity);
                for (int i = 0; i < dataGridView1.Rows.Count - 1; i++)
                {
                    string info = dataGridView1.Rows[i].Cells[StaticVars.infoINDEX].Value.ToString();
                    if (info.Contains("Hash") && info != null)
                    {
                        dataGridView1.Rows[i].Cells[StaticVars.featureINDEX].Value = featTB.Text;
                    }
                }
            }
            if (CanProceed())
            {
                Generate_License();
                Node<Row> rowspointer = rowlist;
                if (StaticVars.serverException == "")
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

        private void plinkRBT_CheckedChanged(object sender, EventArgs e)
        {
            keyBTN.Enabled = true;
            userTB.Enabled = true;
            costumerCB.Enabled = false;
            ipTB.Enabled = true;
            generateBTN.Enabled = true;
            operationType = featCMB.Text;
        }

        private void webserRBT_CheckedChanged(object sender, EventArgs e)
        {
            operationType = "web";
            keyBTN.Enabled = false;
            userTB.Enabled = false;
            ipTB.Enabled = true;
            generateBTN.Enabled = true;
            costumerCB.Enabled = true;
        }
    }
}
