using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace License_Generator
{
    interface FileOp
    {
        void Import(DataGridView dataGridView);
        void Export(Node<Row> rows);
        void OpenFileManager();
    }
}
