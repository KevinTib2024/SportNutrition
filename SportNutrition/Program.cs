using Microsoft.EntityFrameworkCore;
using SportNutrition.Context;
using SportNutrition.Repository;
using SportNutrition.Service;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var conString = builder.Configuration.GetConnectionString("Connection");
builder.Services.AddDbContext<SportNutritionDbContext>(options => options.UseSqlServer(conString));

//Controller y service 

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IUserTypeRepository, UserTypeRepository>();
builder.Services.AddScoped<IUserTypeService, UserTypeService>();

builder.Services.AddScoped<IPermissionsXUserTypeRepositorycs, PermissionsXUserTypeRepositorycs>();
builder.Services.AddScoped<IPermissionsXUserTypeService, PermissionsXUserTypeService>();

builder.Services.AddScoped<IPermissionsRepository, PermissionsRepository>();
builder.Services.AddScoped<IPermissionsService, PermissionsService>();

builder.Services.AddScoped<IIdentificationTypeRepository, IdentificationTypeRepository>();
builder.Services.AddScoped<IIdentificationTypeService, IdentificationTypeService>();

builder.Services.AddScoped<IGenderRepository, GenderRepository>();
builder.Services.AddScoped<IGenderService, GenderService>();

builder.Services.AddScoped<INutritionMealsRepository, NutritionMealsRepository>();
builder.Services.AddScoped<INutritionMealsService, NutritionMealsService>();

builder.Services.AddScoped<INutritionPlansRepository, NutritionPlansRepository>();
builder.Services.AddScoped<INutritionPlansService, NutritionPlansService>();

builder.Services.AddScoped<IMealsRepository, MealsRepository>();
builder.Services.AddScoped<IMealsService, MealsService>();

builder.Services.AddScoped<IWorkoutExercisesRepository, WorkoutExercisesRepository>();
builder.Services.AddScoped<IWorkoutExercisesService, WorkoutExercisesService>();

builder.Services.AddScoped<IWorkoutRepository, WorkoutRepository>();
builder.Services.AddScoped<IWorkoutService, WorkoutService>();

builder.Services.AddScoped<IExercisesRepository, ExercisesRepository>();
builder.Services.AddScoped<IExercisesService, ExercisesService>();

builder.Services.AddScoped<ILoginRepository, LoginRepository>();
builder.Services.AddScoped<ILoginService, LoginService>();


builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
    builder => builder
        .AllowAnyOrigin()
        .AllowAnyMethod()
        .AllowAnyHeader());
});

builder.Services.AddControllers();

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

var app = builder.Build();

//use cors
app.UseCors("AllowAll");

if (app.Environment.IsDevelopment())
{
    app.UseDeveloperExceptionPage();
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    // En producción quizá quieras otro middleware de errores…
    app.UseSwagger();
    app.UseSwaggerUI();
}

// Configure the HTTP request pipeline.
app.UseSwagger();
app.UseSwaggerUI();



app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
