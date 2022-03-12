using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProjeOdevim
{
    public partial class FrmHomePage : DevExpress.XtraEditors.XtraForm
    {
        public FrmHomePage()
        {
            InitializeComponent();
        }

        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {

        }

        Formlar.FrmList Category;
        private void BKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Category == null)
            {
                Category = new Formlar.FrmList();
                Category.Text = "KATEGORİ LİSTESİ";
                Category.label1.Text = "Category";
                Category.MdiParent = this;
                Category.Show();
            }

        }
        Formlar.FrmList Product;
        private void BUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Product == null)
            {
                Product = new Formlar.FrmList();
                Product.Text = "ÜRÜN LİSTESİ";
                Product.label1.Text = "Product";
                Product.MdiParent = this;
                Product.Show();
            }

        }

        Formlar.FrmList Department;
        private void BDepartman_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Department == null)
            {
                Department = new Formlar.FrmList();
                Department.Text = "DEPARTMAN LİSTESİ";
                Department.label1.Text = "Department";
                Department.MdiParent = this;
                Department.Show();
            }

        }

        Formlar.FrmList Shopping;
        private void BMagaza_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Shopping == null)
            {
                Shopping = new Formlar.FrmList();
                Shopping.Text = "MAĞAZA LİSTESİ";
                Shopping.label1.Text = "Shopping";
                Shopping.MdiParent = this;
                Shopping.Show();
            }
        }

        Formlar.FrmList Personel;
        private void BPersonel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Personel == null)
            {
                Personel = new Formlar.FrmList();
                Personel.Text = "PERSONEL LİSTESİ";
                Personel.label1.Text = "Personel";
                Personel.MdiParent = this;
                Personel.Show();
            }
        }

        Formlar.FrmList Customer;
        private void BMusteri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (Customer == null)
            {
                Customer = new Formlar.FrmList();
                Customer.Text = "MÜŞTERİ LİSTESİ";
                Customer.label1.Text = "Customer";
                Customer.MdiParent = this;
                Customer.Show();
            }
        }
    }
}
