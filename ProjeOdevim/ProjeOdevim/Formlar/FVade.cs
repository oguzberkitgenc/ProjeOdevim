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
    public partial class FVade : Form
    {
        public FVade()
        {
            InitializeComponent();
        }
        BaglantiSinif bgl = new BaglantiSinif();
        void Listele()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT TBLTAKSITLER.ID,TBLMUSTERI.AD AS 'MÜŞTERİ',TBLPERSONEL.AD AS 'PERSONEL',ISLEMNOT AS 'İŞLEM NUMARASI'," +
                "TARIH,KACINCITAKSIT AS 'VADE',TAKSITTUTARI FROM TBLTAKSITLER INNER JOIN TBLMUSTERI ON TBLTAKSITLER.MUSTERIT=TBLMUSTERI.ID " +
                "INNER JOIN TBLPERSONEL ON TBLTAKSITLER.PERSONELT=TBLPERSONEL.ID ORDER BY TARIH ASC", connection);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
            gridView1.Columns[0].Visible = false;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView1.DataRowCount > 0)
            {
                DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
                Lbl.Text = dr["İŞLEM NUMARASI"].ToString();
            }
        }


        private void dETAYGÖSTERToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FDetay f = new FDetay();
            f.idal = Lbl.Text.ToString();
            f.ShowDialog();
        }

        private void BSearch_DoubleClick(object sender, EventArgs e)
        {
            Rch.Text = "";
        }

        private void BSearch_Click(object sender, EventArgs e)
        {
            try
            {
                if (Rch.Text != "")
                {
                    bool durum = false;
                    SqlConnection connection = new SqlConnection(bgl.Adres);
                    connection.Open();
                    SqlCommand komut = new SqlCommand("SELECT TBLTAKSITLER.ID,TBLMUSTERI.AD AS 'MÜŞTERİ',TBLPERSONEL.AD AS " +
                        "'PERSONEL',ISLEMNOT AS 'İŞLEM NUMARASI',TARIH,KACINCITAKSIT AS 'VADE',TAKSITTUTARI FROM TBLTAKSITLER INNER JOIN TBLMUSTERI " +
                        "ON TBLTAKSITLER.MUSTERIT=TBLMUSTERI.ID INNER JOIN TBLPERSONEL ON TBLTAKSITLER.PERSONELT=TBLPERSONEL.ID " +
                        "WHERE TBLMUSTERI.AD LIKE '%" + Rch.Text + "%' OR TBLPERSONEL.AD LIKE '%" + Rch.Text + "%' ORDER BY TARIH ASC", connection);
                    SqlDataAdapter da = new SqlDataAdapter(komut);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    gridControl1.DataSource = dt;
                    connection.Close();
                    if (gridView1.DataRowCount == 0)
                    {
                        durum = true;
                    }
                    if (durum == true)
                    {
                        connection.Open();
                        SqlCommand komut2 = new SqlCommand("SELECT TBLTAKSITLER.ID,TBLMUSTERI.AD AS 'MÜŞTERİ',TBLPERSONEL.AD AS " +
                            "'PERSONEL',ISLEMNOT AS 'İŞLEM NUMARASI',TARIH,KACINCITAKSIT AS 'VADE',TAKSITTUTARI FROM TBLTAKSITLER INNER JOIN TBLMUSTERI " +
                            "ON TBLTAKSITLER.MUSTERIT=TBLMUSTERI.ID INNER JOIN TBLPERSONEL ON TBLTAKSITLER.PERSONELT=TBLPERSONEL.ID " +
                            "WHERE ISLEMNOT=" + Rch.Text + "ORDER BY TARIH ASC", connection);
                        SqlDataAdapter da2 = new SqlDataAdapter(komut2);
                        DataTable dt2 = new DataTable();
                        da2.Fill(dt2);
                        gridControl1.DataSource = dt2;
                        connection.Close();
                        if (gridView1.DataRowCount == 0)
                        {
                            MessageBox.Show(Rch.Text + "\n\n Aradığını bulamadım...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                            Rch.Text = "";
                            Listele();
                        }
                    }
                    gridView1.Columns[0].Visible = false;

                }
                else if (Rch.Text == "")
                {
                    Listele();
                }
            }
            catch (Exception)
            {

                MessageBox.Show(Rch.Text + "\n\n Aradığını bulamadım...", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                Rch.Text = "";
                Listele();
            }
        }

        private void FVade_Load(object sender, EventArgs e)
        {
            Listele();
        }
    }
}
