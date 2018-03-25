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
        string plink_path;
        public MainWindow()
        {
            InitializeComponent();
           
        }


        /// <summary>
        /// gets a license and puts it in the suitable row
        /// Input: No input
        /// Output: No output
        /// Author: amazingtali
        /// </summary>
        public void Generate_License()
        {
            operationType = featCMB.Text;
            operationInput = featTB.Text;
            IP = ipTB.Text;
            user = userTB.Text;
            switch (operationType)
            {
                case "Feature":
                    en = new Encode_text(IP, user,plink_path);
                    break;
                case "Number":
                    en = new Encode_num(IP, user,plink_path);
                    break;
            }
            rowlist = datagridmethods.Read(dataGridView1);
            Node<Row> rowspointer = rowlist;
            if (dataGridView1.Rows[0].Cells[6].Value.ToString() == "")
                dataGridView1.Rows[0].Cells[6].Value = "Verified";
            
            while (rowspointer != null)
            {
                rowspointer.GetValue().feature = operationInput;
                code = rowspointer.GetValue().code;
                serialnumber = rowspointer.GetValue().serial_number;
                rowspointer.GetValue().license = en.Get_License(code, operationInput, serialnumber);
                rowspointer.GetValue().verified = en.Verify(rowspointer.GetValue().license, code, serialnumber);
                progressBar.PerformStep();
                rowspointer = rowspointer.GetNext();
                
            }
            MessageBox.Show("license generated");

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
                if(info != null)
                {
                    if (info.ToString().Contains("Hash"))
                        rowcount++;
                }              
            }
            progressBar.Visible = true;
            progressBar.Minimum = 0;
            progressBar.Maximum = rowcount;
            progressBar.Value = 1;
            progressBar.Step = 1;

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
            sfd.FileName = "export.xls";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                Node<Row> rowspointer = rowlist;
                datagridmethods.Export(rowspointer, Path.GetFullPath(sfd.FileName));
            }
        }

        ////////////////////////////////////////////////////////////////////////

        private void importMI_Click(object sender, EventArgs e)
        {
            Import_File();
        }

        private void exportMI_Click(object sender, EventArgs e)
        {
            Export_File();
        }

        private void generateMI_Click(object sender, EventArgs e)
        {
            if (featCMB.Text != "")
            {
                Generate_License();
                Node<Row> rowspointer = rowlist;
                datagridmethods.Update(rowspointer, dataGridView1);
            }
        }

        private void plinkMI_Click(object sender, EventArgs e)
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
    }
}
