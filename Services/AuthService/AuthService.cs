using Dapper;
using MySql.Data.MySqlClient;
using System.Data;
using VG.Common.Params.Auth;
using VG.Domain.Entities.Login;
using VG.Domain.Entities.Enum;
using VG.Services.Interfaces;

namespace VG.Services
{
    public class AuthService : IAuthService
    {
        private readonly string _connectionString = "server=127.0.0.1;port=3306;database=veng;uid=root;pwd=Qwe123$%^;";

        public void SaveUser(Registration user)
        {
            var existing = GetUserByEmail(user.Email);
            if (existing != null)
            {
                throw new Exception("Email already exists");
            }

            var newUser = new User()
            {
                Email = user.Email,
                Password = user.Password,
                Status = RecordStatus.Active,
                Contact = "09010239102931",
                Verified = true,
                VerificationTerms = "email",
                UserTypeId = 1
            };

            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                string sql = @"
                    INSERT INTO Users 
                    (Email, Password, Contact, Verified, VerificationTerms, Status, UserTypeId)
                    VALUES 
                    (@Email, @Password, @Contact, @Verified, @VerificationTerms, @Status, @UserTypeId);";

                db.Execute(sql, newUser);
            }
        }

        public User AuthenticateUser(string email, string password)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                string sql = "SELECT * FROM Users WHERE Email = @Email AND Password = @Password";
                var user = db.QueryFirstOrDefault<User>(sql, new { Email = email, Password = password });

                return user;
            }
        }

        private User GetUserByEmail(string email)
        {
            using (IDbConnection db = new MySqlConnection(_connectionString))
            {
                return db.QueryFirstOrDefault<User>("SELECT * FROM Users WHERE Email = @Email", new { Email = email });
            }
        }
    }
}
