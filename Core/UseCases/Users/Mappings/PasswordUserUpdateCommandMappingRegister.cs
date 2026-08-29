using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.Common.Ports.Service;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.CQRS.Command.Update;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Domain.Aggretates.UserAggregate.Values;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.Mappings;

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
            .Map(dest => dest.IsPasswordChangeRequired, src => src.IsChangePasswordRequired)
            .Map(dest => dest.Password, src => stringHashingService.GetHashed(src.Password))
            .Map(dest => dest.Id, src => new UserId(src.Id));
    }
}
