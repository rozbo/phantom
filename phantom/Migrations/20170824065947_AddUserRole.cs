using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace phantom.Migrations
{
    public partial class AddUserRole : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>(
                "Role",
                "User",
                nullable:true);
            migrationBuilder.AddColumn<string>(
                name: "Nickname",
                table: "UserInfo",
                type: "TEXT",
                nullable: true);

        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "Role",
                table: "User");
            migrationBuilder.DropColumn(
                name: "Nickname",
                table: "UserInfo");

        }
    }
}
