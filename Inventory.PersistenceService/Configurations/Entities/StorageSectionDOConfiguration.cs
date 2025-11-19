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
    public sealed class StorageSectionDOConfiguration : IEntityTypeConfiguration<StorageSectionDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<StorageSectionDO> builder)
        {
            // Configure table name
            builder
                .ToTable("storage_section");

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
                .Property(e => e.TemperatureRange)
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(3);
            builder
                .Property(e => e.Description)
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(4);
            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("varchar(50)")
                .HasColumnOrder(5);
            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("now()")
                .HasColumnOrder(6);
            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("varchar(50)")
                .IsRequired(false)
                .HasColumnOrder(7);
            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("timestamptz")
                .IsRequired(false)
                .HasColumnOrder(8);
            builder
              .Property(e => e.IsActive)
              .HasColumnType("boolean")
              .HasDefaultValue(true)
              .HasColumnOrder(9);

            //Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_storage_section_id");

            //Configure index(s)
            builder
                .HasIndex(e => e.Name)
                .IsUnique()
                .HasDatabaseName("IX_storage_section_name");

            //Configure relations
            // Additional relations can be configured here as needed
        }

        #endregion
    }
}
