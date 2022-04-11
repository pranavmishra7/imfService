using System;
using Microsoft.EntityFrameworkCore.Migrations;

namespace datamodel.Migrations
{
    public partial class InsurancePolicyDetails : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "InsuranceDetailsModel",
                columns: table => new
                {
                    InsurancePolicyId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsuranceCategoryId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    InsurancePlanId = table.Column<Guid>(type: "uniqueidentifier", nullable: false),
                    insuranceProvider = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    policyName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    sumAssured = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    premiumPayingTerm = table.Column<int>(type: "int", nullable: false),
                    policyTerm = table.Column<int>(type: "int", nullable: false),
                    premiumPayingMode = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    //table.PrimaryKey("PK_InsuranceDetailsModel", x => x.InsurancePolicyId);
                    //table.ForeignKey(
                    //    name: "FK_InsuranceDetailsModel_InsuranceCategories_InsuranceCategoryId",
                    //    column: x => x.InsuranceCategoryId,
                    //    principalTable: "InsuranceCategories",
                    //    principalColumn: "id",
                    //    onDelete: ReferentialAction.Cascade);

                    table.ForeignKey(
                        name: "FK_InsuranceDetailsModel_InsurancePlans_InsurancePlanId",
                        column: x => x.InsurancePlanId,
                        principalTable: "InsurancePlans",
                        principalColumn: "id",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceDetailsModel_InsuranceCategoryId",
                table: "InsuranceDetailsModel",
                column: "InsuranceCategoryId");

            migrationBuilder.CreateIndex(
                name: "IX_InsuranceDetailsModel_InsurancePlanId",
                table: "InsuranceDetailsModel",
                column: "InsurancePlanId");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "InsuranceDetailsModel");
        }
    }
}
