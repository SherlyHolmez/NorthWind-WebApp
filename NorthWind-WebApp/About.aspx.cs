using Data;
using Model;
using Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;


namespace NorthWind_WebApp
{
    public partial class About : Page
    {
        ServiceReference1.OrderDetails[] OrderArray;
        ServiceReference1.Customer Cust = new ServiceReference1.Customer();
        ServiceReference1.WebService1SoapClient MyClient = new ServiceReference1.WebService1SoapClient();

         protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Cust = MyClient.FirstCustomer();
                CustomerIDTextBox.Text = Cust.CustomerId;
                CustomerNameTextBox.Text = Cust.CustomerName;
                CustomerTitleTextBox.Text = Cust.CustomerTitle;
                AddressTextbox.Text = Cust.Address;
                CompanyNameTextBox.Text = Cust.CompanyName;

                OrderArray = MyClient.OrdersData(Cust);

                GridView1.DataSource = OrderArray;
                GridView1.DataBind();
            }




        }
        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void AddButtonClick(object sender, EventArgs e)
        {
            CustomerIDTextBox.Text = String.Empty;
            CompanyNameTextBox.Text = String.Empty;
            CustomerNameTextBox.Text = String.Empty;
            CustomerTitleTextBox.Text = String.Empty;
            AddressTextbox.Text = String.Empty;


        }

        protected void SubmitButtonClick(object sender, EventArgs e)
        {
            if(CustomerIDTextBox.Text != String.Empty && CompanyNameTextBox.Text!= String.Empty)
            {
                MyClient.Add_Customer(CustomerIDTextBox.Text, CompanyNameTextBox.Text, CustomerNameTextBox.Text, CustomerTitleTextBox.Text, AddressTextbox.Text);
                Response.Write("<script>alert('Customer Added.')</script>");

            }
            else
            {
                Response.Write("<script>alert('Please Enter Customer ID and Company Name.')</script>");
            }

        }


        protected void FirstButtonClick(object sender, EventArgs e)
        {
            Cust = MyClient.FirstCustomer();
            CustomerIDTextBox.Text = Cust.CustomerId;
            CustomerNameTextBox.Text = Cust.CustomerName;
            CustomerTitleTextBox.Text = Cust.CustomerTitle;
            AddressTextbox.Text = Cust.Address;
            CompanyNameTextBox.Text = Cust.CompanyName;

            OrderArray = MyClient.OrdersData(Cust);

            GridView1.DataSource = OrderArray;
            GridView1.DataBind();
        }

        protected void LastButtonClick(object sender, EventArgs e)
        {
            Cust = MyClient.LastCustomer();
            CustomerIDTextBox.Text = Cust.CustomerId;
            CustomerNameTextBox.Text = Cust.CustomerName;
            CustomerTitleTextBox.Text = Cust.CustomerTitle;
            AddressTextbox.Text = Cust.Address;
            CompanyNameTextBox.Text = Cust.CompanyName;

            OrderArray = MyClient.OrdersData(Cust);

            GridView1.DataSource = OrderArray;
            GridView1.DataBind();
        }



        protected void NextButtonClick(object sender, EventArgs e)
        {
            Cust = MyClient.NextCustomer(CustomerIDTextBox.Text);
            CustomerIDTextBox.Text = Cust.CustomerId;
            CustomerNameTextBox.Text = Cust.CustomerName;
            CustomerTitleTextBox.Text = Cust.CustomerTitle;
            AddressTextbox.Text = Cust.Address;
            CompanyNameTextBox.Text = Cust.CompanyName;

            OrderArray = MyClient.OrdersData(Cust);

            GridView1.DataSource = OrderArray;
            GridView1.DataBind();
        }

        protected void PreviousButtonClick(object sender, EventArgs e)
        {
            
            Cust = MyClient.PrevCustomer(CustomerIDTextBox.Text);
            CustomerIDTextBox.Text = Cust.CustomerId;
            CustomerNameTextBox.Text = Cust.CustomerName;
            CustomerTitleTextBox.Text = Cust.CustomerTitle;
            AddressTextbox.Text = Cust.Address;
            CompanyNameTextBox.Text = Cust.CompanyName;

            OrderArray = MyClient.OrdersData(Cust);

            GridView1.DataSource = OrderArray;
            GridView1.DataBind();

        }

        protected void DeleteButtonClick(object sender, EventArgs e)
        {
            if (CustomerIDTextBox.Text != String.Empty)
            {
                MyClient.Delete_Customer(CustomerIDTextBox.Text);

                Cust = MyClient.NextCustomer(CustomerIDTextBox.Text);
                CustomerIDTextBox.Text = Cust.CustomerId;
                CustomerNameTextBox.Text = Cust.CustomerName;
                CustomerTitleTextBox.Text = Cust.CustomerTitle;
                AddressTextbox.Text = Cust.Address;
                CompanyNameTextBox.Text = Cust.CompanyName;

                Response.Write("<script>alert('Customer Deleted.')</script>");


            }
            else
            {
                Response.Write("<script>alert('No ID found to Delete.')</script>");
            }

        }

        protected void UpdateButtonClick(object sender, EventArgs e)
        {
            if(CustomerIDTextBox.Text != String.Empty && CompanyNameTextBox.Text != String.Empty)
            {
                MyClient.Update_Customer(CustomerIDTextBox.Text, CompanyNameTextBox.Text, CustomerNameTextBox.Text, CustomerTitleTextBox.Text, AddressTextbox.Text);
                Response.Write("<script>alert('The data has been updated.')</script>");
            }
            else
            {
                Response.Write("<script>alert('No ID and Company Name found to Update.')</script>");
            }
        }
    }
}