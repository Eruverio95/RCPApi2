using Microsoft.EntityFrameworkCore.Migrations;

namespace RCP.Migrations
{
    public partial class FinalDbRemoveQuestionnairiesActivityId : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
          migrationBuilder.DropForeignKey(
            name: "FK_Questionnaires_Activities_ActivityId",
            table: "Questionnaires");

          migrationBuilder.DropIndex(
            name: "IX_Questionnaires_ActivityId",
            table: "Questionnaires");

          migrationBuilder.DropColumn(
            name: "ActivityId",
            table: "Questionnaires");
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {

        }
    }
}
