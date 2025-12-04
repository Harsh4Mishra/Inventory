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
    public sealed class BomItemDispositionDOConfiguration : IEntityTypeConfiguration<BomItemDispositionDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<BomItemDispositionDO> builder)
        {
            // Configure table name
            builder
                .ToTable("bom_item_disposition");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("int")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder
                .Property(e => e.BomItemId)
                .HasColumnType("int")
                .HasColumnOrder(2);

            builder
                .Property(e => e.Disposition)
                .HasColumnType("text")
                .HasColumnOrder(3);

            builder
                .Property(e => e.Notes)
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(4);

            builder
                .Property(e => e.ProcessedOn)
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("now()")
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
                .HasName("PK_bom_item_disposition_id");

            // Configure foreign key
            builder
                .HasOne<BomItemDO>() // Assuming you have BomItemDO
                .WithMany() // Adjust if BomItemDO has navigation property
                .HasForeignKey(e => e.BomItemId)
                .HasConstraintName("FK_bom_item_disposition_bom_item_id")
                .OnDelete(DeleteBehavior.Restrict);

            // Configure index(s)
            builder
                .HasIndex(e => e.BomItemId)
                .HasDatabaseName("IX_bom_item_disposition_bom_item_id");

            builder
                .HasIndex(e => e.Disposition)
                .HasDatabaseName("IX_bom_item_disposition_disposition");

            builder
                .HasIndex(e => e.ProcessedOn)
                .HasDatabaseName("IX_bom_item_disposition_processed_on");
        }

        #endregion
    }
}
