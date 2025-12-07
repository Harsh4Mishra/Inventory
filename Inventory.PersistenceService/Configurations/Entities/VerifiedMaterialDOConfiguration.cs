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
    public sealed class VerifiedMaterialDOConfiguration : IEntityTypeConfiguration<VerifiedMaterialDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<VerifiedMaterialDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefVerifiedMaterial");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("INT")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder
                .Property(e => e.MaterialBatchId)
                .HasColumnType("INT")
                .HasColumnOrder(2);

            builder
                .Property(e => e.IsAllotted)
                .HasColumnType("BIT")
                .HasDefaultValue(false)
                .HasColumnOrder(3);

            builder
                .Property(e => e.Quantity)
                .HasColumnType("DECIMAL(10,2)")
                .HasColumnOrder(4);

            builder
                .Property(e => e.EmpId)
                .HasColumnType("INT")
                .IsRequired(false)
                .HasColumnOrder(5);

            builder
                .Property(e => e.Specification)
                .HasColumnType("VARCHAR(500)")
                .IsRequired(false)
                .HasColumnOrder(6);

            builder
                .Property(e => e.IsQualified)
                .HasColumnType("BIT")
                .IsRequired(false)
                .HasColumnOrder(7);

            builder
                .Property(e => e.Reason)
                .HasColumnType("VARCHAR(100)")
                .IsRequired(false)
                .HasColumnOrder(8);

            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(9);

            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasDefaultValueSql("GETDATE()")
                .HasColumnOrder(10);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .IsRequired(false)
                .HasColumnOrder(11);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .IsRequired(false)
                .HasColumnOrder(12);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_verified_material_id");

            // Configure index(s)
            builder
                .HasIndex(e => e.MaterialBatchId)
                .HasDatabaseName("IX_verified_material_material_batch_id");

            builder
                .HasIndex(e => e.EmpId)
                .HasDatabaseName("IX_verified_material_emp_id");

            builder
                .HasIndex(e => e.IsAllotted)
                .HasDatabaseName("IX_verified_material_is_allotted");

            builder
                .HasIndex(e => e.IsQualified)
                .HasDatabaseName("IX_verified_material_is_qualified");

            builder
                .HasIndex(e => e.CreatedOn)
                .HasDatabaseName("IX_verified_material_created_on");

            // Configure foreign key(s) and relations
            // Note: Assuming MaterialBatchDO exists in your domain
            // builder
            //     .HasOne<MaterialBatchDO>()
            //     .WithMany()
            //     .HasForeignKey(e => e.MaterialBatchId)
            //     .HasConstraintName("FK_verified_material_material_batch_id")
            //     .OnDelete(DeleteBehavior.Restrict);
        }

        #endregion
    }
}
