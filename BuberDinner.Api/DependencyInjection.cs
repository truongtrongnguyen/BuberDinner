using BuberDinner.Api.Common.Errors;
using BuberDinner.Api.Mapping;
using Microsoft.AspNetCore.Mvc.Infrastructure;

namespace BuberDinner.Api
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddPresentation(this IServiceCollection services)
        {
            services.AddControllers();

            // Error 
            services.AddSingleton<ProblemDetailsFactory, BuberDinnerProblemDetailsFactory>();

            // Scan assembly config in IMapper 
            services.AddMapping();

            return services;
        }
    }
}
