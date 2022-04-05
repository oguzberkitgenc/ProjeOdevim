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
    public partial class FEmployee : Form
    {
        public FEmployee()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");

        void DepartmanList()
        {
            SqlCommand command = new SqlCommand("Select * From TBLDEPARTMAN", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbDep.ValueMember = "ID";
            CmbDep.DisplayMember = "DEPARTMAN";
            CmbDep.DataSource = dt;
        }
        void MagazaList()
        {
            SqlCommand command = new SqlCommand("Select ID,MAGAZA From TBLMAGAZA", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbMagaza.ValueMember = "ID";
            CmbMagaza.DisplayMember = "MAGAZA";
            CmbMagaza.DataSource = dt;
        }
        void IlList()
        {
            SqlCommand command = new SqlCommand("Select * From ILLER", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbIl.ValueMember = "ID";
            CmbIl.DisplayMember = "SEHIR";
            CmbIl.DataSource = dt;
        }
        void EmployeeList()
        {
            connection.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select TBLPERSONEL.ID,TC AS 'TC NO',DEPARTMAN,MAGAZA as 'MAĞAZA' ," +
                "AD AS 'AD',SOYAD AS 'SOYAD',TEL AS 'TELEFON',CINSIYETAD AS 'CİNSİYET',DTARIH AS 'DOĞUM TARİHİ',TBLPERSONEL.IL AS 'İL'," +
                "TBLPERSONEL.ILCE AS 'İLÇE', TBLPERSONEL.ADRES,FOTO FROM TBLPERSONEL INNER JOIN TBLDEPARTMAN ON TBLPERSONEL.DEPARTMANID=TBLDEPARTMAN.ID " +
                "INNER JOIN TBLMAGAZA ON TBLPERSONEL.MAGAZAID=TBLMAGAZA.ID INNER JOIN TBLCINSIYET ON TBLPERSONEL.CINSIYET=TBLCINSIYET.ID " +
                "order by DEPARTMANID asc", connection);
            da.Fill(dataTable);
            gridControl1.DataSource = dataTable;
            connection.Close();

        }
        void CinsiyetGetir()
        {
            SqlCommand command = new SqlCommand("Select * From TBLCINSIYET", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbGender.ValueMember = "ID";
            CmbGender.DisplayMember = "CINSIYETAD";
            CmbGender.DataSource = dt;
        }
        void Clear()
        {
            TId.Text = "";
            MskTc.Text = "";
            CmbDep.Text = "";
            CmbMagaza.Text = "";
            TName.Text = "";
            TSurname.Text = "";
            CmbGender.Text = "";
            MskPhone.Text = "";
            MskBirth.Text = "";
            CmbIl.Text = "";
            CmbIlce.Text = "";
            RchAdres.Text = "";
            TUser.Text = "";
            TPass.Text = "";
            TPicture.Text = "";
            pictureBox1.ImageLocation = "";
        }
        private void FEmployee_Load(object sender, EventArgs e)
        {
            EmployeeList();
            DepartmanList();
            MagazaList();
            CinsiyetGetir();
            IlList();
            Clear();
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[12].Visible = false;
        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            connection.Open();
            CmbIlce.Items.Clear();
            SqlCommand sqlCommand = new SqlCommand("Select ILCE From ILCELER where SEHIR=@p1", connection);
            sqlCommand.Parameters.AddWithValue("@p1", CmbIl.SelectedIndex + 1);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                CmbIlce.Items.Add(dr[0]);
            }
            connection.Close();
        }
        bool durum;
        void UserMukkerrerNo()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("SELECT KADI FROM TBLPERSONEL WHERE KADI=@P1", connection);
            command.Parameters.AddWithValue("@P1", TUser.Text);
            SqlDataReader dr = command.ExecuteReader();
            if (dr.Read())
            {
                durum = false;
            }
            else
            {
                durum = true;
            }
            connection.Close();
        }
        private void BSave_Click(object sender, EventArgs e)
        {
            UserMukkerrerNo();
            if (durum == true)
            {
                if (TId.Text == "" & MskTc.Text != "" & TName.Text != "" & TSurname.Text != "" & CmbGender.Text != "" &
               MskBirth.Text != "" & CmbIl.Text != "" & CmbIlce.Text != "" & RchAdres.Text != "" & CmbDep.Text != "" & CmbMagaza.Text != "" &
               MskPhone.Text != "" & TPicture.Text != "" & TUser.Text != "" & TPass.Text != "")
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("insert into TBLPERSONEL (TC,AD,SOYAD,CINSIYET,DTARIH,IL,ILCE,ADRES,DEPARTMANID,MAGAZAID,TEL,FOTO,KADI,SIFRE,PUAN) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13,@p14,@p15)", connection);
                    command.Parameters.AddWithValue("@p1", MskTc.Text);
                    command.Parameters.AddWithValue("@p2", TName.Text);
                    command.Parameters.AddWithValue("@p3", TSurname.Text);
                    command.Parameters.AddWithValue("@p4", CmbGender.SelectedValue);
                    command.Parameters.AddWithValue("@p5", MskBirth.Text);
                    command.Parameters.AddWithValue("@p6", CmbIl.Text);
                    command.Parameters.AddWithValue("@p7", CmbIlce.Text);
                    command.Parameters.AddWithValue("@p8", RchAdres.Text);
                    command.Parameters.AddWithValue("@p9", CmbDep.SelectedValue);
                    command.Parameters.AddWithValue("@p10", CmbMagaza.SelectedValue);
                    command.Parameters.AddWithValue("@p11", MskPhone.Text);
                    command.Parameters.AddWithValue("@p12", TPicture.Text);
                    command.Parameters.AddWithValue("@p13", TUser.Text);
                    command.Parameters.AddWithValue("@p14", TPass.Text);
                    command.Parameters.AddWithValue("@p15", 0);
                    command.ExecuteNonQuery();
                    connection.Close();
                    EmployeeList();
                    MessageBox.Show(" Yeni Takım Arkadaşımız Sisteme Başarıyla Kayıt Edildi \n\n Hoşgeldin " + TName.Text +
                        "\n\n Görevin: " + CmbDep.Text +
                          "\n\n Kullanıcı Adın: " + TUser.Text + "\n\n" + " Şifren: " + TPass.Text
                         , "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Clear();
                }
                else
                {
                    MessageBox.Show(" Eksik Bilgi Girişi. \n Lütfen Eksik Yerleri Doldurunuz ve Tekrar Deneyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            else
            {
                MessageBox.Show(" Bu Kullanıcı Veri Tabanında Kayıtlı. \n Lütfen Farklı Kullanıcı Adı İle Tekrar Deneyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        private void BClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        string picture;
        private void TPicture_Properties_DoubleClick(object sender, EventArgs e)
        {
            openFileDialog1.ShowDialog();
            picture = openFileDialog1.FileName;
            TPicture.Text = picture;
            pictureBox1.ImageLocation = picture;
        }

        private void BUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (TId.Text != "")
                {
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Update TBLPERSONEL set TC=@T1,DEPARTMANID=@T2,MAGAZAID=@T3,AD=@T4,SOYAD=@T5," +
                        "CINSIYET=@T6,TEL=@T7,DTARIH=@T8,IL=@T9,ILCE=@T10,ADRES=@T11,FOTO=@T12 WHERE ID=@T13", connection);
                    cmd.Parameters.AddWithValue("@T1", MskTc.Text);
                    cmd.Parameters.AddWithValue("@T2", CmbDep.SelectedValue);
                    cmd.Parameters.AddWithValue("@T3", CmbMagaza.SelectedValue);
                    cmd.Parameters.AddWithValue("@T4", TName.Text);
                    cmd.Parameters.AddWithValue("@T5", TSurname.Text);
                    cmd.Parameters.AddWithValue("@T6", CmbGender.SelectedValue);
                    cmd.Parameters.AddWithValue("@T7", MskPhone.Text);
                    cmd.Parameters.AddWithValue("@T8", MskBirth.Text);
                    cmd.Parameters.AddWithValue("@T9", CmbIl.Text);
                    cmd.Parameters.AddWithValue("@T10", CmbIlce.Text);
                    cmd.Parameters.AddWithValue("@T11", RchAdres.Text);
                    cmd.Parameters.AddWithValue("@T12", TPicture.Text);
                    cmd.Parameters.AddWithValue("@T13", TId.Text);
                    cmd.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("  Personel Başarıyla Güncellendi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EmployeeList();
                    Clear();
                }
                else
                {
                    MessageBox.Show(" Lütfen Güncellemek İstediğiniz Personeli Seçin ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
                }
            }
            catch (Exception)
            {

                throw;
            }

        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TId.Text = dr["ID"].ToString();
            MskTc.Text = dr["TC NO"].ToString();
            CmbDep.Text = dr["DEPARTMAN"].ToString();
            CmbMagaza.Text = dr["MAĞAZA"].ToString();
            TName.Text = dr["AD"].ToString();
            TSurname.Text = dr["SOYAD"].ToString();
            CmbGender.Text = dr["CİNSİYET"].ToString();
            MskPhone.Text = dr["TELEFON"].ToString();
            MskBirth.Text = dr["DOĞUM TARİHİ"].ToString();
            CmbIl.Text = dr["İL"].ToString();
            CmbIlce.Text = dr["İLÇE"].ToString();
            RchAdres.Text = dr["ADRES"].ToString();
            TPicture.Text = dr["FOTO"].ToString();
            pictureBox1.ImageLocation = TPicture.Text;
        }
    }
}
