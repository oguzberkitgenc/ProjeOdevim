using System;
using System.Collections.Generic;
using System.Drawing.Printing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using System.Drawing;
namespace ProjeOdevim
{
    class Yazdir
    {
        public int? IslemNo { get; set; }
        public int? MusteriNo { get; set; }
        public Yazdir(int? islemno, int? musterino)
        {
            IslemNo = islemno;
            MusteriNo = musterino;
        }
        PrintDocument pd = new PrintDocument();
        public void YazdirmayaBasla()
        {

            pd.PrintPage += Pd_PrintPage;
            pd.Print();

        }
        BaglantiSinif bgl = new BaglantiSinif();

        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            string mersis = "", ticaretno = "", vergino = "", vergi = "", mail = "", web = "", fax = "", il = "", ilce = "", adres = "", ticari = "", isyeri = "", urun = "", barkod = "", marka = "", indirim = "", birimfiyat = "", tel = "", tel2 = "", mtc = "", mad = "", mil = "", milce = "", madres = "", mtel = ""; ;
            int yukseklik = 190;

            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlCommand sabit = new SqlCommand("SELECT * FROM TBLMAGAZA", connection);
            SqlDataReader dr = sabit.ExecuteReader();
            while (dr.Read())
            {
                isyeri = dr[1].ToString();
                il = dr[2].ToString();
                ilce = dr[3].ToString();
                adres = dr[4].ToString();
                tel = dr[5].ToString();
                tel2 = dr[6].ToString();
                mail = dr[7].ToString();
                web = dr[8].ToString();
                ticari = dr[10].ToString();
                fax = dr[11].ToString();
                vergi = dr[12].ToString();
                vergino = dr[13].ToString();
                ticaretno = dr[14].ToString();
                mersis = dr[15].ToString();
            }
            connection.Close();

            Font fonbaslik = new Font("Calibri", 24, FontStyle.Bold);
            Font fontbilgi = new Font("Calibri", 12, FontStyle.Bold);
            Font fontIcerikBaslik = new Font("Calibri", 12, FontStyle.Underline);
            Font icerik = new Font("Calibri", 8, FontStyle.Italic);
            Font icerikkalin = new Font("Calibri", 8, FontStyle.Bold);
            //  StringFormat ortala = new StringFormat(StringFormatFlags.FitBlackBox);
            //ortala.Alignment = StringAlignment.Center;
            // RectangleF rcUnvanKonum = new RectangleF(125, 20, 600, 500); // soldan,üstten,genişlik

            e.Graphics.DrawString(isyeri.ToString(), fonbaslik, Brushes.Black, new Point(460, 15)); // soldan üstten
            e.Graphics.DrawString(ticari.ToString(), icerikkalin, Brushes.Black, new Point(5, 15));
            e.Graphics.DrawString("Adres: " + il.ToString() + " / " + ilce.ToString() + "\n" + adres.ToString(), icerik, Brushes.Black, new Point(5, 30));
            e.Graphics.DrawString("Telefon: " + tel.ToString() + " Telefon 2: " + tel2.ToString() + " FAX: " + fax.ToString(), icerik, Brushes.Black, new Point(5, 60));
            e.Graphics.DrawString("Web Sitesi: " + web.ToString(), icerik, Brushes.Black, new Point(5, 75));
            e.Graphics.DrawString("Mail: " + mail.ToString(), icerik, Brushes.Black, new Point(5, 90));
            e.Graphics.DrawString("Vergi Dairesi: " + vergi.ToString() + " Vergi No: " + vergino.ToString(), icerik, Brushes.Black, new Point(5, 105));
            e.Graphics.DrawString("Ticaret Sicil No: " + ticaretno.ToString(), icerik, Brushes.Black, new Point(5, 120));
            e.Graphics.DrawString("Mersis No: " + mersis.ToString(), icerik, Brushes.Black, new Point(5, 135));

            //   e.Graphics.DrawString("İşlem No: " + IslemNo.ToString(), icerikkalin, Brushes.Black, new Point(5, 60));
            e.Graphics.DrawString("      *******************************************************************************************", fontbilgi, Brushes.Black, new Point(5, 150));

            e.Graphics.DrawString("Barkod: ", fontIcerikBaslik, Brushes.Black, new Point(5, 170));
            e.Graphics.DrawString("Marka: ", fontIcerikBaslik, Brushes.Black, new Point(100, 170));
            e.Graphics.DrawString("Ürün: ", fontIcerikBaslik, Brushes.Black, new Point(300, 170));
            e.Graphics.DrawString("İndirim Oranı: ", fontIcerikBaslik, Brushes.Black, new Point(600, 170));
            e.Graphics.DrawString("Birim Fiyatı: ", fontIcerikBaslik, Brushes.Black, new Point(700, 170));

            connection.Open();
            SqlCommand bul = new SqlCommand("SELECT TC,AD,IL,ILCE,ADRES,TEL FROM TBLMUSTERI WHERE ID=" + MusteriNo, connection);
            SqlDataReader br = bul.ExecuteReader();
            while (br.Read())
            {
                mtc = br[0].ToString();
                mad = br[1].ToString();
                mil=br[2].ToString();
                milce=br[3].ToString();
                madres=br[4].ToString();
                mtel=br[5].ToString();
            }
            connection.Close();

            connection.Open();
            SqlCommand sabit2 = new SqlCommand("SELECT ISLEMNO,BARKODNO,MARKAADI,URUNADI,INDIRIMORANI,TOPLAMFIYAT FROM TBLSATIS INNER JOIN TBLURUN ON TBLSATIS.URUNID=TBLURUN.ID WHERE ISLEMNO=" + IslemNo, connection);
            //     sabit2.Parameters.AddWithValue("@ISLEM", IslemNo.ToString());
            SqlDataReader dr2 = sabit2.ExecuteReader();
            while (dr2.Read())
            {
                barkod = dr2[1].ToString();
                urun = dr2[2].ToString();
                marka = dr2[3].ToString();
                indirim = dr2[4].ToString();
                birimfiyat = dr2[5].ToString();

                e.Graphics.DrawString(barkod, fontbilgi, Brushes.Black, new Point(5, yukseklik));
                e.Graphics.DrawString(urun, fontbilgi, Brushes.Black, new Point(100, yukseklik));
                e.Graphics.DrawString(marka, fontbilgi, Brushes.Black, new Point(300, yukseklik));
                e.Graphics.DrawString(indirim, fontbilgi, Brushes.Black, new Point(600, yukseklik));
                e.Graphics.DrawString(Convert.ToDouble(birimfiyat).ToString("C2"), fontbilgi, Brushes.Black, new Point(700, yukseklik));
                yukseklik += 20;
            }
            connection.Close();
            e.Graphics.DrawString("      *******************************************************************************************", fontbilgi, Brushes.Black, new Point(5, yukseklik));

        }
    }
}
