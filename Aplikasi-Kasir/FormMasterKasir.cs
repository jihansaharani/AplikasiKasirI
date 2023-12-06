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
    public partial class FormMasterKasir : Form
    {
        Koneksi konn = new Koneksi();
        private SqlCommand cmd;
        private DataSet ds;
        private SqlDataAdapter da;
        private SqlDataReader rd;
        void munculLevel()
        {
            comboBox1.Items.Add("ADMIN");
            comboBox1.Items.Add("USER");
        }
        void KondisiAwal()
        {
            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            comboBox1.Text = "";
            munculLevel();
            MunculDataKasir();
        }

        public FormMasterKasir()
        {
            InitializeComponent();
        }

        private void FormMasterKasir_Load(object sender, EventArgs e)
        {
            KondisiAwal();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        void MunculDataKasir()
        {
            SqlConnection conn = konn.GetConn();
            conn.Open();
            cmd = new SqlCommand("select * from TBL_KASIR",conn);
            ds = new DataSet();
            da = new SqlDataAdapter(cmd);
            da.Fill(ds, "TBL_KASIR");
            dataGridView1.DataSource = ds;
            dataGridView1.DataMember = "TBL_KASIR";
            dataGridView1.AllowUserToAddRows = false;
            dataGridView1.Refresh();
        }
        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
             if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua Form Terisi!");
            }
            else
            {
                SqlConnection conn = konn.GetConn();          
                cmd = new SqlCommand("insert into TBL_KASIR values ('"+ textBox1.Text + "', '" + textBox2.Text + "','" + textBox3.Text + "', '" + comboBox1.Text + "')",conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di Input");
                KondisiAwal();
            }
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == Convert.ToChar(Keys.Enter))
            {
                SqlConnection conn = konn.GetConn();
                cmd = new SqlCommand("select * from TBL_KASIR where KodeKasir='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                rd = cmd.ExecuteReader();
                if (rd.Read())
                {
                    textBox1.Text = rd[0].ToString();
                    textBox2.Text = rd[1].ToString();
                    textBox3.Text = rd[2].ToString();
                    comboBox1.Text = rd[3].ToString();
                }
                else
                {
                    MessageBox.Show("Data tidak ada!");
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua Form Terisi!");
            }
            else
            {
                SqlConnection conn = konn.GetConn();
                SqlCommand cmd = new SqlCommand("UPDATE TBL_KASIR SET NamaKasir = @NamaKasir, PasswordKasir = @PasswordKasir, levelkasir = @LevelKasir WHERE KodeKasir = @KodeKasir", conn);

                // Menggunakan parameter untuk mencegah SQL injection
                cmd.Parameters.AddWithValue("@NamaKasir", textBox2.Text);
                cmd.Parameters.AddWithValue("@PasswordKasir", textBox3.Text);
                cmd.Parameters.AddWithValue("@LevelKasir", comboBox1.Text);
                cmd.Parameters.AddWithValue("@KodeKasir", textBox1.Text);

                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di Edit");
                KondisiAwal();
                conn.Close(); 
            }

        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text.Trim() == "" || textBox2.Text.Trim() == "" || textBox3.Text.Trim() == "" || comboBox1.Text.Trim() == "")
            {
                MessageBox.Show("Pastikan semua Form Terisi!");
            }
            else
            {
                SqlConnection conn = konn.GetConn();
                cmd = new SqlCommand("delete TBL_KASIR where KodeKasir='" + textBox1.Text + "'", conn);
                conn.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("Data berhasil di Hapus");
                KondisiAwal();
            }
        }
    }
}
