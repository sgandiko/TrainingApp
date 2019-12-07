using Microsoft.EntityFrameworkCore.Migrations;

namespace TrainingApp.Infrastructure.Migrations
{
    public partial class AddedIndexToTable : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TrainingEndDate",
                table: "Trainings",
                column: "TrainingEndDate");

            migrationBuilder.CreateIndex(
                name: "IX_Trainings_TrainingStartDate",
                table: "Trainings",
                column: "TrainingStartDate");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropIndex(
                name: "IX_Trainings_TrainingEndDate",
                table: "Trainings");

            migrationBuilder.DropIndex(
                name: "IX_Trainings_TrainingStartDate",
                table: "Trainings");
        }
    }
}
