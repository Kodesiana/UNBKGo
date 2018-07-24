using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UNBKGo.Server
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
            dgv.Rows.Add();
            var row = dgv.Rows[0];
            row.Cells[0].Value = "FAHMI-PC";
            row.Cells[1].Value = "192.168.1.101";
            row.Cells[2].Value = "FF-FF-FF-FF-FF-FF";
            row.Cells[3].Value = "OK";
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                //TODO - Button Clicked - Execute Code Here
            }
        }
    }
}
