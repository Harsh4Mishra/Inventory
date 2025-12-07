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
                .ToTable("RefInventoryTransaction");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("INT")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder
                .Property(e => e.TransactionUUID)
                .HasColumnName("Transactionuuid")
                .HasColumnType("INT")
                //.HasDefaultValueSql("")
                .HasColumnOrder(2);

            builder
                .Property(e => e.TransactionTime)
                .HasColumnName("TransactionTime")
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()")
                .HasColumnOrder(3);

            builder
                .Property(e => e.TransactionType)
                .HasColumnName("TransactionType")
                .HasColumnType("VARCHAR(50)")
                .IsRequired()
                .HasColumnOrder(4);

            builder
                .Property(e => e.MaterialBatchId)
                .HasColumnName("MaterialBatchId")
                .HasColumnType("INT")
                .IsRequired(false)
                .HasColumnOrder(5);

            builder
                .Property(e => e.ProductId)
                .HasColumnName("ProductId")
                .HasColumnType("INT")
                .IsRequired(false)
                .HasColumnOrder(6);

            builder
                .Property(e => e.Quantity)
                .HasColumnName("Quantity")
                .HasColumnType("INT")
                .IsRequired()
                .HasColumnOrder(7);

            builder
                .Property(e => e.FromWarehouseId)
                .HasColumnName("FromWarehouseId")
                .HasColumnType("INT")
                .IsRequired(false)
                .HasColumnOrder(8);

            builder
                .Property(e => e.ToWarehouseId)
                .HasColumnName("ToWarehouseId")
                .HasColumnType("INT")
                .IsRequired(false)
                .HasColumnOrder(9);

            builder
                .Property(e => e.FromAisleId)
                .HasColumnName("FromAisleId")
                .HasColumnType("INT")
                .IsRequired(false)
                .HasColumnOrder(10);

            builder
                .Property(e => e.ToAisleId)
                .HasColumnName("ToAisleId")
                .HasColumnType("INT")
                .IsRequired(false)
                .HasColumnOrder(11);

            builder
                .Property(e => e.FromRowId)
                .HasColumnName("FromRowId")
                .HasColumnType("INT")
                .IsRequired(false)
                .HasColumnOrder(12);

            builder
                .Property(e => e.ToRowId)
                .HasColumnName("ToRowId")
                .HasColumnType("INT")
                .IsRequired(false)
                .HasColumnOrder(13);

            builder
                .Property(e => e.FromTrayId)
                .HasColumnName("FromTrayId")
                .HasColumnType("INT")
                .IsRequired(false)
                .HasColumnOrder(14);

            builder
                .Property(e => e.ToTrayId)
                .HasColumnName("ToTrayId")
                .HasColumnType("INT")
                .IsRequired(false)
                .HasColumnOrder(15);

            builder
                .Property(e => e.ReferenceType)
                .HasColumnName("ReferenceType")
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(16);

            builder
                .Property(e => e.ReferenceId)
                .HasColumnName("ReferenceId")
                .HasColumnType("INT")
                .IsRequired(false)
                .HasColumnOrder(17);

            builder
                .Property(e => e.CreatedBy)
                .HasColumnName("CreatedBy")
                .HasColumnType("VARCHAR(50)")
                .IsRequired()
                .HasColumnOrder(18);

            builder
                .Property(e => e.Cost)
                .HasColumnName("Cost")
                .HasColumnType("DECIMAL(10,2)")
                .IsRequired(false)
                .HasColumnOrder(19);

            builder
                .Property(e => e.Notes)
                .HasColumnName("Notes")
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(20);

            builder
                .Property(e => e.CreatedOn)
                .HasColumnName("CreatedOn")
                .HasColumnType("DATETIME")
                .HasColumnOrder(21);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnName("UpdatedBy")
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(22);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnName("UpdatedOn")
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(23);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_inventory_transaction_id");

            // Configure index(s)
            builder
                .HasIndex(e => e.TransactionUUID)
                //.IsUnique()
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
