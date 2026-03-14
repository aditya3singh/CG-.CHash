using System;
using System.Collections.Generic;
using System.Data;
using Microsoft.Data.SqlClient; // or System.Data.SqlClient depending on your .NET version
using Pagination.Models;

namespace Pagination.Repositories
{
    public class ProductRepository
    {
        private readonly string _connectionString;

        public ProductRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        // Your requested method signature
        public List<Product> GetProductsLazyLoaded(int pageNumber, int pageSize)
        {
            var products = new List<Product>();

            using (SqlConnection con = new SqlConnection(_connectionString))
            {
                using (SqlCommand cmd = new SqlCommand("spGetProducts_LazyLoad", con))
                {
                    cmd.CommandType = CommandType.StoredProcedure;
                    cmd.Parameters.AddWithValue("@PageNumber", pageNumber);
                    cmd.Parameters.AddWithValue("@PageSize", pageSize);

                    con.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            products.Add(new Product
                            {
                                ProductID = Convert.ToInt32(reader["ProductID"]),
                                Name = reader["Name"].ToString(),
                                ProductNumber = reader["ProductNumber"].ToString()
                            });
                        }
                    }
                }
            }
            return products;
        }
    }
}