using Microsoft.AspNetCore.Builder;
using Microsoft.Extensions.DependencyInjection;

namespace Basket
{
    public static class BasketModule
    {

        public static IServiceCollection AddBasketModule(this IServiceCollection service)
        {

            return service;
        }

        public static IApplicationBuilder UseBasketModule(this IApplicationBuilder app)
        {
            return app;
        }
    }
}
