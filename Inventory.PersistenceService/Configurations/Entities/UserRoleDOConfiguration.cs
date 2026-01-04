using Inventory.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Inventory.PersistenceService.Configurations.Entities
{
    public sealed class UserRoleDOConfiguration : IEntityTypeConfiguration<UserRoleDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<UserRoleDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefUserRole");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("INT")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder
                .Property(e => e.UserId)
                .HasColumnType("INT")
                .HasColumnOrder(2);

            builder
                .Property(e => e.RoleId)
                .HasColumnType("INT")
                .HasColumnOrder(3);

            builder
                .Property(e => e.IsActive)
                .HasColumnType("BIT")
                .HasDefaultValue(true)
                .HasColumnOrder(4);

            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(5);

            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()")
                .HasColumnOrder(6);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(7);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(8);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_user_role_Id");

            // Configure index(s)
            builder
                .HasIndex(e => new { e.UserId, e.RoleId })
                .IsUnique()
                .HasDatabaseName("IX_user_role_UserID_RoleID");

            builder
                .HasIndex(e => e.UserId)
                .HasDatabaseName("IX_user_role_UserID");

            builder
                .HasIndex(e => e.RoleId)
                .HasDatabaseName("IX_user_role_RoleID");

            builder
                .HasIndex(e => e.IsActive)
                .HasDatabaseName("IX_user_role_IsActive");

            // Configure foreign key(s) and relations
            builder
                .HasOne<UserDO>()
                .WithMany()
                .HasForeignKey(e => e.UserId)
                .HasConstraintName("FK_user_role_UserID")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<RoleDO>()
                .WithMany()
                .HasForeignKey(e => e.RoleId)
                .HasConstraintName("FK_user_role_RoleID")
                .OnDelete(DeleteBehavior.Restrict);

            // Configure check constraints (optional)
            builder
    .HasCheckConstraint(
        "CK_user_role_UserID_NotZero",
        "[UserId] > 0");

            builder
                .HasCheckConstraint(
                    "CK_user_role_RoleID_NotZero",
                    "[RoleId] > 0");

        }

        #endregion
    }
}
