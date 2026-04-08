using Mapster;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Permissions.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Roles.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.DTOs;
using MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Domain.Aggretates.UserAggregate;

namespace MOROPO.PDLCoLabCMG.GEDEL.CAMCMG.Core.UseCases.Users.Mappings;

internal class UserDetailDtoMappingRegister : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<User, UserDetailDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest.Roles, src => src.RoleBridges.Select(bridge => new RoleDetailDto(bridge.LinkedId.Value, bridge.Linked!.Name, Array.Empty<PermissionDetailDto>(), bridge.Linked.Description)))
            .Map(dest => dest, src => src);
    }
}
