using Mapster;
using MOROPO.GEDET.CAM.Infrastructure.Extensions;

namespace MOROPO.GEDET.CAM.Presentation.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.UseInfrastructureLayer(builder.Configuration);

        builder.Services.AddMapster();

        builder.Services.AddControllers();

        builder.Services.AddOpenApiDocument();

        var app = builder.Build();

        app.UseHttpsRedirection();
        app.MapControllers();

        if (app.Environment.IsDevelopment())
        {
            // Add OpenAPI 3.0 document serving middleware
            // Available at: http://localhost:<port>/swagger/v1/swagger.json
            app.UseOpenApi();

            // Add web UIs to interact with the document
            // Available at: http://localhost:<port>/swagger
            app.UseSwaggerUi(); // UseSwaggerUI is called only in Development.

            // Add ReDoc UI to interact with the document
            // Available at: http://localhost:<port>/redoc
            app.UseReDoc(options =>
            {
                options.Path = "/redoc";
            });
        }

        app.Run();
    }
}
