using Microsoft.AspNetCore.Builder;
using MyClinicApp.DAL.Interfaces;
using MyClinicApp.DAL.Repositories;
using MyClinicApp.Service.Implementations;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using MyClinicApp.DAL.DBContext;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using MyClimicApp.API;
using Microsoft.OpenApi.Models;
using static System.Net.Mime.MediaTypeNames;
using System.Diagnostics.Metrics;
using System.Net;
using System.Reflection.Metadata;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(options =>
                options.UseNpgsql($"Host=localhost;Port=5432;Database=testDBClinic;Username=postgres;Password=Crjhgbjy123"));

builder.Services.AddTransient<IDoctorRepository, DoctorRepository>();
builder.Services.AddTransient<DoctorService>();

builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<UserService>();

builder.Services.AddTransient<IAppointmentRepository, AppointmentRepository>();
builder.Services.AddTransient<AppointmentService>();

builder.Services.AddTransient<ITimetableRepository, TimetableRepository>();
builder.Services.AddTransient<TimetableService>();

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.RequireHttpsMetadata = false;
        options.TokenValidationParameters = new TokenValidationParameters
        {
                            
            ValidateIssuer = true,
                            
            ValidIssuer = AuthOptions.ISSUER,

            ValidateAudience = true,
                            
            ValidAudience = AuthOptions.AUDIENCE,
                            
            ValidateLifetime = true,
                            
            IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                            
            ValidateIssuerSigningKey = true,
        };
    });
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(swagger =>
{
    //This is to generate the Default UI of Swagger Documentation
    swagger.SwaggerDoc("v1", new OpenApiInfo
    {
        Version = "v1",
        Title = "ASP.NET 5 Web API",
        Description = "Authentication and Authorization in ASP.NET 5 with JWT and Swagger"
    });
    // To Enable authorization using Swagger (JWT)
    swagger.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "Enter ‘Bearer’ [space] and then your valid token in the text input below.\r\n\r\nExample: \"Bearer eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9\"",
    });
    swagger.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                Type = ReferenceType.SecurityScheme,
                Id = "Bearer"
                }
            },
        new string[] {}
        }
    });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "MyClimicApp.API v1"));
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();