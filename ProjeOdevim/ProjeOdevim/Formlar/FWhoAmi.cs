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
            BKos1.Visible = false;
        }
        int sag = 0;
        int sol = 0;
        Random rastgele = new Random(244);


        private void timer1_Tick(object sender, EventArgs e)
        {
            int sayi = rastgele.Next(1, 80);
            int sayi2 = rastgele.Next(80, 160);
            int sayi3 = rastgele.Next(160, 254);
            BKos.BackColor = System.Drawing.Color.FromArgb(sayi, sayi2, sayi3);
            BKos1.BackColor = System.Drawing.Color.FromArgb(sayi2, sayi, sayi3);

            sag += 5;
            BKos.Location = new System.Drawing.Point(sag + 25, 0);
            BKos1.Location = new System.Drawing.Point(sag, 0);
            if (sag >= 840)
            {
                timer1.Stop();
                timer2.Start();
            }
        }

        private void timer2_Tick(object sender, EventArgs e)
        {
            int sayi = rastgele.Next(1, 80);
            int sayi2 = rastgele.Next(80, 160);
            int sayi3 = rastgele.Next(160, 254);
            BKos.BackColor = System.Drawing.Color.FromArgb(sayi2, sayi3, sayi);
            BKos1.BackColor = System.Drawing.Color.FromArgb(sayi, sayi2, sayi3);


            sol += 5;
            BKos.Location = new System.Drawing.Point(sag, sol + 25);
            BKos1.Location = new System.Drawing.Point(sag, sol);
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
            BKos.BackColor = System.Drawing.Color.FromArgb(sayi2, sayi3, sayi);

            sag -= 5;
            BKos.Location = new System.Drawing.Point(sag + 25, sol);
            BKos1.Location = new System.Drawing.Point(sag, sol);

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
            BKos.BackColor = System.Drawing.Color.FromArgb(sayi2, sayi, sayi3);

            sol -= 5;
            BKos.Location = new System.Drawing.Point(sag, sol + 25);
            BKos1.Location = new System.Drawing.Point(sag, sol);

            if (sol == 0)
            {
                timer4.Stop();
                timer1.Start();
                BKos1.Visible = true;
            }
        }
    }
}
