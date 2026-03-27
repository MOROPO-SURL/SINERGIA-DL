using MOROPO.GEDET.CAM.Infrastructure.Extensions;

namespace MOROPO.GEDET.CAM.Presentation.API;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.UseInfrastructure(builder.Configuration);

        var app = builder.Build();

        app.MapGet("/", () => "Hello World!");

        app.Run();
    }
}
