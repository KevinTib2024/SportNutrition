using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportNutrition.Migrations
{
    /// <inheritdoc />
    public partial class AgregarRelacciones : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_nutritionPlans_nutritionPlansId",
                table: "user");

            migrationBuilder.DropForeignKey(
                name: "FK_user_workouts_workoutId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_nutritionPlansId",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_workoutId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "nutritionPlansId",
                table: "user");

            migrationBuilder.DropColumn(
                name: "workoutId",
                table: "user");

            migrationBuilder.CreateIndex(
                name: "IX_user_nutritionPlans_Id",
                table: "user",
                column: "nutritionPlans_Id");

            migrationBuilder.CreateIndex(
                name: "IX_user_workout_Id",
                table: "user",
                column: "workout_Id");

            migrationBuilder.AddForeignKey(
                name: "FK_user_nutritionPlans_nutritionPlans_Id",
                table: "user",
                column: "nutritionPlans_Id",
                principalTable: "nutritionPlans",
                principalColumn: "nutritionPlansId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_workouts_workout_Id",
                table: "user",
                column: "workout_Id",
                principalTable: "workouts",
                principalColumn: "workoutId",
                onDelete: ReferentialAction.Cascade);
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropForeignKey(
                name: "FK_user_nutritionPlans_nutritionPlans_Id",
                table: "user");

            migrationBuilder.DropForeignKey(
                name: "FK_user_workouts_workout_Id",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_nutritionPlans_Id",
                table: "user");

            migrationBuilder.DropIndex(
                name: "IX_user_workout_Id",
                table: "user");

            migrationBuilder.AddColumn<int>(
                name: "nutritionPlansId",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.AddColumn<int>(
                name: "workoutId",
                table: "user",
                type: "int",
                nullable: false,
                defaultValue: 0);

            migrationBuilder.CreateIndex(
                name: "IX_user_nutritionPlansId",
                table: "user",
                column: "nutritionPlansId");

            migrationBuilder.CreateIndex(
                name: "IX_user_workoutId",
                table: "user",
                column: "workoutId");

            migrationBuilder.AddForeignKey(
                name: "FK_user_nutritionPlans_nutritionPlansId",
                table: "user",
                column: "nutritionPlansId",
                principalTable: "nutritionPlans",
                principalColumn: "nutritionPlansId",
                onDelete: ReferentialAction.Cascade);

            migrationBuilder.AddForeignKey(
                name: "FK_user_workouts_workoutId",
                table: "user",
                column: "workoutId",
                principalTable: "workouts",
                principalColumn: "workoutId",
                onDelete: ReferentialAction.Cascade);
        }
    }
}
