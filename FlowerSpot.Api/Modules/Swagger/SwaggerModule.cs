using Microsoft.OpenApi.Models;

namespace FlowerSpot.Api.Modules.Swagger
{
    public static class SwaggerModule
    {
        public static void AddSwaggerModule(this IServiceCollection services)
        {
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Flowers API", Version = "v1" });

                c.AddSecurityDefinition(JwtAuthenticationDefaults.AuthenticationScheme,
                new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization header using the Bearer scheme.",
                    Name = JwtAuthenticationDefaults.HeaderName,
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.Http,
                    Scheme = "bearer"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = JwtAuthenticationDefaults.AuthenticationScheme
                            }
                        },
                        new List<string>()
                    }
                });
            });
        }
    }
}