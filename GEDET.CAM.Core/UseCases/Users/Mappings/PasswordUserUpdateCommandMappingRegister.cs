using Mapster;
using MOROPO.GEDET.CAM.Core.Common.Ports.Service;
using MOROPO.GEDET.CAM.Core.UseCases.Users.CQRS.Command.Update;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate;
using MOROPO.GEDET.CAM.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.GEDET.CAM.Core.UseCases.Users.Mappings;

internal class PasswordUserUpdateCommandMappingRegister : IRegister
{
    private readonly IStringHashingServicePort stringHashingService;

    public PasswordUserUpdateCommandMappingRegister(IStringHashingServicePort stringHashingService)
    {
        this.stringHashingService = stringHashingService;
    }

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<PasswordUserUpdateCommand, User>()
            .Map(dest => dest.IsPasswordChangeRequired, src => false)
            .Map(dest => dest.Password, src => stringHashingService.GetHashed(src.Password))
            .Map(dest => dest.Id, src => new UserId(src.Id));
    }
}
