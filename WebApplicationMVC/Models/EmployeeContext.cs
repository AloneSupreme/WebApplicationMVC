using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;

namespace WebApplicationMVC.Models
{
    public class EmployeeContext : DbContext
    {
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }

        public void AddEmployee(Employee employee)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("spAddEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                SqlParameter paramDepartmentId = new SqlParameter();
                paramDepartmentId.ParameterName = "@DepartmentId";
                paramDepartmentId.Value = employee.DepartmentId;
                cmd.Parameters.Add(paramDepartmentId);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }

        public void SaveEmployee(Employee employee)
        {
            string connectionstring = ConfigurationManager.ConnectionStrings["EmployeeContext"].ConnectionString;
            using (SqlConnection con = new SqlConnection(connectionstring))
            {
                SqlCommand cmd = new SqlCommand("spSaveEmployee", con);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlParameter paramId = new SqlParameter();
                paramId.ParameterName = "@EmployeeId";
                paramId.Value = employee.EmployeeId;
                cmd.Parameters.Add(paramId);

                SqlParameter paramName = new SqlParameter();
                paramName.ParameterName = "@Name";
                paramName.Value = employee.Name;
                cmd.Parameters.Add(paramName);

                SqlParameter paramGender = new SqlParameter();
                paramGender.ParameterName = "@Gender";
                paramGender.Value = employee.Gender;
                cmd.Parameters.Add(paramGender);

                SqlParameter paramCity = new SqlParameter();
                paramCity.ParameterName = "@City";
                paramCity.Value = employee.City;
                cmd.Parameters.Add(paramCity);

                SqlParameter paramDateOfBirth = new SqlParameter();
                paramDateOfBirth.ParameterName = "@DateOfBirth";
                paramDateOfBirth.Value = employee.DateOfBirth;
                cmd.Parameters.Add(paramDateOfBirth);

                SqlParameter paramDepartmentId = new SqlParameter();
                paramDepartmentId.ParameterName = "@DepartmentId";
                paramDepartmentId.Value = employee.DepartmentId;
                cmd.Parameters.Add(paramDepartmentId);

                con.Open();
                cmd.ExecuteNonQuery();

            }
        }
    }
}