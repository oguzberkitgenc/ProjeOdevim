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
    public partial class FHomeList : Form
    {
        public FHomeList()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");

        void DecliningStok()
        {
            connection.Open();
            SqlDataAdapter adapter = new SqlDataAdapter("Select TOP 10 TBLURUN.ID,MARKAADI AS 'MARKA',URUNADI AS 'ÜRÜN ADI'," +
                "SATISFIYAT AS 'SATIŞ FİYATI',STOK,ACIKLAMA AS 'AÇIKLAMA' From TBLURUN INNER JOIN TBLMARKA ON " +
                "TBLURUN.MARKAID=TBLMARKA.ID ORDER BY STOK ASC ",connection);
            connection.Close();
            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);
            gridControl1.DataSource = dataTable;
        }
        private void FHomeList_Load(object sender, EventArgs e)
        {
            DecliningStok();
        }
    }
}
