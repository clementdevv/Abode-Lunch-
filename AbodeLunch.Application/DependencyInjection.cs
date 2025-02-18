using System.Reflection;
using AbodeLunch.Application.Authentication.Commands.Behaviours;
using AbodeLunch.Application.Authentication.Commands.Register;
using AbodeLunch.Application.Authentication.Common;
using ErrorOr;
using FluentValidation;
using MediatR;
using Microsoft.Extensions.DependencyInjection;

namespace AbodeLunch.Application;

public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)         
        {            
            services.AddMediatR(typeof(DependencyInjection).Assembly);
            services.AddScoped(
                typeof(IPipelineBehavior<,>),
                typeof(ValidationBehaviour<,>));
            
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            return services;
        }
    }
