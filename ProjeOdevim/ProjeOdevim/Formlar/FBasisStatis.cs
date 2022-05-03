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
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=TicariOtomasyon;Integrated Security=True");



        void GridDoldur()
        {
            ///// Marka Grid Doldur
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select MARKAADI,SUM(STOK) AS 'STOK SAYISI' FROM TBLURUN  INNER JOIN TBLMARKA ON TBLURUN.MARKAID = TBLMARKA.ID WHERE STOK>=1 GROUP BY MARKAADI ORDER BY MARKAADI ASC", connection);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            gridControl1.DataSource = dataTable;
            connection.Close();
        }
        void MarkaChat()
        {
            ///// Marka Chart Doldur
            connection.Open();
            SqlCommand komut1 = new SqlCommand("Select MARKAADI,SUM(STOK) AS 'STOK SAYISI' FROM TBLURUN  INNER JOIN TBLMARKA ON TBLURUN.MARKAID = TBLMARKA.ID WHERE STOK>=1 GROUP BY MARKAADI ORDER BY MARKAADI ASC", connection);
            SqlDataReader dr = komut1.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Markalar"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            connection.Close();
        }
        void AlisFiyat()
        {
            //// Alış Fiyatı Getir
            connection.Open();
            SqlCommand komut2 = new SqlCommand("Select Sum(ALISFIYAT*STOK) From TBLURUN WHERE STOK>=1", connection);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                LAlisFiyat.Text = dr2[0].ToString();
            }
            connection.Close();
        }
        void SatisFiyat()
        {
            //// Satış Fiyatı Getir
            connection.Open();
            SqlCommand komut3 = new SqlCommand("Select Sum(SATISFIYAT*STOK) From TBLURUN WHERE STOK>=1 ", connection);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                LSatisFiyat.Text = dr3[0].ToString();
            }
            connection.Close();
        }
        void Hesapla()
        {
            double alis = double.Parse(LAlisFiyat.Text);
            double satis = double.Parse(LSatisFiyat.Text);
            double kar = satis - alis;
            double hesapla = kar * 100 / satis;
            LHesap.Text = Convert.ToString("Satış ve Alış Fiyatına Oranlı Net Kar: %" + hesapla);

            chartControl2.Series["AlSat"].Points.AddPoint("Zarar", double.Parse(LSatisFiyat.Text));
            chartControl2.Series["AlSat"].Points.AddPoint("Kar", double.Parse(LAlisFiyat.Text));

            LAlisFiyat.Text = Convert.ToString(alis + ",00 ₺");
            LSatisFiyat.Text = Convert.ToString(satis + ",00 ₺");
        }
        private void FBasisStatis_Load(object sender, EventArgs e)
        {
            GridDoldur();
            MarkaChat();
            AlisFiyat();
            SatisFiyat();
            Hesapla();
        }
    }
}
