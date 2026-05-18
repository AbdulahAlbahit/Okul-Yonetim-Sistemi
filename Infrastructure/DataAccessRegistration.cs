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
                services.AddScoped<IPersonelRepo,PersonelRepo>();
                services.AddScoped<IDersRepo,DersRepo>();
        }
    }
}

