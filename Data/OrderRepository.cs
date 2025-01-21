using CoffeeShop_APICreation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CoffeeShop_APICreation.Data
{
    public class OrderRepository
    {
        private readonly string _connectionString;
        public OrderRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        #region SelectAllOrders And Call this in OrderController

        public IEnumerable<OrderModel> SelectAll()
        {
            var orders = new List<OrderModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_OrderDemo_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    orders.Add(new OrderModel
                    {
                        OrderID = Convert.ToInt32(reader["OrderId"]),
                        OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                        OrderNumber = reader["OrderNumber"].ToString(),
                        CustomerID = Convert.ToInt32(reader["CustomerId"]),
                        PaymentMode = reader["PaymentMode"].ToString(),
                        TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                        ShippingAddress = reader["ShippingAddress"].ToString(),
                        UserID = Convert.ToInt32(reader["UserId"])
                    });
                }
                return orders;
            }
        }
        #endregion

        public OrderModel SelectByPK(int orderId)
        {
            OrderModel order = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_OrderDemo_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@OrderId", orderId);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    order = new OrderModel
                    {
                        OrderID = Convert.ToInt32(reader["OrderId"]),
                        OrderDate = Convert.ToDateTime(reader["OrderDate"]),
                        OrderNumber = reader["OrderNumber"].ToString(),
                        CustomerID = Convert.ToInt32(reader["CustomerId"]),
                        PaymentMode = reader["PaymentMode"].ToString(),
                        TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                        ShippingAddress = reader["ShippingAddress"].ToString(),
                        UserID = Convert.ToInt32(reader["UserId"])
                    };
                }
            }
            return order;
        }

        public bool Delete(int orderId)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_OrderDemo_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@OrderID", orderId);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Insert(OrderModel order)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_OrderDemo_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                cmd.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);
                cmd.Parameters.AddWithValue("@CustomerId", order.CustomerID);
                cmd.Parameters.AddWithValue("@PaymentMode", order.PaymentMode);
                cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                cmd.Parameters.AddWithValue("@ShippingAddress", order.ShippingAddress);
                cmd.Parameters.AddWithValue("@UserId", order.UserID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(OrderModel order)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_OrderDemo_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@OrderId", order.OrderID);
                cmd.Parameters.AddWithValue("@OrderDate", order.OrderDate);
                cmd.Parameters.AddWithValue("@OrderNumber", order.OrderNumber);
                cmd.Parameters.AddWithValue("@CustomerId", order.CustomerID);
                cmd.Parameters.AddWithValue("@PaymentMode", order.PaymentMode);
                cmd.Parameters.AddWithValue("@TotalAmount", order.TotalAmount);
                cmd.Parameters.AddWithValue("@ShippingAddress", order.ShippingAddress);
                cmd.Parameters.AddWithValue("@UserId", order.UserID);
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
        public IEnumerable<CustomerDropDownModel> GetCustomers()
        {
            var customers = new List<CustomerDropDownModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Customer_Dropdown", conn) 
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    customers.Add(new CustomerDropDownModel
                    {
                        CustomerID = Convert.ToInt32(reader["CustomerID"]),
                        CustomerName = reader["CustomerName"].ToString()
                    });
                }
            }

            return customers;
        }

    }
}
