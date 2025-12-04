using Inventory.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Inventory.PersistenceService.Configurations.Entities
{
    public sealed class PermissionDOConfiguration : IEntityTypeConfiguration<PermissionDO>
    {
        public void Configure(EntityTypeBuilder<PermissionDO> builder)
        {
            // Configure table name
            builder.ToTable("permission");

            // Configure columns
            builder.Property(e => e.Id)
                .HasColumnType("int")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder.Property(e => e.TenantId)
                .HasColumnType("uuid")
                .HasColumnOrder(2);

            builder.Property(e => e.Code)
                .HasColumnType("text")
                .HasColumnOrder(3);

            builder.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnOrder(4);

            builder.Property(e => e.Description)
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(5);

            builder.Property(e => e.IsActive)
                .HasColumnType("boolean")
                .HasDefaultValue(true)
                .HasColumnOrder(6);

            // Audit fields (inherited from AuditableDO)
            builder.Property(e => e.CreatedBy)
                .HasColumnType("text")
                .HasColumnOrder(7);

            builder.Property(e => e.CreatedOn)
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("now()")
                .HasColumnOrder(8);

            builder.Property(e => e.UpdatedBy)
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(9);

            builder.Property(e => e.UpdatedOn)
                .HasColumnType("timestamptz")
                .IsRequired(false)
                .HasColumnOrder(10);

            // Configure primary key
            builder.HasKey(e => e.Id)
                .HasName("PK_permission_Id");

            // Configure indexes
            builder.HasIndex(e => e.TenantId)
                .HasDatabaseName("IX_permission_TenantId");

            builder.HasIndex(e => e.Code)
                .HasDatabaseName("IX_permission_Code");

            builder.HasIndex(e => new { e.TenantId, e.Code })
                .IsUnique()
                .HasDatabaseName("IX_permission_TenantId_Code_Unique");

            builder.HasIndex(e => e.IsActive)
                .HasDatabaseName("IX_permission_IsActive");

            // Configure foreign key
            builder.HasOne<OrganizationDO>()
                .WithMany()
                .HasForeignKey(e => e.TenantId)
                .HasConstraintName("FK_permission_TenantId")
                .OnDelete(DeleteBehavior.Restrict);
        }
    }
}
