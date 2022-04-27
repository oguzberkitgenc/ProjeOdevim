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
    public partial class FDetay : Form
    {
        public FDetay()
        {
            InitializeComponent();
        }
        BaglantiSinif bgl = new BaglantiSinif();
        public string idal="";
        public string urun="";
        void Satis()
        {

        }
        private void FDetay_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            if (idal!="")
            {
                connection.Open();
                SqlCommand komut = new SqlCommand("SELECT ISLEMNO,BARKODNO,TARIH,URUNADI,KATEGORIADI,MARKAADI,TBLSATIS.ALISFIYAT," +
                    "TBLSATIS.SATISFIYAT,TOPLAMFIYAT,INDIRIMORANI,TBLPERSONEL.AD,TBLMUSTERI.AD FROM TBLSATIS " +
                    "INNER JOIN TBLPERSONEL ON TBLSATIS.PERSONEL=TBLPERSONEL.ID INNER JOIN TBLMUSTERI " +
                    "ON TBLSATIS.MUSTERIID=TBLMUSTERI.ID INNER JOIN TBLURUN ON TBLSATIS.URUNID=TBLURUN.ID " +
                    "WHERE ISLEMNO=@P1", connection);
                komut.Parameters.AddWithValue("@P1", idal.ToString());
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
                connection.Close();
            }
            else if (urun != "")
            {
                connection.Open();
                SqlCommand komut = new SqlCommand("SELECT TBLURUN.ID,BARKOD,KATEGORIADI,MARKAADI,URUNADI,ALISFIYAT,SATISFIYAT,STOK,ACIKLAMA " +
                    "FROM TBLURUN INNER JOIN TBLKATEGORI ON TBLURUN.KATEGORIID=TBLKATEGORI.ID INNER JOIN TBLMARKA ON " +
                    "TBLURUN.MARKAID=TBLMARKA.ID WHERE TBLURUN.ID=@P1", connection);
                komut.Parameters.AddWithValue("@P1", urun.ToString());
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
                gridView5.Columns[0].Visible = false;
                gridView5.Columns[8].Width = 150;
                connection.Close();
            }
            
        }
    }
}

