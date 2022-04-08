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
    public partial class FSettings : Form
    {
        public FSettings()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");

        string xml1, xml2, xml3, xml4, xml5,xml6;

        private void BXml4_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            xml4 = openFileDialog1.FileName;
            checkBox4.Checked = true;
        }

        private void BXml5_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            xml5 = openFileDialog1.FileName;
            checkBox5.Checked = true;
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand cmd = new SqlCommand("UPDATE TBLXML SET XML1=@P1,XML2=@P2,XML3=@P3,XML4=@P4,XML5=@P5,XML=@6", connection);
            cmd.Parameters.AddWithValue("@p1", xml1.ToString());
            cmd.Parameters.AddWithValue("@p2", xml2.ToString());
            cmd.Parameters.AddWithValue("@p3", xml3.ToString());
            cmd.Parameters.AddWithValue("@p4", xml4.ToString());
            cmd.Parameters.AddWithValue("@p5", xml5.ToString());
            cmd.Parameters.AddWithValue("@p6", xml6.ToString());
            cmd.ExecuteNonQuery();
            MessageBox.Show("XML Dosyaları Başarıyla Kayıt Edildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            connection.Close();
        }

        private void TKod_Enter(object sender, EventArgs e)
        {

        }

        private void TKod_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (TKod.Text == "Formlar.FDuzenle=NewFormlar.FDuzenle")
            {
                Formlar.FDuzenle f = new Formlar.FDuzenle();
                f.ShowDialog();
            }
        }

        private void BMusteri_Click(object sender, EventArgs e)
        {
            try
            {
                if (TMusteri.Text != "")
                {
                    connection.Open();
                    SqlCommand komut = new SqlCommand("UPDATE TBLKREDI SET KMUSTERI=" + TMusteri.Text, connection);
                    komut.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show(" " + TMusteri.Text + "\n Yeni Oran Sisteme Başarıyla Kayıt Edildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {

                MessageBox.Show(" Hatalı Giriş. \n\n Lütfen Sadece SAYI VE NOKTA işareti kullanınız. \n\n Lütfen Sayfayı Yenileyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }



        }

        private void BPersonel_Click(object sender, EventArgs e)
        {
            try
            {
                if (TPersonel.Text != "")
                {
                    connection.Open();
                    SqlCommand komut = new SqlCommand("UPDATE TBLKREDI SET KPERSONEL=" + TPersonel.Text, connection);
                    komut.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show(" " + TPersonel.Text + "\n Yeni Oran Sisteme Başarıyla Kayıt Edildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception)
            {
                MessageBox.Show(" Hatalı Giriş. \n\n Lütfen Sadece SAYI VE NOKTA işareti kullanınız. \n\n Lütfen Sayfayı Yenileyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }

        private void BPersonel_KeyPress(object sender, KeyPressEventArgs e)
        {

        }

        private void BYetkiKaydet_Click(object sender, EventArgs e)
        {
            // en son burada kaldın 
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            xml6 = openFileDialog1.FileName;
            checkBox2.Checked = true;
        }

        private void BXml3_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            xml3 = openFileDialog1.FileName;
            checkBox3.Checked = true;
        }

        private void BXml2_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            xml2 = openFileDialog1.FileName;
            checkBox2.Checked = true;
        }

        private void BXml1_Click(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            xml1 = openFileDialog1.FileName;
            checkBox1.Checked = true;
        }
        private void FSettings_Load(object sender, EventArgs e)
        {

        }
    }
}
