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
    public partial class FAddShopping : Form
    {
        public FAddShopping()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");
        void ShoppingList()
        {
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLMAGAZA", connection);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
        }
        void Clear()
        {
            TId.Text = "";
            TName.Text = "";
            CmbIl.Text = "";
            CmbIlce.Text = "";
            RchAdres.Text = "";
            pictureBox1.ImageLocation = null;
            pictureBox2.ImageLocation = null;
            pictureBox3.ImageLocation = null;
        }

        void CityList()
        {
            SqlCommand command = new SqlCommand("Select * From ILLER", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbIl.ValueMember = "ID";
            CmbIl.DisplayMember = "SEHIR";
            CmbIl.DataSource = dt;
        }
        private void FAddShopping_Load(object sender, EventArgs e)
        {
            ShoppingList();
            CityList();
            Clear();
            gridView1.Columns[0].Visible = false;
            gridView1.Columns[5].Visible = false;
            gridView1.Columns[6].Visible = false;
            gridView1.Columns[7].Visible = false;
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TId.Text = dr["ID"].ToString();
            TName.Text = dr["MAGAZA"].ToString();
            CmbIl.Text = dr["IL"].ToString();
            CmbIlce.Text = dr["ILCE"].ToString();
            RchAdres.Text = dr["ADRES"].ToString();
            pictureBox1.ImageLocation = dr["FOTO1"].ToString();
            pictureBox2.ImageLocation = dr["FOTO2"].ToString();
            pictureBox3.ImageLocation = dr["FOTO3"].ToString();
        }
        private void BClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            if (TId.Text == "" & TName.Text != "" & CmbIl.Text != "" & CmbIlce.Text != "" & RchAdres.Text != "" & foto1 != null & foto2 != null & foto3 != null)
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("insert into TBLMAGAZA (MAGAZA,IL,ILCE,ADRES,FOTO1,FOTO2,FOTO3) values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", connection);
                sqlCommand.Parameters.AddWithValue("@p1", TName.Text);
                sqlCommand.Parameters.AddWithValue("@p2", CmbIl.Text);
                sqlCommand.Parameters.AddWithValue("@p3", CmbIlce.Text);
                sqlCommand.Parameters.AddWithValue("@p4", RchAdres.Text);
                sqlCommand.Parameters.AddWithValue("@p5", foto1.ToString());
                sqlCommand.Parameters.AddWithValue("@p6", foto2.ToString());
                sqlCommand.Parameters.AddWithValue("@p7", foto3.ToString());
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(" " + TName.Text + "\n Yeni Mağaza Sisteme Başarıyla Kayıt Edildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShoppingList();
                Clear();
            }
            else
            {
                MessageBox.Show(" Eksik Bilgi Girişi. \n Lütfen Eksik Yerleri Doldurunuz ve Tekrar Deneyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }
        string foto1, foto2, foto3;
        private void simpleButton3_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Fotoğraf Dosyası |*.jpeg| Fotoğraf Dosyası|*.jpg| Fotoğraf Dosyası|*.png";
            of.ShowDialog();
            foto3 = of.FileName;
            pictureBox3.ImageLocation = foto3;
        }

        private void simpleButton4_Click(object sender, EventArgs e)
        {
            if (TId.Text != "" & TName.Text != "" & CmbIl.Text != "" & CmbIlce.Text != "" & RchAdres.Text != "" & pictureBox1.ImageLocation != "" & pictureBox2.ImageLocation != "" & pictureBox3.ImageLocation != "")
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("update TBLMAGAZA set MAGAZA=@P1,IL=@P2,ILCE=@P3,ADRES=@P4,FOTO1=@P5,FOTO2=@P6,FOTO3=@P7 " +
                    "where ID=@P8", connection);
                sql.Parameters.AddWithValue("@p1", TName.Text);
                sql.Parameters.AddWithValue("@p2", CmbIl.Text);
                sql.Parameters.AddWithValue("@p3", CmbIlce.Text);
                sql.Parameters.AddWithValue("@p4", RchAdres.Text);
                sql.Parameters.AddWithValue("@p5", pictureBox1.ImageLocation.ToString());
                sql.Parameters.AddWithValue("@p6", pictureBox2.ImageLocation.ToString());
                sql.Parameters.AddWithValue("@p7", pictureBox3.ImageLocation.ToString());
                sql.Parameters.AddWithValue("@p8", TId.Text);
                sql.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(" " + TName.Text + "\n Mağaza  Başarıyla Güncellendi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ShoppingList();
                Clear();
            }
            else
            {
                MessageBox.Show(" Eksik Bilgi Girişi. \n Lütfen Eksik Yerleri Doldurunuz ve Tekrar Deneyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }

        }


        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {
            CmbIlce.Items.Clear();
            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("Select ILCE From ILCELER where SEHIR=@p1", connection);
            sqlCommand.Parameters.AddWithValue("@p1", CmbIl.SelectedIndex + 1);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                CmbIlce.Items.Add(dr[0]);
            }
            connection.Close();
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Fotoğraf Dosyası |*.jpeg| Fotoğraf Dosyası|*.jpg| Fotoğraf Dosyası|*.png";
            of.ShowDialog();
            foto2 = of.FileName;
            pictureBox2.ImageLocation = foto2;
        }

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            OpenFileDialog of = new OpenFileDialog();
            of.Filter = "Fotoğraf Dosyası |*.jpeg| Fotoğraf Dosyası|*.jpg| Fotoğraf Dosyası|*.png";
            of.ShowDialog();
            foto1 = of.FileName;
            pictureBox1.ImageLocation = foto1;
        }
    }
}
