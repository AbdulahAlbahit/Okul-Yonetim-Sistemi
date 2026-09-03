using Application.CreationDto;
using Application.DetailDto;
using Application.IServices;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace WepApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController(IAuthService authService) : ControllerBase
    {
        [HttpPost("login")]
        public async Task<ActionResult<TokenResponseDto>> Login([FromBody] LoginDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var result = await authService.LoginAsync(dto);
            if (result == null)
                return Unauthorized("GirisNo veya şifre hatalı.");

            return Ok(result);
        }

        [HttpPost("change-password")]
        [Authorize]
        public async Task<IActionResult> ChangePassword([FromBody] ChangePasswordDto dto)
        {
            if (!ModelState.IsValid) return BadRequest(ModelState);

            var success = await authService.ChangePasswordAsync(dto);
            if (!success)
                return BadRequest("Eski şifre hatalı veya kullanıcı bulunamadı.");

            return Ok(new { message = "Şifre başarıyla değiştirildi." });
        }
    }
}
