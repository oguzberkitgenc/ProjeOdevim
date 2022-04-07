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
        public string id, kategori, marka, urunadi;
        public decimal alisfiyati = 0, satisfiyatı = 0, indirimorani = 0;
        void Product2()
        {
            connection.Open();
            SqlDataAdapter da = new SqlDataAdapter("Select TBLURUN.ID,KATEGORIADI AS 'KATEGORİ',MARKAADI AS 'MARKA',URUNADI AS 'ÜRÜN',ALISFIYAT AS 'ALIŞ FİYATI'," +
                "SATISFIYAT AS 'SATIŞ FİYATI', STOK AS 'STOK',ACIKLAMA AS 'AÇIKLAMA' FROM TBLURUN INNER JOIN TBLKATEGORI ON " +
                "TBLURUN.KATEGORIID=TBLKATEGORI.ID INNER JOIN TBLMARKA ON TBLURUN.MARKAID=TBLMARKA.ID where STOK>=1 order by TBLURUN.ID DESC", connection);
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
        void IslemNo()
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select * From TBLISLEM", connection);
            SqlDataReader dr = command.ExecuteReader();
            while (dr.Read())
            {
                LIslemNo.Text = dr[0].ToString();
            }
            connection.Close();
            DateTime date = DateTime.Now;
            LTarih.Text = date.ToString("MM/dd/yyyy HH:mm");
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
        void Employee()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select ID,AD From TBLPERSONEL", connection);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbEmploye.ValueMember = "ID";
            CmbEmploye.DisplayMember = "AD";
            CmbEmploye.DataSource = dt;
            connection.Close();
        }
        void PuanAddEmploye()
        {
            hesapla = (hesapla / 1000) * 1;
            connection.Open();
            SqlCommand komut = new SqlCommand("UPDATE TBLPERSONEL SET PUAN=PUAN+@P1 WHERE ID=@P2 ", connection);
            komut.Parameters.AddWithValue("@P1",hesapla);
            komut.Parameters.AddWithValue("@P2",CmbEmploye.SelectedValue);
            komut.ExecuteNonQuery();
            connection.Close();
        }
        private void FSales_Load(object sender, EventArgs e)
        {
            Employee();
            IslemNo();
            ProductList();
            CustomerList();
            Total.Focus();
        }
        void IndirimsizsizSatis()
        {
            decimal toplam = satisfiyatı;
            connection.Open();
            SqlCommand sql = new SqlCommand("insert into TBLSATIS (ISLEMNO,URUNID,KATEGORIADI,MARKAADI,ALISFIYAT,SATISFIYAT,INDIRIMORANI,TOPLAMFIYAT,PERSONEL,MUSTERIID,TARIH) " +
                "values (@A1,@A2,@A3,@A4,@A5,@A6,@A7,@A8,@A9,@A10,@A11)", connection);
            sql.Parameters.AddWithValue("@A1", LIslemNo.Text);
            sql.Parameters.AddWithValue("@A2", id.ToString());
            sql.Parameters.AddWithValue("@A3", kategori.ToString());
            sql.Parameters.AddWithValue("@A4", marka.ToString());
            sql.Parameters.AddWithValue("@A5", Convert.ToDecimal(alisfiyati));
            sql.Parameters.AddWithValue("@A6", Convert.ToDecimal(satisfiyatı));
            sql.Parameters.AddWithValue("@A7", Convert.ToString(indirimorani).ToString());
            sql.Parameters.AddWithValue("@A8", Convert.ToDecimal(toplam));
            sql.Parameters.AddWithValue("@A9", CmbEmploye.SelectedValue);
            sql.Parameters.AddWithValue("@A10", CmbCustomer.SelectedValue);
            sql.Parameters.AddWithValue("@A11", Convert.ToString(LTarih.Text));
            sql.ExecuteNonQuery();
            connection.Close();
        }
        void IndirimliSatis()
        {
            decimal toplam = satisfiyatı - (satisfiyatı / 100) * indirimorani;
            connection.Open();
            SqlCommand sql = new SqlCommand("insert into TBLSATIS (ISLEMNO,URUNID,KATEGORIADI,MARKAADI,ALISFIYAT,SATISFIYAT,INDIRIMORANI,TOPLAMFIYAT,PERSONEL,MUSTERIID,TARIH) " +
                "values (@A1,@A2,@A3,@A4,@A5,@A6,@A7,@A8,@A9,@A10,@A11)", connection);
            sql.Parameters.AddWithValue("@A1", LIslemNo.Text);
            sql.Parameters.AddWithValue("@A2", id.ToString());
            sql.Parameters.AddWithValue("@A3", kategori.ToString());
            sql.Parameters.AddWithValue("@A4", marka.ToString());
            sql.Parameters.AddWithValue("@A5", Convert.ToDecimal(alisfiyati));
            sql.Parameters.AddWithValue("@A6", Convert.ToDecimal(satisfiyatı));
            sql.Parameters.AddWithValue("@A7", Convert.ToString(indirimorani).ToString());
            sql.Parameters.AddWithValue("@A8", Convert.ToDecimal(toplam));
            sql.Parameters.AddWithValue("@A9", CmbEmploye.SelectedValue);
            sql.Parameters.AddWithValue("@A10", CmbCustomer.SelectedValue);
            sql.Parameters.AddWithValue("@A11", Convert.ToString(LTarih.Text));
            sql.ExecuteNonQuery();
            connection.Close();

        }
        void UrunEksilt()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("UPDATE TBLURUN SET STOK=STOK-1 WHERE ID=" + LId.Text, connection);
            komut.ExecuteNonQuery();
            connection.Close();
        }
        void UrunArttir()
        {
            connection.Open();
            SqlCommand komut2 = new SqlCommand("UPDATE TBLURUN SET STOK=STOK+1 WHERE ID=" + id, connection);
            komut2.ExecuteNonQuery();
            connection.Close();
        }
        void IslemNoArttir()
        {
            int islem = int.Parse(LIslemNo.Text);
            connection.Open();
            SqlCommand sql = new SqlCommand("update TBLISLEM set IslemNo=@p1", connection);
            sql.Parameters.AddWithValue("@P1", islem + 1);
            sql.ExecuteNonQuery();
            connection.Close();

        }
        double hesapla = 0;
        double grd2fiyatal;

        private void BAdd_Click(object sender, EventArgs e)
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
            UrunEksilt();
            Product2();

        }
        void Clear()
        {
            for (int i = 0; i < gridView2.DataRowCount; i++)
            {
                gridView2.FocusedRowHandle = i;
                UrunArttir();
            }
            dt1.Rows.Clear();
            hesapla = 0;
            LblTest.Text = "0";
            Total.Text = hesapla.ToString("C2");
            LIndirimTutari.Visible = true;
            LIndirimTutari.Text = Convert.ToString("");
            Rch.Text = "";
            indirimorani = 0;
            LUyari.Visible = false;
            BAdd.Enabled = true;
            BSinirsiz.Enabled = true;
            B15.Enabled = true;
            B5.Enabled = true;
            B3.Enabled = true;
            BDelete.Enabled = true;

            Product2();
        }
        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);

            if (dr != null)
            {
                LId.Text = dr["ID"].ToString();
                LKategori.Text = dr["KATEGORİ"].ToString();
                LMarka.Text = dr["MARKA"].ToString();
                LAlis.Text = dr["ALIŞ FİYATI"].ToString();
                LSatis.Text = dr["SATIŞ FİYATI"].ToString();
                LUrun.Text = dr["ÜRÜN"].ToString();
            }
        }

        private void BClear_Click(object sender, EventArgs e)
        {
            Employee();
            CustomerList();
            Product2();
            Clear();
        }

        private void BDelete_Click(object sender, EventArgs e)
        {
            if (LblTest.Text != "0" || gridView2.RowCount == 1)
            {
                UrunArttir();
                Product2();
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

                id = dr["ID"].ToString();
                kategori = dr["KATEGORI"].ToString();
                marka = dr["MARKA"].ToString();
                urunadi = dr["ÜRÜN ADI"].ToString();
                alisfiyati = Convert.ToDecimal(dr["ALIŞ FİYATI"]);
                satisfiyatı = Convert.ToDecimal(dr["SATIŞ FİYATI"]);
            }
        }

        private void B15_Click(object sender, EventArgs e)
        {
            if (Total.Text != "0,00")
            {
                Total.Text = hesapla.ToString();
                double indirim = (hesapla / 100) * 15;
                LIndirimTutari.Visible = true;
                LIndirimTutari.Text = Convert.ToString("-" + "₺" + indirim);
                hesapla = hesapla - indirim;
                Total.Text = hesapla.ToString("C2");
                BAdd.Enabled = false;
                LUyari.Visible = true;
                BSinirsiz.Enabled = false;
                B15.Enabled = false;
                B5.Enabled = false;
                B3.Enabled = false;
                BDelete.Enabled = false;
                indirimorani = 15;
            }
        }
        private void B3_Click(object sender, EventArgs e)
        {
            if (Total.Text != "0,00")
            {
                Total.Text = hesapla.ToString();
                double indirim = (hesapla / 100) * 3;
                LIndirimTutari.Visible = true;
                LIndirimTutari.Text = Convert.ToString("- " + "₺" + indirim);
                hesapla = hesapla - indirim;
                Total.Text = hesapla.ToString("C2");
                BAdd.Enabled = false;
                LUyari.Visible = true;
                BSinirsiz.Enabled = false;
                B15.Enabled = false;
                B5.Enabled = false;
                B3.Enabled = false;
                BDelete.Enabled = false;
                indirimorani = 3;
            }
        }
        private void B5_Click(object sender, EventArgs e)
        {
            if (Total.Text != "0,00")
            {
                Total.Text = hesapla.ToString();
                double indirim = (hesapla / 100) * 5;
                LIndirimTutari.Visible = true;
                LIndirimTutari.Text = Convert.ToString("-" + "₺" + indirim);
                hesapla = hesapla - indirim;
                Total.Text = hesapla.ToString("C2");
                BAdd.Enabled = false;
                LUyari.Visible = true;
                BSinirsiz.Enabled = false;
                B15.Enabled = false;
                B5.Enabled = false;
                B3.Enabled = false;
                BDelete.Enabled = false;
                indirimorani = 5;
            }
        }

        private void BSinirsiz_Click(object sender, EventArgs e)
        {
            try
            {
                if (TYuzdeGir.Text != "0" && TYuzdeGir.Text != "")
                {
                    double yuzde = double.Parse(TYuzdeGir.Text);
                    if (Total.Text != "0,00")
                    {
                        Total.Text = hesapla.ToString();
                        double indirim = (hesapla / 100) * yuzde;
                        LIndirimTutari.Visible = true;
                        LIndirimTutari.Text = Convert.ToString("-" + "₺" + indirim);
                        hesapla = hesapla - indirim;
                        Total.Text = hesapla.ToString("C2");
                        BAdd.Enabled = false;
                        LUyari.Visible = true;
                        BSinirsiz.Enabled = false;
                        B15.Enabled = false;
                        B5.Enabled = false;
                        B3.Enabled = false;
                        BDelete.Enabled = false;
                        indirimorani = Convert.ToDecimal(TYuzdeGir.Text);
                    }
                }
            }
            catch (Exception)
            {

                MessageBox.Show("Nokta işareti kullanmayaınız. Nokta yerine (,) virgün 'ü tercih ediniz.");
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
                if (gridView1.DataRowCount == 0)
                {
                    MessageBox.Show(" " + Rch.Text + "\n\n Oh hayır...\n Bu ürünü tanımıyorum...", "HABERİN OLSUN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Product2();
                    Rch.Text = "";
                }
            }
            else if (Rch.Text == "")
            {
                Product2();
            }
        }
        private void BSatis_Click(object sender, EventArgs e)
        {
            if (gridView2.DataRowCount >= 1)
            {
                for (int i = 0; i < gridView2.DataRowCount; i++)
                {
                    if (indirimorani > 0)
                    {
                        gridView2.FocusedRowHandle = i;
                        IndirimliSatis();
                    }
                    else
                    {
                        gridView2.FocusedRowHandle = i;
                        IndirimsizsizSatis();
                    }
                }
                PuanAddEmploye();
                Employee();
                CustomerList();
                Product2();
                IslemNoArttir();
                IslemNo();
                Console.Beep(800, 250);
                Clear();
            }

        }
    }
}
