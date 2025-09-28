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
                .ToTable("User");

            // Configure column(s)
            builder
                .Property(e => e.Id)
                .HasColumnType("CHAR(16)")
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
                .HasColumnType("DATE")
                .HasColumnOrder(5);

            builder
                .Property(e => e.Gender)
                .HasColumnType("TINYINT")
                .HasColumnOrder(6)
                .HasConversion(
                    v => (byte)v,
                    v => (Gender)v);

            builder
                .Property(e => e.IsActive)
                .HasColumnType("BIT")
                .HasColumnOrder(7);

            builder
                .Property(e => e.CreatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(8);

            builder
                .Property(e => e.CreatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(9);

            builder
                .Property(e => e.UpdatedBy)
                .HasColumnType("VARCHAR(50)")
                .HasColumnOrder(10)
                .IsRequired(false);

            builder
                .Property(e => e.UpdatedOn)
                .HasColumnType("DATETIME")
                .HasColumnOrder(11)
                .IsRequired(false);

            // Configure primary key
            builder
                .HasKey(e => e.Id)
                .HasName("PK_User_Id");

            // Configure index(s)
            //builder.HasIndex("PhoneNo_PhoneNo")  // Shadow property name
            // .IsUnique()
            // .HasDatabaseName("IX_User_PhoneNo");

            //builder.HasIndex("EmailId_EmailId")  // Shadow property name
            //    .IsUnique()
            //    .HasDatabaseName("IX_User_EmailId");


            // Configure value object conversions
            //builder
            //    .OwnsOne(e => e.PhoneNo)
            //    .Property(p => p.PhoneNo)
            //    .HasColumnName("PhoneNo");

            //builder
            //    .OwnsOne(e => e.EmailId)
            //    .Property(e => e.EmailId)
            //    .HasColumnName("EmailId");
        }

        #endregion
    }
}
