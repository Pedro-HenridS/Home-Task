using application.Services.Account;
using application.Services.Encrypt;
using application.Services.Validation;
using application.UseCases;
using application.Validators;
using domain.Interfaces.Encrypt;
using domain.Interfaces.UsersInterfaces;
using hometask.api.Filters;
using infra;
using infra.Services.Encrypt;
using infra.Services.Users;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddRouting(op => op.LowercaseUrls = true);

builder.Services.AddControllers(options => {
    options.Filters.Add<ExceptionFilters>();
});

// validador
builder.Services.AddScoped<RegisterUserValidator>();

// services
builder.Services.AddScoped<ValidatorService>();
builder.Services.AddScoped<EmailAlreadyInUseService>();
builder.Services.AddScoped<RegisterUserService>();
builder.Services.AddScoped<PasswordHasherService>();

// Injeção de Dependência
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUserRegisterRepository, UserRegisterRepository>();

// UseCases
builder.Services.AddScoped<RegisterUseCase>();

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors());

var app = builder.Build();

if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

//app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
