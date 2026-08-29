using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;

public static class ImageBasicModelExtensions
{
    public static ImageSource ToImageSource(this ImageBasicDtoModel self)
    {
        var result = (UriImageSource)ImageSource.FromUri(new Uri($"{IPlatformApplication.Current!.Services.GetRequiredService<IHttpClientProviderPort>().GetHttpClient().BaseAddress}media/images/{self.Id}{self.Extension}"));

        result.CachingEnabled = true;
        result.CacheValidity = TimeSpan.FromDays(90);

        return result;
    }
}