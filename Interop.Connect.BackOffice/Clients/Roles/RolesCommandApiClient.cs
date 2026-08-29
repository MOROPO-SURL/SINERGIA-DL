using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Clients.Abstracts;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.Ports.Provider;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Role.CQRS.Command;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Role.DTOs;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Connect.BackOffice.Clients.Roles;

public sealed class RolesCommandApiClient : AbstractCommandApiClient<Guid, RoleCreateRequestModel, RoleUpdateRequestModel, RoleDetailDtoModel>
{
    public RolesCommandApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/roles";
}