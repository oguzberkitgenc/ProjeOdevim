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
    public partial class FSalesList : Form
    {
        public FSalesList()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");

        void Listele()
        {
            SqlDataAdapter da = new SqlDataAdapter("SELECT ISLEMNO,TARIH,SUM(TOPLAMFIYAT) AS 'SATIŞ TUTARI',INDIRIMORANI," +
                "TBLPERSONEL.AD +' '+ TBLPERSONEL.SOYAD AS 'PERSONEL',TBLMUSTERI.AD AS 'MÜŞTERİ',SUM(ALISFIYAT) " +
                "AS 'MALİYET'FROM TBLSATIS  INNER JOIN TBLPERSONEL ON TBLSATIS.PERSONEL=TBLPERSONEL.ID " +
                "INNER JOIN TBLMUSTERI ON TBLSATIS.MUSTERIID=TBLMUSTERI.ID GROUP BY TARIH,ISLEMNO,INDIRIMORANI," +
                "TBLPERSONEL.AD +' '+ TBLPERSONEL.SOYAD,TBLMUSTERI.AD ORDER BY ISLEMNO DESC", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        private void FSalesList_Load(object sender, EventArgs e)
        {
            Listele();
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Listele();

        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            timer1.Stop();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ISLEMNO,TARIH,SUM(TOPLAMFIYAT) AS 'SATIŞ TUTARI',INDIRIMORANI, " +
                "TBLPERSONEL.AD +' '+ TBLPERSONEL.SOYAD AS 'PERSONEL',TBLMUSTERI.AD AS 'MÜŞTERİ',SUM(ALISFIYAT) AS 'MALİYET' " +
                "FROM TBLSATIS INNER JOIN TBLPERSONEL ON TBLSATIS.PERSONEL=TBLPERSONEL.ID INNER JOIN TBLMUSTERI ON TBLSATIS.MUSTERIID=TBLMUSTERI.ID " +
                "WHERE TARIH BETWEEN @P1 AND @P2 GROUP BY TARIH,ISLEMNO,INDIRIMORANI,TBLPERSONEL.AD +' '+ TBLPERSONEL.SOYAD,TBLMUSTERI.AD  " +
                "ORDER BY ISLEMNO DESC", connection);
            da.SelectCommand.Parameters.Add("@p1", SqlDbType.SmallDateTime).Value = DtBaslangic.Value;
            da.SelectCommand.Parameters.Add("@p2", SqlDbType.SmallDateTime).Value = DtBitis.Value;
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
    }
}
