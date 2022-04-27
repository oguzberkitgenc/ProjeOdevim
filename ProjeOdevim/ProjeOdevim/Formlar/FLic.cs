using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Management;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ProjeOdevim.Formlar
{
    public partial class FLic : Form
    {
        public FLic()
        {
            InitializeComponent();
        }
        BaglantiSinif bgl = new BaglantiSinif();
        long toplam3 = 0;
        private void FLic_Load(object sender, EventArgs e)
        {
            //İşlemci Numarası Al
            string islemciid = "";
            ManagementObjectSearcher ara = new ManagementObjectSearcher("SELECT * FROM WIN32_Processor");
            ManagementObjectCollection obje = ara.Get();
            foreach (ManagementObject item in obje)
            {
                islemciid = item["ProcessorId"].ToString();
            }
            //Bios No Al
            string hddno = "";
            ManagementObjectSearcher ara2 = new ManagementObjectSearcher("SELECT * FROM WIN32_BIOS");
            ManagementObjectCollection obje2 = ara2.Get();
            foreach (ManagementObject item in obje2)
            {
                hddno = item["SerialNumber"].ToString();
            }

            //İşlemci Numarasını Sayıya Çevir
            int toplam = 0;
            foreach (char item in islemciid.ToCharArray())
            {
                toplam += (int)item;
            }

            //Bios Numarasını Sayıya ÇEvir
            int toplam2 = 0;
            foreach (char item2 in hddno.ToCharArray())
            {
                toplam2 += (int)item2;
            }

            long hesapla1 = 0, hesapla2 = 0;
            hesapla1 = toplam * 2;
            hesapla2 = toplam2 * 2;

            LIslemci.Text = islemciid + "SYSTEMLOG" + hesapla1.ToString();
            LBios.Text = hddno + "SYSTEM32" + hesapla2.ToString();

            toplam3 = toplam * toplam2 * 23;

        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                if (toplam3 == long.Parse(textBox1.Text))
                {
                    SqlConnection connection = new SqlConnection(bgl.Adres);
                    connection.Open();
                    SqlCommand komut = new SqlCommand("UPDATE TBLXML SET XLIC=" + toplam3.ToString(), connection);
                    komut.ExecuteNonQuery();
                    connection.Close();
                    MessageBox.Show(" Lisanslama İşlemi Başarılı.\n Program kapatılacaktır tekrar açınız.","LİSANSLI",MessageBoxButtons.OK,MessageBoxIcon.Information);
                    Application.Exit();
                }
                else
                {
                    MessageBox.Show(" Geçersiz Lisans.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }
            }
            catch (Exception)
            {

                MessageBox.Show(" Hatalı Girişç.", "HATA", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }

        }
    }
}
