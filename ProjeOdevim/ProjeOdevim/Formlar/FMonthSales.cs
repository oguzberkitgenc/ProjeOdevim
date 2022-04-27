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
    public partial class FMonthSales : Form
    {
        public FMonthSales()
        {
            InitializeComponent();
        }

        public void FMonthSales_Load(string dashboardPath)
        {
            try
            {
                dashboardViewer1.LoadDashboard(dashboardPath);
            }
            catch (Exception)
            {

                MessageBox.Show(" İhtiyacım olan dosyayı bulamadım.. :( \n\n Hata Kodu\n dat_dashboard_chartmonth ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
