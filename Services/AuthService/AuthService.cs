namespace VG.Services.AuthService
{
    using Dapper;
    using System.Data;
    using VG.Common.Params.Auth;
    using VG.domain.Entities.Login;
    using VG.Services.Interfaces;

    public class AuthService : IAuthService
    {
        private readonly IEnvService envService;
        private readonly TokenService tokenService;

        public AuthService(IEnvService envService, TokenService tokenService) {
            this.envService = envService;
            this.tokenService = tokenService;
        }
        
        public async Task SaveUserAsync(Registration user)
        {
            // Password should be encrypted in database.
            string hashedPassword = BCrypt.Net.BCrypt.HashPassword(user.Password);

            var newUser = new User()
            {
                Email = user.Email,
                Password = hashedPassword,
                Status = Domain.Entities.Enum.RecordStatus.Active,
                Contact = "09010239102931",
                Verified = true,
                VerificationTerms = "email"
            };


            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(this.envService.DbConnectionString))
            {
                connection.Open();
                 string sql = @"
                INSERT INTO Users (Email, Password, Contact, Verified, VerificationTerms, UserTypeId)
                VALUES 
                (@Email, @Password, @Contact, @Verified, @VerificationTerms, 2);";
                
                await connection.ExecuteAsync(sql, newUser);
            }
        }

        public async Task<(User?, string)> LoginUserAsync(Login login)
        {
            using (IDbConnection connection = new MySql.Data.MySqlClient.MySqlConnection(this.envService.DbConnectionString))
            {
                connection.Open();
                string sql = @"SELECT * FROM Users WHERE Email = @Email AND Deleted = 0 AND Status = 'Active'";
                var user =  connection.QueryFirstOrDefaultAsync<User>(sql, new { login.Email }).Result;

                bool isMatch = BCrypt.Net.BCrypt.Verify(login.Password, user == null ? string.Empty : user.Password);

                if (!isMatch)
                {
                    Console.WriteLine($"Password is matched: {login.Email}");

                    string Token = this.tokenService.GenerateJwtToken(user!);

                    return (user, Token);
                }
                return (null, "Login error.");
            }
        }
    }
}
