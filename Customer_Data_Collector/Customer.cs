

using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing.Text;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Customer_Data_Collector
{
    public class Customer
    {
        private static string myConn = ConfigurationManager.ConnectionStrings["connstring"].ConnectionString;

        public string CusId { get; set; }
        public string ComName { get; set; }
        public string ConName { get; set; }
        public string Phone { get; set; }
        private const string InsertQuery = "Insert Into customer(CusId,ComName,ConName,Phone) Values(@CusId,@ComName, @ConName, @Phone)";
        private const string UpdateQuery = "Update customer set ComName=@ComName,ConName=@ConName,Phone=@Phone where CusId=@CusId";
        private const string DeleteQuery = "Delete from customer where CusId=@CusId";
        private const string ShowQuery = "Select * from customer";
        public bool InsertCustomer(Customer customer)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(InsertQuery, con))
                {
                    com.Parameters.AddWithValue("@CusId", customer.CusId);
                    com.Parameters.AddWithValue("@ComName", customer.ComName);
                    com.Parameters.AddWithValue("@ConName", customer.ConName);
                    com.Parameters.AddWithValue("@Phone", customer.Phone);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }
        public bool UpdateCustomer(Customer customer)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(UpdateQuery, con))
                {
                    com.Parameters.AddWithValue("@CusId", customer.CusId);
                    com.Parameters.AddWithValue("@ComName",customer.ComName);
                    com.Parameters.AddWithValue("@ConName",customer.ConName);
                    com.Parameters.AddWithValue("@Phone", customer.Phone);
                   
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }
        public bool DeleteCustomer(Customer customer)
        {
            int rows;
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(DeleteQuery, con))
                {
                    com.Parameters.AddWithValue("@CusId",customer.CusId);
                    rows = com.ExecuteNonQuery();
                }
            }
            return (rows > 0) ? true : false;
        }
        public DataTable ShowCustomer()
        {
            var datatable = new DataTable();
            using (SqlConnection con = new SqlConnection(myConn))
            {
                con.Open();
                using (SqlCommand com = new SqlCommand(ShowQuery, con))
                {
                    using (SqlDataAdapter adapter = new SqlDataAdapter(com))
                    {
                        adapter.Fill(datatable);
                    }
                }
            }
            return datatable;
        }
    }
}
