using Mapster;
using MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Core.UseCases.Users.CQRS.Command.Update;

namespace MOROPO.PDLCoLabCMG.SINERGIADL.CMG.Presentation.Web.BackOffice.Razor.Models.View.Users.Mappings;

public class UserChangePasswordViewModelMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<UserChangePasswordViewModel, PasswordUserUpdateCommand>()
            .Map(dest => dest.Id, src => src.UserId)
            .Map(dest => dest.Password, src => src.NewPassword)
            .Map(dest => dest, src => src);
    }
}
