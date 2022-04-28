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
    public partial class FHomeList : Form
    {
        public FHomeList()
        {
            InitializeComponent();
        }
        BaglantiSinif bgl = new BaglantiSinif();
        void DecliningStok()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select TOP 12 BARKOD,MARKAADI AS 'MARKA',URUNADI AS 'ÜRÜN ADI'," +
                "SATISFIYAT AS 'SATIŞ FİYATI',STOK,ACIKLAMA AS 'AÇIKLAMA' From TBLURUN INNER JOIN TBLMARKA ON " +
                "TBLURUN.MARKAID=TBLMARKA.ID  WHERE STOK>=1 ORDER BY STOK ASC ", connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
            connection.Close();
        }
        void NewEmployee()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select TOP 12 TBLPERSONEL.ID,DEPARTMAN,AD AS 'AD SOYAD'" +
                "From TBLPERSONEL  INNER JOIN TBLDEPARTMAN ON TBLPERSONEL.DEPARTMANID=TBLDEPARTMAN.ID " +
                "WHERE TBLPERSONEL.DEPARTMANID!=(SELECT ID FROM TBLDEPARTMAN WHERE DEPARTMAN='Stajer') " +
                "ORDER BY TBLPERSONEL.ID DESC", connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            gridControl3.DataSource = dataTable;
            connection.Close();
        }
        void Taksitler()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            DateTime dt = DateTime.Now;
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("SET DATEFORMAT DMY SELECT TOP 60 AD,TARIH,KACINCITAKSIT,TAKSITTUTARI FROM TBLTAKSITLER INNER JOIN TBLMUSTERI ON TBLTAKSITLER.MUSTERIT=TBLMUSTERI.ID WHERE TARIH>= '" + dt + "' order by TARIH ASC", connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            gridControl5.DataSource = dataTable;
            connection.Close();
        }
        void NewLogin()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select TOP 12 KULLANICI,ADSOYAD,DEPARTMAN,TARIH From TBLKULLANICIHAREKET " +
                "INNER JOIN TBLDEPARTMAN ON TBLKULLANICIHAREKET.DEPART=TBLDEPARTMAN.ID ORDER BY TARIH DESC", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl2.DataSource = dt;
            connection.Close();
            gridView2.Columns[0].Visible = false;
        }
        void NewSales()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 12 ISLEMNO,TARIH,SUM(TOPLAMFIYAT) AS 'SATIŞ TUTARI', TBLPERSONEL.AD AS 'PERSONEL' FROM TBLSATIS INNER JOIN TBLPERSONEL ON TBLSATIS.PERSONEL=TBLPERSONEL.ID GROUP BY TARIH,ISLEMNO," +
                "TBLPERSONEL.AD ORDER BY ISLEMNO DESC", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl4.DataSource = dt;
            connection.Close();
        }
        void NewNote()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 12 TBLNOTLAR.ID,BASLIK AS 'BAŞLIK',AD AS 'OLUŞTURAN'," +
                "DEPARTMAN AS 'HİTAP' FROM TBLNOTLAR INNER JOIN TBLPERSONEL ON TBLNOTLAR.OLUSTURAN=TBLPERSONEL.ID " +
                "INNER JOIN TBLDEPARTMAN ON TBLNOTLAR.HITAP=TBLDEPARTMAN.ID ORDER BY ID DESC", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl6.DataSource = dt;
            connection.Close();
        }
        private void FHomeList_Load(object sender, EventArgs e)
        {
            DateTime tarih1 = DateTime.Now;
            DateTime tarih2;
            tarih2 = tarih1.AddMonths(1);
            DecliningStok();
            NewEmployee();
            Taksitler();
            NewLogin();
            NewSales();
            NewNote();
            timer1.Start();
            gridView2.Columns[0].Visible = false;
            gridView3.Columns[0].Visible = false;
            gridView6.Columns[0].Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DecliningStok();
            NewEmployee();
            Taksitler();
            NewLogin();
            NewSales();
            gridView2.Columns[0].Visible = false;
            gridView3.Columns[0].Visible = false;
            gridView5.Columns[0].Visible = false;
        }
    }
}
