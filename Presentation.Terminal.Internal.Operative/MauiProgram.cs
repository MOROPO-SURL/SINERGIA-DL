using CommunityToolkit.Maui;
using FFImageLoading.Maui;
using Microsoft.Extensions.Logging;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Ports.Helper;
using SkiaSharp.Views.Maui.Controls.Hosting;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Internal.Operative;

public static class MauiProgram
{
    public static MauiApp CreateMauiApp()
    {
        MauiAppBuilder builder = MauiApp.CreateBuilder();
        
        builder
            .UseMauiApp<App>()
            .UseMauiCommunityToolkit()  
            .UseFFImageLoading()
            .UseSkiaSharp(true)
            .ConfigureFonts(fonts =>
            {
                fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                fonts.AddFont("materialdesignicons-webfont.ttf", "MaterialDesignIcons");
            })
            .UsePresentationCommonDefaults()
            .Services
                .AddSingleton<IHttpClientProviderPort, Ports.Adapter.Provider.HttpClientHelperProvider>()
                .AddSingleton<IExceptionHandlingHelperPort, Ports.Adapter.Helper.ExceptionHandlingHelperPortAdapter>()
                .AddSingleton<ILocalizationHelperPort, Ports.Adapter.Helper.LocalizationHelperPortAdapter>();

#if DEBUG
        builder.Logging.AddDebug();
#endif

        return builder.Build();
    }
}
