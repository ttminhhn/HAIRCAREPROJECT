using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace HAIRCARE.INFRASTURUCTURE.Migrations
{
    public partial class InitCreateDb : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "user_group_mst",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    DeleteFlag = table.Column<int>(nullable: false, defaultValueSql: "(0)"),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Note = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_group_mst", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_role_mst",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    DeleteFlag = table.Column<int>(nullable: false, defaultValueSql: "(0)"),
                    Code = table.Column<string>(maxLength: 10, nullable: false),
                    Name = table.Column<string>(maxLength: 50, nullable: false),
                    Note = table.Column<string>(maxLength: 200, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_role_mst", x => x.Id);
                });

            migrationBuilder.CreateTable(
                name: "user_mst",
                columns: table => new
                {
                    Id = table.Column<int>(nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    CreatedBy = table.Column<int>(nullable: true),
                    DateCreated = table.Column<DateTime>(nullable: true),
                    LastModifiedBy = table.Column<int>(nullable: true),
                    DateModified = table.Column<DateTime>(nullable: true),
                    DeleteFlag = table.Column<int>(nullable: false, defaultValueSql: "(0)"),
                    FirstName = table.Column<string>(maxLength: 50, nullable: false),
                    LastName = table.Column<string>(maxLength: 50, nullable: false),
                    AvatarImg = table.Column<string>(maxLength: 2000, nullable: true),
                    UserName = table.Column<string>(maxLength: 100, nullable: false),
                    Password = table.Column<string>(maxLength: 256, nullable: false),
                    PastPassword1 = table.Column<string>(maxLength: 256, nullable: true),
                    PastPassword2 = table.Column<string>(maxLength: 256, nullable: true),
                    PastPassword3 = table.Column<string>(maxLength: 256, nullable: true),
                    PastPassword4 = table.Column<string>(maxLength: 256, nullable: true),
                    PasswordModifiedDate = table.Column<DateTime>(nullable: false),
                    PasswordExpirationDate = table.Column<DateTime>(nullable: false),
                    Email = table.Column<string>(maxLength: 100, nullable: false),
                    UserRoleId = table.Column<int>(nullable: false),
                    UserState = table.Column<int>(nullable: false, defaultValueSql: "(0)"),
                    LoggedInDate = table.Column<DateTime>(nullable: false),
                    PreviousLoggedInDate = table.Column<DateTime>(nullable: false),
                    LoginFailureCount = table.Column<int>(nullable: false),
                    LockedDateTime = table.Column<DateTime>(nullable: false),
                    VerifyToken = table.Column<string>(nullable: true),
                    VerifyTokenExpirationDate = table.Column<DateTime>(nullable: false),
                    TimezoneId = table.Column<string>(maxLength: 100, nullable: true),
                    Language = table.Column<string>(maxLength: 5, nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_mst", x => x.Id);
                    table.ForeignKey(
                        name: "FK_user_mst_user_role_mst_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "user_role_mst",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "user_group_ref",
                columns: table => new
                {
                    UserId = table.Column<int>(nullable: false),
                    UserGroupId = table.Column<int>(nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user_group_ref", x => new { x.UserId, x.UserGroupId });
                    table.ForeignKey(
                        name: "FK_user_group_ref_user_group_mst_UserGroupId",
                        column: x => x.UserGroupId,
                        principalTable: "user_group_mst",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_group_ref_user_mst_UserId",
                        column: x => x.UserId,
                        principalTable: "user_mst",
                        principalColumn: "Id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_user_group_ref_UserGroupId",
                table: "user_group_ref",
                column: "UserGroupId");

            migrationBuilder.CreateIndex(
                name: "IX_user_mst_UserRoleId",
                table: "user_mst",
                column: "UserRoleId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "user_group_ref");

            migrationBuilder.DropTable(
                name: "user_group_mst");

            migrationBuilder.DropTable(
                name: "user_mst");

            migrationBuilder.DropTable(
                name: "user_role_mst");
        }
    }
}
