using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Cine_App_2.Formularios
{
    public partial class FrmReporteFunciones : Form
    {
        public FrmReporteFunciones()
        {
            InitializeComponent();
        }

        private void FrmReporteFunciones_Load(object sender, EventArgs e)
        {
            this.dataTable1TableAdapter.Fill(this.dataSet1.DataTable1);
            this.reportViewer1.RefreshReport();
        }

    }
}

