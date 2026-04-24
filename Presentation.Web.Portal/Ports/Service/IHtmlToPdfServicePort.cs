namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.Portal.Ports.Service;

public interface IHtmlToPdfServicePort
{
    Task<byte[]> GeneratePdfFromHtmlAsync(string htmlContent, Models.Options.PdfOptionsModel? options = null);
}