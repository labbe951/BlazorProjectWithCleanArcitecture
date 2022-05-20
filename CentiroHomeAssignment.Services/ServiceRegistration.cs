using CentiroHomeAssignment.Data;
using CentiroHomeAssignment.Data.Repositories;
using CentiroHomeAssignment.Services.Features.Files;
using CentiroHomeAssignment.Services.Features.Orders;
using CentiroHomeAssignment.Shared.IRepositories;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;

namespace CentiroHomeAssignment.Services
{
    public static class ServiceRegistration
    {
        public static IServiceCollection AddServices(this IServiceCollection services, IConfiguration configuration)
        {
            //Order Services
            services.AddScoped<IOrderRepository, OrderRepository>();
            services.AddScoped<IOrderService, OrderService>();

            //File Services
            services.AddScoped<IFileService, FileService>();

            //Mapper
            services.AddAutoMapper(Assembly.GetExecutingAssembly());

            // Data Access
            services.AddDataServices(configuration);

            return services;
        }
    }
}
