namespace OtobusBiletOtomasyonu
{
    partial class AnaForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(AnaForm));
            this.btnBiletSatis = new System.Windows.Forms.Button();
            this.btnYolcular = new System.Windows.Forms.Button();
            this.btnSeferler = new System.Windows.Forms.Button();
            this.btnOtobusler = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnBiletSatis
            // 
            this.btnBiletSatis.Location = new System.Drawing.Point(442, 275);
            this.btnBiletSatis.Margin = new System.Windows.Forms.Padding(4);
            this.btnBiletSatis.Name = "btnBiletSatis";
            this.btnBiletSatis.Size = new System.Drawing.Size(179, 70);
            this.btnBiletSatis.TabIndex = 0;
            this.btnBiletSatis.Text = "Bilet Satış Ekranı";
            this.btnBiletSatis.UseVisualStyleBackColor = true;
            this.btnBiletSatis.Click += new System.EventHandler(this.btnBiletSatis_Click);
            // 
            // btnYolcular
            // 
            this.btnYolcular.Location = new System.Drawing.Point(78, 275);
            this.btnYolcular.Margin = new System.Windows.Forms.Padding(4);
            this.btnYolcular.Name = "btnYolcular";
            this.btnYolcular.Size = new System.Drawing.Size(179, 70);
            this.btnYolcular.TabIndex = 0;
            this.btnYolcular.Text = "Yolcu Kayıtları";
            this.btnYolcular.UseVisualStyleBackColor = true;
            this.btnYolcular.Click += new System.EventHandler(this.btnYolcular_Click);
            // 
            // btnSeferler
            // 
            this.btnSeferler.Location = new System.Drawing.Point(442, 108);
            this.btnSeferler.Margin = new System.Windows.Forms.Padding(4);
            this.btnSeferler.Name = "btnSeferler";
            this.btnSeferler.Size = new System.Drawing.Size(179, 70);
            this.btnSeferler.TabIndex = 0;
            this.btnSeferler.Text = "Sefer İşlemleri";
            this.btnSeferler.UseVisualStyleBackColor = true;
            this.btnSeferler.Click += new System.EventHandler(this.btnSeferler_Click);
            // 
            // btnOtobusler
            // 
            this.btnOtobusler.Location = new System.Drawing.Point(78, 108);
            this.btnOtobusler.Margin = new System.Windows.Forms.Padding(4);
            this.btnOtobusler.Name = "btnOtobusler";
            this.btnOtobusler.Size = new System.Drawing.Size(179, 70);
            this.btnOtobusler.TabIndex = 0;
            this.btnOtobusler.Text = "Otobüs İşlemleri";
            this.btnOtobusler.UseVisualStyleBackColor = true;
            this.btnOtobusler.Click += new System.EventHandler(this.btnOtobusler_Click);
            // 
            // AnaForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(11F, 24F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1073, 681);
            this.Controls.Add(this.btnBiletSatis);
            this.Controls.Add(this.btnYolcular);
            this.Controls.Add(this.btnSeferler);
            this.Controls.Add(this.btnOtobusler);
            this.Font = new System.Drawing.Font("Tahoma", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(162)));
            this.Margin = new System.Windows.Forms.Padding(4);
            this.Name = "AnaForm";
            this.Text = "AnaForm";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.Load += new System.EventHandler(this.AnaForm_Load);
            this.ResumeLayout(false);

        }

        #endregion
        private System.Windows.Forms.Button btnBiletSatis;
        private System.Windows.Forms.Button btnYolcular;
        private System.Windows.Forms.Button btnSeferler;
        private System.Windows.Forms.Button btnOtobusler;
    }
}