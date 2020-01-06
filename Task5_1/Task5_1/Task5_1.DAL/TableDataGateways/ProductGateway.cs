using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Task5_1.DAL.Entities;

namespace Task5_1.DAL.TableDataGateways
{
    public class ProductGateway
    {
        private string _connectionString;

        public ProductGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ICollection<Product> FindAll()
        {
            var products = new Collection<Product>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                var sql = "select id, name, category_id, supplier_id from product;";
                command.CommandText = sql;
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        products.Add
                        (
                            new Product()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                                CategoryId = reader.GetInt32(2),
                                SupplierId = reader.GetInt32(3)
                            }
                        );
                    }
                }
            }

            return products;
        }

        public Product FindById(int id)
        {
            Product product = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                var sql = "select id, name, category_id, supplier_id from product where id = @id;";
                command.CommandText = sql;
                command.Parameters.Add(new SqlParameter("@id", id));
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    product = 
                        new Product()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                            CategoryId = reader.GetInt32(2),
                            SupplierId = reader.GetInt32(3)
                        };
                }
            }

            return product;
        }

        public bool Insert(string name, int categoryId, int supplierId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                var sql = "insert into product(name, category_id, supplier_id) values (@name, @categoryId, @supplierId);";
                command.CommandText = sql;
                command.Parameters.Add(new SqlParameter("@name", name));
                command.Parameters.Add(new SqlParameter("@categoryId", categoryId));
                command.Parameters.Add(new SqlParameter("@supplierId", supplierId));
                command.ExecuteNonQuery();
            }

            return true;
        }

        public bool Update(int id, string name, int categoryId, int supplierId)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                var sql = "update product set name = @name, categoryId = @categoryId, supplierId = @supplierId where id = @id;";
                command.CommandText = sql;
                command.Parameters.Add(new SqlParameter("@name", name));
                command.Parameters.Add(new SqlParameter("@categoryId", categoryId));
                command.Parameters.Add(new SqlParameter("@supplierId", supplierId));
                command.Parameters.Add(new SqlParameter("@id", id));
                command.ExecuteNonQuery();
            }

            return true;
        }

        public bool Delete(int id)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                var sql = "delete from product where id = @id;";
                command.CommandText = sql;
                command.Parameters.Add(new SqlParameter("@id", id));
                command.ExecuteNonQuery();
            }

            return true;
        }
    }
}