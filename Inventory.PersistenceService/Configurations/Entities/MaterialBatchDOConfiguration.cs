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
    public sealed class MaterialBatchDOConfiguration : IEntityTypeConfiguration<MaterialBatchDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<MaterialBatchDO> builder)
        {
            // Configure table name
            builder
                .ToTable("material_batch");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1);

            builder
                .Property(e => e.MaterialId)
                .HasColumnType("uuid")
                .IsRequired()
                .HasColumnOrder(2);

            builder
                .Property(e => e.VendorId)
                .HasColumnType("uuid")
                .IsRequired(false)
                .HasColumnOrder(3);

            builder
                .Property(e => e.BatchCode)
                .HasColumnType("text")
                .IsRequired()
                .HasColumnOrder(4);

            builder
                .Property(e => e.Barcode)
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(5);

            builder
                .Property(e => e.ManufactureDate)
                .HasColumnType("date")
                .IsRequired(false)
                .HasColumnOrder(6);

            builder
                .Property(e => e.ExpiryDate)
                .HasColumnType("date")
                .IsRequired(false)
                .HasColumnOrder(7);

            builder
                .Property(e => e.Quantity)
                .HasColumnType("numeric")
                .HasDefaultValue(0)
                .HasColumnOrder(8);

            builder
                .Property(e => e.RemainingQuantity)
                .HasColumnType("numeric")
                .HasDefaultValue(0)
                .HasColumnOrder(9);

            builder
                .Property(e => e.StorageSectionId)
                .HasColumnType("uuid")
                .IsRequired(false)
                .HasColumnOrder(10);

            builder
                .Property(e => e.LocationText)
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(11);

            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(12);

            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("now()")
                .HasColumnOrder(13);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(14);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("timestamptz")
                .IsRequired(false)
                .HasColumnOrder(15);

            builder
                .Property(e => e.IsActive)
                .HasColumnType("boolean")
                .HasDefaultValue(true)
                .HasColumnOrder(16);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_material_batch_id");

            // Configure foreign keys
            builder
                .HasOne(e => e.Material)
                .WithMany()
                .HasForeignKey(e => e.MaterialId)
                .HasConstraintName("FK_material_batch_material_id")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne(e => e.Vendor)
                .WithMany()
                .HasForeignKey(e => e.VendorId)
                .HasConstraintName("FK_material_batch_vendor_id")
                .OnDelete(DeleteBehavior.Restrict);

            // Configure unique constraints
            builder
                .HasIndex(e => e.BatchCode)
                .IsUnique()
                .HasDatabaseName("IX_material_batch_batch_code_unique");

            builder
                .HasIndex(e => e.Barcode)
                .IsUnique()
                .HasDatabaseName("IX_material_batch_barcode_unique")
                .HasFilter("barcode IS NOT NULL");

            // Configure index(s)
            builder
                .HasIndex(e => e.MaterialId)
                .HasDatabaseName("IX_material_batch_material_id");

            builder
                .HasIndex(e => e.VendorId)
                .HasDatabaseName("IX_material_batch_vendor_id");

            builder
                .HasIndex(e => e.ExpiryDate)
                .HasDatabaseName("IX_material_batch_expiry_date");

            builder
                .HasIndex(e => e.StorageSectionId)
                .HasDatabaseName("IX_material_batch_storage_section_id");

            builder
                .HasIndex(e => e.IsActive)
                .HasDatabaseName("IX_material_batch_is_active");

            // Configure query filters (optional)
            builder
                .HasQueryFilter(m => m.IsActive); // This will automatically filter active material batches in queries
        }

        #endregion
    }
}
