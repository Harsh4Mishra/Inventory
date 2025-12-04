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
    public sealed class InventoryTransactionDOConfiguration : IEntityTypeConfiguration<InventoryTransactionDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<InventoryTransactionDO> builder)
        {
            // Configure table name
            builder
                .ToTable("inventory_transaction");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("int")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder
                .Property(e => e.TransactionUUID)
                .HasColumnName("tx_uuid")
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(2);

            builder
                .Property(e => e.TransactionTime)
                .HasColumnName("txn_time")
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("now()")
                .HasColumnOrder(3);

            builder
                .Property(e => e.TransactionType)
                .HasColumnName("txn_type")
                .HasColumnType("text")
                .IsRequired()
                .HasColumnOrder(4);

            builder
                .Property(e => e.MaterialBatchId)
                .HasColumnName("material_batch_id")
                .HasColumnType("uuid")
                .IsRequired(false)
                .HasColumnOrder(5);

            builder
                .Property(e => e.ProductId)
                .HasColumnName("product_id")
                .HasColumnType("uuid")
                .IsRequired(false)
                .HasColumnOrder(6);

            builder
                .Property(e => e.Quantity)
                .HasColumnName("qty")
                .HasColumnType("numeric")
                .IsRequired()
                .HasColumnOrder(7);

            builder
                .Property(e => e.FromWarehouseId)
                .HasColumnName("from_warehouse_id")
                .HasColumnType("uuid")
                .IsRequired(false)
                .HasColumnOrder(8);

            builder
                .Property(e => e.ToWarehouseId)
                .HasColumnName("to_warehouse_id")
                .HasColumnType("uuid")
                .IsRequired(false)
                .HasColumnOrder(9);

            builder
                .Property(e => e.FromAisleId)
                .HasColumnName("from_aisle_id")
                .HasColumnType("uuid")
                .IsRequired(false)
                .HasColumnOrder(10);

            builder
                .Property(e => e.ToAisleId)
                .HasColumnName("to_aisle_id")
                .HasColumnType("uuid")
                .IsRequired(false)
                .HasColumnOrder(11);

            builder
                .Property(e => e.FromRowId)
                .HasColumnName("from_row_id")
                .HasColumnType("uuid")
                .IsRequired(false)
                .HasColumnOrder(12);

            builder
                .Property(e => e.ToRowId)
                .HasColumnName("to_row_id")
                .HasColumnType("uuid")
                .IsRequired(false)
                .HasColumnOrder(13);

            builder
                .Property(e => e.FromTrayId)
                .HasColumnName("from_tray_id")
                .HasColumnType("uuid")
                .IsRequired(false)
                .HasColumnOrder(14);

            builder
                .Property(e => e.ToTrayId)
                .HasColumnName("to_tray_id")
                .HasColumnType("uuid")
                .IsRequired(false)
                .HasColumnOrder(15);

            builder
                .Property(e => e.ReferenceType)
                .HasColumnName("ref_type")
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(16);

            builder
                .Property(e => e.ReferenceId)
                .HasColumnName("ref_id")
                .HasColumnType("uuid")
                .IsRequired(false)
                .HasColumnOrder(17);

            builder
                .Property(e => e.CreatedBy)
                .HasColumnName("created_by")
                .HasColumnType("uuid")
                .IsRequired()
                .HasColumnOrder(18);

            builder
                .Property(e => e.Cost)
                .HasColumnName("cost")
                .HasColumnType("numeric")
                .IsRequired(false)
                .HasColumnOrder(19);

            builder
                .Property(e => e.Notes)
                .HasColumnName("notes")
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(20);

            builder
                .Property(e => e.CreatedOn)
                .HasColumnName("created_on")
                .HasColumnType("timestamptz")
                .HasColumnOrder(21);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnName("updated_by")
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(22);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnName("updated_on")
                .HasColumnType("timestamptz")
                .IsRequired(false)
                .HasColumnOrder(23);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_inventory_transaction_id");

            // Configure index(s)
            builder
                .HasIndex(e => e.TransactionUUID)
                .IsUnique()
                .HasDatabaseName("IX_inventory_transaction_uuid");

            builder
                .HasIndex(e => e.MaterialBatchId)
                .HasDatabaseName("IX_inventory_transaction_material_batch_id");

            builder
                .HasIndex(e => e.ProductId)
                .HasDatabaseName("IX_inventory_transaction_product_id");

            builder
                .HasIndex(e => e.TransactionType)
                .HasDatabaseName("IX_inventory_transaction_type");

            builder
                .HasIndex(e => e.TransactionTime)
                .HasDatabaseName("IX_inventory_transaction_time");

            builder
                .HasIndex(e => new { e.FromWarehouseId, e.ToWarehouseId })
                .HasDatabaseName("IX_inventory_transaction_warehouses");

            // Configure foreign key(s) and relations
            // Note: These would be configured based on your actual entity relationships
            // builder
            //     .HasOne<MaterialBatchDO>()
            //     .WithMany()
            //     .HasForeignKey(e => e.MaterialBatchId)
            //     .HasConstraintName("FK_inventory_transaction_material_batch");

            // builder
            //     .HasOne<ProductDO>()
            //     .WithMany()
            //     .HasForeignKey(e => e.ProductId)
            //     .HasConstraintName("FK_inventory_transaction_product");
        }

        #endregion
    }
}
