using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace phantom.Migrations
{
    public partial class AddUserInfo : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "UserInfo",
                columns: table => new
                {
                    ID = table.Column<Guid>(type: "BLOB", nullable: false),
                    UserId = table.Column<Guid>(type: "BLOB", nullable: false),
                    Sex = table.Column<int>(type: "INTEGER", nullable: true,defaultValue:0),
                    Age = table.Column<int>(type: "INTEGER", nullable: false,defaultValue:0),
                    RegDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    LastDate = table.Column<DateTime>(type: "TEXT", nullable: false),
                    Bio = table.Column<string>(type: "TEXT", nullable: true),
                },
                constraints: table =>
                {
                    table.ForeignKey(
                        "FK_UserInfo",
                        x => x.UserId,
                        "User",
                        "ID"
                    );
                    table.PrimaryKey("PK_UserInfo", x => x.ID);
                });
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable("UserInfo");
        }
    }
}
