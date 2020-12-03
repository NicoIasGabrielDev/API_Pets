using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace APIPETS.Context
{
    public class TipoPetsContext
    {
        SqlConnection con = new SqlConnection();
        public TipoPetsContext()
        {
            con.ConnectionString = @"Data Source=DESKTOP-TI3871K\SQLEXPRESS;Initial Catalog=Pets;Persist Security Info=True;User ID=sa;Password=sa132";
        }

        public SqlConnection Conectar()
        {
            if (con.State == System.Data.ConnectionState.Closed)
            {
                con.Open();
            }
            return con;
        }
        public void Desconectar()
        {
            if (con.State == System.Data.ConnectionState.Open)
            {
                con.Close();
            }
        }
    }

}