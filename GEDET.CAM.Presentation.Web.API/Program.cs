using Mapster;
using Microsoft.Extensions.Options;
using MOROPO.GEDET.CAM.Core.Extensions;
using MOROPO.GEDET.CAM.Infrastructure.Configurations;
using MOROPO.GEDET.CAM.Infrastructure.Extensions;
using MOROPO.GEDET.CAM.Presentation.Web.API.Configurations;
using System.Runtime.CompilerServices;

namespace MOROPO.GEDET.CAM.Presentation.Web.API;

public class Program
{
    [ModuleInitializer]
    public static void Initialize()
    {
        AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
        AppContext.SetSwitch("System.Drawing.EnableUnixSupport", true);
    }

    public static void Main(string[] args)
    {
        JWTConfiguration jwtConfiguration = new();

        var builder = WebApplication.CreateBuilder(args);

        builder.Configuration.Bind("JWT", jwtConfiguration);

        var jwtConfigurationOptions = Options.Create(jwtConfiguration);

        builder.Services.AddSingleton(jwtConfigurationOptions);

        builder.Services.Configure<AuthenticationConfiguration>(builder.Configuration.GetSection("Authentication"));

        builder.Services.UseCoreLayer();
        builder.Services.UseInfrastructureLayer(builder.Configuration);

        TypeAdapterConfig.GlobalSettings.Apply(
            new Models.Authentication.Mappings.AuthenticatedSessionModelMappingRegister(jwtConfigurationOptions)
        );

        builder.Services.AddMapster();

        builder.Services.AddAuthentication(options =>
        {
            options.DefaultScheme = Microsoft.AspNetCore.Authentication.JwtBearer.JwtBearerDefaults.AuthenticationScheme;
        })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new Microsoft.IdentityModel.Tokens.TokenValidationParameters
                {
                    ValidateAudience = false,
                    ValidateIssuer = true,
                    ValidIssuer = jwtConfiguration.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new Microsoft.IdentityModel.Tokens.SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes(jwtConfiguration.JwtSecretKey)),
                    ValidateLifetime = true
                };
            });

        builder.Services.AddControllers();

        builder.Services.AddOpenApiDocument();

        var app = builder.Build();

        app.Services.ApplyCoreMappings();

        app.UseHttpsRedirection();
        app.UseAuthentication();
        app.UseAuthorization();
        app.MapControllers();

        if (app.Environment.IsDevelopment())
        {
            // Add web UIs to interact with the document
            // Available at: http://localhost:<port>/swagger
            app.UseSwaggerUi(); // UseSwaggerUI is called only in Development.
        }

        // Add OpenAPI 3.0 document serving middleware
        // Available at: http://localhost:<port>/swagger/v1/swagger.json
        app.UseOpenApi();

        // Add ReDoc UI to interact with the document
        // Available at: http://localhost:<port>/redoc
        app.UseReDoc(options =>
        {
            options.Path = "/redoc";
        });

        app.Run();
    }
}
