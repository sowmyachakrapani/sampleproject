using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;
using System.Data.Sql;
using System.Data.SqlClient;

namespace TestforEnergyOnline
{
    public class Db
    {
        SqlConnection con = null;
        SqlCommand cmd = null;
        public Db()
        {
            con = new SqlConnection(@"Data Source=JAYA-CHAKRAPANI;Initial Catalog=DbCompany;Integrated Security=True");
            con.Open();
            cmd = new SqlCommand();
            cmd.Connection = con;
        }

        public void SaveEmployees(string ename, string job, string sal)
        {
            cmd.CommandText = "StoreEmployees";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ename", ename);
            cmd.Parameters.AddWithValue("@job", job);
            cmd.Parameters.AddWithValue("@sal", sal);
            cmd.ExecuteNonQuery();
        }


        public DataTable fetch(string tabname)
        {
            string sql1 = string.Format("select * from {0}", tabname);
            SqlDataAdapter adap = new SqlDataAdapter(sql1, con);
            DataTable buffer = new DataTable();
            adap.Fill(buffer);
            return buffer;
        }

        public bool DoTransaction(string query)
        {
            SqlCommand cmds = new SqlCommand(query, con);
            int count = cmds.ExecuteNonQuery();
            if (count == 0)
            {
                return false;
            }
            else
            {
                return true;
            }
        }



        
    }
}