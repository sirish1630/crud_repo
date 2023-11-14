using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;

namespace crud_mvc.Models
{
    public class Employeebusinesslayer
    {
        public IEnumerable<Employee> Employees
        {
            get//AS IT IS A READ ONLY PROPERTY
            {
                string connectionstring = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;
                List<Employee> Employees = new List<Employee>();
                using (SqlConnection con = new SqlConnection(connectionstring))
                {
                    SqlCommand cmd = new SqlCommand("spgetallemployees", con);
                    cmd.CommandType = CommandType.StoredProcedure;
                    con.Open();
                    SqlDataReader rdr = cmd.ExecuteReader();
                    while (rdr.Read())
                    {
                        Employee emp = new Employee();
                        emp.id = Convert.ToInt32(rdr["id"]);
                        emp.empname = rdr["empname"].ToString();
                        emp.gender = rdr["gender"].ToString();
                        emp.city = rdr["city"].ToString();
                        Employees.Add(emp);
                    }

                }
                return Employees;
            }
        }
        public void Addemployee(Employee employee)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmnd = new SqlCommand("spaddemployee", con);
                cmnd.CommandType = CommandType.StoredProcedure;


                SqlParameter paramname = new SqlParameter();
                paramname.ParameterName = "@empname";
                paramname.Value = employee.empname;
                cmnd.Parameters.Add(paramname);

                SqlParameter paramgender = new SqlParameter();
                paramgender.ParameterName = "@gender";
                paramgender.Value = employee.gender;
                cmnd.Parameters.Add(paramgender);


                SqlParameter paramcity = new SqlParameter();
                paramcity.ParameterName = "@city";
                paramcity.Value = employee.city;
                cmnd.Parameters.Add(paramcity);

                con.Open();
                cmnd.ExecuteNonQuery();

            }
        }
        public void Savemployee(Employee employee)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmnd = new SqlCommand("spsaveemployee", con);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.Value = employee.id;
                cmnd.Parameters.Add(paramId);
                //cmnd.Parameters.Clear();


                SqlParameter paramname = new SqlParameter();
                paramname.ParameterName = "@empname";
                paramname.Value = employee.empname;
                cmnd.Parameters.Add(paramname);

                SqlParameter paramgender = new SqlParameter();
                paramgender.ParameterName = "@gender";
                paramgender.Value = employee.gender;
                cmnd.Parameters.Add(paramgender);


                SqlParameter paramcity = new SqlParameter();
                paramcity.ParameterName = "@city";
                paramcity.Value = employee.city;
                cmnd.Parameters.Add(paramcity);

                con.Open();
                cmnd.ExecuteNonQuery();

                con.Close();
            }
        }
        public void Deletemployee(int id)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["DBCS"].ConnectionString;

            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmnd = new SqlCommand("spdeleteemployee", con);
                cmnd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@id";
                paramId.Value = id;
                cmnd.Parameters.Add(paramId);

                con.Open();
                cmnd.ExecuteNonQuery();
            }
        }
    }
}