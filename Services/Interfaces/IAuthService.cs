
namespace VG.Services.Interfaces
{
    using VG.Common.Params.Auth;
    using VG.domain.Entities.Login;

    public interface IAuthService
    {
        Task SaveUserAsync(Registration user);

        Task<(User?, string)> LoginUserAsync(Login login);
    }
}
