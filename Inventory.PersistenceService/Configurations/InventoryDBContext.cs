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
        //public DbSet<InventoryTransactionDO> InventoryTransactions { get; set; }
        public DbSet<AllocationDO> Allocations { get; set; }

        #endregion

        #region Methods

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            // System schema tables
            modelBuilder.Entity<EnumTypeDO>().ToTable("RefEnumType", schema: "system");
            modelBuilder.Entity<EnumValueDO>().ToTable("RefEnumValue", schema: "system");
            modelBuilder.Entity<RoleDO>().ToTable("RefRole", schema: "system");
            modelBuilder.Entity<UserRoleDO>().ToTable("RefUserRole", schema: "system");
            modelBuilder.Entity<AppModuleDO>().ToTable("RefAppModule", schema: "system");
            modelBuilder.Entity<PermissionDO>().ToTable("RefPermission", schema: "system");
            modelBuilder.Entity<RolePermissionDO>().ToTable("RefRolePermission", schema: "system");

            //// Master schema tables
            modelBuilder.Entity<OrganizationDO>().ToTable("RefOrganization", schema: "master");
            modelBuilder.Entity<UserDO>().ToTable("RefUser", schema: "master");

            //// Inventory schema tables
            modelBuilder.Entity<VendorDO>().ToTable("Vendor", schema: "inventory");
            modelBuilder.Entity<MaterialDO>().ToTable("Material", schema: "inventory");
            modelBuilder.Entity<MaterialBatchDO>().ToTable("MaterialBatch", schema: "inventory");
            modelBuilder.Entity<VerifiedMaterialDO>().ToTable("VerifiedMaterial", schema: "inventory");
            modelBuilder.Entity<StorageSectionDO>().ToTable("StorageSection", schema: "inventory");
            modelBuilder.Entity<WarehouseDO>().ToTable("Warehouse", schema: "inventory");
            modelBuilder.Entity<AisleDO>().ToTable("Aisle", schema: "inventory");
            modelBuilder.Entity<RowLocDO>().ToTable("RowLoc", schema: "inventory");
            modelBuilder.Entity<TrayDO>().ToTable("Tray", schema: "inventory");
            modelBuilder.Entity<WarehouseItemDO>().ToTable("WarehouseItem", schema: "inventory");
            modelBuilder.Entity<BomCategoryDO>().ToTable("BomCategory", schema: "inventory");
            modelBuilder.Entity<MaterialStorageRuleDO>().ToTable("MaterialStorageRule", schema: "inventory");
            modelBuilder.Entity<BomDO>().ToTable("Bom", schema: "inventory");
            modelBuilder.Entity<BomItemDO>().ToTable("BomItem", schema: "inventory");
            modelBuilder.Entity<BomItemDispositionDO>().ToTable("BomItemDisposition", schema: "inventory");
            modelBuilder.Entity<ProductDO>().ToTable("Product", schema: "inventory");
            //modelBuilder.Entity<InventoryTransactionDO>().ToTable("InventoryTransaction", schema: "inventory");
            modelBuilder.Entity<AllocationDO>().ToTable("Allocation", schema: "inventory");


        }


        #endregion
    }
}
