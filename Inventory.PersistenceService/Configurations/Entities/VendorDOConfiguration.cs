using Inventory.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.PersistenceService.Configurations.Entities
{
    public sealed class VendorDOConfiguration : IEntityTypeConfiguration<VendorDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<VendorDO> builder)
        {
            // Configure table name
            builder
                .ToTable("Vendor");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("INT")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(100)")
                .IsRequired()
                .HasColumnOrder(2);

            builder
                .Property(e => e.Type)
                .HasColumnType("VARCHAR(50)")
                .IsRequired()
                .HasColumnOrder(3);

            builder
                .Property(e => e.Contact)
                .HasColumnType("VARCHAR(100)")
                .IsRequired()
                .HasColumnOrder(4);

            builder
                .Property(e => e.IsActive)
                .HasColumnType("BIT")
                .HasColumnOrder(5);

            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(6);

            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(7);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(8);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(9);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_Vendor_Id");

            // Configure index(s)
            builder
                .HasIndex(e => e.Name)
                .HasDatabaseName("IX_Vendor_Name");

            builder
                .HasIndex(e => e.Type)
                .HasDatabaseName("IX_Vendor_Type");

            builder
                .HasIndex(e => e.IsActive)
                .HasDatabaseName("IX_Vendor_IsActive");

            // Configure value objects or complex properties if any
            // (Add here if VendorDO has any value objects)

            // Configure query filters (optional)
            builder
                .HasQueryFilter(v => v.IsActive); // This will automatically filter active vendors in queries
        }

        #endregion
    }
}
