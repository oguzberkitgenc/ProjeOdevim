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
    public partial class FCategory : Form
    {
        public FCategory()
        {
            InitializeComponent();
        }
        BaglantiSinif bgl = new BaglantiSinif();
        void CategoryList()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open();
            DataTable dataTable = new DataTable();
            SqlDataAdapter sqlDataAdapter = new SqlDataAdapter("Select * From TBLKATEGORI ORDER BY KATEGORIADI ASC ", connection);
            sqlDataAdapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
            connection.Close();
        }
        void MarkaList()
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            connection.Open ();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLMARKA ORDER BY MARKAADI ASC ", connection);
            da.Fill (dt);
            gridControl2.DataSource = dt;
            connection.Close();
        }
        void Clear()
        {
            TId.Text = "";
            TName.Text = "";
            TId2.Text = "";
            TName2.Text = "";
        }
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TId.Text = dr["ID"].ToString();
            TName.Text = dr["KATEGORIADI"].ToString();
        }

        private void FCategory_Load(object sender, EventArgs e)
        {
            CategoryList();
            MarkaList();
            Clear();
            gridView1.Columns[0].Visible = false;
            gridView2.Columns[0].Visible = false;
        }
        private void BClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
        private void BSave_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            if (TId.Text == "" & TName.Text != "")
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into TBLKATEGORI (KATEGORIADI) values (@p1)", connection);
                sqlCommand.Parameters.AddWithValue("@p1", TName.Text);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Kategori Sisteme Başarıyla Kayıt Edildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CategoryList();
                Clear();
            }
            else
            {
                MessageBox.Show(" Boş Bırakılan Alanlar Var Ya da 'ID' Alanı Dolu. \n Bu Şekilde İşlemlere Devam Edemezsiniz. \n " +
                    " Lütfen Bilgileri Kontrol Edip Tekrar Deneyiniz.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BUpdate_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            if (TId.Text != "" & TName.Text != "")
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("Update TBLKATEGORI set KATEGORIADI=@k1 where ID=@k2", connection);
                sql.Parameters.AddWithValue("@k1",TName.Text);
                sql.Parameters.AddWithValue("@k2",TId.Text);
                sql.ExecuteNonQuery();
                connection.Close ();
                MessageBox.Show("Kategori  Başarıyla Kayıt Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CategoryList();
                Clear();
            }
            else
            {
                MessageBox.Show(" Lütfen Güncellemek İstediğiniz Kategoriyi Seçin ve İsim Alanını Boş Bırakmayın" +
                    " ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
            TId2.Text = dr["ID"].ToString();
            TName2.Text = dr["MARKAADI"].ToString();
        }

        private void BSave2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            if (TId2.Text == "" & TName2.Text != "")
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into TBLMARKA (MARKAADI) values (@p1)", connection);
                sqlCommand.Parameters.AddWithValue("@p1", TName2.Text);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Marka Sisteme Başarıyla Kayıt Edildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MarkaList();
                Clear();
            }
            else
            {
                MessageBox.Show(" Boş Bırakılan Alanlar Var Ya da 'ID' Alanı Dolu. \n Bu Şekilde İşlemlere Devam Edemezsiniz. \n " +
                    " Lütfen Bilgileri Kontrol Edip Tekrar Deneyiniz.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void BUpdate2_Click(object sender, EventArgs e)
        {
            SqlConnection connection = new SqlConnection(bgl.Adres);
            if (TId2.Text != "" & TName2.Text != "")
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("Update TBLMARKA set MARKAADI=@k1 where ID=@k2", connection);
                sql.Parameters.AddWithValue("@k1", TName.Text);
                sql.Parameters.AddWithValue("@k2", TId.Text);
                sql.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("Marka  Başarıyla Kayıt Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                MarkaList();
                Clear();
            }
            else
            {
                MessageBox.Show(" Lütfen Güncellemek İstediğiniz Kategoriyi Seçin ve İsim Alanını Boş Bırakmayın" +
                    " ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }
    }
}
