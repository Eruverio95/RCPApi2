using Microsoft.EntityFrameworkCore.Migrations;

namespace RCP.Migrations
{
    public partial class AddForeignKeys : Migration
    {
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropColumn(
                name: "QuestionnaireId",
                table: "Activities");

            migrationBuilder.AddColumn<int>(
                name: "ActivityId",
                table: "Questionnaires",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "Status",
                table: "Measurements",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_UserProjectRoles_ProjectId",
                table: "UserProjectRoles",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjectRoles_RoleId",
                table: "UserProjectRoles",
                column: "RoleId");

            migrationBuilder.CreateIndex(
                name: "IX_UserProjectRoles_UserId",
                table: "UserProjectRoles",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_ActivityId",
                table: "Questionnaires",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Questionnaires_ProjectId",
                table: "Questionnaires",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_ActivityId",
                table: "Measurements",
                column: "ActivityId");

            migrationBuilder.CreateIndex(
                name: "IX_Measurements_UserId",
                table: "Measurements",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_MeasurementQuestionnaireAnswers_MeasurementId",
                table: "MeasurementQuestionnaireAnswers",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_Activities_ProjectId",
                table: "Activities",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveMeasurements_MeasurementId",
                table: "ActiveMeasurements",
                column: "MeasurementId");

            migrationBuilder.CreateIndex(
                name: "IX_ActiveMeasurements_UserId",
                table: "ActiveMeasurements",
                column: "UserId");
      
            migrationBuilder.AddForeignKey(
                name: "FK_ActiveMeasurements_Measurements_MeasurementId",
                table: "ActiveMeasurements",
                column: "MeasurementId",
                principalTable: "Measurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_ActiveMeasurements_Users_UserId",
                table: "ActiveMeasurements",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Activities_Projects_ProjectId",
                table: "Activities",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_MeasurementQuestionnaireAnswers_Measurements_MeasurementId",
                table: "MeasurementQuestionnaireAnswers",
                column: "MeasurementId",
                principalTable: "Measurements",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Activities_ActivityId",
                table: "Measurements",
                column: "ActivityId",
                principalTable: "Activities",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_Measurements_Users_UserId",
                table: "Measurements",
                column: "UserId",
                principalTable: "Users",
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

            migrationBuilder.AddForeignKey(
                name: "FK_Questionnaires_Projects_ProjectId",
                table: "Questionnaires",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjectRoles_Projects_ProjectId",
                table: "UserProjectRoles",
                column: "ProjectId",
                principalTable: "Projects",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjectRoles_Roles_RoleId",
                table: "UserProjectRoles",
                column: "RoleId",
                principalTable: "Roles",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);

            migrationBuilder.AddForeignKey(
                name: "FK_UserProjectRoles_Users_UserId",
                table: "UserProjectRoles",
                column: "UserId",
                principalTable: "Users",
                principalColumn: "Id",
                onDelete: ReferentialAction.NoAction,
                onUpdate: ReferentialAction.NoAction);
        }

        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_ActiveMeasurements_Measurements_MeasurementId",
                table: "ActiveMeasurements");

            migrationBuilder.DropForeignKey(
                name: "FK_ActiveMeasurements_Users_UserId",
                table: "ActiveMeasurements");

            migrationBuilder.DropForeignKey(
                name: "FK_Activities_Projects_ProjectId",
                table: "Activities");

            migrationBuilder.DropForeignKey(
                name: "FK_MeasurementQuestionnaireAnswers_Measurements_MeasurementId",
                table: "MeasurementQuestionnaireAnswers");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Activities_ActivityId",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_Measurements_Users_UserId",
                table: "Measurements");

            migrationBuilder.DropForeignKey(
                name: "FK_Questionnaires_Activities_ActivityId",
                table: "Questionnaires");

            migrationBuilder.DropForeignKey(
                name: "FK_Questionnaires_Projects_ProjectId",
                table: "Questionnaires");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProjectRoles_Projects_ProjectId",
                table: "UserProjectRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProjectRoles_Roles_RoleId",
                table: "UserProjectRoles");

            migrationBuilder.DropForeignKey(
                name: "FK_UserProjectRoles_Users_UserId",
                table: "UserProjectRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserProjectRoles_ProjectId",
                table: "UserProjectRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserProjectRoles_RoleId",
                table: "UserProjectRoles");

            migrationBuilder.DropIndex(
                name: "IX_UserProjectRoles_UserId",
                table: "UserProjectRoles");

            migrationBuilder.DropIndex(
                name: "IX_Questionnaires_ActivityId",
                table: "Questionnaires");

            migrationBuilder.DropIndex(
                name: "IX_Questionnaires_ProjectId",
                table: "Questionnaires");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_ActivityId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_Measurements_UserId",
                table: "Measurements");

            migrationBuilder.DropIndex(
                name: "IX_MeasurementQuestionnaireAnswers_MeasurementId",
                table: "MeasurementQuestionnaireAnswers");

            migrationBuilder.DropIndex(
                name: "IX_Activities_ProjectId",
                table: "Activities");

            migrationBuilder.DropIndex(
                name: "IX_ActiveMeasurements_MeasurementId",
                table: "ActiveMeasurements");

            migrationBuilder.DropIndex(
                name: "IX_ActiveMeasurements_UserId",
                table: "ActiveMeasurements");

            migrationBuilder.DropColumn(
                name: "ActivityId",
                table: "Questionnaires");

            migrationBuilder.DropColumn(
                name: "Status",
                table: "Measurements");

            migrationBuilder.AddColumn<int>(
                name: "QuestionnaireId",
                table: "Activities",
                nullable: false,
                defaultValue: 0);
        }
    }
}
