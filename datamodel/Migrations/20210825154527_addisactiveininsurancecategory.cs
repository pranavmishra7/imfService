using Microsoft.EntityFrameworkCore.Migrations;

namespace datamodel.Migrations
{
    public partial class addisactiveininsurancecategory : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "InsurancePlans",
                type: "bit",
                nullable: false,
                defaultValue: false);

            migrationBuilder.AddColumn<bool>(
                name: "IsActive",
                table: "InsuranceCategories",
                type: "bit",
                nullable: false,
                defaultValue: false);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "InsurancePlans");

            migrationBuilder.DropColumn(
                name: "IsActive",
                table: "InsuranceCategories");
        }
    }
}
