using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Model;

namespace DAL
{
    public class AuthDao : BaseDao
    {
        public bool Authenticate(string username, string password)
        {
            string sqlQuery = "SELECT COUNT(*) FROM Employee WHERE Username = @Username AND Password = @Password";
            int result = ExecuteScalar<int>(sqlQuery, command =>
            {
                command.Parameters.AddWithValue("@Username", username);
                command.Parameters.AddWithValue("@Password", password);
            });

            return result > 0;
        }

        public bool CheckUsernameExists(string username)
        {
            string sqlQuery = "SELECT COUNT(*) FROM Employee WHERE Username = @Username";
            int result = ExecuteScalar<int>(sqlQuery, command =>
            {
                command.Parameters.AddWithValue("@Username", username);
            });

            return result > 0;
        }

        public Employee GetEmployeeByUsername(string username)
        {
            string sqlQuery = "SELECT Employee_Id, Employee_Name, User_Type FROM Employee WHERE Username = @Username";
            Employee employee = null;
            SqlDataReader reader = ExecuteReader(sqlQuery, command =>
            {
                command.Parameters.AddWithValue("@Username", username);
            });

            if (reader.Read())
            {
                employee = Employee.GetInstance();
                employee.EmployeeName = (string)reader["Employee_Name"];
                employee.EmployeeId = (int)reader["Employee_Id"];
                employee.Username = username;

                string userTypeString = (string)reader["User_Type"];
                if (Enum.TryParse(userTypeString, out UserType userType))
                {
                    employee.UserType = userType;
                }
                else
                {
                    employee.UserType = UserType.Waiter;                                                         
                }

            }

            reader.Close();
            return employee;
        }

        public Employee GetEmployeeById(int id)
        {
            string sqlQuery = "SELECT Employee_Id, Username, Employee_Name, User_Type FROM Employee WHERE Employee_Id = @EmployeeId";
            Employee employee = null;
            SqlDataReader reader = ExecuteReader(sqlQuery, command =>
            {
                command.Parameters.AddWithValue("@EmployeeId", id);
            });

            if (reader.Read())
            {
                employee = Employee.GetInstance();
                employee.EmployeeName = (string)reader["Employee_Name"];
                employee.EmployeeId = (int)reader["Employee_Id"];
                employee.Username = (string)reader["Username"];

                string userTypeString = (string)reader["User_Type"];
                if (Enum.TryParse(userTypeString, out UserType userType))
                {
                    employee.UserType = userType;
                }
                else
                {
                    employee.UserType = UserType.Waiter;
                }
            }

            reader.Close();
            return employee;
        }
    }
}

