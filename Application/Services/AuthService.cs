using Application.CreationDto;
using Application.DetailDto;
using Application.IServices;
using Domain.Entity;
using Domain.Interface;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services
{
    public class AuthService(IUserRepo userRepo, IConfiguration configuration) : IAuthService
    {
        // ═══════════════════════════════════════════════════════════
        // GİRİŞ: Kullanıcı GirisNo + Şifre ile giriş yapar.
        // İlk girişte varsayılan şifre (GirisNo'nun kendisi) ile girer.
        // Response'da IsFirstLogin=true gelirse, frontend şifre değiştirme ekranını açar.
        // ═══════════════════════════════════════════════════════════
        public async Task<TokenResponseDto> LoginAsync(LoginDto dto)
        {
            var user = await userRepo.GetByGirisNoAsync(dto.GirisNo);

            if (user == null || !BCrypt.Net.BCrypt.Verify(dto.Password, user.PasswordHash))
                return null; // Controller 401 döndürecek

            return BuildTokenResponse(user);
        }

        // ═══════════════════════════════════════════════════════════
        // ŞİFRE DEĞİŞTİR: Kullanıcı eski şifresini doğrulayıp yeni şifre belirler.
        // İlk giriş sonrası zorunlu olarak çağrılır.
        // ═══════════════════════════════════════════════════════════
        public async Task<bool> ChangePasswordAsync(ChangePasswordDto dto)
        {
            var user = await userRepo.GetByGirisNoAsync(dto.GirisNo);
            if (user == null)
                return false;

            // Eski şifreyi doğrula
            if (!BCrypt.Net.BCrypt.Verify(dto.CurrentPassword, user.PasswordHash))
                return false;

            // Yeni şifreyi kaydet
            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(dto.NewPassword);
            user.IsFirstLogin = false;
            await userRepo.UpdateAsync(user);

            return true;
        }

        // ═══════════════════════════════════════════════════════════
        // OTOMATİK HESAP: Müdür bir öğrenci eklediğinde, arka planda
        // otomatik olarak o öğrenci için bir User kaydı oluşturulur.
        // Varsayılan şifre = Öğrenci Numarası (ilk girişte değiştirecek)
        // ═══════════════════════════════════════════════════════════
        public async Task CreateUserForOgrenciAsync(Ogrenci ogrenci)
        {
            // Zaten bir hesabı varsa tekrar oluşturma
            if (await userRepo.GirisNoExistsAsync(ogrenci.Ogrenci_No))
                return;

            var user = new User
            {
                GirisNo = ogrenci.Ogrenci_No,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(ogrenci.Ogrenci_No), // Varsayılan şifre = Öğrenci No
                Role = Role.Ogrenci,
                Ogrenci_id = ogrenci.Id,
                IsFirstLogin = true
            };

            await userRepo.AddAsync(user);
        }

        // ═══════════════════════════════════════════════════════════
        // OTOMATİK HESAP: Müdür bir personel eklediğinde, arka planda
        // otomatik olarak o personel için bir User kaydı oluşturulur.
        // Varsayılan şifre = TC Kimlik No (ilk girişte değiştirecek)
        // ═══════════════════════════════════════════════════════════
        public async Task CreateUserForPersonelAsync(Personel personel)
        {
            // Zaten bir hesabı varsa tekrar oluşturma
            if (await userRepo.GirisNoExistsAsync(personel.TC))
                return;

            var role = personel.jobTitle switch
            {
                JobTitle.Mudur => Role.Mudur,
                JobTitle.MudurYardimci => Role.MudurYardimcisi,
                JobTitle.Ogretmen => Role.Ogretmen,
                _ => throw new InvalidOperationException("Geçersiz JobTitle")
            };

            var user = new User
            {
                GirisNo = personel.TC,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(personel.TC), // Varsayılan şifre = TC
                Role = role,
                personel_id = personel.PerId,
                IsFirstLogin = true
            };

            await userRepo.AddAsync(user);
        }

        // ═══════════════════════════════════════════════════════════
        // YARDIMCI METODLAR
        // ═══════════════════════════════════════════════════════════
        private TokenResponseDto BuildTokenResponse(User user)
        {
            var token = GenerateJwtToken(user);
            return new TokenResponseDto
            {
                Token = token,
                Role = user.Role.ToString(),
                GirisNo = user.GirisNo,
                IsFirstLogin = user.IsFirstLogin,
                OgrenciId = user.Ogrenci_id,
                PersonelId = user.personel_id
            };
        }

        private string GenerateJwtToken(User user)
        {
            var jwtKey = configuration["Jwt:Key"]
                ?? throw new InvalidOperationException("JWT Key is not configured.");

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey));
            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.GirisNo),
                new Claim(ClaimTypes.Role, user.Role.ToString()),
            };

            // Öğretmenin kendi dersini kontrol edebilmesi için PersonelId claim'i
            if (user.personel_id.HasValue)
                claims.Add(new Claim("PersonelId", user.personel_id.Value.ToString()));

            if (user.Ogrenci_id.HasValue)
                claims.Add(new Claim("OgrenciId", user.Ogrenci_id.Value.ToString()));

            var hours = int.Parse(configuration["Jwt:ExpirationHours"] ?? "8");

            var token = new JwtSecurityToken(
                issuer: configuration["Jwt:Issuer"],
                audience: configuration["Jwt:Issuer"],
                claims: claims,
                expires: DateTime.UtcNow.AddHours(hours),
                signingCredentials: creds
            );

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}
