using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace CentiroHomeAssignment.Data
{
    public static class DataServiceRegistration
    {
        public static IServiceCollection AddDataServices(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddDbContext<CentiroHomeAssignmentDbContext>(options => options.UseSqlServer(configuration.GetConnectionString("CentiroConString"),
                b => b.MigrationsAssembly(typeof(CentiroHomeAssignmentDbContext).Assembly.FullName)));

            return services;
        }
    }
}
