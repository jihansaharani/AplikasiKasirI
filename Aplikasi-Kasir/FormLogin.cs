using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
//3
using System.Data.SqlClient;

namespace Aplikasi_Kasir
{
    public partial class FormLogin : Form
    {
        //4
        private SqlCommand cmd;
        //private DataSet ds;
        //private SqlDataAdapter da;
        //private SqlDataReader rd;
        //5


        public FormLogin()
        {
            InitializeComponent();
        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlDataReader reader = null;
            Koneksi Konn = new Koneksi();
            SqlConnection conn = Konn.GetConn();
            {
                conn.Open();
                cmd = new SqlCommand("select * from TBL_KASIR where KodeKasir='" + textBox1.Text + "' and PasswordKasir='" +
                textBox2.Text + "'", conn);
                cmd.ExecuteNonQuery();
                reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    
                    FormMenuUtama.menu.menuLogin.Enabled = false;
                    FormMenuUtama.menu.menuLogout.Enabled = true;
                    FormMenuUtama.menu.menuMaster.Enabled = true;
                    FormMenuUtama.menu.menuTransaksi.Enabled = true;
                    FormMenuUtama.menu.menuLaporan.Enabled = true;
                    FormMenuUtama.menu.menuUtility.Enabled = true;
                    //FormMenuUtama frmUtama = new FormMenuUtama();
                    //frmUtama.Show();

                    this.Close();
                }
                {
                    MessageBox.Show("salah bro");
                }
            }

            //if (textBox1.Text == "KSR001" && textBox2.Text == "admin")
            //{
            //    FormMenuUtama frmUtama = new FormMenuUtama();
            //    frmUtama.Show();
            //    this.Hide();
            //} 
            //else
            //{
            //    MessageBox.Show("salah bro");
            //}
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void FormLogin_Load(object sender, EventArgs e)
        {
            textBox2.PasswordChar = 'x';
            textBox1.Text = "KSR001";
            textBox2.Text = "ADMIN";
        }
    }
}
