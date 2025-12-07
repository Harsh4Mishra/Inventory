using Inventory.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.PersistenceService.Configurations.Entities
{
    public sealed class MaterialDOConfiguration : IEntityTypeConfiguration<MaterialDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<MaterialDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefMaterial");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("INT")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder
                .Property(e => e.Sku)
                .HasColumnType("VARCHAR(50)")
                .IsRequired()
                .HasColumnOrder(2);

            builder
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(50)")
                .IsRequired()
                .HasColumnOrder(3);

            builder
                .Property(e => e.Category)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(4);

            builder
                .Property(e => e.Subcategory)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(5);

            builder
                .Property(e => e.CasNumber)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(6);

            builder
                .Property(e => e.Description)
                .HasColumnType("VARCHAR(500)")
                .IsRequired(false)
                .HasColumnOrder(7);

            builder
                .Property(e => e.IsActive)
                .HasColumnType("BIT")
                .HasDefaultValue(true)
                .HasColumnOrder(8);

            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(9);

            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()")
                .HasColumnOrder(10);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(11);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(12);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_material_id");

            // Configure unique constraints
            builder
                .HasIndex(e => e.Sku)
                .IsUnique()
                .HasDatabaseName("IX_material_sku_unique");

            // Configure index(s)
            builder
                .HasIndex(e => e.Name)
                .HasDatabaseName("IX_material_name");

            builder
                .HasIndex(e => e.Category)
                .HasDatabaseName("IX_material_category");

            builder
                .HasIndex(e => e.Subcategory)
                .HasDatabaseName("IX_material_subcategory");

            builder
                .HasIndex(e => e.CasNumber)
                .HasDatabaseName("IX_material_cas_number");

            builder
                .HasIndex(e => e.IsActive)
                .HasDatabaseName("IX_material_is_active");

            // Configure query filters (optional)
            builder
                .HasQueryFilter(m => m.IsActive); // This will automatically filter active materials in queries
        }

        #endregion
    }
}
