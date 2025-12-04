using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Inventory.Domain.DomainObjects;

namespace Inventory.PersistenceService.Configurations.Entities
{
    public sealed class RoleDOConfiguration : IEntityTypeConfiguration<RoleDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<RoleDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefRole");

            //Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("int")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(2);
            builder
                .Property(e => e.Description)
                .HasColumnType("VARCHAR(100)")
                .HasColumnOrder(3);
            builder
                .Property(e => e.Code)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(4);
            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(5);
            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
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
            builder
              .Property(e => e.IsActive)
              .HasColumnType("BIT")
              .HasColumnOrder(9);

            //Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_RefRole_Id");

            //Configure index(s)
            builder
                .HasIndex(e => e.Code)
                .IsUnique()
                .HasDatabaseName("IX_RefRole_Code");

            //Configure relations

            //Configure foreign key(s) and relations
            //builder
            //    .HasMany(e => e.OrganizationRoles)
            //    .WithOne(e => e.Role);

        }

        #endregion
    }
}
