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

namespace Aplikasi_Kasir
{
    public partial class FormTransJual : Form
    {
        Koneksi konn = new Koneksi();
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rd;
        void KondisiAwal()
        {
            LBLHarga.Text = "";
            //LBLNamaKasir.Text = "";
            LBLNamaBarang.Text = "";
            LBLHarga.Text = "";
            LBLKembali.Text = "";
            textBox1.Text = "";
            textBox2.Text = "";
            //LBLItem.Text = "";
            LBLTotal.Text = "";
            LblTanggal.Text = ""; DateTime.Now.ToString("dd-mm-yyyy");
        }
        void BuatKolom()
        {
            dataGridView1.Columns.Clear();
            dataGridView1.Columns.Add("Kodebarang","Kode barang");
            dataGridView1.Columns.Add("namabarang", "Nama barang");
        }
        public FormTransJual()
        {
            InitializeComponent();
        }

        private void FormTransJual_Load(object sender, EventArgs e)
        {
            KondisiAwal();
            BuatKolom();
        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
