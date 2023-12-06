using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//1
using System.Data.SqlClient;

namespace Aplikasi_Kasir
{
    class Koneksi
    {
        //2
        public SqlConnection GetConn()
        {
            SqlConnection Conn = new SqlConnection();
            Conn.ConnectionString = "Data source=LAPTOP-LJ87ADGH;initial catalog=DB_APPKASIR;integrated security=true";
            return Conn;
        }
    }
}
