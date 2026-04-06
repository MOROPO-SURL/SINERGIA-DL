using Mapster;
using MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Query.Detail;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.Mappings;

internal sealed class UserKeyDetailQueryMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserDetailQuery, UserId>()
            .MapWith(src => new UserId(src.Id));
    }
}