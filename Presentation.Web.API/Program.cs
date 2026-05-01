using Mapster;
using Microsoft.Extensions.Options;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Configurations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Service;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Configurations;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Extensions;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API.Ports.Adapter.Service;
using NSwag;
using System.Runtime.CompilerServices;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.API;

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

        WebApplicationBuilder builder = WebApplication.CreateBuilder(args);

        builder.Configuration.Bind("JWT", jwtConfiguration);

        IOptions<JWTConfiguration> jwtConfigurationOptions = Options.Create(jwtConfiguration);

        builder.Services.AddSingleton(jwtConfigurationOptions);

        builder.Services.Configure<AuthenticationConfiguration>(builder.Configuration.GetSection("Authentication"));

        builder.Services.UseCoreLayer();
        builder.Services.UseInfrastructureLayer(builder.Configuration);

        builder.Services.AddScoped<IDomainChangeAuthorProvisionServicePort, DomainChangeAuthorProvisionServicePortAdapter>();

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

        builder.Services.AddOpenApiDocument(options => {
            options.PostProcess = document =>
            {
                document.Info = new OpenApiInfo
                {
                    Version = "v1",
                    Title = "GEDEL API",
                    Description = "API pública de la Plataforma de Gestión del Desarrollo Local del CAM de Camagüey",
                    TermsOfService = "https://portal.gedel.gobcmg.com.cu/terms",
                    Contact = new OpenApiContact
                    {
                        Name = "Contacto",
                        Url = "https://portal.gedel.gobcmg.com.cu/contact"
                    },
                    License = new OpenApiLicense
                    {
                        Name = "Licencia opensource",
                        Url = "https://portal.gedel.gobcmg.com.cu/license"
                    }
                };
            };
        });

        var app = builder.Build();

        app.Services.ApplyCoreMappings();
        app.Services.ApplyMappins();

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
