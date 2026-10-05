using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdoUsing_Services5_10
{
    public class EmployeeServices
    {
        public string AddEmployee(Employee e)
        {
            string result = " ";
            using (SqlConnection con = new SqlConnection(Connection.connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"insert into employee (Employee_Name,designation,salary) values ('{e.name}','{e.designation}',{e.salary})", con);
                int cnt=cmd.ExecuteNonQuery();
                if(cnt > 0 )
                {
                    result = "Employee Added Successfully";
                }
                else
                {
                    result = "Error!! Please Try Again";
                }
            }
            return result;

        }
        public string UpdateEmployee(Employee e)
        {
            string result = " ";
            using (SqlConnection con = new SqlConnection(Connection.connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"update employee set Employee_Name='{e.name}',designation='{e.designation}',salary={e.salary} where ID={e.id}", con);
                int cnt=cmd.ExecuteNonQuery();
                if( cnt > 0 )
                {
                    result = "Employee Update successfully";
                }
                else
                {
                    result = "Error!! Please Try Again";
                }
            }

            return result;
        }
       public string DeleteEmployee(Employee e)
        {
            string result = " ";
            using (SqlConnection con = new SqlConnection(Connection.connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"delete from employee where ID='{e.id}'", con);
                int cnt=cmd.ExecuteNonQuery();
                if(cnt>0)
                {
                    result = "Employee Deleted Successfully";
                }
                else
                {
                    result = "Error!! Please Try Again";
                }

            }
            return result;

        }
        public List<Employee> GetEmployees()
        {
            List<Employee>lst=new List<Employee> ();
            using (SqlConnection con = new SqlConnection(Connection.connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select ID,Employee_Name,designation,salary from employee", con);
                SqlDataReader dr=cmd.ExecuteReader();
                while(dr.Read())
                {
                    Employee e = new Employee()
                    {
                        id = Convert.ToInt32(dr["ID"].ToString()),
                        name = dr["Employee_Name"].ToString(),
                        designation = dr["designation"].ToString(),
                        salary = (float)Convert.ToDouble(dr["salary"].ToString())
                        
                    };
                    lst.Add(e);
                }

            }
            return lst;

        }
        public Employee GetEmployeeByID(int id)
        {
            Employee e = null;
            using(SqlConnection con=new SqlConnection(Connection.connectionstring))
            {
                con.Open();
                SqlCommand cmd = new SqlCommand($"select ID,Employee_Name,designation,salary from employee where ID={id}", con);
                SqlDataReader dr=cmd.ExecuteReader();
                if(dr.Read())
                {
                    e = new Employee()
                    {
                        id= Convert.ToInt32(dr["ID"].ToString()),
                        name = dr["Employee_Name"].ToString(),
                        designation = dr["designation"].ToString(),
                        salary = (float)Convert.ToDouble(dr["salary"].ToString())
                    };
                }
                
            }
            return e;
        }
    }
}
