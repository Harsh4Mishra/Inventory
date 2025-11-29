using Inventory.Domain.DomainObjects;
using Inventory.PersistenceService.Repositories;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace Inventory.PersistenceService.Configurations
{
    public sealed class InventoryDBContext
        : DbContext
    {
        #region Ctor

        //public InventoryDBContext() { }
        public InventoryDBContext(DbContextOptions<InventoryDBContext> options) : base(options) { }

        #endregion

        #region Properties
        public DbSet<EnumTypeDO> EnumTypes { get; set; }
        public DbSet<EnumValueDO> EnumValues { get; set; }
        public DbSet<OrganizationDO> Organizations { get; set; }
        public DbSet<RoleDO> Roles { get; set; }
        public DbSet<UserDO> Users { get; set; }
        public DbSet<UserRoleDO> UserRoles { get; set; }
        public DbSet<AppModuleDO> AppModules { get; set; }
        public DbSet<PermissionDO> Permissions { get; set; }
        public DbSet<RolePermissionDO> RolePermissions { get; set; }
        public DbSet<VendorDO> Vendors { get; set; }
        public DbSet<MaterialDO> Materials { get; set; }
        public DbSet<MaterialBatchDO> MaterialBatches { get; set; }
        public DbSet<VerifiedMaterialDO> VerifiedMaterials { get; set; }
        public DbSet<StorageSectionDO> StorageSections { get; set; }
        public DbSet<WarehouseDO> Warehouses { get; set; }
        public DbSet<AisleDO> Aisles { get; set; }
        public DbSet<RowLocDO> RowLocs { get; set; }
        public DbSet<TrayDO> Trays { get; set; }
        public DbSet<WarehouseItemDO> WarehouseItems { get; set; }
        public DbSet<BomCategoryDO> BomCategories { get; set; }
        public DbSet<MaterialStorageRuleDO> MaterialStorageRules { get; set; }
        public DbSet<BomDO> Boms { get; set; }
        public DbSet<BomItemDO> BomItems { get; set; }
        public DbSet<BomItemDispositionDO> BomItemDispositions { get; set; }
        public DbSet<ProductDO> Products { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());

            //HRADBContextConfiguration.ConfigureModel(modelBuilder);

            modelBuilder.Entity<EnumTypeDO>().ToTable("RefEnumType", schema: "system");
            modelBuilder.Entity<EnumValueDO>().ToTable("RefEnumValue", schema: "system");
            modelBuilder.Entity<OrganizationDO>().ToTable("RefOrganization", schema: "master");
            modelBuilder.Entity<UserDO>().ToTable("RefUser", schema: "master");
            modelBuilder.Entity<RoleDO>().ToTable("RefRole", schema: "system");
            modelBuilder.Entity<UserRoleDO>().ToTable("RefUserRole", schema: "system");
            modelBuilder.Entity<AppModuleDO>().ToTable("RefAppModule", schema: "system");
            modelBuilder.Entity<PermissionDO>().ToTable("RefPermission", schema: "system");
            modelBuilder.Entity<RolePermissionDO>().ToTable("RefRolePermission", schema: "system");

        }


        #endregion
    }
}
