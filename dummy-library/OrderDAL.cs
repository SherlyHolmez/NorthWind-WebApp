using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Models;

namespace Data
{
    public class OrderDAL
    {
        SqlConnection connection = new SqlConnection("Data Source=SEAN-NASIR\\SQLEXPRESS;Initial Catalog=Northwind;Integrated Security=True");
        public bool DeleteOrder(String ID)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("delete Orders where CustomerID = @id", connection);
            command.Parameters.AddWithValue("@id", ID);

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

        public bool DeleteOrderDetails(String ID)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("delete from [Order Details] where OrderID in (select OrderID from Orders where CustomerID=@id)", connection);
            command.Parameters.AddWithValue("@id", ID);
            if (command.ExecuteNonQuery() >= 1)
            {
                connection.Close();
                return true;
            }
            else
            {
                connection.Close();
                return false;
            }
        }

        public List<OrderDetails> DisplayOrder(String ID)
        {
            connection.Open();
            var LS = new List<OrderDetails>();
            SqlCommand Command = new SqlCommand("select OrderID, EmployeeID, OrderDate from Orders where CustomerID = @id", connection);
            Command.Parameters.AddWithValue("@id", ID);
            using (SqlDataReader reader = Command.ExecuteReader())
            {
                int ordid = reader.GetOrdinal("OrderID");
                int empid = reader.GetOrdinal("EmployeeID");
                int orddate = reader.GetOrdinal("OrderDate");
                while (reader.Read())
                {
                    try
                    {
                        var order = new OrderDetails();
                        order.OrderDate = reader[orddate] as DateTime? ?? null;
                        order.OrderID = reader.GetInt32(ordid);
                        order.EmployeeID = reader[empid] as int? ?? null;

                        LS.Add(order);
                    }
                    catch (SqlException exception)
                    {
                        throw exception;
                    }
                }
                reader.Close();
            }
            connection.Close();
            return LS;
        }

        public bool PlaceOrder(String CustomerID, int EmployeeID, int ProductID, int Quantity, decimal UnitPrice)
        {
            connection.Open();
            SqlCommand command = new SqlCommand("insert into Orders(CustomerID, EmployeeID, OrderDate) values( @cxid, @empid,@orderdate)", connection);
            command.Parameters.AddWithValue("@cxid", CustomerID);
            command.Parameters.AddWithValue("@empid", EmployeeID);
            command.Parameters.AddWithValue("@orderdate", DateTime.Now);

            try
            {
                command.ExecuteNonQuery();
                connection.Close();
                OrderDetails(ProductID, Quantity, UnitPrice);
                return true;
            }
            catch (SqlException exception)
            {
                throw exception;
            }
        }

        public bool OrderDetails(int ProductID, int Quantity, decimal UnitPrice)
        {
            connection.Open();
            SqlCommand Command = new SqlCommand("SELECT TOP 1 OrderID FROM Orders ORDER BY OrderID DESC", connection);
            int OrderId = (int)Command.ExecuteScalar();

            SqlCommand order_details = new SqlCommand("insert into [Order Details](OrderID, ProductID, UnitPrice, Quantity) values(@orderid, @prod_id, @unitprice, @quantity)", connection);
            order_details.Parameters.AddWithValue("@orderid", OrderId);
            order_details.Parameters.AddWithValue("@prod_id", ProductID);
            order_details.Parameters.AddWithValue("@unitprice", UnitPrice);
            order_details.Parameters.AddWithValue("@quantity", Quantity);
            try
            {
                order_details.ExecuteNonQuery();
                return true;
            }
            catch (SqlException ex)
            {
                throw ex;
            }

        }

    }
}
