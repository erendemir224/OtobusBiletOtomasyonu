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


namespace OtobusBiletOtomasyonu
{
   
    public partial class FrmOtobusler : Form
    {
        public FrmOtobusler()
        {
            InitializeComponent();
        }
        SqlBaglanti bgl = new SqlBaglanti();
        void Listele()
        {
            DataTable dt = new DataTable();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Otobusler", bgl.baglanti());
            da.Fill(dt);
            dataGridView1.DataSource = dt;
        }
        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void FrmOtobusler_Load(object sender, EventArgs e)
        {
            Listele();
        }

        private void btnKaydet_Click(object sender, EventArgs e)
        {
            SqlCommand komut = new SqlCommand("INSERT INTO Otobusler (Plaka, Marka, KoltukSayisi) VALUES (@p1, @p2, @p3)", bgl.baglanti());
            komut.Parameters.AddWithValue("@p1", txtPlaka.Text);
            komut.Parameters.AddWithValue("@p2", txtMarka.Text);
            komut.Parameters.AddWithValue("@p3", cmbKoltuk.Text);

            komut.ExecuteNonQuery(); 
            bgl.baglanti().Close();  

            MessageBox.Show("Otobüs sisteme başarıyla eklendi!", "Bilgi", MessageBoxButtons.OK, MessageBoxIcon.Information);

            Listele(); 
        }
    }
}
