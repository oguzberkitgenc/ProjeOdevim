using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjeOdevim.Formlar
{
    public partial class frmViewer : Form
    {
        public frmViewer()
        {
            InitializeComponent();
        }
        public void frmViewer_Load(string dashboardPath)
        {
            dashboardViewer1.LoadDashboard(dashboardPath);
        }

        private void frmViewer_Load(object sender, EventArgs e)
        {

        }
    }
}
