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
    public partial class FVadeShow : Form
    {
        public FVadeShow()
        {
            InitializeComponent();
        }
        BaglantiSinif bgl = new BaglantiSinif();
        DataTable dt = new DataTable();
        public int vade = 0;
        public double anmony = 0;
        void TabloEkle()
        {
            dt.Columns.Add(new DataColumn("TARIH", typeof(string)));
            dt.Columns.Add(new DataColumn("TAKSIT", typeof(string)));
            dt.Columns.Add(new DataColumn("VADE", typeof(string)));
            dt.Columns.Add(new DataColumn("ANAPARA", typeof(string)));
            dt.Columns.Add(new DataColumn("VADEFAIZI", typeof(string)));
        }
        void TabloDoldur()
        {
            DateTime tarih = DateTime.Now;
            for (int i = 1; i <= vade; i++)
            {
                anmony = Math.Round(anmony, 2);
                DataRow dr = dt.NewRow();
                dr["VADE"] = i.ToString();
                dr["TAKSIT"] = LAylik.Text;
                dr["VADEFAIZI"] = LFaiz.Text;
                dr["TARIH"] = tarih.ToString();
                dr["ANAPARA"] = anmony.ToString();
                dt.Rows.Add(dr);
                tarih = tarih.AddMonths(1);
            }
            gridControl2.DataSource = dt;
        }
        void MusteriGetir()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            SqlCommand komut = new SqlCommand("SELECT ID,AD FROM TBLMUSTERI ORDER BY AD ASC", connection);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbMusteri.ValueMember = "ID";
            CmbMusteri.DisplayMember = "AD";
            CmbMusteri.DataSource = dt;
        }

        private void FVadeShow_Load(object sender, EventArgs e)
        {
            TabloEkle();
            TabloDoldur();
            MusteriGetir();
        }

        private void BPdf_Click(object sender, EventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            panel19.Visible = true;
            this.WindowState = FormWindowState.Maximized;
            gridView2.Columns[0].Width = 325;
            gridView2.Columns[1].Width = 325;
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT TC,AD,IL,ILCE,ADRES,TEL FROM TBLMUSTERI WHERE ID=" + CmbMusteri.SelectedValue, connection);
            SqlDataReader reader = komut.ExecuteReader();
            while (reader.Read())
            {
                LTc.Text = reader[0].ToString();
                LAd.Text = reader[1].ToString();
                LIl.Text = reader[2].ToString();
                LIlce.Text = reader[3].ToString();
                LAdres.Text = reader[4].ToString();
                LTel.Text = reader[5].ToString();
            }
            connection.Close();

            dt.Rows.Clear();
            DateTime tarih = DateTime.Now;
            for (int i = 1; i <= vade; i++)
            {
                anmony = Math.Round(anmony, 2);
                DataRow dr = dt.NewRow();
                dr["VADE"] = i.ToString();
                dr["TAKSIT"] = LAylik.Text;
                dr["VADEFAIZI"] = LFaiz.Text;
                dr["TARIH"] = tarih.ToString();
                dr["ANAPARA"] = anmony.ToString();
                dt.Rows.Add(dr);
                tarih = tarih.AddMonths(1);
            }
            dt.Rows.Add();
            DataRow dr3 = dt.NewRow();
            dr3["ANAPARA"] = "TOPLAM";
            dr3["VADE"] = "VADE";
            dr3["TAKSIT"] = "AYLIK TAKSİT";
            dr3["TARIH"] = "SON TAKSİT";
            dr3["VADEFAIZI"] = "FAİZ";
            dt.Rows.Add(dr3);

            DataRow dr2 = dt.NewRow();
            dr2["ANAPARA"] = LMiktar.Text.ToString();
            dr2["VADE"] = LVadeSayisi.Text.ToString();
            dr2["TAKSIT"] = LGeriOde.Text.ToString();
            dr2["TARIH"] = LSonTarih.Text.ToString();
            dr2["VADEFAIZI"] = LFaiz.Text.ToString();
            dt.Rows.Add(dr2);
            dt.Rows.Add();
            if (vade == 24)
            {
                dt.Rows.Add();
                dt.Rows.Add();
            }
            else if (vade == 18)
            {
                for (int i = 1; i <= 8; i++)
                {
                    dt.Rows.Add();
                }
            }
            DataRow dr4 = dt.NewRow();
            dr4["TARIH"] = "İMZA:";
            dt.Rows.Add(dr4);

            DataRow dr5 = dt.NewRow();
            dr5["TARIH"] = "TC:" + LTc.Text.ToString();
            dt.Rows.Add(dr5);

            DataRow dr6 = dt.NewRow();
            dr6["TARIH"] = "Ad Soyad:" + LAd.Text.ToString();
            dt.Rows.Add(dr6);

            DataRow dr7 = dt.NewRow();
            dr7["TARIH"] = "Telefon:" + LTel.Text.ToString();
            dt.Rows.Add(dr7);

            DataRow dr8 = dt.NewRow();
            dr8["TARIH"] = "Adres:" + LIl.Text.ToString() + "/" + LIlce.Text.ToString() + "\n" + LAdres.Text.ToString();
            dt.Rows.Add(dr8);

            DataRow dr9 = dt.NewRow();
            dr9["TARIH"] = "GEREKLİ AÇIKLAMALAR";
            dt.Rows.Add(dr9);

            DataRow dr10 = dt.NewRow();
            dr10["TARIH"] = "1. Satılan mal geri alınmaz";
            dt.Rows.Add(dr10);

            DataRow dr11 = dt.NewRow();
            dr11["TARIH"] = "2. Mal tesliminden sonra vuku olan";
            dr11["TAKSIT"] = "arızalarda yetkili servis muhataptır.";
            dt.Rows.Add(dr11);

            DataRow dr12 = dt.NewRow();
            dr12["TARIH"] = "3. Faturaya itiraz müddeti 8 gündür, 8 gün içerisinde";
            dr12["TAKSIT"] = "itiraz edilmediğinde aynen geçerlidir.";
            dt.Rows.Add(dr12);

            DataRow dr13 = dt.NewRow();
            dr13["TARIH"] = "4. Vadesinde ödenmeyen alacaklara";
            dr13["TAKSIT"] = "uygulanmakta olan faiz nispeti farkı\ntahakkuk ettirilir.";
            dt.Rows.Add(dr13);

            gridControl2.DataSource = dt;

            gridControl2.ExportToPdf(@"C:\Ticari Otomasyon\Raporlar\Vade\" + LAd.Text.ToString() + anmony.ToString() + ".Pdf");
            Cursor = Cursors.Default;
            MessageBox.Show("Rapor Oluşturuldu", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            Process.Start(@"C:\Ticari Otomasyon\Raporlar\Vade\" + LAd.Text.ToString() + anmony.ToString() + ".Pdf");
        }
    }
}