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
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=TicariOtomasyon;Integrated Security=True");
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
        private void Pd_PrintPage(object sender, PrintPageEventArgs e)
        {
            string mposta = "", mersis = "", ticaretno = "", vergino = "", vergi = "",
                mail = "", web = "", fax = "", il = "", ilce = "", adres = "", ticari = "",
                isyeri = "", urun = "", barkod = "", marka = "", indirim = "", birimfiyat = "", tel = "",
                tel2 = "", mtc = "", mad = "", mil = "", milce = "", madres = "", mtel = "", isbank = "", 
                garanti = "", akbank = "", finans = "", ziraat = "", halk = "",yapikredi="";
            int yukseklik = 335;
            double geneltoplam = 0;
            DateTime dt = DateTime.Now;

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
                isbank=dr[16].ToString();
                garanti=dr[17].ToString();
                yapikredi=dr[18].ToString();
                akbank=dr[19].ToString();
                finans=dr[20].ToString();
                ziraat=dr[21].ToString();
                halk=dr[22].ToString();
            }
            connection.Close();

            Font fontbilgi = new Font("Calibri", 12, FontStyle.Bold);
            Font fontIcerikBaslik = new Font("Calibri", 12, FontStyle.Underline);
            Font icerik = new Font("Calibri", 8, FontStyle.Italic);
            Font icerikkalin = new Font("Calibri", 8, FontStyle.Bold);

            e.Graphics.DrawString(isyeri.ToString(), new Font("Monotype Corsiva", 24, FontStyle.Bold), Brushes.Black, new Point(460, 15)); // soldan üstten
            Image img = Image.FromFile(@"C:\Ticari Otomasyon\image\employee\logo.png");
            Point loc = new Point(500, 50);
            e.Graphics.DrawImage(img, loc);
            e.Graphics.DrawString(ticari.ToString(), icerikkalin, Brushes.Black, new Point(5, 15));
            e.Graphics.DrawString("Adres: " + il.ToString() + " / " + ilce.ToString() + "\n" + adres.ToString(), icerik, Brushes.Black, new Point(5, 30));
            e.Graphics.DrawString("Telefon: " + tel.ToString() + " Telefon 2: " + tel2.ToString() + " FAX: " + fax.ToString(), icerik, Brushes.Black, new Point(5, 60));
            e.Graphics.DrawString("Web Sitesi: " + web.ToString(), icerik, Brushes.Black, new Point(5, 75));
            e.Graphics.DrawString("Mail: " + mail.ToString(), icerik, Brushes.Black, new Point(5, 90));
            e.Graphics.DrawString("Vergi Dairesi: " + vergi.ToString() + " Vergi No: " + vergino.ToString(), icerik, Brushes.Black, new Point(5, 105));
            e.Graphics.DrawString("Ticaret Sicil No: " + ticaretno.ToString(), icerik, Brushes.Black, new Point(5, 120));
            e.Graphics.DrawString("Mersis No: " + mersis.ToString(), icerik, Brushes.Black, new Point(5, 135));

            connection.Open();
            SqlCommand bul = new SqlCommand("SELECT TC,AD,IL,ILCE,ADRES,TEL,EPOSTA FROM TBLMUSTERI WHERE ID=" + MusteriNo, connection);
            SqlDataReader br = bul.ExecuteReader();
            while (br.Read())
            {
                mtc = br[0].ToString();
                mad = br[1].ToString();
                mil = br[2].ToString();
                milce = br[3].ToString();
                madres = br[4].ToString();
                mtel = br[5].ToString();
                mposta = br[6].ToString();
            }
            connection.Close();


            e.Graphics.DrawString("SAYIN: " + mad.ToString(), icerikkalin, Brushes.Black, new Point(5, 170));
            e.Graphics.DrawString("Adres: " + mil.ToString() + "/" + milce.ToString() + "\n" + madres.ToString(), icerik, Brushes.Black, new Point(5, 190));
            e.Graphics.DrawString("Mail: " + mposta.ToString(), icerik, Brushes.Black, new Point(5, 215));
            e.Graphics.DrawString("Tel: " + mtel.ToString(), icerik, Brushes.Black, new Point(5, 228));
            e.Graphics.DrawString("Veri Dadiresi: " + "TCKİMLİKNO", icerik, Brushes.Black, new Point(5, 242));
            e.Graphics.DrawString("TCKN: " + mtc.ToString(), icerik, Brushes.Black, new Point(5, 258));

            e.Graphics.DrawString("Fatura Tarihi: " + dt.ToShortDateString(), icerikkalin, Brushes.Black, new Point(600, 228));
            e.Graphics.DrawString("Fatura Saati: " + dt.ToShortTimeString(), icerikkalin, Brushes.Black, new Point(600, 242));
            e.Graphics.DrawString("İşlem No: " + IslemNo.ToString(), icerikkalin, Brushes.Black, new Point(600, 258));




            e.Graphics.DrawString("      *******************************************************************************************", fontbilgi, Brushes.Black, new Point(5, 285));
            e.Graphics.DrawString("Barkod: ", fontIcerikBaslik, Brushes.Black, new Point(5, 315));
            e.Graphics.DrawString("Marka: ", fontIcerikBaslik, Brushes.Black, new Point(100, 315));
            e.Graphics.DrawString("Ürün: ", fontIcerikBaslik, Brushes.Black, new Point(300, 315));
            e.Graphics.DrawString("İndirim Oranı: ", fontIcerikBaslik, Brushes.Black, new Point(550, 315));
            e.Graphics.DrawString("Birim Fiyatı: ", fontIcerikBaslik, Brushes.Black, new Point(700, 315));


            connection.Open();
            SqlCommand sabit2 = new SqlCommand("SELECT ISLEMNO,BARKODNO,MARKAADI,URUNADI,INDIRIMORANI,TOPLAMFIYAT FROM TBLSATIS INNER JOIN TBLURUN ON TBLSATIS.URUNID=TBLURUN.ID WHERE ISLEMNO=" + IslemNo, connection);
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
                e.Graphics.DrawString(indirim, fontbilgi, Brushes.Black, new Point(550, yukseklik));
                e.Graphics.DrawString(Convert.ToDouble(birimfiyat).ToString("C2"), fontbilgi, Brushes.Black, new Point(700, yukseklik));
                yukseklik += 20;
                geneltoplam += Convert.ToDouble(birimfiyat);
            }
            connection.Close();
            e.Graphics.DrawString("      *******************************************************************************************", fontbilgi, Brushes.Black, new Point(5, yukseklik));
            e.Graphics.DrawString("Genel Toplam: " + geneltoplam.ToString("C2"), new Font("Calibri", 14, FontStyle.Bold), Brushes.Black, new Point(550, yukseklik + 20));
            e.Graphics.DrawString("      *******************************************************************************************", fontbilgi, Brushes.Black, new Point(5, yukseklik + 40));

            e.Graphics.DrawString("Genel Açıklamalar ", icerikkalin, Brushes.Black, new Point(5, yukseklik + 280));
            e.Graphics.DrawString("1. Satılan mal geri alınmaz. ", icerik, Brushes.Black, new Point(5, yukseklik + 295));
            e.Graphics.DrawString("2. Mal tesliminden sonra vuku bulunan arızalarda yetkili servisler muhtapatır.", icerik, Brushes.Black, new Point(5, yukseklik + 310));
            e.Graphics.DrawString("3. Faturaya itiraz müddeti 8 gündür, 8 gün içinde itiraz edilmediğinde aynen geçerlidir.", icerik, Brushes.Black, new Point(5, yukseklik + 325));
            e.Graphics.DrawString("5. 433 Sıra nolu VUK genel tebliğine göre irsaliye yerine geçer..", icerikkalin, Brushes.Black, new Point(5, yukseklik + 342));

            e.Graphics.DrawString("BANKA HESAP NUMALARAIMIZ ", icerikkalin, Brushes.Black, new Point(300, yukseklik + 365));

            e.Graphics.DrawString("İŞ BANKASI: "+isbank.ToString(), icerikkalin, Brushes.Black, new Point(5, yukseklik + 385));
            e.Graphics.DrawString("FİNANS BANKASI: " + finans.ToString(), icerikkalin, Brushes.Black, new Point(350, yukseklik + 385));
            e.Graphics.DrawString("GARANTİ BANKASI: " + garanti.ToString(), icerikkalin, Brushes.Black, new Point(5, yukseklik + 405));
            e.Graphics.DrawString("ZİRAAT BANKASI: " + ziraat.ToString(), icerikkalin, Brushes.Black, new Point(350, yukseklik + 405));
            e.Graphics.DrawString("YAPI KREDİ BANKASI: " + yapikredi.ToString(), icerikkalin, Brushes.Black, new Point(5, yukseklik + 425));
            e.Graphics.DrawString("HALK BANK: " + halk.ToString(), icerikkalin, Brushes.Black, new Point(350, yukseklik + 425));
            e.Graphics.DrawString("AK BANK: " + akbank.ToString(), icerikkalin, Brushes.Black, new Point(5, yukseklik + 445));


        }
    }
}
