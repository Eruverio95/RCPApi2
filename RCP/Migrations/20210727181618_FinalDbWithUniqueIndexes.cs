using Microsoft.EntityFrameworkCore.Migrations;

namespace RCP.Migrations
{
    public partial class FinalDbWithUniqueIndexes : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Questionnaires_Activities_ActivityId",
                table: "Questionnaires");

            migrationBuilder.DropIndex(
                name: "IX_MeasurementQuestionnaireAnswers_MeasurementId",
                table: "MeasurementQuestionnaireAnswers");

            migrationBuilder.DropIndex(
                name: "IX_ActiveMeasurements_UserId",
                table: "ActiveMeasurements");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "Questionnaires",
                nullable: true,
                oldClrType: typeof(int));

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Measurements",
                type: "int",
                nullable: false,
                defaultValue: 4,
                oldClrType: typeof(int),
                oldType: "int");

            migrationBuilder.AddColumn<int>(
                name: "QuestionnaireId",
                table: "Activities",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementQuestionnaireAnswers_MeasurementId",
                table: "MeasurementQuestionnaireAnswers",
                column: "MeasurementId",
                unique: true);

            migrationBuilder.CreateIndex(
                name: "IX_Activities_QuestionnaireId",
                table: "Activities",
                column: "QuestionnaireId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveMeasurements_UserId",
                table: "ActiveMeasurements",
                column: "UserId",
                unique: true);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Questionnaires_QuestionnaireId",
                table: "Activities",
                column: "QuestionnaireId",
                principalTable: "Questionnaires",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Questionnaires_Activities_ActivityId",
                table: "Questionnaires",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Questionnaires_QuestionnaireId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_Questionnaires_Activities_ActivityId",
                table: "Questionnaires");

            migrationBuilder.DropIndex(
                name: "IX_MeasurementQuestionnaireAnswers_MeasurementId",
                table: "MeasurementQuestionnaireAnswers");

            migrationBuilder.DropIndex(
                name: "IX_Activities_QuestionnaireId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_ActiveMeasurements_UserId",
                table: "ActiveMeasurements");

            migrationBuilder.DropColumn(
                name: "QuestionnaireId",
                table: "Activities");

            migrationBuilder.AlterColumn<int>(
                name: "ActivityId",
                table: "Questionnaires",
                nullable: false,
                oldClrType: typeof(int),
                oldNullable: true);

            migrationBuilder.AlterColumn<int>(
                name: "Status",
                table: "Measurements",
                type: "int",
                nullable: false,
                oldClrType: typeof(int),
                oldType: "int",
                oldDefaultValue: 4);

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementQuestionnaireAnswers_MeasurementId",
                table: "MeasurementQuestionnaireAnswers",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveMeasurements_UserId",
                table: "ActiveMeasurements",
                column: "UserId");

            migrationBuilder.AddForeignKey(
                name: "FK_Questionnaires_Activities_ActivityId",
                table: "Questionnaires",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }
    }
}
