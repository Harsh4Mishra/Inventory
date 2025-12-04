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
    public sealed class AllocationDOConfiguration : IEntityTypeConfiguration<AllocationDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<AllocationDO> builder)
        {
            // Configure table name
            builder
                .ToTable("allocation");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnName("id")
                .HasColumnType("int")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder
                .Property(e => e.OrderId)
                .HasColumnName("order_id")
                .HasColumnType("uuid")
                .HasColumnOrder(2);

            builder
                .Property(e => e.ProductId)
                .HasColumnName("product_id")
                .HasColumnType("uuid")
                .HasColumnOrder(3);

            builder
                .Property(e => e.MaterialBatchId)
                .HasColumnName("material_batch_id")
                .HasColumnType("uuid")
                .HasColumnOrder(4);

            builder
                .Property(e => e.Quantity)
                .HasColumnName("qty")
                .HasColumnType("numeric")
                .IsRequired()
                .HasColumnOrder(5);

            builder
                .Property(e => e.Status)
                .HasColumnName("status")
                .HasColumnType("text")
                .HasDefaultValue("allocated")
                .HasConversion<string>()
                .HasColumnOrder(6);

            builder
                .Property(e => e.CreatedBy)
                .HasColumnName("created_by")
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(7);

            builder
                .Property(e => e.CreatedOn)
                .HasColumnName("created_on")
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("now()")
                .HasColumnOrder(8);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnName("updated_by")
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(9);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnName("updated_on")
                .HasColumnType("timestamptz")
                .IsRequired(false)
                .HasColumnOrder(10);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_allocation_id");

            // Configure index(s)
            builder
                .HasIndex(e => e.OrderId)
                .HasDatabaseName("IX_allocation_order_id");

            builder
                .HasIndex(e => e.ProductId)
                .HasDatabaseName("IX_allocation_product_id");

            builder
                .HasIndex(e => e.MaterialBatchId)
                .HasDatabaseName("IX_allocation_material_batch_id");

            builder
                .HasIndex(e => e.Status)
                .HasDatabaseName("IX_allocation_status");

            builder
                .HasIndex(e => new { e.OrderId, e.ProductId, e.MaterialBatchId })
                .HasDatabaseName("IX_allocation_order_product_batch")
                .IsUnique();

            // Configure check constraint for status
            builder
                .HasCheckConstraint("CK_allocation_status",
                    "status IN ('allocated','picked','shipped','released','cancelled')");

            // Configure foreign key(s) and relations
            // Note: Uncomment and configure when you have these entities
            // builder
            //     .HasOne<ProductDO>()
            //     .WithMany()
            //     .HasForeignKey(e => e.ProductId)
            //     .HasConstraintName("FK_allocation_product");

            // builder
            //     .HasOne<MaterialBatchDO>()
            //     .WithMany()
            //     .HasForeignKey(e => e.MaterialBatchId)
            //     .HasConstraintName("FK_allocation_material_batch");
        }

        #endregion
    }
}
