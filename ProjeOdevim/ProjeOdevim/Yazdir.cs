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
        public Yazdir(int? islemno)
        {
            IslemNo = islemno;
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
            string isyeri = "", urun = "", barkod = "", marka = "", indirim = "", toplamsatisfiyat = "", tel = "";
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlCommand sabit = new SqlCommand("SELECT * FROM TBLMAGAZA WHERE ID=3", connection);
            SqlDataReader dr = sabit.ExecuteReader();
            while (dr.Read())
            {
                isyeri = dr[1].ToString();
                tel = dr[8].ToString();
            }
            connection.Close();

            connection.Open();
            SqlCommand sabit2 = new SqlCommand("SELECT * FROM TBLSATIS WHERE ISLEMNO=" + IslemNo, connection);
            SqlDataReader dr2 = sabit2.ExecuteReader();
            while (dr2.Read())
            {
                urun = dr2[2].ToString();
                barkod = dr2[3].ToString();
                marka = dr2[5].ToString();
                indirim = dr2[8].ToString();
                toplamsatisfiyat = dr2[9].ToString();

            }
            connection.Close();

            if (dr != null && dr2 != null)
            {
                Font fonbaslik = new Font("Calibri", 24, FontStyle.Bold);
                Font fontbilgi = new Font("Calibri", 12, FontStyle.Bold);
                StringFormat ortala = new StringFormat(StringFormatFlags.FitBlackBox);
                ortala.Alignment = StringAlignment.Center;
                RectangleF rcUnvanKonum = new RectangleF(125, 20, 600, 500); // soldam,üstten,
                e.Graphics.DrawString(isyeri.ToString(), fonbaslik, Brushes.Black, rcUnvanKonum, ortala);
                e.Graphics.DrawString("Telefon: " + tel.ToString(), fontbilgi, Brushes.Black, new Point(5, 45));
                e.Graphics.DrawString("İşlem No: " + IslemNo.ToString(), fontbilgi, Brushes.Black, new Point(5, 60));
           //     e.Graphics.DrawString("Telefon: ")

            }
        }
    }
}
