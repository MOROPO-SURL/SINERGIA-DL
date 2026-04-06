using Mapster;
using MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Command.Remove;
using MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Query.Detail;
using MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Query.Paginate;
using MOROPO.GEDET.CAM.Core.UseCases.Users.DTOs;

namespace MOROPO.GEDET.CAM.Presentation.Web.BackOffice.Razor.Models.View.Users.Mappings;

internal sealed class PrimitiveUserMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<(int Sheet, int Limit), UserPaginateQuery>()
            .Map(dest => dest.Page, src => src.Sheet)
            .Map(dest => dest.Limit, src => src.Limit);

        config.NewConfig<string, UserDetailQuery>()
            .MapWith(src => new UserDetailQuery(src));

        config.NewConfig<UserDetailDto, string>()
            .MapWith(src => src.Id);

        config.NewConfig<string, UserRemoveCommand>()
            .Map(dest => dest.Id, src => src);
    }
}