using Microsoft.EntityFrameworkCore;
using SportNutrition.Model;

namespace SportNutrition.Context
{
    public class SportNutritionDbContext : DbContext
    {
        public SportNutritionDbContext(DbContextOptions options) : base(options)
        {


        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //Users
            modelBuilder.Entity<User>().HasOne(u => u.user_Type).WithMany(ut => ut.users).HasForeignKey(u => u.user_Type_Id);
            modelBuilder.Entity<User>().HasOne(u => u.identificationType).WithMany(it => it.users).HasForeignKey(u => u.identificationType_Id);
            modelBuilder.Entity<User>().HasOne(u => u.gender).WithMany(g => g.users).HasForeignKey(u => u.gender_Id);
            modelBuilder.Entity<User>().HasOne(u => u.nutritionPlans).WithMany(g => g.users).HasForeignKey(u => u.nutritionPlans_Id);
            modelBuilder.Entity<User>().HasOne(u => u.workout).WithMany(g => g.users).HasForeignKey(u => u.workout_Id);
            modelBuilder.Entity<User>().HasKey(u => u.userId);

            //modelBuilder.Entity<User>().ToTable(tb => tb.HasTrigger("trg_AuditUser"));

            //PermissionXUserType
            modelBuilder.Entity<PermissionXUserType>()
                .HasKey(pu => pu.permissionXUserTypeId);

            modelBuilder.Entity<PermissionXUserType>()
                .HasOne(pu => pu.permissions)
                .WithMany(p => p.permissionXUserTypes)
                .HasForeignKey(pu => pu.permissions_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<PermissionXUserType>()
                .HasOne(pu => pu.userType)
                .WithMany(ut => ut.permissionsXUserType)
                .HasForeignKey(pu => pu.userType_Id)
                .OnDelete(DeleteBehavior.Restrict);


            //Permissions
            modelBuilder.Entity<Permissions>().HasKey(u => u.permissionsId);

            //UserType
            modelBuilder.Entity<UserType>().HasKey(u => u.userTypeId);

            //Gender
            modelBuilder.Entity<Gender>().HasKey(u => u.genderId);

            //IdentificationType
            modelBuilder.Entity<IdentificationType>().HasKey(c => c.IdentificationTypeId);

            //NutritionPlans
            modelBuilder.Entity<NutritionPlans>().HasKey(n => n.nutritionPlansId);

            //Meals
            modelBuilder.Entity<Meals>().HasKey(m => m.mealsId);

            //NutritionMeals
            modelBuilder.Entity<NutritionMeals>()
                .HasKey(nm => nm.nutritionMealsId);

            modelBuilder.Entity<NutritionMeals>()
                .HasOne(nm => nm.nutritionPlans)
                .WithMany(np => np.nutritionMeals)
                .HasForeignKey(nm => nm.nutritionPlans_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<NutritionMeals>()
                .HasOne(nm => nm.meals)
                .WithMany(m => m.nutritionMeals)
                .HasForeignKey(nm => nm.meals_Id)
                .OnDelete(DeleteBehavior.Restrict);


            //workout
            modelBuilder.Entity<Workout>().HasKey(m => m.workoutId);

            //Exercises
            modelBuilder.Entity<Exercises>().HasKey(m => m.exercisesId);

            //workoutExercises
            modelBuilder.Entity<WorkoutExercises>()
                .HasKey(we => we.workoutExercisesId);

            modelBuilder.Entity<WorkoutExercises>()
                .HasOne(we => we.workout)
                .WithMany(w => w.workoutExercises)
                .HasForeignKey(we => we.workout_Id)
                .OnDelete(DeleteBehavior.Restrict);

            modelBuilder.Entity<WorkoutExercises>()
                .HasOne(we => we.exercises)
                .WithMany(e => e.workoutExercises)
                .HasForeignKey(we => we.exercises_Id)
                .OnDelete(DeleteBehavior.Restrict);

        }

        public DbSet<User> user { get; set; }
        public DbSet<PermissionXUserType> permissionXUserType { get; set; }
        public DbSet<Permissions> permissions { get; set; }
        public DbSet<UserType> userType { get; set; }
        public DbSet<Gender> gender { get; set; }
        public DbSet<IdentificationType> identificationType { get; set; }
        public DbSet<NutritionPlans> nutritionPlans { get; set; }
        public DbSet<Meals> meals { get; set; }
        public DbSet<NutritionMeals> nutritionMeals { get; set; }
        public DbSet<Workout> workouts { get; set; }
        public DbSet<Exercises> exercises { get; set; }
        public DbSet<WorkoutExercises> workoutExercises { get; set; }
    }
}
