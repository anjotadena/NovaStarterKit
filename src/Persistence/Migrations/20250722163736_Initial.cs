using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Persistence.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Permissions",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Resource = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Action = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Permissions", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Roles",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Name = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Description = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    IsActive = table.Column<bool>(type: "bit", nullable: false, defaultValue: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true, defaultValueSql: "GETUTCDATE()"),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Roles", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    FirstName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(200)", maxLength: 200, nullable: false),
                    HashedPassword = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PhoneNumber = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    IsActive = table.Column<bool>(type: "bit", nullable: false),
                    IsEmailConfirmed = table.Column<bool>(type: "bit", nullable: false),
                    LastLoginDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SecurityStamp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    ConcurrencyStamp = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false),
                    FailedLoginAttempts = table.Column<int>(type: "int", nullable: false),
                    LockoutEnd = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "RolePermissions",
                columns: table => new
                {
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    PermissionId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RolePermissions", x => new { x.RoleId, x.PermissionId });
                    table.ForeignKey(
                        name: "FK_RolePermissions_Permissions_PermissionId",
                        column: x => x.PermissionId,
                        principalTable: "Permissions",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_RolePermissions_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "RefreshTokens",
                columns: table => new
                {
                    Id = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    Token = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: false),
                    ExpiresAt = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsRevoked = table.Column<bool>(type: "bit", nullable: false, defaultValue: false),
                    RevokedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    RevokedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: true),
                    ReplacedByToken = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    CreatedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    UpdatedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UpdatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedAt = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_RefreshTokens", x => x.Id);
                    table.ForeignKey(
                        name: "FK_RefreshTokens_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    RoleId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    AssignedAt = table.Column<DateTime>(type: "datetime2", nullable: false, defaultValueSql: "GETUTCDATE()"),
                    AssignedBy = table.Column<string>(type: "nvarchar(100)", maxLength: 100, nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => new { x.UserId, x.RoleId });
                    table.ForeignKey(
                        name: "FK_UserRoles_Roles_RoleId",
                        column: x => x.RoleId,
                        principalTable: "Roles",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_UserRoles_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "Permissions",
                columns: new[] { "Id", "Action", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "Name", "Resource", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("550e8400-e29b-41d4-a716-446655440001"), "Create", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to create users", "Users.Create", "Users", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440002"), "Read", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to read users", "Users.Read", "Users", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440003"), "Update", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to update users", "Users.Update", "Users", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440004"), "Delete", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to delete users", "Users.Delete", "Users", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440005"), "Manage", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to manage users", "Users.Manage", "Users", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440006"), "Create", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to create roles", "Roles.Create", "Roles", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440007"), "Read", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to read roles", "Roles.Read", "Roles", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440008"), "Update", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to update roles", "Roles.Update", "Roles", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440009"), "Delete", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to delete roles", "Roles.Delete", "Roles", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440010"), "Manage", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to manage roles", "Roles.Manage", "Roles", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440011"), "Create", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to create permissions", "Permissions.Create", "Permissions", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440012"), "Read", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to read permissions", "Permissions.Read", "Permissions", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440013"), "Update", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to update permissions", "Permissions.Update", "Permissions", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440014"), "Delete", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to delete permissions", "Permissions.Delete", "Permissions", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440015"), "Manage", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to manage permissions", "Permissions.Manage", "Permissions", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440016"), "Create", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to create content", "Content.Create", "Content", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440017"), "Read", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to read content", "Content.Read", "Content", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440018"), "Update", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to update content", "Content.Update", "Content", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440019"), "Delete", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to delete content", "Content.Delete", "Content", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440020"), "Manage", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to manage content", "Content.Manage", "Content", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440021"), "Create", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to create reports", "Reports.Create", "Reports", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440022"), "Read", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to read reports", "Reports.Read", "Reports", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440023"), "Update", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to update reports", "Reports.Update", "Reports", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440024"), "Delete", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to delete reports", "Reports.Delete", "Reports", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440025"), "Manage", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to manage reports", "Reports.Manage", "Reports", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440026"), "Create", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to create settings", "Settings.Create", "Settings", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440027"), "Read", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to read settings", "Settings.Read", "Settings", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440028"), "Update", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to update settings", "Settings.Update", "Settings", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440029"), "Delete", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to delete settings", "Settings.Delete", "Settings", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" },
                    { new Guid("550e8400-e29b-41d4-a716-446655440030"), "Manage", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System", null, null, "Permission to manage settings", "Settings.Manage", "Settings", new DateTime(2024, 1, 1, 0, 0, 0, 0, DateTimeKind.Utc), "System" }
                });

            migrationBuilder.InsertData(
                table: "Roles",
                columns: new[] { "Id", "CreatedAt", "CreatedBy", "DeletedAt", "DeletedBy", "Description", "IsActive", "Name", "UpdatedAt", "UpdatedBy" },
                values: new object[,]
                {
                    { new Guid("7a2b59d7-b603-406d-99a6-0955792dfc90"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, "System Administrator with full access", true, "Admin", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System" },
                    { new Guid("7a2b59d7-b603-406d-99a6-0955792dfc91"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, "Standard user with limited access", true, "User", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System" },
                    { new Guid("7a2b59d7-b603-406d-99a6-0955792dfc92"), new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System", null, null, "Moderator with content management permissions", true, "Moderator", new DateTime(2025, 1, 1, 0, 0, 0, 0, DateTimeKind.Unspecified), "System" }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Permissions_Resource_Action",
                table: "Permissions",
                columns: new[] { "Resource", "Action" },
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_ExpiresAt",
                table: "RefreshTokens",
                column: "ExpiresAt");

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_Token",
                table: "RefreshTokens",
                column: "Token",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_RefreshTokens_UserId",
                table: "RefreshTokens",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_PermissionId",
                table: "RolePermissions",
                column: "PermissionId");

            migrationBuilder.CreateIndex(
                name: "IX_RolePermissions_RoleId",
                table: "RolePermissions",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Roles_Name",
                table: "Roles",
                column: "Name",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_RoleId",
                table: "UserRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRoles_UserId",
                table: "UserRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_Email",
                table: "Users",
                column: "Email",
                unique: true);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "RefreshTokens");

            migrationBuilder.DropTable(
                name: "RolePermissions");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "Permissions");

            migrationBuilder.DropTable(
                name: "Roles");

            migrationBuilder.DropTable(
                name: "Users");
        }
    }
}
