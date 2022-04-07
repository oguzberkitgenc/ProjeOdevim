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
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");

        void DecliningStok()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select TOP 12 TBLURUN.ID as 'No',MARKAADI AS 'MARKA',URUNADI AS 'ÜRÜN ADI'," +
                "SATISFIYAT AS 'SATIŞ FİYATI',STOK,ACIKLAMA AS 'AÇIKLAMA' From TBLURUN INNER JOIN TBLMARKA ON " +
                "TBLURUN.MARKAID=TBLMARKA.ID  WHERE STOK>=1 ORDER BY STOK ASC ", connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
            connection.Close();
        }
        void NewEmployee()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select TOP 12 TBLPERSONEL.ID,DEPARTMAN,MAGAZA,AD AS 'AD SOYAD'" +
                "From TBLPERSONEL  INNER JOIN TBLDEPARTMAN ON TBLPERSONEL.DEPARTMANID=TBLDEPARTMAN.ID " +
                "INNER JOIN TBLMAGAZA ON TBLPERSONEL.MAGAZAID=TBLMAGAZA.ID " +
                "WHERE TBLPERSONEL.DEPARTMANID!=(SELECT ID FROM TBLDEPARTMAN WHERE DEPARTMAN='Stajer') " +
                "ORDER BY TBLPERSONEL.ID DESC", connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            gridControl3.DataSource = dataTable;
            connection.Close();
        }
        void NewStajer()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select TOP 12 TBLPERSONEL.ID,DEPARTMAN,MAGAZA,AD AS 'AD SOYAD' " +
                "From TBLPERSONEL  INNER JOIN TBLDEPARTMAN ON TBLPERSONEL.DEPARTMANID=TBLDEPARTMAN.ID " +
                "INNER JOIN TBLMAGAZA ON TBLPERSONEL.MAGAZAID=TBLMAGAZA.ID " +
                "WHERE TBLPERSONEL.DEPARTMANID=(SELECT ID FROM TBLDEPARTMAN WHERE DEPARTMAN='Stajer') " +
                "ORDER BY TBLPERSONEL.ID DESC", connection);
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            gridControl5.DataSource = dataTable;
            connection.Close();
        }
        void NewLogin()
        {
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
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT TOP 12 TBLNOTLAR.ID,BASLIK AS 'BAŞLIK',AD AS 'OLUŞTURAN'," +
                "DEPARTMAN AS 'HİTAP' FROM TBLNOTLAR INNER JOIN TBLPERSONEL ON TBLNOTLAR.OLUSTURAN=TBLPERSONEL.ID " +
                "INNER JOIN TBLDEPARTMAN ON TBLNOTLAR.HITAP=TBLDEPARTMAN.ID", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl6.DataSource = dt;
            connection.Close();
        }
        private void FHomeList_Load(object sender, EventArgs e)
        {
            DecliningStok();
            NewEmployee();
            NewStajer();
            NewLogin();
            NewSales();
            NewNote();
            timer1.Start();
            gridView2.Columns[0].Visible = false;
            gridView3.Columns[0].Visible = false;
            gridView5.Columns[0].Visible = false;
            gridView6.Columns[0].Visible = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DecliningStok();
            NewEmployee();
            NewStajer();
            NewLogin();
            NewSales();
            gridView2.Columns[0].Visible = false;
            gridView3.Columns[0].Visible = false;
            gridView5.Columns[0].Visible = false;
        }
    }
}
