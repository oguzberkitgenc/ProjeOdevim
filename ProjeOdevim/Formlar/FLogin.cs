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
    public partial class FLogin : Form
    {
        public FLogin()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");

        private void BExit_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
        string adsoy, depart;
        bool durum;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            FrmHomePage frm = new FrmHomePage();
            connection.Open();
            SqlCommand command = new SqlCommand("Select KADI,SIFRE,AD,SOYAD,DEPARTMANID FROM TBLPERSONEL WHERE KADI=@P1 AND SIFRE=@P2", connection);
            command.Parameters.AddWithValue("@P1", TUser.Text);
            command.Parameters.AddWithValue("@P2", TPass.Text);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                frm.LName.Text = reader["AD"].ToString() + " " + reader["SOYAD"].ToString();
                frm.departman = int.Parse(reader["DEPARTMANID"].ToString());
                depart = Convert.ToString(reader["DEPARTMANID"].ToString());
                adsoy = reader["AD"].ToString() + " " + reader["SOYAD"].ToString();
                durum = true;
            }
            else
            {
                MessageBox.Show(" Kullanıcı Adı Veya Şifre Yanlış. \n Lütfen Tekrar Deneyiniz", "HATALI", MessageBoxButtons.OK, MessageBoxIcon.Stop);
            }
            connection.Close();
            if (durum == true)
            {
                DateTime dateTime = DateTime.Now;
                string dt = dateTime.ToString("MM/dd/yyyy HH:mm:ss");
                connection.Open();
                SqlCommand komut = new SqlCommand("insert into TBLKULLANICIHAREKET (KULLANICI,ADSOYAD,DEPART,TARIH) VALUES (@A1,@A2,@A3,@A4)", connection);
                komut.Parameters.AddWithValue("@A1", TUser.Text);
                komut.Parameters.AddWithValue("@A2", adsoy.ToString());
                komut.Parameters.AddWithValue("@a3", depart.ToString());
                komut.Parameters.AddWithValue("@A4", dt.ToString());
                komut.ExecuteNonQuery();
                connection.Close();
                frm.ShowDialog();
                this.Hide();
            }

        }
    }
}