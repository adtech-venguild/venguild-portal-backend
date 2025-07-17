using VG.Common.Params.Auth;
using VG.Domain.Entities.Login;

namespace VG.Services.Interfaces
{
    public interface IAuthService
    {
        void SaveUser(Registration user);

        User AuthenticateUser(string email, string password);
    }
}