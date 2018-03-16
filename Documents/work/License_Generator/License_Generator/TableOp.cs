using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace License_Generator
{
    interface TableOp
    {
         void Update(Node<Row> prevRows, Node<Row> newRows);
         Node<Row> Read(DataGridView dataGrid);
    }
}
