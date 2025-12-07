using Inventory.Domain.DomainObjects;
using Inventory.Domain.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Inventory.PersistenceService.Configurations.Entities
{
    public class UserDOConfiguration
        : IEntityTypeConfiguration<UserDO>
    {
        #region Methods

        public void Configure(EntityTypeBuilder<UserDO> builder)
        {
            // Configure table name
            builder
                .ToTable("RefUser");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("INT")  // Use "int" for SQL Server, "integer" for PostgreSQL
                .UseIdentityColumn()  // For SQL Server identity
                .HasColumnOrder(1);

            builder
                .Property(e => e.Name)
                .HasColumnType("VARCHAR(100)")
                .HasColumnOrder(2);

            builder
                .OwnsOne(e => e.PhoneNo, phone =>
                {
                    phone.Property(p => p.PhoneNo)
                        .HasColumnType("VARCHAR(15)")
                        .HasColumnName("PhoneNo")
                        .HasColumnOrder(3);

                    // Index configuration inside the owned type
                    phone.HasIndex(p => p.PhoneNo)
                        .IsUnique()
                        .HasDatabaseName("IX_User_PhoneNo");
                });

            builder
                .OwnsOne(e => e.EmailId, email =>
                {
                    email.Property(e => e.EmailId)
                        .HasColumnType("VARCHAR(100)")
                        .HasColumnName("EmailId")
                        .HasColumnOrder(4);

                    // Index configuration inside the owned type
                    email.HasIndex(e => e.EmailId)
                        .IsUnique()
                        .HasDatabaseName("IX_User_EmailId");
                });

            builder
                .Property(e => e.DateOfBirth)
                .HasColumnType("DATETIME")
                .HasColumnOrder(5);

            builder
                .Property(e => e.Gender)
                .HasColumnType("VARCHAR(100)")
                .HasColumnOrder(6);

            builder
                .Property(e => e.IsActive)
                .HasColumnType("BIT")
                .HasColumnOrder(7);

            // New password-related fields
            builder
                .Property(e => e.PasswordHashKey)
                .HasColumnType("VARCHAR(500)")
                .IsRequired(false)
                .HasColumnOrder(8);

            builder
                .Property(e => e.PasswordSaltKey)
                .HasColumnType("VARCHAR(500)")
                .IsRequired(false)
                .HasColumnOrder(9);

            builder
                .Property(e => e.NumberOfAttempts)
                .HasColumnType("INT")
                .HasDefaultValue(0)
                .HasColumnOrder(10);

            builder
                .Property(e => e.IsPasswordSet)
                .HasColumnType("BIT")
                .HasDefaultValue(false)
                .HasColumnOrder(11);

            // Audit fields
            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(12);

            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(13);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(14)
                .IsRequired(false);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(15)
                .IsRequired(false);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_User_Id");

            // Configure additional indexes for new fields
            builder
                .HasIndex(e => e.IsActive)
                .HasDatabaseName("IX_User_IsActive");

            builder
                .HasIndex(e => e.IsPasswordSet)
                .HasDatabaseName("IX_User_IsPasswordSet");

            builder
                .HasIndex(e => e.NumberOfAttempts)
                .HasDatabaseName("IX_User_NumberOfAttempts");

            // Configure check constraints
            builder
                .HasCheckConstraint("CK_User_NumberOfAttempts_Range", "[NumberOfAttempts] >= 0 AND [NumberOfAttempts] <= 10")
                .HasCheckConstraint("CK_User_PasswordFields_Consistency",
                    "([PasswordHashKey] IS NULL AND [PasswordSaltKey] IS NULL AND [IsPasswordSet] = 0) OR " +
                    "([PasswordHashKey] IS NOT NULL AND [PasswordSaltKey] IS NOT NULL AND [IsPasswordSet] = 1)");

            // Configure value object conversions (already handled by OwnsOne)
        }

        #endregion
    }
}
