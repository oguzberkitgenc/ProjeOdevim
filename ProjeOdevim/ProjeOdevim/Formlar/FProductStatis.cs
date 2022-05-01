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
    public partial class FProductStatis : Form
    {
        public FProductStatis()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=DbProjem;Integrated Security=True");

        void UrunSayisi()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select Count(*) From TBLURUN",connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LUrunSayisi.Text = dr[0].ToString();
            }
            connection.Close();
        }
        void KategoriSayisi()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select Count(*) From TBLKATEGORI",connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LKategoriSayisi.Text=dr[0].ToString();
            }
            connection.Close();
        }
        void StokSayisi()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select Sum(STOK) From TBLURUN",connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LStokSayisi.Text = dr[0].ToString();
            }
            connection.Close();
        }
        void KritikSeviye()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select Count(*) From TBLURUN where STOK<=5",connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LKritikSeviye.Text=dr[0].ToString();
            }
            connection.Close();
        }
        void BitikUrun()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select Count(*) From TBLURUN where STOK=0", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LBitikUrun.Text = dr[0].ToString();
            }
            connection.Close();
        }
        
        void EnStokluUrun()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select Top 1 URUNADI,STOK From TBLURUN order by STOK desc",connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LEnStokluUrun.Text=dr[0].ToString();
            }
            connection.Close();
        }
        void EnAzStokluUrun()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select Top 1 URUNADI,STOK From TBLURUN order by STOK asc", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LAzStokluUrun.Text = dr[0].ToString();
            }
            connection.Close();
        }
        void PahaliUrun()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select Top 1 URUNADI,SATISFIYAT From TBLURUN order by STOK asc", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LPahaliUrun.Text = dr[0].ToString();
            }
            connection.Close();
        }
        void UcuzUrun()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select Top 1 URUNADI,SATISFIYAT From TBLURUN order by STOK desc", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LUcuzUrun.Text = dr[0].ToString();
            }
            connection.Close();
        }
        void MarkaSayısı()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select Count(*) From TBLMARKA",connection);
            SqlDataReader dr=komut.ExecuteReader();
            while (dr.Read())
            {
                LMarkaSayisi.Text=dr[0].ToString();
            }
            connection.Close();
        }
        void FazlaMarka()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select TOP 1 MARKAADI,COUNT(*)  AS 'SIRALA 'FROM TBLURUN  INNER JOIN TBLMARKA ON TBLURUN.MARKAID = TBLMARKA.ID GROUP BY MARKAADI ORDER BY [SIRALA] DESC",connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LFazlaMarka.Text = dr[0].ToString();
            }
            connection.Close();
        }
        void FazlaKategori()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select TOP 1 KATEGORIADI,COUNT(*)  AS 'SIRALA 'FROM TBLURUN INNER JOIN TBLKATEGORI ON TBLURUN.KATEGORIID = TBLKATEGORI.ID GROUP BY KATEGORIADI ORDER BY [SIRALA] DESC", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LFazlaKateogori.Text = dr[0].ToString();
            }
            connection.Close();
        }
        void AzKategori()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select TOP 1 KATEGORIADI,COUNT(*)  AS 'SIRALA 'FROM TBLURUN INNER JOIN TBLKATEGORI ON TBLURUN.KATEGORIID = TBLKATEGORI.ID GROUP BY KATEGORIADI ORDER BY [SIRALA] ASC", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LAzKategori.Text = dr[0].ToString();
            }
            connection.Close();
        }
      
        
        void Musteriler()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select Count(*) From TBLMUSTERI",connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LMusteriSayisi.Text = dr[0].ToString();
            }
            connection.Close();
        }
        void Personeller()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select Count(*) From TBLPERSONEL", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LToplamPersonel.Text = dr[0].ToString();
            }
            connection.Close();
        }
        void PersonelPuan()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select TOP 1 AD,PUAN From TBLPERSONEL ORDER BY PUAN DESC",connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LPersonelPuan.Text=dr[0].ToString();
            }
            connection.Close();
        }
        void ErkekPersonel()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select CINSIYET,COUNT(*) From TBLPERSONEL GROUP BY CINSIYET ORDER BY CINSIYET DESC", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LErkekPersonel.Text = dr[1].ToString();
            }
            connection.Close();
        }
        void KadınPersonel()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select CINSIYET,COUNT(*) From TBLPERSONEL GROUP BY CINSIYET ORDER BY CINSIYET ASC", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LKadınPersonel.Text = dr[1].ToString();
            }
            connection.Close();
        }
        void KadınMusteri()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select CINSIYET,COUNT(*) From TBLMUSTERI GROUP BY CINSIYET ORDER BY CINSIYET ASC", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LMKadın.Text = dr[1].ToString();
            }
            connection.Close();
        }
        void ErkekMusteri()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select CINSIYET,COUNT(*) From TBLMUSTERI GROUP BY CINSIYET ORDER BY CINSIYET DESC", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                LMErkek.Text = dr[1].ToString();
            }
            connection.Close();
        }
        private void FProductStatis_Load(object sender, EventArgs e)
        {
            UrunSayisi();
            KategoriSayisi();
            StokSayisi();
            KritikSeviye();
            BitikUrun();
            EnStokluUrun();
            EnAzStokluUrun();
            PahaliUrun();
            UcuzUrun();
            MarkaSayısı();
            FazlaMarka();
            FazlaKategori();
            AzKategori();
            Musteriler();
            Personeller();
            PersonelPuan();
            ErkekPersonel();
            KadınPersonel();
            KadınMusteri();
            ErkekMusteri();
        }
    }
}
