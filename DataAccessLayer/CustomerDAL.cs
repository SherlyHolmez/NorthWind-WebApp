using System.Data.SqlClient;
using Model;
using Models;

namespace DataAccessLayer
{
    public class CustomerDAL
    {
        Order orders = new Order();
        SqlConnection connection = new SqlConnection("Data Source=SEAN-NASIR\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
        public bool AddCustomer(string ID, string CompName, string CustName, string CustTitle, string Address)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into Customers(CustomerID, CompanyName, ContactName, ContactTitle, Address) values (@ID, @CompName, @CustName, @CustTitle, @Address)", connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@compname", CompName);
            command.Parameters.AddWithValue("@CustName", CustName);
            command.Parameters.AddWithValue("@CustTitle", CustTitle);
            command.Parameters.AddWithValue("@Address", Address);

            try
            {
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (SqlException exception)
            {
                throw exception;
            }
        }

        public bool EditCustomer(string ID, string CompName, string CustName, string CustTitle, string Address)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("update Customers set CompanyName=@compname, ContactName=@CustName, ContactTitle=@CustTitle, Address=@Address where CustomerID=@ID", connection);
            command.Parameters.AddWithValue("@ID", ID);
            command.Parameters.AddWithValue("@compname", CompName);
            command.Parameters.AddWithValue("@CustName", CustName);
            command.Parameters.AddWithValue("@CustTitle", CustTitle);
            command.Parameters.AddWithValue("@Address", Address);

            try
            {
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (SqlException exception)
            {
                throw exception;
            }
        }

        public bool DeleteCust(string ID)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("delete Customers where CustomerID=@id", connection);
            command.Parameters.AddWithValue("@id", ID);
            try
            {
                orders.DeleteOrderDetails(ID);
                orders.DeleteOrder(ID);
                command.ExecuteNonQuery();
                connection.Close();
                return true;
            }
            catch (SqlException exception)
            {
                throw exception;
            }
        }

        public Customer NextCustomer(string ID)
        {
            connection.Open();
            var Customer_next = new Customer();
            SqlCommand command = new SqlCommand("select top 1 CustomerID,CompanyName, ContactName,ContactTitle,Address from Customers where CustomerID>@id Order By CustomerID ASC", connection);
            command.Parameters.AddWithValue("@id", ID);
            try
            {
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    Customer_next.CustomerId = reader.GetString(reader.GetOrdinal("CustomerID"));
                    Customer_next.CompanyName = reader.GetString(reader.GetOrdinal("CompanyName"));
                    Customer_next.CustomerName = reader.GetString(reader.GetOrdinal("ContactName"));
                    Customer_next.CustomerTitle = reader.GetString(reader.GetOrdinal("ContactTitle"));
                    Customer_next.Address = reader.GetString(reader.GetOrdinal("Address"));
                }

                connection.Close();
                reader.Close();
            }
            catch (SqlException exception)
            {
                throw exception;
            }

            return Customer_next;
        }

        public Customer PrevCustomer(string ID)
        {
            connection.Open();
            var Previous_Customer = new Customer();
            SqlCommand command = new SqlCommand("select top 1 CustomerID,CompanyName, ContactName,ContactTitle,Address from Customers where CustomerID<@id Order By CustomerID DESC", connection);
            command.Parameters.AddWithValue("@id", ID);
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    Previous_Customer.CustomerId = reader.GetString(reader.GetOrdinal("CustomerID"));
                    Previous_Customer.CompanyName = reader.GetString(reader.GetOrdinal("CompanyName"));
                    Previous_Customer.CustomerName = reader.GetString(reader.GetOrdinal("ContactName"));
                    Previous_Customer.CustomerTitle = reader.GetString(reader.GetOrdinal("ContactTitle"));
                    Previous_Customer.Address = reader.GetString(reader.GetOrdinal("Address"));

                }

                connection.Close();
                reader.Close();
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            return Previous_Customer;
        }

        public Customer FirstCustomer()
        {
            connection.Open();
            var first_customer = new Customer();
            var command = new SqlCommand("select top 1 CustomerID,CompanyName, ContactName,ContactTitle,Address from Customers Order by CustomerID ASC", connection);
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    first_customer.CustomerId = reader.GetString(reader.GetOrdinal("CustomerID"));
                    first_customer.CompanyName = reader.GetString(reader.GetOrdinal("CompanyName"));
                    first_customer.CustomerName = reader.GetString(reader.GetOrdinal("ContactName"));
                    first_customer.CustomerTitle = reader.GetString(reader.GetOrdinal("ContactTitle"));
                    first_customer.Address = reader.GetString(reader.GetOrdinal("Address"));
                }
                connection.Close();
                reader.Close();
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            return first_customer;
        }

        public Customer LastCustomer()
        {
            connection.Open();
            var last_customer = new Customer();
            var command = new SqlCommand("select top 1 CustomerID,CompanyName, ContactName,ContactTitle,Address from Customers Order by CustomerID DESC", connection);
            try
            {
                SqlDataReader reader = command.ExecuteReader();

                if (reader.Read())
                {
                    last_customer.CustomerId = reader.GetString(reader.GetOrdinal("CustomerID"));
                    last_customer.CompanyName = reader.GetString(reader.GetOrdinal("CompanyName"));
                    last_customer.CustomerName = reader.GetString(reader.GetOrdinal("ContactName"));
                    last_customer.CustomerTitle = reader.GetString(reader.GetOrdinal("ContactTitle"));
                    last_customer.Address = reader.GetString(reader.GetOrdinal("Address"));
                }
                connection.Close();
                reader.Close();
            }
            catch (SqlException exception)
            {
                throw exception;
            }
            return last_customer;
        }


    }
}