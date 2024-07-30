using LH.ManageProduct.Api.Extensions;
using LH.ManageProduct.Business.Interfaces;
using LH.ManageProduct.Business.Notification;
using LH.ManageProduct.Business.Services;
using LH.ManageProduct.Data.Context;
using LH.ManageProduct.Data.Repository;
using LH.ManageProduct.Data.UoW;
using Microsoft.Extensions.Options;
using Swashbuckle.AspNetCore.SwaggerGen;
using System.Data;

namespace LH.ManageProduct.Api.Configurations
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection services)
        {
            services.AddScoped<DBConnection>();

            services.AddScoped<IDbConnection>(provider =>
            {
                var dbConnection = provider.GetRequiredService<DBConnection>();
                return dbConnection.OpenConnection(); // Retorna uma conexão aberta
            });

            // Data
            services.AddScoped<ManageProductDbContext>();
            services.AddScoped<IUnitOfWork, UnitOfWork>(); // EF
            services.AddScoped<IDapperUnitOfWork, DapperUnitOfWork>(); // Dapper

            // Repositórios        
            services.AddScoped<IDepartmentRepository, DepartmentRepository>();
            services.AddScoped<IProductRepository, ProductRepository>();

            // Serviços           
            services.AddScoped<INotification, AppNotifier>();
            services.AddScoped<IDepartamentService, DepartmentService>();
            services.AddScoped<IProductService, ProductService>();

            services.AddSingleton<IHttpContextAccessor, HttpContextAccessor>();
            services.AddScoped<IUser,AspNetUser>();

            services.AddTransient<IConfigureOptions<SwaggerGenOptions>, ConfigureSwaggerOptions>();

            return services;
        }
    }
}
