using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Archive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Disable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Enable;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Remove;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Unarchive;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Query.Detail;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.CQRS.Query.Paginate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Organizations.DTOs;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Interop.Contracts.Models.Organization.CQRS.Command;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.API.Models.Organizations.Mappings;

internal class OrganizationMappingRegister: IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        // TODO Remove !!!
    }
}
