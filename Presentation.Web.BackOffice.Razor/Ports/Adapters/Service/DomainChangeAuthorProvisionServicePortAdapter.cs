using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Infrastructure.Ports.Service;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Ports.Adapters.Service;

public class DomainChangeAuthorProvisionServicePortAdapter : IDomainChangeAuthorProvisionServicePort
{
    private readonly IHttpContextAccessor contextAccessor;

    public DomainChangeAuthorProvisionServicePortAdapter(IHttpContextAccessor contextAccessor)
    {
        this.contextAccessor = contextAccessor;
    }

    public string? GetChangeAuthor()
    {
        return contextAccessor.HttpContext!.User.Identity?.Name;
    }
}
