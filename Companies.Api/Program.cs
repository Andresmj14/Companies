using Companies.Api.Extensions;
using Companies.Application.Abstractions;
//using Companies.Infrastructure.Persistence;
//using Companies.Infrastructure.Repositories;
using FluentValidation;
using Microsoft.EntityFrameworkCore;
using MediatR;
using Companies.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
//builder.Services.ConfigureCors();
builder.Services.AddControllers();
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
// DbContext + Npgsql
builder.Services.AddDbContext<AppDbContext>(options =>
{
    string connectionString = builder.Configuration.GetConnectionString("Postgres")!;
    options.UseNpgsql(connectionString);
    options.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
});

// DI repositorio
//builder.Services.AddScoped<IProductRepository, ProductRepository>();

// MediatR / FluentValidation / AutoMapper (si los agregaste)
builder.Services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
builder.Services.AddValidatorsFromAssembly(typeof(Program).Assembly);
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
}
app.UseCors("CorsPolicy");
app.UseCors("Dinamica");
app.UseCors("CorsPolicyUrl");
app.UseHttpsRedirection();
app.UseRateLimiter();

app.UseAuthorization();

app.MapControllers();

app.Run();
