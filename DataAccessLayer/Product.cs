using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Models;

namespace DataAccessLayer
{
    public class Product
    {
        SqlConnection connection = new SqlConnection("Data Source=SEAN-NASIR\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
        public List<Products> AddProducts(int ProdID)
        {
            List<Products> ProductList = new List<Products>();
            connection.Open();
            var command = new SqlCommand("select Top 5 ProductID,ProductName,UnitPrice from Products where ProductID>@id Order By ProductID ASC", connection);
            command.Parameters.AddWithValue("@id", ProdID);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    Products Temp = new Products();
                    Temp.ProductId = reader.GetInt32(reader.GetOrdinal("Product ID"));
                    Temp.ProductName = reader.GetString(reader.GetOrdinal("ProductName"));
                    Temp.UnitPrice = reader.GetDecimal(reader.GetOrdinal("UnitPrice"));
                    ProductList.Add(Temp);
                }

                connection.Close();
                reader.Close();
            }
            catch (SqlException exception)
            {
                throw exception;
            }

            return ProductList;

        }

        public List<Employee> AddEmployees(int EmpID)
        {
            connection.Open();
            List<Employee> EmployeeList = new List<Employee>();
            var command_1 = new SqlCommand("select Top 5 EmployeeId,FirstName from Employees where EmployeeID>@id Order By EmployeeID ASC", connection);
            command_1.Parameters.AddWithValue("@id", EmpID);
            try
            {
                SqlDataReader sql_reader = command_1.ExecuteReader();
                while (sql_reader.Read())
                {
                    Employee Temp = new Employee();
                    Temp.EmployeeId = sql_reader.GetInt32(sql_reader.GetOrdinal("EmployeeID"));
                    Temp.FirstName = sql_reader.GetString(sql_reader.GetOrdinal("FirstName"));
                    EmployeeList.Add(Temp);
                }

                connection.Close();
                sql_reader.Close();
            }
            catch (Exception exception)
            {
                throw exception;
            }

            return EmployeeList;
        }

    }
}
