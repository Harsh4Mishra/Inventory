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
    public sealed class AisleDOConfiguration : IEntityTypeConfiguration<AisleDO>
    {
        public void Configure(EntityTypeBuilder<AisleDO> builder)
        {
            // Configure table name
            builder.ToTable("aisle");

            // Configure column(s)
            builder.Property(e => e.Id)
                .HasColumnType("int")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder.Property(e => e.WarehouseId)
                .HasColumnType("uuid")
                .HasColumnOrder(2);

            builder.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnOrder(3);

            builder.Property(e => e.StorageSectionId)
                .HasColumnType("uuid")
                .HasColumnOrder(4);

            builder.Property(e => e.StorageTypeId)
                .HasColumnType("uuid")
                .HasColumnOrder(5);

            builder.Property(e => e.InventoryTypeId)
                .HasColumnType("uuid")
                .HasColumnOrder(6);

            builder.Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(7);

            builder.Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(8);

            builder.Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(9);

            builder.Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(10);

            // Configure primary key
            builder.HasKey(e => e.Id)
                .HasName("PK_aisle_id");

            // Configure foreign keys
            builder.HasOne(e => e.Warehouse)
                .WithMany()
                .HasForeignKey(e => e.WarehouseId)
                .HasConstraintName("FK_aisle_warehouse_id");

            // Configure index(s)
            builder.HasIndex(e => e.WarehouseId)
                .HasDatabaseName("IX_aisle_warehouse_id");

            builder.HasIndex(e => e.Name)
                .HasDatabaseName("IX_aisle_name");

            // Configure relationship(s) - using field-backed navigation
            builder.HasMany(e => e.RowLocs)
                   .WithOne()
                   .HasForeignKey(e => e.AisleId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Use field-backed navigation for encapsulation
            builder.Navigation(e => e.RowLocs)
                   .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
