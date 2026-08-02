using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microsoft.Extensions.Logging;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.Common.Ports.Helper;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.External.MiPyME;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        var builder = MauiApp.CreateBuilder();
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()
            .UseFFImageLoading()
            .UsePresentationCommonDefaults()
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("materialdesignicons-webfont.ttf", "MaterialDesignIcons");
            })
            .Services
                .AddSingleton<IHttpClientProviderPort, Common.Ports.Adapter.Provider.HttpClientHelperProvider>()
                .AddSingleton<IExceptionHandlingHelperPort, Common.Ports.Adapter.Helper.ExceptionHandlingHelperPortAdapter>()
                .AddSingleton<ILocalizationHelperPort, Ports.Adapter.Helper.LocalizationHelperPortAdapter>()
                .AddSingleton<IAppShellContextBindingHelperPort, Ports.Adapter.Helper.AppShellContextBindingHelperPortAdapter>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
