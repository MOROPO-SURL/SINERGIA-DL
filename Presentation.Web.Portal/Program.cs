using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Ports.Provider.Adapter;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Ports.Service.Adapter;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);

        builder.Services.AddScoped<IHtmlToPdfServicePort, WkhtmltopdfHtmlToPdfServicePortAdapter>();
        builder.Services.AddScoped<IViewRenderServicePort, DefaultViewRenderServicePortAdapter>();
        builder.Services.AddSingleton<IHttpClientProviderPort, HttpClientHelperProvider>();

        builder.Services.AddHttpContextAccessor();

        builder.Services.AddResponseCaching();
        builder.Services.AddDistributedMemoryCache();
        builder.Services.AddCors();

        builder.Services.AddControllersWithViews();

        var app = builder.Build();

        app
            .UseHttpsRedirection()
            .UseStaticFiles()
            .UseCors()
            .UseRouting();

        app.MapControllerRoute(
            name: "area_default",
            pattern: "{controller=home}/{action=index}/{key?}");

        app.Run();
    }
}
