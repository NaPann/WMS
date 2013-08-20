using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace WMS
{
    public partial class frmCalendar : Form
    {
        public frmCalendar()
        {
            InitializeComponent();
        }

        private void frmCalendar_Load(object sender, EventArgs e)
        {
            DataTable dt = new DataTable();
            dt.Columns.Add("id", typeof(int));
            dt.Columns.Add("time", typeof(DateTime));

            for (int j = 0; j < 10; j++)
            {
                dt.Rows.Add(j, DateTime.Now.AddDays(10 * j));
            }

            //this.genericDataGridView1.DataColumns = "id,time";
            this.dataGridView1.DataSource = dt;

            //this.genericDataGridView1.AddCalendar("time", "TIME");
        }
    }
}
