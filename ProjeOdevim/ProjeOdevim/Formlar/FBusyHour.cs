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
    public partial class FBusyHour : Form
    {
        public FBusyHour()
        {
            InitializeComponent();
        }

        public void FBusyHour_Load(string dashboardPath)
        {
            try
            {
                dashboardViewer1.LoadDashboard(dashboardPath);
            }
            catch (Exception)
            {

                MessageBox.Show(" İhtiyacım olan dosyayı bulamadım.. :( \n\n Hata Kodu\n busy_dashboard_chart_hour ", "HATA",MessageBoxButtons.OK,MessageBoxIcon.Warning);
            }
            
        }
    }
}
