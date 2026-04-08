using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Interop.Contracts.Models.Image.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Terminal.Common.Extensions;

public static class ImageCreateRequestModelExtensions
{
    public static ImageSource ToImageSource(this ImageCreateRequestModel self)
    {
        return ImageSource.FromStream(() => new MemoryStream(self.ContentData));
    }
}
