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
            services.AddScoped<ISinifService, SinifService>();
            services.AddScoped<IOgrenciService, OgrenciService>();
            services.AddScoped<ISinavService, SinavService>();
            services.AddScoped<IOgrenciSinavService, OgrenciSinavService>();
            services.AddScoped<IProgramService, ProgramService>();
            services.AddScoped<IAuthService, AuthService>();
            // Diğer bağımlılıklar...
        }
    }

}
