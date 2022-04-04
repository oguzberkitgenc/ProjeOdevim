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
    public partial class FSales : Form
    {
        public FSales()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");
        void ProductList()
        {
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select TBLURUN.ID,KATEGORIADI AS 'KATEGORİ',MARKAADI AS 'MARKA',URUNADI AS 'ÜRÜN',ALISFIYAT AS 'ALIŞ FİYATI'," +
                "SATISFIYAT AS 'SATIŞ FİYATI', STOK AS 'STOK',ACIKLAMA AS 'AÇIKLAMA' FROM TBLURUN INNER JOIN TBLKATEGORI ON " +
                "TBLURUN.KATEGORIID=TBLKATEGORI.ID INNER JOIN TBLMARKA ON TBLURUN.MARKAID=TBLMARKA.ID order by TBLURUN.ID DESC", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
            gridView1.Columns[4].Visible = false;
            gridView1.Columns[6].Visible = false;

            gridView1.Columns[0].Width = 1;
            gridView1.Columns[1].Width = 70;
            gridView1.Columns[2].Width = 35;
            gridView1.Columns[3].Width = 100;
            gridView1.Columns[5].Width = 45;
            gridView1.Columns[7].Width = 150;
        }
        private void FSales_Load(object sender, EventArgs e)
        {
            ProductList();
        }
    }
}
