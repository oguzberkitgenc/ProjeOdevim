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

        string xml1, xml2, xml3, xml4, xml5, xml6;

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
            connection.Close();
            MessageBox.Show("XML Dosyaları Başarıyla Kayıt Edildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
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
        void DepartmanGetir()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select ID,DEPARTMAN From TBLDEPARTMAN", connection);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbList.ValueMember = "ID";
            CmbList.DisplayMember = "DEPARTMAN";
            CmbList.DataSource = dt;
            connection.Close();
        }
        void YetkiGetir()
        {
            SqlCommand cmd2 = new SqlCommand("Select * FROM TBLDEPARTMAN WHERE ID=" + CmbList.SelectedValue, connection);
            connection.Open();
            SqlDataReader reader = cmd2.ExecuteReader();
            while (reader.Read())
            {
                CAnaSayfa.Checked = Convert.ToBoolean(reader[2]);
                CUrunSatis.Checked = Convert.ToBoolean(reader[3]);
                CKrediSorgula.Checked = Convert.ToBoolean(reader[4]);
                CDuyrular.Checked = Convert.ToBoolean(reader[5]);
                CPersoneller.Checked = Convert.ToBoolean(reader[6]);
                CMusteriler.Checked = Convert.ToBoolean(reader[7]);
                CUrunler.Checked = Convert.ToBoolean(reader[8]);
                CMagazalar.Checked = Convert.ToBoolean(reader[9]);
                CKategoriMarkaEkle.Checked = Convert.ToBoolean(reader[10]);
                CDepartmanEkle.Checked = Convert.ToBoolean(reader[11]);
                CCiroVerileri.Checked = Convert.ToBoolean(reader[12]);
                CYogunluk.Checked = Convert.ToBoolean(reader[13]);
                CGenelVeriler.Checked = Convert.ToBoolean(reader[14]);
                CTemelIstatisk.Checked = Convert.ToBoolean(reader[15]);
                CKategoriMarkaIstatisk.Checked = Convert.ToBoolean(reader[16]);
                CGunlukCiro.Checked = Convert.ToBoolean(reader[17]);
                CAylikCiro.Checked = Convert.ToBoolean(reader[18]);
                CGunlukKarsilastir.Checked = Convert.ToBoolean(reader[19]);
                CAylikKarsilastir.Checked = Convert.ToBoolean(reader[20]);
                CAyarlar.Checked = Convert.ToBoolean(reader[21]);
            }
            connection.Close();
        }
        void Clear()
        {
            CAnaSayfa.Checked = false;
            CUrunSatis.Checked = false;
            CKrediSorgula.Checked = false;
            CDuyrular.Checked = false;
            CPersoneller.Checked = false;
            CMusteriler.Checked = false;
            CUrunler.Checked = false;
            CMagazalar.Checked = false;
            CKategoriMarkaEkle.Checked = false;
            CDepartmanEkle.Checked = false;
            CCiroVerileri.Checked = false;
            CYogunluk.Checked = false;
            CGenelVeriler.Checked = false;
            CTemelIstatisk.Checked = false;
            CKategoriMarkaIstatisk.Checked = false;
            CGunlukCiro.Checked = false;
            CAylikCiro.Checked = false;
            CGunlukKarsilastir.Checked = false;
            CAylikKarsilastir.Checked = false;
            CAyarlar.Checked = false;
        }
        private void BYetkiKaydet_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show(CmbList.Text + " Departmanına seçili olan değerler güncellenecek.\n\nDevam etmek istiyor musun? ", "UYARI", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (secenek == DialogResult.Yes)
            {
                connection.Open();
                SqlCommand command = new SqlCommand("UPDATE TBLDEPARTMAN SET ANASAYFA=@P1,URUNSATIS=@P2,KREDISORGULA=@P3,DUYURULAR=@P4," +
                    "PERSONELLER=@P5,MUSTERILER=@P6,URUNLER=@P7,MAGAZALAR=@P8,KATEGORIEKLE=@P9,DEPARTKONTROL=@P10,CIROVERI=@P11," +
                    "YOGUNLUK=@P12,GENELVERI=@P13,TEMELISTATISK=@P14,KATEGORIMARKA=@P15,GUNLUKCIRO=@P16,AYLIKCIRO=@P17,GUNLUKKARSI=@P18," +
                    "AYLIKKARSI=@P19,AYARLAR=@P20 WHERE ID=@P21", connection);
                command.Parameters.AddWithValue("@P1", Convert.ToBoolean(CAnaSayfa.Checked));
                command.Parameters.AddWithValue("@P2", Convert.ToBoolean(CUrunSatis.Checked));
                command.Parameters.AddWithValue("@P3", Convert.ToBoolean(CKrediSorgula.Checked));
                command.Parameters.AddWithValue("@P4", Convert.ToBoolean(CDuyrular.Checked));
                command.Parameters.AddWithValue("@P5", Convert.ToBoolean(CPersoneller.Checked));
                command.Parameters.AddWithValue("@P6", Convert.ToBoolean(CMusteriler.Checked));
                command.Parameters.AddWithValue("@P7", Convert.ToBoolean(CUrunler.Checked));
                command.Parameters.AddWithValue("@P8", Convert.ToBoolean(CMagazalar.Checked));
                command.Parameters.AddWithValue("@P9", Convert.ToBoolean(CKategoriMarkaEkle.Checked));
                command.Parameters.AddWithValue("@P10", Convert.ToBoolean(CDepartmanEkle.Checked));
                command.Parameters.AddWithValue("@P11", Convert.ToBoolean(CCiroVerileri.Checked));
                command.Parameters.AddWithValue("@P12", Convert.ToBoolean(CYogunluk.Checked));
                command.Parameters.AddWithValue("@P13", Convert.ToBoolean(CGenelVeriler.Checked));
                command.Parameters.AddWithValue("@P14", Convert.ToBoolean(CTemelIstatisk.Checked));
                command.Parameters.AddWithValue("@P15", Convert.ToBoolean(CKategoriMarkaIstatisk.Checked));
                command.Parameters.AddWithValue("@P16", Convert.ToBoolean(CGunlukCiro.Checked));
                command.Parameters.AddWithValue("@P17", Convert.ToBoolean(CAylikCiro.Checked));
                command.Parameters.AddWithValue("@P18", Convert.ToBoolean(CGunlukKarsilastir.Checked));
                command.Parameters.AddWithValue("@P19", Convert.ToBoolean(CAylikKarsilastir.Checked));
                command.Parameters.AddWithValue("@P20", Convert.ToBoolean(CAyarlar.Checked));
                command.Parameters.AddWithValue("@P21", CmbList.SelectedValue);
                command.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(CmbList.Text + " Departmanına seçili olan değerler başarıyla güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            YetkiGetir();
        }

        private void BBrows_Click(object sender, EventArgs e)
        {
            FolderBrowserDialog dlg = new FolderBrowserDialog();
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TBackUp.Text = dlg.SelectedPath;
                BBackUp.Enabled = true;

            }
        }

        private void BBackUp_Click(object sender, EventArgs e)
        {
            try
            {
                string database = connection.Database.ToString();
                if (TBackUp.Text == string.Empty)
                {
                    MessageBox.Show("Lütfen yedekleme dosyasının konumunu seçin", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Hand);
                }
                else
                {
                    string cmd = "BACKUP DATABASE [" + database + "] TO DISK= '" + TBackUp.Text + "\\" + "database" + "-" + DateTime.Now.ToString("yyyy-MM-dd--HH-mm-ss") + ".bak'";
                    connection.Open();
                    SqlCommand command = new SqlCommand(cmd, connection);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Yedekleme işlemi başarıyla tamamlandı", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    BBackUp.Enabled = false;
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void BBrowse2_Click(object sender, EventArgs e)
        {
            OpenFileDialog dlg = new OpenFileDialog();
            dlg.Filter = "Veri tabanı dosyası|*.bak";
            dlg.Title = "Restorasyon";
            if (dlg.ShowDialog() == DialogResult.OK)
            {
                TRestore.Text = dlg.FileName;
                BRestore.Enabled = true;
            }
        }

        private void BRestore_Click(object sender, EventArgs e)
        {

            DialogResult secenek = MessageBox.Show("Bütün veriler silinip seçtiğiniz veri yedeği yüklenecektir.\n\n Onaylıyor musunuz?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Hand);
            if (secenek == DialogResult.Yes)
            {
                string database = connection.Database.ToString();
                Cursor.Current = Cursors.WaitCursor;
                connection.Open();
                try
                {
                    string str1 = string.Format("ALTER DATABASE [" + database + "] SET SINGLE_USER WITH ROLLBACK IMMEDIATE");
                    SqlCommand cmd1 = new SqlCommand(str1, connection);
                    cmd1.ExecuteNonQuery();

                    string str2 = "USE MASTER RESTORE DATABASE [" + database + "] FROM DISK ='" + TRestore.Text + "' WITH REPLACE;";
                    SqlCommand cmd2 = new SqlCommand(str2, connection);
                    cmd2.ExecuteNonQuery();

                    string str3 = string.Format("ALTER DATABASE [" + database + "] SET MULTI_USER");
                    SqlCommand cmd3 = new SqlCommand(str3, connection);
                    cmd3.ExecuteNonQuery();

                    MessageBox.Show(" Başarıyla Kayıt Edildi \n\n Programdan çıkış yapılıyor...", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                    Cursor.Current = Cursors.Default;
                }
                catch
                {


                }
            }

        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand kritik = new SqlCommand("UPDATE TBLXML SET KRITIK=@X1", connection);
            kritik.Parameters.AddWithValue("@X1", int.Parse(TKritik.Text));
            kritik.ExecuteNonQuery();
            connection.Close();
            MessageBox.Show(" Kritik Seviye Kayıt Edildi \n\n ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

        }

        private void B3_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand faiz = new SqlCommand("UPDATE TBLFAIZLER SET UC=" + T3.Text, connection);
                faiz.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(" Vade 3 Oranı Başarıyla Güncellendi \n Yeni Oran \n " + T3.Text, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }

        }

        private void B6_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand faiz = new SqlCommand("UPDATE TBLFAIZLER SET ALTI=" + T6.Text, connection);
                faiz.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(" Vade 6 Oranı Başarıyla Güncellendi \n Yeni Oran \n " + T6.Text, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void B9_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand faiz = new SqlCommand("UPDATE TBLFAIZLER SET DOKUZ=" + T9.Text, connection);
                faiz.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(" Vade 9 Oranı Başarıyla Güncellendi \n Yeni Oran \n " + T9.Text, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void B12_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand faiz = new SqlCommand("UPDATE TBLFAIZLER SET ONIKI=" + T12.Text, connection);
                faiz.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(" Vade 12 Oranı Başarıyla Güncellendi \n Yeni Oran \n " + T12.Text, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void B15_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand faiz = new SqlCommand("UPDATE TBLFAIZLER SET ONBES=" + T15.Text, connection);
                faiz.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(" Vade 15 Oranı Başarıyla Güncellendi \n Yeni Oran \n " + T15.Text, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void B18_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand faiz = new SqlCommand("UPDATE TBLFAIZLER SET ONSEKIZ=" + T18.Text, connection);
                faiz.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(" Vade 18 Oranı Başarıyla Güncellendi \n Yeni Oran \n " + T18.Text, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void B24_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand faiz = new SqlCommand("UPDATE TBLFAIZLER SET YIRMIDORT=" + T24.Text, connection);
                faiz.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(" Vade 24 Oranı Başarıyla Güncellendi \n Yeni Oran \n " + T24.Text, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
        }

        private void B36_Click(object sender, EventArgs e)
        {
            try
            {
                connection.Open();
                SqlCommand faiz = new SqlCommand("UPDATE TBLFAIZLER SET OTUZALTI=" + T36.Text, connection);
                faiz.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(" Vade 36 Oranı Başarıyla Güncellendi \n Yeni Oran \n " + T36.Text, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
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
            DepartmanGetir();
            YetkiGetir();
        }
    }
}
