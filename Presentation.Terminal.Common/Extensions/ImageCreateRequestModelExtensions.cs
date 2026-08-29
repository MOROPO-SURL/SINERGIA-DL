using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Image.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Terminal.Common.Extensions;

public static class ImageCreateRequestModelExtensions
{
    public static ImageSource ToImageSource(this ImageCreateRequestModel self)
    {
        return ImageSource.FromStream(() => new MemoryStream(self.ContentData));
    }
}
