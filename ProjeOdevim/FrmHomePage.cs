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
        public string xml1, xml2, xml3, xml4, xml5,xml6;
        public void XmlGetir()
        {
            connection.Open();
            SqlCommand komut = new SqlCommand("Select * From TBLXML", connection);
            SqlDataReader dr = komut.ExecuteReader();
            DataTable dt = new DataTable();
            while (dr.Read())
            {
                xml1 = dr["XML1"].ToString();
                xml2 = dr["XML2"].ToString();
                xml3 = dr["XML3"].ToString();
                xml4 = dr["XML4"].ToString();
                xml5 = dr["XML5"].ToString();
                xml6 = dr["XML6"].ToString();
            }
            connection.Close();
        }
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
            XmlGetir();
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
            this.Hide();
            Formlar.FLogin fLogin = new Formlar.FLogin();
            fLogin.Show();
        }

        Formlar.FSales sales;
        private void BSales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (sales == null || sales.IsDisposed)
            {
                sales = new Formlar.FSales();
                sales.MdiParent = this;
                sales.Show();
            }
        }

        Formlar.FDaySales DaySales;
        private void BDaySales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DaySales == null || DaySales.IsDisposed)
            {
                string filename2 = xml2;
                DaySales = new Formlar.FDaySales();
                DaySales.FDaySales_Load(filename2);
                DaySales.MdiParent = this;
                DaySales.Show();
            }
        }
        Formlar.FMonthSales monthSales;
        private void BMonthSales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (monthSales == null || monthSales.IsDisposed)
            {
                string filename3 = xml3;
                monthSales = new Formlar.FMonthSales();
                monthSales.FMonthSales_Load(filename3);
                monthSales.MdiParent = this;
                monthSales.Show();
            }
        }
        FDayComp fday;
        private void BDayComp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fday == null || fday.IsDisposed)
            {
                string filename4 = xml4;
                fday = new FDayComp();
                fday.FDayComp_Load(filename4);
                fday.MdiParent = this;
                fday.Show();
            }
        }
        Formlar.FMonthComp monthComp;
        private void BMonthComp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (monthComp == null || monthComp.IsDisposed)
            {
                string filename5 = xml5;
                monthComp = new Formlar.FMonthComp();
                monthComp.FMonthComp_Load(filename5);
                monthComp.MdiParent = this;
                monthComp.Show();
            }
        }

        Formlar.FSalesList FSales;
        private void BSaless_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FSales == null || FSales.IsDisposed)
            {
                FSales = new Formlar.FSalesList();
                FSales.MdiParent = this;
                FSales.Show();
            }
        }

        private void barButtonItem10_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FWhoAmi fWhoAmi = new Formlar.FWhoAmi();
            fWhoAmi.Show();
        }

        private void BKredi_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FKredi kredi = new Formlar.FKredi();
            kredi.Show();
        }
        Formlar.FNotlar FNotlar;
        private void BNot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FNotlar==null ||FNotlar.IsDisposed)
            {
                FNotlar = new Formlar.FNotlar();
                FNotlar.MdiParent = this;
                FNotlar.Show();
            }
        }
        Formlar.FBusyHour fBusy;
        private void BBusy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fBusy==null ||fBusy.IsDisposed)
            {
                string filename6 = xml6;
                fBusy = new Formlar.FBusyHour();
                fBusy.FBusyHour_Load(filename6);
                fBusy.MdiParent = this;
                fBusy.Show();
            }
        }

        Formlar.frmViewer frm;
        private void BMoneyList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
            {
                string filname = xml1;
                frm = new Formlar.frmViewer();
                frm.frmViewer_Load(filname);
                frm.MdiParent = this;
                frm.Show();
            }
        }
        Formlar.FSettings settings;
        private void barButtonItem8_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (settings == null || settings.IsDisposed)
            {
                settings = new Formlar.FSettings();
                settings.MdiParent = this;
                settings.Show();
            }
        }
    }
}