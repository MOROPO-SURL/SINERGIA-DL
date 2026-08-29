using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.CQRS.Command.Create;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.Mappings;

internal class UserCreateCommandMappingRegister : IRegister
{
    private readonly IStringHashingServicePort stringHashingService;

    public UserCreateCommandMappingRegister(IStringHashingServicePort stringHashingService)
    {
        this.stringHashingService = stringHashingService;
    }

    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserCreateCommand, User>()
            .Map(dest => dest.Id, src => new UserId(src.Id))
            .Map(dest => dest.Password, src => stringHashingService.GetHashed(src.Password))
            .Map(dest => dest, src => src);
    }
}
