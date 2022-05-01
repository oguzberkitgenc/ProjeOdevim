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
    public partial class BVadeCalc : Form
    {
        public BVadeCalc()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=DbProjem;Integrated Security=True");
        private void BVadeCalc_Load(object sender, EventArgs e)
        {
            SqlCommand command = new SqlCommand("Select * From TBLFAIZLER", connection);
            SqlDataAdapter da = new SqlDataAdapter(command);
            DataTable dt = new DataTable();
            da.Fill(dt);
            CmbTaksit.ValueMember = "ID";
            CmbTaksit.DisplayMember = "VADE";
            CmbTaksit.DataSource = dt;
        }

        private void TMiktarGir_KeyPress(object sender, KeyPressEventArgs e)
        {
            e.Handled = !char.IsDigit(e.KeyChar) && !char.IsControl(e.KeyChar);
        }
        Formlar.FVadeShow f = new Formlar.FVadeShow();
        private void BHesapla_Click(object sender, EventArgs e)
        {
            try
            {
                if (TMiktar.Text != "")
                {
                    DateTime dt = DateTime.Now;
                    double text, oran, hesapla, fark, taksit, anapara;
                    double vadesayisi = double.Parse(CmbTaksit.Text);
                    text = Convert.ToDouble(TMiktar.Text);
                    oran = Convert.ToDouble(CmbTaksit.SelectedValue);
                    hesapla = text + (text / 100 * oran);
                    fark = hesapla - text;
                    anapara = text/vadesayisi;
                    taksit = hesapla / vadesayisi;
                    f.LMiktar.Text = "₺" + TMiktar.Text.ToString();
                    f.LVadeSayisi.Text = CmbTaksit.Text + " Ay";
                    f.LGeriOde.Text = hesapla.ToString("C2");
                    f.LFark.Text = fark.ToString("C2");
                    f.LAylik.Text = taksit.ToString("C2");
                    f.LTarih.Text = CmbTaksit.Text + ". Taksit Tarihi :";
                    f.LIlkTarih.Text = dt.ToString();
                    f.LSonTarih.Text = dt.AddMonths(int.Parse(CmbTaksit.Text) - 1).ToString();
                    f.LFaiz.Text = CmbTaksit.SelectedValue.ToString();
                    f.vade = int.Parse(CmbTaksit.Text);
                    f.anmony = anapara;
                    f.ShowDialog();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Hesaplamam için bana yardım et.", "Boş Bırakma", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {

                MessageBox.Show(ex.ToString());
            }


        }
        private void BCik_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
