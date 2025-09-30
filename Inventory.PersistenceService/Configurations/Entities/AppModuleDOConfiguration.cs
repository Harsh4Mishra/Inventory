using Inventory.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Inventory.PersistenceService.Configurations.Entities
{
    public sealed class AppModuleDOConfiguration : IEntityTypeConfiguration<AppModuleDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<AppModuleDO> builder)
        {
            // Configure table name
            builder
                .ToTable("app_module");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1);

            builder
                .Property(e => e.TenantId)
                .HasColumnType("uuid")
                .HasColumnOrder(2);

            builder
                .Property(e => e.Code)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(3);

            builder
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(100)")
                .HasColumnOrder(4);

            builder
                .Property(e => e.Description)
                .HasColumnType("VARCHAR(500)")
                .IsRequired(false)
                .HasColumnOrder(5);

            builder
                .Property(e => e.IsActive)
                .HasColumnType("BIT")
                .HasDefaultValue(true)
                .HasColumnOrder(6);

            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(7);

            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()")
                .HasColumnOrder(8);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(9);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(10);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_app_module_Id");

            // Configure index(s)
            builder
                .HasIndex(e => e.Code)
                .HasDatabaseName("IX_app_module_Code");

            builder
                .HasIndex(e => e.TenantId)
                .HasDatabaseName("IX_app_module_TenantId");

            builder
                .HasIndex(e => e.IsActive)
                .HasDatabaseName("IX_app_module_IsActive");

            builder
                .HasIndex(e => new { e.TenantId, e.Code })
                .IsUnique()
                .HasDatabaseName("IX_app_module_TenantId_Code_Unique");

            // Configure foreign key(s) and relations
            builder
                .HasOne<OrganizationDO>()
                .WithMany()
                .HasForeignKey(e => e.TenantId)
                .HasConstraintName("FK_app_module_TenantId")
                .OnDelete(DeleteBehavior.Restrict);
        }

        #endregion
    }
}
