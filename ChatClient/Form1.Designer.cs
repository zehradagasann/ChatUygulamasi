namespace ChatClient
{
    partial class Form1
    {
        /// <summary>
        ///Gerekli tasarımcı değişkeni.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///Kullanılan tüm kaynakları temizleyin.
        /// </summary>
        ///<param name="disposing">yönetilen kaynaklar dispose edilmeliyse doğru; aksi halde yanlış.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer üretilen kod

        /// <summary>
        /// Tasarımcı desteği için gerekli metot - bu metodun 
        ///içeriğini kod düzenleyici ile değiştirmeyin.
        /// </summary>
        private void InitializeComponent()
        {
            this.label1 = new System.Windows.Forms.Label();
            this.txtIp = new System.Windows.Forms.TextBox();
            this.ltxtPort = new System.Windows.Forms.Label();
            this.txtKullaniciAdi = new System.Windows.Forms.TextBox();
            this.btnBaglan = new System.Windows.Forms.Button();
            this.rtbMesajlar = new System.Windows.Forms.RichTextBox();
            this.txtMesaj = new System.Windows.Forms.TextBox();
            this.btnGonder = new System.Windows.Forms.Button();
            this.txtPort = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(79, 40);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(87, 20);
            this.label1.TabIndex = 0;
            this.label1.Text = "Sunucu IP:";
            // 
            // txtIp
            // 
            this.txtIp.Location = new System.Drawing.Point(83, 93);
            this.txtIp.Name = "txtIp";
            this.txtIp.Size = new System.Drawing.Size(100, 26);
            this.txtIp.TabIndex = 1;
            this.txtIp.Text = "127.0.0.1";
            // 
            // ltxtPort
            // 
            this.ltxtPort.AutoSize = true;
            this.ltxtPort.Location = new System.Drawing.Point(114, 162);
            this.ltxtPort.Name = "ltxtPort";
            this.ltxtPort.Size = new System.Drawing.Size(45, 20);
            this.ltxtPort.TabIndex = 2;
            this.ltxtPort.Text = "8888";
            // 
            // txtKullaniciAdi
            // 
            this.txtKullaniciAdi.Location = new System.Drawing.Point(309, 93);
            this.txtKullaniciAdi.Name = "txtKullaniciAdi";
            this.txtKullaniciAdi.Size = new System.Drawing.Size(166, 26);
            this.txtKullaniciAdi.TabIndex = 3;
            // 
            // btnBaglan
            // 
            this.btnBaglan.Location = new System.Drawing.Point(309, 133);
            this.btnBaglan.Name = "btnBaglan";
            this.btnBaglan.Size = new System.Drawing.Size(131, 49);
            this.btnBaglan.TabIndex = 4;
            this.btnBaglan.Text = "Bağlan";
            this.btnBaglan.UseVisualStyleBackColor = true;
            this.btnBaglan.Click += new System.EventHandler(this.btnBaglan_Click);
            // 
            // rtbMesajlar
            // 
            this.rtbMesajlar.Location = new System.Drawing.Point(340, 223);
            this.rtbMesajlar.Name = "rtbMesajlar";
            this.rtbMesajlar.Size = new System.Drawing.Size(100, 96);
            this.rtbMesajlar.TabIndex = 5;
            this.rtbMesajlar.Text = "";
            // 
            // txtMesaj
            // 
            this.txtMesaj.Location = new System.Drawing.Point(537, 105);
            this.txtMesaj.Name = "txtMesaj";
            this.txtMesaj.Size = new System.Drawing.Size(220, 26);
            this.txtMesaj.TabIndex = 6;
            // 
            // btnGonder
            // 
            this.btnGonder.Enabled = false;
            this.btnGonder.Location = new System.Drawing.Point(537, 162);
            this.btnGonder.Name = "btnGonder";
            this.btnGonder.Size = new System.Drawing.Size(149, 53);
            this.btnGonder.TabIndex = 7;
            this.btnGonder.Text = "Gönder";
            this.btnGonder.UseVisualStyleBackColor = true;
            this.btnGonder.Click += new System.EventHandler(this.btnGonder_Click);
            // 
            // txtPort
            // 
            this.txtPort.Location = new System.Drawing.Point(525, 271);
            this.txtPort.Name = "txtPort";
            this.txtPort.Size = new System.Drawing.Size(100, 26);
            this.txtPort.TabIndex = 8;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtPort);
            this.Controls.Add(this.btnGonder);
            this.Controls.Add(this.txtMesaj);
            this.Controls.Add(this.rtbMesajlar);
            this.Controls.Add(this.btnBaglan);
            this.Controls.Add(this.txtKullaniciAdi);
            this.Controls.Add(this.ltxtPort);
            this.Controls.Add(this.txtIp);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIp;
        private System.Windows.Forms.Label ltxtPort;
        private System.Windows.Forms.TextBox txtKullaniciAdi;
        private System.Windows.Forms.Button btnBaglan;
        private System.Windows.Forms.RichTextBox rtbMesajlar;
        private System.Windows.Forms.TextBox txtMesaj;
        private System.Windows.Forms.Button btnGonder;
        private System.Windows.Forms.TextBox txtPort;
    }
}

