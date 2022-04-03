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
namespace ProjeOdevim
{
    public partial class FrmHomePage : DevExpress.XtraEditors.XtraForm
    {
        public FrmHomePage()
        {
            InitializeComponent();
        }
        SqlConnection connection = new SqlConnection(@"Data Source=BERKIT;Initial Catalog=DbProjem;Integrated Security=True");
        Formlar.FHomeList homeList;
        private void BHomeList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (homeList == null || homeList.IsDisposed)
            {
                homeList = new Formlar.FHomeList();
                homeList.MdiParent = this;
                homeList.Show();
            }
        }
        public int departman;
        private void FrmAnaSayfa_Load(object sender, EventArgs e)
        {
            DateTime date = DateTime.Now;
            LDate.Text = date.ToString("MM/dd/yyyy");
            LTime.Text = date.ToString("HH:MM:ss");
            timer1.Start();
            if (homeList == null || homeList.IsDisposed)
            {
                homeList = new Formlar.FHomeList();
                homeList.MdiParent = this;
                homeList.Show();
            }

            connection.Open();
            SqlCommand sqlCommand = new SqlCommand("SELECT * FROM TBLDEPARTMAN WHERE ID=@P1", connection);
            sqlCommand.Parameters.AddWithValue("@P1", departman);
            SqlDataReader dr = sqlCommand.ExecuteReader();
            while (dr.Read())
            {
                LDepart.Text = dr[1].ToString();
            }
            connection.Close();
        }
        private void BKategori_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FCategory fCategory = new Formlar.FCategory();
            fCategory.ShowDialog();
        }
        Formlar.FProductList f1;
        private void BUrun_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f1 == null || f1.IsDisposed)
            {
                f1 = new Formlar.FProductList();
                f1.MdiParent = this;
                f1.Show();
            }
        }
        private void BDepartman_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FDepartment fDepartment = new Formlar.FDepartment();
            fDepartment.ShowDialog();
        }

        Formlar.FShopping fShopping;
        private void BMagaza_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fShopping == null || fShopping.IsDisposed)
            {
                fShopping = new Formlar.FShopping();
                fShopping.MdiParent = this;
                fShopping.Show();
            }
        }
        Formlar.FEmployee f2;
        private void BPersonel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f2 == null || f2.IsDisposed)
            {
                f2 = new Formlar.FEmployee();
                f2.MdiParent = this;
                f2.Show();
            }
        }
        Formlar.FCustomer fCustomer;
        private void BMusteri_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fCustomer == null || fCustomer.IsDisposed)
            {
                fCustomer = new Formlar.FCustomer();
                fCustomer.MdiParent = this;
                fCustomer.Show();
            }
        }
        private void BCalc_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("Calc.exe");
        }

        private void BWord_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("winword");
        }

        private void BPaint_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("mspaint");
        }

        private void BExcell_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("excel");
        }
        Formlar.FDoviz fDoviz;
        private void BDoviz_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fDoviz == null || fDoviz.IsDisposed)
            {
                fDoviz = new Formlar.FDoviz();
                fDoviz.MdiParent = this;
                fDoviz.Show();
            }
        }

        Formlar.FGooglee FGooglee;
        private void BYoutube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FGooglee == null || FGooglee.IsDisposed)
            {
                FGooglee = new Formlar.FGooglee();
                FGooglee.MdiParent = this;
                FGooglee.Show();
            }
        }
        Formlar.FProductStatis fProductStatis;
        private void BProductSt_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fProductStatis == null || fProductStatis.IsDisposed)
            {
                fProductStatis = new Formlar.FProductStatis();
                fProductStatis.MdiParent = this;
                fProductStatis.Show();
            }
        }

        private void BBuyutec_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("magnify");
        }

        private void BKlavye_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            System.Diagnostics.Process.Start("notepad");
        }

        Formlar.FBasisStatis fBasis;
        private void BTemelAnaliz_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

            if (fBasis == null || fBasis.IsDisposed)
            {
                fBasis = new Formlar.FBasisStatis();
                fBasis.MdiParent = this;
                fBasis.Show();
            }
        }


        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dateTime = DateTime.Now;
            LTime.Text = dateTime.ToString("HH:MM:ss");
        }

        private void BKullanici_Click(object sender, EventArgs e)
        {
            Formlar.FLogin fLogin = new Formlar.FLogin();
            fLogin.Show();
            this.Hide();
        }
    }
}