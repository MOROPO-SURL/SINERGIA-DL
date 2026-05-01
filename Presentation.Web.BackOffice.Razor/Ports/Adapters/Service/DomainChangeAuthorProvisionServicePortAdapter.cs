using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Infrastructure.Ports.Service;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Presentation.Web.BackOffice.Razor.Ports.Adapters.Service;

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
