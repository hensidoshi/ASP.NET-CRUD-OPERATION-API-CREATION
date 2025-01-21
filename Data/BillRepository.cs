using CoffeeShop_APICreation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using System.Data;

namespace CoffeeShop_APICreation.Data
{
    public class BillRepository
    {
        private readonly string _connectionString;
        public BillRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        #region SelectAllBills And Call this in BillController

        public IEnumerable<BillModel> SelectAll()
        {
            var bills = new List<BillModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Bills_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    bills.Add(new BillModel
                    {
                        BillID = Convert.ToInt32(reader["BillID"]),
                        BillNumber = reader["BillNumber"].ToString(),
                        BillDate = Convert.ToDateTime(reader["BillDate"]),
                        OrderID = Convert.ToInt32(reader["OrderID"]),
                        TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                        Discount = Convert.ToDecimal(reader["Discount"]),
                        NetAmount = Convert.ToDecimal(reader["NetAmount"]),
                        UserID = Convert.ToInt32(reader["UserID"])
                    });
                }
                return bills;
            }
        }
        #endregion

        public BillModel SelectByPK(int billID)
        {
            BillModel bill = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Bills_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BillID", billID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    bill = new BillModel
                    {
                        BillID = Convert.ToInt32(reader["BillID"]),
                        BillNumber = reader["BillNumber"].ToString(),
                        BillDate = Convert.ToDateTime(reader["BillDate"]),
                        OrderID = Convert.ToInt32(reader["OrderID"]),
                        TotalAmount = Convert.ToDecimal(reader["TotalAmount"]),
                        Discount = Convert.ToDecimal(reader["Discount"]),
                        NetAmount = Convert.ToDecimal(reader["NetAmount"]),
                        UserID = Convert.ToInt32(reader["UserID"])
                    };
                }
            }
            return bill;
        }

        public bool Delete(int billID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Bills_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BillID", billID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Insert(BillModel bill)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Bills_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BillNumber", bill.BillNumber);
                cmd.Parameters.AddWithValue("@BillDate", bill.BillDate);
                cmd.Parameters.AddWithValue("@OrderID", bill.OrderID);
                cmd.Parameters.AddWithValue("@TotalAmount", bill.TotalAmount);
                cmd.Parameters.AddWithValue("@Discount", bill.Discount);
                cmd.Parameters.AddWithValue("@NetAmount", bill.NetAmount);
                cmd.Parameters.AddWithValue("@UserID", bill.UserID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(BillModel bill)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Bills_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@BillID", bill.BillID);
                cmd.Parameters.AddWithValue("@BillNumber", bill.BillNumber);
                cmd.Parameters.AddWithValue("@BillDate", bill.BillDate);
                cmd.Parameters.AddWithValue("@OrderID", bill.OrderID);
                cmd.Parameters.AddWithValue("@TotalAmount", bill.TotalAmount);
                cmd.Parameters.AddWithValue("@Discount", bill.Discount);
                cmd.Parameters.AddWithValue("@NetAmount", bill.NetAmount);
                cmd.Parameters.AddWithValue("@UserID", bill.UserID);
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