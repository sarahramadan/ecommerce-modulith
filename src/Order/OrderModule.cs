using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Order
{
    public static class OrderModule
    {
        public static IServiceCollection AddOrderModule(this IServiceCollection service)
        {

            return service;
        }

        public static IApplicationBuilder UseOrderModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
