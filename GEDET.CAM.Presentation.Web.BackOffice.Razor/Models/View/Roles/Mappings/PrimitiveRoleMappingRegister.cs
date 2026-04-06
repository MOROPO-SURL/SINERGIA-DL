using Mapster;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Command.Remove;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Detail;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.CQRS.Query.Paginate;
using MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs;

namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Models.View.Roles.Mappings;

internal sealed class PrimitiveRoleMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), RolePaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<Guid, RoleDetailQuery>()
            .Map(dest => dest.Id, src => src);

        config.NewConfig<RoleDetailDto, Guid>()
            .MapWith(src => src.Id);

        config.NewConfig<Guid, RoleRemoveCommand>()
            .Map(dest => dest.Id, src => src);
    }
}