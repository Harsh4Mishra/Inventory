using Inventory.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.PersistenceService.Configurations.Entities
{
    public sealed class EnumTypeConfiguration
        : IEntityTypeConfiguration<EnumTypeDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<EnumTypeDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefEnumType");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("INT")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);
            builder
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(2);
            builder
                .Property(e => e.Code)
                .HasColumnType("VARCHAR(20)")
                .HasColumnOrder(3);
            builder
                .Property(e => e.Description)
                .HasColumnType("VARCHAR(500)")
                .HasColumnOrder(4)
                .IsRequired(false);
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
                .HasColumnOrder(7)
                .IsRequired(false);
            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(8)
                .IsRequired(false);
            builder
                .Property(e => e.IsActive)
                .HasColumnType("BIT")
                .HasColumnOrder(9);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_RefEnumType_Id");

            // Configure index(s)
            builder
                .HasIndex(e => e.Code)
                .IsUnique()
                .HasDatabaseName("IX_RefEnumType_Code");

            builder
                .HasIndex(e => e.Name)
                .IsUnique()
                .HasDatabaseName("IX_RefEnumType_Name");

            // Configure relationship(s)
            builder.HasMany(e => e.EnumValues)
                   .WithOne()
                   .OnDelete(DeleteBehavior.Cascade);

            // Use field-backed navigation for encapsulation
            builder.Navigation(e => e.EnumValues)
                   .UsePropertyAccessMode(PropertyAccessMode.Field);
        }

        #endregion
    }
}
