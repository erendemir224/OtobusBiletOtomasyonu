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
    public partial class AnaForm : Form
    {
        public AnaForm()
        {
            InitializeComponent();
        }

        private void btnOtobusler_Click(object sender, EventArgs e)
        {
            FrmOtobusler frm = new FrmOtobusler();
            frm.Show();
        }

        private void btnSeferler_Click(object sender, EventArgs e)
        {
            FrmSeferler frm = new FrmSeferler();
            frm.Show();
        }

        private void btnBiletSatis_Click(object sender, EventArgs e)
        {
            FrmBiletSatis frm = new FrmBiletSatis();
            frm.Show();
        }

        private void btnYolcular_Click(object sender, EventArgs e)
        {
            FrmYolcular frm = new FrmYolcular();
            frm.Show();
        }

        private void AnaForm_Load(object sender, EventArgs e)
        {
            if (FrmGiris.kullaniciRolu == "Memur")
            {
                btnOtobusler.Enabled = false;
                btnSeferler.Enabled = false;
                btnOtobusler.BackColor = Color.Gray;
                btnSeferler.BackColor = Color.Gray;
            }
        }
    }
}
