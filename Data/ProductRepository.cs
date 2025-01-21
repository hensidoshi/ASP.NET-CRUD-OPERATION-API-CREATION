using CoffeeShop_APICreation.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using CoffeeShop_APICreation.Models;
using System.Data;

namespace CoffeeShop_APICreation.Data
{
    public class ProductRepository
    {
        private readonly string _connectionString;
        public ProductRepository(IConfiguration configuration)
        {
            _connectionString = configuration.GetConnectionString("DefaultConnection");
        }

        #region SelectAllProducts And Call this in ProductController

        public IEnumerable<ProductModel> SelectAll()
        {
            var products = new List<ProductModel>();
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Product_SelectAll", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };

                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    products.Add(new ProductModel
                    {
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        ProductName = reader["ProductName"].ToString(),
                        ProductPrice = Convert.ToDecimal(reader["ProductPrice"]),
                        ProductCode = reader["ProductCode"].ToString(),
                        Description = reader["Description"].ToString(),
                        UserID = Convert.ToInt32(reader["UserID"])
                    });
                }
                return products;
            }
        }
        #endregion

        public ProductModel SelectByPK(int productID)
        {
            ProductModel product = null;
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Product_SelectByPK", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProductID", productID);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    product = new ProductModel
                    {
                        ProductID = Convert.ToInt32(reader["ProductID"]),
                        ProductName = reader["ProductName"].ToString(),
                        ProductPrice = Convert.ToDecimal(reader["ProductPrice"]),
                        ProductCode = reader["ProductCode"].ToString(),
                        Description = reader["Description"].ToString(),
                        UserID = Convert.ToInt32(reader["UserID"])
                    };
                }
            }
            return product;
        }

        public bool Delete(int productID)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Product_Delete", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProductID", productID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Insert(ProductModel product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Product_Insert", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                cmd.Parameters.AddWithValue("@ProductCode", product.ProductCode);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@UserID", product.UserID);
                conn.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                return rowsAffected > 0;
            }
        }

        public bool Update(ProductModel product)
        {
            using (SqlConnection conn = new SqlConnection(_connectionString))
            {
                SqlCommand cmd = new SqlCommand("PR_Product_Update", conn)
                {
                    CommandType = CommandType.StoredProcedure
                };
                cmd.Parameters.AddWithValue("@ProductID", product.ProductID);
                cmd.Parameters.AddWithValue("@ProductName", product.ProductName);
                cmd.Parameters.AddWithValue("@ProductPrice", product.ProductPrice);
                cmd.Parameters.AddWithValue("@ProductCode", product.ProductCode);
                cmd.Parameters.AddWithValue("@Description", product.Description);
                cmd.Parameters.AddWithValue("@UserID", product.UserID);
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