using Application.IServices;
using Application.Services;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application
{
    public static class ServiceRegistratio
    {
        
        public static void AddBusinessServices(this IServiceCollection services)
        {
            // Kendi katmanındaki servisleri burada kaydet
            services.AddScoped<IPersonelService, PersonelService>();
           services.AddScoped<IDersService, DersService>();
            services.AddScoped<IVeliService, VeliService>();
       //    services.AddScoped<IProgramService, ProgramService> ();
            // Diğer bağımlılıklar...
        }
    }

}
