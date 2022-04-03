using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevExpress.Charts;
namespace ProjeOdevim.Formlar
{
    public partial class FBasisStatis : Form
    {
        public FBasisStatis()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");

        void BrandList()
        {
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select MARKAADI,SUM(STOK) AS 'STOK SAYISI' FROM TBLURUN  INNER JOIN TBLMARKA ON TBLURUN.MARKAID = TBLMARKA.ID WHERE STOK>=1 GROUP BY MARKAADI ORDER BY MARKAADI ASC", connection);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            gridControl1.DataSource = dataTable;
            connection.Close();
        }
        private void FBasisStatis_Load(object sender, EventArgs e)
        {
            BrandList();

           connection.Open();
            SqlCommand sqlCommand = new SqlCommand("Select MARKAADI,SUM(STOK) AS 'STOK SAYISI' FROM TBLURUN  INNER JOIN TBLMARKA ON TBLURUN.MARKAID = TBLMARKA.ID WHERE STOK>=1 GROUP BY MARKAADI", connection);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                //   chartControl1.Series["Markar"].Points.Add(new DevExpress.XtraCharts.SeriesPoint(dr[0], dr[1]));
                chartControl1.Series["Markar"].Points.AddPoint(Convert.ToString(dr[0]),int.Parse(dr[1].ToString()));
            }
            connection.Close();
        }
    }
}
