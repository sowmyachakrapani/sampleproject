using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.SqlClient;
using System.Data;

namespace EnergyOnlineBusinessLogic.Items
{
    public class EmployeeList : List<Employee>
    {
        public EmployeeList()
        {

        }

        public EmployeeList getAllEmployees()
        {
            return Fetch();
        }

        public void SaveEmployee(string ename, string job, string sal)
        {
            Insert(ename, job,  sal);
        }

        private EmployeeList Fetch()
        {
            SqlCommand cmd = null;
            String strSQL = "SELECT * FROM Employee";
            SqlConnection cnn = null;
            SqlDataReader sdr = null;
            Employee emp = null;
            try
            { // Open the connection.
                cnn = new SqlConnection(@"Data Source=JAYA-CHAKRAPANI;Initial Catalog=DbCompany;Integrated Security=True");
                cnn.Open();
                // Open the Command and execute the DataReader.
                cmd = new SqlCommand(strSQL, cnn);
                sdr = cmd.ExecuteReader(CommandBehavior.CloseConnection);
                // Retrieve the data and insert into new rows.
                while (sdr.Read())
                {
                    emp = new Employee(sdr["Salary"].ToString());
                    emp.Name = sdr["EmpName"].ToString();
                    emp.ID = sdr["EmpNo"].ToString();
                    emp.JobTitle = sdr["Job"].ToString();
                    this.Add(emp);
                
                }
                return this;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (sdr != null)
                {
                    sdr.Close();
                }
            }
        }

        private void Insert(string ename, string job, string sal)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "StoreEmployees";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@ename", ename);
            cmd.Parameters.AddWithValue("@job", job);
            cmd.Parameters.AddWithValue("@sal", sal);

            SqlConnection cnn = null;
            try
            { // Open the connection.
                cnn = new SqlConnection(@"Data Source=JAYA-CHAKRAPANI;Initial Catalog=DbCompany;Integrated Security=True");
                cmd.Connection = cnn;
                cnn.Open();   // Open the Command and execute
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }
        }

        public void UpdateEmployee(string ename, string job, string sal, int empNo)
        {
            Update(ename, job,  sal, empNo);
        }

        private void Update(string ename, string job, string sal, int empn)
        {
            SqlCommand cmd = new SqlCommand();
            cmd.CommandText = "UPDATEEMPLOYEE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@empno", empn);
            cmd.Parameters.AddWithValue("@ename", ename);
            cmd.Parameters.AddWithValue("@job", job);
            cmd.Parameters.AddWithValue("@salary", sal);
            SqlConnection cnn = null;
            try
            { // Open the connection.
                cnn = new SqlConnection(@"Data Source=JAYA-CHAKRAPANI;Initial Catalog=DbCompany;Integrated Security=True");
                cmd.Connection = cnn;
                cnn.Open();
                // Open the Command and execute
                cmd.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                if (cnn != null)
                {
                    cnn.Close();
                }
            }
         
        }
    }
}