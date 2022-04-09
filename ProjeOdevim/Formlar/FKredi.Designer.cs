namespace ProjeOdevim.Formlar
{
    partial class FKredi
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FKredi));
            this.BSave2 = new DevExpress.XtraEditors.SimpleButton();
            this.label1 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.TTc = new System.Windows.Forms.TextBox();
            this.simpleButton1 = new DevExpress.XtraEditors.SimpleButton();
            this.panel2 = new System.Windows.Forms.Panel();
            this.gridControl1 = new DevExpress.XtraGrid.GridControl();
            this.gridView1 = new DevExpress.XtraGrid.Views.Grid.GridView();
            this.simpleButton2 = new DevExpress.XtraEditors.SimpleButton();
            this.simpleButton3 = new DevExpress.XtraEditors.SimpleButton();
            this.panel3 = new System.Windows.Forms.Panel();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).BeginInit();
            this.panel3.SuspendLayout();
            this.SuspendLayout();
            // 
            // BSave2
            // 
            this.BSave2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(82)))), ((int)(((byte)(221)))));
            this.BSave2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BSave2.Appearance.Options.UseBackColor = true;
            this.BSave2.Appearance.Options.UseFont = true;
            this.BSave2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BSave2.ImageOptions.Image")));
            this.BSave2.Location = new System.Drawing.Point(42, 41);
            this.BSave2.Name = "BSave2";
            this.BSave2.Size = new System.Drawing.Size(281, 30);
            this.BSave2.TabIndex = 2;
            this.BSave2.Text = "Sorgula";
            this.BSave2.Click += new System.EventHandler(this.BSave2_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.Location = new System.Drawing.Point(-2, 12);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 19);
            this.label1.TabIndex = 53;
            this.label1.Text = "TC: ";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.TTc);
            this.panel1.Controls.Add(this.simpleButton1);
            this.panel1.Controls.Add(this.BSave2);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Location = new System.Drawing.Point(12, 6);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(334, 125);
            this.panel1.TabIndex = 54;
            // 
            // TTc
            // 
            this.TTc.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TTc.Location = new System.Drawing.Point(42, 12);
            this.TTc.MaxLength = 11;
            this.TTc.Name = "TTc";
            this.TTc.Size = new System.Drawing.Size(281, 26);
            this.TTc.TabIndex = 1;
            this.TTc.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TTc_KeyPress);
            // 
            // simpleButton1
            // 
            this.simpleButton1.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(82)))), ((int)(((byte)(221)))));
            this.simpleButton1.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton1.Appearance.Options.UseBackColor = true;
            this.simpleButton1.Appearance.Options.UseFont = true;
            this.simpleButton1.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.simpleButton1.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton1.ImageOptions.Image")));
            this.simpleButton1.Location = new System.Drawing.Point(42, 77);
            this.simpleButton1.Name = "simpleButton1";
            this.simpleButton1.Size = new System.Drawing.Size(281, 30);
            this.simpleButton1.TabIndex = 3;
            this.simpleButton1.Text = "Çık";
            this.simpleButton1.Click += new System.EventHandler(this.simpleButton1_Click);
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.gridControl1);
            this.panel2.Location = new System.Drawing.Point(-3, -1);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(548, 125);
            this.panel2.TabIndex = 55;
            // 
            // gridControl1
            // 
            this.gridControl1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.gridControl1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.gridControl1.Location = new System.Drawing.Point(0, 0);
            this.gridControl1.MainView = this.gridView1;
            this.gridControl1.Name = "gridControl1";
            this.gridControl1.Size = new System.Drawing.Size(548, 125);
            this.gridControl1.TabIndex = 75;
            this.gridControl1.ViewCollection.AddRange(new DevExpress.XtraGrid.Views.Base.BaseView[] {
            this.gridView1});
            // 
            // gridView1
            // 
            this.gridView1.Appearance.ColumnFilterButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.ColumnFilterButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.ColumnFilterButton.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.ColumnFilterButton.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButton.Options.UseFont = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.ColumnFilterButtonActive.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseBackColor = true;
            this.gridView1.Appearance.ColumnFilterButtonActive.Options.UseFont = true;
            this.gridView1.Appearance.CustomizationFormHint.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.CustomizationFormHint.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.CustomizationFormHint.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.CustomizationFormHint.Options.UseBackColor = true;
            this.gridView1.Appearance.CustomizationFormHint.Options.UseFont = true;
            this.gridView1.Appearance.DetailTip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.DetailTip.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.DetailTip.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.DetailTip.Options.UseBackColor = true;
            this.gridView1.Appearance.DetailTip.Options.UseFont = true;
            this.gridView1.Appearance.Empty.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.Empty.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.Empty.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.Empty.Options.UseBackColor = true;
            this.gridView1.Appearance.Empty.Options.UseFont = true;
            this.gridView1.Appearance.EvenRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.EvenRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.EvenRow.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.EvenRow.Options.UseBackColor = true;
            this.gridView1.Appearance.EvenRow.Options.UseFont = true;
            this.gridView1.Appearance.FilterCloseButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.FilterCloseButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.FilterCloseButton.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.FilterCloseButton.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterCloseButton.Options.UseFont = true;
            this.gridView1.Appearance.FilterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.FilterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.FilterPanel.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.FilterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FilterPanel.Options.UseFont = true;
            this.gridView1.Appearance.FixedLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.FixedLine.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.FixedLine.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.FixedLine.Options.UseBackColor = true;
            this.gridView1.Appearance.FixedLine.Options.UseFont = true;
            this.gridView1.Appearance.FocusedCell.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.FocusedCell.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.FocusedCell.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.FocusedCell.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedCell.Options.UseFont = true;
            this.gridView1.Appearance.FocusedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.FocusedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.FocusedRow.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.FocusedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.FocusedRow.Options.UseFont = true;
            this.gridView1.Appearance.FooterPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.FooterPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.FooterPanel.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.FooterPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.FooterPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupButton.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.GroupButton.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.GroupButton.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.GroupButton.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupButton.Options.UseFont = true;
            this.gridView1.Appearance.GroupFooter.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.GroupFooter.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.GroupFooter.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.GroupFooter.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupFooter.Options.UseFont = true;
            this.gridView1.Appearance.GroupPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.GroupPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.GroupPanel.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.GroupPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupPanel.Options.UseFont = true;
            this.gridView1.Appearance.GroupRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.GroupRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.GroupRow.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.GroupRow.Options.UseBackColor = true;
            this.gridView1.Appearance.GroupRow.Options.UseFont = true;
            this.gridView1.Appearance.HeaderPanel.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.HeaderPanel.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.HeaderPanel.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.HeaderPanel.Options.UseBackColor = true;
            this.gridView1.Appearance.HeaderPanel.Options.UseFont = true;
            this.gridView1.Appearance.HideSelectionRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.HideSelectionRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.HideSelectionRow.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.HideSelectionRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HideSelectionRow.Options.UseFont = true;
            this.gridView1.Appearance.HorzLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.HorzLine.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.HorzLine.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.HorzLine.Options.UseBackColor = true;
            this.gridView1.Appearance.HorzLine.Options.UseFont = true;
            this.gridView1.Appearance.HotTrackedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.HotTrackedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.HotTrackedRow.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.HotTrackedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.HotTrackedRow.Options.UseFont = true;
            this.gridView1.Appearance.OddRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.OddRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.OddRow.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.OddRow.Options.UseBackColor = true;
            this.gridView1.Appearance.OddRow.Options.UseFont = true;
            this.gridView1.Appearance.Preview.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.Preview.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.Preview.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.Preview.Options.UseBackColor = true;
            this.gridView1.Appearance.Preview.Options.UseFont = true;
            this.gridView1.Appearance.Row.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.Row.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.Row.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.Row.Options.UseBackColor = true;
            this.gridView1.Appearance.Row.Options.UseFont = true;
            this.gridView1.Appearance.RowSeparator.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.RowSeparator.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.RowSeparator.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.RowSeparator.Options.UseBackColor = true;
            this.gridView1.Appearance.RowSeparator.Options.UseFont = true;
            this.gridView1.Appearance.SelectedRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.SelectedRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.SelectedRow.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.SelectedRow.GradientMode = System.Drawing.Drawing2D.LinearGradientMode.BackwardDiagonal;
            this.gridView1.Appearance.SelectedRow.Options.UseBackColor = true;
            this.gridView1.Appearance.SelectedRow.Options.UseFont = true;
            this.gridView1.Appearance.TopNewRow.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.TopNewRow.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.TopNewRow.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.TopNewRow.Options.UseBackColor = true;
            this.gridView1.Appearance.TopNewRow.Options.UseFont = true;
            this.gridView1.Appearance.VertLine.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.VertLine.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.VertLine.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.VertLine.Options.UseBackColor = true;
            this.gridView1.Appearance.VertLine.Options.UseFont = true;
            this.gridView1.Appearance.ViewCaption.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(12)))), ((int)(((byte)(36)))), ((int)(((byte)(97)))));
            this.gridView1.Appearance.ViewCaption.BackColor2 = System.Drawing.Color.FromArgb(((int)(((byte)(96)))), ((int)(((byte)(163)))), ((int)(((byte)(188)))));
            this.gridView1.Appearance.ViewCaption.Font = new System.Drawing.Font("Lucida Console", 11.25F);
            this.gridView1.Appearance.ViewCaption.Options.UseBackColor = true;
            this.gridView1.Appearance.ViewCaption.Options.UseFont = true;
            this.gridView1.GridControl = this.gridControl1;
            this.gridView1.Name = "gridView1";
            this.gridView1.OptionsBehavior.AutoSelectAllInEditor = false;
            this.gridView1.OptionsBehavior.Editable = false;
            this.gridView1.OptionsBehavior.SmartVertScrollBar = false;
            this.gridView1.OptionsCustomization.AllowFilter = false;
            this.gridView1.OptionsFilter.AllowMRUFilterList = false;
            this.gridView1.OptionsMenu.EnableColumnMenu = false;
            this.gridView1.OptionsView.ShowColumnHeaders = false;
            this.gridView1.OptionsView.ShowGroupPanel = false;
            this.gridView1.OptionsView.ShowIndicator = false;
            // 
            // simpleButton2
            // 
            this.simpleButton2.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(82)))), ((int)(((byte)(221)))));
            this.simpleButton2.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton2.Appearance.Options.UseBackColor = true;
            this.simpleButton2.Appearance.Options.UseFont = true;
            this.simpleButton2.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton2.ImageOptions.Image")));
            this.simpleButton2.Location = new System.Drawing.Point(8, 127);
            this.simpleButton2.Name = "simpleButton2";
            this.simpleButton2.Size = new System.Drawing.Size(229, 30);
            this.simpleButton2.TabIndex = 5;
            this.simpleButton2.Text = "Çık";
            this.simpleButton2.Click += new System.EventHandler(this.simpleButton2_Click);
            // 
            // simpleButton3
            // 
            this.simpleButton3.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(82)))), ((int)(((byte)(221)))));
            this.simpleButton3.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.simpleButton3.Appearance.Options.UseBackColor = true;
            this.simpleButton3.Appearance.Options.UseFont = true;
            this.simpleButton3.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("simpleButton3.ImageOptions.Image")));
            this.simpleButton3.Location = new System.Drawing.Point(264, 127);
            this.simpleButton3.Name = "simpleButton3";
            this.simpleButton3.Size = new System.Drawing.Size(281, 30);
            this.simpleButton3.TabIndex = 4;
            this.simpleButton3.Text = "Yeni Sorgu";
            this.simpleButton3.Click += new System.EventHandler(this.simpleButton3_Click);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.simpleButton2);
            this.panel3.Controls.Add(this.panel2);
            this.panel3.Controls.Add(this.simpleButton3);
            this.panel3.Location = new System.Drawing.Point(3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(548, 171);
            this.panel3.TabIndex = 58;
            // 
            // FKredi
            // 
            this.AcceptButton = this.BSave2;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.CancelButton = this.simpleButton1;
            this.ClientSize = new System.Drawing.Size(555, 183);
            this.Controls.Add(this.panel3);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "FKredi";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "KREDİ SORGULA";
            this.Load += new System.EventHandler(this.FKredi_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.gridControl1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.gridView1)).EndInit();
            this.panel3.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private DevExpress.XtraEditors.SimpleButton BSave2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton simpleButton1;
        private System.Windows.Forms.Panel panel2;
        private DevExpress.XtraGrid.GridControl gridControl1;
        protected DevExpress.XtraGrid.Views.Grid.GridView gridView1;
        private System.Windows.Forms.TextBox TTc;
        private DevExpress.XtraEditors.SimpleButton simpleButton2;
        private DevExpress.XtraEditors.SimpleButton simpleButton3;
        private System.Windows.Forms.Panel panel3;
    }
}