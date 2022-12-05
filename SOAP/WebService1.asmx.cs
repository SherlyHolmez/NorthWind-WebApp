using Data;
using Model;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Web;
using System.Web.Services;

namespace SOAP
{
    /// <summary>
    /// Summary description for WebService1
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class WebService1 : System.Web.Services.WebService
    {
        CustomerDAL Customer_Object = new CustomerDAL();
        OrderDAL Order_Object = new OrderDAL();
        ProductDAL Product_Object = new ProductDAL();

        [WebMethod]
        public Customer FirstCustomer()
        {
            var my_customer = new Customer();
            my_customer = Customer_Object.FirstCustomer();
            return my_customer;
        }

        [WebMethod]
        public Customer LastCustomer()
        {
            var my_customer = new Customer();
            my_customer = Customer_Object.LastCustomer();
            return my_customer;
        }

        [WebMethod]
        public Customer NextCustomer(String id)
        {
            var my_customer = new Customer();
            my_customer = Customer_Object.NextCustomer(id);
            return my_customer;
        }

        [WebMethod]
        public Customer PrevCustomer(String id)
        {
            var my_customer = new Customer();
            my_customer = Customer_Object.PrevCustomer(id);
            return my_customer;
        }

        [WebMethod]
        public bool Add_Customer(string ID, string CompName, string CustName, string CustTitle, string Address)
        {
            if (Customer_Object.AddCustomer(ID, CompName, CustName, CustTitle, Address))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public bool Update_Customer(string ID, string CompName, string CustName, string CustTitle, string Address)
        {
            if (Customer_Object.EditCustomer(ID, CompName, CustName, CustTitle, Address))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        [WebMethod]
        public bool Delete_Customer(string ID)
        {
            if (Customer_Object.DeleteCust(ID))
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        [WebMethod]
        public List<OrderDetails> OrdersData(Customer Cust)
        {
            List<OrderDetails> Orders = new List<OrderDetails>();
            Orders = Order_Object.DisplayOrder(Cust.CustomerId);
            return Orders;
        }

        [WebMethod]
        public bool PlaceOrder(string CustomerID, int EmployeeID, int ProductID, int Quantity, decimal UnitPrice)
        {
            if (Order_Object.PlaceOrder(CustomerID, EmployeeID, ProductID, Quantity, UnitPrice))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        [WebMethod]
        public List<Products> AddProducts(int ProdID)
        {
            List<Products> ProductList = new List<Products>();
            ProductList = Product_Object.AddProducts(ProdID);
            return ProductList;
        }

        [WebMethod]
        public List<Employee> AddEmployees(int EmpID)
        {
            List<Employee> EmployeeList = new List<Employee>();
            EmployeeList = Product_Object.AddEmployees(EmpID);
            return EmployeeList;
        }



    }
}
