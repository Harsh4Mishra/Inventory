using Inventory.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Inventory.PersistenceService.Configurations
{
    public sealed class WarehouseItemDOConfiguration : IEntityTypeConfiguration<WarehouseItemDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<WarehouseItemDO> builder)
        {
            // Configure table name
            builder
                .ToTable("warehouse_item");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1);

            builder
                .Property(e => e.MaterialBatchId)
                .HasColumnType("uuid")
                .HasColumnOrder(2);

            builder
                .Property(e => e.WarehouseId)
                .HasColumnType("uuid")
                .HasColumnOrder(3);

            builder
                .Property(e => e.AisleId)
                .HasColumnType("uuid")
                .HasColumnOrder(4);

            builder
                .Property(e => e.RowId)
                .HasColumnType("uuid")
                .HasColumnOrder(5);

            builder
                .Property(e => e.TrayId)
                .HasColumnType("uuid")
                .HasColumnOrder(6);

            builder
                .Property(e => e.Quantity)
                .HasColumnType("numeric")
                .HasDefaultValue(0)
                .HasColumnOrder(7);

            builder
                .Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnOrder(8);

            builder
                .Property(e => e.Specification)
                .HasColumnType("jsonb")
                .HasColumnOrder(9);

            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(10);

            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("timestamptz")
                .HasColumnOrder(11);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(12);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("timestamptz")
                .IsRequired(false)
                .HasColumnOrder(13);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_warehouse_item_id");

            // Configure foreign keys
            builder
                .HasOne<MaterialBatchDO>()
                .WithMany()
                .HasForeignKey(e => e.MaterialBatchId)
                .HasConstraintName("FK_warehouse_item_material_batch");

            builder
                .HasOne<WarehouseDO>()
                .WithMany()
                .HasForeignKey(e => e.WarehouseId)
                .HasConstraintName("FK_warehouse_item_warehouse");

            builder
                .HasOne<AisleDO>()
                .WithMany()
                .HasForeignKey(e => e.AisleId)
                .HasConstraintName("FK_warehouse_item_aisle");

            builder
                .HasOne<RowLocDO>()
                .WithMany()
                .HasForeignKey(e => e.RowId)
                .HasConstraintName("FK_warehouse_item_row");

            builder
                .HasOne<TrayDO>()
                .WithMany()
                .HasForeignKey(e => e.TrayId)
                .HasConstraintName("FK_warehouse_item_tray");

            // Configure index(s)
            builder
                .HasIndex(e => e.MaterialBatchId)
                .HasDatabaseName("IX_warehouse_item_material_batch_id");

            builder
                .HasIndex(e => e.WarehouseId)
                .HasDatabaseName("IX_warehouse_item_warehouse_id");

            builder
                .HasIndex(e => new { e.WarehouseId, e.AisleId, e.RowId, e.TrayId })
                .HasDatabaseName("IX_warehouse_item_location");

            builder
                .HasIndex(e => e.Name)
                .HasDatabaseName("IX_warehouse_item_name");

            // Configure default values
            builder
                .Property(e => e.Quantity)
                .HasDefaultValue(0);
        }

        #endregion
    }
}
