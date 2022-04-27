using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjeOdevim.Formlar
{
    public partial class FJok : Form
    {
        public FJok()
        {
            InitializeComponent();
        }
        Random random = new Random();
        int p1 = 3, p2 = 3, p3 = 3, p4 = 3, p5 = 3, p6 = 3, p7 = 3, p8 = 3, speed = 5;
        double kasa = 5000;
        double miktaral;

        bool b1 = false, b2 = false, b3 = false, b4 = false, b5 = false, b6 = false, b7 = false, b8 = false;

        private void TBahis_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        void KontrolEt()
        {
            if (comboBox1.Text == LWin.Text)
            {
                miktaral = miktaral * 2;
                kasa = kasa + miktaral;
                LKasa.Text = kasa.ToString("C2");
            }
        }

        private void checkBox1_Click(object sender, EventArgs e)
        {
            if (checkBox1.Checked == true)
            {
                WM.Ctlcontrols.play();

            }
            else if (checkBox1.Checked == false)
            {
                WM.Ctlcontrols.pause();
            }
        }

        private void pictureBox25_Click(object sender, EventArgs e)
        {
            WM.settings.volume += 10;
        }
        private void pictureBox26_Click(object sender, EventArgs e)
        {
            WM.settings.volume -= 10;
        }

        private void PSol_Click(object sender, EventArgs e)
        {
            if (speed == 1)
            {
                MessageBox.Show("Min HIZ");
                PSol.Enabled = false;
            }
            else
            {
                PSag.Enabled = true;
                speed -= 1;
                TSpeed.Text = speed.ToString();
                if (speed == 1)
                {
                    timer1.Interval = 325;
                }
                else if (speed == 2)
                {
                    timer1.Interval = 250;
                }
                else if (speed == 3)
                {
                    timer1.Interval = 180;
                }
                else if (speed == 4)
                {
                    timer1.Interval = 90;
                }
                else if (speed == 5)
                {
                    timer1.Interval = 30;
                }
            }

        }

        private void PSag_Click(object sender, EventArgs e)
        {
            if (speed == 5)
            {
                MessageBox.Show("Max HIZ");
                PSag.Enabled = false;
            }
            else
            {
                PSol.Enabled = true;
                speed += 1;
                TSpeed.Text = speed.ToString();
                if (speed == 1)
                {
                    timer1.Interval = 750;
                }
                else if (speed == 2)
                {
                    timer1.Interval = 250;
                }
                else if (speed == 3)
                {
                    timer1.Interval = 180;
                }
                else if (speed == 4)
                {
                    timer1.Interval = 90;
                }
                else if (speed == 5)
                {
                    timer1.Interval = 30;
                }
            }

        }


        private void FJok_Load(object sender, EventArgs e)
        {
            comboBox1.SelectedIndex = 0;
            try
            {
                WM.URL = @"C:\Ticari Otomasyon\videoplayback.mp4";

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            kasa = Math.Round(kasa);
            LKasa.Text = kasa.ToString("C2");
            TSpeed.Text = speed.ToString();
        }

        private void BBaslat_Click(object sender, EventArgs e)
        {
            comboBox1.Enabled = false;
            miktaral = double.Parse(TBahis.Text);
            if (kasa >= miktaral)
            {
                kasa = kasa - miktaral;
                LKasa.Text = kasa.ToString("C2");
                if (BBaslat.Text == "BAŞLAT")
                {
                    timer1.Start();
                }
                else if (BBaslat.Text == "TEKRAR")
                {
                    p1 = 3;
                    p2 = 3;
                    p3 = 3;
                    p4 = 3;
                    p5 = 3;
                    p6 = 3;
                    p7 = 3;
                    p8 = 3;
                    pictureBox1.Location = new Point(p1, 3);
                    pictureBox2.Location = new Point(p2, 3);
                    pictureBox3.Location = new Point(p3, 3);
                    pictureBox4.Location = new Point(p4, 3);
                    pictureBox5.Location = new Point(p5, 3);
                    pictureBox6.Location = new Point(p6, 3);
                    pictureBox7.Location = new Point(p7, 3);
                    pictureBox8.Location = new Point(p8, 3);
                    Ulke1.Visible = false;
                    Ulke2.Visible = false;
                    Ulke3.Visible = false;
                    Ulke4.Visible = false;
                    Ulke5.Visible = false;
                    Ulke6.Visible = false;
                    Ulke7.Visible = false;
                    Ulke8.Visible = false;
                    pictureBox17.Visible = false;
                    pictureBox18.Visible = false;
                    pictureBox19.Visible = false;
                    pictureBox20.Visible = false;
                    pictureBox21.Visible = false;
                    pictureBox22.Visible = false;
                    pictureBox23.Visible = false;
                    pictureBox24.Visible = false;
                    Kupa1.Visible = false;
                    Kupa2.Visible = false;
                    Kupa3.Visible = false;
                    Kupa4.Visible = false;
                    Kupa5.Visible = false;
                    Kupa6.Visible = false;
                    Kupa7.Visible = false;
                    Kupa8.Visible = false;
                    pictureBox1.Size = new Size(100, 50);
                    pictureBox2.Size = new Size(100, 50);
                    pictureBox3.Size = new Size(100, 50);
                    pictureBox4.Size = new Size(100, 50);
                    pictureBox5.Size = new Size(100, 50);
                    pictureBox6.Size = new Size(100, 50);
                    pictureBox7.Size = new Size(100, 50);
                    pictureBox8.Size = new Size(100, 50);
                    b1 = false;
                    b2 = false;
                    b3 = false;
                    b4 = false;
                    b5 = false;
                    b6 = false;
                    b7 = false;
                    b8 = false;
                    LWin.Text = "";
                    timer1.Start();
                }
            }
            else
            {
                MessageBox.Show(TBahis.Text + " Üzgünüm... Ne Yazık ki kasada bu kadar paramız yok :(", "OLSUN BE", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

        }
        private void timer1_Tick(object sender, EventArgs e)
        {

            int sayi = random.Next(1, 9);
            p1 = sayi + p1;
            pictureBox1.Location = new Point(p1, 3);

            int sayi2 = random.Next(1, 9);
            p2 = sayi2 + p2;
            pictureBox2.Location = new Point(p2, 3);

            int sayi3 = random.Next(1, 9);
            p3 = sayi3 + p3;
            pictureBox3.Location = new Point(p3, 3);

            int sayi4 = random.Next(1, 9);
            p4 = sayi4 + p4;
            pictureBox4.Location = new Point(p4, 3);

            int sayi5 = random.Next(1, 9);
            p5 = sayi5 + p5;
            pictureBox5.Location = new Point(p5, 3);

            int sayi6 = random.Next(1, 9);
            p6 = sayi6 + p6;
            pictureBox6.Location = new Point(p6, 3);

            int sayi7 = random.Next(1, 9);
            p7 = sayi7 + p7;
            pictureBox7.Location = new Point(p7, 3);

            int sayi8 = random.Next(1, 9);
            p8 = sayi8 + p8;
            pictureBox8.Location = new Point(p8, 3);

            if (p1 >= 1268 || p2 >= 1268 || p3 >= 1268 || p4 >= 1268 || p5 >= 1268 || p6 >= 1268 || p7 >= 1268 || p8 >= 1268)
            {
                timer1.Stop();
                if (p1 >= 1268)
                {
                    pictureBox1.Size = new Size(175, 50);
                    pictureBox1.Location = new Point(600, 3);
                    Ulke1.Visible = true;
                    pictureBox17.Visible = true;
                    Kupa1.Visible = true;
                    b1 = true;
                }
                else if (p2 >= 1268)
                {
                    pictureBox2.Size = new Size(175, 50);
                    pictureBox2.Location = new Point(600, 3);
                    Ulke2.Visible = true;
                    pictureBox18.Visible = true;
                    Kupa2.Visible = true;
                    b2 = true;
                }
                else if (p3 >= 1268)
                {
                    pictureBox3.Size = new Size(175, 50);
                    pictureBox3.Location = new Point(600, 3);
                    Ulke3.Visible = true;
                    pictureBox19.Visible = true;
                    Kupa3.Visible = true;
                    b3 = true;
                }
                else if (p4 >= 1268)
                {
                    pictureBox4.Size = new Size(175, 50);
                    pictureBox4.Location = new Point(600, 3);
                    Ulke4.Visible = true;
                    pictureBox20.Visible = true;
                    Kupa4.Visible = true;
                    b4 = true;
                }
                else if (p5 >= 1268)
                {
                    pictureBox5.Size = new Size(175, 50);
                    pictureBox5.Location = new Point(600, 3);
                    Ulke5.Visible = true;
                    pictureBox21.Visible = true;
                    Kupa5.Visible = true;
                    b5 = true;
                }
                else if (p6 >= 1268)
                {
                    pictureBox6.Size = new Size(175, 50);
                    pictureBox6.Location = new Point(600, 3);
                    Ulke6.Visible = true;
                    pictureBox22.Visible = true;
                    Kupa6.Visible = true;
                    b6 = true;
                }
                else if (p7 >= 1268)
                {
                    pictureBox7.Size = new Size(175, 50);
                    pictureBox7.Location = new Point(600, 3);
                    Ulke7.Visible = true;
                    pictureBox23.Visible = true;
                    Kupa7.Visible = true;
                    b7 = true;
                }
                else if (p8 >= 1268)
                {
                    pictureBox8.Size = new Size(175, 50);
                    pictureBox8.Location = new Point(600, 3);
                    Ulke8.Visible = true;
                    pictureBox24.Visible = true;
                    Kupa8.Visible = true;
                    b8 = true;
                }
                BBaslat.Text = "TEKRAR";
                comboBox1.Enabled = true;
            }
            if (b1 == true)
            {
                LWin.Text = "CHANGE-- AVUSTURYA";
                KontrolEt();
            }
            else if (b2 == true)
            {
                LWin.Text = "GUİNEVERE -- İZLANDA";
                KontrolEt();
            }
            else if (b3 == true)
            {
                LWin.Text = "MİYA -- İTALYA";
                KontrolEt();
            }
            else if (b4 == true)
            {
                LWin.Text = "POKİTO -- KUVEYT";
                KontrolEt();
            }
            else if (b5 == true)
            {
                LWin.Text = "GUSİON-- LÜXSEMBURG";
                KontrolEt();
            }
            else if (b6 == true)
            {
                LWin.Text = "BEYAZ SARAY -- TÜRKİYE";
                KontrolEt();
            }
            else if (b7 == true)
            {
                LWin.Text = "DİGGİE -- PAKİSTAN";
                KontrolEt();
            }
            else if (b8 == true)
            {
                LWin.Text = "NANA -- SİNGAPUR";
                KontrolEt();
            }
        }
    }
}

