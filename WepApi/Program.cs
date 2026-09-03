using Application;
using Infrastructure;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace WepApi
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddOpenApi();

            // JWT Authentication
            var jwtKey = builder.Configuration["Jwt:Key"]!;
            var jwtIssuer = builder.Configuration["Jwt:Issuer"]!;

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = jwtIssuer,
                        ValidAudience = jwtIssuer,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
                    };
                });

            builder.Services.AddAuthorization();

            // Swagger with JWT support
            builder.Services.AddSwaggerGen();

            builder.Services.AddBusinessServices();
            builder.Services.AddDataAccessServices(builder.Configuration);
            builder.Services.AddAutoMapper(typeof(MappingProfile));

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            // ═══════════════════════════════════════════════════════════
            // SEED DATA: İlk çalıştırmada Kurucu Müdür hesabı oluştur
            // GirisNo: admin  |  Şifre: admin123
            // ═══════════════════════════════════════════════════════════
            using (var scope = app.Services.CreateScope())
            {
                var context = scope.ServiceProvider.GetRequiredService<Infrastructure.AppDbContext>();

                // Veritabanında hiç User yoksa Kurucu Müdürü oluştur
                if (!context.Users.Any())
                {
                    var adminUser = new Domain.Entity.User
                    {
                        GirisNo = "admin",
                        PasswordHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                        Role = Domain.Entity.Role.Mudur,
                        IsFirstLogin = true
                    };
                    context.Users.Add(adminUser);
                    context.SaveChanges();

                    Console.WriteLine("╔════════════════════════════════════════════╗");
                    Console.WriteLine("║  KURUCU MÜDÜR HESABI OLUŞTURULDU!         ║");
                    Console.WriteLine("║  GirisNo: admin   |   Şifre: admin123     ║");
                    Console.WriteLine("║  İlk girişte şifrenizi değiştirin!        ║");
                    Console.WriteLine("╚════════════════════════════════════════════╝");
                }
            }

            app.Run();
        }
    }
}
