 using System;
using System.Linq;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using System.Runtime.InteropServices;

namespace License_Generator
{
    class DataGrid_methods : FileOp, TableOp
    {

        private string filepath;


        /// <summary>
        /// Opens File Manager so the user could choose an excel file
        /// Input: No input
        /// Output: No output
        /// Author: amazingtali
        /// </summary>
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


        /// <summary>
        /// Imports the chosen excel file to the form
        /// Input: A dataGridView to host the excel file in the form
        /// Output: No output
        /// Author: amazingtali
        /// </summary>
        public void Import(DataGridView dataGridView)
        {
            if (System.IO.File.Exists(filepath))
            {
                System.Data.OleDb.OleDbConnection MyConnection;
                System.Data.DataSet DtSet;
                System.Data.OleDb.OleDbDataAdapter MyCommand;
                //Build the connection string
                string connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
                string sheetname = GetSheetName(connectionstring, 0);
                //connect to excel file
                MyConnection = new System.Data.OleDb.OleDbConnection(connectionstring);
                //select the whole table from excel file               
                MyCommand = new System.Data.OleDb.OleDbDataAdapter("select * from [" + sheetname + "]", MyConnection);
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


        /// <summary>
        /// Gets the name of the sheet that it's index is given
        /// Input: an OLEDB connection string, a sheet index
        /// Output: the sheet's name (string)
        /// Author: amazingtali
        /// </summary>
        private string GetSheetName(string connectionstring, int index)
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
                    System.Data.DataTable dtSheet = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);

                    sheetName = dtSheet.Rows[index]["TABLE_NAME"].ToString();


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

        public bool IsHash(string hash)
        {
            string[] s = hash.Split(':');
            if (s.Length == 4)
                return true;
            return false;
        }
        /// <summary>
        /// Reads the data from the dataGrid and returns a linked list that contains the rows in the table
        /// Input: DataGridView
        /// Output: A linked list of rows
        /// Author: amazingtali
        /// </summary>
        public Node<Row> Read(DataGridView dataGrid)
        {
            int num = 1;
            string serial_num;
            string code;
            string ID;
            string feature;
            string prefix = "";
            Node<Row> row_list = new Node<Row>();
            for (int rows = 0; rows < dataGrid.Rows.Count; rows++)
            {
                if (dataGrid.Rows[rows].Cells[2].Value != null)
                {
                    //the information about the device's cpu, hash code, etc.
                    string info = dataGrid.Rows[rows].Cells[2].Value.ToString();

                    if (info.ToString().Contains("Hash") || IsHash(info.ToString()))
                    {
                        //the provider's ID
                        ID = dataGrid.Rows[rows].Cells[1].Value.ToString();

                        //hash code
                        code = info.Substring(info.Length - 12);

                        //serial number
                        serial_num = dataGrid.Rows[rows].Cells[3].Value.ToString();

                        //if serial number is valid
                        if (serial_num.Contains("-"))
                        {
                            //promote
                            num = int.Parse(serial_num.Split('-').Last());
                            prefix = serial_num.Substring(0, 5);
                        }
                        serial_num = prefix + num;

                        //feature or axes number
                        feature = dataGrid.Rows[rows].Cells[4].Value.ToString();

                        //set values for every row in list
                        if (row_list.GetValue() == null)
                        {
                            row_list.SetValue(new Row(ID, code, serial_num, feature, info));
                        }
                        else
                        {
                            AddToList(row_list, new Row(ID, code, serial_num, feature, info));
                        }
                        num++;
                    }
                }
            }
            return row_list;
        }


        /// <summary>
        /// Adds a new row to the linked list of rows
        /// Input: a linked list of rows, new row
        /// Output: no output
        /// Author: amazingtali
        /// </summary>
        private void AddToList(Node<Row> rows, Row row)
        {
            while (rows.GetNext() != null)
            {
                rows = rows.GetNext();
            }
            rows.SetNext(new Node<Row>(row));
        }


        /// <summary>
        /// visualizes data stored in the list, in the DataGridView 
        /// Input: a linked list of rows, a DataGridView
        /// Output: no output
        /// Author: amazingtali
        /// </summary>
        public void Update(Node<Row> row_list, DataGridView dataGrid)
        {
            string license = "";
            string hash = "";
            string serialnumber = "";
            for (int rows = 0; rows < dataGrid.Rows.Count; rows++)
            {
                if (dataGrid.Rows[rows].Cells[StaticVars.infoINDEX].Value != null)
                {
                    string info = dataGrid.Rows[rows].Cells[StaticVars.infoINDEX].Value.ToString();
                    if (info.Contains("Hash"))
                    {
                        license = row_list.GetValue().license;
                        hash = row_list.GetValue().code;
                        serialnumber = row_list.GetValue().serial_number;
                        dataGrid.Rows[rows].Cells[StaticVars.featureINDEX].Value = row_list.GetValue().feature;
                        dataGrid.Rows[rows].Cells[StaticVars.serialnumberINDEX].Value = serialnumber;
                        if (license != "")
                            dataGrid.Rows[rows].Cells[StaticVars.licenseINDEX].Value = license;
                        else
                            dataGrid.Rows[rows].Cells[StaticVars.licenseINDEX].Value = "ERROR";
                        row_list = row_list.GetNext();
                    }
                }
            }
            MessageBox.Show("Table was updated");
        }


        /// <summary>
        /// exports the linked list of rows to an excel file
        /// Input: a linked list of rows, a file path (as a string)
        /// Output: no output
        /// Author: amazingtali
        /// </summary>
        public void Export(Node<Row> row_list, string filepath)
        {
            Excel.Application xlApp = new Microsoft.Office.Interop.Excel.Application();

            if (xlApp == null)
            {
                MessageBox.Show("Excel is not properly installed!!");
                return;
            }


            Excel.Workbook xlWorkBook;
            Excel.Worksheet xlWorkSheet;
            object misValue = System.Reflection.Missing.Value;

            xlWorkBook = xlApp.Workbooks.Add(misValue);
            xlWorkSheet = (Excel.Worksheet)xlWorkBook.Worksheets.get_Item(1);

            xlWorkSheet.Cells[1, 1] = "ID";
            xlWorkSheet.Cells[1, 2] = "Hash Code";
            xlWorkSheet.Cells[1, 3] = "Serial Number";
            xlWorkSheet.Cells[1, 4] = "Feature";
            xlWorkSheet.Cells[1, 5] = "License";
            xlWorkSheet.Cells[1, 6] = "Verified";
            string hash = "";
            string serialnumber = "";
            string license = "";
            int i = 2;
            while (row_list != null)
            {
                hash = row_list.GetValue().code.ToString();
                serialnumber = row_list.GetValue().serial_number.ToString();
                license = row_list.GetValue().license.ToString();
                xlWorkSheet.Cells[i, 1] = row_list.GetValue().ID.ToString();
                xlWorkSheet.Cells[i, 2] = hash;
                xlWorkSheet.Cells[i, 3] = serialnumber;
                xlWorkSheet.Cells[i, 4] = row_list.GetValue().feature.ToString();
                xlWorkSheet.Cells[i, 5] = hash + "/" + serialnumber + "/" + license;
                xlWorkSheet.Cells[i, 6] = row_list.GetValue().verified.ToString();
                i++;
                row_list = row_list.GetNext();
            }


            xlWorkBook.Saved = true;
            xlWorkBook.SaveCopyAs(filepath);
            xlWorkBook.Close(true, misValue, misValue);
            xlApp.Quit();

            Marshal.ReleaseComObject(xlWorkSheet);
            Marshal.ReleaseComObject(xlWorkBook);
            Marshal.ReleaseComObject(xlApp);

            MessageBox.Show("Excel file created , you can find the file " + filepath);
        }
    }
}
