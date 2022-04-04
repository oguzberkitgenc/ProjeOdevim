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
    public partial class FCustomer : Form
    {
        public FCustomer()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");

        void CustomerList()
        {
            connection.Open();
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("Select * From TBLMUSTERI", connection);
            da.Fill(dt);
            gridControl1.DataSource = dt;
            connection.Close();
        }
        void IlList()
        {
            SqlCommand command = new SqlCommand("Select * From ILLER", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dataTable = new DataTable();
            da.Fill(dataTable);
            CmbIl.ValueMember = "ID";
            CmbIl.DisplayMember = "SEHIR";
            CmbIl.DataSource = dataTable;
        }

        void Clear()
        {
            MskTc.Text = "";
            TId.Text = "";
            TName.Text = "";
            TSurname.Text = "";
            MskBirth.Text = "";
            CmbIl.Text = "";
            CmbIlce.Text = "";
            RchAdres.Text = "";
            CmbGender.Text = "";
            MskPhone.Text = "";
        }
        private void FCustomer_Load(object sender, EventArgs e)
        {
            CustomerList();
            IlList();
            gridView1.Columns[0].Visible = false;
            Clear();
        }

        private void BSave_Click(object sender, EventArgs e)
        {
            double kredi = 0;
            if (TId.Text == "" & MskTc.Text != "" & TName.Text != "" & TSurname.Text != "" & CmbGender.Text != "" &
                MskBirth.Text != "" & CmbIl.Text != "" & CmbIlce.Text != "" & RchAdres.Text != "" & MskPhone.Text != "")
            {
                connection.Open();
                SqlCommand sql = new SqlCommand("insert into TBLMUSTERI (TC,AD,IL,ILCE,ADRES,DOGUMT,TEL,CINSIYET,KREDILIMIT) values (@p1,@p2,@p4,@p5,@p6,@p7,@p8,@p9,@p10)", connection);
                sql.Parameters.AddWithValue("@P1", MskTc.Text);
                sql.Parameters.AddWithValue("@P2", TName.Text);
                sql.Parameters.AddWithValue("@P4", CmbIl.Text);
                sql.Parameters.AddWithValue("@P5", CmbIlce.Text);
                sql.Parameters.AddWithValue("@P6", RchAdres.Text);
                sql.Parameters.AddWithValue("@P7", MskBirth.Text);
                sql.Parameters.AddWithValue("@P8", MskPhone.Text);
                sql.Parameters.AddWithValue("@P9", CmbGender.Text);
                sql.Parameters.AddWithValue("@P10", kredi.ToString());
                sql.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show(" Yeni Müşterimiz Sisteme Başarıyla Kayıt Edildi \n\n Adı Soyadı: " + TName.Text + " " + TSurname.Text + "\n\n TC No: " + MskTc.Text +
                    "\n\n İletişim Numarası: " + MskPhone.Text, "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CustomerList();
                Clear();
            }
            else
            {
                MessageBox.Show(" Eksik Bilgi Girişi. \n Lütfen Eksik Yerleri Doldurunuz ve Tekrar Deneyiniz", "UYARI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

        private void BClear_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void gridView1_FocusedRowChanged(object sender, DevExpress.XtraGrid.Views.Base.FocusedRowChangedEventArgs e)
        {
            DataRow dr = gridView1.GetDataRow(gridView1.FocusedRowHandle);
            TId.Text = dr["ID"].ToString();
            TName.Text = dr["AD"].ToString();
            CmbGender.Text = dr["CINSIYET"].ToString();
            MskBirth.Text = dr["DOGUMT"].ToString();
            CmbIl.Text = dr["IL"].ToString();
            CmbIlce.Text = dr["ILCE"].ToString();
            RchAdres.Text = dr["ADRES"].ToString();
            MskPhone.Text = dr["TEL"].ToString();
            MskTc.Text = dr["TC"].ToString();
        }

        private void CmbIl_SelectedIndexChanged(object sender, EventArgs e)
        {

            connection.Open();
            CmbIlce.Text = "";
            SqlCommand komut = new SqlCommand("Select ILCE From ILCELER where SEHIR=@p1", connection);
            komut.Parameters.AddWithValue("@p1", CmbIl.SelectedIndex + 1);
            SqlDataReader dr = komut.ExecuteReader();
            while (dr.Read())
            {
                CmbIlce.Items.Add(dr[0]);
            }
            connection.Close();
        }

        private void BUpdate_Click(object sender, EventArgs e)
        {
            if (TId.Text != "")
            {
                connection.Open();
                SqlCommand komut = new SqlCommand("update TBLMUSTERI set TC=@P1,AD=@P2,DOGUMT=@P4,IL=@P5,ILCE=@P6,ADRES=@P7,CINSIYET=@P8,TEL=@P9 WHERE ID=@P10", connection);
                komut.Parameters.AddWithValue("@p1", MskTc.Text);
                komut.Parameters.AddWithValue("@p2", TName.Text);
                komut.Parameters.AddWithValue("@p4", MskBirth.Text);
                komut.Parameters.AddWithValue("@p5", CmbIl.Text);
                komut.Parameters.AddWithValue("@p6", CmbIlce.Text);
                komut.Parameters.AddWithValue("@p7", RchAdres.Text);
                komut.Parameters.AddWithValue("@p8", CmbGender.Text);
                komut.Parameters.AddWithValue("@p9", MskPhone.Text);
                komut.Parameters.AddWithValue("@p10", TId.Text);
                komut.ExecuteNonQuery();
                connection.Close();
                MessageBox.Show("  Müşteri Bilgileri Başarıyla Güncellendi!", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Information);
                CustomerList();
                Clear();
            }
            else
            {
                MessageBox.Show(" Lütfen Güncellemek İstediğiniz Ürünü Seçin ", "BİLGİ", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
        }

    }
}
