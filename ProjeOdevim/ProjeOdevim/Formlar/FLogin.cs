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
using System.Management;

namespace ProjeOdevim.Formlar
{
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }
        private BaglantiSinif bgl = new BaglantiSinif();

        private void BExit_Click(object sender, EventArgs e)
        {
            if (TPass.Text=="AYARLARA GİREMİYORUM")
            {
                DialogResult secenek =  MessageBox.Show("Bütün Kullanıcılara Ayarlara Girme Yetkisi Verilecek Onaylıyor musun?","UYARI",MessageBoxButtons.YesNo,MessageBoxIcon.Warning);
                if (secenek==DialogResult.Yes)
                {
                    SqlConnection connection = new SqlConnection(bgl.Adres);
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("UPDATE TBLDEPARTMAN SET AYARLAR=1", connection);
                    cmd.ExecuteNonQuery();
                    MessageBox.Show("Bütün Kullanıcılara 'Ayarlar' yetkisi verildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    connection.Close();
                }
                
            }
            else
            {
                Application.Exit();
            }
            
        }
        string adsoy, depart, lic = "";
        bool durum;
        private void FLogin_Load(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);

            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT XLIC FROM TBLXML", connection);
            SqlDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                lic = dr[0].ToString();
            }
            connection.Close();
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);

            if (lic != "")
            {
                FrmHomePage frm = new FrmHomePage();
                connection.Open();
                SqlCommand command = new SqlCommand("Select ID,KADI,SIFRE,AD,DEPARTMANID FROM TBLPERSONEL WHERE KADI=@P1 AND SIFRE=@P2", connection);
                command.Parameters.AddWithValue("@P1", TUser.Text);
                command.Parameters.AddWithValue("@P2", TPass.Text);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    frm.LName.Text = reader["AD"].ToString();
                    frm.departman = int.Parse(reader["DEPARTMANID"].ToString());
                    depart = Convert.ToString(reader["DEPARTMANID"].ToString());
                    adsoy = reader["AD"].ToString();
                    frm.LId.Text = reader["ID"].ToString();
                    durum = true;
                }
                else
                {
                    MessageBox.Show(" Kullanıcı Adı Veya Şifre Yanlış. \n Lütfen Tekrar Deneyiniz", "HATALI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
                connection.Close();
                if (durum == true)
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Select * FROM TBLDEPARTMAN WHERE ID=" + depart, connection);
                    SqlDataReader dr2 = cmd.ExecuteReader();
                    while (dr2.Read())
                    {
                        frm.BHomeList.Enabled = Convert.ToBoolean(dr2[2]);
                        frm.BSales.Enabled = Convert.ToBoolean(dr2[3]);
                        frm.BKredi.Enabled = Convert.ToBoolean(dr2[4]);
                        frm.BNot.Enabled = Convert.ToBoolean(dr2[5]);
                        frm.BPersonel.Enabled = Convert.ToBoolean(dr2[6]);
                        frm.BMusteri.Enabled = Convert.ToBoolean(dr2[7]);
                        frm.BUrun.Enabled = Convert.ToBoolean(dr2[8]);
                        frm.BMagaza.Enabled = Convert.ToBoolean(dr2[9]);
                        frm.BKategori.Enabled = Convert.ToBoolean(dr2[10]);
                        frm.BDepartman.Enabled = Convert.ToBoolean(dr2[11]);
                        frm.BSaless.Enabled = Convert.ToBoolean(dr2[12]);
                        frm.BBusy.Enabled = Convert.ToBoolean(dr2[13]);
                        frm.BProductSt.Enabled = Convert.ToBoolean(dr2[14]);
                        frm.BTemelAnaliz.Enabled = Convert.ToBoolean(dr2[15]);
                        frm.BCatMark.Enabled = Convert.ToBoolean(dr2[16]);
                        frm.BDaySales.Enabled = Convert.ToBoolean(dr2[17]);
                        frm.BMonthSales.Enabled = Convert.ToBoolean(dr2[18]);
                        frm.BDayComp.Enabled = Convert.ToBoolean(dr2[19]);
                        frm.BMonthComp.Enabled = Convert.ToBoolean(dr2[20]);
                        frm.BSettings.Enabled = Convert.ToBoolean(dr2[21]);
                        frm.BVadeliList.Enabled = Convert.ToBoolean(dr2[22]);
                        frm.BHareket.Enabled= Convert.ToBoolean(dr2[23]);
                        frm.BVadeHesapla.Enabled=Convert.ToBoolean(dr2[24]);
                    }
                }
                connection.Close();

                if (durum == true)
                {
                    DateTime dateTime = DateTime.Now;
                    string dt = dateTime.ToString("MM/dd/yyyy HH:mm:ss");
                    connection.Open();
                    SqlCommand komut = new SqlCommand("insert into TBLKULLANICIHAREKET (KULLANICI,ADSOYAD,DEPART,TARIH) VALUES (@A1,@A2,@A3,@A4)", connection);
                    komut.Parameters.AddWithValue("@A1", TUser.Text);
                    komut.Parameters.AddWithValue("@A2", adsoy.ToString());
                    komut.Parameters.AddWithValue("@a3", depart.ToString());
                    komut.Parameters.AddWithValue("@A4", dt.ToString());
                    komut.ExecuteNonQuery();
                    connection.Close();
                    frm.Show();
                    this.Hide();
                }
            }
            else
            {
                MessageBox.Show("Lisans Hatası");
                FLic lic = new FLic();
                lic.Show();
            }
        }

    }
}
