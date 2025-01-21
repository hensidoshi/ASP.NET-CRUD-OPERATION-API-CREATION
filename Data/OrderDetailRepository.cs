using CoffeeShop_APICreation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using CoffeeShop_APICreation.Models;
using System.Data;

namespace CoffeeShop_APICreation.Data
{
    public class OrderDetailRepository
    {
        private readonly string _connectionString;
        public OrderDetailRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        #region SelectAllOrderDetails And Call this in OrderDetailController

        public IEnumerable<OrderDetailModel> SelectAll()
        {
            var orderDetails = new List<OrderDetailModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_OrderDetail_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    orderDetails.Add(new OrderDetailModel
                    {
                        OrderDetailID = Convert.ToInt32(reader["OrderDetailID"]),
                        OrderID = Convert.ToInt32(reader["OrderID"]),
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Amount = Convert.ToDecimal(reader["Amount"]),
                        TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                        UserID = Convert.ToInt32(reader["UserID"])
                    });
                }
                return orderDetails;
            }
        }
        #endregion

        public OrderDetailModel SelectByPK(int orderDetailID)
        {
            OrderDetailModel orderDetail = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_OrderDetail_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@OrderDetailID", orderDetailID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    orderDetail = new OrderDetailModel
                    {
                        OrderDetailID = Convert.ToInt32(reader["OrderDetailID"]),
                        OrderID = Convert.ToInt32(reader["OrderID"]),
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        Quantity = Convert.ToInt32(reader["Quantity"]),
                        Amount = Convert.ToDecimal(reader["Amount"]),
                        TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                        UserID = Convert.ToInt32(reader["UserID"])
                    };
                }
            }
            return orderDetail;
        }

        public bool Delete(int orderDetailID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_OrderDetail_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@OrderDetailID", orderDetailID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Insert(OrderDetailModel orderDetail)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_OrderDetail_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@OrderID", orderDetail.OrderID);
                cmd.Parameters.AddWithValue("@ProductID", orderDetail.ProductID);
                cmd.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
                cmd.Parameters.AddWithValue("@Amount", orderDetail.Amount);
                cmd.Parameters.AddWithValue("@TotalAmount", orderDetail.TotalAmount);
                cmd.Parameters.AddWithValue("@UserID", orderDetail.UserID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(OrderDetailModel orderDetail)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_OrderDetail_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@OrderDetailID", orderDetail.OrderDetailID);
                cmd.Parameters.AddWithValue("@OrderID", orderDetail.OrderID);
                cmd.Parameters.AddWithValue("@ProductID", orderDetail.ProductID);
                cmd.Parameters.AddWithValue("@Quantity", orderDetail.Quantity);
                cmd.Parameters.AddWithValue("@Amount", orderDetail.Amount);
                cmd.Parameters.AddWithValue("@TotalAmount", orderDetail.TotalAmount);
                cmd.Parameters.AddWithValue("@UserID", orderDetail.UserID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public IEnumerable<OrderDropDownModel> GetOrders()
        {
            var orders = new List<OrderDropDownModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_OrderDemo_Dropdown", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    orders.Add(new OrderDropDownModel
                    {
                        OrderID = Convert.ToInt32(reader["OrderID"]),
                        OrderNumber = reader["OrderNumber"].ToString()
                    });
                }
            }

            return orders;
        }

        public IEnumerable<ProductDropDownModel> GetProducts()
        {
            var products = new List<ProductDropDownModel>();

            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Product_Dropdown", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    products.Add(new ProductDropDownModel
                    {
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        ProductName = reader["ProductName"].ToString()
                    });
                }
            }

            return products;
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
