namespace VG.Services.AuthService
{
    using Dapper;
    using Microsoft.Data.SqlClient;
    using System.Data;
    using VG.Common.Params.Auth;
    using VG.domain.Entities.Login;
    using VG.Domain.Entities.Login;
    using VG.Services.Interfaces;

    public class AuthService : IAuthService
    {
        public AuthService() { }

        // public async Task<AuthResponse>

        private readonly string _connectionString = "server=127.0.0.1 :3306;database=veng;uid=root;pwd=Qwe123$%^;";

        public void SaveUser(Registration user)
        {
            var newUser = new User()
            {
                Email = user.Email,
                Password = user.Password,
                Status = Domain.Entities.Enum.RecordStatus.Active,
                Contact = "09010239102931",
                Verified = true,
                VerificationTerms = "email"
            };


            using (IDbConnection db = new SqlConnection(_connectionString))
            {
                string sql = @"
                INSERT INTO Users 
                (Email, Password, Contact, Verified, VerificationTerms)
                VALUES 
                (@Email, @Password, @Contact, @Verified, @VerificationTerms);";

                db.Execute(sql, newUser);
            }
        }
    }
}
