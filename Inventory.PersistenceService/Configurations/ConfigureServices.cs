using Inventory.Application.Contracts;
using Inventory.Domain.Contracts;
using Inventory.PersistenceService.Repositories;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.PersistenceService.Configurations
{
    public static class ConfigureServices
    {
        #region Methods

        public static IServiceCollection InjectPersistenceServices(this IServiceCollection services, IConfiguration configuration)
        {

            // 1. First validate and get connection string
            var connectionString = configuration.GetSection("DatabaseConfig:Inventory:ConnectionString").Value;
            if (string.IsNullOrEmpty(connectionString))
            {
                throw new InvalidOperationException("Database connection string not found in configuration");
            }

            services
                .AddDbContext<InventoryDBContext>(options => options.UseSqlServer(connectionString)
                .ConfigureWarnings(warnings => warnings.Ignore(Microsoft.EntityFrameworkCore.Diagnostics.RelationalEventId.PendingModelChangesWarning)),
                contextLifetime: ServiceLifetime.Scoped,
                optionsLifetime: ServiceLifetime.Scoped);

            services.AddScoped<IOrganizationRepository, OrganizationRepository>();
            services.AddScoped<IRoleRepository, RoleRepository>();
            services.AddScoped<IVendorRepository, VendorRepository>();
            services.AddScoped<IEnumTypeRepository, EnumTypeRepository>();
            services.AddScoped<IEnumValueRepository, EnumValueRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserRoleRepository, UserRoleRepository>();
            services.AddScoped<IAppModuleRepository, AppModuleRepository>();
            services.AddScoped<IPermissionRepository, PermissionRepository>();
            services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
            services.AddScoped<IMaterialRepository, MaterialRepository>();
            services.AddScoped<IMaterialBatchRepository, MaterialBatchRepository>();
            services.AddScoped<IVerifiedMaterialRepository, VerifiedMaterialRepository>();

            return services;
        }

        #endregion
    }
}
