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
    public sealed class ProductDOConfiguration : IEntityTypeConfiguration<ProductDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<ProductDO> builder)
        {
            // Configure table name
            builder
                .ToTable("product");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1);

            builder
                .Property(e => e.Name)
                .HasColumnType("text")
                .IsRequired()
                .HasColumnOrder(2);

            builder
                .Property(e => e.Sku)
                .HasColumnType("text")
                .HasColumnOrder(3);

            builder
                .Property(e => e.BomId)
                .HasColumnType("uuid")
                .HasColumnOrder(4);

            builder
                .Property(e => e.IsActive)
                .HasColumnType("boolean")
                .HasDefaultValue(true)
                .HasColumnOrder(5);

            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(6);

            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("timestamptz")
                .HasColumnOrder(7);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(8);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("timestamptz")
                .IsRequired(false)
                .HasColumnOrder(9);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_product_id");

            // Configure index(s)
            builder
                .HasIndex(e => e.Sku)
                .IsUnique()
                .HasDatabaseName("IX_product_sku");

            builder
                .HasIndex(e => e.BomId)
                .HasDatabaseName("IX_product_bom_id");

            builder
                .HasIndex(e => e.IsActive)
                .HasDatabaseName("IX_product_is_active");

            // Configure foreign key
            builder
                .HasOne<BomDO>() // Assuming you have BomDO entity
                .WithMany() // Adjust if BomDO has navigation property
                .HasForeignKey(e => e.BomId)
                .HasConstraintName("FK_product_bom_id")
                .OnDelete(DeleteBehavior.Restrict);
        }

        #endregion
    }
}
