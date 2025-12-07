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
    public sealed class BomDOConfiguration : IEntityTypeConfiguration<BomDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<BomDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefBom");

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
                .HasDefaultValueSql("GETDATE()")
                .HasColumnOrder(4);

            builder
                .Property(e => e.IsApproved)
                .HasColumnType("BIT")
                .HasDefaultValue(false)
                .HasColumnOrder(5);

            builder
                .Property(e => e.BomCategoryId)
                .HasColumnType("INT")
                .HasColumnOrder(6);

            builder
                .Property(e => e.Result)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(7);

            builder
                .Property(e => e.Quantity)
                .HasColumnType("DECIMAL(10,2)")
                .HasDefaultValue(0)
                .HasColumnOrder(8);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(9);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(10);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_bom_id");

            // Configure foreign keys
            builder
                .HasOne<BomCategoryDO>()
                .WithMany()
                .HasForeignKey(e => e.BomCategoryId)
                .HasConstraintName("FK_bom_bom_category");

            // Configure index(s)
            builder
                .HasIndex(e => e.Name)
                .IsUnique()
                .HasDatabaseName("IX_bom_name");

            builder
                .HasIndex(e => e.BomCategoryId)
                .HasDatabaseName("IX_bom_category_id");

            builder
                .HasIndex(e => e.IsApproved)
                .HasDatabaseName("IX_bom_is_approved");

            // Configure default values
            builder
                .Property(e => e.CreatedOn)
                .HasDefaultValueSql("GETDATE()");

            builder
                .Property(e => e.IsApproved)
                .HasDefaultValue(false);

            builder
                .Property(e => e.Quantity)
                .HasDefaultValue(0);

            // Configure constraints
            builder
                .Property(e => e.Name)
                .IsRequired();
        }

        #endregion
    }
}
