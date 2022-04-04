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
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT ISLEMNO,TARIH,SUM(ALISFIYAT) AS 'MALİYET TUTARI',SUM(TOPLAMFIYAT) AS 'SATIŞ TUTARI'," +
                "INDIRIMORANI AS 'İNDİRİM %',TBLMUSTERI.AD AS 'MÜŞTERİ',TBLPERSONEL.AD+' ' + TBLPERSONEL.SOYAD AS 'PERSONEL' FROM TBLSATIS " +
                "INNER JOIN TBLMUSTERI ON TBLSATIS.MUSTERIID = TBLMUSTERI.ID INNER JOIN TBLPERSONEL ON TBLSATIS.PERSONEL=TBLPERSONEL.ID GROUP BY ISLEMNO," +
                "TOPLAMFIYAT,INDIRIMORANI,TBLMUSTERI.AD,TBLPERSONEL.AD+' ' + TBLPERSONEL.SOYAD ,TARIH ORDER BY ISLEMNO DESC", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
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
    }
}
