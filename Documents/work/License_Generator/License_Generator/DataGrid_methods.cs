using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace License_Generator
{
    class DataGrid_methods: FileOp,TableOp
    {
        
        private string filepath;
        public void OpenFileManager()
        {
            // Displays an OpenFileDialog so the user can select a Cursor.  
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Excel Files|*.xlsx;*.xls;";
            openFileDialog.Title = "Select an Excel File";

            // Show the Dialog.  
            // If the user clicked OK in the dialog and  
            // a .CUR file was selected, open it.  
            if (openFileDialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                // Assign the cursor in the Stream to the Form's Cursor property.  
                filepath = openFileDialog.FileName;
                MessageBox.Show(filepath);
                 
            }
        }
        public void Import(DataGridView dataGridView)
        {
            if (System.IO.File.Exists(filepath))
            {
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.DataSet DtSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                //Build the connection string
                string connectionstring = String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", filepath);
                if (filepath.EndsWith(".xlsx"))
                {
                    connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
                }
                string sheetname = GetSheetName(connectionstring);
                //connect to excel file
                MyConnection = new System.Data.OleDb.OleDbConnection(connectionstring); 
                //select the whole table from excel file               
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from ["+sheetname+"]", MyConnection);
                MyCommand.TableMappings.Add("Table", "Net-informations.com");
                DtSet = new System.Data.DataSet();
                try
                {
                    //put the excel table in the data grid object
                    MyCommand.Fill(DtSet);
                    dataGridView.DataSource = DtSet.Tables[0];
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }

                MyConnection.Close();
            }
        }
        private string GetSheetName(string connectionstring)
        {
            string sheetName = "";
            using (System.Data.OleDb.OleDbConnection conn = new System.Data.OleDb.OleDbConnection(connectionstring))
            {
                try
                {
                    conn.Open();
                    System.Data.OleDb.OleDbCommand cmd = new System.Data.OleDb.OleDbCommand();
                    cmd.Connection = conn;

                    // Get 1st sheet name in Excel File
                    DataTable dtSheet = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);

                    sheetName = dtSheet.Rows[0]["TABLE_NAME"].ToString();


                    cmd = null;
                    conn.Close();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.ToString());
                }
            }
            return sheetName;
        }
        public Node<Row> Read(DataGridView dataGrid)
        {
            int num = 1;
            string serial_num;
            string code;
            string feature;
            Node<Row> row_list = new Node<Row>();
            for (int rows = 0; rows < dataGrid.Rows.Count; rows++)
            {
                if (dataGrid.Rows[rows].Cells[2].Value != null)
                {
                    string info = dataGrid.Rows[rows].Cells[2].Value.ToString();
                    if (info.Contains("Hash"))
                    {
                        code = info.Substring(info.Length - 12);
                        serial_num = GetSerialNum(num);
                        feature = dataGrid.Rows[rows].Cells[4].Value.ToString();
                        if(row_list.GetValue() == null)
                        {
                            row_list.SetValue(new Row(code, serial_num, feature));
                        }
                        else
                        {
                            AddToList(row_list, new Row(code, serial_num, feature));
                        }                        
                        num++;
                    }
                }
           }
            return row_list;
        }
        private void AddToList(Node<Row> rows, Row row)
        {
            while (rows.GetNext() != null)
            {
                rows = rows.GetNext();
            }
            rows.SetNext(new Node<Row>(row));
        }
        private string GetSerialNum(int n)
        {
            if (n / 10 == 0)
                return "00" + n.ToString();
            if (n / 100 == 0)
                return "0" + n.ToString();
            else
                return n.ToString();
        }
        public void Export(Node<Row> rows)
        {
            MessageBox.Show(rows.ToString());
        }
        public void Update(Node<Row> prevRows, Node<Row> newRows)
        {
            MessageBox.Show("updated");
        }
    }
}
