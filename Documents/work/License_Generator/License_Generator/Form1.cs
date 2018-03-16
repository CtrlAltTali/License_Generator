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
        Node<Row> rows;
        Row first;
        public MainWindow()
        {
            InitializeComponent();
            
        }
        public string Generate_License()
        {
            string featureType = featCMB.Text;
            string featureInput = featTB.Text;
            //switch (featureType)
            //{
            //    case "Number":
            //        en.Get_License(1, featureInput, 234);
            //        break;
            //    case "Text":
            //        et.Get_License(1, featureInput, 234);
            //        break;
            //}
            //return featureType +": "+featureInput;
            return datagridmethods.Read(dataGridView1).ToString();
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
                MessageBox.Show(Generate_License());
            }

        }

        private void importBTN_Click(object sender, EventArgs e)
        {
            Import_File();
        }
    }
}
