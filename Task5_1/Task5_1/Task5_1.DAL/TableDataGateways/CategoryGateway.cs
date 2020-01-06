using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Data.SqlClient;
using Task5_1.DAL.Entities;

namespace Task5_1.DAL.TableDataGateways
{
    public class CategoryGateway
    {
        private string _connectionString;

        public CategoryGateway(string connectionString)
        {
            _connectionString = connectionString;
        }

        public ICollection<Category> FindAll()
        {
            var categories = new Collection<Category>();

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                var sql = "select id, name from category;";
                command.CommandText = sql;
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        categories.Add
                        (
                            new Category()
                            {
                                Id = reader.GetInt32(0),
                                Name = reader.GetString(1),
                            }
                        );
                    }
                }
            }

            return categories;
        }

        public Category FindById(int id)
        {
            Category category = null;

            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                var sql = "select id, name from category where id = @id;";
                command.CommandText = sql;
                command.Parameters.Add(new SqlParameter("@id", id));
                var reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    reader.Read();
                    category = 
                        new Category()
                        {
                            Id = reader.GetInt32(0),
                            Name = reader.GetString(1),
                        };
                }
            }

            return category;
        }

        public bool Insert(string name)
        {
            using (var connection = new SqlConnection(_connectionString))
            {
                connection.Open();
                var command = connection.CreateCommand();
                var sql = "insert into category(name) values (@name);";
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
                var sql = "update category set name = @name where id = @id;";
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
                var sql = "delete from category where id = @id;";
                command.CommandText = sql;
                command.Parameters.Add(new SqlParameter("@id", id));
                command.ExecuteNonQuery();
            }

            return true;
        }
    }
}