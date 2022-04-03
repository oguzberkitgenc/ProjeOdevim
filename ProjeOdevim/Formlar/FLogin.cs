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
        int id;
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("Select KADI,SIFRE,AD,SOYAD,DEPARTMANID FROM TBLPERSONEL WHERE KADI=@P1 AND SIFRE=@P2", connection);
            command.Parameters.AddWithValue("@P1", TUser.Text);
            command.Parameters.AddWithValue("@P2", TPass.Text);
            SqlDataReader reader = command.ExecuteReader();
            if (reader.Read())
            {
                FrmHomePage frm = new FrmHomePage();
                frm.LName.Text = reader["AD"].ToString() + " " + reader["SOYAD"].ToString();
                frm.departman = int.Parse(reader["DEPARTMANID"].ToString());
                frm.ShowDialog();
                this.Hide();
            }
            else
            {
                MessageBox.Show(" Kullanıcı Adı Veya Şifre Yanlış. \n Lütfen Tekrar Deneyiniz", "HATALI", MessageBoxButtons.OK, MessageBoxIcon.Stop);

            }
            connection.Close();
        }
    }
}
