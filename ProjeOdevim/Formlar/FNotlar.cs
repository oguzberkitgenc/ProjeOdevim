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
    public partial class FNotlar : Form
    {
        public FNotlar()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");
        void Listele()
        {
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT TBLNOTLAR.ID,BASLIK AS 'BAŞLIK',AD AS 'OLUŞTURAN'," +
                "DEPARTMAN AS 'HİTAP',MESAJ,TARIH FROM TBLNOTLAR INNER JOIN TBLPERSONEL ON TBLNOTLAR.OLUSTURAN=TBLPERSONEL.ID " +
                "INNER JOIN TBLDEPARTMAN ON TBLNOTLAR.HITAP=TBLDEPARTMAN.ID", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
            gridView1.Columns[0].Visible = false;
        }
        void OlusturanList()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT ID,AD FROM TBLPERSONEL ORDER BY ID ASC", connection);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbOlusturan.ValueMember = "ID";
            CmbOlusturan.DisplayMember = "AD";
            CmbOlusturan.DataSource = dt;
            connection.Close();
        }
        void HitapList()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT ID,DEPARTMAN FROM TBLDEPARTMAN ORDER BY ID ASC", connection);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbHitap.ValueMember = "ID";
            CmbHitap.DisplayMember = "DEPARTMAN";
            CmbHitap.DataSource = dt;
            connection.Close();
        }
        private void FNotlar_Load(object sender, EventArgs e)
        {
            Listele();
            OlusturanList();
            HitapList();
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            connection.Open();
            SqlCommand komut = new SqlCommand("insert into TBLNOTLAR (BASLIK,OLUSTURAN,HITAP,MESAJ,TARIH) values (@P1,@P2,@P3,@P4,@P5)", connection);
            komut.Parameters.AddWithValue("@P1", TBaslik.Text);
            komut.Parameters.AddWithValue("@P2", CmbOlusturan.SelectedValue);
            komut.Parameters.AddWithValue("@P3", CmbHitap.SelectedValue);
            komut.Parameters.AddWithValue("@P4", RchDetay.Text);
            komut.Parameters.AddWithValue("@P5", dt.ToString());
            komut.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show(" " + TBaslik.Text + "\n Yeni Not Sisteme Başarıyla Kayıt Edildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Listele();
        }
    }
}
