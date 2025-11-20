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
    public sealed class RowLocDOConfiguration : IEntityTypeConfiguration<RowLocDO>
    {
        public void Configure(EntityTypeBuilder<RowLocDO> builder)
        {
            // Configure table name
            builder.ToTable("row_loc");

            // Configure column(s)
            builder.Property(e => e.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1);

            builder.Property(e => e.AisleId)
                .HasColumnType("uuid")
                .HasColumnOrder(2);

            builder.Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnOrder(3);

            builder.Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(4);

            builder.Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(5);

            builder.Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(6);

            builder.Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(7);

            // Configure primary key
            builder.HasKey(e => e.Id)
                .HasName("PK_row_loc_id");

            // Configure foreign keys and relationships
            builder.HasOne<AisleDO>()
                 .WithMany("_rowLocs")
                 .HasForeignKey(c => c.AisleId)
                 .HasConstraintName("FK_row_loc_aisle_id")
                 .OnDelete(DeleteBehavior.Cascade);

            // Configure relationship(s) for trays
            builder.HasMany(e => e.Trays)
                   .WithOne()
                   .HasForeignKey(e => e.RowId)
                   .OnDelete(DeleteBehavior.Cascade);

            // Use field-backed navigation for encapsulation
            builder.Navigation(e => e.Trays)
                   .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
