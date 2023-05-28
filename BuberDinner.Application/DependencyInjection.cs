using MediatR;
using Microsoft.Extensions.DependencyInjection;


namespace BuberDinner.Application
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            // Link Setup: https://github.com/jbogard/MediatR
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(DependencyInjection).Assembly));
            return services;
        }
    }
}
