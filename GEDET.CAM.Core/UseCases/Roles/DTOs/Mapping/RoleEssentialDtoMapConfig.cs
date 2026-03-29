using Mapster;
using MOROPO.GEDET.CAM.Domain.Aggretates.RoleAggregate;

namespace MOROPO.GEDET.CAM.Core.UseCases.Roles.DTOs.Mapping;

public class RoleEssentialDtoMapConfig : IRegister
{
    public void Register(TypeAdapterConfig config)
    {
        config.NewConfig<Role, RoleEssentialDto>()
            .Map(dest => dest.Id, src => src.Id.Value)
            .Map(dest => dest, src => src);
    }
}