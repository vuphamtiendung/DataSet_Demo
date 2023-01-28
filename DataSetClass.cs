using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using System.Threading.Tasks;
using static System.Console;

namespace DataSet_003
{
    internal class DataSetClass
    {
        public void DataSetDemo()
        {
            try
            {
                DataTable customer = new DataTable("Customer"); // Create Table

                // create fields of the customer table
                DataColumn CustomerID = new DataColumn("CustomerId", typeof(Int32));
                customer.Columns.Add(CustomerID);
                DataColumn CustomerName = new DataColumn("CustomerName", typeof(string));
                customer.Columns.Add(CustomerName);
                DataColumn CustomerMobile = new DataColumn("CustomerMobile", typeof(string));
                customer.Columns.Add(CustomerMobile);

                // insert data in the customer table
                customer.Rows.Add(101, "Van Quyen", "118001229");
                customer.Rows.Add(202, "Freetuts.net", "1234567890");

                DataTable order = new DataTable("Order"); // Create Table

                // create fields in the order table
                DataColumn orderId = new DataColumn("OrderId", typeof(Int32));
                order.Columns.Add(orderId);
                DataColumn cusId = new DataColumn("CustomerId", typeof(Int32));
                order.Columns.Add(cusId);
                DataColumn orderAmount = new DataColumn("Amount", typeof(Int32));
                order.Columns.Add(orderAmount);

                // insert data in the order table
                order.Rows.Add(10001, 101, 20000);
                order.Rows.Add(10002, 102, 30000);

                // Call DataSet to add two datatable customer and order
                DataSet dataset = new DataSet();
                dataset.Tables.Add(customer);
                dataset.Tables.Add(order);

                // Duyệt dữ liệu
                WriteLine("Customer");
                foreach (DataRow select in dataset.Tables[0].Rows)
                {
                    WriteLine(select["CustomerId"] + " | " + select["CustomerName"] + " | " + select["CustomerMobile"]);
                }
                WriteLine();
                WriteLine("Order");
                foreach (DataRow select in dataset.Tables[1].Rows)
                {
                    WriteLine(select["OrderId"] + " | " + select["CustomerId"] + " | " + select["Amount"]);
                }
            }
            catch(Exception ex)
            {
                WriteLine("Đã có lỗi xảy ra!!! " + ex.Message);
            } 
        }
    }
}
