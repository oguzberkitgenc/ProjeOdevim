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
    public partial class FSales : Form
    {
        public FSales()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");
        DataTable dt1 = new DataTable();
        void Product2()
        {
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select TBLURUN.ID,KATEGORIADI AS 'KATEGORİ',MARKAADI AS 'MARKA',URUNADI AS 'ÜRÜN',ALISFIYAT AS 'ALIŞ FİYATI'," +
                "SATISFIYAT AS 'SATIŞ FİYATI', STOK AS 'STOK',ACIKLAMA AS 'AÇIKLAMA' FROM TBLURUN INNER JOIN TBLKATEGORI ON " +
                "TBLURUN.KATEGORIID=TBLKATEGORI.ID INNER JOIN TBLMARKA ON TBLURUN.MARKAID=TBLMARKA.ID order by TBLURUN.ID DESC", connection);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
        }
        void ProductList()
        {
            Product2();
            gridView1.Columns[4].Visible = false;
            gridView1.Columns[6].Visible = false;
            gridView1.Columns[0].Width = 1;
            gridView1.Columns[1].Width = 70;
            gridView1.Columns[2].Width = 35;
            gridView1.Columns[3].Width = 100;
            gridView1.Columns[5].Width = 45;
            gridView1.Columns[7].Width = 150;


            dt1.Columns.Add(new DataColumn("ID", typeof(int)));
            dt1.Columns.Add(new DataColumn("KATEGORI", typeof(string)));
            dt1.Columns.Add(new DataColumn("MARKA", typeof(string)));
            dt1.Columns.Add(new DataColumn("ÜRÜN ADI", typeof(string)));
            dt1.Columns.Add(new DataColumn("ALIŞ FİYATI", typeof(double)));
            dt1.Columns.Add(new DataColumn("SATIŞ FİYATI", typeof(double)));
        }
        void CustomerList()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select ID,AD From TBLMUSTERI", connection);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbCustomer.ValueMember = "ID";
            CmbCustomer.DisplayMember = "AD";
            CmbCustomer.DataSource = dt;
            connection.Close();
        }
        private void FSales_Load(object sender, EventArgs e)
        {
            ProductList();
            CustomerList();
            Total.Focus();

        }
        double hesapla = 0;
        double grd2fiyatal;

        private void simpleButton1_Click(object sender, EventArgs e)
        {
            DataRow dr1 = dt1.NewRow();
            dr1["ID"] = LId.Text;
            dr1["KATEGORI"] = Convert.ToString(LKategori.Text);
            dr1["MARKA"] = Convert.ToString(LMarka.Text);
            dr1["ÜRÜN ADI"] = Convert.ToString(LUrun.Text);
            dr1["ALIŞ FİYATI"] = double.Parse(LAlis.Text);
            dr1["SATIŞ FİYATI"] = double.Parse(LSatis.Text);
            dt1.Rows.Add(dr1);
            gridControl2.DataSource = dt1;

            gridView2.Columns[0].Width = 5;
            gridView2.Columns[1].Visible = false;
            gridView2.Columns[4].Visible = false;

            double fiyatal = Convert.ToDouble(LSatis.Text);

            hesapla += fiyatal;
            Total.Text = hesapla.ToString("C2");
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {

            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            LId.Text = dr["ID"].ToString();
            LKategori.Text = dr["KATEGORİ"].ToString();
            LMarka.Text = dr["MARKA"].ToString();
            LAlis.Text = dr["ALIŞ FİYATI"].ToString();
            LSatis.Text = dr["SATIŞ FİYATI"].ToString();
            LUrun.Text = dr["ÜRÜN"].ToString();

        }

        private void BClear_Click(object sender, EventArgs e)
        {
            dt1.Rows.Clear();
            hesapla = 0;
            LblTest.Text = "0";
            Total.Text = hesapla.ToString("C2");
            LIndirimTutari.Visible = true;
            LIndirimTutari.Text = Convert.ToString("");
            Rch.Text = "";
            Product2();
        }

        private void BDelete_Click(object sender, EventArgs e)
        {
            if (LblTest.Text != "0" || gridView2.RowCount == 1)
            {
                if (gridView2.RowCount >= 2)
                {
                    hesapla = hesapla - grd2fiyatal;
                    Total.Text = hesapla.ToString("C2");
                    gridView2.DeleteSelectedRows();
                    grd2fiyatal = 0;
                    LblTest.Text = "0";
                    gridView2.GetDataRow(gridView2.FocusedRowHandle = 0);
                }
                else if (gridView2.RowCount == 1)
                {
                    dt1.Rows.Clear();
                    hesapla = 0;
                    Total.Text = hesapla.ToString("C2");
                    gridView2.GetDataRow(gridView2.FocusedRowHandle = 0);
                }
            }
        }
        private void gridView2_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            if (gridView2.RowCount >= 1)
            {
                DataRow dr = gridView2.GetDataRow(gridView2.FocusedRowHandle);
                grd2fiyatal = Convert.ToDouble(dr["SATIŞ FİYATI"]);
                LblTest.Text = dr["SATIŞ FİYATI"].ToString();
            }

        }

        private void B3_Click(object sender, EventArgs e)
        {

            if (Total.Text != "0,00")
            {
                Total.Text = hesapla.ToString();
                double indirim = (hesapla / 100) * 3;
                LIndirimTutari.Visible = true;
                LIndirimTutari.Text = Convert.ToString("İndirim Tutarı: " + "₺" + indirim);
                hesapla = hesapla - indirim;
                Total.Text = hesapla.ToString("C2");
            }
        }

        private void B5_Click(object sender, EventArgs e)
        {
            if (Total.Text != "0,00")
            {
                Total.Text = hesapla.ToString();
                double indirim = (hesapla / 100) * 5;
                LIndirimTutari.Visible = true;
                LIndirimTutari.Text = Convert.ToString("İndirim Tutarı: " + "₺" + indirim);
                hesapla = hesapla - indirim;
                Total.Text = hesapla.ToString("C2");
            }
        }

        private void B15_Click(object sender, EventArgs e)
        {
            if (Total.Text != "0,00")
            {
                Total.Text = hesapla.ToString();
                double indirim = (hesapla / 100) * 15;
                LIndirimTutari.Visible = true;
                LIndirimTutari.Text = Convert.ToString("İndirim Tutarı: " + "₺" + indirim);
                hesapla = hesapla - indirim;
                Total.Text = hesapla.ToString("C2");
            }
        }

        private void BSinirsiz_Click(object sender, EventArgs e)
        {
            try
            {
                if (TYuzdeGir.Text != "0" && TYuzdeGir.Text != "")
                {
                    int yuzde = int.Parse(TYuzdeGir.Text);
                    if (Total.Text != "0,00")
                    {
                        Total.Text = hesapla.ToString();
                        double indirim = (hesapla / 100) * yuzde;
                        LIndirimTutari.Visible = true;
                        LIndirimTutari.Text = Convert.ToString("İndirim Tutarı: " + "₺" + indirim);
                        hesapla = hesapla - indirim;
                        Total.Text = hesapla.ToString("C2");
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
        private void BSearch_Click(object sender, EventArgs e)
        {
            if (Rch.Text != "")
            {
                connection.Open();
                SqlCommand sqlCommand = new SqlCommand("Select TBLURUN.ID,KATEGORIADI AS 'KATEGORİ',MARKAADI AS 'MARKA',URUNADI AS 'ÜRÜN'," +
                    "ALISFIYAT AS 'ALIŞ FİYATI', SATISFIYAT AS 'SATIŞ FİYATI', STOK AS 'STOK',ACIKLAMA AS 'AÇIKLAMA' FROM TBLURUN INNER JOIN TBLKATEGORI  " +
                    "ON TBLURUN.KATEGORIID=TBLKATEGORI.ID INNER JOIN TBLMARKA ON TBLURUN.MARKAID=TBLMARKA.ID WHERE URUNADI like '%" + Rch.Text + "%' " +
                    "OR ACIKLAMA like '%" + Rch.Text + " %' order by TBLURUN.ID DESC ", connection);
                SqlDataAdapter da3 = new SqlDataAdapter(sqlCommand);
                DataTable dt3 = new DataTable();
                da3.Fill(dt3);
                gridControl1.DataSource = dt3;
                connection.Close();
                Rch.Text = "";
            }
            else if (Rch.Text == "")
            {
                Product2();
            }

        }
    }
}
