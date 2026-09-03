using Application.Services;
using Domain.Interface;
using Infrastructure.Repos;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Infrastructure
{
    public static class DataAccessRegistration
    {
 
        public static void AddDataAccessServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<AppDbContext>(options =>
                options.UseSqlServer(configuration.GetConnectionString("DefaultConnection")));

            // Eğer Repository'leriniz varsa onları da burada kayıt edebilirsiniz:
            // services.AddScoped<IPersonelRepository, PersonelRepository>();
                services.AddScoped<IPersonelRepo,PersoneRepo>();
                services.AddScoped<IDersRepo,DersRepo>();
                services.AddScoped<IVeliRepo,VeliRepo>();
               services.AddScoped<IProgramRepo, ProgramRepo>();
                services.AddScoped<ISinifRepo, SinifRepo>();
                services.AddScoped<IOgrenciRepo, OgrenciRepo>();
                services.AddScoped<ISinavRepo, SinavRepo>();
                services.AddScoped<IOgrenciSinavRepo, OgrenciSinavRepo>();
                services.AddScoped<IUserRepo, UserRepo>();
        }
    }
}

