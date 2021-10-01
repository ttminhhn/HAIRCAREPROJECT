using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using HAIRCARE.APPLICATION.Base.Interfaces;
using HAIRCARE.APPLICATION.Base.Services;
using System.Reflection;


namespace HAIRCARE.APPLICATION
{
    public static class ApplicationDI
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddAutoMapper(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddMediatR(Assembly.GetExecutingAssembly());

            services.AddSingleton<IPasswordServices, PassWordServices>();
            services.AddSingleton<IJwtService, JwtServices>();
            return services;
        }
    }
}
