using Microsoft.EntityFrameworkCore;
using PostApp.Infra.Data;
using Scalar.AspNetCore;
using PostApp.Api.Extensions;
using PostApp.Application;
using PostApp.Infra;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("SqlServer")));

// Add Application Layer services (includes MediatR and FluentValidation)
builder.Services.AddApplication();

// Add Infrastructure Layer services (includes repositories, services, and configurations)
builder.Services.AddInfrastructure(builder.Configuration);

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.MapScalarApiReference();
}

app.UseHttpsRedirection();

// Map Authentication Endpoints
app.MapAuthEndpoints();

app.Run();

