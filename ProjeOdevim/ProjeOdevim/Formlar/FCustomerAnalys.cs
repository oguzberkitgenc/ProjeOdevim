﻿using System;
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
    public partial class FCustomerAnalys : Form
    {
        public FCustomerAnalys()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=TicariOtomasyon;Integrated Security=True");

        void ChartDoldur()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT ILCE,COUNT(ILCE) AS 'SAYI' FROM TBLMUSTERI GROUP BY ILCE", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl1.Series["Series 1"].Points.AddPoint(Convert.ToString(dr[0]), int.Parse(dr[1].ToString()));
            }
            connection.Close();
        }
        void GridDoldur()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT COUNT(ILCE) AS 'SAYI',ILCE AS 'İLÇE' FROM TBLMUSTERI GROUP BY ILCE ORDER BY SAYI DESC ", connection);
            SqlDataAdapter da = new SqlDataAdapter(komut);
            DataTable dt = new DataTable();
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
            gridView1.Columns[0].Width = 5;
        }
        void CinsiyetGetir()
        {
            connection.Open();
            SqlCommand komut2 = new SqlCommand("SELECT CINSIYETAD,COUNT(CINSIYETAD) FROM TBLMUSTERI INNER JOIN TBLCINSIYET ON TBLMUSTERI.CINSIYET=TBLCINSIYET.ID GROUP BY CINSIYETAD ORDER BY CINSIYETAD ASC", connection);
            SqlDataReader dr2 = komut2.ExecuteReader();
            while (dr2.Read())
            {
                chartControl2.Series["Cisim"].Points.AddPoint(Convert.ToString(dr2[0].ToString()), int.Parse(dr2[1].ToString()));
            }
            connection.Close();
        }
        void CiroGetir()
        {
            connection.Open();
            SqlCommand komut3 = new SqlCommand("SELECT  TOP 20 AD,SUM(TOPLAMFIYAT) AS 'TOPLAM' FROM TBLSATIS  INNER JOIN TBLMUSTERI ON TBLSATIS.MUSTERIID=TBLMUSTERI.ID GROUP BY AD ORDER BY TOPLAM DESC", connection);
            SqlDataReader dr3 = komut3.ExecuteReader();
            while (dr3.Read())
            {
                chartControl3.Series["Nekadar"].Points.AddPoint(Convert.ToString(dr3[0]).ToString(), double.Parse(dr3[1].ToString()));
            }
            connection.Close();
        }
        int g, k, e = 0;
        DateTime dt = DateTime.Now;
        void Genel()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT AVG(DOGUMT) FROM TBLMUSTERI", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                g = Convert.ToInt32(dr[0]);
            }
            connection.Close();
            g = Convert.ToInt32(dt.Year) - g;
            LGenel.Text = g.ToString();
        }
        void Kadın()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT AVG(DOGUMT) FROM TBLMUSTERI where CINSIYET=2", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                k = Convert.ToInt32(dr[0]);
            }
            connection.Close();
            k = Convert.ToInt32(dt.Year) - k;
            LKadın.Text = k.ToString();

        }
        void Erkek()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT AVG(DOGUMT) FROM TBLMUSTERI where CINSIYET=1", connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                e = Convert.ToInt32(dr[0]);
            }
            connection.Close();
            e = Convert.ToInt32(dt.Year) - e;
            LErkek.Text = e.ToString();
        }
        void YasChart()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("SELECT 2022-DOGUMT,COUNT(DOGUMT) FROM TBLMUSTERI GROUP BY DOGUMT",connection);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                chartControl4.Series["Yaslar"].Points.AddPoint(Convert.ToString(dr[0].ToString()), Convert.ToInt32(dr[1].ToString()));
            }
            connection.Close();
        }
        private void FCustomerAnalys_Load(object sender, EventArgs e)
        {
            try
            {
                ChartDoldur();
                GridDoldur();
                CinsiyetGetir();
                CiroGetir();
                Genel();
                Kadın();
                Erkek();
                YasChart();
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }
            
        }
    }
}
