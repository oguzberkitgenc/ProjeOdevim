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
    public partial class FDepartment : Form
    {
        public FDepartment()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=TicariOtomasyon;Integrated Security=True");


        void DepartmentList()
        {
            
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select ID,DEPARTMAN From TBLDEPARTMAN", connection);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
        }
        void Clear()
        {
            TId.Text = "";
            TName.Text = "";
        }
        private void FDepartment_Load(object sender, EventArgs e)
        {
            DepartmentList();
            Clear();
            gridView1.Columns[0].Visible = false;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        private void BSave_Click(object sender, EventArgs e)
        {
            if (TId.Text == "" & TName.Text != "")
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into TBLDEPARTMAN (DEPARTMAN,ANASAYFA,URUNSATIS," +
                    "KREDISORGULA,DUYURULAR,PERSONELLER,MUSTERILER,URUNLER,MAGAZALAR,KATEGORIEKLE,DEPARTKONTROL," +
                    "CIROVERI,YOGUNLUK,GENELVERI,TEMELISTATISK,KATEGORIMARKA,GUNLUKCIRO,AYLIKCIRO,GUNLUKKARSI," +
                    "AYLIKKARSI,AYARLAR,VADELER,HAREKET,PERSATIS,MUSSATIS,PERANALIZ,MUSANALIZ,VADERAPOR) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7,@p8,@p9,@p10,@p11," +
                    "@p12,@p13,@p14,@p15,@p16,@p17,@p18,@p19,@p20,@p21,@p22,@p23,@p24,@p25,@p26,@p27,@p28)", connection);
                sqlCommand.Parameters.AddWithValue("@p1", TName.Text);
                sqlCommand.Parameters.AddWithValue("@p2", 0);
                sqlCommand.Parameters.AddWithValue("@p3", 0);
                sqlCommand.Parameters.AddWithValue("@p4", 0);
                sqlCommand.Parameters.AddWithValue("@p5", 0);
                sqlCommand.Parameters.AddWithValue("@p6", 0);
                sqlCommand.Parameters.AddWithValue("@p7", 0);
                sqlCommand.Parameters.AddWithValue("@p8", 0);
                sqlCommand.Parameters.AddWithValue("@p9", 0);
                sqlCommand.Parameters.AddWithValue("@p10", 0);
                sqlCommand.Parameters.AddWithValue("@p11", 0);
                sqlCommand.Parameters.AddWithValue("@p12", 0);
                sqlCommand.Parameters.AddWithValue("@p13", 0);
                sqlCommand.Parameters.AddWithValue("@p14", 0);
                sqlCommand.Parameters.AddWithValue("@p15", 0);
                sqlCommand.Parameters.AddWithValue("@p16", 0);
                sqlCommand.Parameters.AddWithValue("@p17", 0);
                sqlCommand.Parameters.AddWithValue("@p18", 0);
                sqlCommand.Parameters.AddWithValue("@p19", 0);
                sqlCommand.Parameters.AddWithValue("@p20", 0);
                sqlCommand.Parameters.AddWithValue("@p21", 0);
                sqlCommand.Parameters.AddWithValue("@p22", 0);
                sqlCommand.Parameters.AddWithValue("@p23", 0);
                sqlCommand.Parameters.AddWithValue("@p24", 0);
                sqlCommand.Parameters.AddWithValue("@p25", 0);
                sqlCommand.Parameters.AddWithValue("@p26", 0);
                sqlCommand.Parameters.AddWithValue("@p27", 0);
                sqlCommand.Parameters.AddWithValue("@p28", 0);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Departman Sisteme Başarıyla Kayıt Edildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DepartmentList();
            }
            else
            {
                MessageBox.Show(" Boş Bırakılan Alanlar Var Ya da 'ID' Alanı Dolu. \n Bu Şekilde İşlemlere Devam Edemezsiniz. \n " +
                    " Lütfen Bilgileri Kontrol Edip Tekrar Deneyiniz.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void BUpdate_Click(object sender, EventArgs e)
        {

            if (TId.Text != "" & TName.Text != "")
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("Update TBLDEPARTMAN set DEPARTMAN=@k1 where ID=@k2", connection);
                sql.Parameters.AddWithValue("@k1", TName.Text);
                sql.Parameters.AddWithValue("@k2", TId.Text);
                sql.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Departman  Başarıyla Kayıt Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                DepartmentList();
                Clear();
            }
            else
            {
                MessageBox.Show(" Lütfen Güncellemek İstediğiniz Departmanı Seçin ve İsim Alanını Boş Bırakmayın" +
                    " ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
        private void BClear_Click(object sender, EventArgs e)
        {
            DepartmentList();
            Clear();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TId.Text = dr["ID"].ToString();
            TName.Text = dr["DEPARTMAN"].ToString();
        }
    }
}
