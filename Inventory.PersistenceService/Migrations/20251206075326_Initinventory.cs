using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace Inventory.PersistenceService.Migrations
{
    /// <inheritdoc />
    public partial class Initinventory : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.EnsureSchema(
                name: "inventory");

            migrationBuilder.EnsureSchema(
                name: "system");

            migrationBuilder.EnsureSchema(
                name: "master");

            migrationBuilder.CreateTable(
                name: "Allocation",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    OrderId = table.Column<int>(type: "INT", nullable: false),
                    ProductId = table.Column<int>(type: "INT", nullable: false),
                    MaterialBatchId = table.Column<int>(type: "INT", nullable: false),
                    Quantity = table.Column<decimal>(type: "Decimal(10,2)", nullable: false),
                    Status = table.Column<string>(type: "VARCHAR(50)", nullable: false, defaultValue: "Allocated"),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_allocation_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "BomCategory",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bom_category_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Material",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Sku = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Category = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Subcategory = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CasNumber = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Description = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_material_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefEnumType",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Code = table.Column<string>(type: "VARCHAR(20)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefEnumType_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefOrganization",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Code = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Description = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_organization_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefRole",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    Code = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefRole_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RefUser",
                schema: "master",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    PhoneNo = table.Column<string>(type: "VARCHAR(15)", nullable: false),
                    EmailId = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    DateOfBirth = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    Gender = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false),
                    PasswordHashKey = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    PasswordSaltKey = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    NumberOfAttempts = table.Column<int>(type: "INT", nullable: false, defaultValue: 0),
                    IsPasswordSet = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IsPasswordLinkVisited = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User_Id", x => x.Id);
                    table.CheckConstraint("CK_User_NumberOfAttempts_Range", "[NumberOfAttempts] >= 0 AND [NumberOfAttempts] <= 10");
                    table.CheckConstraint("CK_User_PasswordFields_Consistency", "([PasswordHashKey] IS NULL AND [PasswordSaltKey] IS NULL AND [IsPasswordSet] = 0) OR ([PasswordHashKey] IS NOT NULL AND [PasswordSaltKey] IS NOT NULL AND [IsPasswordSet] = 1)");
                });

            migrationBuilder.CreateTable(
                name: "StorageSection",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    TemperatureRange = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Description = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_storage_section_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Vendor",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Type = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Contact = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Vendor_Id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "VerifiedMaterial",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialBatchId = table.Column<int>(type: "INT", nullable: false),
                    IsAllotted = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    Quantity = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    EmpId = table.Column<int>(type: "INT", nullable: true),
                    Specification = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    IsQualified = table.Column<bool>(type: "BIT", nullable: true),
                    Reason = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_verified_material_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Warehouse",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Address = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_id", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Bom",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    IsApproved = table.Column<bool>(type: "BIT", nullable: false, defaultValue: false),
                    BomCategoryId = table.Column<int>(type: "INT", nullable: false),
                    Result = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    Quantity = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false, defaultValue: 0m),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bom_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bom_bom_category",
                        column: x => x.BomCategoryId,
                        principalSchema: "inventory",
                        principalTable: "BomCategory",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefEnumValue",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    EnumTypeId = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Code = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefEnumValue_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefEnumValue_RefEnumType_EnumTypeId",
                        column: x => x.EnumTypeId,
                        principalSchema: "system",
                        principalTable: "RefEnumType",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefAppModule",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "INT", nullable: false),
                    Code = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(100)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_app_module_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_app_module_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "master",
                        principalTable: "RefOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefPermission",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    TenantId = table.Column<int>(type: "INT", nullable: false),
                    Code = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permission_Id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_permission_TenantId",
                        column: x => x.TenantId,
                        principalSchema: "master",
                        principalTable: "RefOrganization",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefUserRole",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    UserId = table.Column<int>(type: "INT", nullable: false),
                    RoleId = table.Column<int>(type: "INT", nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role_Id", x => x.Id);
                    table.CheckConstraint("CK_user_role_RoleID_NotEmpty", "\"RoleId\" != '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_user_role_UserID_NotEmpty", "\"UserId\" != '00000000-0000-0000-0000-000000000000'");
                    table.ForeignKey(
                        name: "FK_user_role_RoleID",
                        column: x => x.RoleId,
                        principalSchema: "system",
                        principalTable: "RefRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_user_role_UserID",
                        column: x => x.UserId,
                        principalSchema: "master",
                        principalTable: "RefUser",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "MaterialStorageRule",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "INT", nullable: false),
                    MinQuantity = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false, defaultValue: 0m),
                    ThresholdQuantity = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false, defaultValue: 0m),
                    PreferredSectionId = table.Column<int>(type: "INT", nullable: false),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_material_storage_rule_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_material_storage_rule_material",
                        column: x => x.MaterialId,
                        principalSchema: "inventory",
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_material_storage_rule_storage_section",
                        column: x => x.PreferredSectionId,
                        principalSchema: "inventory",
                        principalTable: "StorageSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "MaterialBatch",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialId = table.Column<int>(type: "INT", nullable: false),
                    VendorId = table.Column<int>(type: "INT", nullable: true),
                    BatchCode = table.Column<string>(type: "VARCHAR(10)", nullable: false),
                    Barcode = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    ManufactureDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    ExpiryDate = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    Quantity = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false, defaultValue: 0m),
                    RemainingQuantity = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false, defaultValue: 0m),
                    StorageSectionId = table.Column<int>(type: "INT", nullable: true),
                    LocationText = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_material_batch_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_material_batch_material_id",
                        column: x => x.MaterialId,
                        principalSchema: "inventory",
                        principalTable: "Material",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_material_batch_vendor_id",
                        column: x => x.VendorId,
                        principalSchema: "inventory",
                        principalTable: "Vendor",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Aisle",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    WarehouseId = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    StorageSectionId = table.Column<int>(type: "INT", nullable: false),
                    StorageTypeId = table.Column<int>(type: "INT", nullable: false),
                    InventoryTypeId = table.Column<int>(type: "INT", nullable: false),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_aisle_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Aisle_StorageSection_StorageSectionId",
                        column: x => x.StorageSectionId,
                        principalSchema: "inventory",
                        principalTable: "StorageSection",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_aisle_warehouse_id",
                        column: x => x.WarehouseId,
                        principalSchema: "inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "Product",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Sku = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    BomId = table.Column<int>(type: "INT", nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_product_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_product_bom_id",
                        column: x => x.BomId,
                        principalSchema: "inventory",
                        principalTable: "Bom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RefRolePermission",
                schema: "system",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RoleId = table.Column<int>(type: "INT", nullable: false),
                    ModuleId = table.Column<int>(type: "INT", nullable: false),
                    PermissionId = table.Column<int>(type: "INT", nullable: false),
                    IsActive = table.Column<bool>(type: "BIT", nullable: false, defaultValue: true),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_role_permission_Id", x => x.Id);
                    table.CheckConstraint("CK_role_permission_ModuleId_NotEmpty", "\"ModuleId\" != '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_role_permission_PermissionId_NotEmpty", "\"PermissionId\" != '00000000-0000-0000-0000-000000000000'");
                    table.CheckConstraint("CK_role_permission_RoleId_NotEmpty", "\"RoleId\" != '00000000-0000-0000-0000-000000000000'");
                    table.ForeignKey(
                        name: "FK_role_permission_ModuleId",
                        column: x => x.ModuleId,
                        principalSchema: "system",
                        principalTable: "RefAppModule",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_role_permission_PermissionId",
                        column: x => x.PermissionId,
                        principalSchema: "system",
                        principalTable: "RefPermission",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_role_permission_RoleId",
                        column: x => x.RoleId,
                        principalSchema: "system",
                        principalTable: "RefRole",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "RowLoc",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AisleId = table.Column<int>(type: "INT", nullable: false),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    AisleDOId = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_row_loc_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RowLoc_Aisle_AisleDOId",
                        column: x => x.AisleDOId,
                        principalSchema: "inventory",
                        principalTable: "Aisle",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_row_loc_aisle_id",
                        column: x => x.AisleId,
                        principalSchema: "inventory",
                        principalTable: "Aisle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Tray",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    RowId = table.Column<int>(type: "INT", nullable: false),
                    Capacity = table.Column<int>(type: "INT", nullable: false),
                    Description = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true),
                    RowLocDOId = table.Column<int>(type: "INT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_tray_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_Tray_RowLoc_RowLocDOId",
                        column: x => x.RowLocDOId,
                        principalSchema: "inventory",
                        principalTable: "RowLoc",
                        principalColumn: "Id");
                    table.ForeignKey(
                        name: "FK_tray_row_id",
                        column: x => x.RowId,
                        principalSchema: "inventory",
                        principalTable: "RowLoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "WarehouseItem",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MaterialBatchId = table.Column<int>(type: "INT", nullable: false),
                    WarehouseId = table.Column<int>(type: "INT", nullable: false),
                    AisleId = table.Column<int>(type: "INT", nullable: false),
                    RowId = table.Column<int>(type: "INT", nullable: false),
                    TrayId = table.Column<int>(type: "INT", nullable: false),
                    Quantity = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false, defaultValue: 0m),
                    Name = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Specification = table.Column<string>(type: "VARCHAR(100)", nullable: true),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_warehouse_item_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_warehouse_item_aisle",
                        column: x => x.AisleId,
                        principalSchema: "inventory",
                        principalTable: "Aisle",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_warehouse_item_material_batch",
                        column: x => x.MaterialBatchId,
                        principalSchema: "inventory",
                        principalTable: "MaterialBatch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_warehouse_item_row",
                        column: x => x.RowId,
                        principalSchema: "inventory",
                        principalTable: "RowLoc",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_warehouse_item_tray",
                        column: x => x.TrayId,
                        principalSchema: "inventory",
                        principalTable: "Tray",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_warehouse_item_warehouse",
                        column: x => x.WarehouseId,
                        principalSchema: "inventory",
                        principalTable: "Warehouse",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BomItem",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BomId = table.Column<int>(type: "INT", nullable: false),
                    MaterialBatchId = table.Column<int>(type: "INT", nullable: false),
                    WarehouseItemId = table.Column<int>(type: "INT", nullable: false),
                    Quantity = table.Column<decimal>(type: "DECIMAL(10,2)", nullable: false),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bom_item_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bom_item_bom",
                        column: x => x.BomId,
                        principalSchema: "inventory",
                        principalTable: "Bom",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bom_item_material_batch",
                        column: x => x.MaterialBatchId,
                        principalSchema: "inventory",
                        principalTable: "MaterialBatch",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_bom_item_warehouse_item",
                        column: x => x.WarehouseItemId,
                        principalSchema: "inventory",
                        principalTable: "WarehouseItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "BomItemDisposition",
                schema: "inventory",
                columns: table => new
                {
                    Id = table.Column<int>(type: "INT", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BomItemId = table.Column<int>(type: "INT", nullable: false),
                    Disposition = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    Notes = table.Column<string>(type: "VARCHAR(500)", nullable: true),
                    ProcessedOn = table.Column<DateTime>(type: "DATETIME", nullable: false, defaultValueSql: "GETDATE()"),
                    CreatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: false),
                    CreatedOn = table.Column<DateTime>(type: "DATETIME", nullable: false),
                    UpdatedBy = table.Column<string>(type: "VARCHAR(50)", nullable: true),
                    UpdatedOn = table.Column<DateTime>(type: "DATETIME", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_bom_item_disposition_id", x => x.Id);
                    table.ForeignKey(
                        name: "FK_bom_item_disposition_bom_item_id",
                        column: x => x.BomItemId,
                        principalSchema: "inventory",
                        principalTable: "BomItem",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_aisle_name",
                schema: "inventory",
                table: "Aisle",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Aisle_StorageSectionId",
                schema: "inventory",
                table: "Aisle",
                column: "StorageSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_aisle_warehouse_id",
                schema: "inventory",
                table: "Aisle",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_allocation_material_batch_id",
                schema: "inventory",
                table: "Allocation",
                column: "MaterialBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_allocation_order_id",
                schema: "inventory",
                table: "Allocation",
                column: "OrderId");

            migrationBuilder.CreateIndex(
                name: "IX_allocation_order_product_batch",
                schema: "inventory",
                table: "Allocation",
                columns: new[] { "OrderId", "ProductId", "MaterialBatchId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_allocation_product_id",
                schema: "inventory",
                table: "Allocation",
                column: "ProductId");

            migrationBuilder.CreateIndex(
                name: "IX_allocation_status",
                schema: "inventory",
                table: "Allocation",
                column: "Status");

            migrationBuilder.CreateIndex(
                name: "IX_bom_category_id",
                schema: "inventory",
                table: "Bom",
                column: "BomCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_bom_is_approved",
                schema: "inventory",
                table: "Bom",
                column: "IsApproved");

            migrationBuilder.CreateIndex(
                name: "IX_bom_name",
                schema: "inventory",
                table: "Bom",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bom_category_name",
                schema: "inventory",
                table: "BomCategory",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bom_item_bom_id",
                schema: "inventory",
                table: "BomItem",
                column: "BomId");

            migrationBuilder.CreateIndex(
                name: "IX_bom_item_composite_unique",
                schema: "inventory",
                table: "BomItem",
                columns: new[] { "BomId", "MaterialBatchId", "WarehouseItemId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_bom_item_material_batch_id",
                schema: "inventory",
                table: "BomItem",
                column: "MaterialBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_bom_item_warehouse_item_id",
                schema: "inventory",
                table: "BomItem",
                column: "WarehouseItemId");

            migrationBuilder.CreateIndex(
                name: "IX_bom_item_disposition_bom_item_id",
                schema: "inventory",
                table: "BomItemDisposition",
                column: "BomItemId");

            migrationBuilder.CreateIndex(
                name: "IX_bom_item_disposition_disposition",
                schema: "inventory",
                table: "BomItemDisposition",
                column: "Disposition");

            migrationBuilder.CreateIndex(
                name: "IX_bom_item_disposition_processed_on",
                schema: "inventory",
                table: "BomItemDisposition",
                column: "ProcessedOn");

            migrationBuilder.CreateIndex(
                name: "IX_material_cas_number",
                schema: "inventory",
                table: "Material",
                column: "CasNumber");

            migrationBuilder.CreateIndex(
                name: "IX_material_category",
                schema: "inventory",
                table: "Material",
                column: "Category");

            migrationBuilder.CreateIndex(
                name: "IX_material_is_active",
                schema: "inventory",
                table: "Material",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_material_name",
                schema: "inventory",
                table: "Material",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_material_sku_unique",
                schema: "inventory",
                table: "Material",
                column: "Sku",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_material_subcategory",
                schema: "inventory",
                table: "Material",
                column: "Subcategory");

            migrationBuilder.CreateIndex(
                name: "IX_material_batch_barcode_unique",
                schema: "inventory",
                table: "MaterialBatch",
                column: "Barcode",
                unique: true,
                filter: "barcode IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_material_batch_batch_code_unique",
                schema: "inventory",
                table: "MaterialBatch",
                column: "BatchCode",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_material_batch_expiry_date",
                schema: "inventory",
                table: "MaterialBatch",
                column: "ExpiryDate");

            migrationBuilder.CreateIndex(
                name: "IX_material_batch_is_active",
                schema: "inventory",
                table: "MaterialBatch",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_material_batch_material_id",
                schema: "inventory",
                table: "MaterialBatch",
                column: "MaterialId");

            migrationBuilder.CreateIndex(
                name: "IX_material_batch_storage_section_id",
                schema: "inventory",
                table: "MaterialBatch",
                column: "StorageSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_material_batch_vendor_id",
                schema: "inventory",
                table: "MaterialBatch",
                column: "VendorId");

            migrationBuilder.CreateIndex(
                name: "IX_material_storage_rule_material_id",
                schema: "inventory",
                table: "MaterialStorageRule",
                column: "MaterialId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_material_storage_rule_preferred_section_id",
                schema: "inventory",
                table: "MaterialStorageRule",
                column: "PreferredSectionId");

            migrationBuilder.CreateIndex(
                name: "IX_product_bom_id",
                schema: "inventory",
                table: "Product",
                column: "BomId");

            migrationBuilder.CreateIndex(
                name: "IX_product_is_active",
                schema: "inventory",
                table: "Product",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_product_sku",
                schema: "inventory",
                table: "Product",
                column: "Sku",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_app_module_Code",
                schema: "system",
                table: "RefAppModule",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_app_module_IsActive",
                schema: "system",
                table: "RefAppModule",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_app_module_TenantId",
                schema: "system",
                table: "RefAppModule",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_app_module_TenantId_Code_Unique",
                schema: "system",
                table: "RefAppModule",
                columns: new[] { "TenantId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefEnumType_Code",
                schema: "system",
                table: "RefEnumType",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefEnumType_Name",
                schema: "system",
                table: "RefEnumType",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefEnumValue_Code",
                schema: "system",
                table: "RefEnumValue",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefEnumValue_EnumTypeId",
                schema: "system",
                table: "RefEnumValue",
                column: "EnumTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_organization_code_unique",
                schema: "master",
                table: "RefOrganization",
                column: "Code",
                unique: true,
                filter: "[Code] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_organization_is_active",
                schema: "master",
                table: "RefOrganization",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_organization_name_unique",
                schema: "master",
                table: "RefOrganization",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_permission_Code",
                schema: "system",
                table: "RefPermission",
                column: "Code");

            migrationBuilder.CreateIndex(
                name: "IX_permission_IsActive",
                schema: "system",
                table: "RefPermission",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_permission_TenantId",
                schema: "system",
                table: "RefPermission",
                column: "TenantId");

            migrationBuilder.CreateIndex(
                name: "IX_permission_TenantId_Code_Unique",
                schema: "system",
                table: "RefPermission",
                columns: new[] { "TenantId", "Code" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefRole_Code",
                schema: "system",
                table: "RefRole",
                column: "Code",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_role_permission_IsActive",
                schema: "system",
                table: "RefRolePermission",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_role_permission_ModuleId",
                schema: "system",
                table: "RefRolePermission",
                column: "ModuleId");

            migrationBuilder.CreateIndex(
                name: "IX_role_permission_PermissionId",
                schema: "system",
                table: "RefRolePermission",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_role_permission_RoleId",
                schema: "system",
                table: "RefRolePermission",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_role_permission_RoleId_ModuleId_PermissionId_Unique",
                schema: "system",
                table: "RefRolePermission",
                columns: new[] { "RoleId", "ModuleId", "PermissionId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_EmailId",
                schema: "master",
                table: "RefUser",
                column: "EmailId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_User_IsActive",
                schema: "master",
                table: "RefUser",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_User_IsPasswordSet",
                schema: "master",
                table: "RefUser",
                column: "IsPasswordSet");

            migrationBuilder.CreateIndex(
                name: "IX_User_NumberOfAttempts",
                schema: "master",
                table: "RefUser",
                column: "NumberOfAttempts");

            migrationBuilder.CreateIndex(
                name: "IX_User_PhoneNo",
                schema: "master",
                table: "RefUser",
                column: "PhoneNo",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_user_role_IsActive",
                schema: "system",
                table: "RefUserRole",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_RoleID",
                schema: "system",
                table: "RefUserRole",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_UserID",
                schema: "system",
                table: "RefUserRole",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_user_role_UserID_RoleID",
                schema: "system",
                table: "RefUserRole",
                columns: new[] { "UserId", "RoleId" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RowLoc_AisleDOId",
                schema: "inventory",
                table: "RowLoc",
                column: "AisleDOId");

            migrationBuilder.CreateIndex(
                name: "IX_RowLoc_AisleId",
                schema: "inventory",
                table: "RowLoc",
                column: "AisleId");

            migrationBuilder.CreateIndex(
                name: "IX_storage_section_name",
                schema: "inventory",
                table: "StorageSection",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_tray_row_id",
                schema: "inventory",
                table: "Tray",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_Tray_RowLocDOId",
                schema: "inventory",
                table: "Tray",
                column: "RowLocDOId");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_IsActive",
                schema: "inventory",
                table: "Vendor",
                column: "IsActive");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_Name",
                schema: "inventory",
                table: "Vendor",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_Vendor_Type",
                schema: "inventory",
                table: "Vendor",
                column: "Type");

            migrationBuilder.CreateIndex(
                name: "IX_verified_material_created_on",
                schema: "inventory",
                table: "VerifiedMaterial",
                column: "CreatedOn");

            migrationBuilder.CreateIndex(
                name: "IX_verified_material_emp_id",
                schema: "inventory",
                table: "VerifiedMaterial",
                column: "EmpId");

            migrationBuilder.CreateIndex(
                name: "IX_verified_material_is_allotted",
                schema: "inventory",
                table: "VerifiedMaterial",
                column: "IsAllotted");

            migrationBuilder.CreateIndex(
                name: "IX_verified_material_is_qualified",
                schema: "inventory",
                table: "VerifiedMaterial",
                column: "IsQualified");

            migrationBuilder.CreateIndex(
                name: "IX_verified_material_material_batch_id",
                schema: "inventory",
                table: "VerifiedMaterial",
                column: "MaterialBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_name",
                schema: "inventory",
                table: "Warehouse",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_item_location",
                schema: "inventory",
                table: "WarehouseItem",
                columns: new[] { "WarehouseId", "AisleId", "RowId", "TrayId" });

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_item_material_batch_id",
                schema: "inventory",
                table: "WarehouseItem",
                column: "MaterialBatchId");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_item_name",
                schema: "inventory",
                table: "WarehouseItem",
                column: "Name");

            migrationBuilder.CreateIndex(
                name: "IX_warehouse_item_warehouse_id",
                schema: "inventory",
                table: "WarehouseItem",
                column: "WarehouseId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItem_AisleId",
                schema: "inventory",
                table: "WarehouseItem",
                column: "AisleId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItem_RowId",
                schema: "inventory",
                table: "WarehouseItem",
                column: "RowId");

            migrationBuilder.CreateIndex(
                name: "IX_WarehouseItem_TrayId",
                schema: "inventory",
                table: "WarehouseItem",
                column: "TrayId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Allocation",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "BomItemDisposition",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "MaterialStorageRule",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "Product",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "RefEnumValue",
                schema: "system");

            migrationBuilder.DropTable(
                name: "RefRolePermission",
                schema: "system");

            migrationBuilder.DropTable(
                name: "RefUserRole",
                schema: "system");

            migrationBuilder.DropTable(
                name: "VerifiedMaterial",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "BomItem",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "RefEnumType",
                schema: "system");

            migrationBuilder.DropTable(
                name: "RefAppModule",
                schema: "system");

            migrationBuilder.DropTable(
                name: "RefPermission",
                schema: "system");

            migrationBuilder.DropTable(
                name: "RefRole",
                schema: "system");

            migrationBuilder.DropTable(
                name: "RefUser",
                schema: "master");

            migrationBuilder.DropTable(
                name: "Bom",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "WarehouseItem",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "RefOrganization",
                schema: "master");

            migrationBuilder.DropTable(
                name: "BomCategory",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "MaterialBatch",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "Tray",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "Material",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "Vendor",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "RowLoc",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "Aisle",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "StorageSection",
                schema: "inventory");

            migrationBuilder.DropTable(
                name: "Warehouse",
                schema: "inventory");
        }
    }
}
