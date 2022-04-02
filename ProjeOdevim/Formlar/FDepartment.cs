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
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");
        void DepartmentList()
        {
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLDEPARTMAN", connection);
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
                SqlCommand sqlCommand = new SqlCommand("insert into TBLDEPARTMAN (DEPARTMAN) values (@p1)", connection);
                sqlCommand.Parameters.AddWithValue("@p1", TName.Text);
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
