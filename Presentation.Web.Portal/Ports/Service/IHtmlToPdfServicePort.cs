namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Ports.Service;

public interface IHtmlToPdfServicePort
{
    Task<byte[]> GeneratePdfFromHtmlAsync(string htmlContent, Models.Options.PdfOptionsModel? options = null);
}