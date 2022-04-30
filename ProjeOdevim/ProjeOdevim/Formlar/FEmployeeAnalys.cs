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
namespace ProjeOdevim.Formlar
{
    public partial class FEmployeeAnalys : Form
    {
        public FEmployeeAnalys()
        {
            InitializeComponent();
        }
        BaglantiSinif bgl = new BaglantiSinif();
        void ChartDoldur()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT ILCE,COUNT(ILCE) AS 'SAYI' FROM TBLPERSONEL GROUP BY ILCE", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            connection.Close();
        }
        void GridDoldur()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT COUNT(ILCE) AS 'SAYI',ILCE AS 'İLÇE' FROM TBLPERSONEL GROUP BY ILCE ", connection);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
            gridView1.Columns[0].Width = 5;
        }
        void CinsiyetGetir()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlCommand komut2 = new SqlCommand("SELECT CINSIYETAD,COUNT(CINSIYETAD) FROM TBLPERSONEL INNER JOIN TBLCINSIYET ON TBLPERSONEL.CINSIYET=TBLCINSIYET.ID GROUP BY CINSIYETAD ORDER BY CINSIYETAD ASC", connection);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Cisim"].Points.AddPoint(Convert.ToString(dr2[0].ToString()), int.Parse(dr2[1].ToString()));
            }
            connection.Close();
        }
        void CiroGetir()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlCommand komut3 = new SqlCommand("SELECT  TOP 20 AD,SUM(TOPLAMFIYAT) AS 'TOPLAM' FROM TBLSATIS  INNER JOIN TBLPERSONEL ON TBLSATIS.PERSONEL=TBLPERSONEL.ID GROUP BY AD ORDER BY TOPLAM DESC", connection);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                chartControl3.Series["Nekadar"].Points.AddPoint(Convert.ToString(dr3[0]).ToString(), double.Parse(dr3[1].ToString()));
            }
            connection.Close();
        }
        private void FEmployeeAnalys_Load(object sender, EventArgs e)
        {
            ChartDoldur();
            GridDoldur();
            CinsiyetGetir();
            CiroGetir();
        }
    }
}
