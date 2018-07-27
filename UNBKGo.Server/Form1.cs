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
            dgv.AutoGenerateColumns = false;
            
            
        }

        private void dgv_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0 && dgv.Columns[e.ColumnIndex] is DataGridViewButtonColumn)
            {
                //TODO - Button Clicked - Execute Code Here
            }
        }

        private void cmdStartServer_Click(object sender, EventArgs e)
        {
            
        }
    }
}
