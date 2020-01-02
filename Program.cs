using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace RawCRUD_ConsoleApp
{
    class Program
    {
        static void Main(string[] args)
        {
            //list of customers from the database will be stored here
            List<Customer> customers = new List<Customer>();
            string connectionString = "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=Northwind;Integrated Security=True;Connect Timeout=30;Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False";
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                //Open the SQL Connection
                conn.Open();
                Console.WriteLine("Connection succesfull");

                #region Insert_Row_in_Customers_table
                //try
                //{
                //    Customer newCustomer = new Customer("T19", "Remus", "YOLO");
                //string sqlIns = String.Format("INSERT INTO Customers (CustomerID, CompanyName, ContactName) Values ('{0}','{1}','{2}')", newCustomer.CustomerID, newCustomer.ContactName, newCustomer.CompanyName);
                //using (SqlCommand command = new SqlCommand(sqlIns, conn))
                //    {
                //        int rowAffected = command.ExecuteNonQuery();
                //        Console.WriteLine("INSERT_SQL_QUERY finished: {0}", rowAffected);
                //    }
                //}
                //catch (SqlException se)
                //{

                //    Console.WriteLine(se.Message);
                //}
                #endregion

                #region Update_Customers_table
                //try
                //{
                //    Customer newCustomer2 = new Customer("UPD", "YoloSRL", "Arriva");
                //    string sqlUpd = String.Format("UPDATE Customers SET CustomerID='{0}', CompanyName='{1}', ContactName='{2}' WHERE CustomerID ='T19'", newCustomer2.CustomerID, newCustomer2.CompanyName, newCustomer2.ContactName);
                //    using (SqlCommand command = new SqlCommand(sqlUpd, conn))
                //    {
                //    int rowAffected = command.ExecuteNonQuery();
                //    Console.WriteLine("UPDATE_SQL_QUERY finished: {0}", rowAffected);
                //    }
                //}
                //catch (SqlException su)
                //{
                //    Console.WriteLine(su.Message);
                //}
                #endregion

                #region Select_Multiple_Rows_with_array
                string select = "SELECT * FROM Customers";
                using (SqlCommand command1 = new SqlCommand(select, conn))
                {
                    SqlDataReader rowsFromCustomer = command1.ExecuteReader();
                    while (rowsFromCustomer.Read())
                    {
                        string cID = rowsFromCustomer["CustomerID"].ToString();
                        string companyN = rowsFromCustomer["CompanyName"].ToString();
                        string contactN = rowsFromCustomer["ContactName"].ToString();

                        Customer customer3 = new Customer(cID, companyN, contactN);
                        customers.Add(customer3);
                    }
                    foreach (Customer new_cust_from_table in customers)
                    {
                        Console.WriteLine(string.Format("Customer ID {0}", new_cust_from_table.CustomerID));
                        Console.WriteLine(string.Format("Company Name {0}", new_cust_from_table.CompanyName));
                        Console.WriteLine(string.Format("Contact Name {0}", new_cust_from_table.ContactName));
                    }
                }
                #endregion
            }
        }
    }

    #region Customer_class
    public class Customer
    {
        private string customerID;
        private string contactName;
        private string companyName;
        public Customer(string customerID, string contactName, string companyName)
        {
            this.customerID = customerID;
            this.contactName = contactName;
            this.companyName = companyName;
        }

        public string CustomerID { get => customerID; set => customerID = value; }
        public string ContactName { get => contactName; set => contactName = value; }
        public string CompanyName { get => companyName; set => companyName = value; }
    }
    #endregion
}
