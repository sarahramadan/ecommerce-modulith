using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.DependencyInjection;
using Shared.Auth;
using Shared.Interceptor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared
{
    public static class SharedExtension
    {
        public static IServiceCollection AddSharedModule(this IServiceCollection service)
        {
            service.AddScoped<IAuthorization, Authorization>();
            service.AddScoped<IInterceptor, AuditDbContextInterceptor>();
            return service;
        }
    }
}
