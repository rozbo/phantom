using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace phantom.Migrations
{
    public partial class InitialCreate : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Topic",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "BLOB", nullable: false),
                    Content = table.Column<string>(type: "TEXT", nullable: true),
                    NodeId = table.Column<int>(type: "INTEGER", nullable: false),
                    PostDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    ReplyCount = table.Column<int>(type: "INTEGER", nullable: false),
                    ReplyDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Title = table.Column<string>(type: "TEXT", nullable: true),
                    UserId = table.Column<Guid>(type: "BLOB", nullable: false),
                    ViewCount = table.Column<int>(type: "INTEGER", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Topic", x => x.ID);
                });

            migrationBuilder.CreateTable(
                name: "User",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "BLOB", nullable: false),
                    Password = table.Column<string>(type: "TEXT", nullable: true),
                    Username = table.Column<string>(type: "TEXT", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_User", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Topic");

            migrationBuilder.DropTable(
                name: "User");
        }
    }
}
