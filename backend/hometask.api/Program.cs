using application.Services.Account;
using application.Services.Encrypt;
using application.Services.Jwt;
using application.UseCases;
using application.Validators;
using domain.Interfaces.Encrypt;
using domain.Interfaces.Token;
using domain.Interfaces.UsersInterfaces;
using hometask.api.Filters;
using infra;
using infra.Services.Encrypt;
using infra.Services.Users;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddUserSecrets<Program>(optional: true);

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
builder.Services.AddScoped<EmailAlreadyInUseService>();
builder.Services.AddScoped<RegisterUserService>();
builder.Services.AddScoped<PasswordHasherService>();
builder.Services.AddScoped<VerifyHashService>();
builder.Services.AddScoped<JwtService>();
builder.Services.AddScoped<FindAccountService>();

// Injeção de Dependência
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();
builder.Services.AddScoped<IUserRegisterRepository, UserRegisterRepository>();
builder.Services.AddScoped<IVerifyPasswordHash, VerifyPasswordHash>();

// UseCases
builder.Services.AddScoped<RegisterUseCase>();
builder.Services.AddScoped<LoginUseCase>();

builder.Services.Configure<IJwtSettings>(builder.Configuration.GetSection("Jwt"));

var connectionString = builder.Configuration.GetConnectionString("DefaultConnection");

builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
    .EnableSensitiveDataLogging()
    .EnableDetailedErrors());

builder.Services.AddAuthentication("Bearer")
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]!)
            )
        };
    });

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
