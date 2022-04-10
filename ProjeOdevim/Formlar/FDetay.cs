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
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");
        public string idal;

        private void FDetay_Load(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT ISLEMNO,TARIH,ALISFIYAT,SATISFIYAT,TOPLAMFIYAT,INDIRIMORANI,TBLPERSONEL.AD,TBLMUSTERI.AD FROM TBLSATIS  INNER JOIN TBLPERSONEL ON TBLSATIS.PERSONEL=TBLPERSONEL.ID INNER JOIN TBLMUSTERI ON TBLSATIS.MUSTERIID=TBLMUSTERI.ID WHERE ISLEMNO=@P1", connection);
            komut.Parameters.AddWithValue("@P1",idal.ToString());
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
        }
    }
}

