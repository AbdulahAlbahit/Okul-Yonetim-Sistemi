using Application.CreationDto;
using Application.DetailDto;
using Domain.Entity;
using System.Threading.Tasks;

namespace Application.IServices
{
    public interface IAuthService
    {
        Task<TokenResponseDto> LoginAsync(LoginDto loginDto);
        Task<bool> ChangePasswordAsync(ChangePasswordDto dto);
        Task CreateUserForOgrenciAsync(Ogrenci ogrenci);
        Task CreateUserForPersonelAsync(Personel personel);
    }
}
