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
    public sealed class WarehouseDOConfiguration : IEntityTypeConfiguration<WarehouseDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<WarehouseDO> builder)
        {
            // Configure table name
            builder
                .ToTable("warehouse");

            //Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("uuid")
                .HasDefaultValueSql("gen_random_uuid()")
                .HasColumnOrder(1);
            builder
                .Property(e => e.Name)
                .HasColumnType("text")
                .HasColumnOrder(2);
            builder
                .Property(e => e.Address)
                .HasColumnType("jsonb")
                .IsRequired(false)
                .HasColumnOrder(3);
            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("varchar(50)")
                .HasColumnOrder(4);
            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("now()")
                .HasColumnOrder(5);
            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("varchar(50)")
                .IsRequired(false)
                .HasColumnOrder(6);
            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("timestamptz")
                .IsRequired(false)
                .HasColumnOrder(7);
            builder
              .Property(e => e.IsActive)
              .HasColumnType("boolean")
              .HasDefaultValue(true)
              .HasColumnOrder(8);

            //Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_warehouse_id");

            //Configure index(s)
            builder
                .HasIndex(e => e.Name)
                .IsUnique()
                .HasDatabaseName("IX_warehouse_name");

            //Configure relations
            // Additional relations can be configured here as needed
        }

        #endregion
    }
}
