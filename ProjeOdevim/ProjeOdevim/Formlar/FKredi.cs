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
    public partial class FKredi : Form
    {
        public FKredi()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=TicariOtomasyon;Integrated Security=True");


        private void BSave2_Click(object sender, EventArgs e)
        {
            if (TTc.Text != "" && TTc.TextLength >= 11)
            {
                connection.Open();
                SqlCommand komut = new SqlCommand("SELECT TC,AD,KREDILIMIT FROM TBLMUSTERI WHERE TC=" + TTc.Text, connection);
                SqlDataAdapter da = new SqlDataAdapter(komut);
                DataTable dt = new DataTable();
                da.Fill(dt);
                gridControl1.DataSource = dt;
                connection.Close();
                panel1.Visible = false;
                panel3.Visible = true;
                Size = new Size(555, 183);
                if (gridView1.DataRowCount == 0)
                {
                    MessageBox.Show(" " + TTc.Text + "\n\n Bu kişiyi tanımıyorum...", "HABERİN OLSUN", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    TTc.Text = "";
                }
            }
            else
            {
                MessageBox.Show(" " + TTc.Text + "\n\n Eksik Tuşlama.", "HATALI", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
        private void FKredi_Load(object sender, EventArgs e)
        {
            panel3.Visible = false;
            Size = new Size(385, 140);
        }

        private void simpleButton3_Click(object sender, EventArgs e)
        {
            panel1.Visible = true;
            panel3.Visible = false;
            Size = new Size(385, 140);
        }
        private void TTc_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }

        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
