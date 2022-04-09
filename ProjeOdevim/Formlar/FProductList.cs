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
using DevExpress.XtraGrid.Views.Grid;

namespace ProjeOdevim.Formlar
{
    public partial class FProductList : Form
    {
        public FProductList()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");
        void CategoryName()
        {
            // Combobax Kategori Getir
            SqlCommand command = new SqlCommand("Select * From TBLKATEGORI ORDER BY KATEGORIADI DESC ", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbCategory.ValueMember = "ID";
            CmbCategory.DisplayMember = "KATEGORIADI";
            CmbCategory.DataSource = dt;
        }

        void MarkaName()
        {
            // Combobax Marka Getir
            SqlCommand command = new SqlCommand("Select * From TBLMARKA ORDER BY MARKAADI DESC ", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbMarka.ValueMember = "ID";
            CmbMarka.DisplayMember = "MARKAADI";
            CmbMarka.DataSource = dt;
        }
        void ProductList()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select TBLURUN.ID,KATEGORIADI AS 'KATEGORİ',MARKAADI AS 'MARKA',URUNADI AS 'ÜRÜN',ALISFIYAT AS 'ALIŞ FİYATI'," +
                "SATISFIYAT AS 'SATIŞ FİYATI', STOK AS 'STOK',ACIKLAMA AS 'AÇIKLAMA' FROM TBLURUN INNER JOIN TBLKATEGORI ON T" +
                "BLURUN.KATEGORIID=TBLKATEGORI.ID INNER JOIN TBLMARKA ON TBLURUN.MARKAID=TBLMARKA.ID order by KATEGORIID asc", connection);
            da.Fill(dt);
            gridControl1.DataSource = dt;
        }
        void Clear()
        {
            TId.Text = "";
            CmbCategory.Text = "";
            CmbMarka.Text = "";
            TProductName.Text = "";
            TBuying.Text = "";
            TSales.Text = "";
            NStock.Text = "";
            richTextBox1.Text = "";
        }
        int kritik = 0;

        private void FProductList_Load(object sender, EventArgs e)
        {
            ProductList();
            CategoryName();
            MarkaName();
            Clear();
            gridView1.Columns[0].Visible = false;

            connection.Open();
            SqlCommand komut = new SqlCommand("Select ID,KRITIK From TBLXML",connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                kritik = Convert.ToInt32(dr[1]);
            }
            connection.Close();
        }
        private void gridView1_RowCellStyle(object sender, DevExpress.XtraGrid.Views.Grid.RowCellStyleEventArgs e)
        {
            GridView view = sender as GridView;
            int miktar = Convert.ToInt32(view.GetRowCellValue(e.RowHandle, "STOK"));
            if (miktar >= 1 & miktar <= kritik)
            {
                e.Appearance.BackColor = Color.FromArgb(255, 118, 117);
                e.Appearance.BackColor2 = Color.FromArgb(45, 52, 54);
            }
            else if (miktar == 0)
            {
                e.Appearance.BackColor = Color.FromArgb(129, 236, 236);
                e.Appearance.BackColor2 = Color.FromArgb(99, 110, 114);
                e.Appearance.ForeColor = Color.Black;
            }
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TId.Text = dr["ID"].ToString();
            CmbCategory.Text = dr["KATEGORİ"].ToString();
            CmbMarka.Text = dr["MARKA"].ToString();
            TProductName.Text = dr["ÜRÜN"].ToString();
            TBuying.Text = dr["ALIŞ FİYATI"].ToString();
            TSales.Text = dr["SATIŞ FİYATI"].ToString();
            NStock.Value = Convert.ToInt32(dr["STOK"].ToString());
            richTextBox1.Text = dr["AÇIKLAMA"].ToString();
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (CmbCategory.Text != "" & CmbMarka.Text != "" & TProductName.Text != "" & TBuying.Text != "" & TSales.Text != "" & NStock.Value >= 0 & TId.Text == "")
                {
                    connection.Open();
                    SqlCommand command = new SqlCommand("insert into TBLURUN (KATEGORIID,MARKAID,URUNADI,ALISFIYAT,SATISFIYAT,STOK,ACIKLAMA)" +
                        "  values (@p1,@p2,@p3,@p4,@p5,@p6,@p7)", connection);
                    command.Parameters.AddWithValue("@p1", CmbCategory.SelectedValue);
                    command.Parameters.AddWithValue("@p2", CmbMarka.SelectedValue);
                    command.Parameters.AddWithValue("@p3", TProductName.Text);
                    command.Parameters.AddWithValue("@p4", Decimal.Parse(TBuying.Text));
                    command.Parameters.AddWithValue("@p5", Decimal.Parse(TSales.Text));
                    command.Parameters.AddWithValue("@p6", int.Parse(NStock.Value.ToString()));
                    command.Parameters.AddWithValue("@p7", richTextBox1.Text);
                    command.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show("Ürün Sisteme Başarıyla Kayıt Edildi", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    ProductList();
                    Clear();
                }
                else
                {
                    MessageBox.Show(" Boş Bırakılan Alanlar Var Ya da 'ID' Alanı Dolu. \n Bu Şekilde İşlemlere Devam Edemezsiniz. \n " +
                        " Lütfen Bilgileri Kontrol Edip Tekrar Deneyiniz.", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
           
        }

        private void BUpdate_Click(object sender, EventArgs e)
        {
            if (TId.Text != "")
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Update TBLURUN set KATEGORIID=@P1,MARKAID=@P2,URUNADI=@P3,ALISFIYAT=@P4,SATISFIYAT=@P5,STOK=@P6,ACIKLAMA=@P7 " +
                    "WHERE ID=@P8", connection);
                sqlCommand.Parameters.AddWithValue("@P1", CmbCategory.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@P2", CmbMarka.SelectedValue);
                sqlCommand.Parameters.AddWithValue("@P3", TProductName.Text);
                sqlCommand.Parameters.AddWithValue("@P4", Decimal.Parse(TBuying.Text));
                sqlCommand.Parameters.AddWithValue("@P5", Decimal.Parse(TSales.Text));
                sqlCommand.Parameters.AddWithValue("@P6", int.Parse(NStock.Value.ToString()));
                sqlCommand.Parameters.AddWithValue("@P7", richTextBox1.Text);
                sqlCommand.Parameters.AddWithValue("@P8", TId.Text);
                sqlCommand.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("  Ürün Başarıyla Güncellendi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                ProductList();
                Clear();
            }
            else
            {
                MessageBox.Show(" Lütfen Güncellemek İstediğiniz Ürünü Seçin ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
        }

        private void BClear_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
