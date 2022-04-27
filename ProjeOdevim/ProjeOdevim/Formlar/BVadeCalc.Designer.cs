namespace ProjeOdevim.Formlar
{
    partial class BVadeCalc
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(BVadeCalc));
            this.panel1 = new System.Windows.Forms.Panel();
            this.BCik = new DevExpress.XtraEditors.SimpleButton();
            this.BHesapla = new DevExpress.XtraEditors.SimpleButton();
            this.LTaksit = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.CmbTaksit = new System.Windows.Forms.ComboBox();
            this.TMiktar = new DevExpress.XtraEditors.TextEdit();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TMiktar.Properties)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.LightSlateGray;
            this.panel1.Controls.Add(this.BCik);
            this.panel1.Controls.Add(this.BHesapla);
            this.panel1.Controls.Add(this.LTaksit);
            this.panel1.Controls.Add(this.label1);
            this.panel1.Controls.Add(this.CmbTaksit);
            this.panel1.Controls.Add(this.TMiktar);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(482, 133);
            this.panel1.TabIndex = 134;
            // 
            // BCik
            // 
            this.BCik.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(82)))), ((int)(((byte)(221)))));
            this.BCik.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BCik.Appearance.Options.UseBackColor = true;
            this.BCik.Appearance.Options.UseFont = true;
            this.BCik.DialogResult = System.Windows.Forms.DialogResult.Cancel;
            this.BCik.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BCik.ImageOptions.Image")));
            this.BCik.Location = new System.Drawing.Point(204, 80);
            this.BCik.Name = "BCik";
            this.BCik.Size = new System.Drawing.Size(124, 30);
            this.BCik.TabIndex = 138;
            this.BCik.Text = "Çık";
            this.BCik.Click += new System.EventHandler(this.BCik_Click);
            // 
            // BHesapla
            // 
            this.BHesapla.Appearance.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(6)))), ((int)(((byte)(82)))), ((int)(((byte)(221)))));
            this.BHesapla.Appearance.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.BHesapla.Appearance.Options.UseBackColor = true;
            this.BHesapla.Appearance.Options.UseFont = true;
            this.BHesapla.ImageOptions.Image = ((System.Drawing.Image)(resources.GetObject("BHesapla.ImageOptions.Image")));
            this.BHesapla.Location = new System.Drawing.Point(334, 80);
            this.BHesapla.Name = "BHesapla";
            this.BHesapla.Size = new System.Drawing.Size(116, 30);
            this.BHesapla.TabIndex = 137;
            this.BHesapla.Text = "Hesapla";
            this.BHesapla.Click += new System.EventHandler(this.BHesapla_Click);
            // 
            // LTaksit
            // 
            this.LTaksit.AutoSize = true;
            this.LTaksit.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.LTaksit.ForeColor = System.Drawing.Color.White;
            this.LTaksit.Location = new System.Drawing.Point(43, 17);
            this.LTaksit.Name = "LTaksit";
            this.LTaksit.Size = new System.Drawing.Size(155, 19);
            this.LTaksit.TabIndex = 129;
            this.LTaksit.Text = "Vade Sayısı (AY) :";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(133, 51);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 19);
            this.label1.TabIndex = 132;
            this.label1.Text = "Tutar :";
            // 
            // CmbTaksit
            // 
            this.CmbTaksit.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.CmbTaksit.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.CmbTaksit.FormattingEnabled = true;
            this.CmbTaksit.Items.AddRange(new object[] {
            "3",
            "6",
            "9",
            "12",
            "15",
            "18",
            "24",
            "36"});
            this.CmbTaksit.Location = new System.Drawing.Point(204, 15);
            this.CmbTaksit.Name = "CmbTaksit";
            this.CmbTaksit.Size = new System.Drawing.Size(246, 27);
            this.CmbTaksit.TabIndex = 130;
            // 
            // TMiktar
            // 
            this.TMiktar.Location = new System.Drawing.Point(204, 48);
            this.TMiktar.Name = "TMiktar";
            this.TMiktar.Properties.Appearance.BackColor = System.Drawing.Color.White;
            this.TMiktar.Properties.Appearance.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.TMiktar.Properties.Appearance.ForeColor = System.Drawing.Color.Black;
            this.TMiktar.Properties.Appearance.Options.UseBackColor = true;
            this.TMiktar.Properties.Appearance.Options.UseFont = true;
            this.TMiktar.Properties.Appearance.Options.UseForeColor = true;
            this.TMiktar.Properties.AppearanceDisabled.BackColor = System.Drawing.Color.White;
            this.TMiktar.Properties.AppearanceDisabled.Options.UseBackColor = true;
            this.TMiktar.Properties.AppearanceFocused.BackColor = System.Drawing.Color.Cyan;
            this.TMiktar.Properties.AppearanceFocused.Options.UseBackColor = true;
            this.TMiktar.Properties.AppearanceReadOnly.BackColor = System.Drawing.Color.Cyan;
            this.TMiktar.Properties.AppearanceReadOnly.Options.UseBackColor = true;
            this.TMiktar.Size = new System.Drawing.Size(246, 26);
            this.TMiktar.TabIndex = 131;
            this.TMiktar.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.TMiktarGir_KeyPress);
            // 
            // BVadeCalc
            // 
            this.AcceptButton = this.BHesapla;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.CancelButton = this.BCik;
            this.ClientSize = new System.Drawing.Size(482, 133);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "BVadeCalc";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VADE HESAPLA";
            this.Load += new System.EventHandler(this.BVadeCalc_Load);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.TMiktar.Properties)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private DevExpress.XtraEditors.SimpleButton BCik;
        private DevExpress.XtraEditors.SimpleButton BHesapla;
        private System.Windows.Forms.Label LTaksit;
        private System.Windows.Forms.Label label1;
        private DevExpress.XtraEditors.TextEdit TMiktar;
        public System.Windows.Forms.ComboBox CmbTaksit;
    }
}