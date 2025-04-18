using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

namespace SportNutrition.Migrations
{
    /// <inheritdoc />
    public partial class InitialCreate : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "exercises",
                columns: table => new
                {
                    exercisesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    muscleGroup = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_exercises", x => x.exercisesId);
                });

            migrationBuilder.CreateTable(
                name: "gender",
                columns: table => new
                {
                    genderId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    gender = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_gender", x => x.genderId);
                });

            migrationBuilder.CreateTable(
                name: "identificationType",
                columns: table => new
                {
                    IdentificationTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Identification_Type = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_identificationType", x => x.IdentificationTypeId);
                });

            migrationBuilder.CreateTable(
                name: "meals",
                columns: table => new
                {
                    mealsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    calories = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    protein = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    carbs = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    flat = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_meals", x => x.mealsId);
                });

            migrationBuilder.CreateTable(
                name: "nutritionPlans",
                columns: table => new
                {
                    nutritionPlansId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    goal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    dalyCalories = table.Column<float>(type: "real", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutritionPlans", x => x.nutritionPlansId);
                });

            migrationBuilder.CreateTable(
                name: "permissions",
                columns: table => new
                {
                    permissionsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    permission = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissions", x => x.permissionsId);
                });

            migrationBuilder.CreateTable(
                name: "userType",
                columns: table => new
                {
                    userTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_userType", x => x.userTypeId);
                });

            migrationBuilder.CreateTable(
                name: "workouts",
                columns: table => new
                {
                    workoutId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    difficultyLevel = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    duration = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    goal = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workouts", x => x.workoutId);
                });

            migrationBuilder.CreateTable(
                name: "nutritionMeals",
                columns: table => new
                {
                    nutritionMealsId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    nutritionPlans_Id = table.Column<int>(type: "int", nullable: false),
                    meals_Id = table.Column<int>(type: "int", nullable: false),
                    mealType = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_nutritionMeals", x => x.nutritionMealsId);
                    table.ForeignKey(
                        name: "FK_nutritionMeals_meals_meals_Id",
                        column: x => x.meals_Id,
                        principalTable: "meals",
                        principalColumn: "mealsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_nutritionMeals_nutritionPlans_nutritionPlans_Id",
                        column: x => x.nutritionPlans_Id,
                        principalTable: "nutritionPlans",
                        principalColumn: "nutritionPlansId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "permissionXUserType",
                columns: table => new
                {
                    permissionXUserTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    userType_Id = table.Column<int>(type: "int", nullable: false),
                    permissions_Id = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_permissionXUserType", x => x.permissionXUserTypeId);
                    table.ForeignKey(
                        name: "FK_permissionXUserType_permissions_permissions_Id",
                        column: x => x.permissions_Id,
                        principalTable: "permissions",
                        principalColumn: "permissionsId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_permissionXUserType_userType_userType_Id",
                        column: x => x.userType_Id,
                        principalTable: "userType",
                        principalColumn: "userTypeId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateTable(
                name: "user",
                columns: table => new
                {
                    userId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    user_Type_Id = table.Column<int>(type: "int", nullable: false),
                    identificationType_Id = table.Column<int>(type: "int", nullable: false),
                    identificationNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    names = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    lastNames = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    birthDate = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    contact = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    gender_Id = table.Column<int>(type: "int", nullable: false),
                    height = table.Column<float>(type: "real", nullable: false),
                    weight = table.Column<float>(type: "real", nullable: false),
                    workoutId = table.Column<int>(type: "int", nullable: false),
                    workout_Id = table.Column<int>(type: "int", nullable: false),
                    nutritionPlansId = table.Column<int>(type: "int", nullable: false),
                    nutritionPlans_Id = table.Column<int>(type: "int", nullable: false),
                    email = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_user", x => x.userId);
                    table.ForeignKey(
                        name: "FK_user_gender_gender_Id",
                        column: x => x.gender_Id,
                        principalTable: "gender",
                        principalColumn: "genderId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_identificationType_identificationType_Id",
                        column: x => x.identificationType_Id,
                        principalTable: "identificationType",
                        principalColumn: "IdentificationTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_nutritionPlans_nutritionPlansId",
                        column: x => x.nutritionPlansId,
                        principalTable: "nutritionPlans",
                        principalColumn: "nutritionPlansId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_userType_user_Type_Id",
                        column: x => x.user_Type_Id,
                        principalTable: "userType",
                        principalColumn: "userTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_user_workouts_workoutId",
                        column: x => x.workoutId,
                        principalTable: "workouts",
                        principalColumn: "workoutId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "workoutExercises",
                columns: table => new
                {
                    workoutExercisesId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    workout_Id = table.Column<int>(type: "int", nullable: false),
                    exercises_Id = table.Column<int>(type: "int", nullable: false),
                    sets = table.Column<int>(type: "int", nullable: false),
                    reps = table.Column<int>(type: "int", nullable: false),
                    restSeconds = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_workoutExercises", x => x.workoutExercisesId);
                    table.ForeignKey(
                        name: "FK_workoutExercises_exercises_exercises_Id",
                        column: x => x.exercises_Id,
                        principalTable: "exercises",
                        principalColumn: "exercisesId",
                        onDelete: ReferentialAction.Restrict);
                    table.ForeignKey(
                        name: "FK_workoutExercises_workouts_workout_Id",
                        column: x => x.workout_Id,
                        principalTable: "workouts",
                        principalColumn: "workoutId",
                        onDelete: ReferentialAction.Restrict);
                });

            migrationBuilder.CreateIndex(
                name: "IX_nutritionMeals_meals_Id",
                table: "nutritionMeals",
                column: "meals_Id");

            migrationBuilder.CreateIndex(
                name: "IX_nutritionMeals_nutritionPlans_Id",
                table: "nutritionMeals",
                column: "nutritionPlans_Id");

            migrationBuilder.CreateIndex(
                name: "IX_permissionXUserType_permissions_Id",
                table: "permissionXUserType",
                column: "permissions_Id");

            migrationBuilder.CreateIndex(
                name: "IX_permissionXUserType_userType_Id",
                table: "permissionXUserType",
                column: "userType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_user_gender_Id",
                table: "user",
                column: "gender_Id");

            migrationBuilder.CreateIndex(
                name: "IX_user_identificationType_Id",
                table: "user",
                column: "identificationType_Id");

            migrationBuilder.CreateIndex(
                name: "IX_user_nutritionPlansId",
                table: "user",
                column: "nutritionPlansId");

            migrationBuilder.CreateIndex(
                name: "IX_user_user_Type_Id",
                table: "user",
                column: "user_Type_Id");

            migrationBuilder.CreateIndex(
                name: "IX_user_workoutId",
                table: "user",
                column: "workoutId");

            migrationBuilder.CreateIndex(
                name: "IX_workoutExercises_exercises_Id",
                table: "workoutExercises",
                column: "exercises_Id");

            migrationBuilder.CreateIndex(
                name: "IX_workoutExercises_workout_Id",
                table: "workoutExercises",
                column: "workout_Id");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "nutritionMeals");

            migrationBuilder.DropTable(
                name: "permissionXUserType");

            migrationBuilder.DropTable(
                name: "user");

            migrationBuilder.DropTable(
                name: "workoutExercises");

            migrationBuilder.DropTable(
                name: "meals");

            migrationBuilder.DropTable(
                name: "permissions");

            migrationBuilder.DropTable(
                name: "gender");

            migrationBuilder.DropTable(
                name: "identificationType");

            migrationBuilder.DropTable(
                name: "nutritionPlans");

            migrationBuilder.DropTable(
                name: "userType");

            migrationBuilder.DropTable(
                name: "exercises");

            migrationBuilder.DropTable(
                name: "workouts");
        }
    }
}
