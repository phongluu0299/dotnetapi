using System;
using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace netCoreApi.Migrations
{
    /// <inheritdoc />
    public partial class InitialDb : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Page",
                columns: table => new
                {
                    PageID = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Parent = table.Column<int>(type: "int", nullable: false),
                    Display = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Title = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Icon = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: true),
                    Api = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Func = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Route = table.Column<string>(type: "nvarchar(500)", maxLength: 500, nullable: true),
                    Param = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    Hidden = table.Column<bool>(type: "bit", nullable: false),
                    Sort = table.Column<int>(type: "int", nullable: false),
                    UserCreated = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserModified = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Page", x => x.PageID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    UserID = table.Column<long>(type: "bigint", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    FullName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: false),
                    Password = table.Column<string>(type: "nvarchar(255)", maxLength: 255, nullable: false),
                    Salt = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Email = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    PhoneNumber = table.Column<string>(type: "nvarchar(50)", maxLength: 50, nullable: false),
                    Avatar = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    MainDeviceId = table.Column<string>(type: "nvarchar(250)", maxLength: 250, nullable: true),
                    UserCreated = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    DateCreated = table.Column<DateTime>(type: "datetime", nullable: true),
                    UserModified = table.Column<decimal>(type: "numeric(18,0)", nullable: true),
                    DateModified = table.Column<DateTime>(type: "datetime", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.UserID);
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Page");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
