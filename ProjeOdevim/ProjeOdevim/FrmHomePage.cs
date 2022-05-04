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
        //   SqlConnection connection = new SqlConnection("Data Source=.;Initial Catalog=TicariOtomasyon;Integrated Security=True");
        // SqlConnection connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename=|DataDirectory|\TicariOtomasyon.mdf;Integrated Security=True");
        //SqlConnection connection = new SqlConnection(@"Data Source=.\SQLEXPRESS;AttachDbFilename=C:\Users\24f4c\Desktop\Proje\ProjeOdevim\ProjeOdevim\bin\Debug\TicariOtomasyon.mdf;Integrated Security=True;Connect Timeout=30;User Instance=True");
        SqlConnection connection = new SqlConnection(@"Server=(localdb)\v11.0;Integrated Security=true;AttachDbFileName=C:\Users\24f4c\Desktop\Proje\ProjeOdevim\ProjeOdevim\bin\Debug\TicariOtomasyon.mdf;");
        Formlar.FEmployeeStatis employeeStatis;
        Formlar.FCustomerStatis customerStatis;
        Formlar.FEmployeeAnalys employeeAnalys;
        Formlar.FCustomerAnalys customerAnalys;
        Formlar.frmViewer frm;
        Formlar.FSettings settings;
        Formlar.FHomeList homeList;
        Formlar.FProductList f1;
        Formlar.FCustomer fCustomer;
        Formlar.FEmployee f2;
        Formlar.FDoviz fDoviz;
        Formlar.FGooglee FGooglee;
        Formlar.FProductStatis fProductStatis;
        Formlar.FBasisStatis fBasis;
        Formlar.FSales sales;
        Formlar.FDaySales DaySales;
        Formlar.FMonthSales monthSales;
        FDayComp fday;
        Formlar.FMonthComp monthComp;
        Formlar.FSalesList FSales;
        Formlar.FBusyHour fBusy;
        Formlar.FVade vade;
        Formlar.FNotlar FNotlar;
        public int departman;
        public string xml1, xml2, xml3, xml4, xml5, xml6, xml7, xml8;
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
                xml7 = dr["XML7"].ToString();
                xml8 = dr["XML8"].ToString();
            }
            connection.Close();
        }
        private void BHomeList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (homeList == null || homeList.IsDisposed)
            {
                homeList = new Formlar.FHomeList();
                homeList.MdiParent = this;
                homeList.Show();
            }
        }
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
        private void BPersonel_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (f2 == null || f2.IsDisposed)
            {
                f2 = new Formlar.FEmployee();
                f2.MdiParent = this;
                f2.Show();
            }
        }
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
        private void BDoviz_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fDoviz == null || fDoviz.IsDisposed)
            {
                fDoviz = new Formlar.FDoviz();
                fDoviz.MdiParent = this;
                fDoviz.Show();
            }
        }
        private void BYoutube_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FGooglee == null || FGooglee.IsDisposed)
            {
                FGooglee = new Formlar.FGooglee();
                FGooglee.MdiParent = this;
                FGooglee.Show();
            }
        }
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
        private void BSales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (sales == null || sales.IsDisposed)
            {
                sales = new Formlar.FSales();
                sales.MdiParent = this;
                sales.Show();
            }
        }
        private void BDaySales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (DaySales == null || DaySales.IsDisposed)
            {
                Cursor = Cursors.WaitCursor;
                string filename2 = xml2;
                DaySales = new Formlar.FDaySales();
                DaySales.FDaySales_Load(filename2);
                DaySales.MdiParent = this;
                DaySales.Show();
                Cursor = Cursors.Default;
            }
        }
        private void BMonthSales_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (monthSales == null || monthSales.IsDisposed)
            {
                Cursor = Cursors.WaitCursor;
                string filename3 = xml3;
                monthSales = new Formlar.FMonthSales();
                monthSales.FMonthSales_Load(filename3);
                monthSales.MdiParent = this;
                monthSales.Show();
                Cursor = Cursors.Default;
            }
        }
        private void BDayComp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (fday == null || fday.IsDisposed)
            {
                Cursor = Cursors.WaitCursor;
                string filename4 = xml4;
                fday = new FDayComp();
                fday.FDayComp_Load(filename4);
                fday.MdiParent = this;
                fday.Show();
                Cursor = Cursors.Default;
            }
        }
        private void BMonthComp_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (monthComp == null || monthComp.IsDisposed)
            {
                Cursor = Cursors.WaitCursor;
                string filename5 = xml5;
                monthComp = new Formlar.FMonthComp();
                monthComp.FMonthComp_Load(filename5);
                monthComp.MdiParent = this;
                monthComp.Show();
                Cursor = Cursors.Default;
            }
        }
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
        private void BNot_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (FNotlar == null || FNotlar.IsDisposed)
            {
                FNotlar = new Formlar.FNotlar();
                FNotlar.MdiParent = this;
                FNotlar.Show();
            }
        }
        private void barButtonItem19_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (vade == null || vade.IsDisposed)
            {
                vade = new Formlar.FVade();
                vade.MdiParent = this;
                vade.Show();
            }
        }
        private void BVadeHesapla_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.BVadeCalc vadecalc = new Formlar.BVadeCalc();
            vadecalc.Show();
        }
        private void BHareket_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FUserList flist = new Formlar.FUserList();
            flist.ShowDialog();
        }
        private void BJoker_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Formlar.FJok jok = new Formlar.FJok();
            jok.Show();
        }
        private void FEmployeeAnalys_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (employeeAnalys == null || employeeAnalys.IsDisposed)
            {
                employeeAnalys = new Formlar.FEmployeeAnalys();
                employeeAnalys.MdiParent = this;
                employeeAnalys.Show();
            }
        }
        private void BCustomerAnalys_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (customerAnalys == null || customerAnalys.IsDisposed)
            {
                customerAnalys = new Formlar.FCustomerAnalys();
                customerAnalys.MdiParent = this;
                customerAnalys.Show();
            }
        }
        private void FCustomerTakip_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (customerStatis == null || customerStatis.IsDisposed)
            {
                string filename8 = xml8;
                customerStatis = new Formlar.FCustomerStatis();
                customerStatis.FCustomerStatis_Load(filename8);
                customerStatis.MdiParent = this;
                customerStatis.Show();
            }
        }
        private void BEmployeTakip_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (employeeStatis == null || employeeStatis.IsDisposed)
            {
                string filename7 = xml7;
                employeeStatis = new Formlar.FEmployeeStatis();
                employeeStatis.FEmployeeStatis_Load(filename7);
                employeeStatis.MdiParent = this;
                employeeStatis.Show();
            }
            Cursor = Cursors.Default;
        }
        private void BBusy_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            Cursor = Cursors.WaitCursor;
            if (fBusy == null || fBusy.IsDisposed)
            {
                string filename6 = xml6;
                fBusy = new Formlar.FBusyHour();
                fBusy.FBusyHour_Load(filename6);
                fBusy.MdiParent = this;
                fBusy.Show();
            }
            Cursor = Cursors.Default;
        }
        private void BMoneyList_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            if (frm == null || frm.IsDisposed)
            {
                Cursor = Cursors.WaitCursor;
                string filname = xml1;
                frm = new Formlar.frmViewer();
                frm.frmViewer_Load(filname);
                frm.MdiParent = this;
                frm.Show();
                Cursor = Cursors.Default;
            }
        }
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