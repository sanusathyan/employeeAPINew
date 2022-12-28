using EmployeeMvcNew.Models;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace EmployeeMvcNew.EmpRepository
{
    public class EmployeeRepository
    {
        private readonly SqlConnection _sqlconnection;
        public EmployeeRepository()
        {
            var connectionString = "data source = (localdb)\\mssqllocaldb; database = traindb";

            _sqlconnection = new SqlConnection(connectionString);
        }

        public IEnumerable<Employee> GetEmployees()
        {
            try
            {
                _sqlconnection.Open();

                var sqlCommand = new SqlCommand("select * from employee", _sqlconnection);

                var sqlDataReader = sqlCommand.ExecuteReader();

                var employees = new List<Employee>();

                while (sqlDataReader.Read())
                {
                    var id = (int)sqlDataReader["id"];
                    var name = (string)sqlDataReader["Empname"];
                    var age = (int)sqlDataReader["age"];
                    var salary = (int)sqlDataReader["salary"];

                    employees.Add(new Employee
                    {
                        Id = id,
                        Name = name,
                        Age = age,
                        Salary = salary
                    }); ;
                }
                return employees;

            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _sqlconnection.Close();
            }
        }

        public Employee GetEmployeeById(int emp_id)
        {
            try
            {
                _sqlconnection.Open();

                var sqlCommand = new SqlCommand("select * from employee where id=@id", _sqlconnection);

                sqlCommand.Parameters.AddWithValue("id", emp_id);

                var sqlDataRead = sqlCommand.ExecuteReader();

                var employeeList = new List<Employee>();

                while (sqlDataRead.Read())
                {
                    employeeList.Add(new Employee
                    {
                        Id = (int)sqlDataRead["id"],
                        Name = (string)sqlDataRead["Empname"],
                        Age = (int)sqlDataRead["age"],
                        Salary = (int)sqlDataRead["salary"],
                    });
                }

                return employeeList.FirstOrDefault();
            }
            catch
            {
                throw;
            }
            finally
            {
                _sqlconnection.Close();
            }
        }

        public bool InsertEmployee(Employee employee)
        {
            try
            {
                _sqlconnection.Open();
                var sqlCommand = new SqlCommand("insert into employee values(@name, @age, @salary)", _sqlconnection);
                sqlCommand.Parameters.AddWithValue("name", employee.Name);
                sqlCommand.Parameters.AddWithValue("age", employee.Age);
                sqlCommand.Parameters.AddWithValue("salary", employee.Salary);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _sqlconnection.Close();
            }
        }

        public bool UpdateEmployee(Employee employee)
        {
            try
            {
                _sqlconnection.Open();
                var sqlCommand = new SqlCommand("update employee set Empname= @name,age=@age,salary=@salary where id=@id", _sqlconnection);
                sqlCommand.Parameters.AddWithValue("name", employee.Name);
                sqlCommand.Parameters.AddWithValue("age", employee.Age);
                sqlCommand.Parameters.AddWithValue("salary", employee.Salary);
                sqlCommand.Parameters.AddWithValue("id", employee.Id);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _sqlconnection.Close();
            }
        }

        public bool DeleteEmployee(int id)
        {
            try
            {
                _sqlconnection.Open();
                var sqlCommand = new SqlCommand("delete from employee where id = @id", _sqlconnection);
                sqlCommand.Parameters.AddWithValue("id", id);
                sqlCommand.ExecuteNonQuery();
                return true;
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _sqlconnection.Close();
            }
        }
    }
}
