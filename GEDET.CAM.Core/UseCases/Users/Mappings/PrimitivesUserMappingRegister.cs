using Mapster;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.Mappings;

internal sealed class PrimitivesUserMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<string, UserId>()
            .MapWith(src => new UserId(src));
    }
}
