using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

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
        public void Generate_License()
        {
            featureType = featCMB.Text;
            featureInput = featTB.Text;
            rowlist = datagridmethods.Read(dataGridView1);
            Node<Row> rowspointer = rowlist;
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
        public void Import_File()
        {
            datagridmethods.OpenFileManager();
            datagridmethods.Import(dataGridView1);
        }
        public void Export_File()
        {

        }
        private void generateBTN_Click(object sender, EventArgs e)
        {
            if (featCMB.Text != "")
            {
                Generate_License();
                Node<Row> rowspointer = rowlist;
                datagridmethods.Update(rowlist, dataGridView1);
            }

        }

        private void importBTN_Click(object sender, EventArgs e)
        {
            Import_File();
        }
    }
}
