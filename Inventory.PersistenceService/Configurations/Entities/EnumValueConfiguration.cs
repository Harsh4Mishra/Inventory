using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Inventory.Domain.DomainObjects;

namespace Inventory.PersistenceService.Configurations.Entities
{
    public sealed class EnumValueConfiguration
        : IEntityTypeConfiguration<EnumValueDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<EnumValueDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefEnumValue");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("INT")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);
            builder
                .Property(e => e.EnumTypeId)
                .HasColumnType("INT")
                .HasColumnOrder(2);
            builder
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(3);
            builder
                .Property(e => e.Code)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(4);
            builder
                .Property(e => e.Description)
                .HasColumnType("VARCHAR(500)")
                .HasColumnOrder(5)
                .IsRequired(false);
            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(6);
            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(7);
            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(8)
                .IsRequired(false);
            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(9)
                .IsRequired(false);
            builder
                .Property(e => e.IsActive)
                .HasColumnType("BIT")
                .HasColumnOrder(10);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_RefEnumValue_Id");

            // Configure index(s)
            builder
                .HasIndex(e => e.Code)
                .IsUnique()
                .HasDatabaseName("IX_RefEnumValue_Code");

            //builder
            //    .HasIndex(e => new { e.EnumTypeId, e.Name })
            //    .IsUnique()
            //    .HasDatabaseName("IX_RefEnumValue_EnumTypeId_Name");

            //builder
            //    .HasIndex(e => new { e.EnumTypeId, e.Code })
            //    .IsUnique()
            //    .HasDatabaseName("IX_RefEnumValue_EnumTypeId_Code");

            // Configure foreign key(s) and relationship(s)
            builder.HasOne<EnumTypeDO>()
                   .WithMany(e => e.EnumValues)
                   .HasForeignKey(ev => ev.EnumTypeId)
                   .HasConstraintName("FK_RefEnumValue_RefEnumType_EnumTypeId")
                   .OnDelete(DeleteBehavior.Cascade);
        }

        #endregion
    }
}
