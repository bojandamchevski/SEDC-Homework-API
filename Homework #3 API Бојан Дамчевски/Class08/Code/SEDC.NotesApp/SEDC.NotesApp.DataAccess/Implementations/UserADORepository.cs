using SEDC.NotesApp.DataAccess.Interfaces;
using SEDC.NotesApp.Domain.Models;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;

namespace SEDC.NotesApp.DataAccess.Implementations
{
    public class UserADORepository : IRepository<User>
    {
        private string _connectionString;
        public UserADORepository(string connectionString)
        {
            _connectionString = connectionString;
        }
        public void Delete(User entity)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "DELETE FROM dbo.Users WHERE Id = @id";
            sqlCommand.Parameters.AddWithValue("@id", entity.Id);

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }

        public List<User> GetAll()
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();
            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;
            sqlCommand.CommandText = "SELECT * FROM dbo.Users";
            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<User> usersDb = new List<User>();

            while (sqlDataReader.Read())
            {
                usersDb.Add(new User
                {
                    Id = (int)sqlDataReader["Id"],
                    FirstName = (string)sqlDataReader["FirstName"],
                    LastName = (string)sqlDataReader["LastName"],
                    Username = (string)sqlDataReader["Username"],
                    Address = (string)sqlDataReader["Address"],
                    SSN = (string)sqlDataReader["SSN"],
                    Age = (int)sqlDataReader["Age"]
                });
            }
            sqlConnection.Close();
            return usersDb;
        }

        public User GetById(int id)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "SELECT * FROM dbo.Users where Id = @id";
            sqlCommand.Parameters.AddWithValue("@id", id);

            SqlDataReader sqlDataReader = sqlCommand.ExecuteReader();
            List<User> usersDb = new List<User>();

            while (sqlDataReader.Read())
            {
                usersDb.Add(new User
                {
                    Id = (int)sqlDataReader["Id"],
                    FirstName = (string)sqlDataReader["FirstName"],
                    LastName = (string)sqlDataReader["LastName"],
                    Username = (string)sqlDataReader["Username"],
                    Address = (string)sqlDataReader["Address"],
                    SSN = (string)sqlDataReader["SSN"],
                    Age = (int)sqlDataReader["Age"]
                });
            }

            sqlConnection.Close();
            return usersDb.FirstOrDefault();
        }

        public void Insert(User entity)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "INSERT INTO dbo.User (FirstName, LastName, Username, Address,SSN,Age) " +
                "VALUES(@FirstName, @LastName, @Username, @Address, @SSN, @Age)";
            sqlCommand.Parameters.AddWithValue("@FirstName", entity.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", entity.LastName);
            sqlCommand.Parameters.AddWithValue("@Username", entity.Username);
            sqlCommand.Parameters.AddWithValue("@Address", entity.Address);
            sqlCommand.Parameters.AddWithValue("@SSN", entity.SSN);
            sqlCommand.Parameters.AddWithValue("@Age", entity.Age);

            sqlCommand.ExecuteNonQuery();
            sqlConnection.Close();
        }

        public void Update(User entity)
        {
            SqlConnection sqlConnection = new SqlConnection(_connectionString);
            sqlConnection.Open();

            SqlCommand sqlCommand = new SqlCommand();
            sqlCommand.Connection = sqlConnection;

            sqlCommand.CommandText = "UPDATE dbo.Users SET FirstName = @FirstName, LastName = @LastName, Username = @Username, Address = @Address, SSN = @SSN, Age = @Age" +
                " WHERE Id = @id";
            sqlCommand.Parameters.AddWithValue("@FirstName", entity.FirstName);
            sqlCommand.Parameters.AddWithValue("@LastName", entity.LastName);
            sqlCommand.Parameters.AddWithValue("@Username", entity.Username);
            sqlCommand.Parameters.AddWithValue("@Address", entity.Address);
            sqlCommand.Parameters.AddWithValue("@SSN", entity.SSN);
            sqlCommand.Parameters.AddWithValue("@Age", entity.Age);

            sqlCommand.ExecuteNonQuery();

            sqlConnection.Close();
        }
    }
}
