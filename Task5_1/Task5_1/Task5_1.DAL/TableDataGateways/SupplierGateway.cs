using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Task5_1.DAL.Entities;

namespace Task5_1.DAL.TableDataGateways
{
    public class SupplierGateway
    {
        private string _connectionString;

        public SupplierGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ICollection<Supplier> FindAll()
        {
            var suppliers = new Collection<Supplier>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                var sql = "select id, name from supplier;";
                command.CommandText = sql;
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        suppliers.Add
                        (
                            new Supplier()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                            }
                        );
                    }
                }
            }

            return suppliers;
        }

        public Supplier FindById(int id)
        {
            Supplier supplier = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                var sql = "select id, name from supplier where id = @id;";
                command.CommandText = sql;
                command.Parameters.Add(new SqlParameter("@id", id));
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    supplier =
                        new Supplier()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                        };
                }
            }

            return supplier;
        }

        public bool Insert(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                var sql = "insert into supplier(name) values (@name);";
                command.CommandText = sql;
                command.Parameters.Add(new SqlParameter("@name", name));
                command.ExecuteNonQuery();
            }

            return true;
        }

        public bool Update(int id, string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                var sql = "update supplier set name = @name where id = @id;";
                command.CommandText = sql;
                command.Parameters.Add(new SqlParameter("@name", name));
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
                var sql = "delete from supplier where id = @id;";
                command.CommandText = sql;
                command.Parameters.Add(new SqlParameter("@id", id));
                command.ExecuteNonQuery();
            }

            return true;
        }

        public ICollection<Supplier> FindByCategory(string categoryName)
        {
            var suppliers = new Collection<Supplier>();
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                var sql = "select supplier.id, supplier.name from supplier where id in (select distinct supplier_id from product join supplier on product.supplier_id = supplier.id join category on product.category_id = category.id where category.name = @categoryName);";
                command.CommandText = sql;
                command.Parameters.Add(new SqlParameter("@categoryName", categoryName));
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        suppliers.Add
                        (
                            new Supplier()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1)
                            }
                        );
                    }
                }
            }

            return suppliers;
        }
    }
}