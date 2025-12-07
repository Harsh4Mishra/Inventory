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
    public sealed class BomItemDOConfiguration : IEntityTypeConfiguration<BomItemDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<BomItemDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefBomItem");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("INT")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder
                .Property(e => e.BomId)
                .HasColumnType("INT")
                .HasColumnOrder(2);

            builder
                .Property(e => e.MaterialBatchId)
                .HasColumnType("INT")
                .HasColumnOrder(3);

            builder
                .Property(e => e.WarehouseItemId)
                .HasColumnType("INT")
                .HasColumnOrder(4);

            builder
                .Property(e => e.Quantity)
                .HasColumnType("DECIMAL(10,2)")
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
                .HasName("PK_bom_item_id");

            // Configure foreign keys
            builder
                .HasOne<BomDO>()
                .WithMany()
                .HasForeignKey(e => e.BomId)
                .HasConstraintName("FK_bom_item_bom")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<MaterialBatchDO>()
                .WithMany()
                .HasForeignKey(e => e.MaterialBatchId)
                .HasConstraintName("FK_bom_item_material_batch")
                .OnDelete(DeleteBehavior.Restrict);

            builder
                .HasOne<WarehouseItemDO>()
                .WithMany()
                .HasForeignKey(e => e.WarehouseItemId)
                .HasConstraintName("FK_bom_item_warehouse_item")
                .OnDelete(DeleteBehavior.Restrict);

            // Configure index(s)
            builder
                .HasIndex(e => e.BomId)
                .HasDatabaseName("IX_bom_item_bom_id");

            builder
                .HasIndex(e => e.MaterialBatchId)
                .HasDatabaseName("IX_bom_item_material_batch_id");

            builder
                .HasIndex(e => e.WarehouseItemId)
                .HasDatabaseName("IX_bom_item_warehouse_item_id");

            builder
                .HasIndex(e => new { e.BomId, e.MaterialBatchId, e.WarehouseItemId })
                .IsUnique()
                .HasDatabaseName("IX_bom_item_composite_unique");

            // Configure constraints
            builder
                .Property(e => e.Quantity)
                .IsRequired();
        }

        #endregion
    }
}
