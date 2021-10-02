using Dapper;
using Dapper.Contrib.Extensions;
using SEDC.NotesApp.DataAccess.Interfaces;
using SEDC.NotesApp.Domain.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SEDC.NotesApp.DataAccess.Implementations
{
    public class UserDapperRepository : IRepository<User>
    {
        private string _connectionString;

        public UserDapperRepository(string connectionString)
        {
            _connectionString = connectionString;
        }

        public void Delete(User entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                string sql = "DELETE FROM dbo.Users WHERE Id = @Id";
                sqlConnection.Execute(sql, new { Id = entity.Id });
            }
        }

        public List<User> GetAll()
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                List<User> usersDb = sqlConnection.Query<User>("SELECT * FROM dbo.Users").ToList();
                return usersDb;
            }
        }

        public User GetById(int id)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();

                User usersDb = sqlConnection.Query<User>("SELECT * FROM dbo.Users WHERE Id = @Id", new { Id = id }).FirstOrDefault();
                return usersDb;
            }
        }

        public void Insert(User entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Insert<User>(entity);
            }
        }

        public void Update(User entity)
        {
            using (SqlConnection sqlConnection = new SqlConnection(_connectionString))
            {
                sqlConnection.Open();
                sqlConnection.Update<User>(entity);
            }
        }
    }
}
