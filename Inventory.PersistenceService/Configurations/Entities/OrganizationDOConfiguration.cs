using Inventory.Domain.DomainObjects;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Inventory.PersistenceService.Configurations.Entities
{
    public class OrganizationDOConfiguration
        : IEntityTypeConfiguration<OrganizationDO>
    {
        public void Configure(EntityTypeBuilder<OrganizationDO> builder)
        {
            // Configure table name
            builder.ToTable("Reforganization"); // Matches your CREATE TABLE statement

            // Configure primary key
            builder.HasKey(e => e.Id)
                .HasName("PK_organization_id");

            // Configure columns
            builder.Property(e => e.Id)
                .HasColumnType("int")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder.Property(e => e.Name)
                .HasColumnName("name")
                .HasColumnType("text")
                .IsRequired()
                .HasColumnOrder(2);

            builder.Property(e => e.Code)
                .HasColumnName("code")
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(3);

            builder.Property(e => e.Description)
                .HasColumnName("description")
                .HasColumnType("text")
                .IsRequired(false)
                .HasColumnOrder(4);

            builder.Property(e => e.IsActive)
                .HasColumnName("is_active")
                .HasColumnType("boolean")
                .HasDefaultValue(true)
                .HasColumnOrder(5);


            // Audit properties (from AuditableDO base class)
            builder.Property(e => e.CreatedOn)
                .HasColumnName("created_on")
                .HasColumnType("timestamptz")
                .HasDefaultValueSql("now()")
                .ValueGeneratedOnAdd()
                .HasColumnOrder(6);

            builder.Property(e => e.CreatedBy)
                .HasColumnName("created_by")
                .HasColumnType("uuid")
                .IsRequired()
                .HasColumnOrder(7);

            builder.Property(e => e.UpdatedOn)
                .HasColumnName("updated_on")
                .HasColumnType("timestamptz")
                .IsRequired(false)
                .HasColumnOrder(8);

            builder.Property(e => e.UpdatedBy)
                .HasColumnName("updated_by")
                .HasColumnType("uuid")
                .IsRequired(false)
                .HasColumnOrder(9);

            // Configure indexes
            builder.HasIndex(e => e.Name)
                .IsUnique()
                .HasDatabaseName("IX_organization_name_unique")
                .HasFilter("[is_deleted] = false"); // Only enforce uniqueness on non-deleted records

            builder.HasIndex(e => e.Code)
                .IsUnique()
                .HasDatabaseName("IX_organization_code_unique")
                .HasFilter("[code] IS NOT NULL AND [is_deleted] = false"); // Partial index for unique non-null codes and non-deleted records

            builder.HasIndex(e => e.IsActive)
                .HasDatabaseName("IX_organization_is_active")
                .HasFilter("[is_deleted] = false"); // Only index active non-deleted records


            // Configure relationships (commented out as per your domain object)
            // builder.HasMany(e => e.Employees)
            //     .WithOne()
            //     .HasForeignKey(e => e.OrganizationId)
            //     .OnDelete(DeleteBehavior.Cascade);

            // Use field-backed navigation for encapsulation (if Employees were enabled)
            // builder.Navigation(e => e.Employees)
            //     .UsePropertyAccessMode(PropertyAccessMode.Field);
        }
    }
}
