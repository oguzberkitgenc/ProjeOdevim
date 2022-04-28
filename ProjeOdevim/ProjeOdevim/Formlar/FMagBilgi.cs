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
    public partial class FMagBilgi : Form
    {
        public FMagBilgi()
        {
            InitializeComponent();
        }
        BaglantiSinif bgl = new BaglantiSinif();
        void Listele()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT * FROM TBLMAGAZA", connection);
            SqlDataReader sqlDataReader = komut.ExecuteReader();
            while (sqlDataReader.Read())
            {
                TUnvan.Text = sqlDataReader[1].ToString();
                CmbIl.Text = sqlDataReader[2].ToString();
                CmbIlce.Text = sqlDataReader[3].ToString();
                TAdres.Text = sqlDataReader[4].ToString();
                MskTel1.Text = sqlDataReader[5].ToString();
                MskTel2.Text = sqlDataReader[6].ToString();
                TMail.Text = sqlDataReader[7].ToString();
                TWeb.Text = sqlDataReader[8].ToString();
                TLogo.Text = sqlDataReader[9].ToString();
                TTicariUnvan.Text = sqlDataReader[10].ToString();
                MskFax.Text = sqlDataReader[11].ToString();
                TVergiD.Text=sqlDataReader[12].ToString();
                TVergiN.Text=sqlDataReader[13].ToString();
                TTicaretNo.Text=sqlDataReader[14].ToString();
                TMersisNo.Text=sqlDataReader[15].ToString();
                Mskisbank.Text=sqlDataReader[16].ToString();
                MskGaranti.Text=sqlDataReader[17].ToString();
                MskYapi.Text=sqlDataReader[18].ToString();
                MskAkbank.Text=sqlDataReader[19].ToString();
                MskFinans.Text=sqlDataReader[20].ToString();
                MskZiraat.Text=sqlDataReader[21].ToString();
                MskHalk.Text=sqlDataReader[22].ToString();

            }
            connection.Close();
        }
        void IlGetir()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ILLER", connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbIl.ValueMember = "ID";
            CmbIl.DisplayMember = "SEHIR";
            CmbIl.DataSource = dt;
            connection.Close();
        }

        private void FMagBilgi_Load(object sender, EventArgs e)
        {
            IlGetir();
            Listele();
        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            SqlCommand cmd = new SqlCommand("SELECT * FROM ILCELER WHERE SEHIR=" + CmbIl.SelectedValue, connection);
            SqlDataAdapter da = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbIlce.ValueMember = "ID";
            CmbIlce.DisplayMember = "ILCE";
            CmbIlce.DataSource = dt;
            connection.Close();
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            DialogResult secenek = MessageBox.Show("Yeni Mağaza Bilgileri Kayıt Edilecek. \nOnaylıyor musun?", "BİLGİ", MessageBoxButtons.YesNo, MessageBoxIcon.Stop);
            if (secenek == DialogResult.Yes)
            {
                SqlConnection connection = new SqlConnection(bgl.Adres);
                connection.Open();
                SqlCommand komut = new SqlCommand("UPDATE TBLMAGAZA SET UNVAN=@P1,IL=@P2,ILCE=@P3," +
                    "ADRES=@P4,TEL1=@P5,TEL2=@P6,MAIL=@P7,WEB=@P8,LOGO=@P9,TICARIUNVAN=@P10,FAX=@P11," +
                    "VERGIDAIRESI=@P12,VERGINO=@P13,TICARETNO=@P14,MERSISNO=@P15,ISBANK=@P16," +
                    "GARANTI=@P17,YAPI=@P18,AKBANK=@P19,FINANS=@P20,ZIRAAT=@P21,HALK=@P22", connection);
                komut.Parameters.AddWithValue("@P1", TUnvan.Text);
                komut.Parameters.AddWithValue("@P2", CmbIl.Text);
                komut.Parameters.AddWithValue("@P3", CmbIlce.Text);
                komut.Parameters.AddWithValue("@P4", TAdres.Text);
                komut.Parameters.AddWithValue("@P5", MskTel1.Text);
                komut.Parameters.AddWithValue("@P6", MskTel2.Text);
                komut.Parameters.AddWithValue("@P7", TMail.Text);
                komut.Parameters.AddWithValue("@P8", TWeb.Text);
                komut.Parameters.AddWithValue("@P9", TLogo.Text);
                komut.Parameters.AddWithValue("@P10", TTicariUnvan.Text);
                komut.Parameters.AddWithValue("@P11", MskFax.Text);
                komut.Parameters.AddWithValue("@P12", TVergiD.Text);
                komut.Parameters.AddWithValue("@P13", TVergiN.Text);
                komut.Parameters.AddWithValue("@P14", TTicaretNo.Text);
                komut.Parameters.AddWithValue("@P15", TMersisNo.Text);
                komut.Parameters.AddWithValue("@P16", Mskisbank.Text);
                komut.Parameters.AddWithValue("@P17", MskGaranti.Text);
                komut.Parameters.AddWithValue("@P18", MskYapi.Text);
                komut.Parameters.AddWithValue("@P19", MskAkbank.Text);
                komut.Parameters.AddWithValue("@P20", MskFinans.Text);
                komut.Parameters.AddWithValue("@P21", MskZiraat.Text);
                komut.Parameters.AddWithValue("@P22", MskHalk.Text);

                komut.ExecuteNonQuery();
                MessageBox.Show("Mağaza Bilgileri Başarıyla Kayıt Edildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                connection.Close();
            }
            else
            {
                MessageBox.Show("İşlem İptal Edildi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
            Listele();

        }

        private void TLogo_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.ShowDialog();
            TLogo.Text= ofd.FileName;
        }
    }
}