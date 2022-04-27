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
    public partial class FUserList : Form
    {
        public FUserList()
        {
            InitializeComponent();
        }
        BaglantiSinif bgl = new BaglantiSinif();

        void Listele()
        {
            DateTime baslangic = DateTime.Parse(DtBaslangic.Value.ToShortDateString());
            DateTime bitis = DateTime.Parse(DtBitis.Value.ToShortDateString());
            bitis = bitis.AddDays(1);
            DataTable dt = new DataTable();
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select KULLANICI,ADSOYAD,DEPARTMAN,TARIH From TBLKULLANICIHAREKET " +
                "INNER JOIN TBLDEPARTMAN ON TBLKULLANICIHAREKET.DEPART=TBLDEPARTMAN.ID WHERE TARIH BETWEEN @P1 AND @P2 ORDER BY TARIH DESC", connection);
            da.SelectCommand.Parameters.Add("@p1", SqlDbType.SmallDateTime).Value = baslangic;
            da.SelectCommand.Parameters.Add("@p2", SqlDbType.SmallDateTime).Value = bitis;
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
        }
        private void FUserList_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            Listele();
        }

        private void BSifirla_Click(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            DateTime dt2 = DateTime.Now;
            DtBaslangic.Value = dt;
            DtBitis.Value = dt2;
            Listele();
        }
    }
}
