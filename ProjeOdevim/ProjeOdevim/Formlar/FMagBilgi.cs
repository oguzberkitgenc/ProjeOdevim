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
                    "ADRES=@P4,TEL1=@P5,TEL2=@P6,MAIL=@P7,WEB=@P8,LOGO=@P9", connection);
                komut.Parameters.AddWithValue("@P1", TUnvan.Text);
                komut.Parameters.AddWithValue("@P2", CmbIl.Text);
                komut.Parameters.AddWithValue("@P3", CmbIlce.Text);
                komut.Parameters.AddWithValue("@P4", TAdres.Text);
                komut.Parameters.AddWithValue("@P5", MskTel1.Text);
                komut.Parameters.AddWithValue("@P6", MskTel2.Text);
                komut.Parameters.AddWithValue("@P7", TMail.Text);
                komut.Parameters.AddWithValue("@P8", TWeb.Text);
                komut.Parameters.AddWithValue("@P9", TLogo.Text);
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
    }
}