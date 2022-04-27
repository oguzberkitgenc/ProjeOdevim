using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjeOdevim
{
    public partial class FDayComp : Form
    {
        public FDayComp()
        {
            InitializeComponent();
        }

        public void FDayComp_Load(string dashboardhPath)
        {
            try
            {
                dashboardViewer1.LoadDashboard(dashboardhPath);
            }
            catch (Exception)
            {

                MessageBox.Show(" İhtiyacım olan dosyayı bulamadım.. :( \n\n Hata Kodu\n dat_dashboard_chart_comparday ", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
