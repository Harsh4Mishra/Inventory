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
    public sealed class BomCategoryDOConfiguration : IEntityTypeConfiguration<BomCategoryDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<BomCategoryDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefBomCategory");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("INT")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(2);

            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(3);

            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(4);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(5);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(6);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_bom_category_id");

            // Configure index(s)
            builder
                .HasIndex(e => e.Name)
                .IsUnique()
                .HasDatabaseName("IX_bom_category_name");

            // Configure constraints
            builder
                .Property(e => e.Name)
                .IsRequired();
        }

        #endregion
    }
}
