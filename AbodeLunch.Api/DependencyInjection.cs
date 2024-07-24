
using AbodeLunch.Api.Common.Errors;
using AbodeLunch.Api.Common.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace AbodeLunch.Api;

public static class DependencyInjection
{
    public static IServiceCollection AddPresentation(this IServiceCollection services)
    {
        services.AddControllers();
        services.AddSingleton<ProblemDetailsFactory, AbodeLunchProblemDetailsFactory>();
        services.AddMappings();
        return services;

    }
}
