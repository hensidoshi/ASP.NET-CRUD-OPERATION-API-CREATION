using CoffeeShop_APICreation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using CoffeeShop_APICreation.Models;
using System.Data;

namespace CoffeeShop_APICreation.Data
{
    public class CustomerRepository
    {
        private readonly string _connectionString;
        public CustomerRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        #region SelectAllCustomers And Call this in CustomerController

        public IEnumerable<CustomerModel> SelectAll()
        {
            var customers = new List<CustomerModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Customer_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    customers.Add(new CustomerModel
                    {
                        CustomerID = Convert.ToInt32(reader["CustomerID"]),
                        CustomerName = reader["CustomerName"].ToString(),
                        HomeAddress = reader["HomeAddress"].ToString(),
                        Email = reader["Email"].ToString(),
                        MobileNo = reader["MobileNo"].ToString(),
                        GST_NO = reader["GST_NO"].ToString(),
                        CityName = reader["CityName"].ToString(),
                        Pincode = reader["Pincode"].ToString(),
                        NetAmount = Convert.ToDecimal(reader["NetAmount"]),
                        UserID = Convert.ToInt32(reader["UserID"])
                    });
                }
                return customers;
            }
        }
        #endregion

        public CustomerModel SelectByPK(int customerID)
        {
            CustomerModel customer = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Customer_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    customer = new CustomerModel
                    {
                        CustomerID = Convert.ToInt32(reader["CustomerID"]),
                        CustomerName = reader["CustomerName"].ToString(),
                        HomeAddress = reader["HomeAddress"].ToString(),
                        Email = reader["Email"].ToString(),
                        MobileNo = reader["MobileNo"].ToString(),
                        GST_NO = reader["GST_NO"].ToString(),
                        CityName = reader["CityName"].ToString(),
                        Pincode = reader["Pincode"].ToString(),
                        NetAmount = Convert.ToDecimal(reader["NetAmount"]),
                        UserID = Convert.ToInt32(reader["UserID"])
                    };
                }
            }
            return customer;
        }

        public bool Delete(int customerID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Customer_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@CustomerID", customerID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Insert(CustomerModel customer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Customer_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@HomeAddress", customer.HomeAddress);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@MobileNo", customer.MobileNo);
                cmd.Parameters.AddWithValue("@GST_NO", customer.GST_NO);
                cmd.Parameters.AddWithValue("@CityName", customer.CityName);
                cmd.Parameters.AddWithValue("@Pincode", customer.Pincode);
                cmd.Parameters.AddWithValue("@NetAmount", customer.NetAmount);
                cmd.Parameters.AddWithValue("@UserID", customer.UserID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(CustomerModel customer)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Customer_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@CustomerID", customer.CustomerID);
                cmd.Parameters.AddWithValue("@CustomerName", customer.CustomerName);
                cmd.Parameters.AddWithValue("@HomeAddress", customer.HomeAddress);
                cmd.Parameters.AddWithValue("@Email", customer.Email);
                cmd.Parameters.AddWithValue("@MobileNo", customer.MobileNo);
                cmd.Parameters.AddWithValue("@GST_NO", customer.GST_NO);
                cmd.Parameters.AddWithValue("@CityName", customer.CityName);
                cmd.Parameters.AddWithValue("@Pincode", customer.Pincode);
                cmd.Parameters.AddWithValue("@NetAmount", customer.NetAmount);
                cmd.Parameters.AddWithValue("@UserID", customer.UserID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public IEnumerable<UserDropDownModel> GetUsers()
        {
            var users = new List<UserDropDownModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_UserDemo_Dropdown", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    users.Add(new UserDropDownModel
                    {
                        UserID = Convert.ToInt32(reader["UserID"]),
                        UserName = reader["UserName"].ToString()
                    });
                }
            }

            return users;
        }
    }
}
