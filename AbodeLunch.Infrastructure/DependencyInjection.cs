using System.Text;
using AbodeLunch.Application.Common.Authentication;
using AbodeLunch.Application.Common.Interfaces.Persistence;
using AbodeLunch.Application.Common.Interfaces.Services;
using AbodeLunch.Infrastructure.Authentication;
using AbodeLunch.Infrastructure.Persistence;
using AbodeLunch.Infrastructure.Persistence.Interceptors;
using AbodeLunch.Infrastructure.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace AbodeLunch.Infrastructure;

    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(
            this IServiceCollection services,
            ConfigurationManager configuration)         
        {           
            services
                .AddAuth(configuration)
                .AddPersistance();
            services.AddSingleton<IDateTimeProvider, DateTimeProvider>();

            services.AddScoped<IUserRepository, UserRepository>();
            return services;
        }

        public static IServiceCollection AddPersistance(
            this IServiceCollection services)           
            {
                services.AddDbContext<AbodeLunchDbContext>(options => options.UseSqlServer());

                services.AddScoped<PublishDomainEventInterceptor>();
                services.AddScoped<IUserRepository, UserRepository>();
                services.AddScoped<IMenuRepository, MenuRepository>();
                // services.AddScoped<IDinnerRepository, DinnerRepository>();

                return services;
            }
        public static IServiceCollection AddAuth(
            this IServiceCollection services,
            ConfigurationManager configuration)  
            {
                var JwtSettings = new JwtSettings(); 
                configuration.Bind(JwtSettings.SectionName, JwtSettings);

                services.AddSingleton(Options.Create(JwtSettings));
                services.Configure<JwtSettings>(configuration.GetSection(JwtSettings.SectionName));
                services.AddSingleton<IJwtTokenGenerator, JwtTokenGenerator>();

                services.AddAuthentication(defaultScheme: JwtBearerDefaults.AuthenticationScheme)
                    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = true,
                        ValidateAudience = true,
                        ValidateLifetime = true,
                        ValidateIssuerSigningKey = true,
                        ValidIssuer = JwtSettings.Issuer,
                        ValidAudience = JwtSettings.Audience,
                        IssuerSigningKey = new SymmetricSecurityKey(
                            Encoding.UTF8.GetBytes(JwtSettings.Secret)
                        )
            });
                return services;
            }       
    }
