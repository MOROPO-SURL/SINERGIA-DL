using Mapster;
using MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Command.Update;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.Mappings;

internal class UserUpdateCommandMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<FullUserUpdateCommand, User>()
            .Map(dest => dest.Id, src => new UserId(src.Id))
            .Map(dest => dest, src => src);
    }
}
