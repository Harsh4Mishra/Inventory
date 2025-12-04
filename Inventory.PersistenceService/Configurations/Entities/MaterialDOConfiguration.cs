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
                .ToTable("material");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("int")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder
                .Property(e => e.Sku)
                .HasColumnType("text")
                .IsRequired()
                .HasColumnOrder(2);

            builder
                .Property(e => e.Name)
                .HasColumnType("text")
                .IsRequired()
                .HasColumnOrder(3);

            builder
                .Property(e => e.Category)
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(4);

            builder
                .Property(e => e.Subcategory)
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(5);

            builder
                .Property(e => e.CasNumber)
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(6);

            builder
                .Property(e => e.Description)
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(7);

            builder
                .Property(e => e.IsActive)
                .HasColumnType("boolean")
                .HasDefaultValue(true)
                .HasColumnOrder(8);

            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("uuid")
                .HasColumnOrder(9);

            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("now()")
                .HasColumnOrder(10);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("uuid")
                .IsRequired(false)
                .HasColumnOrder(11);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("timestamptz")
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
