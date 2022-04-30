using System;
using System.Windows.Forms;

namespace ProjeOdevim.Formlar
{
    public partial class FWhoAmi : Form
    {
        public FWhoAmi()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FWhoAmi_Load(object sender, EventArgs e)
        {
            timer1.Start();
            timer5.Start();
            BKos1.Visible = false;
            BKos2.Visible = false;
            durum = true;
            /*l1 0; 260
             *l2 0; 280
             *l3 0; 300
             * 
             *31 660 ; 260
             *l2: 660;280
             *l3 660=300
             *l4430; 455
             */
        }
        int sag = 0;
        int sol = 0;
        int sayonu = 0;
        bool durum = false;
        int sl1 = -175;
        int sl4 = 430;
        Random rastgele = new Random(244);


        private void timer1_Tick(object sender, EventArgs e)
        {
            int sayi = rastgele.Next(1, 80);
            int sayi2 = rastgele.Next(80, 160);
            int sayi3 = rastgele.Next(160, 254);
            BKos.BackColor = System.Drawing.Color.FromArgb(sayi, sayi2, sayi3);
            BKos1.BackColor = System.Drawing.Color.FromArgb(sayi3, sayi, sayi2);
            BKos2.BackColor = System.Drawing.Color.FromArgb(sayi2, sayi3, sayi);

            sag += 5;
            BKos.Location = new System.Drawing.Point(sag + 45, 0);
            BKos1.Location = new System.Drawing.Point(sag + 25, 0);
            BKos2.Location = new System.Drawing.Point(sag, 0);
            if (sag >= 840)
            {
                timer1.Stop();
                timer2.Start();
            }
            if (durum == true)
            {
                durum = false;
                MessageBox.Show(" Yazılımın Genel Misyonu; \n Bir Şirketin / İşletmenin veri tabanı üzerinden  görselleştirilmiş veri grafikleriyle" +
               " kolay / detaylı / hızlı bir şekilde yönetilmesini amaçlar. \n\n Bu yazılım; \n Çukurova Üniversitesi Karaisali Meslek Yüksek Okulu " +
                "Bilgisayar Programcılığı Öğrencisi Oğuz Berkit GENÇ tarafından proje ödevi amaçlı geliştirilmiştir.", "ÇUKUROVA ÜNİVERSİTESİ KARAİSALİ MESLEK YÜKSEK OKULU", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int sayi = rastgele.Next(1, 80);
            int sayi2 = rastgele.Next(80, 160);
            int sayi3 = rastgele.Next(160, 254);
            BKos.BackColor = System.Drawing.Color.FromArgb(sayi2, sayi3, sayi);
            BKos1.BackColor = System.Drawing.Color.FromArgb(sayi, sayi2, sayi3);
            BKos2.BackColor = System.Drawing.Color.FromArgb(sayi3, sayi, sayi2);


            sol += 5;
            BKos.Location = new System.Drawing.Point(sag, sol + 45);
            BKos1.Location = new System.Drawing.Point(sag, sol + 25);
            BKos2.Location = new System.Drawing.Point(sag, sol);
            if (sol >= 500)
            {
                timer2.Stop();
                timer3.Start();
            }
        }

        private void timer3_Tick(object sender, EventArgs e)
        {
            int sayi = rastgele.Next(1, 80);
            int sayi2 = rastgele.Next(80, 160);
            int sayi3 = rastgele.Next(160, 254);
            BKos.BackColor = System.Drawing.Color.FromArgb(sayi3, sayi, sayi2);
            BKos1.BackColor = System.Drawing.Color.FromArgb(sayi2, sayi3, sayi);
            BKos2.BackColor = System.Drawing.Color.FromArgb(sayi, sayi2, sayi3);

            sag -= 5;
            BKos.Location = new System.Drawing.Point(sag + 45, sol);
            BKos1.Location = new System.Drawing.Point(sag + 25, sol);
            BKos2.Location = new System.Drawing.Point(sag, sol);


            if (sag == 0)
            {
                timer3.Stop();
                timer4.Start();
            }
        }

        private void timer4_Tick(object sender, EventArgs e)
        {
            int sayi = rastgele.Next(1, 80);
            int sayi2 = rastgele.Next(80, 160);
            int sayi3 = rastgele.Next(160, 254);
            BKos.BackColor = System.Drawing.Color.FromArgb(sayi, sayi2, sayi3);
            BKos1.BackColor = System.Drawing.Color.FromArgb(sayi2, sayi, sayi3);
            BKos2.BackColor = System.Drawing.Color.FromArgb(sayi3, sayi3, sayi2);


            sol -= 5;
            BKos.Location = new System.Drawing.Point(sag, sol + 45);
            BKos1.Location = new System.Drawing.Point(sag, sol + 25);
            BKos2.Location = new System.Drawing.Point(sag, sol);
            if (sol == 0)
            {
                timer4.Stop();
                timer1.Start();
                BKos1.Visible = true;
                sayonu += 1;
                if (sayonu >= 2)
                {
                    BKos2.Visible = true;
                }
            }
        }

        private void timer5_Tick(object sender, EventArgs e)
        {
            //-430
            sl1 += 3;
            sl4 -= 3;
            l1.Location = new System.Drawing.Point(sl1, 260);
            l2.Location = new System.Drawing.Point(sl1, 280);
            l3.Location = new System.Drawing.Point(sl1, 300);
            l4.Location = new System.Drawing.Point(sl4, 455);
            if (sl1 >= 885)
            {
                sl1 = 0;
            }
            if (sl4 <= -425)
            {
                sl4 = 850;
            }
        }
    }
}
