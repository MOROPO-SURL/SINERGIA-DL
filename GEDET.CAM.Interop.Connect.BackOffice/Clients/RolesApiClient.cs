using MOROPO.GEDET.CAM.Interop.Connect.Ports.Provider;
using MOROPO.GEDET.CAM.Interop.Contracts.Models.Role.CQRS.Command;
using MOROPO.GEDET.CAM.Interop.Contracts.Models.Role.DTOs;

namespace MOROPO.GEDET.CAM.Interop.Connect.BackOffice.Clients;

internal sealed class RolesApiClient : Connect.Clients.Abstracts.AbstractQueryAndCommandApiClient<Guid, RoleCreateRequestModel, RoleUpdateRequestModel, RoleBasiclModel, RoleDetailModel>
{
    public RolesApiClient(IHttpClientProviderPort httpClientProvider) : base(httpClientProvider)
    {
    }

    protected override string GetUseCaseBaseUriSegment() => "api/roles";
}
