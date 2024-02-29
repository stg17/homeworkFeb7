using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace homeworkFeb7.Models
{
    public class NorthwindDBManager
    {
        private string _connectionString;
        public NorthwindDBManager(string connectionString)
        {
            _connectionString = connectionString;
        }

        public List<Product> GetProducts(int min = 0, int max = 0)
        {
            string search = "";
            if (min != 0 && max != 0)
            {
                search = "WHERE UnitsInStock BETWEEN @min AND @max";
            }

            SqlConnection connection = new SqlConnection(_connectionString);
            SqlCommand command = connection.CreateCommand();
            command.CommandText = $"SELECT * FROM Products {search}";
            command.Parameters.AddWithValue("@min", min);
            command.Parameters.AddWithValue("@max", max);
            connection.Open();
            List<Product> products = new List<Product>();
            SqlDataReader reader = command.ExecuteReader();

            while (reader.Read())
            {
                products.Add(new Product
                {
                    Id = (int)reader["ProductId"],
                    Name = (string)reader["ProductName"],
                    UnitsInStock = (short)reader["UnitsInStock"]
                });
            }

            return products;
        }
    }

    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int UnitsInStock { get; set; }
    }
}