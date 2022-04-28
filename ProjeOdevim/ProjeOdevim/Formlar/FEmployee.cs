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
        BaglantiSinif bgl = new BaglantiSinif();
        void DepartmanList()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            SqlCommand command = new SqlCommand("Select * From TBLDEPARTMAN", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbDep.ValueMember = "ID";
            CmbDep.DisplayMember = "DEPARTMAN";
            CmbDep.DataSource = dt;
        }

        void IlList()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
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
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select TBLPERSONEL.ID,TC AS 'TC NO',DEPARTMAN," +
                "AD AS 'AD SOYAD',TEL AS 'TELEFON',CINSIYETAD AS 'CİNSİYET',DTARIH AS 'DOĞUM TARİHİ',TBLPERSONEL.IL AS 'İL'," +
                "TBLPERSONEL.ILCE AS 'İLÇE', TBLPERSONEL.ADRES,FOTO FROM TBLPERSONEL INNER JOIN TBLDEPARTMAN ON TBLPERSONEL.DEPARTMANID=TBLDEPARTMAN.ID " +
                "INNER JOIN TBLCINSIYET ON TBLPERSONEL.CINSIYET=TBLCINSIYET.ID " +
                "order by DEPARTMANID asc", connection);
            da.Fill(dataTable);
            gridControl1.DataSource = dataTable;
            connection.Close();
        }
        void CinsiyetGetir()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
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
            TName.Text = "";
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
            CinsiyetGetir();
            IlList();
            Clear();
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[10].Visible = false;
        }
        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
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
            SqlConnection connection = new SqlConnection(bgl.Adres);
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
                if (TId.Text == "" & MskTc.Text != "" & TName.Text != "" & CmbGender.Text != "" &
               MskBirth.Text != "" & CmbIl.Text != "" & CmbIlce.Text != "" & RchAdres.Text != "" & CmbDep.Text != "" &
               MskPhone.Text != "" & TPicture.Text != "" & TUser.Text != "" & TPass.Text != "")
                {
                    SqlConnection connection = new SqlConnection(bgl.Adres);
                    connection.Open();
                    SqlCommand command = new SqlCommand("insert into TBLPERSONEL (TC,AD,CINSIYET,DTARIH,IL,ILCE,ADRES,DEPARTMANID,TEL," +
                        "FOTO,KADI,SIFRE,PUAN) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11,@p12,@p13)", connection);
                    command.Parameters.AddWithValue("@p1", MskTc.Text);
                    command.Parameters.AddWithValue("@p2", TName.Text);
                    command.Parameters.AddWithValue("@p3", CmbGender.SelectedValue);
                    command.Parameters.AddWithValue("@p4", MskBirth.Text);
                    command.Parameters.AddWithValue("@p5", CmbIl.Text);
                    command.Parameters.AddWithValue("@p6", CmbIlce.Text);
                    command.Parameters.AddWithValue("@p7", RchAdres.Text);
                    command.Parameters.AddWithValue("@p8", CmbDep.SelectedValue);
                    command.Parameters.AddWithValue("@p9", MskPhone.Text);
                    command.Parameters.AddWithValue("@p10", TPicture.Text);
                    command.Parameters.AddWithValue("@p11", TUser.Text);
                    command.Parameters.AddWithValue("@p12", TPass.Text);
                    command.Parameters.AddWithValue("@p13", 0);
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
        private void TPicture_Properties_DoubleClick(object sender, EventArgs e)
        {
            OpenFileDialog opf = new OpenFileDialog();
            opf.ShowDialog();
            TPicture.Text = opf.FileName;
        }
        private void BUpdate_Click(object sender, EventArgs e)
        {
            try
            {
                if (TId.Text != "")
                {

                    SqlConnection connection = new SqlConnection(bgl.Adres);
                    connection.Open();
                    SqlCommand cmd = new SqlCommand("Update TBLPERSONEL set TC=@T1,DEPARTMANID=@T2,AD=@T4," +
                        "CINSIYET=@T6,TEL=@T7,DTARIH=@T8,IL=@T9,ILCE=@T10,ADRES=@T11,FOTO=@T12 WHERE ID=@T13", connection);
                    cmd.Parameters.AddWithValue("@T1", MskTc.Text);
                    cmd.Parameters.AddWithValue("@T2", CmbDep.SelectedValue);
                    cmd.Parameters.AddWithValue("@T4", TName.Text);
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
                    UserMukkerrerNo();
                    if (TUser.Text != "" && TPass.Text != "" && durum == true)
                    {
                        connection.Open();
                        SqlCommand pas = new SqlCommand("UPDATE TBLPERSONEL SET KADI=@A1,SIFRE=@A2 WHERE ID=@A3", connection);
                        pas.Parameters.AddWithValue("@A1", TUser.Text);
                        pas.Parameters.AddWithValue("@A2", TPass.Text);
                        pas.Parameters.AddWithValue("@A3", TId.Text);
                        pas.ExecuteNonQuery();
                        connection.Close();
                    }
                    MessageBox.Show("  Personel Başarıyla Güncellendi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    EmployeeList();
                    Clear();

                }
                else if (durum == false)
                {
                    MessageBox.Show("Bu Kullanıcı Adı Sistemde Başka Bir Kullanıcı Tarafından Kullanılmaktadır.! \n Kullanıcı Adı ve Şifre Hariç Diğer Bilgiler Başarıyla Güncellendi.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
            TPicture.Text = dr["FOTO"].ToString();
            TId.Text = dr["ID"].ToString();
            MskTc.Text = dr["TC NO"].ToString();
            CmbDep.Text = dr["DEPARTMAN"].ToString();
            TName.Text = dr["AD SOYAD"].ToString();
            CmbGender.Text = dr["CİNSİYET"].ToString();
            MskPhone.Text = dr["TELEFON"].ToString();
            MskBirth.Text = dr["DOĞUM TARİHİ"].ToString();
            CmbIl.Text = dr["İL"].ToString();
            CmbIlce.Text = dr["İLÇE"].ToString();
            RchAdres.Text = dr["ADRES"].ToString();
            pictureBox1.ImageLocation = TPicture.Text;
        }

        private void BClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
