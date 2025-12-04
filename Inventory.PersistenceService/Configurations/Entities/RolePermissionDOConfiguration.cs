using Inventory.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Inventory.PersistenceService.Configurations.Entities
{
    public sealed class RolePermissionDOConfiguration : IEntityTypeConfiguration<RolePermissionDO>
    {
        public void Configure(EntityTypeBuilder<RolePermissionDO> builder)
        {
            // Configure table name
            builder.ToTable("role_permission");

            // Configure columns
            builder.Property(e => e.Id)
                .HasColumnType("int")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder.Property(e => e.RoleId)
                .HasColumnType("uuid")
                .HasColumnOrder(2);

            builder.Property(e => e.ModuleId)
                .HasColumnType("uuid")
                .HasColumnOrder(3);

            builder.Property(e => e.PermissionId)
                .HasColumnType("uuid")
                .HasColumnOrder(4);

            builder.Property(e => e.IsActive)
                .HasColumnType("boolean")
                .HasDefaultValue(true)
                .HasColumnOrder(5);

            // Audit fields (inherited from AuditableDO)
            builder.Property(e => e.CreatedBy)
                .HasColumnType("text")
                .HasColumnOrder(6);

            builder.Property(e => e.CreatedOn)
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("now()")
                .HasColumnOrder(7);

            builder.Property(e => e.UpdatedBy)
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(8);

            builder.Property(e => e.UpdatedOn)
                .HasColumnType("timestamptz")
                .IsRequired(false)
                .HasColumnOrder(9);

            // Configure primary key
            builder.HasKey(e => e.Id)
                .HasName("PK_role_permission_Id");

            // Configure indexes
            builder.HasIndex(e => e.RoleId)
                .HasDatabaseName("IX_role_permission_RoleId");

            builder.HasIndex(e => e.ModuleId)
                .HasDatabaseName("IX_role_permission_ModuleId");

            builder.HasIndex(e => e.PermissionId)
                .HasDatabaseName("IX_role_permission_PermissionId");

            builder.HasIndex(e => e.IsActive)
                .HasDatabaseName("IX_role_permission_IsActive");

            builder.HasIndex(e => new { e.RoleId, e.ModuleId, e.PermissionId })
                .IsUnique()
                .HasDatabaseName("IX_role_permission_RoleId_ModuleId_PermissionId_Unique");

            // Configure foreign keys
            builder.HasOne<RoleDO>()
                .WithMany()
                .HasForeignKey(e => e.RoleId)
                .HasConstraintName("FK_role_permission_RoleId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<AppModuleDO>()
                .WithMany()
                .HasForeignKey(e => e.ModuleId)
                .HasConstraintName("FK_role_permission_ModuleId")
                .OnDelete(DeleteBehavior.Restrict);

            builder.HasOne<PermissionDO>()
                .WithMany()
                .HasForeignKey(e => e.PermissionId)
                .HasConstraintName("FK_role_permission_PermissionId")
                .OnDelete(DeleteBehavior.Restrict);

            // Configure check constraints
            builder.HasCheckConstraint("CK_role_permission_RoleId_NotEmpty", "\"RoleId\" != '00000000-0000-0000-0000-000000000000'")
                .HasCheckConstraint("CK_role_permission_ModuleId_NotEmpty", "\"ModuleId\" != '00000000-0000-0000-0000-000000000000'")
                .HasCheckConstraint("CK_role_permission_PermissionId_NotEmpty", "\"PermissionId\" != '00000000-0000-0000-0000-000000000000'");
        }
    }
}
