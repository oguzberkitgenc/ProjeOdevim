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
using System.Diagnostics;

namespace ProjeOdevim.Formlar
{
    public partial class FSalesList : Form
    {
        public FSalesList()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=TicariOtomasyon;Integrated Security=True");


        public int idAl = 0;
        void Listele()
        {
            int datasatiri = gridView1.DataRowCount;
            DateTime baslangic = DateTime.Parse(DtBaslangic.Value.ToShortDateString());
            DateTime bitis = DateTime.Parse(DtBitis.Value.ToShortDateString());
            bitis = bitis.AddDays(1);
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ISLEMNO,TARIH,SUM(TOPLAMFIYAT) AS 'SATIŞ TUTARI',INDIRIMORANI, " +
                "TBLPERSONEL.AD AS 'PERSONEL',TBLMUSTERI.AD AS 'MÜŞTERİ',SUM(ALISFIYAT) AS 'MALİYET' " +
                "FROM TBLSATIS INNER JOIN TBLPERSONEL ON TBLSATIS.PERSONEL=TBLPERSONEL.ID INNER JOIN TBLMUSTERI ON TBLSATIS.MUSTERIID=TBLMUSTERI.ID " +
                "WHERE TARIH BETWEEN @P1 AND @P2 GROUP BY TARIH,ISLEMNO,INDIRIMORANI,TBLPERSONEL.AD,TBLMUSTERI.AD  " +
                "ORDER BY ISLEMNO DESC", connection);
            da.SelectCommand.Parameters.Add("@p1", SqlDbType.SmallDateTime).Value = baslangic;
            da.SelectCommand.Parameters.Add("@p2", SqlDbType.SmallDateTime).Value = bitis;
            da.Fill(dt);
            gridControl1.DataSource = dt;
            double ciro = 0;
            if (gridView1.DataRowCount > 0)
            {
                connection.Open();
                SqlCommand da2 = new SqlCommand("SELECT SUM(SATISFIYAT) FROM TBLSATIS WHERE TARIH BETWEEN @T1 AND @T2", connection);
                da2.Parameters.AddWithValue("@T1", baslangic);
                da2.Parameters.AddWithValue("@T2", bitis);
                SqlDataReader dr2 = da2.ExecuteReader();
                while (dr2.Read())
                {
                    ciro = Convert.ToDouble((dr2[0]));
                }
                connection.Close();
                TCiro.Text = " " + ciro.ToString("C2");
            }

        }
        private void FSalesList_Load(object sender, EventArgs e)
        {

            Listele();
            timer1.Start();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Listele();
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            if (durum == false)
            {
                Listele();
            }
        }
        bool durum = false;
        private void DtBaslangic_ValueChanged(object sender, EventArgs e)
        {
            durum = true;
        }
        private void BSifirla_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            DateTime dt2 = DateTime.Now;
            DtBaslangic.Value = dt;
            DtBitis.Value = dt2;
            durum = false;
            timer1.Start();
            Listele();
        }
        private void detayGösterToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDetay f = new FDetay();
            f.idal = LId.Text.ToString();
            f.ShowDialog();
        }

        private void contextMenuStrip1_Opening(object sender, CancelEventArgs e)
        {
            timer1.Stop();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.DataRowCount > 0)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                LId.Text = (dr["ISLEMNO"]).ToString();
            }

        }

        private void BPdf_Click(object sender, EventArgs e)
        {
            gridControl1.ExportToPdf(@"C:\Ticari Otomasyon\Raporlar\Ciro\" + DtBaslangic.Text.ToString()+ ".Pdf");
            MessageBox.Show("Rapor Oluşturuldu", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(@"C:\Ticari Otomasyon\Raporlar\Ciro\" + DtBaslangic.Text.ToString() + ".Pdf");

        }
    }
}
