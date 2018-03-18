﻿using System;
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
                string connectionstring = String.Format(@"Provider=Microsoft.Jet.OLEDB.4.0;Data Source={0};Extended Properties=""Excel 8.0;HDR=YES;IMEX=1;""", filepath);
                if (filepath.EndsWith(".xlsx"))
                {
                    connectionstring = @"Provider=Microsoft.ACE.OLEDB.12.0;Data Source=" + filepath + ";Extended Properties=\"Excel 12.0;HDR=Yes;IMEX=1\"";
                }
                string sheetname = GetSheetName(connectionstring,0);
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
                    DataTable dtSheet = conn.GetOleDbSchemaTable(System.Data.OleDb.OleDbSchemaGuid.Tables, null);

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
        /// Creates a serial number in a format that "Encode" function could read
        /// Input: a number
        /// Output: a formatted serial number (as a string)
        /// Author: amazingtali
        /// </summary>
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
        /// <summary>
        /// visualizes data stored in the list, in the DataGridView 
        /// Input: a linked list of rows, a DataGridView
        /// Output: no output
        /// Author: amazingtali
        /// </summary>
        public void Update(Node<Row> row_list, DataGridView dataGrid)
        {
            for (int rows = 0; rows < dataGrid.Rows.Count; rows++)
            {
                if (dataGrid.Rows[rows].Cells[StaticVars.infoINDEX].Value != null)
                {
                    string info = dataGrid.Rows[rows].Cells[StaticVars.infoINDEX].Value.ToString();
                    if (info.Contains("Hash"))
                    {
                        dataGrid.Rows[rows].Cells[StaticVars.featureINDEX].Value = row_list.GetValue().feature;
                        dataGrid.Rows[rows].Cells[StaticVars.serialnumberINDEX].Value = row_list.GetValue().serial_number;
                        dataGrid.Rows[rows].Cells[StaticVars.licenseINDEX].Value = row_list.GetValue().license;
                        dataGrid.Rows[rows].Cells[StaticVars.verifiedINDEX].Value = row_list.GetValue().verified;
                        row_list = row_list.GetNext();
                    }
                }
            }
            MessageBox.Show("updated");
        }
    }
}
