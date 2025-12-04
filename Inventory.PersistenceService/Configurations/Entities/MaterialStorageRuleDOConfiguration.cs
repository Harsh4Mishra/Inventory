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
    public sealed class MaterialStorageRuleDOConfiguration : IEntityTypeConfiguration<MaterialStorageRuleDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<MaterialStorageRuleDO> builder)
        {
            // Configure table name
            builder
                .ToTable("material_storage_rule");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("int")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder
                .Property(e => e.MaterialId)
                .HasColumnType("uuid")
                .HasColumnOrder(2);

            builder
                .Property(e => e.MinQuantity)
                .HasColumnType("numeric")
                .HasDefaultValue(0)
                .HasColumnOrder(3);

            builder
                .Property(e => e.ThresholdQuantity)
                .HasColumnType("numeric")
                .HasDefaultValue(0)
                .HasColumnOrder(4);

            builder
                .Property(e => e.PreferredSectionId)
                .HasColumnType("uuid")
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
                .HasName("PK_material_storage_rule_id");

            // Configure foreign keys
            builder
                .HasOne<MaterialDO>()
                .WithMany()
                .HasForeignKey(e => e.MaterialId)
                .HasConstraintName("FK_material_storage_rule_material");

            builder
                .HasOne<StorageSectionDO>()
                .WithMany()
                .HasForeignKey(e => e.PreferredSectionId)
                .HasConstraintName("FK_material_storage_rule_storage_section");

            // Configure index(s)
            builder
                .HasIndex(e => e.MaterialId)
                .IsUnique()
                .HasDatabaseName("IX_material_storage_rule_material_id");

            builder
                .HasIndex(e => e.PreferredSectionId)
                .HasDatabaseName("IX_material_storage_rule_preferred_section_id");

            // Configure default values
            builder
                .Property(e => e.MinQuantity)
                .HasDefaultValue(0);

            builder
                .Property(e => e.ThresholdQuantity)
                .HasDefaultValue(0);
        }

        #endregion
    }
}
