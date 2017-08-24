using Microsoft.EntityFrameworkCore.Migrations;
using System;
using System.Collections.Generic;

namespace phantom.Migrations
{
    public partial class AddUserEmail : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<string>("Email", "User",nullable:true);
            migrationBuilder.AddColumn<string>("Education", "UserInfo",nullable:true);
            migrationBuilder.AddColumn<string>("Location", "UserInfo",nullable:true);
            migrationBuilder.AddColumn<string>("Skills", "UserInfo",nullable:true);
            migrationBuilder.AddColumn<string>("Notes", "UserInfo",nullable:true);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn("Email", "User");
            migrationBuilder.DropColumn("Education", "UserInfo");
            migrationBuilder.DropColumn("Location", "UserInfo");
            migrationBuilder.DropColumn("Skills", "UserInfo");
            migrationBuilder.DropColumn("Notes", "UserInfo");
        }
    }
}
