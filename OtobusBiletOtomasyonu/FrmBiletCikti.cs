using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace OtobusBiletOtomasyonu
{
    public partial class FrmBiletCikti : Form
    {
        
        public FrmBiletCikti(string adSoyad, string tc, string sefer, string koltuk, string tarih)
        {
            InitializeComponent();

            
            lblAdSoyad.Text = adSoyad;
            lblTC.Text = tc;
            lblSeferBilgisi.Text = sefer;
            lblKoltukNo.Text = koltuk;
            lblTarih.Text = tarih;
        }

        
        private void FrmBiletCikti_DoubleClick(object sender, EventArgs e)
        {
            this.Close();
        }
        private void FrmBiletCikti_Load(object sender, EventArgs e)
        {
        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {
        }
    }
}