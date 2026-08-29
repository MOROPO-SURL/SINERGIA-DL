namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.Portal.Ports.Service;

public interface IViewRenderServicePort
{
    Task<string> RenderViewToStringAsync(string viewName, object model);
    Task<string> RenderPartialViewToStringAsync(string viewName, object model);
}