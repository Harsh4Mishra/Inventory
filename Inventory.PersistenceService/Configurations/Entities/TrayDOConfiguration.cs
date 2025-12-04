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
    public sealed class TrayDOConfiguration : IEntityTypeConfiguration<TrayDO>
    {
        public void Configure(EntityTypeBuilder<TrayDO> builder)
        {
            // Configure table name
            builder.ToTable("tray");

            // Configure column(s)
            builder.Property(e => e.Id)
                .HasColumnType("int")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder.Property(e => e.RowId)
                .HasColumnType("int")
                .HasColumnOrder(2);

            builder.Property(e => e.Capacity)
                .HasColumnType("integer")
                .HasColumnOrder(3);

            builder.Property(e => e.Description)
                .HasColumnType("text")
                .HasColumnOrder(4);

            builder.Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(5);

            builder.Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(6);

            builder.Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(7);

            builder.Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(8);

            // Configure primary key
            builder.HasKey(e => e.Id)
                .HasName("PK_tray_id");

            // Configure foreign keys and relationships
            builder.HasOne<RowLocDO>()
                 .WithMany()
                 .HasForeignKey(c => c.RowId)
                 .HasConstraintName("FK_tray_row_id")
                 .OnDelete(DeleteBehavior.Cascade);

            // Configure index(s)
            builder.HasIndex(e => e.RowId)
                .HasDatabaseName("IX_tray_row_id");
        }
    }
}
