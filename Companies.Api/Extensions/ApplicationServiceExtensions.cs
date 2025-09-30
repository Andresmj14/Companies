using System;
using System.Threading.RateLimiting;
using Companies.Application.Abstractions;
using Companies.Application.Common.Behaviors;
//using Companies.Infrastructure.Repositories;
using Companies.Infrastructure.UnitOfWork;
using FluentValidation;
using MediatR;

namespace Companies.Api.Extensions;

public static class ApplicationServiceExtensions
{
    public static void ConfigureCors(this IServiceCollection services) =>
        services.AddCors(options =>
        {
            HashSet<String> allowed = new HashSet<string>(StringComparer.OrdinalIgnoreCase)
            {
                "http://app.ejemplo.com",
            };
            options.AddPolicy("CorsPolicy", builder =>
                builder.AllowAnyOrigin()   //WithOrigins("https://dominio.com")
                .AllowAnyMethod()          //WithMethods("GET","POST")
                .AllowAnyHeader());
            options.AddPolicy("CorsPolicyUrl", builder =>
                builder.WithOrigins("htpps://localhost:4200")   //WithOrigins("https://dominio.com")
                .AllowAnyMethod()          //WithMethods("GET","POST")
                .AllowAnyHeader()
            ); //WithHeaders("accept","content-type")
        options.AddPolicy("Dinamica", builder =>
            builder.SetIsOriginAllowed(origin => allowed.Contains(origin))
            .WithMethods("GET", "POST")
            .WithHeaders("Content-Type", "Athorization")
            );
        });

    public static void AddApplicationServices(this IServiceCollection services)
    {
        //services.AddScoped<IUnitOfWork, UnitOfWork>();
        services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Program).Assembly));
        services.AddValidatorsFromAssembly(typeof(Program).Assembly);
        services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
        services.AddTransient(typeof(IPipelineBehavior<,>), typeof(ValidationBehavior<,>));
        //services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(Companies.Application.Products.CreateProduct).Assembly));
    }
    public static IServiceCollection AddCustomRateLimiter(this IServiceCollection services)
{
    services.AddRateLimiter(options =>
    {   
        options.OnRejected = async (context, token) =>
        {
            var ip = context.HttpContext.Connection.RemoteIpAddress?.ToString() ?? "desconocida";
            context.HttpContext.Response.StatusCode = 429;
            context.HttpContext.Response.ContentType = "application/json";
            var mensaje = $"{{\"message\": \"Demasiadas peticiones desde la IP {ip}. Intenta más tarde.\"}}";
            await context.HttpContext.Response.WriteAsync(mensaje, token);
        };

        // Aquí no se define GlobalLimiter
        options.AddPolicy("ipLimiter", httpContext =>
        {
            var ip = httpContext.Connection.RemoteIpAddress?.ToString() ?? "unknown";
            return RateLimitPartition.GetFixedWindowLimiter(ip, _ => new FixedWindowRateLimiterOptions
            {
                PermitLimit = 5,
                Window = TimeSpan.FromSeconds(10),
                QueueLimit = 0,
                QueueProcessingOrder = QueueProcessingOrder.OldestFirst
            });
        });
        // Fixed Window Limiter
        // options.AddFixedWindowLimiter("fixed", opt =>
        // {
        //     opt.Window = TimeSpan.FromSeconds(10);
        //     opt.PermitLimit = 5;
        //     opt.QueueLimit = 0;
        //     opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        // });

        // Sliding Window Limiter
        // options.AddSlidingWindowLimiter("sliding", opt =>
        // {
        //     opt.Window = TimeSpan.FromSeconds(10);
        //     opt.SegmentsPerWindow = 3;
        //     opt.PermitLimit = 6;
        //     opt.QueueLimit = 0;
        //     opt.QueueProcessingOrder = QueueProcessingOrder.NewestFirst;
        //     // Aquí se personaliza la respuesta cuando se excede el límite
        // });

        // Token Bucket Limiter
        // options.AddTokenBucketLimiter("token", opt =>
        // {
        //     opt.TokenLimit = 20;
        //     opt.TokensPerPeriod = 4;
        //     opt.ReplenishmentPeriod = TimeSpan.FromSeconds(10);
        //     opt.QueueLimit = 2;
        //     opt.QueueProcessingOrder = QueueProcessingOrder.OldestFirst;
        //     opt.AutoReplenishment = true;
        // });

    });

    return services;
}
}
