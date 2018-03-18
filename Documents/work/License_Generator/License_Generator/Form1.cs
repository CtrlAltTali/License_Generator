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
        Encode en = new Encode_num();
        Encode et = new Encode_text();
        Node<Row> rowlist;
        string featureType;
        string featureInput;
        string code;
        string serialnumber;
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
            featureType = featCMB.Text;
            featureInput = featTB.Text;
            rowlist = datagridmethods.Read(dataGridView1);
            Node<Row> rowspointer = rowlist;
            if (dataGridView1.Rows[0].Cells[6].Value.ToString() == "")
                dataGridView1.Rows[0].Cells[6].Value = "Verified";
            while (rowspointer != null)
            {
                rowspointer.GetValue().feature = featureInput;
                code = rowspointer.GetValue().code;
                serialnumber = rowspointer.GetValue().serial_number;
                switch (featureType)
                {
                    case "Text":
                        rowspointer.GetValue().license = et.Get_License(code, featureInput, serialnumber);
                        rowspointer.GetValue().verified = et.Verify(rowspointer.GetValue().license, code, serialnumber);
                        break;
                    case "Number":
                        rowspointer.GetValue().license = en.Get_License(code, featureInput, serialnumber);
                        rowspointer.GetValue().verified = en.Verify(rowspointer.GetValue().license, code, serialnumber);
                        break;
                }
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
        private void generateBTN_Click(object sender, EventArgs e)
        {
            if (featCMB.Text != "")
            {
                Generate_License();
                Node<Row> rowspointer = rowlist;
                datagridmethods.Update(rowspointer, dataGridView1);
            }

        }

        private void importBTN_Click(object sender, EventArgs e)
        {
            Import_File();
        }

        private void exportBTN_Click(object sender, EventArgs e)
        {
            Export_File();
        }
    }
}
